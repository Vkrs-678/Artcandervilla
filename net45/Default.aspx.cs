using iTextSharp.text.pdf.codec.wmf;
using Newtonsoft.Json.Linq;
using Org.BouncyCastle.Asn1.Crmf;
using Razorpay.Api;
using RazorpaySampleApp.Connections.Implimentations;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace RazorpaySampleApp
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        public string orderId;
        AdminDashbordRepo adminrepo = new AdminDashbordRepo();
        protected void Page_Load(object sender, EventArgs e)
        {
           
            Dictionary<string, object> input = new Dictionary<string, object>();
           List<string> ost = new List<string>();
            input.Add("amount", 100); // this amount should be same as transaction amount
            input.Add("currency", "INR");
            input.Add("receipt", "12121");
            input.Add("payment_capture", 1);

            string key = "rzp_test_cvwiiVvHjyJrmr";
            string secret = "J4d2RxfQ97udLpP5JSNuvwSH";

            RazorpayClient client = new RazorpayClient(key, secret);
            System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
           // Razorpay.Api.Order order =  client.Order.Create(input); //client.Order.Create(input.ToString());
           // orderId = order["id"].ToString();

            if(!IsPostBack)
            {
                bindMainMenu();
            }

            if(Session["flag"]!=null)
            {
                Session["flag"] = null;
            }

           
        }

        private void bindMainMenu()
        {
            DataTable dt = adminrepo.GetMainCat(0);
            Rptrmenu.DataSource = dt;
            Rptrmenu.DataBind();
        }

        private void   Logins()
        {
            if (!IsPostBack)
            {
                if (Session["UserLoginTrue"] != null)
                {

                    Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "swal('Logged In', 'You Have Logged In Successfully', 'success')", true);
                }
                if (Session["SellerLoggedintrue"] != null)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "swal('Hello Seller', 'You Have Logged In Successfully', 'success')", true);
                }
            }
        }

        protected void btnsendsms_Click(object sender, EventArgs e)
        {
            string result;
            string apikey = "MzA2MzY4NGI2NTM1NzY0ODRlNjk0ZTUwNDc2NTRmMzk=";
            string msg = "Test msg";
            string numbers = "919999963147";
            string senders = "TXTLCL";


            String url = "https://api.textlocal.in/send/?apikey=" + apikey + "&numbers=" + numbers + "&message=" + getTemplates() + "&sender=" + sender;
            //refer to parameters to complete correct url string

            StreamWriter myWriter = null;
            HttpWebRequest objRequest = (HttpWebRequest)WebRequest.Create(url);

            objRequest.Method = "POST";
            objRequest.ContentLength = Encoding.UTF8.GetByteCount(url);
            objRequest.ContentType = "application/x-www-form-urlencoded";
            try
            {
                myWriter = new StreamWriter(objRequest.GetRequestStream());
                myWriter.Write(url);
            }
            catch (Exception ex)
            {
                
            }
            finally
            {
                myWriter.Close();
            }

            HttpWebResponse objResponse = (HttpWebResponse)objRequest.GetResponse();
            using (StreamReader sr = new StreamReader(objResponse.GetResponseStream()))
            {
                result = sr.ReadToEnd();
                // Close and clean up the StreamReader
                sr.Close();
            }
            
        }

        
            public string getTemplates()
            {
                String result;
                string apiKey = "MzA2MzY4NGI2NTM1NzY0ODRlNjk0ZTUwNDc2NTRmMzk=";

                String url = "https://api.textlocal.in/get_templates/?apikey=" + apiKey;
                //refer to parameters to complete correct url string

                StreamWriter myWriter = null;
                HttpWebRequest objRequest = (HttpWebRequest)WebRequest.Create(url);

                objRequest.Method = "POST";
                objRequest.ContentLength = Encoding.UTF8.GetByteCount(url);
                objRequest.ContentType = "application/x-www-form-urlencoded";
                try
                {
                    myWriter = new StreamWriter(objRequest.GetRequestStream());
                    myWriter.Write(url);
                }
                catch (Exception e)
                {
                    return e.Message;
                }
                finally
                {
                    myWriter.Close();
                }

                HttpWebResponse objResponse = (HttpWebResponse)objRequest.GetResponse();
                using (StreamReader sr = new StreamReader(objResponse.GetResponseStream()))
                {
                    result = sr.ReadToEnd();
                    // Close and clean up the StreamReader
                    sr.Close();
                }
                Console.WriteLine(result);
                Console.ReadLine();
                return result;
            }
       

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static List<string> Getname(string pre)
        {

            AdminDashbordRepo adminsss = new AdminDashbordRepo();
            List<string> name = adminsss.Getkeywodsearc(pre); ;
            return name;


        }

       

    }
}