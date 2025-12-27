using Org.BouncyCastle.Asn1.Ocsp;
using RazorpaySampleApp.Connections.Implimentations;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RazorpaySampleApp
{
    public partial class WebForm17 : System.Web.UI.Page
    {
        ProductListRepo product = new ProductListRepo();

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                bindRepeater();
            }

          
        }

        private void bindRepeater()
        {
            
            string userid = Request.QueryString["userid"]==null? "0": Request.QueryString["userid"].ToString();
            DataSet ds = product.Getcartvalues(userid);
            Repeater.DataSource = ds.Tables[0];
            Repeater.DataBind();
            if(ds.Tables[1].Rows.Count > 0)
            {
                lblTotalAmount.Text = "₹ " + ds.Tables[1].Rows[0]["totalAmount"].ToString();
                Lbltotaldiscount.Text = "-₹ " + ds.Tables[1].Rows[0]["totaldiscount"].ToString();
                LbltotalDeliverycharge.Text = "+₹ " + ds.Tables[1].Rows[0]["toatoldeliverycharge"].ToString();
                lbltotalpayableAmont.Text = "₹ " + ds.Tables[1].Rows[0]["totalpayableamount"].ToString();
            }
            
           
        }

        protected void Repeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if(e.Item.ItemType==ListItemType.AlternatingItem || e.Item.ItemType== ListItemType.Item)
            {
                HiddenField availablqty = (HiddenField)e.Item.FindControl("Hdnavailableqty");               
                
                DropDownList droqty = (DropDownList)e.Item.FindControl("dropselectQuantity");

                droqty.SelectedValue = availablqty.Value;
            }
        }

        protected void dropselectQuantity_SelectedIndexChanged(object sender, EventArgs e)
        {
            RepeaterItem item=(sender as DropDownList).Parent as RepeaterItem;
            DropDownList qty=((DropDownList)item.FindControl("dropselectQuantity")) as DropDownList;
            HiddenField productid=((HiddenField)item.FindControl("Hdnproductid")) as HiddenField;
            HiddenField productrefid=((HiddenField)item.FindControl("Hdnproductrefid")) as HiddenField;
            HiddenField availquantity=((HiddenField)item.FindControl("HdnactualQuantity")) as HiddenField;
            HiddenField newqvailqty= ((HiddenField)item.FindControl("Hdnavlqty")) as HiddenField;

            HiddenField producttype = ((HiddenField)item.FindControl("HdnproductType"))as HiddenField;
            if ((producttype.Value == "CLOTHING" || producttype.Value == "FOOTWEAR") && Convert.ToInt32(qty.SelectedItem.Value) > Convert.ToInt32(newqvailqty.Value))
            {
                qty.SelectedValue = newqvailqty.Value;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "swal('Quantity Unavailable', 'Only " + newqvailqty.Value + " Quantities are Available !', 'error')", true);
            }
           else if (Convert.ToInt32(qty.SelectedItem.Value)> Convert.ToInt32(availquantity.Value))
            {
                qty.SelectedValue=availquantity.Value;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop","swal('Quantity Unavailable', 'Only "+availquantity.Value+" Quantities are Available !', 'error')", true);
            }

            int i=product.upateCartqty(Convert.ToInt32(qty.SelectedItem.Value),Convert.ToInt32(productid.Value),productrefid.Value);

            bindRepeater();
        }

        protected void Btnremoveproduct_Click(object sender, EventArgs e)
        {
            if(Session["UserLoginTrue"]==null)
            {
                Response.Redirect("Default.aspx");
                return;
            }
            string userid = Request.QueryString["userid"] == null ? "0" : Request.QueryString["userid"].ToString();
            RepeaterItem item = (sender as LinkButton).Parent as RepeaterItem;
            HiddenField productid = ((HiddenField)item.FindControl("Hdnproductid")) as HiddenField;
            try           {
                

                int i = product.Deletecartitem(Convert.ToDouble(productid.Value), userid);
                if (i > 0)
                {
                   // Response.Redirect(HttpContext.Current.Request.Url.AbsoluteUri);
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
                }
                bindRepeater();
            }
            catch(Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "swal('Exception Handling !', '"+ex.Message+"', 'error')", true);
            }
           

            
        }

        protected void LnkBuynow_Click(object sender, EventArgs e)
        {
            if (Session["UserLoginTrue"] == null)
            {
                Session["Redirecturl"] = HttpContext.Current.Request.Url.AbsoluteUri;
                Response.Redirect("LoginForm.aspx");
                return;
            }
            if(RdoCOD.Checked==false && RdoPaynow.Checked==false)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "swal('Payment Mode', 'Select Payment Mode', 'error')", true);
                return;
            }
            if(RdoPaynow.Checked==true)
            {
                Session["Payonline"] = true;
            }
            DataTable dts = product.getCartItemForbuy(Session["UserLoginTrue"].ToString());
            if(dts.Rows.Count<=0)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "swal('Cart Empty ', 'Add Something in Your Cart', 'error')", true);
                return;
            }
            DataTable dt = new DataTable();
            dt.Columns.Add("userid");
            dt.Columns.Add("productid");
            dt.Columns.Add("productrefid");
            dt.Columns.Add("image");
            dt.Columns.Add("quantity");
            dt.Columns.Add("iscod");
            dt.Columns.Add("payableamount");
            dt.Columns.Add("buymode");
            dt.Columns.Add("description");
            dt.Columns.Add("size");
            
            double payableamoutn = 0;
            
            foreach (DataRow row in dts.Rows)
            {
                payableamoutn += Convert.ToDouble(row["payableAmount"].ToString());
            }
           
            foreach (DataRow row in dts.Rows)
            {
                


                dt.Rows.Add(Session["UserLoginTrue"], row["product_id"], row["ref_productid"], row["image1"], row["purchasedquantity"], row["iscod"], payableamoutn, row["buymode"], row["productname"], row["size"]);
            }
            Session["placeorderdata"] = dt;
            Response.Redirect("AddressSelectionPage.aspx");
        }
    }
}