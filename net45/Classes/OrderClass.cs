using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RazorpaySampleApp.Classes
{
    public class OrderClass
    {
        public string orderid { get; set; }
        public string paymentid { get; set; }
        public string userid { get; set; }
        public string size { get; set; }
        public Double productid { get; set; }
        public string productrefid { get; set; }
        public string buymethod { get; set; }
        public string paymentmode { get; set; }
        public string imageurl { get; set; }
        public int quantity { get; set; }
        public string paymentstaus { get; set; }
    }
}