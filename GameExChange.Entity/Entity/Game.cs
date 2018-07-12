using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;


namespace GameExChange.Entity
{
    /// <summary>
    /// 可交换游戏表
    /// </summary>
    [Table("Game")]
    public class Game 
    {

        #region database columns
        /// <summary>
        /// Id
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        /// <summary>
        /// UserId
        /// </summary>		
        public int UserId { get; set; }
        /// <summary>
        /// GameName
        /// </summary>		
        public string GameName { get; set; }
        /// <summary>
        /// GameType
        /// </summary>		
        public string GameType { get; set; }
        /// <summary>
        /// 持有数量
        /// </summary>		
        public int HoldNum { get; set; }
        /// <summary>
        /// 交换中数量
        /// </summary>		
        public int ExchangedNum { get; set; }
        /// <summary>
        /// AddTimeStamp
        /// </summary>		
        public DateTime AddTimeStamp { get; set; }
        /// <summary>
        /// Remark
        /// </summary>		
        public string Remark { get; set; }
        /// <summary>
        /// Status
        /// </summary>		
        public int Status { get; set; }
        #endregion

        #region  Public Methods
        #endregion
    }
}