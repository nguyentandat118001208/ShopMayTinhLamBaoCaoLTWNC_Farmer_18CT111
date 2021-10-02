using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopMayTinhLamBaoCaoLTWNC_Farmer_18CT111.Common
{
    [Serializable]
    public class UserLogin
    {
        public long UserID { set; get; }
        public string UserName { set; get; }
    }
}