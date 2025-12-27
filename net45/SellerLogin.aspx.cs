using RazorpaySampleApp.Connections.Implimentations;
using RazorpaySampleApp.SellerDataClass;
using RazorpaySampleApp.SendmailClass;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RazorpaySampleApp
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        SellerSignupRepo sellerSignupRepo= new SellerSignupRepo();
        SellerDataClasses SellerClass = new SellerDataClasses();
        Sendmail sendemail = new Sendmail();
        int Sellerid;
        string sellerName;
        protected void Page_Load(object sender, EventArgs e)
        {
            
           
           if(!IsPostBack)
           {
                
                displaypanel();
               
           }
        }
       
        protected void LnkLogin_Click(object sender, EventArgs e)
        {
            try
            {

            
            if (Session["UserLoginTrue"] != null)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "swal('User', 'Logout as User','error')", true);
                return;
            }
            if (string.IsNullOrEmpty(TxtMobileNo.Text.Trim()))
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", " swal('Mobile or Email', 'Enter Mobile Number or Email', 'error')", true);
                return;
            }
            DataTable dt;
            if(TxtMobileNo.Text.Trim().Contains('@'))
            {
                dt= sellerSignupRepo.GetEmailAddress(TxtMobileNo.Text.Trim(),0);
                if(dt.Rows.Count ==0)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", " swal('Not Found', 'No Credentials Found', 'error')", true);
                    return;
                }
                if (dt.Rows[0]["is_Approve"].ToString() == "0")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", " swal('Not Approved', 'Your Account is Pending Now', 'error')", true);
                    return;
                }
                else if(dt.Rows[0]["is_Active"].ToString()=="0")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", " swal('Not Active', 'Your Account has been Deactivated', 'error')", true);
                    return;
                }
               
            }
            else
            {
                dt= sellerSignupRepo.GetEmailAddress("", Convert.ToDouble(TxtMobileNo.Text.Trim()));
                if (dt.Rows.Count == 0)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", " swal('Not Found', 'No Credentials Found', 'error')", true);
                    return;
                }
                if (dt.Rows[0]["is_Approve"].ToString() == "0")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", " swal('Not Approved', 'Your Account is Pending Now', 'error')", true);
                    return;
                }
                else if (dt.Rows[0]["is_Active"].ToString() == "0")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", " swal('Not Active', 'Your Account has been Deactivated', 'error')", true);
                    return;
                }
            }
            Random rd = new Random();

            int pass = rd.Next(10000, 99999); //dt.Rows[0]["userpassword"].ToString();
            if(dt.Rows.Count==0)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", " swal('No Record Found', 'Sorry No Seller Found', 'info')", true);
                return;
            }
            else if (Session["UserLoginTrue"] != null)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "swal('User Logout', 'Logout As User First', 'info')", true);
                return;
            }
            else if (Session["isAdminid"] != null)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "swal('Admin Logout', 'Logout As Admin First', 'info')", true);
                return;
            }
                   
            string s = "<div style='height:70vh;width:94%;background-color:yellow;border-radius:8px;text-align:center;border-style:solid;border-width:3px;border-color:hotpink;'>";
            s += "<div style='display:inline-flex;'>";
            s += "<h1 style='font-family:cursive;color:green;background-color:white;padding:20px;margin-top:30px;margin-bottom:30px'>Art<span style='font-family:cursive;color:hotpink;background-color:white;'>-Candervilla</span></h1><br/> ";
            s += "</div>";
            s += "<div><h3 style='color:red;font-family:verdana;font-weight:800;'>Hello " + dt.Rows[0]["sellername"].ToString() +"</h3></div>";
            s += "<div><h3 style='color:red;font-family:verdana;font-weight:800;'>Your One Time Password For Login is</h3></div>";
            s += "<div><h3 style='color:red;font-family:verdana;font-weight:800;'>" + pass + "</h3></div>";
           
            s += "<div><h3 style='color:red;font-family:verdana;font-weight:800;'>Kind Regards</h3></div>";
            s += "<div><a href='artcandervilla.in' style='color:red;font-family:verdana;font-weight:800;'>artcandervilla</a></div>";
            s += "</div>";
           
            Session["SellerLoginOtp"] = pass;
            sendemail.Email( s,dt.Rows[0]["Email"].ToString(),"Seller Login OTP");           
            PanelsellerLogin.Visible = false;
            PanelSellerSignup.Visible = false;
            PanelEnterotp.Visible = true;
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", " swal('Enter Correct Credentials', 'Enter Correct Mobile Number or Email', 'error')", true);
            }
        }

        private void displaypanel()
        {
            PanelsellerLogin.Visible = true;
            PanelSellerSignup.Visible = false;
            PanelEnterotp.Visible = false;
            PanelSellerEmailVeriry.Visible = false;
            PanelAfterEmailVerify.Visible=false;
        }

        protected void LnkSignup_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dtadhar = sellerSignupRepo.CheckAdhar(TxtAdharno.Text.Trim());
                DataTable dtpan = sellerSignupRepo.Checkpan(Txtpancardno.Text.Trim());
                DataTable dtgst = sellerSignupRepo.Checkgst(TxtGstNo.Text.Trim());
                if (dtadhar.Rows.Count > 0)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", " swal('Adhar', 'Adhar Card Already Registered', 'error')", true);
                    return;
                }
                if (dtpan.Rows.Count > 0)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", " swal('Pan Card', 'Pan Card Already Registered', 'error')", true);
                    return;
                }
                if (dtgst.Rows.Count > 0)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", " swal('GST Number', 'GST Number Already Registered', 'error')", true);
                    return;
                }
                if (!ChkTermandConditions.Checked)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", " swal('Term & Conditions !', 'Please Accept Term & Condtions', 'info')", true);
                    return;
                }
                if(!fileadhar.HasFile && !filepancard.HasFile)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", " swal('Adhar & Pan!', 'Adhar card and Pan Card Image is Mandatory', 'info')", true);
                    return;
                }
                if (Txtupino.Text == "")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", " swal('UPI No', 'Please Enter UpI Number it's Mandatory', 'info')", true);
                    return;
                }
                if (TxtAdharno.Text == "")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", " swal('Adhar', 'Please Enter Adhar Number it's Mandatory', 'info')", true);
                    return;
                }
                if (Txtpancardno.Text == "")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", " swal('PanCard', 'Please Enter PanCard Number it's Mandatory', 'info')", true);
                    return;
                }
                if (fullAdress.Text=="")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", " swal('Full Address', 'Enter Complete Address With Pincode', 'info')", true);
                    return;
                }
                SellerClass.SellerName = TxtsellerName.Text.Trim().ToUpper();
                SellerClass.Mobile = Convert.ToDouble(Txtmobile.Text.Trim());
                SellerClass.Email = TxtEmailAddress.Text.Trim();
                SellerClass.Gst = TxtGstNo.Text.Trim()==null?"": TxtGstNo.Text.Trim();
                SellerClass.upino = Txtupino.Text.Trim();
                SellerClass.pancardno = Txtpancardno.Text.Trim();
                SellerClass.adharno = TxtAdharno.Text.Trim();
                string datechange = DateTime.Now.ToString("ddMMyyyyhhmmss");
              
                string filename=Path.Combine("~/SellerData/SellerAdharImages/", datechange+"_"+fileadhar.FileName);
                string filenameSave=Path.Combine(Server.MapPath("~/SellerData/SellerAdharImages/"), datechange + "_" + fileadhar.FileName);
                //if(File.Exists(filename))
                //{
                //    File.Delete(filename);
                //}
                fileadhar.SaveAs(filenameSave);
                SellerClass.Adhar = filename;
                string Panfilename = Path.Combine("~/SellerData/SellerPancardImages/", datechange + "_" + filepancard.FileName);
                string Panfilenamesacw = Path.Combine(Server.MapPath("~/SellerData/SellerPancardImages/"), datechange + "_" + filepancard.FileName);
                filepancard.SaveAs(Panfilenamesacw);
                SellerClass.Pancard = Panfilename;
                SellerClass.fullAddress = fullAdress.Text.Trim();
                int i=  sellerSignupRepo.InsertSellerData(SellerClass);
                DataTable dt = sellerSignupRepo.GetEmailAddress(TxtEmailAddress.Text.Trim(), 0);
                if (i>0)
                {
                    Sellerid = Convert.ToInt32(dt.Rows[0]["Sellerid"].ToString());
                   // Session["SellerLoggedintrue"] = Sellerid;
                    sellerName = dt.Rows[0]["SellerName"].ToString();
                    sendmainAfterSignup(sellerName, Sellerid.ToString());
                    PanelSellerSignup.Visible = false;
                    PanelEnterotp.Visible = false;
                    PanelsellerLogin.Visible = true;
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", " swal('Registration Successfull !', 'Your Are Registered Successfully', 'success')", true);
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", " swal('Registration UnSuccessfull !', 'Not Registered', 'error')", true);
                }
            }
            catch(Exception ex)
            {
                LblCustomeerror.Visible = true;
                LblCustomeerror.Text = ex.Message;
            }
        }

        private void sendmainAfterSignup(string SellerName,string Sellerids)
        {
            string s = "<div style='height:70vh;width:94%;background-color:yellow;border-radius:8px;text-align:center;border-style:solid;border-width:3px;border-color:hotpink;'>";
            s += "<div style='display:inline-flex;'>";
            s += "<h1 style='font-family:cursive;color:green;background-color:white;padding:20px;margin-top:30px;margin-bottom:30px'>Art<span style='font-family:cursive;color:hotpink;background-color:white;'>-Candervilla</span></h1><br/> ";
            s += "</div>";
            s += "<div><h3 style='color:red;font-family:verdana;font-weight:800;'>Congratulations " + SellerName + "</h3></div>";
            s += "<div><h3 style='color:red;font-family:verdana;font-weight:800;'>You have Successfully Registered With Us</h3></div>";
            s += "<div><h3 style='color:red;font-family:verdana;font-weight:800;'>Wait Until Your Account Get Verified From Our Side.</h3></div>";
            s += "<div><h3 style='color:red;font-family:verdana;font-weight:800;'>Your Seller ID Is : " + Sellerids + "</h3></div>";
            s += "</div>";
            s += "<div><h3 style='color:red;font-family:verdana;font-weight:800;'>Kind Regards</h3></div>";
            s += "<div><a href='artcandervilla.in' style='color:red;font-family:verdana;font-weight:800;'>artcandervilla</a></div>";

            sendemail.Email(s, TxtEmailAddress.Text.Trim(), "Seller Registration Successful");
        }

        protected void LnkShowsignup_Click(object sender, EventArgs e)
        {
            PanelsellerLogin.Visible = false;
            PanelSellerSignup.Visible = true;
            PanelEnterotp.Visible = false;
        }

        protected void LnkgoLogin_Click(object sender, EventArgs e)
        {
            PanelsellerLogin.Visible = true;
            PanelSellerSignup.Visible = false;
            PanelEnterotp.Visible = false;
        }

        protected void lnkEnterOtp_Click(object sender, EventArgs e)
        {
            DataTable dt = null;
            if (TxtMobileNo.Text.Trim().Contains('@'))
            {
                 dt = sellerSignupRepo.GetEmailAddress(TxtMobileNo.Text.Trim(), 0);
            }
            else
            {
                dt = sellerSignupRepo.GetEmailAddress("", Convert.ToDouble(TxtMobileNo.Text.Trim()));
            }
           
             
            if (Session["SellerLoginOtp"]!=null && Session["SellerLoginOtp"].ToString()== TxtEnterOtp.Text.Trim())
            {
                Session["SellerLoginOtp"] = null;
                Session["SellerLoggedintrue"] = dt.Rows[0]["Sellerid"];              
                Response.Redirect("Default.aspx");

            }
        }

        protected void LnkveifySelleremail_Click(object sender, EventArgs e)
        {
            bool isEmail = Regex.IsMatch(TxtEmailAddress.Text.Trim(), @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase);
            if (isEmail == false)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", " swal('Email', 'Enter Correct Email', 'error')", true);
                return;
            }
            try
            {
                if(TxtEmailAddress.Text.Trim()=="")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", " swal('Enter Email!', 'Please Enter Email Address', 'error')", true);
                }
                DataTable dt = sellerSignupRepo.GetEmailAddress(TxtEmailAddress.Text.Trim(),0);
                if(dt.Rows.Count>0)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", " swal('Email ', 'Email Already Exist !', 'error')", true);
                    return;
                }
                dt = sellerSignupRepo.GetEmailAddress("", Convert.ToDouble(Txtmobile.Text.Trim()));
                if (dt.Rows.Count > 0)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", " swal('Mobile ', ' Mobile  Already Exist !', 'error')", true);
                    return;
                }
                Random rd = new Random();

                int pass = rd.Next(10000, 99999);
                string s = "<div style='height:70vh;width:94%;background-color:yellow;border-radius:8px;text-align:center;border-style:solid;border-width:3px;border-color:hotpink;'>";
                s += "<div style='display:inline-flex;'>";
                s += "<h1 style='font-family:cursive;color:green;background-color:white;padding:20px;margin-top:30px;margin-bottom:30px'>Art<span style='font-family:cursive;color:hotpink;background-color:white;'>-Candervilla</span></h1><br/> ";
                s += "</div>";               
                s += "<div><h3 style='color:red;font-family:verdana;font-weight:800;'>Verify Your Mail With Below OTP</h3></div>";
                s += "<div><h3 style='color:red;font-family:verdana;font-weight:800;'>" + pass + "</h3></div>";                
                s += "</div>";
                s += "<div><h3 style='color:red;font-family:verdana;font-weight:800;'>Kind Regards</h3></div>";
                s += "<div><a href='artcandervilla.in' style='color:red;font-family:verdana;font-weight:800;'>artcandervilla</a></div>";
                Session["SellerEmailVerify"] = pass;
                sendemail.Email(s, TxtEmailAddress.Text.Trim(), "Verify Your Email");
                TxtEmailAddress.Visible = false;
                PanelSellerEmailVeriry.Visible = true;
                LnkveifySelleremail.Visible = false;


            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", " swal('Exceptional Erro!', '" + ex.Message + "', 'error')", true);
            }
        }

        protected void LnkOtpVerifySellerEmail_Click(object sender, EventArgs e)
        {
            if (Session["SellerEmailVerify"].ToString()== TxtVerifyOtpSeller.Text.Trim())
            {
                LnkveifySelleremail.Visible = false;
                PanelSellerEmailVeriry.Visible = false;
                PanelAfterEmailVerify.Visible=true;
                TxtEmailAddress.Visible = true;
                LblVerifyEmail.Visible=true;
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", " swal('Wrong OTP', 'Enter The OTP Correctly', 'error')", true);
            }
        }

        protected void LnkReEnterEmail_Click(object sender, EventArgs e)
        {
            PanelSellerEmailVeriry.Visible = false;
            LnkveifySelleremail.Visible = true;
            TxtEmailAddress.Visible = true;
        }
    }
}