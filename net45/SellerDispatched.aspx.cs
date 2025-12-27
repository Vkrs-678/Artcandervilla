using Razorpay.Api;
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
    public partial class WebForm20 : System.Web.UI.Page
    {
        SellerSignupRepo  seller = new SellerSignupRepo();
        Sendmail sendmails = new Sendmail();
        AddressRepo address= new AddressRepo();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["SellerLoggedintrue"]==null && Request.QueryString["orderid"]==null)
            {
                Response.Redirect("Default.aspx");
            }
            else
            {
                if(Request.QueryString["orderid"]==null)
                {
                    Session["SellerLoggedintrue"] = Session["SellerLoggedintrue"].ToString();
                }
               
            }
            if(!IsPostBack)
            {
                if (Request.QueryString["orderid"]!=null&& Request.QueryString["productid"] != null&& Request.QueryString["productrefid"] != null)
                {
                    Binddemail(Request.QueryString["orderid"].ToString(),Convert.ToDouble(Request.QueryString["productid"].ToString()), Request.QueryString["productrefid"].ToString());
                }
                else
                {
                    BindRepeater();
                    Double sellerid = Convert.ToInt64(Session["SellerLoggedintrue"] == null ? "1021" : Session["SellerLoggedintrue"].ToString());
                    Lblpendingcount.Text = seller.GetSellerDispatchPendingOrders(sellerid).ToString();
                }
                BindRepeater();
            }
        }

        protected void BindRepeater()
        {
            Double sellerid = Convert.ToInt64(Session["SellerLoggedintrue"] == null ? "1021" : Session["SellerLoggedintrue"].ToString());
            DataTable dt = seller.GetDataforSellerDispatch(sellerid);
            RptrProducts.DataSource = dt;
            RptrProducts.DataBind();
            Lblpendingcount.Text = seller.GetSellerDispatchPendingOrders(sellerid).ToString();
        }

        protected void LnkAccept_Click(object sender, EventArgs e)
        {
            RepeaterItem item = (sender as LinkButton).NamingContainer as RepeaterItem;
            
            HiddenField orderid = ((HiddenField)item.FindControl("orderid")) as HiddenField;
            Label orderids = ((Label)item.FindControl("LblOrderid")) as Label;           
            HiddenField userid = ((HiddenField)item.FindControl("Hdnuserid")) as HiddenField;           
            HiddenField sellerid = (HiddenField)item.FindControl("HdnSellerid");
            HiddenField productid = ((HiddenField)item.FindControl("Hdnproductid")) as HiddenField;
            HiddenField productrefid = ((HiddenField)item.FindControl("Hdnproductrefid")) as HiddenField;
            HiddenField productname = ((HiddenField)item.FindControl("Hdnproductname")) as HiddenField;
            HiddenField username = ((HiddenField)item.FindControl("Hdnusername")) as HiddenField;
            HiddenField useremail = ((HiddenField)item.FindControl("Hdnuseremail")) as HiddenField;
            HiddenField totalprice = ((HiddenField)item.FindControl("Hdntotalprice")) as HiddenField;           
            HiddenField imageurl = ((HiddenField)item.FindControl("Hdnimageurl")) as HiddenField;
            HiddenField paymentmode = ((HiddenField)item.FindControl("Hdnpaymentmode")) as HiddenField;
            Hdnfinalorderid.Value = orderid.Value;
            Hdnfinaluserid.Value = userid.Value;
            Hdnfinalsellerid.Value = sellerid.Value;
            Hdnfinalproductid.Value = productid.Value;
            Hdnfinalproductrefid.Value = productrefid.Value;
            Hdnfinalname.Value = productname.Value;
            Hdnfinalusername.Value = username.Value;
            Hdnfinalemail.Value = useremail.Value;
            Hdnfinaltotalprice.Value = totalprice.Value;
            Hdnfinalimageurl.Value = imageurl.Value;
            Hdnfinalpaymentmode.Value = paymentmode.Value;
            Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", " popup();", true);

          
        }

        protected void Lnkreject_Click(object sender, EventArgs e)
        {
            RepeaterItem item = (sender as LinkButton).Parent as RepeaterItem;
            HiddenField orderid = ((HiddenField)item.FindControl("orderid")) as HiddenField;
            HiddenField sellerid = ((HiddenField)item.FindControl("HdnSellerid")) as HiddenField;
            HiddenField productid = ((HiddenField)item.FindControl("Hdnproductid")) as HiddenField;
            HiddenField productrefid = ((HiddenField)item.FindControl("Hdnproductrefid")) as HiddenField;
            HiddenField productname = ((HiddenField)item.FindControl("Hdnproductname")) as HiddenField;
            HiddenField username = ((HiddenField)item.FindControl("Hdnusername")) as HiddenField;           
            HiddenField useremail = ((HiddenField)item.FindControl("Hdnuseremail")) as HiddenField;
            HiddenField totalprice = ((HiddenField)item.FindControl("Hdntotalprice")) as HiddenField;
            HiddenField imageurl = ((HiddenField)item.FindControl("Hdnimageurl")) as HiddenField;
            HiddenField paymentmode = ((HiddenField)item.FindControl("Hdnpaymentmode")) as HiddenField;


            int i = seller.UpdateDispatchedSeller(orderid.Value, Convert.ToDouble(sellerid.Value), Convert.ToDouble(productid.Value), productrefid.Value, "reject");
            if (i > 0)
            {
                BindRepeater();
                sendmailReject(orderid.Value, productname.Value, imageurl.Value, username.Value, useremail.Value, paymentmode.Value, totalprice.Value);
            }

        }

        protected void sendmail(String orderid,String productname,String Imageurl,String username,String useremail,String paymentmode,string totalPrice)
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
         
            s += "<div style='text-align:center;'><div><img src=cid:MyPic style='height:100px;width:100px;border:solid;border-color:white;border-radius:5px'></div><div><h3>Product : " + productname + "</h3><h3>Product has been dispatched & Will Deliver to You Soon</h3></div></div>";
            s += "<div style='text-align:right;margin:10px'><h3 style='color:red;font-family:verdana;font-weight:800;'>Payment Mode : " + paymentmode + "</h3></div>";
            s += "<div style='text-align:right;margin:10px'><h3 style='color:Green;font-family:verdana;font-weight:800;'>Amount Paid : ₹ " + Math.Round(Convert.ToDouble(totalPrice),0) + "/-</h3></div>";
            s += "<div style='text-align:left;margin:10px'><h3 style='color:red;font-family:verdana;font-weight:800;'>Kind Regards</h3></div>";
            s += "<div style='text-align:left;margin:10px'><a href='artcandervilla.in' style='color:blue;font-family:verdana;font-weight:800;'>artcandervilla</a></div>";
            s += "</div>";
            AlternateView htmlView = AlternateView.CreateAlternateViewFromString(
                          s, null, "text/html");
            htmlView.LinkedResources.Add(LinkedImage);
            sendmails.EmailWithImgae(useremail, "Your Order  " + productname + " has been Dispatched", htmlView);
          
        }

        protected void sendmailAdmin(String orderid, String productname, String Imageurl, String username, String useremail, String paymentmode, string totalPrice)
        {
            LinkedResource LinkedImage = new LinkedResource(Server.MapPath(Imageurl));
            LinkedImage.ContentId = "MyPic";

            string s = "<div style='height:fit-content;width:94%;background-color:#ffff66;border-radius:8px;border-style:solid;border-width:3px;border-color:hotpink;'>";
            s += "<div style='text-align:center;'>";
            s += "<div style='display:inline-flex;text-align:center;'>";
            s += "<h1 style='font-family:cursive;color:green;background-color:white;padding:20px;margin-top:30px;margin-bottom:30px'>Art<span style='font-family:cursive;color:hotpink;background-color:white;'>-Candervilla</span></h1><br/> ";
            s += "</div>";
            s += "</div>";
            s += "<div style='text-align:left;margin:10px'><div><h3 style='color:black;font-family:verdana;font-weight:800;'>Hello Admin,</h3><h4 style='color:gray;font-family:verdana;font-weight:800;>Order Id</h6><h6 style='color:black;font-family:verdana;font-weight:800;'>Order Id :- " + orderid + "</h4></div></div>";
            // s += "<div style='text-align:left;margin:10px'><div><h4 style='color:black;font-family:verdana;font-weight:800;'>Tracking Id :- " + trackno + "</h4></div></div>";

            s += "<div style='text-align:center;'><div><img src=cid:MyPic style='height:100px;width:100px;border:solid;border-color:white;border-radius:5px'></div><div><h3>Product : " + productname + "</h3><h3>Product has been dispatched & Ready For Shipment</h3></div></div>";
            s += "<div style='text-align:right;margin:10px'><h3 style='color:red;font-family:verdana;font-weight:800;'>Payment Mode : " + paymentmode + "</h3></div>";
            s += "<div style='text-align:right;margin:10px'><h3 style='color:Green;font-family:verdana;font-weight:800;'>Amount Paid : ₹ " + Math.Round(Convert.ToDouble(totalPrice), 0) + "/-</h3></div>";
            s += "<div style='text-align:left;margin:10px'><h3 style='color:red;font-family:verdana;font-weight:800;'>Kind Regards</h3></div>";
            s += "<div style='text-align:left;margin:10px'><a href='artcandervilla.bsite.net' style='color:blue;font-family:verdana;font-weight:800;'>artcandervilla</a></div>";
            s += "</div>";
            AlternateView htmlView = AlternateView.CreateAlternateViewFromString(
                          s, null, "text/html");
            htmlView.LinkedResources.Add(LinkedImage);
           
            sendmails.EmailWithImgae("artcandervilla@gmail.com", "Your Order  " + productname + " has been Dispatched", htmlView);
        }

        protected void sendmailReject(String orderid,String productname, String Imageurl, String username,String useremail, String paymentmode, string totalPrice)
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
            s += "<div style='text-align:center;'><div><img src=cid:MyPic style='height:100px;width:100px;border:solid;border-color:white;border-radius:5px'></div><div><h3 style='color:Red'>Product : " + productname + "</h3><h3>Product is Declined by Seller & Your Refund Will be Soon Deposite To Your Account</h3></div></div>";
            s += "<div style='text-align:right;margin:10px'><h3 style='color:red;font-family:verdana;font-weight:800;'>Payment Mode : " + paymentmode + "</h3></div>";
            s += "<div style='text-align:right;margin:10px'><h3 style='color:Green;font-family:verdana;font-weight:800;'>Amount Paid : ₹ " + Math.Round(Convert.ToDouble(totalPrice), 0) + "/-</h3></div>";
            s += "<div style='text-align:left;margin:10px'><h3 style='color:red;font-family:verdana;font-weight:800;'>Kind Regards</h3></div>";
            s += "<div style='text-align:left;margin:10px'><a href='artcandervilla.bsite.net' style='color:blue;font-family:verdana;font-weight:800;'>artcandervilla</a></div>";
            s += "</div>";
            AlternateView htmlView = AlternateView.CreateAlternateViewFromString(
                          s, null, "text/html");
            htmlView.LinkedResources.Add(LinkedImage);
            sendmails.EmailWithImgae(useremail, "Your Order  " + productname + " has been Decline By Seller", htmlView);
        }

        protected void RptrProducts_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
            {
                HiddenField Dispatchedstatus = (HiddenField)e.Item.FindControl("Hdndispatchedstatus");
                Panel panelprint = (Panel)e.Item.FindControl("panelprint");
                Panel panelaccept = (Panel)e.Item.FindControl("Panelaccept");
              
                String dispatchstatus = Dispatchedstatus.Value == "" ? "0" : Dispatchedstatus.Value;

               if(dispatchstatus=="0")
                {
                    panelaccept.Visible = true;
                    panelprint.Visible = false;
                }  
               else if(dispatchstatus == "2")
                {
                    panelprint.Visible = false;
                    panelaccept.Visible = false;
                    panelprint.Visible = false;
                }
                else
                {
                    panelprint.Visible = true;
                    panelaccept.Visible = false;
                    panelprint.Visible = true;
                }
            }
        }

        protected void LnkPendingforapproval_Click(object sender, EventArgs e)
        {
            Double sellerid = Convert.ToInt64(Session["SellerLoggedintrue"] == null ? "1021" : Session["SellerLoggedintrue"].ToString());
            DataTable dt = seller.GetOrderDetailsforDispatchPendingOnly(sellerid);
            RptrProducts.DataSource = dt;
            RptrProducts.DataBind();
        }

        protected void Lnksearchorderid_Click(object sender, EventArgs e)
        {
            Double sellerid = Convert.ToInt64(Session["SellerLoggedintrue"] == null ? "1021" : Session["SellerLoggedintrue"].ToString());
            DataTable dt = seller.GetOrderDetailsforDispatchOrderid(Txtorderid.Text.Trim());
            RptrProducts.DataSource = dt;
            RptrProducts.DataBind();
        }


        protected void Binddemail(string orderid ,Double productid,string productrefid)
        {
           
            DataTable dt = seller.GetOrderDetailsforDispatchOEmailpatch(orderid,productid,productrefid);
            RptrProducts.DataSource = dt;
            RptrProducts.DataBind();
        }

        protected void LnkfinalAccept_Click(object sender, EventArgs e)
        {
           
            if (Txtheight.Text.Trim() == "")
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "swal('Height', 'Enter Height', 'error')", true);
                return;
            }

            if (Txtwidth.Text.Trim() == "")
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "swal('Width', 'Enter Width', 'error')", true);
                return;
            }

            if (Txtlength.Text.Trim() == "")
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "swal('Length', 'Enter Length', 'error')", true);
                return;
            }

            if (TxtWeight.Text.Trim() == "")
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "swal('Weight', 'Enter Weigth', 'error')", true);
                return;
            }

            if (chksizeandcolor.Checked == false)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "swal('Size & Color', 'Confirm Size and Color', 'error')", true);
                return;
            }

            int i = seller.UpdateDispatchedSeller(Hdnfinalorderid.Value, Convert.ToDouble(Hdnfinalsellerid.Value), Convert.ToDouble(Hdnfinalproductid.Value), Hdnfinalproductrefid.Value, "accept");
            int j = seller.AddSpecification(Hdnfinalorderid.Value, Convert.ToDouble(Hdnfinalproductid.Value), Hdnfinalproductrefid.Value, Convert.ToInt32(Txtheight.Text.Trim()), Convert.ToInt32(Txtwidth.Text.Trim()), Convert.ToInt32(Txtlength.Text.Trim()), Convert.ToDouble(TxtWeight.Text.Trim()));
            if (i > 0)
            {
                BindRepeater();
                sendmail(Hdnfinalorderid.Value, Hdnfinalname.Value, Hdnfinalimageurl.Value, Hdnfinalusername.Value, Hdnfinalemail.Value, Hdnfinalpaymentmode.Value, Hdnfinaltotalprice.Value);
                sendmailAdmin(Hdnfinalorderid.Value, Hdnfinalname.Value, Hdnfinalimageurl.Value, Hdnfinalusername.Value, Hdnfinalemail.Value, Hdnfinalpaymentmode.Value, Hdnfinaltotalprice.Value);
            }
        }
    }
}