using RazorpaySampleApp.Connections.Implimentations;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RazorpaySampleApp
{
    public partial class WebForm9 : System.Web.UI.Page
    {
        AdminDashbordRepo adminrepo= new AdminDashbordRepo();
        ProductListRepo product= new ProductListRepo();
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
                BindRepeater();
            }
        }
        private void BindRepeater()
        {
           DataTable dt= adminrepo.GetMainCat(0);
            RptrMainCat.DataSource = dt;
            RptrMainCat.DataBind();

            DataTable dtsub= adminrepo.GetSubCat(0);
            RptrSubcategory.DataSource = dtsub;
            RptrSubcategory.DataBind();


            DropMainCat.DataSource = dt;
            DropMainCat.DataTextField = "Catname";
            DropMainCat.DataValueField = "id";
            DropMainCat.DataBind();
            DropMainCat.Items.Insert(0, new ListItem("--Select---", "0"));



        }

        protected void LnkAddCategoory_Click(object sender, EventArgs e)
        {
            try
            {
                if(FileMainImage.HasFile)
                {
                    String Timestamp = DateTime.Now.ToString("yyyyMMddHHss");
                    string path = Path.Combine(Server.MapPath("~/Images/MainCatImages/"), Timestamp+"_"+FileMainImage.FileName);
                    string pathsave = Path.Combine("~/Images/MainCatImages/", Timestamp + "_" + FileMainImage.FileName);
                    FileMainImage.SaveAs(path);
                   int i= adminrepo.AddMainCat(TxtMainCategory.Text.Trim().ToUpper(), pathsave);
                    if(i>0)
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", " swal('Added', 'Category Added Successfully, 'success')", true);
                        TxtMainCategory.Text = "";
                        BindRepeater();
                    }
                    else
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", " swal('Not Added', 'Category Not Added, 'error')", true);
                    }
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", " swal('Image Not Added', 'Image is Missing', 'error')", true);
                }
              
            }
            catch(Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", " swal('Exceptional Error !', '" + ex.Message + "', 'error')", true);
            }
        }

        protected void LinDelete_Click(object sender, EventArgs e)
        {
            RepeaterItem item = (sender as LinkButton).Parent as RepeaterItem;
            Label id = ((Label)item.FindControl("lblMainCatid")) as Label;
            DataTable dtmain = adminrepo.GetMainCat(Convert.ToDouble(id.Text));
            DataTable dt = adminrepo.GetSubCatByMaincatid(Convert.ToDouble(id.Text));
            DataTable dtproduct = adminrepo.GetProductBymaincatid(Convert.ToDouble(id.Text));
            int i = 0;
            if (dt.Rows.Count>0)
            {
                 i = adminrepo.DeletSubCat(0, Convert.ToDouble(id.Text));
                if (i > 0)
                {
                    string path = string.Empty;
                    if (dt.Rows[0]["CatImage"] != null)
                    {
                        path = dt.Rows[0]["CatImage"].ToString();
                    }

                    if (File.Exists(path))
                    {
                        File.Delete(path);
                    }
                    foreach (DataRow row in dtproduct.Rows)
                    {
                        product.DeleteProductbyid(Convert.ToDouble(row["product_id"]), "Delete");
                    }
                   
                    i = adminrepo.DeletMainCat(Convert.ToDouble(id.Text));
                }
            }
            else
            {
                string path = Server.MapPath(dtmain.Rows[0]["CatImage"].ToString());
                if (File.Exists(path))
                {
                    File.Delete(path);
                }
                foreach (DataRow row in dtproduct.Rows)
                {
                    product.DeleteProductbyid(Convert.ToDouble(row["product_id"]), "Delete");
                }
                i = adminrepo.DeletMainCat(Convert.ToDouble(id.Text));
            }
           
             
            if(i>0)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", " swal('Cat Deleted ', 'Category Deleted Successfully, 'success')", true);
                BindRepeater();
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", " swal('Not Deleted', 'Category Not Deleted, 'error')", true);
            }
        }

        protected void LnkAddSub_Click(object sender, EventArgs e)
        {
            if(Convert.ToInt64(DropMainCat.SelectedValue.ToString())!=0)
            {
                int i = adminrepo.AddSubCat(TxtSubCat.Text.Trim().ToUpper(), Convert.ToDouble(DropMainCat.SelectedValue.ToString()));
                if (i > 0)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", " swal('Subcategory Added ', 'Subcategory Added Successfully, 'success')", true);
                    BindRepeater();
                    TxtSubCat.Text = "";
                    LblDropAlert.Visible = false;
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", " swal('Not Subcategory Added', 'Subcategory Not Added, 'error')", true);
                }
            }
            else
            {
                LblDropAlert.Visible = true;
            }
           
        }

        protected void LinDeletesub_Click(object sender, EventArgs e)
        {
            RepeaterItem item = (sender as LinkButton).Parent as RepeaterItem;
            Label id = ((Label)item.FindControl("lblSubCatid")) as Label;
            DataTable dtproduct = adminrepo.GetProductBysubcatid(Convert.ToDouble(id.Text));
            foreach (DataRow row in dtproduct.Rows)
            {
                product.DeleteProductbyid(Convert.ToDouble(row["product_id"]), "Delete");
            }
            int i = adminrepo.DeletSubCat(Convert.ToDouble(id.Text));
            if (i > 0)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", " swal('Cat Deleted ', 'Category Deleted Successfully, 'success')", true);
                BindRepeater();
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", " swal('Not Deleted', 'Category Not Deleted, 'error')", true);
            }
        }
    }
}