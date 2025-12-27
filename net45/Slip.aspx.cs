using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using iTextSharp.text;

using QRCoder;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RazorpaySampleApp.Connections.Implimentations;
using System.Data;
using TheArtOfDev.HtmlRenderer.PdfSharp;
using Font = iTextSharp.text.Font;
using System.Diagnostics;

namespace RazorpaySampleApp
{
    public partial class WebForm21 : System.Web.UI.Page
    {
        SellerSignupRepo seller = new SellerSignupRepo();
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["succespage"] = "Y";
            GetBillDetails();
            generateqr();



        }
       



        protected void generateqr()
        {
            String orderid = Request.QueryString["orderid"].ToString();
            double productid = Convert.ToDouble(Request.QueryString["productid"].ToString());
            String productrefid = Request.QueryString["productrefid"].ToString();
            //string code = "https://artcandervilla.in/Deliverpage.aspx?orderid=" + orderid + "&&productid="+ productid + "&&productrefid="+ productrefid + "";   //http//localhost:2799
            string code = "https://artcandervilla.in/Productdetailpage.aspx?productid=" + productid + "&&productrefid="+ productrefid + "";   
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeGenerator.QRCode qrCode = qrGenerator.CreateQrCode(code, QRCodeGenerator.ECCLevel.Q);
            System.Web.UI.WebControls.Image imgBarCode = new System.Web.UI.WebControls.Image();
            imgBarCode.Height = 150;
            imgBarCode.Width = 150;
            using (Bitmap bitMap = qrCode.GetGraphic(20))
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    bitMap.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                    byte[] byteImage = ms.ToArray();
                    imgBarCode.ImageUrl = "data:image/png;base64," + Convert.ToBase64String(byteImage);
                }
              PlaceHolder1.Controls.Add(imgBarCode);
            }
        }

       

        

        protected void GetBillDetails()
        {
            try
            {
                String orderid = Request.QueryString["orderid"].ToString();

                double productid = Convert.ToDouble(Request.QueryString["productid"].ToString());
                String productrefid = Request.QueryString["productrefid"].ToString();
                DataTable dt = seller.GetBillDetails(orderid, productid, productrefid);
                if (dt.Rows.Count > 0)
                {
                    LblOrderPlaceDate.Text = Convert.ToDateTime(dt.Rows[0]["orderdate"]).ToString("dd/MM/yyyy");
                    LblOrderId.Text = dt.Rows[0]["orderid"].ToString();
                    LblPaymentId.Text = dt.Rows[0]["Paymentid"].ToString();
                    LblDispatchedDate.Text = dt.Rows[0]["dispatched_date"] != null ? "Dispatched on " + Convert.ToDateTime(dt.Rows[0]["dispatched_date"]).ToString("dd/MM/yyyy") :
                    LblProductDetail.Text = dt.Rows[0]["productdetail"].ToString() + " Size:-" + dt.Rows[0]["size"].ToString() + " Color:-" + dt.Rows[0]["color"].ToString() + " Qty:-" + dt.Rows[0]["quantity"].ToString();
                    Label4.Text = dt.Rows[0]["productdetail"].ToString() + " \n(Size:-" + dt.Rows[0]["size"].ToString() + ", Color:-" + dt.Rows[0]["color"].ToString() + ", Qty:-" + dt.Rows[0]["quantity"].ToString() + ")";
                    string warranty = string.Empty;
                    if(dt.Rows[0]["warranty"].ToString()!="0" && dt.Rows[0]["warranty"].ToString() != "")
                    {
                        warranty = dt.Rows[0]["warranty"].ToString() + " Month Seller's Warranty";
                    }
                    Lblwarranty.Text = warranty;
                    LblSoldby.Text = "Sold By : " + dt.Rows[0]["SellerName"].ToString();
                    Lblheadsoldby.Text = dt.Rows[0]["SellerName"].ToString();
                    Lblperson.Text = dt.Rows[0]["Nameofthecustomer"].ToString();
                    lblheadselleraddress.Text = dt.Rows[0]["FullAdress"].ToString();
                    LblfullAddress.Text = dt.Rows[0]["full_address"].ToString() + "," + dt.Rows[0]["area_village"].ToString();
                    LblfullAddressbill.Text = dt.Rows[0]["full_address"].ToString() + "," + dt.Rows[0]["area_village"].ToString();
                    lblsellerpan.Text = dt.Rows[0]["pancardno"].ToString();
                    lblsellergst.Text = dt.Rows[0]["gst"].ToString();
                    LblDistrict.Text = dt.Rows[0]["district"].ToString();
                    LblDistrictbill.Text = dt.Rows[0]["district"].ToString();
                    LblCity.Text = dt.Rows[0]["city"].ToString();
                    LblCitybill.Text = dt.Rows[0]["city"].ToString();
                    LblState.Text = dt.Rows[0]["state_name"].ToString();
                    LblStatebill.Text = dt.Rows[0]["state_name"].ToString();
                    Lblpincode.Text = dt.Rows[0]["pincode"].ToString();
                    Lblpincodebill.Text = dt.Rows[0]["pincode"].ToString();
                    LblPaymentmode.Text = dt.Rows[0]["PaymentMode"].ToString();
                    LblNearby.Text = "Nearby : " + dt.Rows[0]["Nearby"].ToString();
                    LblNearbybill.Text = "Nearby : " + dt.Rows[0]["Nearby"].ToString();
                    LblPrice.Text = "₹ " + Math.Round(Convert.ToDouble(dt.Rows[0]["original_price"].ToString()), 0);
                    Lblsubtotal.Text = "₹ " + Math.Round(Convert.ToDouble(dt.Rows[0]["original_price"].ToString()), 0) + " X " + Math.Round(Convert.ToDouble(dt.Rows[0]["quantity"].ToString()), 0);
                    Lbldiscount.Text = "- ₹ " + Math.Round(Convert.ToDouble(dt.Rows[0]["totaldiscount"].ToString()) * Convert.ToDouble(dt.Rows[0]["quantity"].ToString()), 0);
                    LblDeliveryCharge.Text = "+ ₹ " + Math.Round(Convert.ToDouble(dt.Rows[0]["deliveryprice"].ToString()), 0);
                    LblGrandtotal.Text = "₹ " + Math.Round(Convert.ToDouble(dt.Rows[0]["Grandtotal"].ToString()), 0);


                }
            }
            catch(Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "swal('Empty', '"+ex.Message+"','error')", true);
            }
           

           
        }

        

    }
}