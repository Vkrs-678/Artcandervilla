using RazorpaySampleApp.Connections.Implimentations;
using RazorpaySampleApp.SendmailClass;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RazorpaySampleApp
{
    public partial class WebForm4 : System.Web.UI.Page
    {
        Sendmail main = new Sendmail();
        LoginClassRepo logicrepo = new LoginClassRepo();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                
                Panelforgotpassword.Visible = true;
                PanelEnterOTp.Visible = false;
            }
        }
       
        protected void LnkSendOtp_Click(object sender, EventArgs e)
        {
            DataTable dt = logicrepo.AdminEmail(TxtEmail.Text.Trim());
            if (dt.Rows.Count>0)
            {
                if(Session["UserLoginTrue"]!=null)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "swal('User Logout', 'Logout As User First', 'info')", true);
                    return;
                }
                else if (Session["SellerLoggedintrue"] != null)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "swal('Seller Logout', 'Logout As Seller First', 'info')", true);
                    return;
                }
                    Random random = new Random();
                int pass = random.Next(2839, 3899334);
                Session["Adminloginpass"] = pass;
                string s = "<div style='height:70vh;width:94%;background-color:yellow;border-radius:8px;text-align:center;border-style:solid;border-width:3px;border-color:hotpink;'>";
                s += "<div style='display:inline-flex;'>";
                s += "<h1 style='font-family:cursive;color:green;background-color:white;padding:20px;margin-top:30px;margin-bottom:30px'>Art<span style='font-family:cursive;color:hotpink;background-color:white;'>-Candervilla</span></h1><br/> ";
                s += "</div>";
                s += "<div><h3 style='color:red;font-family:verdana;font-weight:800;'>Hello Admin</h3></div>";
                s += "<div><h3 style='color:red;font-family:verdana;font-weight:800;'>Your OTP Is</h3></div>";
                s += "<div><h3 style='color:red;font-family:verdana;font-weight:800;'>" + pass + "</h3></div>";
                s += "<div><h3 style='color:red;font-family:verdana;font-weight:800;'>Kind Regards</h3></div>";
                s += "<div><a href='artcandervilla.in' style='color:red;font-family:verdana;font-weight:800;'>artcandervilla</a></div>";
                s += "</div>";

                main.Email(s, TxtEmail.Text.Trim(), "Your Art-candervilla Login OTP");
                Session["isAdmin"] = Convert.ToInt32(dt.Rows[0]["Adminid"].ToString());
                Panelforgotpassword.Visible = false;
                PanelEnterOTp.Visible = true;
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "swal('Reattempt', 'No User Found', 'info')", true);
                return;
            }
        }

        protected void LnkEnterotp_Click(object sender, EventArgs e)
        {
            if (Session["UserLoginTrue"] != null)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "swal('User', 'Logout as User','error')", true);
                return;
            }
            if (Session["Adminloginpass"].ToString()==TxtEnterOtp.Text.Trim())
            {
                Session["isAdminid"] = Session["isAdmin"].ToString();
                Response.Redirect("Default.aspx");
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "swal('OTP', 'Wrong OTP', 'error')", true);
            }
        }
    }
}