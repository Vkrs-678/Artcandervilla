<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="ProductCart.aspx.cs" Inherits="RazorpaySampleApp.WebForm17" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
    <style>
        #colproductscroll::-webkit-scrollbar {
            display: none;
        }
        .shad:hover{
            box-shadow:2px 2px 5px #808080;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">  
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="container" style="margin-top: 100px;">
                <div class="row">
                    <asp:LinkButton ID="LinkButton1" style="display:none" runat="server">LinkButton</asp:LinkButton>
                    <div id="colproductscroll" class="col-12 col-sm-12 col-md-8 col-lg-7 col-xl-6 " style="height: 55vh; overflow-y: scroll">
                        <!---1---->
                        <asp:Repeater ID="Repeater" OnItemDataBound="Repeater_ItemDataBound" runat="server">
                            <ItemTemplate>
                                
                                <div class="row">
                                    <asp:HiddenField ID="Hdnproductid" Value='<%#Eval("product_id")%>' runat="server" />
                                    <asp:HiddenField ID="Hdnproductrefid" Value='<%#Eval("ref_productid")%>' runat="server" />
                                    <asp:HiddenField ID="Hdnavailableqty" Value='<%#Eval("purchasedquantity")%>' runat="server" />
                                    <asp:HiddenField ID="Hdnavlqty" Value='<%#Eval("newavlqty")%>' runat="server" />
                                    <asp:HiddenField ID="HdnactualQuantity" Value='<%#Eval("Avl_Quantity")%>' runat="server" />
                                    <asp:HiddenField ID="HdnproductType" Value='<%#Eval("productType")%>' runat="server" />
                                    <asp:Label ID="Label1" runat="server" style="display:none" CssClass="lblcod" Text='<%#Eval("iscod")%>'></asp:Label>
                                    <div class="col-5 col-sm-5 col-md-6 col-lg-4 col-xl-3" style="text-align: center">
                                        <a href="Productdetailpage.aspx?productid=<%#Eval("product_id") %>&&productrefid=<%#Eval("ref_productid") %>">
                                        <asp:Image ID="Image1" CssClass="img-fluid img-thumbnail" ImageUrl='<%#Eval("image1")%>' Style="height: 160px; width: 150px" runat="server" />
                                            </a>
                                    </div>
                                    <div class="col-7 col-sm-7 col-md-6 col-lg-8 col-xl-9">
                                        <div>
                                            <asp:Label ID="lblproductname" runat="server" Font-Bold="true" Font-Size="Large" ForeColor="HotPink" Font-Italic="true" Text='<%#Eval("productname")%>'></asp:Label>
                                        </div>
                                        <div>
                                            <asp:Label ID="Lblproductsize" runat="server" Font-Bold="true" Font-Size="small" ForeColor="GrayText" Font-Italic="true" Text='<%#"Size:"+" "+Eval("productsize").ToString()+" "+"&"%>'></asp:Label>
                                            <asp:Label ID="lblproductcolor" runat="server" Font-Bold="true" Font-Size="small" ForeColor="GrayText" Font-Italic="true" Text='<%#"Color:"+" "+Eval("productcolor").ToString()%>'></asp:Label>
                                        </div>
                                        <div class="d-flex">
                                            <asp:Label ID="Label3" runat="server" Font-Bold="true" Font-Size="x-small" ForeColor="#00ff00" Font-Italic="true" Text="in Stock"></asp:Label>&nbsp;
                                            <asp:Label ID="Label4" runat="server" Font-Bold="true" Font-Size="x-small" ForeColor="#0033cc" Font-Italic="true" Text='<%#Eval("iscod").ToString()=="1"?"COD Availabele":"COD Not Available"%>'></asp:Label>
                                        </div>
                                        <div>
                                            <asp:Label ID="lblfreedeliver" runat="server" Font-Bold="true" Font-Size="x-small" ForeColor="GrayText" Font-Italic="true" Text='<%#Eval("deliveryprice").ToString()=="0"?"Eligible for Free Delivery":"Delivery Charge Applicable"%>'></asp:Label>
                                        </div>
                                        <div class="d-flex">
                                            <asp:Label ID="Label5" runat="server" Font-Bold="true" Font-Size="small" ForeColor="Black" Font-Italic="true" Text="₹"></asp:Label>
                                            <asp:Label ID="lblacturalprice" runat="server" Font-Bold="true" Font-Size="small" ForeColor="Black" Font-Italic="true" Text='<%#Eval("finalprice")%>'></asp:Label>
                                            &nbsp;<asp:Label ID="lbldiscount" runat="server" Font-Bold="true" Font-Size="small" ForeColor="Black" Font-Italic="true" Text='<%#"after (-"+Eval("productdiscount")+"% OFF)"%>'></asp:Label>
                                            <asp:HiddenField ID="Hiddendiscountpercent" Value='<%#Eval("productdiscount")%>' runat="server" />
                                        </div>
                                        <div class="d-flex">

                                        </div>
                                        <div style="display:flex;justify-content:space-between;align-items:end;">
                                            <asp:DropDownList ID="dropselectQuantity" AutoPostBack="true" OnSelectedIndexChanged="dropselectQuantity_SelectedIndexChanged" runat="server">
                                                <asp:ListItem Value="1" Text="1">1</asp:ListItem>
                                                <asp:ListItem Value="2" Text="2">2</asp:ListItem>
                                                <asp:ListItem Value="3" Text="3">3</asp:ListItem>
                                                <asp:ListItem Value="4" Text="4">4</asp:ListItem>
                                                <asp:ListItem Value="5" Text="5">5</asp:ListItem>
                                                <asp:ListItem Value="6" Text="6">6</asp:ListItem>
                                                <asp:ListItem Value="7" Text="7">7</asp:ListItem>
                                                <asp:ListItem Value="8" Text="8">8</asp:ListItem>
                                                <asp:ListItem Value="9" Text="9">9</asp:ListItem>
                                                <asp:ListItem Value="10" Text="10">10</asp:ListItem>
                                            </asp:DropDownList>
                                            <asp:LinkButton ID="Btnremoveproduct" OnClick="Btnremoveproduct_Click" style="text-decoration:none;color:white!important" CssClass="badge bg-dark" runat="server">Remove</asp:LinkButton>
                                        </div>





                                    </div>
                                </div>
                                   
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                    <div class="col-12 col-sm-12 col-md-4 col-lg-5 col-xl-6">

                        <div class="row mt-3">
                            <div class="col" style="display: flex; justify-content: space-between; align-content: end">
                                <asp:Label ID="Label10" runat="server" Font-Bold="true" Font-Size="Large" ForeColor="HotPink" Font-Italic="true" Text="Total Amount :"></asp:Label>
                                <asp:Label ID="lblTotalAmount" runat="server" Font-Bold="true" Font-Size="Large" ForeColor="HotPink" Font-Italic="true" Text="₹ 499"></asp:Label>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col" style="display: flex; justify-content: space-between; align-content: end">
                                <asp:Label ID="Label15" runat="server" Font-Bold="true" Font-Size="Large" ForeColor="HotPink" Font-Italic="true" Text="Total Discount :"></asp:Label>
                                <asp:Label ID="Lbltotaldiscount" runat="server" Font-Bold="true" Font-Size="Large" ForeColor="HotPink" Font-Italic="true" Text="- ₹ 200"></asp:Label>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col" style="display: flex; justify-content: space-between; align-content: end">
                                <asp:Label ID="Label13" runat="server" Font-Bold="true" Font-Size="Large" ForeColor="HotPink" Font-Italic="true" Text="Delivery charge :"></asp:Label>
                                <asp:Label ID="LbltotalDeliverycharge" runat="server" Font-Bold="true" Font-Size="Large" ForeColor="HotPink" Font-Italic="true" Text="+₹ 200"></asp:Label>
                            </div>
                        </div>
                        <hr />
                        <div class="row">
                            <div class="col" style="display: flex; justify-content: space-between; align-content: end">
                                <asp:Label ID="Label17" runat="server" Font-Bold="true" Font-Size="Large" ForeColor="HotPink" Font-Italic="true" Text="Total Payable Amount :"></asp:Label>
                                <asp:Label ID="lbltotalpayableAmont" runat="server" Font-Bold="true" Font-Size="Large" ForeColor="HotPink" Font-Italic="true" Text="₹ 499"></asp:Label>
                            </div>
                        </div>
                        <hr />
                        <div class="row">
                            <div class="col" style="display: flex; justify-content: space-between; align-content: end">
                                <asp:RadioButton ID="RdoCOD" onclick="Checkcod();" GroupName="Paymode" runat="server" />
                                <asp:Label ID="Label19" runat="server" Font-Bold="true" Font-Size="Large" ForeColor="HotPink" Font-Italic="true" Text="COD"></asp:Label>

                            </div>
                        </div>
                        <div class="row">
                            <div class="col" style="display: flex; justify-content: space-between; align-content: end">
                                <asp:RadioButton ID="RdoPaynow" Checked="true" GroupName="Paymode" runat="server" />
                                <asp:Label ID="Label20" runat="server" Font-Bold="true" Font-Size="Large" ForeColor="HotPink" Font-Italic="true" Text="Pay Now"></asp:Label>

                            </div>
                        </div>
                        <div class="row p-4">
                            <asp:LinkButton ID="LnkBuynow" OnClick="LnkBuynow_Click" CssClass="btn btn-dark" runat="server">Buy Now</asp:LinkButton>
                        </div>

                    </div>

                </div>
            </div>

            <asp:Label ID="Label2" runat="server" Text='<%#Eval("Time") %>'></asp:Label>
            <asp:UpdateProgress ID="UpdateProgress1" DisplayAfter="10" runat="server">
                <ProgressTemplate>
                    <center>
                        <img src="Images/Loader/loader.gif" class="img-fluid" height="30" width="40" />
                    </center>
                </ProgressTemplate>
            </asp:UpdateProgress>
        </ContentTemplate>
    </asp:UpdatePanel>
    <script>
        function Checkcod() {
            var codrdo = document.getElementById('<%=RdoCOD.ClientID%>');
            var iscodhdn = document.getElementsByClassName('lblcod');

            for (let i = 0; i < iscodhdn.length; i++) {
                if (iscodhdn[i].innerHTML == "0") {
                    codrdo.checked = false;
                    swal('COD', 'Part of Your Order Not Eligible for COD', 'error')
                }
            }

        }
        function openModal() { document.getElementById('<%=LinkButton1.ClientID%>').click(); }
    </script>
</asp:Content>
