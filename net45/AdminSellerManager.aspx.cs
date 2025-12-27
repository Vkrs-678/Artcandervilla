using RazorpaySampleApp.Connections.Implimentations;
using RazorpaySampleApp.SendmailClass;
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
    public partial class WebForm7 : System.Web.UI.Page
    {
        AdminDashbordRepo adminrepo = new AdminDashbordRepo();
        Sendmail sendmail = new Sendmail();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["isAdminid"] == null)
            {
                 Response.Redirect("Default.aspx");
            }
            else
            {
                Session["isAdminid"]= Session["isAdminid"].ToString();
            }
            if (!IsPostBack)
            {
               
                BindsellerDetails();
            }
        }

        private void BindsellerDetails()
        {
            DataTable dt = adminrepo.GetSellerDetails();
            if (dt.Rows.Count > 0)
            {
                RptrSellerData.DataSource = dt;
                RptrSellerData.DataBind();

            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            RepeaterItem item = (sender as LinkButton).Parent as RepeaterItem;
            Label id=((Label)item.FindControl("LblSellerid")) as Label;
            
            int i = adminrepo.ApprovedSellerAccount(Convert.ToDouble(id.Text), "APPROVE","");
            DataTable dt = adminrepo.GetSellerDetails(Convert.ToDouble(id.Text));
            if (i>0)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", " swal('Approved', 'Account Approved', 'success')", true);
                BindsellerDetails();
                string s = "<div style='height:70vh;width:94%;background-color:yellow;border-radius:8px;text-align:center;border-style:solid;border-width:3px;border-color:hotpink;'>";
                s += "<div style='display:inline-flex;'>";
                s += "<h1 style='font-family:cursive;color:green;background-color:white;padding:20px;margin-top:30px;margin-bottom:30px'>Art<span style='font-family:cursive;color:hotpink;background-color:white;'>-Candervilla</span></h1><br/> ";
                s += "</div>";
                s += "<div><h3 style='color:red;font-family:verdana;font-weight:800;'>Hello " + dt.Rows[0]["SellerName"].ToString() +" </h3></div>";
                s += "<div><h3 style='color:red;font-family:verdana;font-weight:800;'>Your Account Has been Approved</h3></div>";               
                s += "</div>";
                s += "<div><h3 style='color:red;font-family:verdana;font-weight:800;'>Kind Regards</h3></div>";
                s += "<div><a href='artcandervilla.in' style='color:red;font-family:verdana;font-weight:800;'>artcandervilla</a></div>";
                sendmail.Email(s, dt.Rows[0]["Email"].ToString(), "Your Account Status Changed");
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", " swal('Not Approved', 'Account Not Approved', 'error')", true);
            }
        }

        protected void LnkDisaaprove_Click(object sender, EventArgs e)
        {
            RepeaterItem item = (sender as LinkButton).Parent as RepeaterItem;
            Label id = ((Label)item.FindControl("LblSellerid")) as Label;
            HiddenIdForDisaaprove.Value=id.Text;
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
           
           
        }

        protected void LnkActivate_Click(object sender, EventArgs e)
        {
            RepeaterItem item = (sender as LinkButton).Parent as RepeaterItem;
            Label id = ((Label)item.FindControl("LblSellerid")) as Label;
            TextBox reason = ((TextBox)item.FindControl("TxtReasonDeactivated")) as TextBox;
            int i = adminrepo.ApprovedSellerAccount(Convert.ToDouble(id.Text), "DEACTIVATE", reason.Text);
            DataTable dt = adminrepo.GetSellerDetails(Convert.ToDouble(id.Text));
            if (i > 0)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", " swal('DiActivated', 'Account DiActivated', 'success')", true);
                BindsellerDetails();
                string s = "<div style='height:70vh;width:94%;background-color:yellow;border-radius:8px;text-align:center;border-style:solid;border-width:3px;border-color:hotpink;'>";
                s += "<div style='display:inline-flex;'>";
                s += "<h1 style='font-family:cursive;color:green;background-color:white;padding:20px;margin-top:30px;margin-bottom:30px'>Art<span style='font-family:cursive;color:hotpink;background-color:white;'>-Candervilla</span></h1><br/> ";
                s += "</div>";
                s += "<div><h3 style='color:red;font-family:verdana;font-weight:800;'>Hello " + dt.Rows[0]["SellerName"].ToString() + " </h3></div>";
                s += "<div><h3 style='color:red;font-family:verdana;font-weight:800;'>Your Account Has been DeActivated</h3></div>";
                s += "<div><h3 style='color:red;font-family:verdana;font-weight:800;'>Reason : " + dt.Rows[0]["reason"].ToString() + "</h3></div>";
                s += "</div>";
                s += "<div><h3 style='color:red;font-family:verdana;font-weight:800;'>Kind Regards</h3></div>";
                s += "<div><a href='artcandervilla.in' style='color:red;font-family:verdana;font-weight:800;'>artcandervilla</a></div>";
                sendmail.Email(s, dt.Rows[0]["Email"].ToString(), "Your Account Status Changed");
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", " swal('Not DiActivated', 'Account Not DiActivated', 'error')", true);
            }
        }

       

        protected void LinkfinalDisaaprove_Click(object sender, EventArgs e)
        {
            string reason = TxtreasonForDisApproved.Text;
            int i = adminrepo.ApprovedSellerAccount(Convert.ToDouble(HiddenIdForDisaaprove.Value), "DISAPPROVE", reason);
            DataTable dt = adminrepo.GetSellerDetails(Convert.ToDouble(HiddenIdForDisaaprove.Value));


            if (i > 0)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", " swal('DeApproved', 'Account DeApproved', 'success')", true);
                BindsellerDetails();
                string s = "<div style='height:70vh;width:94%;background-color:yellow;border-radius:8px;text-align:center;border-style:solid;border-width:3px;border-color:hotpink;'>";
                s += "<div style='display:inline-flex;'>";
                s += "<h1 style='font-family:cursive;color:green;background-color:white;padding:20px;margin-top:30px;margin-bottom:30px'>Art<span style='font-family:cursive;color:hotpink;background-color:white;'>-Candervilla</span></h1><br/> ";
                s += "</div>";
                s += "<div><h3 style='color:red;font-family:verdana;font-weight:800;'>Hello " + dt.Rows[0]["SellerName"].ToString() + " </h3></div>";
                s += "<div><h3 style='color:red;font-family:verdana;font-weight:800;'>Your Account Has been DeApproved</h3></div>";
                s += "<div><h3 style='color:red;font-family:verdana;font-weight:800;'>Reason : " + dt.Rows[0]["reason"].ToString() + "</h3></div>";
                
                s += "</div>";
                s += "<div><h3 style='color:red;font-family:verdana;font-weight:800;'>Kind Regards</h3></div>";
                s += "<div><a href='artcandervilla.in' style='color:red;font-family:verdana;font-weight:800;'>artcandervilla</a></div>";
                sendmail.Email(s, dt.Rows[0]["Email"].ToString(), "Your Account Status Changed");
                TxtreasonForDisApproved.Text = "";
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", " swal('Not DisApproved', 'Account Not DisApproved', 'error')", true);
            }
        }

        protected void LnkfinalDelete_Click(object sender, EventArgs e)
        {
            string reason = TxtreasonDeleted.Text;
            DataTable dt = adminrepo.GetSellerDetails(Convert.ToDouble(HdnDeleteid.Value));

            if (File.Exists(Server.MapPath(dt.Rows[0]["Adharcard"].ToString())))
            {
                File.Delete(Server.MapPath(dt.Rows[0]["Adharcard"].ToString()));
            }
            if (File.Exists(Server.MapPath(dt.Rows[0]["Pancard"].ToString())))
            {
                File.Delete(Server.MapPath(dt.Rows[0]["Pancard"].ToString()));
            }
            int i = adminrepo.ApprovedSellerAccount(Convert.ToDouble(HdnDeleteid.Value), "DELETE", "");
           
            if (i > 0)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", " swal('Deleted', 'Account Deleted', 'success')", true);
                BindsellerDetails();
                string s = "<div style='height:70vh;width:94%;background-color:yellow;border-radius:8px;text-align:center;border-style:solid;border-width:3px;border-color:hotpink;'>";
                s += "<div style='display:inline-flex;'>";
                s += "<h1 style='font-family:cursive;color:green;background-color:white;padding:20px;margin-top:30px;margin-bottom:30px'>Art<span style='font-family:cursive;color:hotpink;background-color:white;'>-Candervilla</span></h1><br/> ";
                s += "</div>";
                s += "<div><h3 style='color:red;font-family:verdana;font-weight:800;'>Hello " + dt.Rows[0]["SellerName"].ToString() + " </h3></div>";
                s += "<div><h3 style='color:red;font-family:verdana;font-weight:800;'>Your Account Has been Deleted</h3></div>";
                s += "<div><h3 style='color:red;font-family:verdana;font-weight:800;'>Reason : " + reason + "</h3></div>";
                s += "</div>";
                s += "<div><h3 style='color:red;font-family:verdana;font-weight:800;'>Kind Regards</h3></div>";
                s += "<div><a href='artcandervilla.in' style='color:red;font-family:verdana;font-weight:800;'>artcandervilla</a></div>";
                sendmail.Email(s, dt.Rows[0]["Email"].ToString(), "Your Artcandervilla Account has been Deleted");
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", " swal('Not Deleted', 'Account Not Deleted', 'error')", true);
            }
        }

        protected void LnkDelete_Click1(object sender, EventArgs e)
        {
            RepeaterItem item = (sender as LinkButton).Parent as RepeaterItem;
            Label id = ((Label)item.FindControl("LblSellerid")) as Label;
            HdnDeleteid.Value = id.Text;
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModalforDelete();", true);
        }
    }
}