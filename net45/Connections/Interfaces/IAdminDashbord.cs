using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace RazorpaySampleApp.Connections.Interfaces
{
    interface IAdminDashbord
    {
        DataTable GetSellerDetails();
        DataTable GetSellerDetails(Double id);
       
        int ApprovedSellerAccount(Double id,String Operation,string reason);

        DataTable GetBuyerDetails(string id);
        DataTable GetOrderForShipt();

        int ApprovedBuyerAccount(string id,string Operation);

        int AddMainCat(string name, string imagepath);
        int updateDeliverydetails(string orderid, int expectedday, string trackno);
        DataTable GetMainCat(Double id);
        DataTable GetShipdata(string orderid, double productid, string productrefid);

        int DeletMainCat(Double id);

        int AddSubCat(string name, Double mainid);
        int AddFinalsemifinalDelivery(string orderi,double productid,String productrefid, string tracking, DateTime pickupdate,double shippingprice);

        DataTable GetSubCat(Double id);

        int DeletSubCat(Double id);
        int UpdateDelivery(string orderid);

        DataTable GetAdminName(Double id);
        DataTable GetAllProducts(Double productid);
        DataTable GetpendingproductforApproval(int count);
        DataTable GetShippedProducts();
        DataTable GetProductBymaincatid(double maincatid);
        DataTable GetProductBysubcatid(double subcatid);

        int PendingDataTable(Double productid,int Approvalresponse,String DisapprovalReason);
        DataTable GetDataforFinalDelivered(string orderid);

        int UpdateDeliveryStatus(string orderid,Double productid,string productrefid,string status);

        List<string> Getkeywodsearc(string prefix);

        DataSet barDataChart(string year,int sellerid);

        DataTable GetSaleReport(int sellerid,DateTime from,DateTime to,string setteled,string unsettled,string cancelled,string returns,string Delivered);
        DataTable GetDataforSettlement();
        DataTable GetDataforSettlement(string orderid);
        int UpdateSettlementstatus(string orderid, Double productid, string productrefid);
    }
}