using Razorpay.Api;
using RazorpaySampleApp.Connections.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Services.Description;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar;

namespace RazorpaySampleApp.Connections.Implimentations
{

    public class AdminDashbordRepo: IAdminDashbord
    {
        public readonly string strcon = ConfigurationManager.ConnectionStrings["dbcon"].ConnectionString;
        SqlConnection con;
        SqlCommand cmd;

        public int AddFinalsemifinalDelivery(string orderi, double productid, String productrefid, string tracking, DateTime   pickupdate,double shippingprice)
        {
            con = new SqlConnection(strcon);
            if (con.State == ConnectionState.Closed)
                con.Open();
            cmd = new SqlCommand("finalDelivery", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@orderid", orderi);
            cmd.Parameters.AddWithValue("@tracking", tracking);
            cmd.Parameters.AddWithValue("@Expectepickupdate", pickupdate.ToShortDateString());
            cmd.Parameters.AddWithValue("@productid", productid);
            cmd.Parameters.AddWithValue("@productrefid", productrefid);           
            cmd.Parameters.AddWithValue("@Shippingprice", shippingprice);           
            int i = cmd.ExecuteNonQuery();
            con.Close();
            return i;
        }

        public int AddMainCat(string name,string imagepath)
        {
            con = new SqlConnection(strcon);
            if (con.State == ConnectionState.Closed)
                con.Open();
            cmd = new SqlCommand("InserMainCat", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@image", imagepath);
            cmd.Parameters.AddWithValue("@Name", name);
            int i = cmd.ExecuteNonQuery();
            con.Close();
            return i;
        }

        public int AddSubCat(string name, double mainid)
        {

            con = new SqlConnection(strcon);
            if (con.State == ConnectionState.Closed)
                con.Open();
            cmd = new SqlCommand("Insertsubcategory", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@subcatname", name);
            cmd.Parameters.AddWithValue("@maincatid", mainid);
            int i = cmd.ExecuteNonQuery();
            con.Close();
            return i;
        }

        public int ApprovedBuyerAccount(string id, string Operation)
        {
            con = new SqlConnection(strcon);
            if (con.State == ConnectionState.Closed)
                con.Open();
            cmd = new SqlCommand("Buyeraccountoperation", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@userid", id);
            cmd.Parameters.AddWithValue("@operation", Operation);            
            int i = cmd.ExecuteNonQuery();
            con.Close();
            return i;
        }

        public int ApprovedSellerAccount(double id,String Operation,string reason)
        {
            con = new SqlConnection(strcon);
            if (con.State == ConnectionState.Closed)
                con.Open();
            cmd = new SqlCommand("SellerAccountOperation", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Sellerid", id);
            cmd.Parameters.AddWithValue("@operation", Operation);
            cmd.Parameters.AddWithValue("@reason", reason);
            int i=cmd.ExecuteNonQuery();
            con.Close();
            return i;
        }

        public DataSet barDataChart(string year,int sellerid)
        {
            con = new SqlConnection(strcon);
            if (con.State == ConnectionState.Closed)
                con.Open();
            cmd = new SqlCommand("Getbarchartdata", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@year", year);
            cmd.Parameters.AddWithValue("@sellerid", sellerid);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            con.Close();
            return ds;
        }

        public int DeletMainCat(double id)
        {
            con = new SqlConnection(strcon);
            if (con.State == ConnectionState.Closed)
                con.Open();
            cmd = new SqlCommand("DeleteMaincat", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@productid", id);
            int i = cmd.ExecuteNonQuery();
            con.Close();
            return i;
        }

        public int DeletSubCat(double id)
        {
            con = new SqlConnection(strcon);
            if (con.State == ConnectionState.Closed)
                con.Open();
            cmd = new SqlCommand("DeletSubcat", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@subid", id);
            cmd.Parameters.AddWithValue("@mainid", 0);
            int i = cmd.ExecuteNonQuery();
            con.Close();
            return i;
        }

        public int DeletSubCat(double id,double mainid)
        {
            con = new SqlConnection(strcon);
            if (con.State == ConnectionState.Closed)
                con.Open();
            cmd = new SqlCommand("DeletSubcat", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@subid", id);
            cmd.Parameters.AddWithValue("@mainid", mainid);
            int i = cmd.ExecuteNonQuery();
            con.Close();
            return i;
        }

        public DataTable GetAdminName(double id)
        {
            con = new SqlConnection(strcon);
            if (con.State == ConnectionState.Closed)
                con.Open();
            cmd = new SqlCommand("GetAdminName", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@adminid", id);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }

        public DataTable GetAllProducts(double productid)
        {
            con = new SqlConnection(strcon);
            if (con.State == ConnectionState.Closed)
                con.Open();
            cmd = new SqlCommand("Getproduct", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@productid", productid);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }

      

        public DataTable GetBuyerDetails(string id)
        {
            con = new SqlConnection(strcon);
            if (con.State == ConnectionState.Closed)
                con.Open();
            cmd = new SqlCommand("GetBuyerDetails", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@userid", id);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }

        public DataTable GetDataforFinalDelivered(string orderid)
        {
            con = new SqlConnection(strcon);
            if (con.State == ConnectionState.Closed)
                con.Open();
            cmd = new SqlCommand("GetDeliveredOrders", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@orderid", orderid);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }

        public DataTable GetDataforSettlement()
        {
            con = new SqlConnection(strcon);
            if (con.State == ConnectionState.Closed)
                con.Open();
            cmd = new SqlCommand("GetDataforSettlement", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@orderid", "");
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }

        public DataTable GetDataforSettlement(string orderid)
        {
            con = new SqlConnection(strcon);
            if (con.State == ConnectionState.Closed)
                con.Open();
            cmd = new SqlCommand("GetDataforSettlement", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@orderid", orderid);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }

        public List<string> Getkeywodsearc(string prefix)
        {
            con = new SqlConnection(strcon);
            if (con.State == ConnectionState.Closed)
                con.Open();
            cmd = new SqlCommand("getkeywords", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@keyword", prefix);
            SqlDataReader dr =cmd.ExecuteReader();
            List<string> keyworlis = new List<string> ();
            while(dr.Read())
            {
                
                keyworlis.Add(dr["value"].ToString());
                /// .Add(dr["value"].ToString());
            }
            var data = keyworlis.Distinct();
            List<string> newlist = new List<string>();
            foreach (var item in data)
            {
                newlist.Add(item);
            }
       
            return newlist;
        }

        public DataTable GetMainCat(Double id)
        {
            con = new SqlConnection(strcon);
            if (con.State == ConnectionState.Closed)
                con.Open();
            cmd = new SqlCommand("GetMaincate", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@productid", id);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }

        public DataTable GetOrderForShipt()
        {
            con = new SqlConnection(strcon);
            if (con.State == ConnectionState.Closed)
                con.Open();
            cmd = new SqlCommand("GetOrderDetailsForShiping", con);            
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }

        public DataTable GetpendingproductforApproval(int count)
        {
            con = new SqlConnection(strcon);
            if (con.State == ConnectionState.Closed)
                con.Open();
            cmd = new SqlCommand("Getproductpending", con);
            cmd.Parameters.AddWithValue("@count", count);
            cmd.CommandType = CommandType.StoredProcedure;            
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }

        public DataTable GetProductBymaincatid(double maincatid)
        {
            con = new SqlConnection(strcon);
            if (con.State == ConnectionState.Closed)
                con.Open();
            cmd = new SqlCommand("Getproductbymaincat", con);
            cmd.Parameters.AddWithValue("@maincatid", maincatid);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }

        public DataTable GetProductBysubcatid(double subcatid)
        {
            con = new SqlConnection(strcon);
            if (con.State == ConnectionState.Closed)
                con.Open();
            cmd = new SqlCommand("Getproductbysubcatid", con);
            cmd.Parameters.AddWithValue("@subcatid", subcatid);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }

        public DataTable GetSaleReport(int sellerid, DateTime from, DateTime to, string setteled, string unsettled, string cancelled, string returns, string Delivered)
        {
            con = new SqlConnection(strcon);
            if (con.State == ConnectionState.Closed)
                con.Open();
            cmd = new SqlCommand("GetSalesReport", con);
            cmd.Parameters.AddWithValue("@sellerid", sellerid);
            cmd.Parameters.AddWithValue("@delivered", Delivered);
            cmd.Parameters.AddWithValue("@fromdate", from);
            cmd.Parameters.AddWithValue("@toDate", to);
            cmd.Parameters.AddWithValue("@settled", setteled);
            cmd.Parameters.AddWithValue("@unsettled", unsettled);
            cmd.Parameters.AddWithValue("@cancelled", cancelled);
            cmd.Parameters.AddWithValue("@return", returns);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;

        }

        public DataTable GetSellerDetails()
        {
            con = new SqlConnection(strcon);
            if (con.State == ConnectionState.Closed)
                con.Open();
            cmd = new SqlCommand("GetSellerData", con);
            cmd.CommandType = CommandType.StoredProcedure;           
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }

        public DataTable GetSellerDetails(double id)
        {
            con = new SqlConnection(strcon);
            if (con.State == ConnectionState.Closed)
                con.Open();
            cmd = new SqlCommand("GetSellerbyid", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@sellerid", id);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }

        public DataTable GetShipdata(string orderid,double productid,string productrefid)
        {
            con = new SqlConnection(strcon);
            if (con.State == ConnectionState.Closed)
                con.Open();
            cmd = new SqlCommand("GetShipData", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@orderid", orderid);
            cmd.Parameters.AddWithValue("@productid", productid);
            cmd.Parameters.AddWithValue("@productrefid", productrefid);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }

        public DataTable GetShippedProducts()
        {
            con = new SqlConnection(strcon);
            if (con.State == ConnectionState.Closed)
                con.Open();
            cmd = new SqlCommand("GetShippedProducts", con);
            cmd.CommandType = CommandType.StoredProcedure;           
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }

        public DataTable GetSubCat(double id)
        {
            con = new SqlConnection(strcon);
            if (con.State == ConnectionState.Closed)
                con.Open();
            cmd = new SqlCommand("Getsubcat", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@subid", id);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }

        public DataTable GetSubCatByMaincatid(double maincatid)
        {
            con = new SqlConnection(strcon);
            if (con.State == ConnectionState.Closed)
                con.Open();
            cmd = new SqlCommand("GetsubcatbyMainid", con);
            cmd.CommandType = CommandType.StoredProcedure;            
            cmd.Parameters.AddWithValue("@maincatid", maincatid);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }

        public int PendingDataTable(double productid, int Approvalresponse, string DisapprovalReason)
        {
            con = new SqlConnection(strcon);
            if (con.State == ConnectionState.Closed)
                con.Open();
            cmd = new SqlCommand("AdminApproval", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@productid", productid);
            cmd.Parameters.AddWithValue("@ApprovalResponse", Approvalresponse);
            cmd.Parameters.AddWithValue("@DisapprovalReason", DisapprovalReason);
            int i= cmd.ExecuteNonQuery();
            con.Close();
            return i;
        }

        public int UpdateDelivery(string orderid)
        {
            con = new SqlConnection(strcon);
            if (con.State == ConnectionState.Closed)
                con.Open();
            cmd = new SqlCommand("UpdateDelivery", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@orderid", orderid);           
            int i = cmd.ExecuteNonQuery();
            con.Close();
            return i;
        }

        public int updateDeliverydetails(string orderid, int expectedday, string trackno)
        {
            con = new SqlConnection(strcon);
            if (con.State == ConnectionState.Closed)
                con.Open();
            cmd = new SqlCommand("Dispatchdeliverydetails", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@orderid", orderid);
            cmd.Parameters.AddWithValue("@trackno", trackno);
            cmd.Parameters.AddWithValue("@expectedDeliverydate", expectedday);
            int i = cmd.ExecuteNonQuery();
            con.Close();
            return i;
        }

        public int UpdateDeliveryStatus(string orderid, double productid, string productrefid, string status)
        {
            con = new SqlConnection(strcon);
            if (con.State == ConnectionState.Closed)
                con.Open();
            cmd = new SqlCommand("updateFinalDeliveryStatus", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@orderid", orderid);
            cmd.Parameters.AddWithValue("@productid", productid);
            cmd.Parameters.AddWithValue("@productrefid", productrefid);
            cmd.Parameters.AddWithValue("@status", status);
            int i = cmd.ExecuteNonQuery();
            con.Close();
            return i;
        }

        public int UpdateSettlementstatus(string orderid, double productid, string productrefid)
        {
            con = new SqlConnection(strcon);
            if (con.State == ConnectionState.Closed)
                con.Open();
            cmd = new SqlCommand("UpdateSettlementstatus", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@orderid", orderid);
            cmd.Parameters.AddWithValue("@productid", productid);
            cmd.Parameters.AddWithValue("@productrefid", productrefid);           
            int i = cmd.ExecuteNonQuery();
            con.Close();
            return i;
        }
    }
}