using RazorpaySampleApp.AdressClass;
using RazorpaySampleApp.Connections.Implimentations;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RazorpaySampleApp
{
    public partial class WebForm18 : System.Web.UI.Page
    {
        AddressRepo addresses = new AddressRepo();
        protected void Page_Load(object sender, EventArgs e)
        {
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
                // Call a method to populate the dropdown list
                PopulateStatesDropDown();
                BindRepeater();
            }
        }

        private void BindRepeater()
        {
            DataTable dt = addresses.GetallAddress(Session["UserLoginTrue"].ToString());

            RepeaterbindAddress.DataSource = dt;
            RepeaterbindAddress.DataBind();
        }

        private void PopulateStatesDropDown()
        {
            // Create a list of states (you can replace this with a database query)
            string[] states = {
        "Andhra Pradesh", "Arunachal Pradesh", "Assam", "Bihar", "Chhattisgarh",
        "Goa", "Gujarat", "Haryana", "Himachal Pradesh", "Jharkhand", "Karnataka",
        "Kerala", "Madhya Pradesh", "Maharashtra", "Manipur", "Meghalaya", "Mizoram",
        "Nagaland", "Odisha", "Punjab", "Rajasthan", "Sikkim", "Tamil Nadu", "Telangana",
        "Tripura", "Uttar Pradesh", "Uttarakhand", "West Bengal", "Andaman and Nicobar Islands",
        "Chandigarh", "Dadra and Nagar Haveli", "Daman and Diu", "Lakshadweep", "Delhi", "Puducherry"
                };

            // Bind the states to the dropdown list
            ddlStates.DataSource = states;
            ddlStates.DataBind();
            ddlStates.Items.Insert(0, new ListItem("Choose State"));
        }


        private void InsertAddress()
        {
            if(string.IsNullOrEmpty(TxtEnterName.Text.Trim()))
            {
                lblwarning.Text = "Please Enter Your Name";
                return;
            }
            if (string.IsNullOrEmpty(TxtMobileNumber.Text.Trim()))
            {
                lblwarning.Text = "Please Enter Your Mobile Number";
                return;
            }
            if (string.IsNullOrEmpty(TxtFulladdress.Text.Trim()))
            {
                lblwarning.Text = "Please Enter Full Address";
                return;
            }
            if (string.IsNullOrEmpty(Txtareavillage.Text.Trim()))
            {
                lblwarning.Text = "Please Enter Area/Village";
                return;
            }
            if (string.IsNullOrEmpty(Txtdistrict.Text.Trim()))
            {
                lblwarning.Text = "Please Enter District";
                return;
            }
            if (string.IsNullOrEmpty(Txtcity.Text.Trim()))
            {
                lblwarning.Text = "Please Enter City";
                return;
            }
            if (ddlStates.SelectedIndex.ToString()=="0")
            {
                lblwarning.Text = "Please Enter State";
                return;
            }
            if (string.IsNullOrEmpty(Txtpincode.Text.Trim()))
            {
                lblwarning.Text = "Please Enter Pincode";
                return;
            }
            if (string.IsNullOrEmpty(TxtNearbyAddress.Text.Trim()))
            {
                lblwarning.Text = "Please Enter Nearby Location";
                return;
            }
            if (string.IsNullOrEmpty(Txtemailaddress.Text.Trim()))
            {
                lblwarning.Text = "Please Enter Email";
                return;
            }
            try
            {
                Addrestable address = new Addrestable();
                address.userid = Session["UserLoginTrue"].ToString();
                address.Name = TxtEnterName.Text.Trim();
                address.MobileNumber = Convert.ToDouble(TxtMobileNumber.Text.Trim());
                address.FullAddress = TxtFulladdress.Text.Trim();
                address.Areavillage = Txtareavillage.Text.Trim();
                address.District = Txtdistrict.Text.Trim();
                address.city = Txtcity.Text.Trim();
                address.State = ddlStates.SelectedItem.Text;
                address.Pincode = Convert.ToInt32(Txtpincode.Text.Trim());
                address.NearbyPlace = TxtNearbyAddress.Text.Trim();
                address.email = Txtemailaddress.Text.Trim();
                int i= addresses.InsertAddress(address);
                if(i>0)
                {
                    BindRepeater();
                    lblwarning.Text = string.Empty;
                }
            }
            catch(Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "swal('Exception !', '"+ex.Message+"', 'error')", true);
            }
        }

        protected void BtnAddadress_Click(object sender, EventArgs e)
        {
            InsertAddress();
        }

        protected void RdoSelection_CheckedChanged(object sender, EventArgs e)
        {
            RepeaterItem item = (sender as RadioButton).Parent as RepeaterItem;
            HiddenField uerid = (HiddenField)item.FindControl("Hdnuserid");
            HiddenField addressid = (HiddenField)item.FindControl("HdnAddressid");
            RadioButton rdobutton = (RadioButton)item.FindControl("RdoSelection");
            
            /*int i =*/ addresses.UpdateAddressTable(uerid.Value, Convert.ToDouble(addressid.Value));
            if(rdobutton.Checked==true)
            {
                rdobutton.Checked = false;
            }
            BindRepeater();
            LinkButton1.Visible = true;
        }

        protected void RepeaterbindAddress_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if(e.Item.ItemType==ListItemType.AlternatingItem || e.Item.ItemType==ListItemType.Item)
            {
                HiddenField hdndefaultvalue = (HiddenField)e.Item.FindControl("Hdnisdefult");
               // RadioButton Radiocheck = (RadioButton)e.Item.FindControl("RdoSelection");
                Label lblSelected = (Label)e.Item.FindControl("lblSelected");

                if(hdndefaultvalue.Value=="1")
                {
                    if(IsPostBack)
                    {
                        lblSelected.Visible = true;
                    }
                   
                  

                }
            }
        }

        protected void LnkRemoveAddress_Click(object sender, EventArgs e)
        {
            RepeaterItem item = (sender as LinkButton).Parent as RepeaterItem;
            HiddenField id = ((HiddenField)item.FindControl("HdnAddressid")) as HiddenField;
            /*int i =*/ addresses.DeleteAddressTable(Convert.ToDouble(id.Value));

            BindRepeater();
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Placeorder.aspx");
        }
    }
}