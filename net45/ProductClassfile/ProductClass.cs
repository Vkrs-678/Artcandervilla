using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Web;

namespace RazorpaySampleApp.ProductClass
{
    public class ProductClassSaveData
    {
        public int Sellerid { get; set; }
        public string refId { get; set; }
        public Double Maincatid { get; set; }
        public Double Subcatid { get; set; }
        public string ProductName { get; set; }
        public string ProducBrand { get; set; }
        public string ProductDeails { get; set; }
        public string ProductDescription { get; set; }
        public string ProductKeywords { get; set; }
        public string ProductSpecification { get; set; }
        public string ProductType { get; set; }
        public string ProductColor { get; set; }
        public string ProductSize { get; set; }
        public Decimal ProductPrice { get; set; }
        public Decimal ProductDiscount { get; set; }
        public int Iscod { get; set; }
        public int isFestiveOffer { get; set; }//0.No offer 1.Limited Time Deal 2.festive Offer
        public int isActiveNow { get; set; }
        public int ReturnDay { get; set; }
        public int ReplacementDay { get; set; }
        public Decimal DeliveryPrice { get; set; }
        public int avl_qty { get; set; }
        
        public string Image1 { get; set; }
        public string Image2 { get; set; }
        public string Image3 { get; set; }
        public string Image4 { get; set; }
        public string Image5 { get; set; }
        public int warranty { get; set; }


    }
}