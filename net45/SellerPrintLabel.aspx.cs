using Newtonsoft.Json.Linq;
using RazorpaySampleApp.Connections.Implimentations;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RazorpaySampleApp
{
    public partial class WebForm27 : System.Web.UI.Page
    {
        SellerSignupRepo seller = new SellerSignupRepo();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["SellerLoggedintrue"] == null)
            {
                Response.Redirect("Default.aspx");
            }
            else
            {
                Session["SellerLoggedintrue"] = Session["SellerLoggedintrue"].ToString();
            }
            if (!IsPostBack)
            {
                Printlabel();
            }
        }

        private void Printlabel()
        {
            RptrProducts.DataSource = seller.GetOrdersForPrintShipmentLabel();
            RptrProducts.DataBind();
        }
        protected void btnPrintlabel_Click(object sender, EventArgs e)
        {
            try
            {
                RepeaterItem item = (sender as LinkButton).Parent as RepeaterItem;
                HiddenField hdnawb = ((HiddenField)item.FindControl("Hdnawbno")) as HiddenField;
                var client = new RestClient("https://my.ithinklogistics.com/api_v3/shipping/label.json");
                var request = new RestRequest(Method.POST);
                request.AddHeader("cache-control", "no-cache");
                request.AddHeader("content-type", "application/json");
                request.AddParameter("application/json", "{\"data\":{\"access_token\":\"9b2c8a088ee4e7eb03bcf781663b6fd0\",\"secret_key\":\"6244c53d36f4f07227b21d8b83c6debb\",\"awb_numbers\":" + hdnawb.Value + ",\"page_size\":\"A4\",\"display_cod_prepaid\":\"1\",\"display_shipper_mobile\":\"\",\"display_shipper_address\":\"\"}}\n", ParameterType.RequestBody);
                IRestResponse response = client.Execute(request);
                string sourse = response.Content.ToString();
                dynamic data = JObject.Parse(sourse);
                //Response.Redirect(data.file_name);
            }
            catch (Exception ex)
            {
                dfd.Text = ex.Message.ToString();
            }
          
            
        }
    }
}