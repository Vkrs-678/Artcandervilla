using RazorpaySampleApp.Connections.Implimentations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RazorpaySampleApp
{
    public partial class WebForm24 : System.Web.UI.Page
    {
        AdminDashbordRepo  admin = new AdminDashbordRepo();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["isAdminid"] == null)
            {
                Response.Redirect("Default.aspx");
            }
            else
            {
                Session["isAdminid"] = Session["isAdminid"].ToString();
            }
            if (!IsPostBack)
            {
                GetAllOrdeDetails();
            }
        }

        private void GetAllOrdeDetails()
        {
            RptrProducts.DataSource = admin.GetOrderForShipt();
            RptrProducts.DataBind();
        }
    }
}