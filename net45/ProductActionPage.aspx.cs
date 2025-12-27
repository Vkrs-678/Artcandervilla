using RazorpaySampleApp.Connections.Implimentations;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RazorpaySampleApp
{
    public partial class WebForm11 : System.Web.UI.Page
    {
        ProductListRepo product= new ProductListRepo();
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
           
            if (!IsPostBack) {
                bindproducts();
            }
        }

        private void bindproducts()
        {
            DataTable dt = product.GetproductsSellerwiese(Convert.ToInt32(Session["SellerLoggedintrue"].ToString()));
            RptrProducts.DataSource = dt;
            RptrProducts.DataBind();
        }

       

        protected void Lnkview_Click(object sender, EventArgs e)
        {
            RepeaterItem item = (sender as LinkButton).Parent as RepeaterItem;
            Label id = ((Label)item.FindControl("Label2")) as Label;
            DataTable dt = product.GetProductForview(Convert.ToDouble(id.Text),Convert.ToInt32(Session["SellerLoggedintrue"].ToString()));
            Rptrproductview.DataSource = dt;
            Rptrproductview.DataBind();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
            
        }

        protected void LnkDelete_Click(object sender, EventArgs e)
        {
            try
            {
                RepeaterItem item = (sender as LinkButton).Parent as RepeaterItem;
                Label id = ((Label)item.FindControl("Label2")) as Label;
                DataTable dtforimage = product.GetProductForview(Convert.ToDouble(id.Text), Convert.ToInt32(Session["SellerLoggedintrue"].ToString()));
                string image1 = Server.MapPath(dtforimage.Rows[0]["Image1"].ToString());
                string image2 = Server.MapPath(dtforimage.Rows[0]["Image2"].ToString());
                string image3 = Server.MapPath(dtforimage.Rows[0]["Image3"].ToString());
                string image4 = Server.MapPath(dtforimage.Rows[0]["Image4"].ToString());
                string image5 = Server.MapPath(dtforimage.Rows[0]["Image5"].ToString());
                
                int i = product.DeleteProductbyid(Convert.ToDouble(id.Text), "Delete");
                if (i > 0)
                {
                    if (File.Exists(image1))
                    {
                        File.Delete(image1);
                    }
                    if (File.Exists(image2))
                    {
                        File.Delete(image2);
                    }
                    if (File.Exists(image3))
                    {
                        File.Delete(image3);
                    }
                    if (File.Exists(image4))
                    {
                        File.Delete(image4);
                    }
                    if (File.Exists(image5))
                    {
                        File.Delete(image5);
                    }
                    bindproducts();
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "swal('Deleted !', 'Product Deleted Successfully','Success')", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "swal('Deleted !', 'Product Not Deleted Successfully','error')", true);
                }
            }
            catch(Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "swal('Correct Value', '" + ex.Message + "','error')", true);
            }
           
        }

        protected void LnkDeactivate_Click(object sender, EventArgs e)
        {
            try
            {
                RepeaterItem item = (sender as LinkButton).Parent as RepeaterItem;
                Label id = ((Label)item.FindControl("Label2")) as Label;

                int i = product.DeleteProductbyid(Convert.ToDouble(id.Text), "Deactivate");
                if (i > 0)
                {
                    bindproducts();
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "swal('Deactivated !', 'Product Deactivated Successfully','success')", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "swal('Deactivated !', 'Product Not Deactivated','error')", true);
                }
            }
            catch(Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "swal('Correct Value', '" + ex.Message + "','error')", true);
            }
        }

        protected void LnkOffer_Click(object sender, EventArgs e)
        {

            RepeaterItem item = (sender as LinkButton).Parent as RepeaterItem;
            Label id = ((Label)item.FindControl("Label2")) as Label;
            Hiddenproductid.Value=id.Text;
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModalforOffer();", true);
        }

        protected void Lnkoffer_Click1(object sender, EventArgs e)
        {
            if(RdoFestive.Checked==false && RdoLimitedOffer.Checked==false && RdoNoOffer.Checked==false)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "swal('Information !', 'Select a Offer Type','error')", true);
                return;
            }
            string offer = string.Empty;

            if(RdoFestive.Checked)
            {
                offer = "Festive";
            }
            else if(RdoLimitedOffer.Checked)
            {
                offer = "Limited";
            }
            else
            {
                offer = "Nooffer";
            }
            int i = product.updateoffer(Convert.ToDouble(Hiddenproductid.Value), offer);
            if(i>0)
            {
                bindproducts();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "swal('Updated !', 'Offer Update Successfully','success')", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "swal('Updated !', 'Offer Not Update','error')", true);
            }
                
        }
    }
}