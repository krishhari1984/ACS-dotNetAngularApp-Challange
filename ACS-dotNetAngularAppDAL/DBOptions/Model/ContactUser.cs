using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ACS_dotNetAngularApp.Business.Model
{
    /// <summary>
    /// User model object
    /// </summary>
    [Table("ContactUsers")]
    public class ContactUser
    {
        [Key]
        public int ContactID { get; set; }
        /// <summary>
        /// FName
        /// </summary>
        [Required]
        [StringLength(50)]
        public string FName { get; set; }
        /// <summary>
        /// LName
        /// </summary>
        [Required]
        [StringLength(50)] 
        public string LName { get; set; }
        /// <summary>
        /// DOB
        /// </summary>
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd)")]
        public DateTime DOB { get; set; }

        /// <summary>
        /// Email
        /// </summary>
        [Required]
        [StringLength(50)]
        public string Email { get; set; }
        /// <summary>
        /// PhoneNumber
        /// </summary>

        [Required]
        [StringLength(10)] 
        public string Phone { get; set; }
       
    }
}
