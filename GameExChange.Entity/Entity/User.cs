using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameExChange.Entity
{
    /// <summary>
    /// 用户表
    /// </summary>
    [Table("User")]
    public class User 
    {

        #region database columns
        /// <summary>
        /// Id
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        /// <summary>
        /// UserName
        /// </summary>		
        public string UserName { get; set; }
        /// <summary>
        /// Password
        /// </summary>		
        public string Password { get; set; }
        /// <summary>
        /// Province
        /// </summary>		
        public string Province { get; set; }
        /// <summary>
        /// Nationality
        /// </summary>		
        public string Nationality { get; set; }
        /// <summary>
        /// City
        /// </summary>		
        public string City { get; set; }
        /// <summary>
        /// Address
        /// </summary>		
        public string Address { get; set; }
        /// <summary>
        /// Remark
        /// </summary>		
        public string Remark { get; set; }
        /// <summary>
        /// QQ
        /// </summary>		
        public string QQ { get; set; }
        /// <summary>
        /// Email
        /// </summary>		
        public string Email { get; set; }
        /// <summary>
        /// Phone
        /// </summary>		
        public string Phone { get; set; }
        #endregion

        #region  Public Methods

        #endregion
    }
}
