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
    public partial class WebForm5 : System.Web.UI.Page
    {
        AdminDashbordRepo adminrepo= new AdminDashbordRepo();
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
            if (!IsPostBack)           {              
                

                GetAdminName();//Admin Name is Added.
            }

        }

        private void GetAdminName()
        {
           DataTable dt=  adminrepo.GetAdminName(Convert.ToDouble(Session["isAdminid"].ToString()));
            if(dt.Rows.Count>0)
            {
                LblAdminName.Text = dt.Rows[0]["AdminName"].ToString();
            }
        }

        protected void LnkLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminSellerManager.aspx");
        }

        protected void LnManagerBuyers_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminBuyerManager.aspx");
        }

        protected void LnkAddCatSub_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddCategorySubCategory.aspx");
        }

        protected void LnkManageproducts_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminProductView.aspx");
        }

        protected void LnkShipProduct_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminShipPage.aspx");
        }

        protected void LnkDelivery_Click(object sender, EventArgs e)
        {
            Response.Redirect("DeliveredPage.aspx");
        }

        protected void LnkFinalDeliveryPage_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminFinalDeliverypage.aspx");
        }

        protected void LnkreturnRequest_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminReturnrequest.aspx");
        }

        protected void LnkSellerPayment_Click(object sender, EventArgs e)
        {
            Response.Redirect("SellerPayment.aspx");
        }

        protected void LnkCancelRefund_Click(object sender, EventArgs e)
        {
            Response.Redirect("CancelRefund.aspx");
        }
    }
}