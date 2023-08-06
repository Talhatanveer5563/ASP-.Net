using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Institute_Of_Fine_Arts.Models
{
    [Table("tblcontact")]
    public class Contactus
    {
        [Key]
        public int c_id { get; set; }


        [Required]
        public string c_name { get; set; }




        [Required]
        [DataType(DataType.EmailAddress)]
        public string c_email { get; set; }

        [Required]
       public string c_subject { get; set; }

        [Required]
        public string c_message { get; set; }


    }
}