using RazorpaySampleApp.AdressClass;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace RazorpaySampleApp.Connections.Interfaces
{
    interface IAddress
    {
         int InsertAddress(Addrestable address);
        DataTable GetallAddress(string useridd);       
        DataTable GetallAddressForemail(string useridd);       
       

        int UpdateAddressTable(string useridd, double addressid);
        int DeleteAddressTable(Double addressid);

      
        
    }
}