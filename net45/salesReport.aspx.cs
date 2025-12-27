using RazorpaySampleApp.Connections.Implimentations;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RazorpaySampleApp
{
    public partial class WebForm31 : System.Web.UI.Page
    {
        AdminDashbordRepo seller = new AdminDashbordRepo();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["SellerLoggedintrue"] == null)
            {
                Response.Redirect("Default.aspx");
            }
            else
            {
                Session["SellerLoggedintrue"] = Session["SellerLoggedintrue"].ToString();
            }

            if(!IsPostBack)
            {
                
                string Fromdate = (DateTime.Now.AddMonths(-1)).ToShortDateString();
                string Todate = (DateTime.Now).ToShortDateString();
                fromDate.Text = Fromdate;                
                ToDate.Text = Todate;
                BindGrid(Convert.ToInt32(Session["SellerLoggedintrue"].ToString()), Convert.ToDateTime(fromDate.Text), Convert.ToDateTime(ToDate.Text),"","","","","");


            }
        }

        private void BindGrid(int sellerid, DateTime from, DateTime to, string setteled, string unsettled, string cancelled, string returns, string Delivered)
        {
            DataTable dt= seller.GetSaleReport(sellerid, from, to, setteled, unsettled, cancelled, returns, Delivered);
            GridSaleReport.DataSource = dt;
           
            GridSaleReport.DataBind();
           if(dt.Rows.Count>0)
            {
                GridSaleReport.HeaderRow.ForeColor = System.Drawing.Color.White;
                GridSaleReport.HeaderRow.BackColor = System.Drawing.Color.Black;
            }
      

        }

        protected void LinkReport_Click(object sender, EventArgs e)
        {
            Response.Clear();
            Response.Buffer = true;
            Response.ClearContent();
            Response.ClearHeaders();
            Response.Charset = "";
            string FileName = "Artcandervilla_seller_report_" + DateTime.Now + ".xls";
            StringWriter strwritter = new StringWriter();
            HtmlTextWriter htmltextwrtter = new HtmlTextWriter(strwritter);
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.ContentType = "application/vnd.ms-excel";
            Response.AddHeader("Content-Disposition", "attachment;filename=" + FileName);
            GridSaleReport.GridLines = GridLines.Both;
            GridSaleReport.HeaderStyle.Font.Bold = true;
            GridSaleReport.RenderControl(htmltextwrtter);
            Response.Write(strwritter.ToString());
            Response.End();
        }

        public override void VerifyRenderingInServerForm(Control control)
        {
            //required to avoid the run time error "
            //Control 'GridView1' of type 'Grid View' must be placed inside a form tag with runat=server."
        }

        protected void Searchbtn_Click(object sender, EventArgs e)
        {
            if (fromDate.Text == "" || ToDate.Text == "")
            {
                fromDate.Text = DateTime.Now.AddMonths(-1).ToString();
                ToDate.Text = DateTime.Now.ToString();
            }
            BindGrid(Convert.ToInt32(Session["SellerLoggedintrue"].ToString()), Convert.ToDateTime(fromDate.Text), Convert.ToDateTime(ToDate.Text), "", "", "", "", "");
        }

        protected void btnDelivered_Click(object sender, EventArgs e)
        {
            if (fromDate.Text == "" || ToDate.Text == "")
            {
                fromDate.Text = DateTime.Now.AddMonths(-1).ToString();
                ToDate.Text = DateTime.Now.ToString();
            }
            BindGrid(Convert.ToInt32(Session["SellerLoggedintrue"].ToString()), Convert.ToDateTime(fromDate.Text), Convert.ToDateTime(ToDate.Text), "", "", "", "", "Delivered");
        }

        protected void LnkReturn_Click(object sender, EventArgs e)
        {
            if (fromDate.Text == "" || ToDate.Text == "")
            {
                fromDate.Text = DateTime.Now.AddMonths(-1).ToString();
                ToDate.Text = DateTime.Now.ToString();
            }
            BindGrid(Convert.ToInt32(Session["SellerLoggedintrue"].ToString()), Convert.ToDateTime(fromDate.Text), Convert.ToDateTime(ToDate.Text), "", "", "", "Return", "");
        }

        protected void LnkCancelled_Click(object sender, EventArgs e)
        {
            if (fromDate.Text == "" || ToDate.Text == "")
            {
                fromDate.Text = DateTime.Now.AddMonths(-1).ToString();
                ToDate.Text = DateTime.Now.ToString();
            }
            BindGrid(Convert.ToInt32(Session["SellerLoggedintrue"].ToString()), Convert.ToDateTime(fromDate.Text), Convert.ToDateTime(ToDate.Text), "", "", "Cancelled", "", "");
        }

        protected void LnkSetteled_Click(object sender, EventArgs e)
        {
            if (fromDate.Text == "" || ToDate.Text == "")
            {
                fromDate.Text = DateTime.Now.AddMonths(-1).ToString();
                ToDate.Text = DateTime.Now.ToString();
            }
            BindGrid(Convert.ToInt32(Session["SellerLoggedintrue"].ToString()), Convert.ToDateTime(fromDate.Text), Convert.ToDateTime(ToDate.Text), "Settled", "", "", "", "");
        }

        protected void LnkUnsettled_Click(object sender, EventArgs e)
        {
            if(fromDate.Text=="" || ToDate.Text=="")
            {
                fromDate.Text = DateTime.Now.AddMonths(-1).ToString();
                ToDate.Text= DateTime.Now.ToString();
            }
            BindGrid(Convert.ToInt32(Session["SellerLoggedintrue"].ToString()), Convert.ToDateTime(fromDate.Text), Convert.ToDateTime(ToDate.Text), "", "UnSettled", "", "", "");
        }
    }
}