using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WebApiStudent_Net_Core2.Tools;
using WebApiStudent_Net_Core2.ConstDeclarations;

namespace WebApiStudent_Net_Core2.Models
{
    public class UserInfo
    {
        public int UserInfoID { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        public string UserPassword { get; set; }
    }
}