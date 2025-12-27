using Org.BouncyCastle.Asn1.Ocsp;
using RazorpaySampleApp.Connections.Implimentations;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http.Headers;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RazorpaySampleApp
{
    public partial class WebForm15 : System.Web.UI.Page
    {
        ProductListRepo product = new ProductListRepo();
        int top = 0,top1=50;
        string userid = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                top = 20;
                ViewState["num"] = top;
                bindDaata(top);
            }
            
        }

        public void bindDaata()
        {
            userid = Session["UserLoginTrue"] == null ? "" : Session["UserLoginTrue"].ToString();
            if (Request.QueryString["subcatid"]!=null)
            {
                string id = Request.QueryString["subcatid"].ToString().Trim();
                DataTable dt = product.GetproductforGridviewSubcats(top1, Convert.ToDouble(id), "NO", "NO", "NO", "NO", userid);
                filterProduct(dt);
            }
            else if (Request.QueryString["searchkey"]!=null)
            {
                string id = Request.QueryString["searchkey"].ToString().Trim();
                DataTable dt = product.GetproductforGridviewSearch(top1, id, "NO", "NO", "NO", "NO", userid);
                filterProduct(dt);
            }
            else
            {
                DataTable dt = product.GetproductforGridviewa(top1, "NO", "NO", "NO", "NO", userid);
                filterProduct(dt);
            }
           
        }

        public void bindDaata(int newtop)
        {
            userid = Session["UserLoginTrue"] == null ? "" : Session["UserLoginTrue"].ToString();
            if (Request.QueryString["subcatid"] != null)
            {
                string id = Request.QueryString["subcatid"].ToString().Trim();
                DataTable dt = product.GetproductforGridviewSubcats(newtop, Convert.ToDouble(id), "NO", "NO", "NO", "NO", userid);
                filterProduct(dt);
            }
            else if (Request.QueryString["searchkey"] != null)
            {
                string id = Request.QueryString["searchkey"].ToString().Trim();
                DataTable dt = product.GetproductforGridviewSearch(newtop, id, "NO", "NO", "NO", "NO", userid);
                filterProduct(dt);
            }
            else if (Request.QueryString["mainid"] != null)
            {
                string id = Request.QueryString["mainid"].ToString().Trim();
                DataTable dt = product.GetproductforGridviewmaincat(newtop, Convert.ToDouble(id), "NO", "NO", "NO", "NO", userid);
                filterProduct(dt);
            }
            else
            {
                DataTable dt = product.GetproductforGridviewa(newtop, "NO", "NO", "NO", "NO", userid);
                filterProduct(dt);
            }

        }

        public void bindataonsort()
        {
            userid = Session["UserLoginTrue"] == null ? "" : Session["UserLoginTrue"].ToString();
            if (Rdodiscount.Checked==true)
            {
                if (Request.QueryString["subcatid"] != null)
                {
                    string id = Request.QueryString["subcatid"].ToString().Trim();
                    DataTable dt = product.GetproductforGridviewSubcats(top1, Convert.ToDouble(id),"YES","YES", "NO", "NO", userid);
                    filterProduct(dt);
                }
                else if (Request.QueryString["searchkey"] != null)
                {
                    string id = Request.QueryString["searchkey"].ToString().Trim();
                    DataTable dt = product.GetproductforGridviewSearch(top1, id, "YES", "YES", "NO", "NO", userid);
                    filterProduct(dt);
                }
                else
                {
                    DataTable dt = product.GetproductforGridviewa(top1, "YES", "YES", "NO", "NO", userid);
                    filterProduct(dt);
                }
            }
            else if(RdoHightoLow.Checked == true)
            {
                if (Request.QueryString["subcatid"] != null)
                {
                    string id = Request.QueryString["subcatid"].ToString().Trim();
                    DataTable dt = product.GetproductforGridviewSubcats(top1, Convert.ToDouble(id), "YES","NO","YES","NO", userid);
                    filterProduct(dt);
                }
                else if (Request.QueryString["searchkey"] != null)
                {
                    string id = Request.QueryString["searchkey"].ToString().Trim();
                    DataTable dt = product.GetproductforGridviewSearch(top1, id, "YES", "NO", "YES", "NO", userid);
                    filterProduct(dt);
                }
                else
                {
                    DataTable dt = product.GetproductforGridviewa(top1, "YES", "NO", "YES", "NO", userid);
                    filterProduct(dt);
                }
            }
            else if(RdoLowtoHigh.Checked==true)
            {
                if (Request.QueryString["subcatid"] != null)
                {
                    string id = Request.QueryString["subcatid"].ToString().Trim();
                    DataTable dt = product.GetproductforGridviewSubcats(top1, Convert.ToDouble(id), "YES", "NO", "NO", "YES", userid);
                    filterProduct(dt);
                }
                else if (Request.QueryString["searchkey"] != null)
                {
                    string id = Request.QueryString["searchkey"].ToString().Trim();
                    DataTable dt = product.GetproductforGridviewSearch(top1, id, "YES", "NO", "NO", "YES", userid);
                    filterProduct(dt);
                }
                else
                {
                    DataTable dt = product.GetproductforGridviewa(top1, "YES", "NO", "NO", "YES", userid);
                    filterProduct(dt);
                }
            }
            else
            {
                bindDaata();
            }
           
        }


        public void bindataonsort(int newtop)
        {
            userid = Session["UserLoginTrue"] == null ? "" : Session["UserLoginTrue"].ToString();
            if (Rdodiscount.Checked == true)
            {
                if (Request.QueryString["subcatid"] != null)
                {
                    string id = Request.QueryString["subcatid"].ToString().Trim();
                    DataTable dt = product.GetproductforGridviewSubcats(newtop, Convert.ToDouble(id), "YES", "YES", "NO", "NO", userid);
                    filterProduct(dt);
                }
                else if (Request.QueryString["searchkey"] != null)
                {
                    string id = Request.QueryString["searchkey"].ToString().Trim();
                    DataTable dt = product.GetproductforGridviewSearch(newtop, id, "YES", "YES", "NO", "NO", userid);
                    filterProduct(dt);
                }
                else if (Request.QueryString["mainid"] != null)
                {
                    string id = Request.QueryString["mainid"].ToString().Trim();
                    DataTable dt = product.GetproductforGridviewmaincat(newtop, Convert.ToDouble(id), "YES", "YES", "NO", "NO", userid);
                    filterProduct(dt);
                }
                else
                {
                    DataTable dt = product.GetproductforGridviewa(newtop, "YES", "YES", "NO", "NO", userid);
                    filterProduct(dt);
                }
            }
            else if (RdoHightoLow.Checked == true)
            {
                if (Request.QueryString["subcatid"] != null)
                {
                    string id = Request.QueryString["subcatid"].ToString().Trim();
                    DataTable dt = product.GetproductforGridviewSubcats(newtop, Convert.ToDouble(id), "YES", "NO", "YES", "NO", userid);
                    filterProduct(dt);
                }
                else if (Request.QueryString["searchkey"] != null)
                {
                    string id = Request.QueryString["searchkey"].ToString().Trim();
                    DataTable dt = product.GetproductforGridviewSearch(newtop, id, "YES", "NO", "YES", "NO", userid);
                    filterProduct(dt);
                }
                else if (Request.QueryString["mainid"] != null)
                {
                    string id = Request.QueryString["mainid"].ToString().Trim();
                    DataTable dt = product.GetproductforGridviewmaincat(newtop, Convert.ToDouble(id), "YES", "NO", "YES", "NO", userid);
                    filterProduct(dt);
                }
                else
                {
                    DataTable dt = product.GetproductforGridviewa(newtop, "YES", "NO", "YES", "NO", userid);
                    filterProduct(dt);
                }
            }
            else if (RdoLowtoHigh.Checked == true)
            {
                if (Request.QueryString["subcatid"] != null)
                {
                    string id = Request.QueryString["subcatid"].ToString().Trim();
                    DataTable dt = product.GetproductforGridviewSubcats(newtop, Convert.ToDouble(id), "YES", "NO", "NO", "YES", userid);
                    filterProduct(dt);
                }
                else if (Request.QueryString["searchkey"] != null)
                {
                    string id = Request.QueryString["searchkey"].ToString().Trim();
                    DataTable dt = product.GetproductforGridviewSearch(newtop, id, "YES", "NO", "NO", "YES", userid);
                    filterProduct(dt);
                }
                else if (Request.QueryString["mainid"] != null)
                {
                    string id = Request.QueryString["mainid"].ToString().Trim();
                    DataTable dt = product.GetproductforGridviewmaincat(newtop, Convert.ToDouble(id), "YES", "NO", "NO", "YES", userid);
                    filterProduct(dt);
                }
                else
                {
                    DataTable dt = product.GetproductforGridviewa(newtop, "YES", "NO", "NO", "YES", userid);
                    filterProduct(dt);
                }
            }
            else
            {
                bindDaata(newtop);
            }

        }

        protected void Rptrimage_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {

            if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
            {
                HiddenField totalrate = (HiddenField)e.Item.FindControl("HdnTotalrate");
                HiddenField gainrate = (HiddenField)e.Item.FindControl("Hdngainrate");
                HiddenField productrefid = (HiddenField)e.Item.FindControl("hdnproductrefid");
                HiddenField productrid = (HiddenField)e.Item.FindControl("hdnproductid");
                HiddenField addedwishlistvalue = (HiddenField)e.Item.FindControl("hdbaddedwishlist");
                Repeater Repeatersubproduct = (Repeater)e.Item.FindControl("Repeatersubproduct");
                Label lblcommentcount = (Label)e.Item.FindControl("Label13");
                Label star1 = (Label)e.Item.FindControl("Label7");
                Label star2 = (Label)e.Item.FindControl("Label8");
                Label star3 = (Label)e.Item.FindControl("Label9");
                Label star4 = (Label)e.Item.FindControl("Label10");
                Label star5 = (Label)e.Item.FindControl("Label11");
                Label isAddedtowishlist = (Label)e.Item.FindControl("lblisAddedtowhishlist");
                Label totalcolor = (Label)e.Item.FindControl("totalcolors");
                
                int availabcolors = product.Getproductavailablelist(productrefid.Value).Rows.Count;                
                totalcolor.Text = "";
               
                if (availabcolors>1)
                {
                    totalcolor.Text = "More Colors (" +(availabcolors-1).ToString() + ")";
                    
                  
                }

                if(addedwishlistvalue.Value!="0")
                {
                    isAddedtowishlist.Visible = true;
                }
                else
                {
                    isAddedtowishlist.Visible = false;
                }
               

                if (lblcommentcount.Text=="(0)")
                {
                    lblcommentcount.Visible = false;
                }
                Double starpercentage = 0;
                Double totalr = Convert.ToDouble(totalrate.Value);
                Double gainr = Convert.ToDouble(gainrate.Value);

                if(totalr>0 && gainr>0)
                {
                    starpercentage = gainr / totalr * 100;
                }

                if(starpercentage==0)
                {
                    star1.Visible = false;
                    star2.Visible = false;
                    star3.Visible = false;
                    star4.Visible = false;
                    star5.Visible = false;
                }
                else if(starpercentage>0 && starpercentage<=20)
                {
                    star1.Visible = true;
                    star2.Visible = false;
                    star3.Visible = false;
                    star4.Visible = false;
                    star5.Visible = false;
                }
                else if (starpercentage > 20 && starpercentage <= 40)
                {
                    star1.Visible = true;
                    star2.Visible = true;
                    star3.Visible = false;
                    star4.Visible = false;
                    star5.Visible = false;
                }
                else if (starpercentage > 40 && starpercentage <= 60)
                {
                    star1.Visible = true;
                    star2.Visible = true;
                    star3.Visible = true;
                    star4.Visible = false;
                    star5.Visible = false;
                }
                else if (starpercentage > 60 && starpercentage <= 80)
                {
                    star1.Visible = true;
                    star2.Visible = true;
                    star3.Visible = true;
                    star4.Visible = true;
                    star5.Visible = false;
                }
                else if (starpercentage > 80 && starpercentage <= 100)
                {
                    star1.Visible = true;
                    star2.Visible = true;
                    star3.Visible = true;
                    star4.Visible = true;
                    star5.Visible = true;
                }

            }
        }

        protected void LnkApply_Click(object sender, EventArgs e)
        {
            bindataonsort(Convert.ToInt32(ViewState["num"]));
        }

       

        protected void Btnloadmore_Click(object sender, EventArgs e)
        {
            int newtop = Convert.ToInt32(ViewState["num"]) + 20;
            bindataonsort(newtop);
            ViewState["num"] = newtop;

        }

        private void filterProduct(DataTable dt)
        {
            DataTable dtfiltered = new DataTable();           
            dtfiltered.Columns.Add("product_id");
            dtfiltered.Columns.Add("product_ref_id");
            dtfiltered.Columns.Add("productbrand");
            dtfiltered.Columns.Add("productname");
            dtfiltered.Columns.Add("originalprice");
            dtfiltered.Columns.Add("productdiscount");
            dtfiltered.Columns.Add("finaprice");
            dtfiltered.Columns.Add("image1");
            dtfiltered.Columns.Add("image2");
            dtfiltered.Columns.Add("image3");
            dtfiltered.Columns.Add("image4");
            dtfiltered.Columns.Add("image5");
            dtfiltered.Columns.Add("isfestiveoffer");
            dtfiltered.Columns.Add("comments");
            dtfiltered.Columns.Add("totalrate");
            dtfiltered.Columns.Add("gainrate");        
            dtfiltered.Columns.Add("wishlist");        
            int i = 0;                     
            
            foreach(DataRow rwo in dt.Rows)
            {
                if(i!=0)
                {
                    if (iseXists(dtfiltered, rwo["product_ref_id"].ToString()) ==false)
                    {
                        
                        dtfiltered.Rows.Add(rwo["product_id"], rwo["product_ref_id"], rwo["productbrand"], rwo["productname"], rwo["originalprice"], rwo["productdiscount"], rwo["finaprice"],
                        rwo["image1"], rwo["image2"], rwo["image3"], rwo["image4"], rwo["image5"], rwo["isfestiveoffer"], rwo["comments"], rwo["totalrate"],
                        rwo["gainrate"], rwo["wishlist"]);
                    }
                }
                else
                {
                    
                    dtfiltered.Rows.Add(rwo["product_id"], rwo["product_ref_id"], rwo["productbrand"], rwo["productname"], rwo["originalprice"], rwo["productdiscount"], rwo["finaprice"],
                        rwo["image1"], rwo["image2"], rwo["image3"], rwo["image4"], rwo["image5"], rwo["isfestiveoffer"], rwo["comments"], rwo["totalrate"],
                        rwo["gainrate"], rwo["wishlist"]);
                }
                i++;
            }

            Rptrimage.DataSource = dt;//dtfiltered;
            Rptrimage.DataBind();
        }

        private Boolean iseXists(DataTable dt,string productrefid)
        {
            Boolean f=false;
            foreach(DataRow row in dt.Rows)
            {
                if (row["product_ref_id"].ToString() == productrefid)
                {
                    f= true;
                    break;
                }
                    
            }

            return f;

        }
    }
}