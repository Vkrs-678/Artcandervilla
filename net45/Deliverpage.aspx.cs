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
    public partial class WebForm22 : System.Web.UI.Page
    {
        SellerSignupRepo seller = new SellerSignupRepo();
        Sendmail sendmails = new Sendmail();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                Panel1.Visible = true;
                Panel2.Visible = false;
                Panel3.Visible = false;
                getdownload();
            }
        }

        protected void getdownload()
        {
            String orderid = Request.QueryString["orderid"].ToString();
            Session["orderidDel"] = orderid;
            double productid = Convert.ToDouble(Request.QueryString["productid"].ToString());
            Session["productidDel"] = productid;
            String productrefid = Request.QueryString["productrefid"].ToString();
            Session["productrefidDel"] = productrefid;
            DataTable dt = seller.GetBillDetails(orderid, productid, productrefid);
            if(dt.Rows.Count>0)
            {
                HiddenField1.Value = dt.Rows[0]["DeliveryBoyid"].ToString();
                HdnEmail.Value = dt.Rows[0]["email"].ToString();
                Session["useremailidDel"] = dt.Rows[0]["email"].ToString();
                Hdnorderid.Value = orderid;
                Hdnproductname.Value = dt.Rows[0]["productname"].ToString();
                Session["productnameDel"] = dt.Rows[0]["productname"].ToString();
                HdnImageurl.Value = dt.Rows[0]["productimage"].ToString();
                Session["ImagedDel"] = dt.Rows[0]["productimage"].ToString();
                Hdnusername.Value = dt.Rows[0]["Nameofthecustomer"].ToString();
                Session["usernameDel"] = dt.Rows[0]["Nameofthecustomer"].ToString();
                HdnPaymentmode.Value = dt.Rows[0]["paymentMode"].ToString();
                Session["paymentmodeDel"] = dt.Rows[0]["paymentMode"].ToString();
                HdnTotalPrice.Value = dt.Rows[0]["Grandtotal"].ToString();
                Session["GrandTotalDel"] = dt.Rows[0]["Grandtotal"].ToString();
                Hdnalreadydelivered.Value = dt.Rows[0]["alreadystatus"].ToString();
            }
           
        }

        protected void LnkNext_Click(object sender, EventArgs e)
        {
            if(TxtDeliverboyid.Text.Trim()==HiddenField1.Value)
            {
                Panel1.Visible = false;
                Panel2.Visible = true;
                Panel3.Visible = false;
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "swal('Id', 'Enter Correct Id', 'error')", true);
                
            }
        }

        protected void LnkSendOtp_Click(object sender, EventArgs e)
        {
            if (Hdnalreadydelivered.Value.ToString() == "1")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "swal('Already Delivered', 'Product has been Already Delivered', 'info')", true);
                return;
            }
            Random rdn = new Random();
           int OTP= rdn.Next(1001, 9999);
            Session["OtpforDeliverpage"] = OTP;
            sendmaiOTP(Hdnorderid.Value, Hdnproductname.Value, HdnImageurl.Value, Hdnusername.Value, HdnEmail.Value, HdnPaymentmode.Value, HdnTotalPrice.Value, OTP);
            Panel1.Visible = false;
            Panel2.Visible = false;
            Panel3.Visible = true;
        }

        protected void sendmaiOTP(String orderid, String productname, String Imageurl, String username, String useremail, String paymentmode, string totalPrice,int OTP)
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
            s += "<div style='text-align:center;'><div><img src=cid:MyPic style='height:100px;width:100px;border:solid;border-color:white;border-radius:5px'></div><div><h3 style='color:Red'>Product : " + productname + "</h3><h3>OTP : "+OTP+"</h3></div></div>";
            s += "<div style='text-align:right;margin:10px'><h3 style='color:red;font-family:verdana;font-weight:800;'>Payment Mode : " + paymentmode + "</h3></div>";
            s += "<div style='text-align:right;margin:10px'><h3 style='color:Green;font-family:verdana;font-weight:800;'>Amount : ₹ " + Math.Round(Convert.ToDouble(totalPrice), 0) + "/-</h3></div>";
            s += "<div style='text-align:left;margin:10px'><h3 style='color:red;font-family:verdana;font-weight:800;'>Kind Regards</h3></div>";
            s += "<div style='text-align:left;margin:10px'><a href='artcandervilla.in' style='color:blue;font-family:verdana;font-weight:800;'>artcandervilla</a></div>";
            s += "</div>";
            AlternateView htmlView = AlternateView.CreateAlternateViewFromString(
                          s, null, "text/html");
            htmlView.LinkedResources.Add(LinkedImage);
            sendmails.EmailWithImgae(useremail, "Your Order  " + productname + " Require OTP To Deliver", htmlView);
        }

        protected void LnkDeliver_Click(object sender, EventArgs e)
        {
            if(Hdnalreadydelivered.Value.ToString()=="1")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "swal('Delivered', 'Product has been Already Delivered', 'info')", true);
                return;
            }
            if (TxtOtpUser.Text.Trim() == Session["OtpforDeliverpage"].ToString().Trim())
            {
                Response.Redirect("DeliverySuccess.aspx");
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "swal('Wrong', 'Enter Correct OTP', 'error')", true);
            }
        }

        
    }
}