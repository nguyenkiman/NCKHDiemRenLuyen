using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DiemRenLuyen.Areas.Admin.Model
{
    public class LoginModel
    {
        [Required]
        public string UserName { get; set; }
        public string PassWord { get; set; }
    }
}