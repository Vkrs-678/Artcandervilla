using PdfSharp;
using RazorpaySampleApp.Connections.Implimentations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RazorpaySampleApp
{
    public partial class WebForm30 : System.Web.UI.Page
    {
        ProductListRepo product = new ProductListRepo();
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
                bindData();
            }
        }

        private void bindData()
        {
            RptrProducts.DataSource = product.GetRetunRequest();
            RptrProducts.DataBind();
        }

        protected void btnAccept_Click(object sender, EventArgs e)
        {
            RepeaterItem item = (sender as LinkButton).Parent as RepeaterItem;
            HiddenField hdnrequestid = ((HiddenField)item.FindControl("Hdnrequestid")) as HiddenField;
            TextBox Textreturnprice = ((TextBox)item.FindControl("TxtReturnShippingPrice")) as TextBox;
            if (Textreturnprice.Text.Trim()=="")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "swal('Return Shipping Price', 'Enter Return Price','error')", true);
                return;
            }
          
            int i = product.ActiononReturnRequest(Convert.ToDouble(hdnrequestid.Value), "Accept",Convert.ToDouble(Textreturnprice.Text.Trim()));
            if(i>0)
            {
                bindData();
            }
        }

        protected void btnReject_Click(object sender, EventArgs e)
        {
            RepeaterItem item = (sender as LinkButton).Parent as RepeaterItem;
            HiddenField hdnrequestid = ((HiddenField)item.FindControl("Hdnrequestid")) as HiddenField;
            int i = product.ActiononReturnRequest(Convert.ToDouble(hdnrequestid.Value), "Rejected",0);
            if (i > 0)
            {
                bindData();
            }
        }
    }
}