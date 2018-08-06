
using GameEntity = GameExChange.Entity.Game;
using ExchangeRecordEntity = GameExChange.Entity.ExchangeRecord;
using UserEntity = GameExChange.Entity.User;

using GameExChange.Repository.Contract;
using System.Collections.Generic;
using System.Linq;

using Spec = GameExChange.Infrastructure.Specifications;
using System;
using System.Linq.Expressions;
using GameExChange.Business.Input.ExChangeBusiness;
using GameExChange.Business.Output.ExChangeBusiness;
using GameExChange.Infrastructure.Interface;

namespace GameExChange.Business.Business
{
    /// <summary>
    /// 游戏交换
    /// </summary>
    public class ExChangeBusiness : IExChangeBusiness
    {
        private readonly IGameRepository _gameRepository;
        private readonly IUserRepository _userRepository;
        private readonly IExchangeRecordRepository _exchangeRecordRepository;

        private readonly IUnitOfWork _unitOfWork;

        public ExChangeBusiness(IGameRepository gameRepository,
            IUserRepository userRepository,
            IExchangeRecordRepository exchangeRecordRepository,
            IUnitOfWork unitOfWork)
        {
            _gameRepository = gameRepository;
            _userRepository = userRepository;
            _exchangeRecordRepository = exchangeRecordRepository;

            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// 申请仅借入 （还没写完)
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public BorrowOutput Borrow(ExChangeInput input)
        {
            GameEntity game = _gameRepository.Get(x=>x.Id == input.GameId);
            if(game.HoldNum <= game.ExchangedNum)
            {
                return new BorrowOutput()
                {
                    IsSuccess = false,
                    ErrMessage = "该游戏已被借完"
                };
            }

            UserEntity lender = _userRepository.Get(x=>x.Id == game.UserId);

            ExchangeRecordEntity record = new ExchangeRecordEntity()
            {
                AddTime = DateTime.Now,
                BorrowAddressId = input.AddressId,
                Borrower = input.Borrower.Id,
                BorrowerGameId = 0,
                BorrowerName = input.Borrower.UserName,
                BorrowGameName = "",
                ExchangeDays = input.ExpireDays,
                ExchangeType = (int)GameExChange.Entity.Enum.ExChangeRecord.Types.Borrow,
                Lender = lender.Id,
                //出借人的地址待通过时写入
                LenderAddressId = 0,
                LenderGameId = game.Id,
                LenderGameName = game.GameName,
                LenderName = lender.UserName,
                RealReturningTime = DateTime.Now,
                Status = (int)GameExChange.Entity.Enum.ExChangeRecord.Statues.BorrowerApplying,

            };

            //有未归还的游戏时禁止再借

            //修改 game对象

            //写入 exchange表

            throw new NotImplementedException();
        }

        /// <summary>
        /// 申请交换
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public ExChangeOutput ExChange(ExChangeInput input)
        {
            throw new NotImplementedException();
        }

    }
}
