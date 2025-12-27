using Newtonsoft.Json.Linq;
using Org.BouncyCastle.Crypto.Tls;
using RazorpaySampleApp.Classes;
using RazorpaySampleApp.Connections.Implimentations;
using RazorpaySampleApp.ProductClass;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Web;
using System.Web.UI;

using System.Web.UI.WebControls;

namespace RazorpaySampleApp
{
    public partial class WebForm10 : System.Web.UI.Page
    {
        Double maincategoryid, subcategoryid;
        decimal productprice, productdiscountprice, deliveryprice;
        int iscashondeliver, isAcitve, returnday, replacementday,isfestiveoffer;
        string refid, productname, productbrand, productdetails, productdescription, productkeyword, productspecification,
               producttype, productcolor, productsize, image1, image2, image3, image4, image5;

       

        protected void LnkSelect_Click(object sender, EventArgs e)
        {
            RepeaterItem item = (sender as LinkButton).Parent as RepeaterItem;
            System.Web.UI.WebControls.Label id = ((System.Web.UI.WebControls.Label)item.FindControl("LblProductReferenceid")) as System.Web.UI.WebControls.Label;
            TxtreferenceProductId.Text = id.Text;
        }

        ProductListRepo productListRepo = new ProductListRepo();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["SellerLoggedintrue"] == null)
            {
                Response.Redirect("Default.aspx");
            }
            else
            {
                Session["SellerLoggedintrue"] = Session["SellerLoggedintrue"].ToString();
            }

            if (!IsPostBack)
            {
                BindMainmenu();
                defaultvalues();
                TxtreferenceProductId.Text = stringrefid() + stringrefidNumeric() + stringrefid();
                BindProudctforReference();
            }
        }

        private void BindProudctforReference()
        {
            DataTable dt = productListRepo.GetProductsref();

            RptrProducts.DataSource = dt;
            RptrProducts.DataBind();
        }
        protected void LnklistProduct_Click(object sender, EventArgs e)
        {
            try
            {

            
            if (DropdownMain.SelectedIndex.ToString() == "0")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "swal('Select Main Category', 'Please Select Main Category','error')", true);
                return;
            }
            if (DropDownSub.SelectedIndex.ToString() == "0")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "swal('Select Sub Category', 'Please Select Sub Category','error')", true);
                return;
            }
            if (string.IsNullOrEmpty(TxtProductName.Text.Trim()))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "swal('Enter Prouduct Name', 'Please Enter Prouduct','error')", true);
                return;
            }
           
            if (string.IsNullOrEmpty(TxtProductBrand.Text.Trim()))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "swal('Enter Brand', 'Please Enter Brand','error')", true);
                return;
            }
            if (string.IsNullOrEmpty(TxtProductDetails.Text.Trim()))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "swal('Enter Details', 'Please Enter Details','error')", true);
                return;
            }
            if (string.IsNullOrEmpty(TxtProductDescription.Text.Trim()))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "swal('Prouduct Description', 'Please Enter Description','error')", true);
                return;
            }
            if (string.IsNullOrEmpty(TxtProductkeyword.Text.Trim()))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "swal('Prouduct Keyword', 'Please Enter Keyword','error')", true);
                return;
            }
            if (string.IsNullOrEmpty(TxtProductSpecification.Text.Trim()))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "swal('Prouduct Specification', 'Please Enter Specification','error')", true);
                return;
            }
            if (Dropdowncolor.SelectedIndex.ToString() == "0")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "swal('Select Color', 'Please Select Color','error')", true);
                return;
            }
            if(!ProfileFileUpload.HasFile)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "swal('Choose Image1', 'Please Select Image','error')", true);
                return;
            }
            if (!ProfileFileUpload.HasFile)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "swal('Choose Image1', 'Please Select Image','error')", true);
                return;
            }
            if (!ProfileFileUpload2.HasFile)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "swal('Choose Image2', 'Please Select Image','error')", true);
                return;
            }
            if (!ProfileFileUpload3.HasFile)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "swal('Choose Image3', 'Please Select Image','error')", true);
                return;
            }
            if (!ProfileFileUpload4.HasFile)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "swal('Choose Image4', 'Please Select Image','error')", true);
                return;
            }
            if (!ProfileFileUpload5.HasFile)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "swal('Choose Image5', 'Please Select Image','error')", true);
                return;
            }
            saveproduct();///Product List Method...
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "swal('Select Main Category', '" + ex.Message + "','error')", true);
                return;
            }
        }
        private void saveproduct()
        {
            ProductClassSaveData product = new ProductClassSaveData();
            Sizeclass sizeclass = new Sizeclass();
            sizeclass.sellerid= Convert.ToInt32(Session["SellerLoggedintrue"].ToString());           
            sizeclass.productrefid= TxtreferenceProductId.Text.Trim().ToUpper();


            try
            {
                refid = TxtreferenceProductId.Text.Trim().ToUpper();
                productname = TxtProductName.Text.Trim().ToUpper();
                productbrand = TxtProductBrand.Text.Trim().ToUpper();
                productdetails = TxtProductDetails.Text.Trim().ToUpper();
                productdescription = TxtProductDescription.Text;
                productkeyword = TxtProductkeyword.Text.Trim().ToUpper();
                productspecification = TxtProductSpecification.Text;
                productcolor = Dropdowncolor.SelectedItem.Text.Trim();
                if(RdoClothing.Checked)
                {
                    productsize = DropdwnClothsize.SelectedItem.Text.Trim();
                }
                else if(RdoFootwear.Checked)
                {
                    productsize = Dropdownfoot.SelectedItem.Text.Trim();
                }
                else
                {
                    productsize = "NO SIZE";
                }
               
                if (RdoClothing.Checked)
                {
                    producttype = "CLOTHING";

                  

                }
                else if (RdoFootwear.Checked)
                {
                    producttype = "FOOTWEAR";


                   
                }
                else
                {
                    producttype = "OTHER";
                }

                maincategoryid = Convert.ToDouble(DropdownMain.SelectedItem.Value);
                subcategoryid = Convert.ToDouble(DropDownSub.SelectedItem.Value);
                productprice = Convert.ToDecimal(Txtmarkedprice.Text.Trim());
                productdiscountprice = Convert.ToDecimal(TxtProductDiscount.Text.Trim());
                deliveryprice = Convert.ToDecimal(Txtdeliveryprice.Text.Trim());
                if (ChkCashonDelivery.Checked == true)
                {
                    iscashondeliver = 1;
                }
                else
                {
                    iscashondeliver = 0;
                }
                isAcitve = 1;
               
                //0.No offer 1.Limited Time Deal 2.festive Offer
                if (RdoFestival.Checked == true)
                {
                    isfestiveoffer = 2;
                }
                else if (RdoLimitedtimeOffer.Checked == true)
                {
                    isfestiveoffer = 1;
                }
                else
                {
                    isfestiveoffer = 0;
                }

                if (RdoReturn.Checked == true)
                {
                    returnday = Convert.ToInt32(Txtreturnday.Text);
                }
                else if (RdoReplcement.Checked == true)
                {
                    replacementday = Convert.ToInt32(TxtReplacementday.Text);
                }
                else
                {
                    returnday = 0;
                    replacementday = 0;
                }

                string path = "~/Images/ProductImages/"+ TxtreferenceProductId.Text.Trim()+"/";
                string pathcreate = Path.Combine(Server.MapPath("~/Images/ProductImages/"), TxtreferenceProductId.Text.Trim());
                if (!Directory.Exists(pathcreate))
                {
                    Directory.CreateDirectory(pathcreate);
                }
                String Timestamp = DateTime.Now.ToString("yyyyMMddHHss");
                string pathsave1 = Path.Combine(path, Timestamp + "_"+ProfileFileUpload.FileName);
                string pathupload1 = Path.Combine(Server.MapPath(path), Timestamp + "_" + ProfileFileUpload.FileName);
                string pathsave2 = Path.Combine(path, Timestamp + "_" + ProfileFileUpload2.FileName);
                string pathupload2 = Path.Combine(Server.MapPath(path), Timestamp + "_" + ProfileFileUpload2.FileName);
                string pathsave3 = Path.Combine(path, Timestamp + "_" + ProfileFileUpload3.FileName);
                string pathupload3 = Path.Combine(Server.MapPath(path),  Timestamp + "_"+ProfileFileUpload3.FileName);
                string pathsave4 = Path.Combine(path,  Timestamp + "_"+ProfileFileUpload4.FileName);
                string pathupload4 = Path.Combine(Server.MapPath(path),  Timestamp + "_"+ProfileFileUpload4.FileName);
                string pathsave5 = Path.Combine(path,  Timestamp + "_"+ProfileFileUpload5.FileName);
                string pathupload5 = Path.Combine(Server.MapPath(path),  Timestamp + "_"+ProfileFileUpload5.FileName);


                image1 = pathsave1;
                image2 = pathsave2;
                image3 = pathsave3;
                image4 = pathsave4;
                image5 = pathsave5;

                product.Sellerid = Convert.ToInt32(Session["SellerLoggedintrue"].ToString());
                product.refId = refid;
                product.Maincatid = maincategoryid;
                product.Subcatid = subcategoryid;
                product.ProductName = productname;
                product.ProducBrand = productbrand;
                product.ProductDeails = productdetails;
                product.ProductDescription = productdescription;
                product.ProductKeywords = productkeyword;
                product.ProductSpecification = productspecification;
                product.ProductType = producttype;
                product.ProductColor = productcolor;
                product.ProductSize = productsize;
                product.ProductPrice = productprice;
                product.ProductDiscount = productdiscountprice;
                product.Iscod = iscashondeliver;
                product.isFestiveOffer = isfestiveoffer;
                product.isActiveNow = isAcitve;
                product.ReturnDay = returnday;
                product.ReplacementDay = replacementday;
                product.DeliveryPrice = deliveryprice;
                product.avl_qty = Convert.ToInt32(Txtavlquantity.Text);
                product.Image1 = image1;
                product.Image2 = image2;
                product.Image3 = image3;
                product.Image4 = image4;
                product.Image5 = image5;
                product.warranty = Txtwarant.Text.Trim()==""?0: Convert.ToInt32(Txtwarant.Text.Trim());

                int i = productListRepo.SaveProduct(product);
                sizeclass.Prodcutid = productListRepo.Getproductid(TxtreferenceProductId.Text.Trim());
                if (i > 0)
                {
                    if (RdoClothing.Checked)
                    {
                        

                        if (!string.IsNullOrEmpty(TxtsmallsizeQuantity.Text.Trim()))
                        {
                            sizeclass.size = "S";
                            sizeclass.qty = Convert.ToInt32(TxtsmallsizeQuantity.Text.Trim());
                            productListRepo.Saveproducts(sizeclass);
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "swal('Enter Size', 'Enter Small Size Or '0'','error')", true);
                            return;
                        }

                        if (!string.IsNullOrEmpty(TxtmediumsizeQuantity.Text.Trim()))
                        {
                            sizeclass.size = "M";
                            sizeclass.qty = Convert.ToInt32(TxtmediumsizeQuantity.Text.Trim());
                            productListRepo.Saveproducts(sizeclass);
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "swal('Enter Size', 'Enter Medium Size Or '0'','error')", true);
                            return;
                        }


                        if (!string.IsNullOrEmpty(TxtlargesizeQuantity.Text.Trim()))
                        {
                            sizeclass.size = "L";
                            sizeclass.qty = Convert.ToInt32(TxtlargesizeQuantity.Text.Trim());
                            productListRepo.Saveproducts(sizeclass);
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "swal('Enter Size', 'Enter Large Size Or '0'','error')", true);
                            return;
                        }

                        if (!string.IsNullOrEmpty(TxtxlsizeQuantity.Text.Trim()))
                        {
                            sizeclass.size = "XL";
                            sizeclass.qty = Convert.ToInt32(TxtxlsizeQuantity.Text.Trim());
                            productListRepo.Saveproducts(sizeclass);
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "swal('Enter Size', 'Enter Xl Size Or '0'','error')", true);
                            return;
                        }

                        if (!string.IsNullOrEmpty(TxtxxlsizeQuantity.Text.Trim()))
                        {
                            sizeclass.size = "XXL";
                            sizeclass.qty = Convert.ToInt32(TxtxxlsizeQuantity.Text.Trim());
                            productListRepo.Saveproducts(sizeclass);
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "swal('Enter Size', 'Enter XXl Size Or '0'','error')", true);
                            return;
                        }

                    }
                    else if (RdoFootwear.Checked)
                    {
                       


                        if (!string.IsNullOrEmpty(Txtsize4.Text.Trim()))
                        {
                            sizeclass.size = "4";
                            sizeclass.qty = Convert.ToInt32(Txtsize4.Text.Trim());
                            productListRepo.Saveproducts(sizeclass);
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "swal('Enter Size', 'Enter 4 Number Size Or '0'','error')", true);
                            return;
                        }

                        if (!string.IsNullOrEmpty(Txtsize5.Text.Trim()))
                        {
                            sizeclass.size = "5";
                            sizeclass.qty = Convert.ToInt32(Txtsize5.Text.Trim());
                            productListRepo.Saveproducts(sizeclass);
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "swal('Enter Size', 'Enter 5 Number Size Or '0'','error')", true);
                            return;
                        }

                        if (!string.IsNullOrEmpty(Txtsize6.Text.Trim()))
                        {
                            sizeclass.size = "6";
                            sizeclass.qty = Convert.ToInt32(Txtsize6.Text.Trim());
                            productListRepo.Saveproducts(sizeclass);
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "swal('Enter Size', 'Enter 6 Number Size Or '0'','error')", true);
                            return;
                        }
                        if (!string.IsNullOrEmpty(Txtsize7.Text.Trim()))
                        {
                            sizeclass.size = "7";
                            sizeclass.qty = Convert.ToInt32(Txtsize7.Text.Trim());
                            productListRepo.Saveproducts(sizeclass);
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "swal('Enter Size', 'Enter 7 Number Size Or '0'','error')", true);
                            return;
                        }

                        if (!string.IsNullOrEmpty(Txtsize8.Text.Trim()))
                        {
                            sizeclass.size = "8";
                            sizeclass.qty = Convert.ToInt32(Txtsize8.Text.Trim());
                            productListRepo.Saveproducts(sizeclass);
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "swal('Enter Size', 'Enter 8 Number Size Or '0'','error')", true);
                            return;
                        }

                        if (!string.IsNullOrEmpty(Txtsize9.Text.Trim()))
                        {
                            sizeclass.size = "9";
                            sizeclass.qty = Convert.ToInt32(Txtsize9.Text.Trim());
                            productListRepo.Saveproducts(sizeclass);
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "swal('Enter Size', 'Enter 9 Number Size Or '0'','error')", true);
                            return;
                        }

                        if (!string.IsNullOrEmpty(Txtsize10.Text.Trim()))
                        {
                            sizeclass.size = "10";
                            sizeclass.qty = Convert.ToInt32(Txtsize10.Text.Trim());
                            productListRepo.Saveproducts(sizeclass);
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "swal('Enter Size', 'Enter 10 Number Size Or '0'','error')", true);
                            return;
                        }

                        if (!string.IsNullOrEmpty(Txtsize11.Text.Trim()))
                        {
                            sizeclass.size = "11";
                            sizeclass.qty = Convert.ToInt32(Txtsize11.Text.Trim());
                            productListRepo.Saveproducts(sizeclass);
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "swal('Enter Size', 'Enter 11 Number Size Or '0'','error')", true);
                            return;
                        }

                        if (!string.IsNullOrEmpty(Txtsize12.Text.Trim()))
                        {
                            sizeclass.size = "12";
                            sizeclass.qty = Convert.ToInt32(Txtsize12.Text.Trim());
                            productListRepo.Saveproducts(sizeclass);
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "swal('Enter Size', 'Enter 12 Number Size Or '0'','error')", true);
                            return;
                        }
                    }
                    ProfileFileUpload.SaveAs(pathupload1);
                    ProfileFileUpload2.SaveAs(pathupload2);
                    ProfileFileUpload3.SaveAs(pathupload3);
                    ProfileFileUpload4.SaveAs(pathupload4);
                    ProfileFileUpload5.SaveAs(pathupload5);
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "swal('Product Listed', 'Product Listed Successfully','success')", true);
                    BindProudctforReference();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "swal('Error !', 'Not Listed','error')", true);
                }
            }
            catch(Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "swal('Correct Value', '" + ex.Message + "','error')", true);
            }

           


        }

        private string stringrefid()
        {
            char[] alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
            Random random = new Random();
            string s = string.Empty;
            for(int i=0;i<6;i++)
            {
                s += alphabet[random.Next(0, alphabet.Length)].ToString();
            }
            return s;
        }

        private string stringrefidNumeric()
        {
            int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            Random random = new Random();
            string s = string.Empty;
            for (int i = 0; i < 6; i++)
            {
                s += numbers[random.Next(0, numbers.Length)].ToString();
            }
            return s;
        }

        private void defaultvalues()
        {
            Txtmarkedprice.Text = "0";
            TxtProductDiscount.Text = "0";
            Txtdeliveryprice.Text = "0";
            Txtreturnday.Text = "0";
            TxtReplacementday.Text = "0";
            Txtavlquantity.Text = "0";
            TxtsmallsizeQuantity.Text = "0";
            TxtmediumsizeQuantity.Text = "0";
            TxtlargesizeQuantity.Text = "0";
            TxtxlsizeQuantity.Text = "0";
            TxtxxlsizeQuantity.Text = "0";
            Txtwarant.Text = "0";


            Txtsize4.Text = "0";
            Txtsize5.Text = "0";
            Txtsize6.Text = "0";
            Txtsize7.Text = "0";
            Txtsize8.Text = "0";
            Txtsize9.Text = "0";
            Txtsize10.Text = "0";
            Txtsize11.Text = "0";
            Txtsize12.Text = "0";


        }

       private void BindMainmenu()
        {
            try
            {
                DataTable dt= productListRepo.GetAllMainmenu();
                DropdownMain.DataSource = dt;
                DropdownMain.DataTextField = "Catname";
                DropdownMain.DataValueField = "id";                
                DropdownMain.DataBind();
                DropdownMain.Items.Insert(0, new ListItem("Choose maincategory", "0"));
            }
            catch(Exception ex) {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert","swal('Correct Value', '"+ex.Message+"','error')", true);
            }
        }

        private void BindSubmenu(Double mainid)
        {
            try
            {
                DataTable dt = productListRepo.GetAllSubmenu(mainid);
                DropDownSub.DataSource = dt;
                DropDownSub.DataTextField = "SubCatName";
                DropDownSub.DataValueField = "id";                
                DropDownSub.DataBind();
                DropDownSub.Items.Insert(0, new ListItem("Choose subcategory", "0"));
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "swal('Correct Value', '" + ex.Message + "','error')", true);
            }
        }       

       

        protected void DropdownMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindSubmenu(Convert.ToDouble(DropdownMain.SelectedItem.Value));
        }
    }
}