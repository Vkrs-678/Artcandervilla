using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASPSnippets.GoogleAPI;
using System.Web.Script.Serialization;
using System.Data.SqlTypes;
using RazorpaySampleApp.Connections.Implimentations;
using RazorpaySampleApp.Loginclass;
using System.EnterpriseServices.CompensatingResourceManager;
using RazorpaySampleApp.SendmailClass;
using static System.Net.WebRequestMethods;
using System.Data;
using System.Text.RegularExpressions;

using System;
using System.Collections.Generic;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;
using System.Text.Json;

namespace RazorpaySampleApp
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        LoginClassRepo LoginClassRepo = new LoginClassRepo();
        Loginfields Loginrepo = new Loginfields();
        Sendmail sendmail = new Sendmail();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DecidePanel();
                GoogelDetails();
                panelofemailconfirmation.Visible = false;
                panelverifyemail.Visible = false;
                msgverifyemail.Visible = false;


            }
            // Remmeberepassworddisplay();//For Remember password
        }

        protected void GoogelDetails()
        {
            try
            {

                GoogleConnect.ClientId = "484076494321-pdah3sog3977cuaplvfjhe42hp4juadq.apps.googleusercontent.com";
                GoogleConnect.ClientSecret = "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";
                GoogleConnect.RedirectUri = Request.Url.AbsoluteUri.Split('?')[0];

                if (!string.IsNullOrEmpty(Request.QueryString["code"]))
                {
                    string code = Request.QueryString["code"].ToString();
                    GoogleConnect connect = new GoogleConnect();
                    string json = connect.Fetch("me", code);
                    GoogleProfile profile = new JavaScriptSerializer().Deserialize<GoogleProfile>(json);
                    string name = profile.DisplayName;
                    string email = profile.email;
                    string mob = profile.Id;
                    string userids = Guid.NewGuid().ToString();
                    DataTable dt = LoginClassRepo.Checkuserid(profile.email);
                    if (dt.Rows.Count > 0 && Session["Typo"].ToString() == "Signup")
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "swal('Already', 'Already Exist', 'info')", true);
                        return;
                    }

                    Loginrepo.userid = profile.Id;
                    if (name == null)
                    {
                        name = "Hello Buyer!";
                    }
                    Loginrepo.username = name;
                    Loginrepo.useremail = email;
                    Loginrepo.usermobile = 0;
                    Loginrepo.userpassword = profile.Id;
                    Loginrepo.registrationtype = "G";
                    if (Session["Typo"].ToString() == "Signup")
                    {
                        int i = LoginClassRepo.InsertLoginData(Loginrepo);
                        if (i > 0)
                        {
                            Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "swal('Success', 'Signed up Successfully', 'success')", true);
                        }
                        else
                        {
                            Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "swal('Error', 'Authentication Error', 'error')", true);
                        }
                    }
                    else
                    {
                        dt = LoginClassRepo.Checkuserid(profile.email);
                        if (dt.Rows.Count > 0)
                        {
                            Session["UserLoginTrue"] = dt.Rows[0]["userid"].ToString();
                            Response.Redirect("Default.aspx");
                        }
                        else
                        {
                            Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "swal('Not Found', 'No User Found !', 'error')", true);
                            return;
                        }


                    }


                }
                if (Request.QueryString["error"] == "access_denied")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", " swal('Error', 'Access denied', 'error')", true);
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", " swal('Exceptional Error !', '" + ex.Message + "', 'error')", true);
            }
        }



        void DecidePanel()
        {
            PanelSignup.Visible = false;
            Panelforgotpassword.Visible = false;
            PanelEnterOTp.Visible = false;
            PanelNewpassword.Visible = false;
        }

        protected void LnkShowsignup_Click(object sender, EventArgs e)
        {
            PanelLogin.Visible = false;
            PanelSignup.Visible = true;
        }

        protected void LnkgoLogin_Click(object sender, EventArgs e)
        {
            PanelLogin.Visible = true;
            PanelSignup.Visible = false;
        }

        protected void LnkGoogleSignup_Click(object sender, EventArgs e)
        {
            if (!ChkTermandConditions.Checked)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "swal('Term & Conditions', 'Please Check The Term & Conditions Box', 'info')", true);
                return;
            }
            Session["Typo"] = "Signup";
            GoogleConnect.Authorize("profile", "email");
        }

        protected void LnkLoginwithgoogle_Click(object sender, EventArgs e)
        {
            Session["Typo"] = "Login";
            GoogleConnect.Authorize("profile", "email");
        }

        protected void LnkSignup_Click(object sender, EventArgs e)
        {
            try
            {
                if (TxtUserName.Text == "")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "swal('UserName', 'Enter UserName', 'error')", true);

                    return;
                }
                if (TxtSignMobile.Text == "")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "swal('Mobile Number', 'Enter Mobile Number', 'error')", true);

                    return;
                }

                if (TxtsignEmail.Text == "")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "swal('Email Address', 'Enter Email Address', 'error')", true);

                    return;
                }

                if (!ChkTermandConditions.Checked)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "swal('Term & Conditions', 'Please Check The Term & Conditions Box', 'info')", true);
                    return;
                }
                if (TxtsignPassword.Text.Trim() != TxtconfirmPassword.Text.Trim())
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "swal('Not Matched', 'Password Not Matched', 'error')", true);
                    return;
                }
                if (LoginClassRepo.CheckEmail(TxtsignEmail.Text.Trim()) == true)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "swal('Exists', 'Email Already Registered', 'info')", true);
                    return;
                }
                if (LoginClassRepo.CheckMobile(Convert.ToInt64(TxtSignMobile.Text.Trim())) == true)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "swal('Exists', 'Mobile Number Already Registered', 'info')", true);
                    return;
                }

                string id = Guid.NewGuid().ToString();
                DataTable dt = LoginClassRepo.Checkuserid(id);
                while (dt.Rows.Count > 0)
                {
                    id = Guid.NewGuid().ToString();
                    dt = LoginClassRepo.Checkuserid(id);
                }
                Loginrepo.userid = id;
                Loginrepo.username = TxtUserName.Text.Trim().ToUpper();
                Loginrepo.useremail = TxtsignEmail.Text.Trim().ToUpper();
                Loginrepo.usermobile = Convert.ToInt64(TxtSignMobile.Text.Trim().ToString());
                Loginrepo.userpassword = TxtconfirmPassword.Text.Trim();
                Loginrepo.registrationtype = "D";
                int i = LoginClassRepo.InsertLoginData(Loginrepo);
                if (i > 0)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "swal('Success', 'Signed up Successfully', 'success')", true);
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "swal('Error !', 'Error while Saving the Data', 'error')", true);
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", " swal('Exceptional Error !', '" + ex.Message + "', 'error')", true);
            }
        }
        protected void Remmeberepassworddisplay()
        {
            if (Session["passwordremembered"] != null)
            {
                TxtMobileNo.Text = Request.Cookies["username"].Value.ToString();
                string Encryptedpassword = Request.Cookies["password"].Value.ToString();
                byte[] b = Convert.FromBase64String(Encryptedpassword);
                string Decryptedpassword = ASCIIEncoding.ASCII.GetString(b);
                Txtpassword.Text = Decryptedpassword;
                ChkRememberme.Checked = true;
                Session["passwordremembered"] = null;
            }
        }

        protected void LnkLogin_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = LoginClassRepo.LoginDirect(Convert.ToInt64(TxtMobileNo.Text.Trim()), Txtpassword.Text.Trim());
                if (dt.Rows.Count > 0)
                {
                    if (ChkRememberme.Checked)
                    {
                        Response.Cookies["username"].Value = TxtMobileNo.Text.Trim();

                        byte[] b = ASCIIEncoding.ASCII.GetBytes(Txtpassword.Text.Trim());
                        string EncryptedPassword = Convert.ToBase64String(b);
                        Response.Cookies["password"].Value = EncryptedPassword;
                        Response.Cookies["username"].Expires = DateTime.Now.AddDays(15);
                        Response.Cookies["password"].Expires = DateTime.Now.AddDays(15);
                        Session["passwordremembered"] = "true";

                    }
                    Session["UserLoginTrue"] = dt.Rows[0]["userid"].ToString();
                    if (Session["Redirecturl"] != null)
                    {

                        Response.Redirect(Session["Redirecturl"].ToString());
                    }
                    else
                    {
                        Response.Redirect("Default.aspx");
                    }

                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", " swal('Wrong Credentials !', 'Enter Mobile and Password Carefully', 'error')", true);
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", " swal('Exceptional Error !', '" + ex.Message + "', 'error')", true);
            }
        }

        protected void Lnkforgotpassword_Click(object sender, EventArgs e)
        {
            PanelLogin.Visible = false;
            PanelSignup.Visible = false;
            Panelforgotpassword.Visible = true;
            PanelEnterOTp.Visible = false;
            PanelNewpassword.Visible = false;
        }

        protected void LnkSendOtp_Click(object sender, EventArgs e)
        {
            DataTable dt = LoginClassRepo.retrieveforgotpassword(Txtforgotemail.Text.Trim());
            Session["changeEmailPass"] = Txtforgotemail.Text.Trim();
            if (dt.Rows.Count == 0)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", " swal('No Record Found !', 'There is No Account Registered With This Mail..', 'error')", true);
                return;
            }
            Random rd = new Random();

            int pass = rd.Next(10000, 99999); //dt.Rows[0]["userpassword"].ToString();
            string Registertype = dt.Rows[0]["registrationtype"].ToString();
            if (Registertype == "G")
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", " swal('Google Login !', 'Direct Login Through Mail', 'info')", true);
                return;
            }
            string s = "<div style='height:70vh;width:94%;background-color:yellow;border-radius:8px;text-align:center;border-style:solid;border-width:3px;border-color:hotpink;'>";
            s += "<div style='display:inline-flex;'>";
            s += "<h1 style='font-family:cursive;color:green;background-color:white;padding:20px;margin-top:30px;margin-bottom:30px'>Art<span style='font-family:cursive;color:hotpink;background-color:white;'>-Candervilla</span></h1><br/> ";
            s += "</div>";
            s += "<div><h3 style='color:red;font-family:verdana;font-weight:800;'>Your One Time Password Is</h3></div>";
            s += "<div><h3 style='color:red;font-family:verdana;font-weight:800;'>" + pass + "</h3></div>";
            s += "<div><h3 style='color:red;font-family:verdana;font-weight:800;'>Kind Regards</h3></div>";
            s += "<div><a href='artcandervilla.bsite.net' style='color:red;font-family:verdana;font-weight:800;'>artcandervilla</a></div>";
            s += "</div>";
            sendmail.Email(s, Txtforgotemail.Text.Trim(), "Forgot Password !");
            Session["passchangeotp"] = pass;
            PanelLogin.Visible = false;
            PanelSignup.Visible = false;
            Panelforgotpassword.Visible = false;
            PanelEnterOTp.Visible = true;
            PanelNewpassword.Visible = false;
        }

        protected void LnkEnterotp_Click(object sender, EventArgs e)
        {
            if (TxtEnterOtp.Text.Trim() == Session["passchangeotp"].ToString())
            {
                Session["passchangeotp"] = null;
                PanelLogin.Visible = false;
                PanelSignup.Visible = false;
                Panelforgotpassword.Visible = false;
                PanelEnterOTp.Visible = false;
                PanelNewpassword.Visible = true;
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", " swal('Wrong OTP !', 'Enter Correct OTP', 'error')", true);
            }

        }

        protected void LnkChangepassword_Click(object sender, EventArgs e)
        {
            try
            {
                int i = LoginClassRepo.resetpassword(TxtconfNewpassword.Text.Trim(), Session["changeEmailPass"].ToString());
                if (i > 0)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", " swal('Password Reseted ', 'Password Changed Successfully', 'success')", true);
                    PanelLogin.Visible = true;
                    PanelSignup.Visible = false;
                    Panelforgotpassword.Visible = false;
                    PanelEnterOTp.Visible = false;
                    PanelNewpassword.Visible = false;
                }
                Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", " swal('Password Not Reseted ', 'Password Not Changed', 'error')", true);
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", " swal('Exceptional Error !', '" + ex.Message + "', 'error')", true);
            }

        }

        protected void btnsendopt_Click(object sender, EventArgs e)
        {
            bool isEmail = Regex.IsMatch(TxtsignEmail.Text.Trim(), @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase);
            if (isEmail == false)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", " swal('Email', 'Enter Correct Email', 'error')", true);
                return;
            }
            Random rnd = new Random();
            Sendmail sendemail = new Sendmail();
            int randomno = rnd.Next(1000, 9999);
            string s = "<div style='height:70vh;width:94%;background-color:yellow;border-radius:8px;text-align:center;border-style:solid;border-width:3px;border-color:hotpink;'>";
            s += "<div style='display:inline-flex;'>";
            s += "<h1 style='font-family:cursive;color:green;background-color:white;padding:20px;margin-top:30px;margin-bottom:30px'>Art<span style='font-family:cursive;color:hotpink;background-color:white;'>-Candervilla</span></h1><br/> ";
            s += "</div>";
            s += "<div><h3 style='color:red;font-family:verdana;font-weight:800;'>Verify Your Mail With Below OTP</h3></div>";
            s += "<div><h3 style='color:red;font-family:verdana;font-weight:800;'>" + randomno + "</h3></div>";
            s += "</div>";
            s += "<div><h3 style='color:red;font-family:verdana;font-weight:800;'>Kind Regards</h3></div>";
            s += "<div><a href='artcandervilla.bsite.net' style='color:red;font-family:verdana;font-weight:800;'>artcandervilla</a></div>";
            Session["UserEmailVerify"] = randomno;
            sendemail.Email(s, TxtsignEmail.Text.Trim(), "Verify Your Email");
            btnsendopt.Visible = false;
            panelverifyemail.Visible = true;

        }

        protected void BtnverifyEmail_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(Txtenterotpforverification.Text.Trim()) == Convert.ToInt32(Session["UserEmailVerify"].ToString()))
            {
                panelofemailconfirmation.Visible = true;
                btnsendopt.Visible = false;
                panelverifyemail.Visible = false;
                msgverifyemail.Visible = true;
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", " swal('Wrong OTP', 'Enter Otp Carefully', 'error')", true);
            }
        }

       
    }

    public class GoogleProfile
    {
        public string Id { get; set; }
        public string DisplayName { get; set; }
        public string email { get; set; }
    }
    public class Email
    {
        public string value { get; set; }
        public string Type { get; set; }
    }
}