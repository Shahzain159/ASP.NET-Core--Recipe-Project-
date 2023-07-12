using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace James_thew_2.Models.DB_Models
{
    public partial class TblAdmin
    {
        public int AId { get; set; }
        public string AName { get; set; }
        [Required(ErrorMessage ="Email id Required")]
        [EmailAddress(ErrorMessage ="Invalid Email")]
        public string AEmail { get; set; }

        [Required(ErrorMessage ="Password is Required")]
        public string APassword { get; set; }
    }
}
