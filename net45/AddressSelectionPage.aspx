<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="AddressSelectionPage.aspx.cs" Inherits="RazorpaySampleApp.WebForm18" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
              <!--searapi--->
  
 <link rel="stylesheet" href="http://code.jquery.com/ui/1.10.3/themes/smoothness/jquery-ui.css"/>
 
    <style>
        .shad:hover {
            box-shadow: 5px 5px 10px #808080 !important;
        }

        .textarea {
            box-shadow: none;
            outline: none;
        }
    </style>
 
 <script>
     
     function openModal() { $('#Button1').trigger('click'); }

     var obj = { status: false, ele: null };
     function AreYouSureDelete(ev) {
         if (obj.status) {
             return true;
         };
         swal({
             title: "Delete?",
             text: "Address Will be Deleted ?",
             type: "warning",
             showCancelButton: true,
             confirmButtonClass: "btn-danger",
             confirmButtonText: "Yes, Delete",
             closeOnConfirm: true
         },
             function () {
                 obj.status = true;
                 obj.ele = ev;
                 obj.ele.click();
             });

         return false;
     }
 </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container rounded" style="margin-top: 100px">
        <div class="d-flex">
            
             <a id="btns" style="text-decoration:underline;color:#030edc;cursor:pointer" data-bs-toggle="modal" data-bs-target="#openAddressbar">Add-Address</a>           
           
           
        </div>  
        <asp:Label ID="lblwarning" runat="server" Font-Bold="true" ForeColor="Red"></asp:Label>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                 <div class="row">
                <asp:Repeater ID="RepeaterbindAddress" OnItemDataBound="RepeaterbindAddress_ItemDataBound" runat="server">
                    <ItemTemplate>                       
                            <div class="col-6 col-sm-6 col-md-4 col-lg-3 col-xl-3">
                                                      
 
                                <div id="selectdiv"  class="p-3 shad my-4">
                                    <div class="row" onclick="radio(this);" style="cursor:pointer">
                                        <div class="col-1">
                                            <asp:RadioButton ID="RdoSelection" Class="rdobutton d-none" GroupName="turw" style="cursor:pointer" AutoPostBack="true"  OnCheckedChanged="RdoSelection_CheckedChanged" runat="server" />
                                           
                                        </div>
                                        <div class="col-11">
                                            <asp:HiddenField ID="Hdnuserid" Value='<%#Eval("userid")%>' runat="server" />
                                            <asp:Label ID="lblSelected" Visible="false" ForeColor="Green" Font-Bold="true" runat="server" Text="✔"></asp:Label><br />
                                            <asp:HiddenField ID="HdnAddressid" Value='<%#Eval("address_id")%>' runat="server"/>
                                            <asp:HiddenField ID="Hdnisdefult" Value='<%#Eval("isdefault")%>' runat="server"/>
                                            <asp:Label ID="Label1" runat="server" Font-Bold="true" Font-Size="Medium" Text='<%#Eval("Nameofthecustomer") %>'></asp:Label><br />
                                            <asp:Label ID="Label2" Font-Bold="true" Font-Size="Small" ForeColor="GrayText" runat="server" Text='<%#Eval("Mobile_no") %>'></asp:Label>&nbsp;&nbsp;&nbsp;<br />
                                            <asp:Label ID="Label3" Font-Bold="true" Font-Size="Small" ForeColor="GrayText" runat="server" Text='<%#Eval("full_address").ToString()+" "+Eval("area_village") %>'></asp:Label>&nbsp;&nbsp;&nbsp;<br />
                                            <asp:Label ID="Label4" Font-Bold="true" Font-Size="Small" ForeColor="GrayText" runat="server" Text='<%#Eval("district") %>'></asp:Label>&nbsp;&nbsp;&nbsp;<br />
                                            <asp:Label ID="Label5" Font-Bold="true" Font-Size="Small" ForeColor="GrayText" runat="server" Text='<%#Eval("city") %>'></asp:Label>&nbsp;&nbsp;&nbsp;<br />
                                            <asp:Label ID="Label6" Font-Bold="true" Font-Size="Small" ForeColor="GrayText" runat="server" Text='<%#Eval("state_name").ToString()+"-"+Eval("pincode") %>'></asp:Label>&nbsp;&nbsp;&nbsp;<br />
                                        </div>
                                    </div>
                                    <asp:LinkButton ID="LnkRemoveAddress" OnClientClick="return AreYouSureDelete(this);" OnClick="LnkRemoveAddress_Click" runat="server">Remove</asp:LinkButton>
                                   
                                </div>
                            </div>
                       
                    </ItemTemplate>
                </asp:Repeater>
                     <asp:LinkButton ID="LinkButton1" OnClick="LinkButton1_Click" CssClass="btn btn-dark" Visible="false" runat="server">Proceed To PlaceOrder</asp:LinkButton>
                      </div>
            </ContentTemplate>
        </asp:UpdatePanel>
        <!---modal for add address---->
        <div class="modal fade" id="openAddressbar" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
            <div class="modal-dialog modal-lg">
                <div class="modal-content">

                    <button type="button" class="btn-close ms-auto" data-bs-dismiss="modal" aria-label="Close"></button>
                    <div class="modal-body">
                        <div class="form-floating mb-3 ">
                            <asp:TextBox ID="TxtEnterName" CssClass="form-control" placeholder="Enter Name" runat="server"></asp:TextBox>

                            <label for="floatingInput">Your Name</label>
                        </div>
                    </div>
                    <div class="modal-body">
                        <div class="form-floating mb-3 ">
                            <asp:TextBox ID="TxtMobileNumber" TextMode="Phone" MaxLength="10" CssClass="form-control" placeholder="Mobile Number" runat="server"></asp:TextBox>
                            <label for="floatingInput">Mobile Number</label>
                        </div>
                       
                    </div>
                    <div class="modal-body">
                        <div class="mb-3 ">
                            <asp:TextBox ID="TxtFulladdress" TextMode="MultiLine" Rows="5" Style="resize: none" CssClass="form-control" placeholder="Full Address" runat="server"></asp:TextBox>

                        </div>
                    </div>
                    <div class="modal-body">
                        <div class="form-floating mb-3 ">
                            <asp:TextBox ID="Txtareavillage" CssClass="form-control" placeholder="Mobile Number" runat="server"></asp:TextBox>
                            <label for="floatingInput">Area/Village</label>
                        </div>
                    </div>

                    <div class="modal-body">
                        <div class="form-floating mb-3 ">
                            <asp:TextBox ID="Txtdistrict" CssClass="form-control" placeholder="District" runat="server"></asp:TextBox>
                            <label for="floatingInput">District</label>
                        </div>
                    </div>

                    <div class="modal-body">
                        <div class="form-floating mb-3 ">
                            <asp:TextBox ID="Txtcity" CssClass="form-control" placeholder="City" runat="server"></asp:TextBox>
                            <label for="floatingInput">City</label>
                        </div>
                    </div>


                    <div class="modal-body">
                        <div class="form-floating mb-3 ">
                            <asp:DropDownList ID="ddlStates" CssClass="form-control" runat="server"></asp:DropDownList>

                            <label for="floatingInput"></label>
                        </div>
                    </div>

                    <div class="modal-body">
                        <div class="form-floating mb-3 ">
                            <asp:TextBox ID="Txtpincode" TextMode="Phone" MaxLength="6" CssClass="form-control" placeholder="Mobile Number" runat="server"></asp:TextBox>
                            <label for="floatingInput">Pincode</label>
                        </div>
                    </div>
                    <div class="modal-body">
                        <div class="form-floating mb-3 ">
                            <asp:TextBox ID="TxtNearbyAddress" CssClass="form-control" placeholder="Mobile Number" runat="server"></asp:TextBox>
                            <label for="floatingInput">Nearby</label>
                        </div>
                    </div>
                   
                      <div class="modal-body">
                          <div class="form-floating mb-3 ">                               
                              <asp:TextBox ID="Txtemailaddress" onchange="Checkmob(this);" TextMode="Email" CssClass="form-control" placeholder="Mobile Number" runat="server"></asp:TextBox>
                              <label for="floatingInput">E-Mail</label>
                          </div>
                           <label id="mobno"></label>
                      </div>
                    <div class="m-3">
                        <asp:Button ID="BtnAddadress" Width="100%" OnClick="BtnAddadress_Click" CssClass="btn btn-dark" runat="server" Text="Add Address" />
                    </div>

                </div>
            </div>
        </div>
    </div>   
      <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <script src="http://code.jquery.com/jquery-1.9.1.js"></script>
<script src="http://code.jquery.com/ui/1.10.3/jquery-ui.js"></script> 
    <%-- <script src="https://code.jquery.com/jquery-3.7.1.min.js" integrity="sha256-/JqT3SQfawRcv/BIHPThkBvs0OEvtFFmqPF/lYI/Cxo=" crossorigin="anonymous"></script>--%>
    <script>
        function Checkmob(ev) {
           
            var a = ev.value;
            if (a.includes('@')==false) {
                document.getElementById('mobno').innerText = 'Enter Valid Email id';
                document.getElementById('mobno').style.color = 'red';
                ev.value = "";

            }
            else {
                document.getElementById('mobno').innerHTML = '';
            }
        }

        function radio(ev) {
            var radio = ev.getElementsByTagName('input')[0];
            radio.click();
        }
    </script>

</asp:Content>

