using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using RazorpaySampleApp.Connections.Interfaces;
using RazorpaySampleApp.Loginclass;
using System.Reflection;
using System.Web.UI.WebControls;

namespace RazorpaySampleApp.Connections.Implimentations
{

    public class LoginClassRepo: ILoginClass
    {
        public readonly string strcon = ConfigurationManager.ConnectionStrings["dbcon"].ConnectionString;
        SqlConnection con;
        SqlCommand cmd;
       

        public DataTable AdminEmail(string email)
        {
            con = new SqlConnection(strcon);
            if (con.State == ConnectionState.Closed)
                con.Open();
            cmd = new SqlCommand("Adminsmail", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@email", email);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt= new DataTable();  
            da.Fill(dt);
            con.Close();
            return dt;
        }

        public bool CheckEmail(string email)
        {
            con = new SqlConnection(strcon);
            if (con.State == ConnectionState.Closed)
                con.Open();
            cmd = new SqlCommand("checkemail", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@email", email);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                return true;
            }
            con.Close();
            return false;
        }

        public bool CheckMobile(double Mobile)
        {
            con = new SqlConnection(strcon);
            if (con.State == ConnectionState.Closed)
                con.Open();
            cmd = new SqlCommand("checkmobile", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@mobile", Mobile);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                return true;
            }
            con.Close();
            return false;
        }

        public DataTable Checkuserid(string userid)
        {
            con = new SqlConnection(strcon);
            if (con.State == ConnectionState.Closed)
                con.Open();
            cmd = new SqlCommand("finduserid", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@userid", userid);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            
           
            return dt;
        }

       
        public int InsertLoginData(Loginfields login)
        {
            con = new SqlConnection(strcon);
            if (con.State == ConnectionState.Closed)
                con.Open();
            cmd = new SqlCommand("Insertlogincredentials", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@userid", login.userid);
            cmd.Parameters.AddWithValue("@username", login.username);
            cmd.Parameters.AddWithValue("@useremail", login.useremail);
            cmd.Parameters.AddWithValue("@usermobile", login.usermobile);
            cmd.Parameters.AddWithValue("@userpassword", login.userpassword);
            cmd.Parameters.AddWithValue("@registrationType", login.registrationtype);
            int i = cmd.ExecuteNonQuery();
            con.Close();
            return i;
        }

        

        public DataTable LoginDirect(Double Mobile, string password)
        {
            con = new SqlConnection(strcon);
            if (con.State == ConnectionState.Closed)
                con.Open();
            cmd = new SqlCommand("loginDirect", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@mobile", Mobile);
            cmd.Parameters.AddWithValue("@password", password);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();           
            da.Fill(dt);
            con.Close();
            return dt;

        }

        public int resetpassword(string password, string email)
        {
            con = new SqlConnection(strcon);
            if (con.State == ConnectionState.Closed)
                con.Open();
            cmd = new SqlCommand("resetpassword", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@email", email);
            cmd.Parameters.AddWithValue("@password", password);           
            int i = cmd.ExecuteNonQuery();
            con.Close();
            return i;
        }

        public DataTable retrieveforgotpassword(string email)
        {
            con = new SqlConnection(strcon);
            if (con.State == ConnectionState.Closed)
                con.Open();
            cmd = new SqlCommand("getforgotpassword", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@email", email);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;

           
        }
    }
}