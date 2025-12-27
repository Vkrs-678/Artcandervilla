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
    public partial class DeliverySuccess : System.Web.UI.Page
    {
        Sendmail sendmails= new Sendmail();
        SellerSignupRepo seller= new SellerSignupRepo();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["orderidDel"]==null)
            {
                return;
            }
            if(!IsPostBack)
            {
                int i = seller.Deliveredproduct(Session["orderidDel"].ToString(), Convert.ToInt64(Session["productidDel"].ToString()), Session["productrefidDel"].ToString());
                if(i>0)
                {
                    int res=sendmaildelivered(Session["orderidDel"].ToString(), Session["productnameDel"].ToString(), Session["ImagedDel"].ToString(), Session["usernameDel"].ToString(),
                    Session["useremailidDel"].ToString(), Session["paymentmodeDel"].ToString(), Session["GrandTotalDel"].ToString());
                    if(res>0)
                    {
                        Session["orderidDel"] = null;
                        Session["productidDel"] = null;
                        Session["productrefidDel"] = null;
                        Session["productnameDel"] = null;
                        Session["ImagedDel"] = null;
                        Session["usernameDel"] = null;
                        Session["useremailidDel"] = null;
                        Session["paymentmodeDel"] = null;
                        Session["GrandTotalDel"] = null;
                    }
                }
               
            }

           

        }

        protected int sendmaildelivered(String orderid, String productname, String Imageurl, String username, String useremail, String paymentmode, string totalPrice)
        {
            int flag = 0;
            LinkedResource LinkedImage = new LinkedResource(Server.MapPath(Imageurl));
            LinkedImage.ContentId = "MyPic";

            string s = "<div style='height:fit-content;width:94%;background-color:#ffff66;border-radius:8px;border-style:solid;border-width:3px;border-color:hotpink;'>";
            s += "<div style='text-align:center;'>";
            s += "<div style='display:inline-flex;text-align:center;'>";
            s += "<h1 style='font-family:cursive;color:green;background-color:white;padding:20px;margin-top:30px;margin-bottom:30px'>Art<span style='font-family:cursive;color:hotpink;background-color:white;'>-Candervilla</span></h1><br/> ";
            s += "</div>";
            s += "</div>";
            s += "<div style='text-align:left;margin:10px'><div><h3 style='color:black;font-family:verdana;font-weight:800;'>" + username + "</h3><h4 style='color:gray;font-family:verdana;font-weight:800;>Order Id</h6><h6 style='color:black;font-family:verdana;font-weight:800;'>Order Id :- " + orderid + "</h4></div></div>";
            s += "<div style='text-align:center;'><div><img src=cid:MyPic style='height:100px;width:100px;border:solid;border-color:white;border-radius:5px'></div><div><h3 style='color:Red'>Product : " + productname + "</h3><h3 style='color:green'>Has been delivered Successfully..</h3></div></div>";
            s += "<div style='text-align:right;margin:10px'><h3 style='color:red;font-family:verdana;font-weight:800;'>Payment Mode : " + paymentmode + "</h3></div>";
            s += "<div style='text-align:right;margin:10px'><h3 style='color:Green;font-family:verdana;font-weight:800;'>Amount : ₹ " + Math.Round(Convert.ToDouble(totalPrice), 0) + "/-</h3></div>";
            s += "<div style='text-align:left;margin:10px'><h3 style='color:red;font-family:verdana;font-weight:800;'>Kind Regards</h3></div>";
            s += "<div style='text-align:left;margin:10px'><a href='artcandervilla.in' style='color:blue;font-family:verdana;font-weight:800;'>artcandervilla</a></div>";
            s += "</div>";
            AlternateView htmlView = AlternateView.CreateAlternateViewFromString(
                          s, null, "text/html");
            htmlView.LinkedResources.Add(LinkedImage);
            sendmails.EmailWithImgae(useremail, "Your Order  " + productname + " has been Successfully Delivered", htmlView);
            flag = 1;
            return flag;
        }
    }
}