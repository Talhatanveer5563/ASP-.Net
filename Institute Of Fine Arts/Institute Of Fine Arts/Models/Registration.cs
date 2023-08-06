using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Institute_Of_Fine_Arts.Models
{
    [Table("tblRegistration")]
    public class Registration
    {

        [Key]
        public int s_id { get; set; }

        
       [Required]
        public string s_name { get; set; }




        [Required]
        [DataType(DataType.EmailAddress)]
        public string s_email { get; set; }
        
        
        [Required]
        [Display(Name = "Gender:")]
        public string s_gender { get; set; }



        [Required]
        [DataType(DataType.Password)]
        [MinLength(8)]
        [MaxLength(16)]
        public string s_Password {get; set;}


        [Required]
        [DataType(DataType.Password)]
        [MinLength(8)]
        [MaxLength(16)]
        [Compare("s_Password",ErrorMessage ="Password does not match")]
        public string s_Confirm_password { get; set; }
    }
}