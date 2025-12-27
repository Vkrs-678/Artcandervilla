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
    public partial class WebForm8 : System.Web.UI.Page
    {
        AdminDashbordRepo adminrepo = new AdminDashbordRepo();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack) {
                if (Session["isAdminid"] == null)
                {
                    Response.Redirect("Default.aspx");
                }
                else
                {
                    Session["isAdminid"] = Session["isAdminid"].ToString();
                }
                BindBuyerData();
            }

        }

        private void BindBuyerData()
        {
            DataTable dt = adminrepo.GetBuyerDetails("0");

            if(dt.Rows.Count > 0 )
            {
                RptrBuyerData.DataSource = dt;
                RptrBuyerData.DataBind();
            }
        }

        protected void Lnkapprove_Click(object sender, EventArgs e)
        {
            RepeaterItem item = (sender as LinkButton).Parent as RepeaterItem;
            Label id = ((Label)item.FindControl("Lbluserid")) as Label;
            int i = adminrepo.ApprovedBuyerAccount(id.Text, "APPROVE");
            if(i>0)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", " swal('Approved', 'Account Approved', 'success')", true);
                BindBuyerData();
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", " swal('Not Approved', 'Account Not Approved', 'error')", true);
            }

                
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            RepeaterItem item = (sender as LinkButton).Parent as RepeaterItem;
            Label id = ((Label)item.FindControl("Lbluserid")) as Label;
            int i = adminrepo.ApprovedBuyerAccount(id.Text, "DISAPPROVE");
            if (i > 0)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", " swal('DisApproved', 'Account DisApproved', 'success')", true);
                BindBuyerData();
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", " swal('Not DisApproved', 'Account Not DisApproved', 'error')", true);
            }
        }

        protected void LinkButton4_Click(object sender, EventArgs e)
        {
            RepeaterItem item = (sender as LinkButton).Parent as RepeaterItem;
            Label id = ((Label)item.FindControl("Lbluserid")) as Label;
            int i = adminrepo.ApprovedBuyerAccount(id.Text, "DELETE");
            if (i > 0)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", " swal('Deleted', 'Account Deleted', 'success')", true);
                BindBuyerData();
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", " swal('Not Deleted', 'Account Not Deleted', 'error')", true);
            }
        }
    }
}