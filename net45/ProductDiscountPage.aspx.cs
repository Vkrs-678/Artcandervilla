using iTextSharp.text.pdf;
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
    public partial class WebForm12 : System.Web.UI.Page
    {
        ProductListRepo product = new ProductListRepo();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["SellerLoggedintrue"] == null)
            {
                Response.Redirect("Default.aspx");
            }
            else
            {
                Session["SellerLoggedintrue"] = Session["SellerLoggedintrue"].ToString();
            }
            if (!IsPostBack)
            {

               
                maincat();
                Suubcat();
                BindProduct();
            }
        }

        private void BindProduct()
        {
            Rptrproduct.DataSource = product.GetListofProductForQuantity(Convert.ToInt32(Session["SellerLoggedintrue"].ToString()));
            Rptrproduct.DataBind();
        }

        private void maincat()
        {
            DataTable dt= product.GetMaincatForofferSellerWise(Convert.ToInt32(Session["SellerLoggedintrue"].ToString()), "maincat");
            DropdownMaincat.DataSource = dt;
            DropdownMaincat.DataValueField = "id";
            DropdownMaincat.DataTextField = "Catname";
            DropdownMaincat.DataBind();
            DropdownMaincat.Items.Insert(0, new ListItem("---Select---", "0"));
        }

        private void Suubcat()
        {
            DataTable dt = product.GetMaincatForofferSellerWise(Convert.ToInt32(Session["SellerLoggedintrue"].ToString()), "subcat");
            DropdownSubcat.DataSource = dt;
            DropdownSubcat.DataValueField = "id";
            DropdownSubcat.DataTextField = "SubcatName";
            DropdownSubcat.DataBind();
            DropdownSubcat.Items.Insert(0, new ListItem("---Select---", "0"));
        }

        protected void LnkMaindiscount_Click(object sender, EventArgs e)
        {
            if (DropdownMaincat.SelectedItem.Value == "0")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "swal('Not Update', 'Select maincategory','error')", true);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "offermaincat();", true);
                return;
            }
            else if (Txtmaincatdiscount.Text == "")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "swal('Not Update', 'Enter Discountpercentage','error')", true);
                return;
            }
            int i = product.Discountupdate(Convert.ToDouble(DropdownMaincat.SelectedItem.Value),0,"", "Maincat", Convert.ToInt32(Txtmaincatdiscount.Text.Trim()));
            if(i>0)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "swal('Offer Update', 'Offer Updated Maincategory Wise','success')", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "swal('Not Update', 'Offer Not Updated','error')", true);
            }
           
        }

        protected void LnkSubDicount_Click(object sender, EventArgs e)
        {
            if (DropdownSubcat.SelectedItem.Value == "0")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "swal('Not Update', 'Select Subcategory','error')", true);
                return;
            }
            else if (Txtsubcatdiscount.Text == "")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "swal('Not Update', 'Enter Discountpercentage','error')", true);
                return;
            }
            int i = product.Discountupdate(0,Convert.ToDouble(DropdownSubcat.SelectedItem.Value),"", "Subcat", Convert.ToInt32(Txtsubcatdiscount.Text.Trim()));
            if (i > 0)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "swal('Offer Update', 'Offer Updated Subcategory Wise','success')", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "swal('Not Update', 'Offer Not Updated','error')", true);
            }
        }

        protected void Lnkproductwisediscount_Click(object sender, EventArgs e)
        {
            if(Txtrefid.Text=="")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "swal('Not Update', 'Enter Ref Number','error')", true);
                return;
            }
            else if(TxtrefidDiscount.Text=="")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "swal('Not Update', 'Enter Discountpercentage','error')", true);
                return;
            }
            int i = product.Discountupdate(0,0,Txtrefid.Text.Trim(), "Product", Convert.ToInt32(TxtrefidDiscount.Text.Trim()));
            if (i > 0)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "swal('Offer Update', 'Offer Updated Product Wise','success')", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "swal('Not Update', 'Offer Not Updated','error')", true);
            }
        }

        private void PanelSelection(Double productid)
        {
            DataSet ds = product.GetproductforUpdate(productid);

            TxtKeyword.Text = ds.Tables[0].Rows[0]["productkeyword"].ToString();
            TxtOthersQuntity.Text = ds.Tables[0].Rows[0]["Avl_Quantity"].ToString();
            GridOfProducts.Visible = false;
            PanelKeyword.Visible = true;


            if (ds.Tables[0].Rows[0]["productType"].ToString() == "CLOTHING")
            {
                TxtClothSmall.Text = ds.Tables[1].Rows[0]["Qty"].ToString();
                TxtClothMedium.Text = ds.Tables[1].Rows[1]["Qty"].ToString();
                TxtClothlarge.Text = ds.Tables[1].Rows[2]["Qty"].ToString();
                TxtClothxl.Text = ds.Tables[1].Rows[3]["Qty"].ToString();
                TxtClothxxl.Text = ds.Tables[1].Rows[4]["Qty"].ToString();
                PanelCloth.Visible = true;

            }
            else if (ds.Tables[0].Rows[0]["productType"].ToString() == "FOOTWEAR")
            {
                Txtfoot4.Text = ds.Tables[1].Rows[0]["Qty"].ToString();
                Txtfoot5.Text = ds.Tables[1].Rows[1]["Qty"].ToString();
                Txtfoot6.Text = ds.Tables[1].Rows[2]["Qty"].ToString();
                Txtfoot7.Text = ds.Tables[1].Rows[3]["Qty"].ToString();
                Txtfoot8.Text = ds.Tables[1].Rows[4]["Qty"].ToString();
                Txtfoot9.Text = ds.Tables[1].Rows[5]["Qty"].ToString();
                Txtfoot10.Text = ds.Tables[1].Rows[6]["Qty"].ToString();
                Txtfoot11.Text = ds.Tables[1].Rows[7]["Qty"].ToString();
                Txtfoot12.Text = ds.Tables[1].Rows[8]["Qty"].ToString();
                PanelFootwear.Visible = true;
            }
            else
            {
                PanelOther.Visible = true;
            }
        }

        protected void LnkUpdate_Click(object sender, EventArgs e)
        {
            RepeaterItem item = (sender as LinkButton).Parent as RepeaterItem;
            Label lblproductid=((Label)item.FindControl("lblproductid")) as Label;
            Productid.Value = lblproductid.Text;
            PanelSelection(Convert.ToDouble(lblproductid.Text));
        }

        protected void LnkBack_Click(object sender, EventArgs e)
        {
            GridOfProducts.Visible = true;
            PanelKeyword.Visible = false;
            PanelCloth.Visible = false;
            PanelFootwear.Visible = false;
            PanelOther.Visible = false;
        }

        protected void LnkUpdateKeyword_Click(object sender, EventArgs e)
        {
            int i = product.Updatekeyword(Convert.ToDouble(Productid.Value), TxtKeyword.Text.Trim().ToUpper(), Convert.ToInt32(TxtOthersQuntity.Text.Trim()));
            if(i>0)
            {
                PanelSelection(Convert.ToDouble(Productid.Value));
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "swal('Updated', 'KeywordUpdated','success')", true);
            }
        }

        protected void LnkupdateClothing_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("productid");
            dt.Columns.Add("size");
            dt.Columns.Add("qty");
            dt.Rows.Add(Productid.Value, "S", TxtClothSmall.Text.Trim());
            dt.Rows.Add(Productid.Value, "M", TxtClothMedium.Text.Trim());
            dt.Rows.Add(Productid.Value, "L", TxtClothlarge.Text.Trim());
            dt.Rows.Add(Productid.Value, "XL", TxtClothxl.Text.Trim());
            dt.Rows.Add(Productid.Value, "XXL", TxtClothxxl.Text.Trim());
            int totalavalquanity = (Convert.ToInt32(TxtClothSmall.Text.Trim()) + Convert.ToInt32(TxtClothMedium.Text.Trim()) + Convert.ToInt32(TxtClothlarge.Text.Trim()) + Convert.ToInt32(TxtClothxl.Text.Trim()) + Convert.ToInt32(TxtClothxxl.Text.Trim()));
            foreach(DataRow row in dt.Rows)
            {
                product.UpdatesizeTable(Convert.ToDouble(row["productid"]), row["size"].ToString(), Convert.ToInt32(row["qty"].ToString()));
            }
            product.Updatekeyword(Convert.ToDouble(Productid.Value), TxtKeyword.Text.Trim().ToUpper(), totalavalquanity);
            PanelSelection(Convert.ToDouble(Productid.Value));
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "swal('Updated', 'Quantity Updated','success')", true);
        }

        protected void LnkupdateFootwear_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("productid");
            dt.Columns.Add("size");
            dt.Columns.Add("qty");
            dt.Rows.Add(Productid.Value, "4", Txtfoot4.Text.Trim());
            dt.Rows.Add(Productid.Value, "5", Txtfoot5.Text.Trim());
            dt.Rows.Add(Productid.Value, "6", Txtfoot6.Text.Trim());
            dt.Rows.Add(Productid.Value, "7", Txtfoot7.Text.Trim());
            dt.Rows.Add(Productid.Value, "8", Txtfoot8.Text.Trim());
            dt.Rows.Add(Productid.Value, "9", Txtfoot9.Text.Trim());
            dt.Rows.Add(Productid.Value, "10", Txtfoot10.Text.Trim());
            dt.Rows.Add(Productid.Value, "11", Txtfoot11.Text.Trim());
            dt.Rows.Add(Productid.Value, "12", Txtfoot12.Text.Trim());
            int totalavalquanity = (Convert.ToInt32(Txtfoot4.Text.Trim()) + Convert.ToInt32(Txtfoot5.Text.Trim()) + Convert.ToInt32(Txtfoot6.Text.Trim()) + Convert.ToInt32(Txtfoot7.Text.Trim()) + Convert.ToInt32(Txtfoot8.Text.Trim()) + +Convert.ToInt32(Txtfoot9.Text.Trim()) + +Convert.ToInt32(Txtfoot10.Text.Trim()) + +Convert.ToInt32(Txtfoot11.Text.Trim()) + +Convert.ToInt32(Txtfoot12.Text.Trim()));
            foreach (DataRow row in dt.Rows)
            {
                product.UpdatesizeTable(Convert.ToDouble(row["productid"]), row["size"].ToString(), Convert.ToInt32(row["qty"].ToString()));
            }
            product.Updatekeyword(Convert.ToDouble(Productid.Value), TxtKeyword.Text.Trim().ToUpper(), totalavalquanity);
            PanelSelection(Convert.ToDouble(Productid.Value));
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "swal('Updated', 'Quantity Updated','success')", true);
        }
    }
}