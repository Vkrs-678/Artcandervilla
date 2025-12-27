using RazorpaySampleApp.Connections.Implimentations;
using RazorpaySampleApp.SendmailClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RazorpaySampleApp
{
    public partial class WebForm28 : System.Web.UI.Page
    {
        AdminDashbordRepo admin = new AdminDashbordRepo();
        SellerSignupRepo seller = new SellerSignupRepo();
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


        protected void BtnSearch_Click(object sender, EventArgs e)
        {
            RptrProducts.DataSource = admin.GetDataforFinalDelivered(Txtorderidforsearch.Text.Trim());
            RptrProducts.DataBind();
        }

        protected void btnDelivered_Click(object sender, EventArgs e)
        {
            RepeaterItem item = (sender as LinkButton).Parent as RepeaterItem;
            HiddenField Hdnorderid = ((HiddenField)item.FindControl("HdnOrderid")) as HiddenField;
            HiddenField Hdnproductid = ((HiddenField)item.FindControl("HdnProductid")) as HiddenField;
            HiddenField Hdnprodcutrefid = ((HiddenField)item.FindControl("HdnProductrefid")) as HiddenField;
            HiddenField Hdnusername = ((HiddenField)item.FindControl("Hdnusername")) as HiddenField;
            HiddenField Hdnuseremail = ((HiddenField)item.FindControl("Hdnuseremail")) as HiddenField;
            HiddenField Hdntotalprice = ((HiddenField)item.FindControl("Hdntotalprice")) as HiddenField;
            HiddenField Hdnpaymentmode = ((HiddenField)item.FindControl("HdnPaymentMode")) as HiddenField;
            HiddenField Hdnname = ((HiddenField)item.FindControl("Hdnproductname")) as HiddenField;
            HiddenField HdnImege = ((HiddenField)item.FindControl("Hdnproductimage")) as HiddenField;
            HiddenField HdnSellerEmail = ((HiddenField)item.FindControl("HdnSellerEmail")) as HiddenField;
            int i = admin.UpdateDeliveryStatus(Hdnorderid.Value, Convert.ToDouble(Hdnproductid.Value), Hdnprodcutrefid.Value, "Delivered");
            if(i>0)
            {
                sendmail(Hdnorderid.Value, Hdnname.Value, HdnImege.Value, Hdnusername.Value, Hdnuseremail.Value, Hdnpaymentmode.Value, Hdntotalprice.Value);
                sendmailseller(Hdnorderid.Value, Hdnname.Value, HdnImege.Value, Hdnusername.Value, HdnSellerEmail.Value, Hdnpaymentmode.Value, Hdntotalprice.Value);
                Printlabel();
            }
        }

        protected void btnRefused_Click(object sender, EventArgs e)
        {
            RepeaterItem item = (sender as LinkButton).Parent as RepeaterItem;
            HiddenField Hdnorderid = ((HiddenField)item.FindControl("HdnOrderid")) as HiddenField;
            HiddenField Hdnproductid = ((HiddenField)item.FindControl("HdnProductid")) as HiddenField;
            HiddenField Hdnprodcutrefid = ((HiddenField)item.FindControl("HdnProductrefid")) as HiddenField;
          
            int i = admin.UpdateDeliveryStatus(Hdnorderid.Value, Convert.ToDouble(Hdnproductid.Value), Hdnprodcutrefid.Value, "Refused");
            Printlabel();
        }


        protected void sendmail(String orderid, String productname, String Imageurl, String username, String useremail, String paymentmode, string totalPrice)
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
            

            s += "<div style='text-align:center;'><div><img src=cid:MyPic style='height:100px;width:100px;border:solid;border-color:white;border-radius:5px;color:Green'></div><div><h3>Product : " + productname + "</h3><h3>Product has been Delivered Successfully</h3></div></div>";
            s += "<div style='text-align:right;margin:10px'><h3 style='color:red;font-family:verdana;font-weight:800;'>Payment Mode : " + paymentmode + "</h3></div>";
            s += "<div style='text-align:right;margin:10px'><h3 style='color:Green;font-family:verdana;font-weight:800;'>Amount Paid : ₹ " + Math.Round(Convert.ToDouble(totalPrice), 0) + "/-</h3></div>";
            s += "<div style='text-align:left;margin:10px'><h3 style='color:red;font-family:verdana;font-weight:800;'>Kind Regards</h3></div>";
            s += "<div style='text-align:left;margin:10px'><a href='artcandervilla.in' style='color:blue;font-family:verdana;font-weight:800;'>artcandervilla</a></div>";
            s += "</div>";
            AlternateView htmlView = AlternateView.CreateAlternateViewFromString(
                          s, null, "text/html");
            htmlView.LinkedResources.Add(LinkedImage);
            sendmails.EmailWithImgae(useremail, "Your Order  " + productname + " has been Delivered Successfully", htmlView);
        }


        protected void sendmailseller(String orderid, String productname, String Imageurl,string username ,String selleremail, String paymentmode, string totalPrice)
        {
            LinkedResource LinkedImage = new LinkedResource(Server.MapPath(Imageurl));
            LinkedImage.ContentId = "MyPic";

            string s = "<div style='height:fit-content;width:94%;background-color:#ffff66;border-radius:8px;border-style:solid;border-width:3px;border-color:hotpink;'>";
            s += "<div style='text-align:center;'>";
            s += "<div style='display:inline-flex;text-align:center;'>";
            s += "<h1 style='font-family:cursive;color:green;background-color:white;padding:20px;margin-top:30px;margin-bottom:30px'>Art<span style='font-family:cursive;color:hotpink;background-color:white;'>-Candervilla</span></h1><br/> ";
            s += "</div>";
            s += "</div>";
            s += "<div style='text-align:left;margin:10px'><div><h3 style='color:black;font-family:verdana;font-weight:800;'>Hello Partner,</h3><h4 style='color:gray;font-family:verdana;font-weight:800;>Order Id</h6><h6 style='color:black;font-family:verdana;font-weight:800;'>Order Id :- " + orderid + "</h4></div></div>";


            s += "<div style='text-align:center;'><div><img src=cid:MyPic style='height:100px;width:100px;border:solid;border-color:white;border-radius:5px;color:Green'></div><div><h3>Product : " + productname + "</h3><h3>Product has been Delivered Successfully To The Customer Your Amount For the Product Will be Settle With in 3-4 Working Days </h3></div></div>";
            s += "<div style='text-align:right;margin:10px'><h3 style='color:red;font-family:verdana;font-weight:800;'>Payment Mode : " + paymentmode + "</h3></div>";
            s += "<div style='text-align:right;margin:10px'><h3 style='color:Green;font-family:verdana;font-weight:800;'>Amount Paid : ₹ " + Math.Round(Convert.ToDouble(totalPrice), 0) + "/-</h3></div>";
            s += "<div style='text-align:left;margin:10px'><h3 style='color:red;font-family:verdana;font-weight:800;'>Kind Regards</h3></div>";
            s += "<div style='text-align:left;margin:10px'><a href='artcandervilla.in' style='color:blue;font-family:verdana;font-weight:800;'>artcandervilla</a></div>";
            s += "</div>";
            AlternateView htmlView = AlternateView.CreateAlternateViewFromString(
                          s, null, "text/html");
            htmlView.LinkedResources.Add(LinkedImage);
            sendmails.EmailWithImgae(selleremail, "Your Order  " + productname + " has been Delivered Successfully To The Customer", htmlView);
        }
    }
}