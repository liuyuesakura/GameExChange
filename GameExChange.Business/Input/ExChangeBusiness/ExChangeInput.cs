using System;
using System.Collections.Generic;
using System.Text;

using GameExChange.Entity;

namespace GameExChange.Business.Input.ExChangeBusiness
{
    /// <summary>
    /// 交换
    /// </summary>
    public class ExChangeInput
    {
        /// <summary>
        /// 目标游戏ID
        /// </summary>
        public int GameId { set; get; }

        /// <summary>
        /// 可交换的游戏ID
        /// </summary>
        public int ProvideGameId { set; get; }

        /// <summary>
        /// 申请交换的用户
        /// </summary>
        public User Borrower { set; get; }

        /// <summary>
        /// 交换期限
        /// </summary>
        public int ExpireDays { set; get; }

        /// <summary>
        /// 申请方的地址
        /// </summary>
        public int AddressId { set; get; }

    }
}
