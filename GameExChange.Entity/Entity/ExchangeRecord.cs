using System;

namespace GameExChange.Entity
{
    /// <summary>
    /// 交换记录
    /// </summary>
    public class ExchangeRecord : AggregateRoot
    {

        #region database columns
        ///// <summary>
        ///// Id
        ///// </summary>		
        //public int Id { get; set; }
        /// <summary>
        /// LenderGameId
        /// </summary>		
        public int LenderGameId { get; set; }
        /// <summary>
        /// Lender
        /// </summary>		
        public int Lender { get; set; }
        /// <summary>
        /// LenderName
        /// </summary>		
        public string LenderName { get; set; }
        /// <summary>
        /// Borrower
        /// </summary>		
        public int Borrower { get; set; }
        /// <summary>
        /// BorrowerName
        /// </summary>		
        public string BorrowerName { get; set; }
        /// <summary>
        /// AddTime
        /// </summary>		
        public DateTime AddTime { get; set; }
        /// <summary>
        /// 交换时间
        /// </summary>		
        public int ExchangeDays { get; set; }
        /// <summary>
        /// RealReturningTime
        /// </summary>		
        public DateTime RealReturningTime { get; set; }
        /// <summary>
        /// 交换状态
        /// </summary>		
        public int Status { get; set; }
        /// <summary>
        /// LenderGameName
        /// </summary>		
        public string LenderGameName { get; set; }
        /// <summary>
        /// BorrowerGameId
        /// </summary>		
        public int BorrowerGameId { get; set; }
        /// <summary>
        /// BorrowGameName
        /// </summary>		
        public string BorrowGameName { get; set; }
        /// <summary>
        /// 交换类型
        /// </summary>		
        public int ExchangeType { get; set; }
        /// <summary>
        /// LenderAddressId
        /// </summary>		
        public int LenderAddressId { get; set; }
        /// <summary>
        /// BorrowAddressId
        /// </summary>		
        public int BorrowAddressId { get; set; }
        #endregion

        #region  Public Methods
        #endregion
    }
}

