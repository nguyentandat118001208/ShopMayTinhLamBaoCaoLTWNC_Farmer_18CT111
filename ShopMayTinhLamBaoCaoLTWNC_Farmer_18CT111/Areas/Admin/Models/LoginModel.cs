using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShopMayTinhLamBaoCaoLTWNC_Farmer_18CT111.Areas.Admin.Models
{
    public class LoginModel
    {
        
        
            [Required(ErrorMessage = "Nhap vao day du username ")]
            public string UserName { set; get; }
            [Required(ErrorMessage = "Nhap vao day du password ")]
            public string Password { set; get; }
            public bool RememberMe { set; get; }
        
    }
}