﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using GameEntity = GameExChange.Entity.Game;

namespace GameExChange.Web.Controllers
{
    [Route("api/[controller]")]
    public class GameController : Controller
    {
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
        public IEnumerable<GameEntity> GetList(int pageindex)
        {
            List<GameEntity> gelist = new List<GameEntity>();

            gelist.Add(new GameEntity()
            {
                Id = 0,
                AddTimeStamp = DateTime.Now,
                ExchangedNum = 0,
                GameName = "GameName",
                GameType = "GameType",
                HoldNum = 10,

                Remark = "Remark",
                Status = 0,
                UserId = 0,
            });

            gelist.Add(new GameEntity()
            {
                Id = 1,
                AddTimeStamp = DateTime.Now,
                ExchangedNum = 0,
                GameName = "GameName2",
                GameType = "GameType2",
                HoldNum = 10,

                Remark = "Remark2",
                Status = 0,
                UserId = 0,
            });

            return gelist;
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