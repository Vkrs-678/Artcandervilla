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
    public partial class WebForm32 : System.Web.UI.Page
    {
        Sendmail sendemail = new Sendmail();
        AdminDashbordRepo admin = new AdminDashbordRepo();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {

                if (Session["isAdminid"] == null)
                {
                    Response.Redirect("Default.aspx");
                }
                else
                {
                    Session["isAdminid"] = Session["isAdminid"].ToString();
                }

                bindData();
            }
        }

        private void bindData()
        {
            RptrProducts.DataSource = admin.GetDataforSettlement();
            RptrProducts.DataBind();
        }

        protected void sendmailseller(String selleremail, string Imageurl, String Productname, double totalPrice, String orderid, String productqty, String productsize, double productid, string productrefid, String Paymentmode)
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
            s += "<div style='text-align:center;'><div><img src=cid:MyPic style='height:100px;width:100px;border:solid;border-color:white;border-radius:5px'></div><div><h3>Product Name : " + Productname + "</h3><h3>Qty : " + productqty + "</h3><h3>Size : " + productsize + "</h3></div></div>";           
            s += "<div style='text-align:right;margin:10px'><h3 style='color:red;font-family:verdana;font-weight:800;'>Payment Mode : " + Paymentmode + "</h3></div>";
            s += "<div style='text-align:right;margin:10px'><h3 style='color:Green;font-family:verdana;font-weight:800;'>Settled Amount : ₹ " + Math.Round(Convert.ToDouble(totalPrice),0) + "/-</h3></div>";
            s += "<div style='text-align:left;margin:10px'><h3 style='color:red;font-family:verdana;font-weight:800;'>Kind Regards</h3></div>";
            s += "<div style='text-align:left;margin:10px'><a href='artcandervilla.in' style='color:blue;font-family:verdana;font-weight:800;'>artcandervilla</a></div>";
            s += "</div>";
            AlternateView htmlView = AlternateView.CreateAlternateViewFromString(
                          s, null, "text/html");
            htmlView.LinkedResources.Add(LinkedImage);
            sendemail.EmailWithImgae(selleremail, " Order  " + Productname + " has been Settled", htmlView);
        }

        protected void BtnPayNow_Click(object sender, EventArgs e)
        {
            RepeaterItem item = (sender as LinkButton).Parent as RepeaterItem;
            HiddenField orderid=(HiddenField)item.FindControl("Hdnorderid") as HiddenField;
            HiddenField productid=(HiddenField)item.FindControl("Hdnproductid") as HiddenField;
            HiddenField productrefi=(HiddenField)item.FindControl("Hdproductrefid") as HiddenField;
            HiddenField email=(HiddenField)item.FindControl("HdnEmail") as HiddenField;
            HiddenField image=(HiddenField)item.FindControl("HdnproductImage") as HiddenField;
            HiddenField name=(HiddenField)item.FindControl("Hdnproductname") as HiddenField;
            HiddenField amount=(HiddenField)item.FindControl("Hdnproductamount") as HiddenField;
            
            HiddenField qty=(HiddenField)item.FindControl("Hdnproductqty") as HiddenField;
            HiddenField size=(HiddenField)item.FindControl("Hdnproductsize") as HiddenField;
            HiddenField mode=(HiddenField)item.FindControl("Hdnpaymentmode") as HiddenField;

            int i = admin.UpdateSettlementstatus(orderid.Value, Convert.ToDouble(productid.Value), productrefi.Value);
            if(i>0)
            {
               
                bindData();
                sendmailseller(email.Value, image.Value, name.Value,Math.Round(Convert.ToDouble(amount.Value.ToString()),2), orderid.Value, qty.Value, size.Value, Convert.ToDouble(productid.Value.ToString()), productrefi.Value, mode.Value);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "swal('Amount Settled', 'Paid Successfully', 'success')", true);
                
            }
        }

        protected void Lnksearch_Click(object sender, EventArgs e)
        {
            RptrProducts.DataSource = admin.GetDataforSettlement(Txtordersearch.Text.Trim());
            RptrProducts.DataBind();
        }

        protected void RptrProducts_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            
            HiddenField pID = (e.Item.FindControl("Hdnsettled") as HiddenField);
            LinkButton linkbutton = (e.Item.FindControl("BtnPayNow") as LinkButton);
            //RepeaterItem item = (sender as Repeater).Parent as RepeaterItem;
            //HiddenField settled = (HiddenField)item.FindControl("Hdnsettled") as HiddenField;
            //LinkButton linkbutton = (LinkButton)item.FindControl("BtnPayNow") as LinkButton;
            if(pID.Value== "settled")
            {
                linkbutton.Visible = false;
            }
        }
    }
}