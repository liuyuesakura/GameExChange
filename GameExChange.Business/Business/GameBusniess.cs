
using GameExChange.Entity;
using GameEntity = GameExChange.Entity.Game;
using GameExChange.Repository.Contract;
using System.Collections.Generic;
using System.Linq;
using GameExChange.Infrastructure.Interface;
using GameExChange.Business.Input.GameBusniess;
using GameExChange.Business.Output.GameBusniess;

using Spec = GameExChange.Infrastructure.Specifications;
using System;
using System.Linq.Expressions;

namespace GameExChange.Business
{
    public class GameBusniess : IGameBusniess
    {

        private readonly IGameRepository _gameRepository;
        private readonly IUnitOfWork _unitOfWork;

        public GameBusniess(IGameRepository gameRepository, IUnitOfWork unitOfWork)
        {
            _gameRepository = gameRepository;
            _unitOfWork = unitOfWork;
        }
        /// <summary>
        /// 添加游戏
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public GameAddOutput Add(GameAddInput input)
        {


            return new GameAddOutput()
            {
                IsSuccess = true,
                ErrMessage = ""
            };
        }

        public GetListOutput GetList(GetListInput input)
        {
            try
            {
                Expression<Func<GameEntity, bool>> expression = Spec.Specification<GameEntity>.Eval(x => x.Id > 0).Expression;
                if (!string.IsNullOrEmpty(input.GameName))
                {
                    expression = Spec.SpecExprExtensions.And(expression, x => x.GameName.IndexOf(input.GameName) >= 0);
                }
                if(!string.IsNullOrEmpty(input.GameType))
                {
                    expression = Spec.SpecExprExtensions.And(expression, x => x.GameName.IndexOf(input.GameType) >= 0);
                }

                Spec.ExpressionSpecification<GameEntity> spec = new Spec.ExpressionSpecification<GameEntity>(expression);

                var list = _gameRepository.GetAll(
                    spec,
                    x => x.Id,
                    Infrastructure.Utils.SortOrder.Descending,
                    input.PageIndex,
                    input.PageSize
                );

                return new GetListOutput()
                {
                    IsSuccess = true,
                    Games = list.PageData,
                    ErrMessage = ""
                };
            }
            catch (Exception ex)
            {

                return new GetListOutput()
                {
                    IsSuccess = false,
                    Games = new List<GameEntity>(),
                    ErrMessage = ex.Message
                };
            }
        }


    }
}
