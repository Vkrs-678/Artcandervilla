using Razorpay.Api;
using System;
using System.Collections.Generic;
using System.Net;

namespace RazorpaySampleApp
{
    public partial class Payment : System.Web.UI.Page
    {
        public string orderId;
        protected void Page_Load(object sender, EventArgs e)
        {
            Dictionary<string, object> input = new Dictionary<string, object>();
            input.Add("amount", 100); // this amount should be same as transaction amount
            input.Add("currency", "INR");
            input.Add("receipt", "12121");
            input.Add("payment_capture", 1);

           // string key = "rzp_test_cvwiiVvHjyJrmr";
           // string secret = "J4d2RxfQ97udLpP5JSNuvwSH";


            string key = "rzp_live_CtUgMmOa1ao67Q";
            string secret = "FwP78mYm6Sagd4zAIwMV9F9k";

            RazorpayClient client = new RazorpayClient(key, secret);
            System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            Razorpay.Api.Order order = client.Order.Create(input);
            orderId = order["id"].ToString();


        }
    }
}