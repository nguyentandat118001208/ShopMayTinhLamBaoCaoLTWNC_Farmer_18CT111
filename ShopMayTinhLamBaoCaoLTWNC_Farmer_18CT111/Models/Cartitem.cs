using Models.Core.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopMayTinhLamBaoCaoLTWNC_Farmer_18CT111.Models
{
    [Serializable]
    public class Cartitem
    {
        public Product Product { set; get; }
        public int Quantity { set; get; }
    }
}