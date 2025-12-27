using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RazorpaySampleApp.Cartdataclass
{
    public class CartFields
    {
        public string userid { get; set; }
        public double productid { get; set; }
        public string  productrefid { get; set; }
        public string  size { get; set; }
        public Double Sellingprice { get; set; }
        public Double markedprice { get; set; }
        public int discountpercentage { get; set; }
        public decimal deliveryprice { get; set; }

        public int PurchasedQuantity { get; set; }
    }
}