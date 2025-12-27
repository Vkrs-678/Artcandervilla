using RazorpaySampleApp.AdressClass;
using RazorpaySampleApp.Connections.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Configuration;

namespace RazorpaySampleApp.Connections.Implimentations
{
    public class AddressRepo : IAddress
    {
        public readonly string strcon = ConfigurationManager.ConnectionStrings["dbcon"].ConnectionString;
        SqlConnection con;
        SqlCommand cmd;

        public int DeleteAddressTable(double addressid)
        {
            con = new SqlConnection(strcon);
            if (con.State == ConnectionState.Closed)
                con.Open();
            cmd = new SqlCommand("DeleteAddresstable", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@adressid", addressid);           
            int i = cmd.ExecuteNonQuery();
            con.Close();
            return i;
        }

       

        public DataTable GetallAddress(string useridd)
        {
            con = new SqlConnection(strcon);
            if (con.State == ConnectionState.Closed)
                con.Open();
            cmd = new SqlCommand("GetAddresofCustmer", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@userid", useridd);            
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }

        public DataTable GetallAddressForemail(string useridd)
        {

            con = new SqlConnection(strcon);
            if (con.State == ConnectionState.Closed)
                con.Open();
            cmd = new SqlCommand("GetAddresofCustmerForemail", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@userid", useridd);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }

        public int InsertAddress(Addrestable address)
        {
            con = new SqlConnection(strcon);
            if (con.State == ConnectionState.Closed)
                con.Open();
            cmd = new SqlCommand("insertAddress", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@userid", address.userid);
            cmd.Parameters.AddWithValue("@Name", address.Name);          
            cmd.Parameters.AddWithValue("@Mobilenumber", address.MobileNumber);          
            cmd.Parameters.AddWithValue("@FullAddress", address.FullAddress);          
            cmd.Parameters.AddWithValue("@areavillage", address.Areavillage);          
            cmd.Parameters.AddWithValue("@district", address.District);          
            cmd.Parameters.AddWithValue("@city", address.city);          
            cmd.Parameters.AddWithValue("@statename", address.State);          
            cmd.Parameters.AddWithValue("@pincode", address.Pincode);          
            cmd.Parameters.AddWithValue("@Nearby", address.NearbyPlace);          
            cmd.Parameters.AddWithValue("@email", address.email);          
            int i = cmd.ExecuteNonQuery();
            con.Close();
            return i;
        }

        public int UpdateAddressTable(string useridd, double addressid)
        {
            con = new SqlConnection(strcon);
            if (con.State == ConnectionState.Closed)
                con.Open();
            cmd = new SqlCommand("updatedefultAddress", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@userid", useridd);
            cmd.Parameters.AddWithValue("@addressid", addressid);           
            int i = cmd.ExecuteNonQuery();
            con.Close();
            return i;
        }
    }
}