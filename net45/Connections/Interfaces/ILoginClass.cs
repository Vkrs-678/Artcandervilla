using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Configuration;
using System.Data.Common;
using RazorpaySampleApp.Loginclass;

namespace RazorpaySampleApp.Connections.Interfaces
{
    
    interface ILoginClass
    {
       

        int InsertLoginData(Loginfields login);

        DataTable Checkuserid(string userid);

        DataTable LoginDirect(Double Mobile,string password);

        bool CheckEmail(string email);  
        bool CheckMobile(double  Mobile);

        DataTable retrieveforgotpassword(string email);

        int resetpassword(string password,string email);

        DataTable AdminEmail(string email);
        

    }
}