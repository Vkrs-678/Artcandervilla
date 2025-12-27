using Razorpay.Api;
using RazorpaySampleApp.Connections.Implimentations;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RazorpaySampleApp
{
    public partial class WebForm19 : System.Web.UI.Page
    {
        ProductListRepo product = new ProductListRepo();
        public string orderId;
        public string description;
        public string image;
        public string username;
        public string email;
        public string number;

        protected void Page_Load(object sender, EventArgs e)
        {
           

            if (!IsPostBack)
            {
                DataTable dt = Session["placeorderdata"] as DataTable;
                DataTable dtpaynow = new DataTable();
                dtpaynow.Columns.Add("onetime");
                dtpaynow.Rows.Add("Yes");
                Repeater1.DataSource = dtpaynow;
                Repeater1.DataBind();
                if (dt.Rows[0]["buymode"].ToString() == "Direct")
                {
                    Panel1.Visible = true;
                    BindData();
                }
                else
                {
                    Panel1.Visible = false;
                    BindData();
                    RdoCOD.Checked = true;
                    foreach (DataRow row in dt.Rows)
                    {
                        if (row["iscod"].ToString()=="0" || Session["Payonline"]!=null)
                        {
                            RdoPayonline.Checked = true;
                            RdoCOD.Checked = false;
                            Session["Payonline"] = null;
                            break;
                        }
                    }
                }
                
            }
            payment();

        }
        private void payment() 
        {
            orderId=Guid.NewGuid().ToString();
            Session["orderid"]=orderId;
            Dictionary<string, object> input = new Dictionary<string, object>();
            List<string> ost = new List<string>();
            double amount = Convert.ToDouble(lblprice.Text) * 100;
            input.Add("amount", amount); // this amount should be same as transaction amount
            input.Add("currency", "INR");
            input.Add("receipt", "12121");
            input.Add("payment_capture", 1);


            string key = "rzp_live_Rv6dP9DN2EfZjQ";
            string secret = "jq1L30jtW9K7mzZHgTV049pe";

           // string key = "rzp_test_cvwiiVvHjyJrmr";
           // string secret = "J4d2RxfQ97udLpP5JSNuvwSH";

            RazorpayClient client = new RazorpayClient(key, secret);
            System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            Razorpay.Api.Order order = client.Order.Create(input); //client.Order.Create(input.ToString());
            orderId = order["id"].ToString();
        }

        private void BindData()
        {
            if (Session["placeorderdata"] != null)
            {
                
                RepeaterImages.DataSource = Session["placeorderdata"] as DataTable;
                RepeaterImages.DataBind();
                DataTable dt = Session["placeorderdata"] as DataTable;
                lblprice.Text = dt.Rows[0]["payableamount"].ToString();
                lbliscod.Text = dt.Rows[0]["iscod"].ToString();
                DataTable dtid = product.Getuserbyid(dt.Rows[0]["userid"].ToString());
                description = dt.Rows[0]["description"].ToString();
                string pimage = dt.Rows[0]["image"].ToString().Replace('~', '.');
                image = "." + pimage;
                if (dtid.Rows.Count > 0)
                {
                    username = dtid.Rows[0]["Nameofthecustomer"].ToString();
                    email = dtid.Rows[0]["email"].ToString();
                    number = dtid.Rows[0]["usermobile"].ToString() == "0" ? "+919999999999" : "+91"+dtid.Rows[0]["usermobile"].ToString();
                }
            }
        }

        private void FillDetails(DataTable dt)
        {
            DataTable dtfinal = new DataTable();
            dtfinal.Columns.Add("userid");
            dtfinal.Columns.Add("productid");
            dtfinal.Columns.Add("productrefid");
            dtfinal.Columns.Add("buymethod");
            dtfinal.Columns.Add("paymentmode");
            dtfinal.Columns.Add("imageurl");
            dtfinal.Columns.Add("quantity");
            dtfinal.Columns.Add("paymentstatus");
            dtfinal.Columns.Add("TotalPayment");
            dtfinal.Columns.Add("size");
            string paymentmode = "Onlline";
            string paymentstatus = "success";
            if(RdoCOD.Checked )
            {
                paymentmode = "COD";
                paymentstatus = "pending";
            }
            foreach(DataRow row in dt.Rows)
            {
                dtfinal.Rows.Add(row["userid"], row["productid"], row["productrefid"], row["buymode"], paymentmode, row["image"], row["quantity"], paymentstatus, Convert.ToInt64(lblprice.Text), row["size"]);
            }
            Session["finaltable"]= dtfinal;
        }
        protected void btnplaceorder_Click(object sender, EventArgs e)
        {
            if(RdoCOD.Checked==false && RdoPayonline.Checked==false)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "swal('Select Payment Mode!', 'info')", true);
                return;
            }
            RepeaterItem item= (sender as Button).Parent as RepeaterItem;
            
            if(RdoPayonline.Checked==true)
            {
                FillDetails(Session["placeorderdata"] as DataTable);
                lblwarning.Text = "If Payment Is Completed,Don't Press anything";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
            }
            else if(RdoCOD.Checked==true)
            {

                Boolean f = true;
                string orderivalue = string.Empty;
                while(f==true)
                {
                    orderivalue = generateOrderidi();
                    f = product.Checkorderid(orderivalue);
                }

                FillDetails(Session["placeorderdata"] as DataTable);
                Response.Redirect("Success.aspx?orderid=ord_" + orderivalue + "&&paymentid=COD");
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "swal('Select Payment Mode!', 'info')", true);
            }
        }

        private string generateOrderidi()
        {
            char[] array = { 'a', 'U', 'P', 'c', 'z', 'Q', 'p', 'e', 'T', 'R', 'a', 'A', 'L', 'l', 'p', 'P', 'A', 'O', 'W', 'E', 'U', 'w', 'E', 'i', 'q', 'B', 'S', 'c', 'X', 'M', 'n', 'E', 'G' };
            String orde = String.Empty;
            Random rdn = new Random();

            for (int i = 0; i < 15; i++)
            {
                int s = rdn.Next(0, array.Length);
                orde += array[s];
            }
            return orde;
        }
    }
}