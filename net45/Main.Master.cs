using RazorpaySampleApp.Connections.Implimentations;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RazorpaySampleApp
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        AdminDashbordRepo adminrepo = new AdminDashbordRepo();
        ProductListRepo product= new ProductListRepo();
        protected void Page_Load(object sender, EventArgs e)
        {
            Whovisible();//Visiblity of Users
            Lgins();
           string userid = Session["UserLoginTrue"] ==null? "0" : Session["UserLoginTrue"].ToString();
            DataSet ds = product.Getcartvalues(userid);
            Label1.Text = ds.Tables[2].Rows[0]["Totalitemincart"].ToString();
            if (!IsPostBack)
            {
                
                BindMaincat();
            }
            String url = HttpContext.Current.Request.Url.AbsolutePath;


            this.TxtSearch.Attributes.Add(
            "onkeypress", "button_click(this,'" + this.LinkSearch.ClientID + "')");

            // Session["isbuyerid"]   When buyer logged work as buyer if globally
            // Session["issellerid"]  When seller logged work as seller if globally
            // Session["isAdminid"]     When Admin logged work as Admin if globally
        }

      

        private void BindMaincat()
        {
            DataTable dt = adminrepo.GetMainCat(0);
            Rptrmain.DataSource = dt;
            Rptrmain.DataBind();
        }
        void Lgins()
        {
           
            if (Session["UserLoginTrue"] != null)
            {
                Session["UserLoginTrue"] = Session["UserLoginTrue"].ToString();
                LnkLogin.Visible = false;
                LnkProfile.Visible = true;
                LnkLogout.Visible = true;
                LnkSellerLogin.Visible = false;
                LnkAdmins.Visible = false;
            }
            else if(Session["SellerLoggedintrue"]!=null)
            {
                Session["SellerLoggedintrue"] = Session["SellerLoggedintrue"].ToString();
                LnkLogin.Visible = false;
                LnkProfile.Visible = false;
                LnkLogout.Visible = true;
                LnkSellerLogin.Visible = false;
                LnkSeller.Visible = true;
                LnkAdmins.Visible = false;

            }
            else if (Session["isAdminid"]!=null)
            {
                Session["isAdminid"] = Session["isAdminid"].ToString();
                LnkLogin.Visible = false;
                LnkProfile.Visible = false;
                LnkLogout.Visible = true;
                LnkSellerLogin.Visible = false;
                LnkSeller.Visible = false;
                LnkAdmins.Visible = false;
                LnkAdmin.Visible = true;

            }
            else
            {
                LnkLogout.Visible = false;
                LnkLogin.Visible = true;
                LnkProfile.Visible = false;
                LnkSellerLogin.Visible = true;
            }
              

        }

        protected void Whovisible()
        {
            try
            {
                if (Session["user"]==null)
                {
                    LnkProfile.Visible = false;
                }
                if (Session["admin"]==null)
                {
                    LnkAdmin.Visible = false;   
                }
                if (Session["seller"]==null)
                {
                    LnkSeller.Visible = false;
                }
            }
            catch(Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", " swal('Exceptional Error !', '"+ex.Message+"', 'error')", true);
            }
        }

        protected void LnkLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("LoginForm.aspx");
        }

        protected void LnkLogout_Click(object sender, EventArgs e)
        {
            Session["UserLoginTrue"] = null;
            Session["SellerLoggedintrue"]=null;
            Session["isAdminid"] = null;
            Response.Redirect("Default.aspx");
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
           
            Response.Redirect("SellerLogin.aspx");
        }

        protected void LnkAdmins_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminLogin.aspx");
        }

        protected void LnkSeller_Click(object sender, EventArgs e)
        {
            Response.Redirect("SellerDashbord.aspx");
        }

        protected void LnkAdmin_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminDashbord.aspx");

        }           

        protected void Rptrmain_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if(e.Item.ItemType==ListItemType.AlternatingItem || e.Item.ItemType==ListItemType.Item)
            {
                var hiddenmainmenu = (HiddenField)e.Item.FindControl("Hdnmainfield");
                var repeater = (Repeater)e.Item.FindControl("Rptrsubcat");
                DataTable dt = adminrepo.GetSubCatByMaincatid(Convert.ToDouble(hiddenmainmenu.Value));
                repeater.DataSource = dt;
                repeater.DataBind();
            }
           

           
           
        }

        protected void LinkSearch_Click(object sender, EventArgs e)
        {
            Response.Redirect("Productpage.aspx?searchkey=" + TxtSearch.Text.Trim() + "");
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
          string userid=  Session["UserLoginTrue"] == null ? "0" : Session["UserLoginTrue"].ToString();
            Response.Redirect("Productcart.aspx?userid=" + userid + "");
        }

        protected void LnkProfile_Click(object sender, EventArgs e)
        {
            Response.Redirect("MyAccount.aspx");
        }

        protected void Linsearch2_Click(object sender, EventArgs e)
        {
            Response.Redirect("Productpage.aspx?searchkey=" + Txtsearch2.Text.Trim() + "");
        }

        //[ScriptMethod]
        //[WebMethod]
        //public static List<string> Getname(string pre)
        //{
        //     AdminDashbordRepo adminsss = new AdminDashbordRepo();
        //    List<string> name = adminsss.Getkeywodsearc(pre);
        //    return name;
        //}
    }
}