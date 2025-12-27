using Org.BouncyCastle.Asn1.Ocsp;
using Org.BouncyCastle.Asn1.X509;
using Razorpay.Api;
using RazorpaySampleApp.Cartdataclass;
using RazorpaySampleApp.Classes;
using RazorpaySampleApp.Connections.Interfaces;
using RazorpaySampleApp.ProductClass;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services.Description;

namespace RazorpaySampleApp.Connections.Implimentations
{
    public class ProductListRepo : IProductList
    {
        public readonly string strcon = ConfigurationManager.ConnectionStrings["dbcon"].ConnectionString;
        SqlConnection con;
        SqlCommand cmd;
        public DataTable GetAllMainmenu()
        {
            con = new SqlConnection(strcon);
            if (con.State == ConnectionState.Closed)
                con.Open();
            cmd = new SqlCommand("GetAllMainmenu", con);
            cmd.CommandType = CommandType.StoredProcedure;           
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }

        public DataTable GetMaincatForofferSellerWise(int sellerid,string type)
        {
            con = new SqlConnection(strcon);
            if (con.State == ConnectionState.Closed)
                con.Open();
            cmd = new SqlCommand("GetMaincatForofferSellerWise", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@sellerid", sellerid);
            cmd.Parameters.AddWithValue("@type", type);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }

        public DataTable GetAllSubmenu(Double mainid)
        {
            con = new SqlConnection(strcon);
            if (con.State == ConnectionState.Closed)
                con.Open();
            cmd = new SqlCommand("GetAllSubmenu", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@maincatid", mainid);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }

        public DataTable GetProducts(double id, string referenceid)
        {
            con = new SqlConnection(strcon);
            if (con.State == ConnectionState.Closed)
                con.Open();
            cmd = new SqlCommand("GetProducts", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@ref_id", referenceid);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }

        public DataTable GetProductForview(Double id,int Sellerid)
        {
            con = new SqlConnection(strcon);
            if (con.State == ConnectionState.Closed)
                con.Open();
            cmd = new SqlCommand("GetProductForview", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@productid", id);
            cmd.Parameters.AddWithValue("@sellerid", id);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }

        public DataTable GetProductsref()
        {
            con = new SqlConnection(strcon);
            if (con.State == ConnectionState.Closed)
                con.Open();
            cmd = new SqlCommand("GetProductforref", con);
            cmd.CommandType = CommandType.StoredProcedure;           
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }

        public DataTable GetListofProductForQuantity(int sellerid)
        {
            con = new SqlConnection(strcon);
            if (con.State == ConnectionState.Closed)
                con.Open();
            cmd = new SqlCommand("GetListofProductForQuantity", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@sellerid", sellerid);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }

        public int SaveProduct(ProductClassSaveData product)
        {
            con = new SqlConnection(strcon);
            if (con.State == ConnectionState.Closed)
                con.Open();
            cmd = new SqlCommand("ListProduct", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Sellerid", product.Sellerid);
            cmd.Parameters.AddWithValue("@red_id", product.refId);
            cmd.Parameters.AddWithValue("@maincat_id", product.Maincatid);
            cmd.Parameters.AddWithValue("@subcat_id", product.Subcatid);
            cmd.Parameters.AddWithValue("@productname", product.ProductName);
            cmd.Parameters.AddWithValue("@productbrand", product.ProducBrand);
            cmd.Parameters.AddWithValue("@productdetail", product.ProductDeails);
            cmd.Parameters.AddWithValue("@productdescription", product.ProductDescription);
            cmd.Parameters.AddWithValue("@productkeyword", product.ProductKeywords);
            cmd.Parameters.AddWithValue("@productspecification", product.ProductSpecification);
            cmd.Parameters.AddWithValue("@productType", product.ProductType);
            cmd.Parameters.AddWithValue("@productcolor", product.ProductColor);
            cmd.Parameters.AddWithValue("@productsize", product.ProductSize);
            cmd.Parameters.AddWithValue("@productprice", product.ProductPrice);
            cmd.Parameters.AddWithValue("@productdiscount", product.ProductDiscount);
            cmd.Parameters.AddWithValue("@iscod", product.Iscod);
            cmd.Parameters.AddWithValue("@isfestiveoffer", product.isFestiveOffer);
            cmd.Parameters.AddWithValue("@isactive", product.isActiveNow);
            cmd.Parameters.AddWithValue("@returnday", product.ReturnDay);
            cmd.Parameters.AddWithValue("@replacementday", product.ReplacementDay);
            cmd.Parameters.AddWithValue("@deliveryprice", product.DeliveryPrice);
            cmd.Parameters.AddWithValue("@avl_qty", product.avl_qty);
            cmd.Parameters.AddWithValue("@image1", product.Image1);
            cmd.Parameters.AddWithValue("@image2", product.Image2);
            cmd.Parameters.AddWithValue("@image3", product.Image3);
            cmd.Parameters.AddWithValue("@image4", product.Image4);
            cmd.Parameters.AddWithValue("@image5", product.Image5);
            cmd.Parameters.AddWithValue("@warranty", product.warranty);
            int i = cmd.ExecuteNonQuery();
            con.Close();
            return i;
        }

        public int DeleteProductbyid(double id, string Action)
        {
            con = new SqlConnection(strcon);
            if (con.State == ConnectionState.Closed)
                con.Open();
            cmd = new SqlCommand("Deleteproductbyid", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@productid", id);            
            cmd.Parameters.AddWithValue("@Action", Action);            
            int i = cmd.ExecuteNonQuery();
            con.Close();
            return i;
        }

        public DataTable GetproductsSellerwiese(int sellerid)
        {
            con = new SqlConnection(strcon);
            if (con.State == ConnectionState.Closed)
                con.Open();
            cmd = new SqlCommand("GetproductsSellerwiese", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@sellerid", sellerid);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }

        public int updateoffer(double id, string offertype)
        {
            con = new SqlConnection(strcon);
            if (con.State == ConnectionState.Closed)
                con.Open();
            cmd = new SqlCommand("Offerupdate", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@productid", id);
            cmd.Parameters.AddWithValue("@offer", offertype);
            int i = cmd.ExecuteNonQuery();
            con.Close();
            return i;
        }

        public int Discountupdate(Double maincatid, Double subcatid, string productrefid, string type, int discount)
        {
            con = new SqlConnection(strcon);
            if (con.State == ConnectionState.Closed)
                con.Open();
            cmd = new SqlCommand("Discoutedupdate", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@productrefid", productrefid);
            cmd.Parameters.AddWithValue("@maincatid", maincatid);
            cmd.Parameters.AddWithValue("@subcatid", subcatid);
            cmd.Parameters.AddWithValue("@type", type);
            cmd.Parameters.AddWithValue("@discount", discount);
            int i = cmd.ExecuteNonQuery();
            con.Close();
            return i;
        }

        public DataTable GetproductforGridview(int top)
        {
            con = new SqlConnection(strcon);
            if (con.State == ConnectionState.Closed)
                con.Open();
            cmd = new SqlCommand("GetproductforGridview", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@top", top);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }

        public DataTable GetproductforGridviewa(int top, string issort, string isdiscount, string isHightolow, string islowtohigh, string userid)
        {
            con = new SqlConnection(strcon);
            if (con.State == ConnectionState.Closed)
                con.Open();
            cmd = new SqlCommand("GetproductforGridview", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@top", top);
            cmd.Parameters.AddWithValue("@issort", issort);
            cmd.Parameters.AddWithValue("@isdiscount", isdiscount);
            cmd.Parameters.AddWithValue("@hightolow", isHightolow);
            cmd.Parameters.AddWithValue("@lowothight", islowtohigh);
            cmd.Parameters.AddWithValue("@userid", userid);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        

        public DataTable GetproductforGridviewSubcats(int top, Double subcatid, string issort, string isdiscount, string isHithtolow, string islowtohigh, string userid)
        {
            con = new SqlConnection(strcon);
            if (con.State == ConnectionState.Closed)
                con.Open();
            cmd = new SqlCommand("GetproductforGridviewSubcat", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@top", top);
            cmd.Parameters.AddWithValue("@subcat", subcatid);
            cmd.Parameters.AddWithValue("@issort", issort);
            cmd.Parameters.AddWithValue("@isdiscount", isdiscount);
            cmd.Parameters.AddWithValue("@hightolow", isHithtolow);
            cmd.Parameters.AddWithValue("@lowothight", islowtohigh);
            cmd.Parameters.AddWithValue("@userid", userid);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }

        public DataTable GetproductforGridviewSearch(int top, string searchquery, string issort, string isdiscount, string isHithtolow, string islowtohigh, string userid)
        {
            con = new SqlConnection(strcon);
            if (con.State == ConnectionState.Closed)
                con.Open();
            cmd = new SqlCommand("GetproductforGridviewSearch", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@top", top);
            cmd.Parameters.AddWithValue("@searchquery", searchquery);
            cmd.Parameters.AddWithValue("@issort", issort);
            cmd.Parameters.AddWithValue("@isdiscount", isdiscount);
            cmd.Parameters.AddWithValue("@hightolow", isHithtolow);
            cmd.Parameters.AddWithValue("@lowothight", islowtohigh);
            cmd.Parameters.AddWithValue("@userid", userid);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }

        public DataTable GetproductforGridviewmaincat(int top, double maincat, string issort, string isdiscount, string isHithtolow, string islowtohigh, string userid)
        {
            con = new SqlConnection(strcon);
            if (con.State == ConnectionState.Closed)
                con.Open();
            cmd = new SqlCommand("GetproductforGridviewmaincat", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@top", top);
            cmd.Parameters.AddWithValue("@maincat", maincat);
            cmd.Parameters.AddWithValue("@issort", issort);
            cmd.Parameters.AddWithValue("@isdiscount", isdiscount);
            cmd.Parameters.AddWithValue("@hightolow", isHithtolow);
            cmd.Parameters.AddWithValue("@lowothight", islowtohigh);
            cmd.Parameters.AddWithValue("@userid", userid);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }

       

        public DataSet GetProductdetails(double proeuctid, string productrefid)
        {
            con = new SqlConnection(strcon);
            if (con.State == ConnectionState.Closed)
                con.Open();
            cmd = new SqlCommand("GetProductdetails", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@productid", proeuctid);
            cmd.Parameters.AddWithValue("@productrefid", productrefid);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            con.Close();
            return ds;
        }

        public DataTable CheckifCommentExitst(string userid, double proeuctid, string productrefid)
        {
            con = new SqlConnection(strcon);
            if (con.State == ConnectionState.Closed)
                con.Open();
            cmd = new SqlCommand("CheckifCommentExitst", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@userid", userid);
            cmd.Parameters.AddWithValue("@productid", proeuctid);
            cmd.Parameters.AddWithValue("@productrefid", productrefid);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }

        public int commentinsert(string userid, double productid, string productrefid, string comment, int ratecount)
        {
            con = new SqlConnection(strcon);
            if (con.State == ConnectionState.Closed)
                con.Open();
            cmd = new SqlCommand("commentinsert", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@userid", userid);
            cmd.Parameters.AddWithValue("@productid", productid);
            cmd.Parameters.AddWithValue("@productrefid", productrefid);
            cmd.Parameters.AddWithValue("@comment", comment);
            cmd.Parameters.AddWithValue("@ratecount", ratecount);
            int i = cmd.ExecuteNonQuery();
            con.Close();
            return i;
        }

        public int commentupdate(string userid, double productid, string productrefid, string comment, int ratecount)
        {
            con = new SqlConnection(strcon);
            if (con.State == ConnectionState.Closed)
                con.Open();
            cmd = new SqlCommand("commentupdate", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@userid", userid);
            cmd.Parameters.AddWithValue("@productid", productid);
            cmd.Parameters.AddWithValue("@productrefid", productrefid);
            cmd.Parameters.AddWithValue("@comment", comment);
            cmd.Parameters.AddWithValue("@ratecount", ratecount);
            int i = cmd.ExecuteNonQuery();
            con.Close();
            return i;
        }

        public DataSet Getcartvalues(string userid)
        {
            con = new SqlConnection(strcon);
            if (con.State == ConnectionState.Closed)
                con.Open();
            cmd = new SqlCommand("Getcartvalues", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@userid", userid);            
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            con.Close();
            return ds;
        }

        public int upateCartqty(int qty, double productid, string productrefid)
        {
            con = new SqlConnection(strcon);
            if (con.State == ConnectionState.Closed)
                con.Open();
            cmd = new SqlCommand("UpdateQtycart", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@qty", qty);
            cmd.Parameters.AddWithValue("@productid", productid);
            cmd.Parameters.AddWithValue("@productirefid", productrefid);
           
            int i = cmd.ExecuteNonQuery();
            con.Close();
            return i;
        }

        public int Deletecartitem(double productid, string userid)
        {
            con = new SqlConnection(strcon);
            if (con.State == ConnectionState.Closed)
                con.Open();
            cmd = new SqlCommand("deletecartitem", con);
            cmd.CommandType = CommandType.StoredProcedure;
           
            cmd.Parameters.AddWithValue("@productid", productid);
            cmd.Parameters.AddWithValue("@userid", userid);

            int i = cmd.ExecuteNonQuery();
            con.Close();
            return i;
        }

        public int AddTocart(CartFields cart)
        {
            con = new SqlConnection(strcon);
            if (con.State == ConnectionState.Closed)
                con.Open();
            cmd = new SqlCommand("Addtocart", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@userid", cart.userid);
            cmd.Parameters.AddWithValue("@productid", cart.productid);
            cmd.Parameters.AddWithValue("@product_refid",cart.productrefid );
            cmd.Parameters.AddWithValue("@selling_price",cart.Sellingprice );
            cmd.Parameters.AddWithValue("@discountpercentage",cart.discountpercentage );
            cmd.Parameters.AddWithValue("@markedprice",cart.markedprice );
            cmd.Parameters.AddWithValue("@deliveryprice",cart.deliveryprice );
            cmd.Parameters.AddWithValue("@purchasedquantity",cart.PurchasedQuantity );
            cmd.Parameters.AddWithValue("@size",cart.size );

            int i = cmd.ExecuteNonQuery();
            con.Close();
            return i;
        }

        public bool check_If_item_available_in_cart(string userid, double productid, string productrefid)
        {
            con = new SqlConnection(strcon);
            if (con.State == ConnectionState.Closed)
                con.Open();
            cmd = new SqlCommand("checkitemincart", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@userid", userid);
            cmd.Parameters.AddWithValue("@productid", productid);
            cmd.Parameters.AddWithValue("@productref_id", productrefid);           
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            if(dt.Rows.Count>0)
            {
                return true;
            }
            return false;

        }

        public DataTable Getuserbyid(string id)
        {
            con = new SqlConnection(strcon);
            if (con.State == ConnectionState.Closed)
                con.Open();
            cmd = new SqlCommand("Getuserid", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@userid", id);                    
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }

        public int insertIntoOrderTable(OrderClass order)
        {
            con = new SqlConnection(strcon);
            if (con.State == ConnectionState.Closed)
                con.Open();
            cmd = new SqlCommand("orderValue", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@userid", order.userid);          
            cmd.Parameters.AddWithValue("@orderid",order.orderid );          
            cmd.Parameters.AddWithValue("@paymentid",order.paymentid );          
            cmd.Parameters.AddWithValue("@productid",order.productid );          
            cmd.Parameters.AddWithValue("@productrefid", order.productrefid);          
            cmd.Parameters.AddWithValue("@buymethod",order.buymethod );          
            cmd.Parameters.AddWithValue("@paymentmode",order.paymentmode );          
            cmd.Parameters.AddWithValue("@image",order.imageurl );          
            cmd.Parameters.AddWithValue("@quantity",order.quantity );          
            cmd.Parameters.AddWithValue("@paymentstatus", order.paymentstaus );          
            cmd.Parameters.AddWithValue("@size", order.size );          
            int i = cmd.ExecuteNonQuery();
            con.Close();
            return i;
        }

        public DataTable getCartItemForbuy(string userid)
        {
            con = new SqlConnection(strcon);
            if (con.State == ConnectionState.Closed)
                con.Open();
            cmd = new SqlCommand("Getcartitemtoplaceorder", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@userid", userid);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }

        public int Emptycart()
        {
            con = new SqlConnection(strcon);
            if (con.State == ConnectionState.Closed)
                con.Open();
            cmd = new SqlCommand("EmptyCart", con);
            cmd.CommandType = CommandType.StoredProcedure;          
            int i = cmd.ExecuteNonQuery();
            con.Close();
            return i;
        }

        public DataTable GetQuantity(double productid, string productreid)
        {
            con = new SqlConnection(strcon);
            if (con.State == ConnectionState.Closed)
                con.Open();
            cmd = new SqlCommand("GetQuantity", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@prductid", productid);
            cmd.Parameters.AddWithValue("@productrefid", productreid);

            
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }

        public DataTable Commentrights(string userid, double proeuctid, string productrefid)
        {
            con = new SqlConnection(strcon);
            if (con.State == ConnectionState.Closed)
                con.Open();
            cmd = new SqlCommand("Commentrights", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@userid", userid);
            cmd.Parameters.AddWithValue("@prductid", proeuctid);
            cmd.Parameters.AddWithValue("@productrefid", productrefid);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }

        public DataTable Getallkeywordst()
        {
            con = new SqlConnection(strcon);
            if (con.State == ConnectionState.Closed)
                con.Open();
            cmd = new SqlCommand("Getallkeywords", con);
            cmd.CommandType = CommandType.StoredProcedure;                      
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }

        public int Getproductid(string refid)
        {
            con = new SqlConnection(strcon);
            if (con.State == ConnectionState.Closed)
                con.Open();
            cmd = new SqlCommand("getproducid", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@productrefid", refid);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return Convert.ToInt32(dt.Rows[0][0].ToString());
        }

        public int Saveproducts(Sizeclass sizeclass)
        {
            con = new SqlConnection(strcon);
            if (con.State == ConnectionState.Closed)
                con.Open();
            cmd = new SqlCommand("insertsize", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@sellerid", sizeclass.sellerid);
            cmd.Parameters.AddWithValue("@productid", sizeclass.Prodcutid);
            cmd.Parameters.AddWithValue("@productrefid", sizeclass.productrefid);
            cmd.Parameters.AddWithValue("@sizename", sizeclass.size);
            cmd.Parameters.AddWithValue("@Qty", sizeclass.qty);
            int i = cmd.ExecuteNonQuery();
            con.Close();
            return i;
        }

        public DataTable Getprodutdetailsforsize(double productid, string productrefid, string sizename)
        {
            con = new SqlConnection(strcon);
            if (con.State == ConnectionState.Closed)
                con.Open();
            cmd = new SqlCommand("getAvlqty", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@productid", productid);
            cmd.Parameters.AddWithValue("@productrefid", productrefid);
            cmd.Parameters.AddWithValue("@sizename", sizename);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }

        public int addTowhishlist(int available, string userid, double productid, string productrefid)
        {
            con = new SqlConnection(strcon);
            if (con.State == ConnectionState.Closed)
                con.Open();
            cmd = new SqlCommand("Addtowhishlist", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@userid",userid);
            cmd.Parameters.AddWithValue("@productid", productid);
            cmd.Parameters.AddWithValue("@productrefid", productrefid);            
            cmd.Parameters.AddWithValue("@isavailable", available);            
            int i = cmd.ExecuteNonQuery();
            con.Close();
            return i;
        }

        public int GetWhishlistTable(string userid, double productid, string productrefid)
        {
            con = new SqlConnection(strcon);
            if (con.State == ConnectionState.Closed)
                con.Open();
            cmd = new SqlCommand("Getwhishlist", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@userid", userid);
            cmd.Parameters.AddWithValue("@productid", productid);
            cmd.Parameters.AddWithValue("@productrefid", productrefid);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            if(dt.Rows.Count>0)
            {
                return 1;
            }
            return 0;
        }

        public DataTable Getproductavailablelist(string productrefid)
        {
            con = new SqlConnection(strcon);
            if (con.State == ConnectionState.Closed)
                con.Open();
            cmd = new SqlCommand("getAvailablecolor", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@productrefid", productrefid);          
                   
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }

        public int Delcommeent(string userid, double productid, string productrefid)
        {
            con = new SqlConnection(strcon);
            if (con.State == ConnectionState.Closed)
                con.Open();
            cmd = new SqlCommand("delcomment", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@userid", userid);
            cmd.Parameters.AddWithValue("@productid", productid);
            cmd.Parameters.AddWithValue("@productrefid", productrefid);            
            int i = cmd.ExecuteNonQuery();
            con.Close();
            return i;
        }

        public DataTable GetWishlist(string userid)
        {
            con = new SqlConnection(strcon);
            if (con.State == ConnectionState.Closed)
                con.Open();
            cmd = new SqlCommand("getWishlistvalue", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@userid", userid);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }

        public bool Checkorderid(string orderid)
        {
            Boolean f = false;
            con = new SqlConnection(strcon);
            if (con.State == ConnectionState.Closed)
                con.Open();
            cmd = new SqlCommand("checkorderid", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@orderid", orderid);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
           if(dt.Rows.Count > 0)
            {
                f=true;
            }
            return f;
        }

        public DataTable GetSimilardata(int subcatid, string productrefid)
        {
            con = new SqlConnection(strcon);
            if (con.State == ConnectionState.Closed)
                con.Open();
            cmd = new SqlCommand("Getsimilarproducts", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@subcatid", subcatid);
            cmd.Parameters.AddWithValue("@productrefid", productrefid);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }

        public int Cancelorder(string orderid, double productid, string productrefid)
        {
            con = new SqlConnection(strcon);
            if (con.State == ConnectionState.Closed)
                con.Open();
            cmd = new SqlCommand("Cancelproduct", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@orderid", orderid);
            cmd.Parameters.AddWithValue("@productid", productid);
            cmd.Parameters.AddWithValue("@productrefid", productrefid);
            int i = cmd.ExecuteNonQuery();
            con.Close();
            return i;
        }

        public int Returnrequest(string orderid, double productid, string productrefid, string returnreason)
        {
            con = new SqlConnection(strcon);
            if (con.State == ConnectionState.Closed)
                con.Open();
            cmd = new SqlCommand("createreturnrequest", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@orderid", orderid);
            cmd.Parameters.AddWithValue("@productid", productid);
            cmd.Parameters.AddWithValue("@productrefid", productrefid);
            cmd.Parameters.AddWithValue("@returnreason", returnreason);
            int i = cmd.ExecuteNonQuery();
            con.Close();
            return i;
        }

        public DataTable GetRetunRequest()
        {
            con = new SqlConnection(strcon);
            if (con.State == ConnectionState.Closed)
                con.Open();
            cmd = new SqlCommand("GetReturnRequest", con);
            cmd.CommandType = CommandType.StoredProcedure;           
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }

        public int ActiononReturnRequest(double requestid, string decision,double returnshippingprice)
        {
            con = new SqlConnection(strcon);
            if (con.State == ConnectionState.Closed)
                con.Open();
            cmd = new SqlCommand("AcceptorRejectReturn", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@requestid", requestid);
            cmd.Parameters.AddWithValue("@decision", decision);
            cmd.Parameters.AddWithValue("@returnShipping", returnshippingprice);
          
            int i = cmd.ExecuteNonQuery();
            con.Close();
            return i;
        }

        public DataSet GetproductforUpdate(Double productid)
        {
            con = new SqlConnection(strcon);
            if (con.State == ConnectionState.Closed)
                con.Open();
            cmd = new SqlCommand("GetProductforQty", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@productid", productid);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            con.Close();
            return ds;
        }

        public int Updatekeyword(double productid, string keyword,int avlquanity)
        {
            con = new SqlConnection(strcon);
            if (con.State == ConnectionState.Closed)
                con.Open();
            cmd = new SqlCommand("UpdateKeyword", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@productid", productid);
            cmd.Parameters.AddWithValue("@keyword", keyword);          
            cmd.Parameters.AddWithValue("@quantity", avlquanity);          
            int i = cmd.ExecuteNonQuery();
            con.Close();
            return i;
        }

        public int UpdatesizeTable(double productid, string size, int avlquantity)
        {
            con = new SqlConnection(strcon);
            if (con.State == ConnectionState.Closed)
                con.Open();
            cmd = new SqlCommand("UpdateSizetable", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@productid", productid);
            cmd.Parameters.AddWithValue("@size", size);
            cmd.Parameters.AddWithValue("@qty", avlquantity);
            int i = cmd.ExecuteNonQuery();
            con.Close();
            return i;
        }

        public DataTable Cancelproduct()
        {
            con = new SqlConnection(strcon);
            if (con.State == ConnectionState.Closed)
                con.Open();
            cmd = new SqlCommand("canceltablerefund", con);
            cmd.CommandType = CommandType.StoredProcedure;          
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }

        public int Cancelconfirm(string orderid, double productid)
        {
            con = new SqlConnection(strcon);
            if (con.State == ConnectionState.Closed)
                con.Open();
            cmd = new SqlCommand("cancelinformation", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@productid", productid);
            cmd.Parameters.AddWithValue("@orderid", orderid);           
            int i = cmd.ExecuteNonQuery();
            con.Close();
            return i;
        }

        public DataTable Cancelproduct(string orderid)
        {
            con = new SqlConnection(strcon);
            if (con.State == ConnectionState.Closed)
                con.Open();
            cmd = new SqlCommand("canceltablerefundByorderid", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@orderid", orderid);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
    }
}