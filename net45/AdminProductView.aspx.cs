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
    public partial class WebForm13 : System.Web.UI.Page
    {
        AdminDashbordRepo admin = new AdminDashbordRepo();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["isAdminid"] == null)
                {
                    Response.Redirect("Default.aspx");
                }
                else
                {
                    Session["isAdminid"] = Session["isAdminid"].ToString();
                }

                bindproducts();
                bindpending();
            }

        }

        private void bindproducts()
        {
            DataTable dt = admin.GetAllProducts(0);
            RptrProducts.DataSource = dt;
            RptrProducts.DataBind();
        }

        private void bindpending()
        {
            DataTable dt = admin.GetpendingproductforApproval(0); //0 parameter will give count else will give table;
            Lblpendingcount.Text = dt.Rows[0]["pending"].ToString();
        }

        protected void LnkPendingforapproval_Click(object sender, EventArgs e)
        {
            DataTable dt = admin.GetpendingproductforApproval(1);
            RptrProducts.DataSource = dt;
            RptrProducts.DataBind();
        }

        protected void Lnkview_Click(object sender, EventArgs e)
        {
            RepeaterItem item = (sender as LinkButton).Parent as RepeaterItem;
            Label id = ((Label)item.FindControl("Label2")) as Label;
            Response.Redirect("ApproveProductByAdmin.aspx?id=" + id.Text + "");
           
        }
    }
}