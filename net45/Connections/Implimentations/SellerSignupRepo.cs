using Razorpay.Api;
using RazorpaySampleApp.Connections.Interfaces;
using RazorpaySampleApp.SellerDataClass;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace RazorpaySampleApp.Connections.Implimentations
{
    public class SellerSignupRepo : ISellersignup
    {
        public readonly string strcon = ConfigurationManager.ConnectionStrings["dbcon"].ConnectionString;
        SqlConnection con;
        SqlCommand cmd;

        public int Deliveredproduct(string orderid, double productid, string productrefid)
        {
            con = new SqlConnection(strcon);
            if (con.State == ConnectionState.Closed)
                con.Open();
            cmd = new SqlCommand("Deliveredproduct", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@orderid", orderid);
            cmd.Parameters.AddWithValue("@productid", productid);
            cmd.Parameters.AddWithValue("@productref", productrefid);
            int i = cmd.ExecuteNonQuery();
            con.Close();
            return i;
        }

        public DataTable GetBillDetails(string orderid, double productid, string productrefid)
        {
            con = new SqlConnection(strcon);
            if (con.State == ConnectionState.Closed)
                con.Open();
            cmd = new SqlCommand("GetBillDetails", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@orderid", orderid);
            cmd.Parameters.AddWithValue("@productid", productid);
            cmd.Parameters.AddWithValue("@productref", productrefid);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }

        public DataTable GetDataforSellerDispatch(double sellerid)
        {
            con = new SqlConnection(strcon);
            if (con.State == ConnectionState.Closed)
                con.Open();
            cmd = new SqlCommand("GetOrderDetailsforDispatch", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Sellerid", sellerid);          
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }


        public DataTable GetOrderDetailsforDispatchPendingOnly(double sellerid)
        {
            con = new SqlConnection(strcon);
            if (con.State == ConnectionState.Closed)
                con.Open();
            cmd = new SqlCommand("GetOrderDetailsforDispatchPendingOnly", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Sellerid", sellerid);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }

        public DataTable GetEmailAddress(string email, double mob)
        {
            con = new SqlConnection(strcon);
            if (con.State == ConnectionState.Closed)
                con.Open();
            cmd = new SqlCommand("getmailforsellerlogin", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@email", email);
            cmd.Parameters.AddWithValue("@mob", mob);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);           
            con.Close();
            return dt;
        }

       

        public int InsertSellerData(SellerDataClasses sldata)
        {
            con = new SqlConnection(strcon);
            if (con.State == ConnectionState.Closed)
                con.Open();
            cmd = new SqlCommand("insertsellerdata", con);
            cmd.CommandType = CommandType.StoredProcedure;           
            cmd.Parameters.AddWithValue("@sellerName", sldata.SellerName);
            cmd.Parameters.AddWithValue("@mobile", sldata.Mobile);
            cmd.Parameters.AddWithValue("@email", sldata.Email);
            cmd.Parameters.AddWithValue("@gst", sldata.Gst);
            cmd.Parameters.AddWithValue("@adharcard", sldata.Adhar);
            cmd.Parameters.AddWithValue("@pancard", sldata.Pancard);           
            cmd.Parameters.AddWithValue("@fullAdress", sldata.fullAddress);           
            cmd.Parameters.AddWithValue("@upino", sldata.upino);           
            cmd.Parameters.AddWithValue("@adharno", sldata.adharno);           
            cmd.Parameters.AddWithValue("@pancardno", sldata.pancardno);           
            int i = cmd.ExecuteNonQuery();
            con.Close();
            return i;

        }

        public int UpdateDispatchedSeller(string Orderid, double Sellerid, double productid, string productrefid, string aciton)
        {
            con = new SqlConnection(strcon);
            if (con.State == ConnectionState.Closed)
                con.Open();
            cmd = new SqlCommand("OrderDispatchedStatus", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@orderid", Orderid);
            cmd.Parameters.AddWithValue("@sellerid", Sellerid);
            cmd.Parameters.AddWithValue("@productid", productid);
            cmd.Parameters.AddWithValue("@productrefid", productrefid);
            cmd.Parameters.AddWithValue("@action", aciton);            
            int i = cmd.ExecuteNonQuery();
            con.Close();
            return i;
        }

        public DataTable GetOrderDetailsforDispatchOrderid(string Orderid)
        {
            con = new SqlConnection(strcon);
            if (con.State == ConnectionState.Closed)
                con.Open();
            cmd = new SqlCommand("GetOrderDetailsforDispatchOrderid", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Orderid", Orderid);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }

        public int GetSellerDispatchPendingOrders(double sellerid)
        {
            con = new SqlConnection(strcon);
            if (con.State == ConnectionState.Closed)
                con.Open();
            cmd = new SqlCommand("GetSellerDispatchpendingorders", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@sellerid", sellerid);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return Convert.ToInt32(dt.Rows[0][0].ToString());
        }

        public DataTable GetOrderDetailsforDispatchOEmailpatch(string orderid, double productid, string productrefid)
        {
            con = new SqlConnection(strcon);
            if (con.State == ConnectionState.Closed)
                con.Open();
            cmd = new SqlCommand("GetOrderDetailsforDispatchOEmailpatch", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Orderid", orderid);
            cmd.Parameters.AddWithValue("@productid", productid);
            cmd.Parameters.AddWithValue("@productrefid", productrefid);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }

        public int AddSpecification(string orederid,double productid,string productrefid, int heigth, int width, int length, double weight)
        {
            con = new SqlConnection(strcon);
            if (con.State == ConnectionState.Closed)
                con.Open();
            cmd = new SqlCommand("addspecification", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@orderid", orederid);
            cmd.Parameters.AddWithValue("@height", heigth);
            cmd.Parameters.AddWithValue("@width", width);
            cmd.Parameters.AddWithValue("@length", length);
            cmd.Parameters.AddWithValue("@weight", weight);
            cmd.Parameters.AddWithValue("@productid", productid);
            cmd.Parameters.AddWithValue("@productrefid", productrefid);
            int i = cmd.ExecuteNonQuery();
            con.Close();
            return i;
        }

        public DataTable GetOrdersForPrintShipmentLabel()
        {
            con = new SqlConnection(strcon);
            if (con.State == ConnectionState.Closed)
                con.Open();
            cmd = new SqlCommand("GetOrdersForShipments", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }

        public DataTable CheckAdhar(string adhar)
        {
            con = new SqlConnection(strcon);
            if (con.State == ConnectionState.Closed)
                con.Open();
            cmd = new SqlCommand("checkAdhar", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Adhar", adhar);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }

        public DataTable Checkpan(string pan)
        {
            con = new SqlConnection(strcon);
            if (con.State == ConnectionState.Closed)
                con.Open();
            cmd = new SqlCommand("checkpancard", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@pancardno", pan);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }

        public DataTable Checkgst(string gst)
        {
            con = new SqlConnection(strcon);
            if (con.State == ConnectionState.Closed)
                con.Open();
            cmd = new SqlCommand("checkgst", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@gst", gst);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
    }
}