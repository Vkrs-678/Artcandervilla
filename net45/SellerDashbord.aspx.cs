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
    public partial class WebForm6 : System.Web.UI.Page
    {
        Sendmail Sendmail= new Sendmail();
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

            if (!IsPostBack)
            {
               
               
                getSellerNameDat();
               
                totalSalesChart();
                SalecanclereturnActualSale();
                SalevsReturn();


            }

        }

        private void totalSalesChart()
        {
            DataSet ds = seller.barDataChart(Barchartyear.SelectedItem.Text,Convert.ToInt32(Session["SellerLoggedintrue"].ToString()));
            DataTable dt = ds.Tables[0];
            string months = string.Empty;
            string sales = string.Empty;
            foreach (DataRow row in dt.Rows)
            {
                months += "'"+row["month_name"].ToString()+"',";
                sales+= row["sales"].ToString()+",";
            }
        
            string s = "   function printchart() {const ctx = document.getElementById('myChart');\r\n            new Chart(ctx, {\r\n type: 'bar',\r\n data: {\r\n \r\n labels: [" + months + "],\r\ndatasets: [{\r\nlabel: 'Total Sales Month Wise',\r\n  data: ["+ sales + "],\r\n  borderWidth: 1\r\n}]\r\n},\r\noptions: {\r\nscales: {\r\ny: {\r\nbeginAtZero: true\r\n }\r\n }\r\n}\r\n});}printchart();";
            Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", s, true);
        }

        private void SalecanclereturnActualSale()
        {
            DataSet ds = seller.barDataChart(Barchartyear.SelectedItem.Text, Convert.ToInt32(Session["SellerLoggedintrue"].ToString()));
            DataTable dt = ds.Tables[2];
           
            string values = string.Empty;
            foreach (DataRow row in dt.Rows)
            {
                values +=  row["totalsale"].ToString() + ","+ row["ActualSale"].ToString()+"," + row["cancel"].ToString()+"," + row["ReturnOrder"].ToString();
              
            }
            Doughnutvalue.Value = values;
        }

        private void SalevsReturn()
        {
            DataSet ds = seller.barDataChart(Barchartyear.SelectedItem.Text, Convert.ToInt32(Session["SellerLoggedintrue"].ToString()));
            DataTable dt = ds.Tables[3];

            string values = string.Empty;
            foreach (DataRow row in dt.Rows)
            {
                values += row["totalsale"].ToString() + "," + row["totalreturn"].ToString();

            }
            pievalue.Value = values;
        }

        private void getSellerNameDat()
        {
            
            DataTable dt = seller.GetSellerDetails(Convert.ToDouble(Session["SellerLoggedintrue"].ToString()));
            Label1.Text = dt.Rows[0]["SellerName"].ToString();
            Label3.Text = dt.Rows[0]["SellerName"].ToString();
            Label2.Text = (dt.Rows[0]["is_Approve"].ToString()=="1"?"Aproved":"Not Aproved");
            Label4.Text = (dt.Rows[0]["is_Approve"].ToString()=="1"?"Aproved":"Not Aproved");
            Label5.Text = dt.Rows[0]["Mobile"].ToString();
            Label6.Text = dt.Rows[0]["Email"].ToString();
            Label7.Text = "Upi :-"+dt.Rows[0]["upino"].ToString();
            Label8.Text = dt.Rows[0]["Mobile"].ToString();
            Label9.Text = dt.Rows[0]["Email"].ToString();
            Label10.Text = "Upi :-" + dt.Rows[0]["upino"].ToString();
        }

        protected void LnkLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddProductPage.aspx");
        }

        protected void LnkDeleteDeactivate_Click(object sender, EventArgs e)
        {
            Response.Redirect("ProductActionPage.aspx");
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            Response.Redirect("ProductDiscountpage.aspx");
        }

        protected void LinkDispatch_Click(object sender, EventArgs e)
        {
            Response.Redirect("SellerDispatched.aspx");
        }

        protected void LnkprintShipmentLabel_Click(object sender, EventArgs e)
        {
            Response.Redirect("SellerPrintLabel.aspx");
        }

        protected void Barchartyear_TextChanged(object sender, EventArgs e)
        {
            totalSalesChart();
        }

        protected void LnkPrintReport_Click(object sender, EventArgs e)
        {
            Response.Redirect("salesReport.aspx");
        }

        
    }
}