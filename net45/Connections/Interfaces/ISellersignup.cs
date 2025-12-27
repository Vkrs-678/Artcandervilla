using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using RazorpaySampleApp.SellerDataClass;

namespace RazorpaySampleApp.Connections.Interfaces
{
    interface ISellersignup
    {
        int InsertSellerData(SellerDataClasses sldata);
        DataTable GetEmailAddress(string email, Double mob);
        DataTable GetDataforSellerDispatch(double sellerid);
        DataTable GetOrderDetailsforDispatchPendingOnly(double sellerid);
        DataTable GetOrderDetailsforDispatchOrderid(String Orderid);
        DataTable GetOrderDetailsforDispatchOEmailpatch(string orderid, Double productid, string productrefid);

        DataTable GetBillDetails(string orderid,double productid,String productrefid);

        int UpdateDispatchedSeller(String Orderid, double Sellerid, double productid, String productrefid, String aciton);

        int Deliveredproduct(string orderid, double productid, String productrefid);

        int GetSellerDispatchPendingOrders(double sellerid);
        int AddSpecification(string orederid, double productid, string productrefid,int heigth,int width,int length,double weight);

        DataTable GetOrdersForPrintShipmentLabel();
        DataTable CheckAdhar(string adhar);
        DataTable Checkpan(string pan);
        DataTable Checkgst(string gst);
    }
}