using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameExChange.Entity
{
    [Table("Address")]
    //Address
    public class Address 
    {

        #region database columns
        ///// <summary>
        ///// Id
        ///// </summary>		
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        /// <summary>
        /// Country
        /// </summary>		
        public string Country { get; set; }
        /// <summary>
        /// Province
        /// </summary>		
        public string Province { get; set; }
        /// <summary>
        /// City
        /// </summary>		
        public string City { get; set; }
        /// <summary>
        /// Address
        /// </summary>		
        public string AddressDetail { get; set; }
        /// <summary>
        /// PostCode
        /// </summary>		
        public string PostCode { get; set; }
        /// <summary>
        /// UserId
        /// </summary>		
        public int UserId { get; set; }
        /// <summary>
        /// IsDefault
        /// </summary>		
        public bool IsDefault { get; set; }
        /// <summary>
        /// 地址标签
        /// </summary>		
        public string Tags { get; set; }
        /// <summary>
        /// Remark
        /// </summary>		
        public string Remark { get; set; }
        /// <summary>
        /// Phone
        /// </summary>		
        public string Phone { get; set; }
        #endregion

        #region  Public Methods
        #endregion
    }
}

