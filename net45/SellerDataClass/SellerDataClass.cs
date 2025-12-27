using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RazorpaySampleApp.SellerDataClass
{
    public class SellerDataClasses
    {
        [Required]
        
        public string SellerName { get; set; }
        [Required]
        public Double Mobile { get; set; }
        [Required]
        public string Email { get; set; }
        public string Gst { get; set; }
        public string Adhar { get; set; }
        public string Pancard { get; set; }
        public string fullAddress { get; set; }
        public string upino { get; set; }
        public string adharno { get; set; }
        public string pancardno { get; set; }
        
    }
}