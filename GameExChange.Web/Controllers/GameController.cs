using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using GameEntity = GameExChange.Entity.Game;

using UserAuthorization = GameExChange.Web.Common.UserAuthorization;

namespace GameExChange.Web.Controllers
{
    [Route("api/[controller]")]
    public class GameController : Controller
    {

        private readonly Business.IGameBusniess _gameBusniess;

        public GameController(Business.IGameBusniess busniess)
        {
            _gameBusniess = busniess;
        }
        // GET: Game
        public ActionResult Index()
        {
            return View();
        }

        // GET: Game/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        /// <summary>
        /// 获取可借游戏的分页数据
        /// </summary>
        /// <param name="pageindex"></param>
        /// <returns></returns>
        [HttpGet("[action]")]
        [UserAuthorization(Method = "GetList",LoginRequired = false)]
        public IEnumerable<GameEntity> GetList(int pageindex)
        {
            List<GameEntity> gelist = new List<GameEntity>();

            _gameBusniess.GetList(new Business.Input.GameBusniess.GetListInput() {
                PageIndex = pageindex
            });

            //gelist.Add(new GameEntity()
            //{
            //    Id = 0,
            //    AddTimeStamp = DateTime.Now,
            //    ExchangedNum = 0,
            //    GameName = "GameName",
            //    GameType = "GameType",
            //    HoldNum = 10,

            //    Remark = "Remark",
            //    Status = 0,
            //    UserId = 0,
            //});

            //gelist.Add(new GameEntity()
            //{
            //    Id = 1,
            //    AddTimeStamp = DateTime.Now,
            //    ExchangedNum = 0,
            //    GameName = "GameName2",
            //    GameType = "GameType2",
            //    HoldNum = 10,

            //    Remark = "Remark2",
            //    Status = 0,
            //    UserId = 0,
            //});

            return gelist;
        }

        [HttpGet("[action]")]
        [UserAuthorization(Method = "AddGame", LoginRequired = true)]
        public GameExChange.Business.Output.GameBusniess.GameAddOutput AddGame(GameExChange.Entity.Game gameEntity)
        {
            GameExChange.Business.Output.GameBusniess.GameAddOutput result = new Business.Output.GameBusniess.GameAddOutput();
            if (string.IsNullOrEmpty(gameEntity.GameName))
            {
                result = new Business.Output.GameBusniess.GameAddOutput()
                {
                    IsSuccess = false,
                    ErrMessage = "游戏名称不可为空"
                };
            }

            gameEntity.HoldNum = gameEntity.HoldNum <= 0 ? 1 : gameEntity.HoldNum;
            gameEntity.Status = (int)GameExChange.Entity.Enum.Game.Status.Pending;
            //gameEntity.UserId = 
            gameEntity.AddTimeStamp = DateTime.Now;
            gameEntity.ExchangedNum = 0;

            result = _gameBusniess.Add(new Business.Input.GameBusniess.GameAddInput() { Entity = gameEntity,User = new Entity.User() { } });
            return result;
        }
        //// GET: Game/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: Game/Create
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(IFormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add insert logic here

        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: Game/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        //// POST: Game/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add update logic here

        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: Game/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: Game/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add delete logic here

        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}