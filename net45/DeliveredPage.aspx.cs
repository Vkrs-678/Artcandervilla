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
    public partial class WebForm26 : System.Web.UI.Page
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
            if (!IsPostBack)
            {
                bidnRepeater();
            }
        }

        private void bidnRepeater()
        {
            RptrProducts.DataSource = admin.GetShippedProducts();
            RptrProducts.DataBind();
        }

        protected void btnDelivered_Click(object sender, EventArgs e)
        {
            RepeaterItem item=(sender as LinkButton).Parent as RepeaterItem;

            HiddenField Hdnorderid = ((HiddenField)item.FindControl("Hdnorderid")) as HiddenField;
            HiddenField Hdnprodcutname = ((HiddenField)item.FindControl("Hdnproductname")) as HiddenField;
            HiddenField Hdnimage = ((HiddenField)item.FindControl("Hdnimage")) as HiddenField;
            HiddenField Hdnusername = ((HiddenField)item.FindControl("Hdnusername")) as HiddenField;
            HiddenField Hdnemail = ((HiddenField)item.FindControl("Hdnemail")) as HiddenField;
            HiddenField Hdnpayment = ((HiddenField)item.FindControl("Hdnpaymentmode")) as HiddenField;
            HiddenField Hdnbuyprice = ((HiddenField)item.FindControl("Hdnprice")) as HiddenField;

            int i=admin.UpdateDelivery(Hdnorderid.Value);
            if(i>0)
            {
                bidnRepeater();
                sendmail(Hdnorderid.Value, Hdnprodcutname.Value, Hdnimage.Value, Hdnusername.Value, Hdnemail.Value, Hdnpayment.Value, Hdnbuyprice.Value);
            }
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
           // s += "<div style='text-align:left;margin:10px'><div><h4 style='color:black;font-family:verdana;font-weight:800;'>Tracking Id :- " + trackno + "</h4></div></div>";

            s += "<div style='text-align:center;'><div><img src=cid:MyPic style='height:100px;width:100px;border:solid;border-color:white;border-radius:5px'></div><div><h3>Product : " + productname + "</h3><h3>Product has been Delivered</h3></div></div>";
            s += "<div style='text-align:right;margin:10px'><h3 style='color:red;font-family:verdana;font-weight:800;'>Payment Mode : " + paymentmode + "</h3></div>";
            s += "<div style='text-align:right;margin:10px'><h3 style='color:Green;font-family:verdana;font-weight:800;'>Amount Paid : ₹ " + Math.Round(Convert.ToDouble(totalPrice), 0) + "/-</h3></div>";
            s += "<div style='text-align:left;margin:10px'><h3 style='color:red;font-family:verdana;font-weight:800;'>Kind Regards</h3></div>";
            s += "<div style='text-align:left;margin:10px'><a href='artcandervilla.in' style='color:blue;font-family:verdana;font-weight:800;'>artcandervilla</a></div>";
            s += "</div>";
            AlternateView htmlView = AlternateView.CreateAlternateViewFromString(s, null, "text/html");
            htmlView.LinkedResources.Add(LinkedImage);
            sendmails.EmailWithImgae(useremail, "Your Order  " + productname + " has been DeliVered Successfully", htmlView);
        }
    }
}