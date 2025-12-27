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
    public partial class WebForm29 : System.Web.UI.Page
    {
        ProductListRepo product = new ProductListRepo();
        AdminDashbordRepo admin = new AdminDashbordRepo();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                Binddata();
            }
        }

        private void Binddata()
        {
           string orderid= Request.QueryString["orderid"].ToString();
           string productid= Request.QueryString["productid"].ToString();
           string productrefid= Request.QueryString["productrefid"].ToString();

            DataTable dt= admin.GetShipdata(orderid,Convert.ToDouble(productid), productrefid);
            Image1.ImageUrl = dt.Rows[0]["productimage"].ToString();
        }

        protected void btnSubmitReason_Click(object sender, EventArgs e)
        {
            string orderid = Request.QueryString["orderid"].ToString();
            string productid = Request.QueryString["productid"].ToString();
            string productrefid = Request.QueryString["productrefid"].ToString();
            string reason = string.Empty;
            if (RdoDefecteditem.Checked)
            {
                reason = RdoDefecteditem.Text;
            }
            else if (Rdowrongitem.Checked) {
                reason = Rdowrongitem.Text;
            }
            else if (Rdosizeorfitissue.Checked)
            {
                reason = Rdosizeorfitissue.Text;
            }
            else if (RdoBetterpricefound.Checked)
            {
                reason = RdoBetterpricefound.Text;
            }
            else if (Rdocolorstyle.Checked)
            {
                reason = Rdocolorstyle.Text;
            }
            else if (Rdootherreason.Checked)
            {
                reason = TxtotherReason.Text.Trim();   
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "swal('Reason', 'Choose the Reason for Return', 'info')", true);
                return;
            }

            int i= product.Returnrequest(orderid, Convert.ToDouble(productid), productrefid, reason);
            if(i>0)
            {
               
                Response.Redirect("MyAccount.aspx");
            }
            else
            {
                 Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "swal('Return', 'Already Submiitted', 'error')", true);
            }

        }

        
    }
}