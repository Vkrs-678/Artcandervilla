using RazorpaySampleApp.Connections.Implimentations;
using RazorpaySampleApp.SendmailClass;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RazorpaySampleApp
{
    public partial class WebForm25 : System.Web.UI.Page
    {
        AdminDashbordRepo admin = new AdminDashbordRepo();
        Sendmail sendmails = new Sendmail();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["isAdminid"] == null)
            {
                Response.Redirect("Default.aspx");
            }
            else
            {
                Session["isAdminid"] = Session["isAdminid"].ToString();
            }
            try
            {
                BindData();
            }
            catch(Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "swal('Tracking No', '"+ex.Message+"', 'error')", true);
            }
           
        }
        string orederi = "";       
        double productid = 0;       
        string productrefid = "";       
        string productname = "";
        string image = "";
        string username = "";
        string email = "";
        string paymentmode = "";
        string price = "";
        string selleremail = "";
        private void BindData()
        {
            orederi = Request.QueryString["orderid"].ToString();
            productid = Convert.ToDouble(Request.QueryString["productid"].ToString());
            productrefid = Request.QueryString["productrefid"].ToString();             
            DataTable dt = admin.GetShipdata(orederi, productid, productrefid);

            SellerAddress.Text = dt.Rows[0]["FullAdress"].ToString();
            CustomerAdress.Text = dt.Rows[0]["customeraddress"].ToString();
            LblOrderid.Text ="Order id:-"+ dt.Rows[0]["orderid"].ToString();
            LblLogisticsorder.Text = "Order id(Logistics) :-" + dt.Rows[0]["orderid"].ToString()+"@"+ dt.Rows[0]["productrefid"].ToString()+"@"+ dt.Rows[0]["productid"].ToString();
            Lblproductid.Text = "Product id:-" + dt.Rows[0]["productid"].ToString();
            Lblproductrefid.Text = "Productref id:-" + dt.Rows[0]["productrefid"].ToString();
            Lblheight.Text = "Height :-" + dt.Rows[0]["height"].ToString();
            Lblwidth.Text = "Width :-" + dt.Rows[0]["width"].ToString();
            Lbllength.Text = "Length :-" + dt.Rows[0]["length"].ToString();
            lblweight.Text = "Weight :-" + dt.Rows[0]["weights"].ToString();
            SellerName.Text = "Name :-" + dt.Rows[0]["SellerName"].ToString();
            SellerEmail.Text = "Email :-" + dt.Rows[0]["Selleremail"].ToString();
            selleremail = dt.Rows[0]["Selleremail"].ToString();
            SellerMobile.Text = "Mobile :-" + dt.Rows[0]["sellermobile"].ToString();
            CustomerName.Text = "Name :-" + dt.Rows[0]["username"].ToString();
            CustomerEmail.Text = "Email :-" + dt.Rows[0]["email"].ToString();
            CustomerMobile.Text = "Mobile :-" + dt.Rows[0]["Mobile_no"].ToString();
            productname = dt.Rows[0]["productname"].ToString();
            image = dt.Rows[0]["image1"].ToString();
            username = dt.Rows[0]["username"].ToString();
            email = dt.Rows[0]["email"].ToString();
            paymentmode = dt.Rows[0]["paymentMode"].ToString();
            price = dt.Rows[0]["buyPrice"].ToString();
        }

        protected void btnShip_Click(object sender, EventArgs e)
        {
            if (Txttracking.Text.Trim() == "")
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "swal('Tracking No', 'Enter Tracking Number', 'error')", true);
                return;
            }
            if (TxtDelivered.Text.Trim() == "")
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "swal('Delivery Day', 'Select Date', 'error')", true);
                return;
            }
            if (TxtShippingPrice.Text.Trim() == "")
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "swal('Shipping Price', 'Enter Shipping Price', 'error')", true);
                return;
            }

            int i = admin.AddFinalsemifinalDelivery(orederi, productid, productrefid, Txttracking.Text.Trim(), Convert.ToDateTime(TxtDelivered.Text.ToString()),Convert.ToDouble(TxtShippingPrice.Text.Trim()));

            if (i > 0)
            {
                sendmail(orederi, productname, image, username, email, paymentmode, price, Txttracking.Text.Trim());
                sendmailseller(selleremail, image, productname, price, orederi, paymentmode, Convert.ToDateTime(TxtDelivered.Text.Trim()).ToString("dd/MM/yyyy"));
                Response.Redirect("AdminShipPage.aspx");
            }
        }

        protected void sendmail(String orderid, String productname, String Imageurl, String username, String useremail, String paymentmode, string totalPrice,string trackno)
        {
            LinkedResource LinkedImage = new LinkedResource(Server.MapPath(Imageurl));
            LinkedImage.ContentId = "MyPic";

            string s = "<div style='height:fit-content;width:94%;background-color:#ffff66;border-radius:8px;border-style:solid;border-width:3px;border-color:hotpink;'>";
            s += "<div style='text-align:center;'>";
            s += "<div style='display:inline-flex;text-align:center;'>";
            s += "<h1 style='font-family:cursive;color:green;background-color:white;padding:20px;margin-top:30px;margin-bottom:30px'>Art<span style='font-family:cursive;color:hotpink;background-color:white;'>-Candervilla</span></h1><br/> ";
            s += "</div>";
            s += "</div>";
            s += "<div style='text-align:left;margin:10px'><div><h3 style='color:black;font-family:verdana;font-weight:800;'>" + username + "</h3><h4 style='color:gray;font-family:verdana;font-weight:800;>Order Id</h6><h6 style='color:black;font-family:verdana;font-weight:800;'>Order Id :- " + orderid + "</h4></div></div>";
             s += "<div style='text-align:left;margin:10px'><div><h4 style='color:black;font-family:verdana;font-weight:800;'>Tracking Id :- " + trackno + "</h4></div></div>";

            s += "<div style='text-align:center;'><div><img src=cid:MyPic style='height:100px;width:100px;border:solid;border-color:white;border-radius:5px'></div><div><h3>Product : " + productname + "</h3><h3>Product has been Shipped & Will Deliver to You Soon</h3></div></div>";
            s += "<div style='text-align:right;margin:10px'><h3 style='color:red;font-family:verdana;font-weight:800;'>Payment Mode : " + paymentmode + "</h3></div>";
            s += "<div style='text-align:right;margin:10px'><h3 style='color:Green;font-family:verdana;font-weight:800;'>Amount Paid : ₹ " + Math.Round(Convert.ToDouble(totalPrice), 0) + "/-</h3></div>";
            s += "<div style='text-align:left;margin:10px'><h3 style='color:red;font-family:verdana;font-weight:800;'>Kind Regards</h3></div>";
            s += "<div style='text-align:left;margin:10px'><a href='artcandervilla.store' style='color:blue;font-family:verdana;font-weight:800;'>artcandervilla</a></div>";
            s += "</div>";
            AlternateView htmlView = AlternateView.CreateAlternateViewFromString(
                          s, null, "text/html");
            htmlView.LinkedResources.Add(LinkedImage);
            sendmails.EmailWithImgae(useremail, "Your Order  " + productname + " has been Shipped", htmlView);
        }

        protected void sendmailseller(String selleremail, string Imageurl, String Productname, string totalPrice, String orderid, String Paymentmode,string pickupdate)
        {
            LinkedResource LinkedImage = new LinkedResource(Server.MapPath(Imageurl));
            LinkedImage.ContentId = "MyPic";

            string s = "<div style='height:fit-content;width:94%;background-color:#ffff66;border-radius:8px;border-style:solid;border-width:3px;border-color:hotpink;'>";
            s += "<div style='text-align:center;'>";
            s += "<div style='display:inline-flex;text-align:center;'>";
            s += "<h1 style='font-family:cursive;color:green;background-color:white;padding:20px;margin-top:30px;margin-bottom:30px'>Art<span style='font-family:cursive;color:hotpink;background-color:white;'>-Candervilla</span></h1><br/> ";
            s += "</div>";
            s += "</div>";
            s += "<div style='text-align:left;margin:10px'><div><h3 style='color:black;font-family:verdana;font-weight:800;'>Hello, Partner</h3><h4 style='color:gray;font-family:verdana;font-weight:800;>Order Id</h6><h6 style='color:black;font-family:verdana;font-weight:800;'>Order Id :- " + orderid + "</h4></div></div>";
            s += "<div style='text-align:center;'><div><img src=cid:MyPic style='height:100px;width:100px;border:solid;border-color:white;border-radius:5px'></div><div><div><h3>Shipment has been Arranged Please Ready Your Shipment A Delivery Agent(Delihivery) will Collect the Shipment By "+ pickupdate + "</h3></div><h3>Product : " + Productname + "</h3></div></div>";           
            s += "<div style='text-align:right;margin:10px'><h3 style='color:red;font-family:verdana;font-weight:800;'>Payment Mode : " + Paymentmode + "</h3></div>";
            s += "<div style='text-align:right;margin:10px'><h3 style='color:Green;font-family:verdana;font-weight:800;'>Amount : ₹ " + Math.Round(Convert.ToDouble(totalPrice),0) + "/-</h3></div>";
            s += "<div style='text-align:left;margin:10px'><h3 style='color:red;font-family:verdana;font-weight:800;'>Kind Regards</h3></div>";
            s += "<div style='text-align:left;margin:10px'><a href='artcandervilla.store' style='color:blue;font-family:verdana;font-weight:800;'>artcandervilla</a></div>";
            s += "</div>";
            AlternateView htmlView = AlternateView.CreateAlternateViewFromString(s, null, "text/html");
            htmlView.LinkedResources.Add(LinkedImage);
            sendmails.EmailWithImgae(selleremail, " Order  " + Productname + " Ready For Pickup by "+ pickupdate + "", htmlView);
        }
    }
}