using RazorpaySampleApp.Cartdataclass;
using RazorpaySampleApp.Connections.Implimentations;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.AccessControl;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IPinfo;
using IPinfo.Models;
using System.Threading.Tasks;
using System.Net;
using RestSharp;
using Newtonsoft.Json.Linq;
using System.Web.Script.Services;
using System.Web.Services;

namespace RazorpaySampleApp
{
    public partial class WebForm16 : System.Web.UI.Page
    {
        ProductListRepo product= new ProductListRepo();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["productid"]==null && Request.QueryString["productrefid"]==null)
            {
                Response.Redirect("Default.aspx");

                
            }
            if (Session["Redirecturl"] != null)
            {
                Session["Redirecturl"] = null;
            }
            
            double id = Convert.ToDouble(Request.QueryString["productid"].ToString());
            string ref_id = Request.QueryString["productrefid"].ToString();
            DataTable dt = product.GetQuantity(id, ref_id);
            Boolean qu = false;
            foreach(DataRow row in dt.Rows)
            {
                if (Convert.ToInt32(row["Avl_Quantity"].ToString())>0 || Convert.ToInt32(row["qty"].ToString()) > 0)
                {
                    qu = true;
                    break;
                }
            }
            if (qu)
            {
                PanelButtonbuy.Visible = true;
                PanelOutofStokc.Visible = false;
               
            }
            else
            {
                PanelButtonbuy.Visible = false;
                PanelOutofStokc.Visible = true;
            }
            if (!IsPostBack)
            {
                Txtcheckpincode.Text = "110006";
                BindAllData();
                Loginpanel();
                BindsizeRptr();
                lblid.ForeColor = System.Drawing.Color.Gray;
                if (Session["UserLoginTrue"]!=null)
                {
                  int isvailable=  getWishlist();//get color of wishlist button;

                    if (isvailable == 1)
                    {

                        lblid.ForeColor = System.Drawing.Color.Red;
                    }
                    else
                    {

                        lblid.ForeColor = System.Drawing.Color.Gray;
                    }
                }

                




            }

           
        }

        private void BindsizeRptr()
        {
            double id = Convert.ToDouble(Request.QueryString["productid"].ToString());
            string ref_id = Request.QueryString["productrefid"].ToString();

            Rtrsize.DataSource = product.GetProductdetails(id, ref_id).Tables[5];
            Rtrsize.DataBind();
        }
       

        private void BindAllData()
        {
            double id = Convert.ToDouble(Request.QueryString["productid"].ToString());
            string ref_id = Request.QueryString["productrefid"].ToString();
            DataSet ds = product.GetProductdetails(id, ref_id);
            bindcomment(ds.Tables[1]);
            bindreferenceProducts(ds.Tables[4]);
            DataTable dt = ds.Tables[0];
            if(dt.Rows.Count>0)
            {
                MainImage.ImageUrl = dt.Rows[0]["image1"].ToString();               
                MainImage1.ImageUrl = dt.Rows[0]["image2"].ToString();               
                MainImage2.ImageUrl = dt.Rows[0]["image3"].ToString();               
                MainImage3.ImageUrl = dt.Rows[0]["image4"].ToString();               
                MainImage4.ImageUrl = dt.Rows[0]["image5"].ToString();                                        
                Imagecarasoul1.ImageUrl = dt.Rows[0]["image1"].ToString();
                imgcomment.ImageUrl = dt.Rows[0]["image1"].ToString();
                SubImage1.ImageUrl = dt.Rows[0]["image1"].ToString();
                Sidesumimage1.ImageUrl = dt.Rows[0]["image1"].ToString();
                SubImage2.ImageUrl = dt.Rows[0]["image2"].ToString();
                Sidesumimage2.ImageUrl = dt.Rows[0]["image2"].ToString();
                Imagecarasoul2.ImageUrl = dt.Rows[0]["image2"].ToString();
                SubImage3.ImageUrl = dt.Rows[0]["image3"].ToString();
                Sidesumimage3.ImageUrl = dt.Rows[0]["image3"].ToString();
                Imagecarasoul3.ImageUrl = dt.Rows[0]["image3"].ToString();
                SubImage4.ImageUrl = dt.Rows[0]["image4"].ToString();
                Sidesumimage4.ImageUrl = dt.Rows[0]["image4"].ToString();
                Imagecarasoul4.ImageUrl = dt.Rows[0]["image4"].ToString();
                SubImage5.ImageUrl = dt.Rows[0]["image5"].ToString();
                Sidesumimage5.ImageUrl = dt.Rows[0]["image5"].ToString();
                Imagecarasoul5.ImageUrl = dt.Rows[0]["image5"].ToString();
                LblSellerName.Text = dt.Rows[0]["SellerName"].ToString();
                LblSellerEmail.Text = dt.Rows[0]["Email"].ToString();
                string warranty = "";
                if(dt.Rows[0]["warranty"].ToString()!="" && dt.Rows[0]["warranty"].ToString() != "0")
                {
                    warranty = dt.Rows[0]["warranty"].ToString() + "  Months Seller's Warranty";
                }
                Lblwarranty.Text = warranty;
              //  Hdnpincode.Value= dt.Rows[0]["deliverypincode"].ToString();
                Lblmainbrand.Text = dt.Rows[0]["productbrand"].ToString();
                lblmainproductname.Text= dt.Rows[0]["productname"].ToString();
                Double totalrate = Convert.ToDouble(ds.Tables[2].Rows[0]["totalrate"].ToString());
                Double gainrate = Convert.ToDouble(ds.Tables[2].Rows[0]["gainrate"].ToString());
                Double ratediscoutn = 0;
                if (totalrate>0 && gainrate>0)
                {
                     ratediscoutn = (gainrate / totalrate) * 100;
                }
                
                if (ratediscoutn == 0)
                {
                    Star1.Visible = false;
                    Star2.Visible = false;
                    Star3.Visible = false;
                    Star4.Visible = false;
                    Star5.Visible = false;
                }
                else if(0< ratediscoutn && ratediscoutn <= 20)
                {
                    Star1.Visible = true;
                    Star2.Visible = false;
                    Star3.Visible = false;
                    Star4.Visible = false;
                    Star5.Visible = false;
                }
                else if (20 < ratediscoutn && ratediscoutn <= 40)
                {
                    Star1.Visible = true;
                    Star2.Visible = true;
                    Star3.Visible = false;
                    Star4.Visible = false;
                    Star5.Visible = false;
                }
                else if (40 < ratediscoutn && ratediscoutn <= 60)
                {
                    Star1.Visible = true;
                    Star2.Visible = true;
                    Star3.Visible = true;
                    Star4.Visible = false;
                    Star5.Visible = false;
                }
                else if (60 < ratediscoutn && ratediscoutn <= 80)
                {
                    Star1.Visible = true;
                    Star2.Visible = true;
                    Star3.Visible = true;
                    Star4.Visible = true;
                    Star5.Visible = false;
                }
                else if (80 < ratediscoutn && ratediscoutn <= 100)
                {
                    Star1.Visible = true;
                    Star2.Visible = true;
                    Star3.Visible = true;
                    Star4.Visible = true;
                    Star5.Visible = true;
                }

                Lblnoofreviews.Text = ds.Tables[3].Rows[0]["Noofreviews"].ToString() == "0" ? "" : ds.Tables[3].Rows[0]["Noofreviews"].ToString()+" reviews";
                lbldiscount.Text = "(-"+dt.Rows[0]["productdiscount"].ToString()+"%)";
                lblpriceafterdiscount.Text = dt.Rows[0]["Priceafterdiscount"].ToString();
                lblpricebeforediscount.Text = dt.Rows[0]["PricebeforeDiscount"].ToString();
                lbloffertype.Text = dt.Rows[0]["isfestiveoffer"].ToString()=="0"?"": dt.Rows[0]["isfestiveoffer"].ToString()=="1"?"Limited Time Offer": dt.Rows[0]["isfestiveoffer"].ToString()=="2"?"Festive Offer":"";
                if(dt.Rows[0]["returnday"].ToString()!="0")
                {
                    lblreturnorrplacement.Text = dt.Rows[0]["returnday"].ToString() + " Day Return";
                }
                else if(dt.Rows[0]["replacementday"].ToString() != "0")
                {
                    lblreturnorrplacement.Text = dt.Rows[0]["replacementday"].ToString() + " Day Replacement";
                }
                else
                {
                    lblreturnorrplacement.Text = "No Return";
                }

                lblisfreedeliveryornot.Text = dt.Rows[0]["deliveryprice"].ToString() == "0" ? "Free Delivery" : "₹"+dt.Rows[0]["deliveryprice"].ToString() + " Delivery Charge";
                lbliscod.Text = dt.Rows[0]["iscod"].ToString() == "0" ? "No COD" :"COD";
                if(ds.Tables[5].Rows.Count>0)
                {
                    lblsize.Text = ds.Tables[5].Rows[0]["sizename"].ToString();
                }
                else
                {
                    lblsize.Text = dt.Rows[0]["productsize"].ToString();
                }               
                
                lblcolor.Text = dt.Rows[0]["productcolor"].ToString();
                lblproductspecification.Text = dt.Rows[0]["productspecification"].ToString();
                lblproductdetails.Text = dt.Rows[0]["productdetail"].ToString();
                lblproductdescription.Text = dt.Rows[0]["productdescription"].ToString();
                HdnAvailablequantity.Value = dt.Rows[0]["Avl_Quantity"].ToString();
                if (dt.Rows[0]["productType"].ToString()=="CLOTHING")
                {
                    DataTable dts = product.Getprodutdetailsforsize(id,ref_id,lblsize.Text);
                    if(dts.Rows.Count>0)
                    {
                        HdnAvailablequantity.Value = dts.Rows[0]["Qty"].ToString();
                    }
                   
                }
                else if (dt.Rows[0]["productType"].ToString() == "FOOTWEAR")
                {
                    DataTable dts = product.Getprodutdetailsforsize(id, ref_id, lblsize.Text);
                    if (dts.Rows.Count > 0)
                    {
                        HdnAvailablequantity.Value = dts.Rows[0]["Qty"].ToString();
                    }

                }
                HdnDeliveryprice.Value = dt.Rows[0]["deliveryprice"].ToString();
                HdnDiscountpercentage.Value = dt.Rows[0]["productdiscount"].ToString();

                bindSimilardata(Convert.ToInt32(dt.Rows[0]["subcat_id"]), dt.Rows[0]["product_ref_id"].ToString());
            }

           
        }

        private void bindSimilardata(int subcatid,string productrefid)
        {
            Repeatersimilarproduct.DataSource= product.GetSimilardata(subcatid, productrefid);
            Repeatersimilarproduct.DataBind();
        }

        private void bindcomment(DataTable dt)
        {
            RepeaterComment.DataSource = dt;
            RepeaterComment.DataBind();
        }

        private void bindreferenceProducts(DataTable dt)
        {
            Repeaterrefproducts.DataSource = dt;
            Repeaterrefproducts.DataBind();
        }

        protected void RepeaterComment_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if(e.Item.ItemType==ListItemType.AlternatingItem || e.Item.ItemType==ListItemType.Item)
            {
                HiddenField hiddentrate = (HiddenField)e.Item.FindControl("Hiddenratecount");
                HiddenField hdnuerid = (HiddenField)e.Item.FindControl("userhdn");
                int ratecount = Convert.ToInt32(hiddentrate.Value);
                Label lblstar1 = (Label)e.Item.FindControl("cstar1");
                Label lblstar2 = (Label)e.Item.FindControl("cstar2");
                Label lblstar3 = (Label)e.Item.FindControl("cstar3");
                Label lblstar4 = (Label)e.Item.FindControl("cstar4");
                Label lblstar5 = (Label)e.Item.FindControl("cstar5");
                Label lblrating = (Label)e.Item.FindControl("editrating");
                LinkButton Deltebutton = (LinkButton)e.Item.FindControl("commentdel");
                lblrating.Visible = false;
                Deltebutton.Visible = false;
                string compareuserid = Session["UserLoginTrue"] == null ? "" : Session["UserLoginTrue"].ToString();
                if (hdnuerid.Value== compareuserid)
                {
                    lblrating.Visible = true;
                    Deltebutton.Visible = true;
                }
                if(ratecount==0)
                {
                    lblstar1.Visible = false;
                    lblstar2.Visible = false;
                    lblstar3.Visible = false;
                    lblstar4.Visible = false;
                    lblstar5.Visible = false;
                }
                else if(ratecount==1)
                {
                    lblstar1.Visible = true;
                    lblstar2.Visible = false;
                    lblstar3.Visible = false;
                    lblstar4.Visible = false;
                    lblstar5.Visible = false;
                }
                else if (ratecount==2)
                {
                    lblstar1.Visible = true;
                    lblstar2.Visible = true;
                    lblstar3.Visible = false;
                    lblstar4.Visible = false;
                    lblstar5.Visible = false;
                }
                else if (ratecount==3)
                {
                    lblstar1.Visible = true;
                    lblstar2.Visible = true;
                    lblstar3.Visible = true;
                    lblstar4.Visible = false;
                    lblstar5.Visible = false;
                }
                else if (ratecount ==4)
                {
                    lblstar1.Visible = true;
                    lblstar2.Visible = true;
                    lblstar3.Visible = true;
                    lblstar4.Visible = true;
                    lblstar5.Visible = false;
                }
                else if (ratecount ==5)
                {
                    lblstar1.Visible = true;
                    lblstar2.Visible = true;
                    lblstar3.Visible = true;
                    lblstar4.Visible = true;
                    lblstar5.Visible = true;
                }
            }
        }

        protected void BtnSaveComment_Click(object sender, EventArgs e)
        {
            if(Txtcomment.Text.Trim()=="")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "swal('Empty', 'Write Something','error')", true);
                return;
            }
            if (HiddenField1.Value == "")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "swal('Empty', 'Rate Something','error')", true);
                return;
            }
            double id = Convert.ToDouble(Request.QueryString["productid"].ToString());
            string ref_id = Request.QueryString["productrefid"].ToString();
            string userid = Session["UserLoginTrue"] == null ? "0" : Session["UserLoginTrue"].ToString();          
            DataTable dt = product.CheckifCommentExitst(userid, id, ref_id);
            if(dt.Rows.Count>0)
            {
                int i = product.commentupdate(userid, id, ref_id, Txtcomment.Text.Trim(), Convert.ToInt32(HiddenField1.Value));
                if (i > 0)
                {
                    BindAllData();
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "swal('Commented', 'Thanks For Your Review','success')", true);
                }
            }
            else
            {
                int i = product.commentinsert(userid, id, ref_id, Txtcomment.Text.Trim(), Convert.ToInt32(HiddenField1.Value));
                if (i > 0)
                {
                    BindAllData();
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "swal('Commented', 'Thanks For Your Review','success')", true);
                }
            }
        }

        private void Loginpanel()
        {
            double id = Convert.ToDouble(Request.QueryString["productid"].ToString());
            string ref_id = Request.QueryString["productrefid"].ToString();
            string userid = Session["UserLoginTrue"]==null?"0":Session["UserLoginTrue"].ToString();
            if (Session["UserLoginTrue"]==null)
            {
                Panel1.Visible = true;
                Panel2.Visible = false;
                Panel3.Visible = false;
            }
            else if(product.Commentrights(userid, id, ref_id).Rows.Count>0 && Session["UserLoginTrue"]!=null)
            {
                Panel1.Visible = false;
                Panel2.Visible = true;
                Panel3.Visible = false;
            }
            else
            {
                Panel1.Visible = false;
                Panel2.Visible = false;
                Panel3.Visible = true;
            }
        }

        protected void btnaddtocart_Click(object sender, EventArgs e)
        {
            try
            {
                if(Session["UserLoginTrue"]==null)
                {
                    if (Session["SellerLoggedintrue"]!=null)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "swal('Seller, 'Logoout as Seller !', 'error')", true);
                        return;
                    }
                    if (Session["isAdminid"] != null)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "swal('Seller, 'Logoout as Admin !', 'error')", true);
                        return;
                    }
                    Session["Redirecturl"] = HttpContext.Current.Request.Url.AbsoluteUri;
                    Response.Redirect("LoginForm.aspx");                   
                    return;
                }

                if(product.check_If_item_available_in_cart(Session["UserLoginTrue"].ToString(), Convert.ToDouble(Request.QueryString["productid"].ToString()), Request.QueryString["productrefid"].ToString()) ==true)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "swal('Already Available !', 'This Product is Already Available in your Cart !', 'info')", true);
                    return;
                }
                CartFields cart = new CartFields();
                cart.userid = Session["UserLoginTrue"].ToString();
                cart.productid = Convert.ToInt32(Request.QueryString["productid"].ToString());
                cart.productrefid = Request.QueryString["productrefid"].ToString();
                cart.Sellingprice=Convert.ToDouble(lblpriceafterdiscount.Text);
                cart.markedprice=Convert.ToDouble(lblpricebeforediscount.Text);
                cart.discountpercentage = Convert.ToInt32(HdnDiscountpercentage.Value); 
                cart.deliveryprice=Convert.ToDecimal(HdnDeliveryprice.Value);
                cart.PurchasedQuantity = Convert.ToInt32(Dropqty.SelectedItem.Text);
                cart.size = lblsize.Text;
                int i = product.AddTocart(cart); 
                if(i > 0)
                {
                    //ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "addedtocart();", true);
                    Response.Redirect(HttpContext.Current.Request.Url.AbsoluteUri);
                   
                }

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "swal('Exception Handling !', '" + ex.Message + "', 'error')", true);
            }
        }

        protected void btnbuynow_Click(object sender, EventArgs e)
        {
            try
            {
                if (Session["UserLoginTrue"] == null)
                {
                    Session["Redirecturl"] = HttpContext.Current.Request.Url.AbsoluteUri;
                    Response.Redirect("LoginForm.aspx");
                    return;
                }
                string finalsize = lblsize.Text.Trim();
                if(hdnsizevalue.Value!="")
                {
                    finalsize = hdnsizevalue.Value;
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
                dt.Columns.Add("colors");
                dt.Rows.Add(Session["UserLoginTrue"].ToString(), Request.QueryString["productid"].ToString(), Request.QueryString["productrefid"].ToString(), MainImage.ImageUrl,Dropqty.SelectedItem.Text,lbliscod.Text,(Convert.ToDouble(lblpriceafterdiscount.Text)*Convert.ToDouble(Dropqty.SelectedItem.Text)+Convert.ToDouble(HdnDeliveryprice.Value)),"Direct",Lblmainbrand, finalsize);
                Session["placeorderdata"] = dt;
                Response.Redirect("AddressSelectionPage.aspx");
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "swal('Exception Handling !', '" + ex.Message + "', 'error')", true);
            }
        }

        protected void Lnkbtnsize_Click(object sender, EventArgs e)
        {
            double id = Convert.ToDouble(Request.QueryString["productid"].ToString());
            string ref_id = Request.QueryString["productrefid"].ToString();
            DataTable dts = product.Getprodutdetailsforsize(id, ref_id, hdnsizevalue.Value);
           if(dts.Rows.Count>0)
            {
                HdnAvailablequantity.Value = dts.Rows[0]["Qty"].ToString();
                lblsize.Text = hdnsizevalue.Value;
            }
        }

        protected void btnaddtowhishlist_Click(object sender, EventArgs e)
        {
            if(Session["UserLoginTrue"]==null)
            {
                Session["Redirecturl"] = HttpContext.Current.Request.Url.AbsoluteUri;
                Response.Redirect("LoginForm.aspx");
                return;
            }

            string userid = Session["UserLoginTrue"].ToString();
            double productid = Convert.ToDouble(Request.QueryString["productid"].ToString());
            string productrefid = Request.QueryString["productrefid"].ToString();
            int isvailable = getWishlist();
             product.addTowhishlist(isvailable, userid, productid, productrefid);  //to add or delete product from datable
            if (isvailable == 1)
            {

                lblid.ForeColor = System.Drawing.Color.Gray;
            }
            else
            {

                lblid.ForeColor = System.Drawing.Color.Red;
              
            }


        }

        private int getWishlist()
        {
            string userid = Session["UserLoginTrue"].ToString();
            double productid = Convert.ToDouble(Request.QueryString["productid"].ToString());
            string productrefid = Request.QueryString["productrefid"].ToString();
            int isvailable = product.GetWhishlistTable(userid, productid, productrefid);
           
            return isvailable;
        }

        protected void commentdel_Click(object sender, EventArgs e)
        {
            RepeaterItem item = (sender as LinkButton).Parent as RepeaterItem;
            HiddenField productid = ((HiddenField)item.FindControl("productid")) as HiddenField;
            HiddenField productrefid = ((HiddenField)item.FindControl("productrefid")) as HiddenField;
            HiddenField userid = ((HiddenField)item.FindControl("userhdn")) as HiddenField;
            product.Delcommeent(userid.Value, Convert.ToDouble(productid.Value), productrefid.Value);
            BindAllData();
        }

        protected void btnpincodesearch_Click(object sender, EventArgs e)
        {
            try
            {
                String pincode = Txtcheckpincode.Text.Trim();
                var client = new RestSharp.RestClient("https://my.ithinklogistics.com/api_v3/pincode/check.json");
                var request = new RestRequest(Method.POST);
                request.AddHeader("cache-control", "no-cache");
                request.AddHeader("content-type", "application/json");
                request.AddParameter("application/json", "{\"data\":{\"pincode\":" + pincode + ",\"access_token\":\"9b2c8a088ee4e7eb03bcf781663b6fd0\",\"secret_key\":\"6244c53d36f4f07227b21d8b83c6debb\"}}\n", ParameterType.RequestBody);
                IRestResponse response = client.Execute(request);
                string sourse = response.Content.ToString();
                dynamic data = JObject.Parse(sourse);
                //lblpincodesearch.Text = (data.data).ToString();//["802222"].Delhivery.cod).ToString();
                if ((data.data[pincode].Delhivery.cod).ToString() == "Y" && (data.data[pincode].Delhivery.prepaid).ToString() == "Y" && (data.data[pincode].Delhivery.pickup).ToString() == "Y")
                {
                    lblpincodesearch.Text = "Delivery is Available and Will Deliver in 6-7 Days";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "deliveryplain();", true);
                    
                }
                else
                {
                    // lblpincodesearch.Text = "Sorry We Are Not Available Here yet !";
                    lblpincodesearch.Text = "Delivery is Available and Will Deliver in 6-7 Days";
                }
                // lblpincodesearch.Text = (data.data[pincode].Delhivery.cod).ToString()+" "+ (data.data[pincode].Delhivery.prepaid).ToString();
            }
            catch (Exception ex)
            {
                //lblpincodesearch.Text = "Sorry We Are Not Available Here yet !";
                lblpincodesearch.Text = "Delivery is Available and Will Deliver in 6-7 Days";
            }
           
        }

        



    }
}