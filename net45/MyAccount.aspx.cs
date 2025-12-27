using Org.BouncyCastle.Asn1.X509;
using RazorpaySampleApp.Connections.Implimentations;
using RazorpaySampleApp.SendmailClass;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Mail;
using System.Reflection.Emit;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RazorpaySampleApp
{
    public partial class WebForm23 : System.Web.UI.Page
    {
        ProductListRepo product = new ProductListRepo();
        Sendmail sendmails = new Sendmail();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["UserLoginTrue"]==null)
            {
                Response.Redirect("Default.aspx");
            }
            else
            {
                Session["UserLoginTrue"] = Session["UserLoginTrue"].ToString();
            }
            if (!IsPostBack)
            {
                bindRepeater();
                Bindwhislist();
               
            }
        }

       

        private void bindRepeater()
        {

            string userid = Session["UserLoginTrue"] == null ? "0" : Session["UserLoginTrue"].ToString();
            DataSet ds = product.Getcartvalues(userid);
           // DataTable list = ds.Tables[3].AsEnumerable().Where(x=>x.Field<string>("productrefid")=="dfdfdfdfd").Distinct().CopyToDataTable();
            Repeater.DataSource = ds.Tables[3];
            Repeater.DataBind();

            Label1.Text = ds.Tables[4].Rows[0]["username"].ToString();
            Label2.Text = ds.Tables[4].Rows[0]["useremail"].ToString();
            Label3.Text = ds.Tables[4].Rows[0]["usermobile"].ToString();
           


        }

        private void Bindwhislist()
        {
            string userid = Session["UserLoginTrue"] == null ? "0" : Session["UserLoginTrue"].ToString();
            RepeaterWishlist.DataSource = product.GetWishlist(userid);
            RepeaterWishlist.DataBind();
        }

        protected void Repeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
            {
                HiddenField hdndeliverstatus = (HiddenField)e.Item.FindControl("Hdndeliverystatus");
                HiddenField avaquantity = (HiddenField)e.Item.FindControl("avalquanity");
                HiddenField orderid = (HiddenField)e.Item.FindControl("Hdnporderid");
                HiddenField productid = (HiddenField)e.Item.FindControl("Hdnproductid");
                HiddenField productrefid = (HiddenField)e.Item.FindControl("Hdnproductrefid");
                HiddenField productiscancelled = (HiddenField)e.Item.FindControl("HdnisCancelled");
                HiddenField dispatchedstatus = (HiddenField)e.Item.FindControl("HdnDispatchstatus");
                HiddenField deliverystatus = (HiddenField)e.Item.FindControl("Hdndeliverystatus");
                HiddenField isreturn = (HiddenField)e.Item.FindControl("Hdnreturn");
                HiddenField isreplacemnt = (HiddenField)e.Item.FindControl("Hdnreplacement");
                HiddenField finallyDelivered = (HiddenField)e.Item.FindControl("HdnfinallyDelivered");
                HiddenField finalDeliverydate = (HiddenField)e.Item.FindControl("HdnFinallyDeliveredDate");
                HiddenField isrefused = (HiddenField)e.Item.FindControl("Hdnisrefused");
                HiddenField returnrquested = (HiddenField)e.Item.FindControl("Hdnreturnrequest");
               
                Panel paneldownload = (Panel)e.Item.FindControl("Panel1");
                Panel panelDelivere = (Panel)e.Item.FindControl("PanelDelivered");
                Panel panelyetToDelivered = (Panel)e.Item.FindControl("Panelyet");
                Panel panelTrackshipment = (Panel)e.Item.FindControl("Panel2");
                Panel paneldispatched = (Panel)e.Item.FindControl("Paneldispatched");
                Panel paneldelivered = (Panel)e.Item.FindControl("PanelDelivered");
                Panel panelshipped = (Panel)e.Item.FindControl("Panelshipped");
                Panel panelbtn = (Panel)e.Item.FindControl("panelbtn");
                LinkButton Cancelbtn = (LinkButton)e.Item.FindControl("btnCancel");
                LinkButton Returnbtn = (LinkButton)e.Item.FindControl("btnReturn");                             
                LinkButton Trackbtn = (LinkButton)e.Item.FindControl("btnTrack");
                LinkButton Downloadslip = (LinkButton)e.Item.FindControl("btnDownloadSlip");
                System.Web.UI.WebControls.Label lblcancelled = (System.Web.UI.WebControls.Label)e.Item.FindControl("lblCancelled");
                System.Web.UI.WebControls.Label lblrefused = (System.Web.UI.WebControls.Label)e.Item.FindControl("lblRefused");
                System.Web.UI.WebControls.Label lblinstock = (System.Web.UI.WebControls.Label)e.Item.FindControl("Label7");
                System.Web.UI.WebControls.Label lblooutofstock = (System.Web.UI.WebControls.Label)e.Item.FindControl("Label6");

                string isoutfordelivery = deliverystatus.Value == "" ? "0" : deliverystatus.Value;
                string dispatchced = hdndeliverstatus.Value == "" ? "0" : hdndeliverstatus.Value;
                string iscancelled = productiscancelled.Value == "" ? "0" : productiscancelled.Value;
                string rejected = dispatchedstatus.Value == "" ? "0" : dispatchedstatus.Value;
                string isreturnpossible = isreturn.Value == "" ? "0" : isreturn.Value;
                string isreplacementpossible = isreplacemnt.Value == "" ? "0" : isreplacemnt.Value;
                string DeliveryCompleted = finallyDelivered.Value == "" ? "0" : finallyDelivered.Value;
                string Dispathcedvalue = dispatchedstatus.Value == "" ? "0" : dispatchedstatus.Value;
                string finalDeliverydates = finalDeliverydate.Value == "" ? "0" : finalDeliverydate.Value;
                string isrefuseds = isrefused.Value == "" ? "0" : isrefused.Value;
                //setting value to outside

                Hdnproductid.Value = productid.Value;
                Hdnproductrefid.Value = productrefid.Value;
                Hdnporderid.Value = orderid.Value;
                if (iscancelled=="1")
                {
                    //all btn start
                    Cancelbtn.Visible = false;
                    Returnbtn.Visible = false;
                    Trackbtn.Visible = false;
                    Downloadslip.Visible = false;
                    //all btn start
                    lblcancelled.Visible = true;
                }
                else if(rejected == "2")
                {
                    //all btn start
                    Cancelbtn.Visible = false;
                    Returnbtn.Visible = false;
                    Trackbtn.Visible = false;
                    Downloadslip.Visible = false;
                    //all btn start
                    lblrefused.Visible = true;
                }

               if(isrefuseds=="1")
                {
                    //all btn start
                    Cancelbtn.Visible = false;
                    Returnbtn.Visible = false;
                    Trackbtn.Visible = false;
                    Downloadslip.Visible = false;
                    //all btn start
                    lblrefused.Text = "Order Refused";
                    lblrefused.Visible = true;
                }

               if((returnrquested.Value!="" && returnrquested.Value == "0") && DeliveryCompleted == "1")
                {
                    //all btn start
                    Cancelbtn.Visible = false;
                    Returnbtn.Visible = false;
                    Trackbtn.Visible = false;
                    Downloadslip.Visible = false;
                    //all btn start
                    lblrefused.Text = "Return Requested";
                    lblrefused.Visible = true;
                }
               else if(returnrquested.Value == "1" &&  DeliveryCompleted == "1")
                {
                    //all btn start
                    Cancelbtn.Visible = false;
                    Returnbtn.Visible = false;
                    Trackbtn.Visible = false;
                    Downloadslip.Visible = false;
                    //all btn start
                    lblrefused.Text = "Return Accepted";
                    lblrefused.Visible = true;
                }
                else if (returnrquested.Value == "2" && DeliveryCompleted == "1")
                {
                    //all btn start
                    Cancelbtn.Visible = false;
                    Returnbtn.Visible = false;
                    Trackbtn.Visible = false;
                    Downloadslip.Visible = true;
                    //all btn start
                    lblrefused.Text = "Return Request Rejected";
                    lblrefused.ForeColor = System.Drawing.Color.Red;
                    lblrefused.Visible = true;
                }


                if (isoutfordelivery == "0")
                {
                    Cancelbtn.Visible = false;
                }

                
                if(Dispathcedvalue == "0" && isoutfordelivery=="0" && iscancelled=="0")
                {
                    panelyetToDelivered.Visible = true;
                    Cancelbtn.Visible = true;
                }
                else if(Dispathcedvalue == "1" && isoutfordelivery == "0" && iscancelled == "0")
                {
                    paneldispatched.Visible = true;
                    Cancelbtn.Visible = true;
                }
                else if (Dispathcedvalue == "1" && isoutfordelivery == "1" && DeliveryCompleted == "0" && isrefuseds == "0")
                {
                    panelshipped.Visible = true;
                }
                else if(Dispathcedvalue == "1" && isoutfordelivery == "1" && DeliveryCompleted == "1" && returnrquested.Value == "")
                {
                    paneldelivered.Visible = true;
                }

                
               
                

                if (hdndeliverstatus.Value == "0")
                {
                    
                   

                }
                else
                {
                    

                    if(Convert.ToInt32(isreturnpossible)>0 && DeliveryCompleted=="1" && returnrquested.Value == "")
                    {
                        if(DateTime.Now<=Convert.ToDateTime(finalDeliverydate.Value).AddDays(Convert.ToInt32(isreturnpossible)))
                        {
                            Returnbtn.Visible = true;
                        }
                       
                    }
                    else if((Convert.ToInt32(isreplacementpossible) > 0) && DeliveryCompleted=="1")
                    {
                       // dropdownlist.Items.Insert(1, new ListItem("Replacement", "4"));
                    }

                    if(isoutfordelivery=="1" && DeliveryCompleted=="0" && returnrquested.Value == "")
                    {
                        Trackbtn.Visible = true;
                    }
                    

                    if(DeliveryCompleted=="1" && returnrquested.Value == "")
                    {
                        Downloadslip.Visible = true;
                    }
                   
                }


                if(avaquantity.Value=="0")
                {
                    lblinstock.Visible = false;
                    lblooutofstock.Visible = true;
                }
                else
                {
                    lblinstock.Visible = true;
                    lblooutofstock.Visible = false;
                }

               
            }
        }

        protected void btnDownloadSlip_Click(object sender, EventArgs e)
        {
            RepeaterItem item = (sender as LinkButton).Parent as RepeaterItem;
            var orderid = item.FindControl("Hdnporderid") as HiddenField;
            var productid = item.FindControl("Hdnproductid") as HiddenField;
            var productrefid = item.FindControl("Hdnproductrefid") as HiddenField;

            Response.Redirect("slip.aspx?orderid=" + orderid.Value + "&&productid=" + productid.Value + "&&productrefid=" + productrefid.Value + "");

        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            RepeaterItem item = (sender as LinkButton).Parent as RepeaterItem;
            var orderid = item.FindControl("Hdnporderid") as HiddenField;
            var productid = item.FindControl("Hdnproductid") as HiddenField;
            var productrefid = item.FindControl("Hdnproductrefid") as HiddenField;
            var image = item.FindControl("Image1") as Image;
            var selleremail = item.FindControl("HdnSelleremail") as HiddenField;
            var paymentmode = item.FindControl("HdnpaymentMode") as HiddenField;

            int i = product.Cancelorder(orderid.Value, Convert.ToDouble(productid.Value), productrefid.Value);
            if (i > 0)
            {
             if(paymentmode.Value=="Onlline")
             {
                    sendmailseller("artcandervilla@gmail.com", image.ImageUrl, orderid.Value);
             }
                bindRepeater();
            }
        }

        protected void btnReturn_Click(object sender, EventArgs e)
        {
            RepeaterItem item = (sender as LinkButton).Parent as RepeaterItem;
             var orderid = item.FindControl("Hdnporderid") as HiddenField;
            var productid = item.FindControl("Hdnproductid") as HiddenField;
            var productrefid = item.FindControl("Hdnproductrefid") as HiddenField;
            Response.Redirect("returnpage.aspx?orderid=" + orderid.Value + "&&productid=" + productid.Value + "&&productrefid=" + productrefid.Value + "");
           
        }

        protected void sendmailseller(String selleremail, string Imageurl,  String orderid)
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
            s += "<div style='text-align:center;'><div><img src=cid:MyPic style='height:100px;width:100px;border:solid;border-color:white;border-radius:5px'></div><div><div><h3>Order has been Cancelled and Refund it's Amount</h3></div>";
            //s += "<div style='text-align:right;margin:10px'><h3 style='color:red;font-family:verdana;font-weight:800;'>Payment Mode : " + Paymentmode + "</h3></div>";
          //  s += "<div style='text-align:right;margin:10px'><h3 style='color:Green;font-family:verdana;font-weight:800;'>Amount : ₹ " + Math.Round(Convert.ToDouble(totalPrice), 0) + "/-</h3></div>";
            s += "<div style='text-align:left;margin:10px'><h3 style='color:red;font-family:verdana;font-weight:800;'>Kind Regards</h3></div>";
            s += "<div style='text-align:left;margin:10px'><a href='artcandervilla.in' style='color:blue;font-family:verdana;font-weight:800;'>artcandervilla</a></div>";
            s += "</div>";
            AlternateView htmlView = AlternateView.CreateAlternateViewFromString(s, null, "text/html");
            htmlView.LinkedResources.Add(LinkedImage);
            sendmails.EmailWithImgae(selleremail, " Order id  " + orderid + " Has been Cancelled", htmlView);
        }
    }
}