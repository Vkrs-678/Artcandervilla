using RazorpaySampleApp.Cartdataclass;
using RazorpaySampleApp.Classes;
using RazorpaySampleApp.ProductClass;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;

namespace RazorpaySampleApp.Connections.Interfaces
{
    interface IProductList
    {
        DataTable GetAllMainmenu();
        DataTable GetAllSubmenu(Double Mainid);

        int SaveProduct(ProductClassSaveData product);
        int Discountupdate(Double maincatid, Double subcatid,string productrefid,string type,int discount);

        DataTable GetProducts(Double id,String referenceid);
        DataTable GetMaincatForofferSellerWise(int sellerid, string type);
        DataTable GetProductsref();
        DataTable GetProductForview(double id,int sellerid);
        int DeleteProductbyid(double id,string Action);
        int updateoffer(double id,string offertype);
        DataTable GetproductsSellerwiese(int sellerid);
       
        DataTable GetproductforGridviewa(int top,string issort,string isdiscount,string isHithtolow,string islowtohigh, string userid);
        DataTable GetproductforGridviewSubcats(int top , Double subcatid, string issort, string isdiscount, string isHithtolow, string islowtohigh,string userid);
        DataTable GetproductforGridviewSearch(int top , string searchquery, string issort, string isdiscount, string isHithtolow, string islowtohigh, string userid);
        DataTable GetproductforGridviewmaincat(int top , Double maincat, string issort, string isdiscount, string isHithtolow, string islowtohigh, string userid);

        DataSet  GetProductdetails(double proeuctid,string productrefid);

        DataTable CheckifCommentExitst(string userid,double proeuctid, string productrefid);
        DataTable Commentrights(string userid,double proeuctid, string productrefid);
        int commentinsert(string userid, double productid, string productrefid, string comment, int ratecount);
        int commentupdate(string userid, double productid, string productrefid, string comment, int ratecount);

        DataSet Getcartvalues(string userid);
        DataTable GetWishlist(string userid);

        int upateCartqty(int qty,Double productid,string productrefid);

        int Deletecartitem(double productid,string userid);

        DataTable GetQuantity(double productid, string userid);

        int AddTocart(CartFields cart);

        bool check_If_item_available_in_cart(string userid, Double productid, string productrefid);

        DataTable Getuserbyid(string id);

        int insertIntoOrderTable(OrderClass order);

        DataTable getCartItemForbuy(string userid);
        int Emptycart();

        DataTable Getallkeywordst();
        int GetWhishlistTable(string userid, double productid, string productrefid);

        int Getproductid(String refid);
        int Delcommeent(String userid,double productid,string productrefid);

        int Saveproducts(Sizeclass sizeclass);
        int addTowhishlist(int available,string userid,double productid,string productrefid);

        DataTable Getprodutdetailsforsize(Double productid, string productrefid,string sizename);
        DataTable Getproductavailablelist(string productrefid);

        Boolean Checkorderid(string orderid);


        DataTable GetSimilardata(int subcatid,string productrefid);

        int Cancelorder(string orderid,double productid,string productrefid);

        int Returnrequest(string orderid, double productid, string productrefid,string returnreason);

        DataTable GetRetunRequest();
        DataSet GetproductforUpdate(Double productid);

        int ActiononReturnRequest(double requestid,String decision,double returnShippingcharge);

        DataTable GetListofProductForQuantity(int sellerid);

        int Updatekeyword( double productid, string keyword,int avlquantity);
        int UpdatesizeTable( double productid, string size,int avlquantity);

        DataTable Cancelproduct();

        DataTable Cancelproduct(String orderid);

        int Cancelconfirm(string orderid, double productid );

    }
}