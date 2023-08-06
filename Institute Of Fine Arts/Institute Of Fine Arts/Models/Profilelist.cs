using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Institute_Of_Fine_Arts.Models
{
    [Table("tblprofile")]
    public class Profilelist
    {
        [Key]
        public int p_id { get; set; }

        [Required]
        public string p_firstname { get; set; }

        [Required]
        public string p_lasttname { get; set; }

        [Required]
        public string p_class { get; set; }


        [Required]
        public string p_subject { get; set; }

        [Required]
        DataType[DataType.Date]
        public string p_sdate { get; set; }

        [Required]
        DataType[DataType.Date]
        public string p_edate { get; set; }

      
        public string p_remarks { get; set; }
    }
}