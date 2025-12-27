using RazorpaySampleApp.Classes;
using RazorpaySampleApp.Connections.Implimentations;
using RazorpaySampleApp.SendmailClass;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RazorpaySampleApp
{
    public partial class Success : System.Web.UI.Page
    {
        
        ProductListRepo product = new ProductListRepo();
        Sendmail sendemail = new Sendmail();
        AddressRepo addressRepo = new AddressRepo();
       



        protected void Page_Load(object sender, EventArgs e)
        {
            Session["succespage"] = "y";
            if (Session["UserLoginTrue"] == null)
            {
                Response.Redirect("Default.aspx");
            }
            else
            {
                Session["UserLoginTrue"] = Session["UserLoginTrue"].ToString();
            }
          

            if (!IsPostBack)
            {
                if(Session["finaltable"]==null)
                {
                    Response.Redirect("Default.aspx");
                }
                else
                {
                    insertDataOrderData();
                  
                }
               
                lblorderid.Text="Odrder Id : " + Request.QueryString["orderid"].ToString();
                lblpaymentid.Text="Payment Id : "+ Request.QueryString["paymentid"].ToString();

            }
        }

        private void insertDataOrderData()
        {
            try
            {
                if ( Request.QueryString["orderid"]!=null)
                {
                    DataTable dt = Session["finaltable"] as DataTable;
                    OrderClass order = new OrderClass();
                    String s = string.Empty;
                    if (dt.Rows.Count>0)
                    {
                       
                        for (int i=0; i<dt.Rows.Count;i++)
                        {
                            order.userid = dt.Rows[i]["userid"].ToString();
                            order.orderid = Request.QueryString["orderid"].ToString();
                            order.paymentid = Request.QueryString["paymentid"].ToString();
                            order.productid = Convert.ToDouble(dt.Rows[i]["productid"].ToString());
                            order.productrefid = dt.Rows[i]["productrefid"].ToString();
                            order.buymethod = dt.Rows[i]["buymethod"].ToString();
                            order.paymentmode = dt.Rows[i]["paymentmode"].ToString();
                            order.imageurl = dt.Rows[i]["imageurl"].ToString();
                            order.quantity =Convert.ToInt32(dt.Rows[i]["quantity"].ToString());
                            order.paymentstaus =dt.Rows[i]["paymentstatus"].ToString(); 
                            order.size= dt.Rows[i]["size"].ToString();

                            String paym = string.Empty;
                            if(dt.Rows[i]["paymentmode"].ToString()=="COD")
                            {
                              paym = "Total Payable Amount";
                            }
                            else
                            {
                                paym = "Total Amount Paid";
                            }

                            DataTable dts = product.GetProducts(Convert.ToInt64(dt.Rows[i]["productid"].ToString()), dt.Rows[i]["productrefid"].ToString());
                            // DataTable dts = product.GetProducts(6, "IUZDPJ379264IUZDPJ");
                            DataTable dtuser = product.Getuserbyid(dt.Rows[i]["userid"].ToString());
                            String username = dtuser.Rows[0]["Nameofthecustomer"].ToString();
                            String useremail = dtuser.Rows[0]["email"].ToString();
                            String productname = dts.Rows[0]["productname"].ToString();
                            String selleremail = dts.Rows[0]["selleremail"].ToString();
                           

                            double totalprice = Math.Round(Convert.ToDouble(dt.Rows[i]["TotalPayment"].ToString()),2);
                            String prdoductsize = dt.Rows[i]["size"].ToString();//dts.Rows[0]["productsize"].ToString();
                            String Paymentmode = dt.Rows[i]["paymentmode"].ToString();
                            String fulladdres = dtuser.Rows[0]["full_address"].ToString();
                            String areavillage = dtuser.Rows[0]["area_village"].ToString();
                            String district = dtuser.Rows[0]["district"].ToString();
                            String city = dtuser.Rows[0]["city"].ToString();
                            String state = dtuser.Rows[0]["state_name"].ToString();
                            String pincode = dtuser.Rows[0]["pincode"].ToString();


                            int ior = product.insertIntoOrderTable(order);
                            if(ior>0)
                            {
                               
                                sendmail(username, useremail, dt.Rows[i]["imageurl"].ToString(), productname, Paymentmode, totalprice, Request.QueryString["orderid"].ToString(), dt.Rows[i]["quantity"].ToString(), prdoductsize, fulladdres, areavillage, district, city, state, pincode, paym);
                                sendmailseller(selleremail, dt.Rows[i]["imageurl"].ToString(), productname, totalprice, Request.QueryString["orderid"].ToString(), dt.Rows[i]["quantity"].ToString(), prdoductsize, Convert.ToDouble(dt.Rows[i]["productid"].ToString()), dt.Rows[i]["productrefid"].ToString(), Paymentmode);
                                sendmailadmin(selleremail, dt.Rows[i]["imageurl"].ToString(), productname, totalprice, Request.QueryString["orderid"].ToString(), dt.Rows[i]["quantity"].ToString(), prdoductsize, Convert.ToDouble(dt.Rows[i]["productid"].ToString()), dt.Rows[i]["productrefid"].ToString(), Paymentmode);
                            }
                           


                        }
                        
                        if(dt.Rows[0]["buymethod"].ToString()== "cart")
                        {
                            int i = product.Emptycart();
                        }
                        Session["finaltable"] = null;
                    }
                   

                }
            }
            catch(Exception ex)
            {

            }
        }

        protected void sendmail(String username,String useremail,string Imageurl,String Productname,String  Paymentmode,double totalPrice,String orderid,String productqty,String productsize,String fulladdress,String Areavillage,String Distric,String City,String statename,String Pincode,String pays)
        {
            LinkedResource LinkedImage = new LinkedResource(Server.MapPath(Imageurl));
            LinkedImage.ContentId = "MyPic";
            
            string s = "<div style='height:fit-content;width:94%;background-color:#ffff66;border-radius:8px;border-style:solid;border-width:3px;border-color:hotpink;'>";
            s += "<div style='text-align:center;'>";
            s += "<div style='display:inline-flex;text-align:center;'>";
            s += "<h1 style='font-family:cursive;color:green;background-color:white;padding:20px;margin-top:30px;margin-bottom:30px'>Art<span style='font-family:cursive;color:hotpink;background-color:white;'>-Candervilla</span></h1><br/> ";
            s += "</div>";
            s += "</div>";
            s += "<div style='text-align:left;margin:10px'><div><h3 style='color:black;font-family:verdana;font-weight:800;'>" + username + "</h3><h4 style='color:gray;font-family:verdana;font-weight:800;>Order Id</h6><h6 style='color:black;font-family:verdana;font-weight:800;'>Order Id :- " + orderid + "</h4></div></div>";
            s += "<div style='text-align:right;margin:10px'><div><h3 style='color:black;font-family:verdana;font-weight:800;'>Delivery Address </h3><h4 style='color:gray;font-family:verdana;font-weight:800;>Order Id</h6><h6 style='color:black;font-family:verdana;font-weight:800;'>"+ fulladdress + " "+ Areavillage + "<br/>"+ Distric + "<br/>"+ City + ","+ statename + "- "+Pincode+"</h4></div></div>";
            s += "<div style='text-align:center;'><div><img src=cid:MyPic style='height:100px;width:100px;border:solid;border-color:white;border-radius:5px'></div><div><h3>Product : "+ Productname + "</h3><h3>Qty : "+ productqty + "</h3><h3>Size : "+productsize+"</h3></div></div>";
            s += "<div style='text-align:right;margin:10px'><h3 style='color:red;font-family:verdana;font-weight:800;'>Payment Mode : "+ Paymentmode + "</h3></div>";
            s += "<div style='text-align:right;margin:10px'><h3 style='color:Green;font-family:verdana;font-weight:800;'>"+ pays + " : ₹ " + totalPrice + "/-</h3></div>";
            s += "<div style='text-align:left;margin:10px'><h3 style='color:red;font-family:verdana;font-weight:800;'>Kind Regards</h3></div>";
            s += "<div style='text-align:left;margin:10px'><a href='artcandervilla.in' style='color:blue;font-family:verdana;font-weight:800;'>artcandervilla</a></div>";
            s += "</div>";
            AlternateView htmlView = AlternateView.CreateAlternateViewFromString(
                          s, null, "text/html");
            htmlView.LinkedResources.Add(LinkedImage);
            sendemail.EmailWithImgae(useremail, "Your Order For "+Productname+" has been Successfully Placed", htmlView);
        }


        protected void sendmailseller(String selleremail, string Imageurl, String Productname, double totalPrice, String orderid, String productqty, String productsize, double productid,string productrefid, String Paymentmode)
        {
            LinkedResource LinkedImage = new LinkedResource(Server.MapPath(Imageurl));
            LinkedImage.ContentId = "MyPic";

            string s = "<div style='height:fit-content;width:94%;background-color:#ffff66;border-radius:8px;border-style:solid;border-width:3px;border-color:hotpink;'>";
            s += "<div style='text-align:center;'>";
            s += "<div style='display:inline-flex;text-align:center;'>";
            s += "<h1 style='font-family:cursive;color:green;background-color:white;padding:20px;margin-top:30px;margin-bottom:30px'>Art<span style='font-family:cursive;color:hotpink;background-color:white;'>-Candervilla</span></h1><br/> ";
            s += "</div>";
            s += "</div>";
            s += "<div style='text-align:left;margin:10px'><div><h3 style='color:black;font-family:verdana;font-weight:800;'>Hello, Partner</h3><h4 style='color:gray;font-family:verdana;font-weight:800;>Order Id</h6><h6 style='color:black;font-family:verdana;font-weight:800;'>Order Id :- " + orderid + "</h4></div></div>";           
            s += "<div style='text-align:center;'><div><img src=cid:MyPic style='height:100px;width:100px;border:solid;border-color:white;border-radius:5px'></div><div><h3>Product : " + Productname + "</h3><h3>Qty : " + productqty + "</h3><h3>Size : " + productsize + "</h3></div></div>";
            s += "<div style='text-align:center;margin:10px'><a href='https://artcandervilla.in/SellerDispatched.aspx?orderid=" + orderid + "&&productid=" + productid + "&&productrefid=" + productrefid + "' style='color:blue;font-family:verdana;font-weight:800;'>Accept of Reject</a></div>";
            s += "<div style='text-align:right;margin:10px'><h3 style='color:red;font-family:verdana;font-weight:800;'>Payment Mode : " + Paymentmode + "</h3></div>";
            s += "<div style='text-align:right;margin:10px'><h3 style='color:Green;font-family:verdana;font-weight:800;'>Amount : ₹ " + totalPrice + "/-</h3></div>";
            s += "<div style='text-align:left;margin:10px'><h3 style='color:red;font-family:verdana;font-weight:800;'>Kind Regards</h3></div>";
            s += "<div style='text-align:left;margin:10px'><a href='artcandervilla.in' style='color:blue;font-family:verdana;font-weight:800;'>artcandervilla</a></div>";
            s += "</div>";
            AlternateView htmlView = AlternateView.CreateAlternateViewFromString(
                          s, null, "text/html");
            htmlView.LinkedResources.Add(LinkedImage);
            sendemail.EmailWithImgae(selleremail, " Order  " + Productname + " has been Booked Accept Or Reject", htmlView);
        }

        protected void sendmailadmin(String selleremail, string Imageurl, String Productname, double totalPrice, String orderid, String productqty, String productsize, double productid, string productrefid, String Paymentmode)
        {
            LinkedResource LinkedImage = new LinkedResource(Server.MapPath(Imageurl));
            LinkedImage.ContentId = "MyPic";

            string s = "<div style='height:fit-content;width:94%;background-color:#ffff66;border-radius:8px;border-style:solid;border-width:3px;border-color:hotpink;'>";
            s += "<div style='text-align:center;'>";
            s += "<div style='display:inline-flex;text-align:center;'>";
            s += "<h1 style='font-family:cursive;color:green;background-color:white;padding:20px;margin-top:30px;margin-bottom:30px'>Art<span style='font-family:cursive;color:hotpink;background-color:white;'>-Candervilla</span></h1><br/> ";
            s += "</div>";
            s += "</div>";
            s += "<div style='text-align:left;margin:10px'><div><h3 style='color:black;font-family:verdana;font-weight:800;'>Hello, Partner</h3><h4 style='color:gray;font-family:verdana;font-weight:800;>Order Id</h6><h6 style='color:black;font-family:verdana;font-weight:800;'>Order Id :- " + orderid + "</h4></div></div>";
            s += "<div style='text-align:center;'><div><img src=cid:MyPic style='height:100px;width:100px;border:solid;border-color:white;border-radius:5px'></div><div><h3>Product : " + Productname + "</h3><h3>Qty : " + productqty + "</h3><h3>Size : " + productsize + "</h3></div></div>";
            s += "<div style='text-align:center;margin:10px'><a href='https://artcandervilla.in/SellerDispatched.aspx?orderid=" + orderid + "&&productid=" + productid + "&&productrefid=" + productrefid + "' style='color:blue;font-family:verdana;font-weight:800;'>Accept of Reject</a></div>";
            s += "<div style='text-align:center;margin:10px'><h3 style='color:red;font-family:verdana;font-weight:800;'>Order Booked Please Check</h3></div>";
            s += "<div style='text-align:right;margin:10px'><h3 style='color:red;font-family:verdana;font-weight:800;'>Payment Mode : " + Paymentmode + "</h3></div>";
            s += "<div style='text-align:right;margin:10px'><h3 style='color:Green;font-family:verdana;font-weight:800;'>Amount : ₹ " + totalPrice + "/-</h3></div>";
            s += "<div style='text-align:left;margin:10px'><h3 style='color:red;font-family:verdana;font-weight:800;'>Kind Regards</h3></div>";
            s += "<div style='text-align:left;margin:10px'><a href='artcandervilla.in' style='color:blue;font-family:verdana;font-weight:800;'>artcandervilla</a></div>";
            s += "</div>";
            AlternateView htmlView = AlternateView.CreateAlternateViewFromString(
                          s, null, "text/html");
            htmlView.LinkedResources.Add(LinkedImage);
            sendemail.EmailWithImgae("artcandervilla@gmail.com", " Order  " + Productname + " has been Sold Please Check", htmlView);
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }
    }
}