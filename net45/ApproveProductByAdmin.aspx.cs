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
    public partial class WebForm14 : System.Web.UI.Page
    {
        AdminDashbordRepo admin = new AdminDashbordRepo();
        Sendmail sendmail= new Sendmail();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                if (Session["isAdminid"] == null)
                {
                    Response.Redirect("Default.aspx");
                }
                else
                {
                    Session["isAdminid"] = Session["isAdminid"].ToString();
                }

                bindproduct();
            }
        }

        public DataTable bindproduct()
        {
           string id= Request.QueryString["id"] == null ? "0" : Request.QueryString["id"].ToString();
            DataTable dt = admin.GetAllProducts(Convert.ToDouble(id));
            Rptrproductview.DataSource = dt;
            Rptrproductview.DataBind();
            return dt;
        }

        protected void LnkApprove_Click(object sender, EventArgs e)
        {
            string id = Request.QueryString["id"] == null ? "0" : Request.QueryString["id"].ToString();
            int i= admin.PendingDataTable(Convert.ToDouble(id),1,"");
            if (i > 0)
            {
               DataTable dt= bindproduct();
                DataTable dtsellerdata = admin.GetSellerDetails(Convert.ToInt64(dt.Rows[0]["seller_id"].ToString()));
                string s = "<div style='height:70vh;width:94%;background-color:yellow;border-radius:8px;text-align:center;border-style:solid;border-width:3px;border-color:hotpink;'>";
                s += "<div style='display:inline-flex;'>";
                s += "<h1 style='font-family:cursive;color:green;background-color:white;padding:20px;margin-top:30px;margin-bottom:30px'>Art<span style='font-family:cursive;color:hotpink;background-color:white;'>-Candervilla</span></h1><br/> ";
                s += "</div>";
                s += "<div><h3 style='color:red;font-family:verdana;font-weight:800;'>Hello "+ dtsellerdata.Rows[0]["SellerName"].ToString() + "</h3></div>";
                s += "<div><h3 style='color:red;font-family:verdana;font-weight:800;'>Your Listed Product <br/> Of which <br/>Id : " + dt.Rows[0]["product_id"].ToString() + " <br/>and <br/> Ref id : " + dt.Rows[0]["product_ref_id"].ToString() + " <br/>Has Been Approved</h3></div>";              
               
                s += "<div><h3 style='color:red;font-family:verdana;font-weight:800;'>Kind Regards</h3></div>";
                s += "<div><a href='artcandervilla.in' style='color:red;font-family:verdana;font-weight:800;'>artcandervilla</a></div>";
                sendmail.Email(s, dtsellerdata.Rows[0]["Email"].ToString(), "Your Listed Product Has Been Approved");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "swal('Approved', 'Product Approved','success')", true);
               
            }
           
        }

        protected void Lnkdisaaprove_Click(object sender, EventArgs e)
        {
            string id = Request.QueryString["id"] == null ? "0" : Request.QueryString["id"].ToString();
            int i = admin.PendingDataTable(Convert.ToDouble(id), 0,TxtdisaaprovalReason.Text.Trim());
            if(i>0)
            {
                DataTable dt = bindproduct();
                DataTable dtsellerdata = admin.GetSellerDetails(Convert.ToInt64(dt.Rows[0]["seller_id"].ToString()));
                string s = "<div style='height:80vh;width:94%;background-color:yellow;border-radius:8px;text-align:center;border-style:solid;border-width:3px;border-color:hotpink;'>";
                s += "<div style='display:inline-flex;'>";
                s += "<h1 style='font-family:cursive;color:green;background-color:white;padding:20px;margin-top:30px;margin-bottom:30px'>Art<span style='font-family:cursive;color:hotpink;background-color:white;'>-Candervilla</span></h1><br/> ";
                s += "</div>";
                s += "<div><h3 style='color:red;font-family:verdana;font-weight:800;'>Hello " + dtsellerdata.Rows[0]["SellerName"].ToString() + "</h3></div>";
                s += "<div><h3 style='color:red;font-family:verdana;font-weight:800;'>Your Listed Product <br/> Of which <br/>Id : " + dt.Rows[0]["product_id"].ToString() + " <br/>and <br/> Ref id : " + dt.Rows[0]["product_ref_id"].ToString() + " <br/>Has Been Dispproved</h3></div>";
                s += "<div style='color:red;font-family:verdana;font-weight:800;'>Reason : " + dt.Rows[0]["disaproved_reason"].ToString() + "</div>";
                s += "<div><h3 style='color:red;font-family:verdana;font-weight:800;'>Kind Regards</h3></div>";
                s += "<div><a href='artcandervilla.in' style='color:red;font-family:verdana;font-weight:800;'>artcandervilla</a></div>";
                sendmail.Email(s, dtsellerdata.Rows[0]["Email"].ToString(), "Your Listed Product Has Been Disapproved");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "swal('Disapproved', 'Product Disapproved','info')", true);
            }
        }
    }
}