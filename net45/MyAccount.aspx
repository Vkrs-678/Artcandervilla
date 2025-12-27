<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="MyAccount.aspx.cs" Inherits="RazorpaySampleApp.WebForm23" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        
         <div class="row" style="margin-top: 100px;">
             <div style="text-align:right">
                 <a href="#" data-bs-toggle="modal" class="btn btn-outline-secondary" data-bs-target="#modalAccount">Account</a>&nbsp;
                 <a href="#" data-bs-toggle="modal" class="btn btn-outline-secondary" data-bs-target="#modalWishlist">Wishlist</a>
             </div>
    
     <div id="colproductscroll" class="col-12">
         <hr />
         <center>
             <h1>My Orders</h1>
         </center>
         <asp:HiddenField ID="Hdnproductid" runat="server" />
         <asp:HiddenField ID="Hdnproductrefid"  runat="server" />
         <asp:HiddenField ID="Hdnporderid" runat="server" />
         <asp:HiddenField ID="Hdnavailableqty" runat="server" />
         <asp:HiddenField ID="Hdndeliverystatus"  runat="server" />
         <asp:HiddenField ID="HdnDispatchstatus"  runat="server" />
         <asp:HiddenField ID="HdnisCancelled"  runat="server" />
         <!---1---->
         <asp:Repeater ID="Repeater" OnItemDataBound="Repeater_ItemDataBound" runat="server">
             <ItemTemplate>
                 
                 <div class="row">
                     <asp:HiddenField ID="Hdnproductid" Value='<%#Eval("productid")%>' runat="server" />
                     <asp:HiddenField ID="Hdnproductrefid" Value='<%#Eval("productrefid")%>' runat="server" />
                     <asp:HiddenField ID="Hdnporderid" Value='<%#Eval("orderid")%>' runat="server" />
                     <asp:HiddenField ID="Hdnavailableqty" Value='<%#Eval("quantity")%>' runat="server" />
                     <asp:HiddenField ID="Hdndeliverystatus" Value='<%#Eval("Deliverstatus")%>' runat="server" />
                     <asp:HiddenField ID="HdnDispatchstatus" Value='<%#Eval("dispachedstatus")%>' runat="server" />
                     <asp:HiddenField ID="HdnisCancelled" Value='<%#Eval("iscancelled")%>' runat="server" />
                     <asp:HiddenField ID="Hdnreturn" Value='<%#Eval("returnday")%>' runat="server" />
                     <asp:HiddenField ID="Hdnreplacement" Value='<%#Eval("replacementday")%>' runat="server" />
                     <asp:HiddenField ID="HdnfinallyDelivered" Value='<%#Eval("finallyDelivered")%>' runat="server" />
                     <asp:HiddenField ID="HdnFinallyDeliveredDate" Value='<%#Eval("delivery_date")%>' runat="server" />
                     <asp:HiddenField ID="Hdnisrefused" Value='<%#Eval("isrefused")%>' runat="server" />
                     <asp:HiddenField ID="Hdnreturnrequest" Value='<%#Eval("accepted")%>' runat="server" />
                     <asp:HiddenField ID="HdnSelleremail" Value='<%#Eval("Email")%>' runat="server" />
                     <asp:HiddenField ID="HdnpaymentMode" Value='<%#Eval("PaymentMode")%>' runat="server" />
                    
                    <div class="d-flex">
                        <asp:Label ForeColor="Gray" Font-Bold="true" Text="Order Id :-" runat="server"></asp:Label>&nbsp;&nbsp;&nbsp;
                        <asp:Label ForeColor="Gray" Font-Bold="true" Text='<%#Eval("orderid") %>' runat="server"></asp:Label>
                    </div>
                     <div class="d-flex">
                         <asp:Label ForeColor="Gray" Font-Bold="true" Text="Tracking Id :-" runat="server"></asp:Label>&nbsp;&nbsp;&nbsp;
                         <a target="_blank" id="track" href='<%#Eval("trackingid") %>'><%#Eval("trackingid").ToString()!=""?"Click to Track":"" %></a>
             <%--<asp:Label ForeColor="Gray" onclick="copytocliboard(this);" Font-Bold="true" style="cursor:pointer" Text='<%#Eval("trackingid") %>' runat="server"></asp:Label>--%>
                     </div>
                     <div class="col-12 col-sm-5 col-md-6 col-lg-4 col-xl-3 text-center">
                         
                         <a href="Productdetailpage.aspx?productid=<%#Eval("productid") %>&&productrefid=<%#Eval("productrefid") %>">
                         <asp:Image ID="Image1" CssClass="img-fluid img-thumbnail" ImageUrl='<%#Eval("productimage")%>' Style="height: 160px; width: 150px" runat="server" />
                             </a>
                     </div>
                     <div class="col-12 col-sm-4 col-md-6 col-lg-8 col-xl-8" style="text-align: left">
                         <div>
                             <asp:Label ID="lblproductname" runat="server" Font-Bold="true" Font-Size="Large" ForeColor="HotPink" Font-Italic="true" Text='<%#Eval("productname")%>'></asp:Label>
                         </div>
                         <div>
                             <asp:Label ID="Lblproductsize" runat="server" Font-Bold="true" Font-Size="small" ForeColor="GrayText" Font-Italic="true" Text='<%#"Size:"+" "+Eval("size").ToString()+" "+"&"%>'></asp:Label>
                             <asp:Label ID="lblproductcolor" runat="server" Font-Bold="true" Font-Size="small" ForeColor="GrayText" Font-Italic="true" Text='<%#"Color:"+" "+Eval("color").ToString()+" "+"&"%>'></asp:Label>
                             <asp:Label ID="lblproductqty" runat="server" Font-Bold="true" Font-Size="small" ForeColor="GrayText" Font-Italic="true" Text='<%#"Qty:"+" "+Eval("quantity").ToString()%>'></asp:Label>
                         </div>
                         <div class="d-flex">
                             <asp:HiddenField ID="avalquanity" Value='<%#Eval("Avl_Quantity") %>' runat="server" />
                             <asp:Label ID="Label7" runat="server" Font-Bold="true" Font-Size="x-small" ForeColor="#00ff00" Font-Italic="true" Text="in Stock"></asp:Label>&nbsp;
                               <asp:Label ID="Label6" runat="server" Font-Bold="true" Font-Size="x-small" ForeColor="red" Font-Italic="true" Text="Out of Stock"></asp:Label>&nbsp;
                             

                             <asp:Label ID="Label4" runat="server" Font-Bold="true" Font-Size="x-small" ForeColor="#0033cc" Font-Italic="true" Text='<%#Eval("paymentMode")%>'></asp:Label>
                         </div>
                         <div>
                             <asp:Label ID="lblfreedeliver" runat="server" Font-Bold="true" Font-Size="x-small" ForeColor="GrayText" Font-Italic="true" Text='<%#"Delivery Price : "+Math.Round(Convert.ToDouble(Eval("deliveryprice")),0)%>'></asp:Label>
                         </div>
                         <div class="d-flex">
                             <asp:Label ID="Label5" runat="server" Font-Bold="true" Font-Size="small" ForeColor="Black" Font-Italic="true" Text="₹"></asp:Label>
                             <asp:Label ID="lblacturalprice" runat="server" Font-Bold="true" Font-Size="small" ForeColor="Black" Font-Italic="true" Text='<%#Math.Round(Convert.ToDouble(Eval("grandtotal")),2)%>'></asp:Label>
                             &nbsp;<asp:Label ID="lbldiscount" runat="server" Font-Bold="true" Font-Size="small" ForeColor="Black" Font-Italic="true" Text='<%#"after (-"+Eval("discountpercent")+"% OFF)"%>'></asp:Label>
                          
                         </div>
                         <div class="d-flex">
                             <asp:Panel ID="Panelyet" Visible="false" runat="server">
                                 <span style="color:#36d01e; font: bolder">&#9679; Order Booked</span>
                             </asp:Panel>
                             <asp:Panel ID="Paneldispatched" Visible="false"  runat="server">
                                 <span style="color: orangered; font: bolder">&#9679; Dispatched</span>
                             </asp:Panel>
                             <asp:Panel ID="Panelshipped" Visible="false" runat="server">
                                 <span style="color: #000000; font:800">&#9679; Shipped</span>
                             </asp:Panel>
                             <asp:Panel ID="PanelDelivered" Visible="false"  runat="server">
                                 <span style="color: green; font: bolder">&#9679; Delivered</span>
                             </asp:Panel>
                         </div>
                         <div>
                             <%--<asp:DropDownList ID="DropDownList1" AutoPostBack="true" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged"  runat="server"></asp:DropDownList> <br /> <!--onchange="dropchange();"-->--%>
                            
                             <asp:Label ID="lblCancelled" ForeColor="Red" Text="Cancelled" Visible="false" runat="server"></asp:Label>
                             <asp:Label ID="lblRefused" ForeColor="Orange" Text="Refused By Seller" Visible="false" runat="server"></asp:Label>
                         </div>
                        
                         <div style="display:none;justify-content:space-between;align-items:center;">
                             <div class="col-lg-4">
                                   <a style="color:orangered;" href="Productdetailpage.aspx?productid=<%#Eval("productid") %>&&productrefid=<%#Eval("productrefid") %>">Buy again</a>&nbsp;
                             </div>
                             <div class="col-lg-4">
                                 <asp:Panel ID="Panel1" runat="server">
                                     <a style="color: orangered" target="_blank" href="slip.aspx?orderid=<%#Eval("orderid") %>&&productid=<%#Eval("productid") %>&&productrefid=<%#Eval("productrefid") %>">Download invoice</a>
                                 </asp:Panel>
                             </div>
                             <div class="col-lg-4">
                                 <asp:Panel ID="Panel2" runat="server">
                                     <a style="color: orangered" onclick="trackorder();" >Track Shipment</a>
                                 </asp:Panel>
                             </div>
                             
                           
                           
                         </div>





                     </div>
                 </div>
                 <div>
                     <asp:Panel ID="panelbtn" runat="server">
                                  
                    
                      </asp:Panel>
                         <asp:HiddenField ID="HiddenFieldOrderid" Value='<%#Eval("orderid")%>' runat="server" />
                     <asp:HiddenField ID="HiddenFieldProductid" Value='<%#Eval("productid")%>' runat="server" />
                     <asp:HiddenField ID="HiddenFieldProductrefid" Value='<%#Eval("productrefid")%>' runat="server" />
                     <asp:LinkButton ID="btnCancel" OnClick="btnCancel_Click" OnClientClick="return AreYouSure(this)" Visible="false" runat="server" CssClass="btn btn-dark w-100 mt-2">Cancel</asp:LinkButton>
                     <asp:LinkButton ID="btnTrack" Visible="false" OnClientClick="Trackingweb();" runat="server" CssClass="btn btn-dark w-100 mt-2">Track Order</asp:LinkButton>
                     <asp:LinkButton ID="btnDownloadSlip" OnClick="btnDownloadSlip_Click" Visible="false" runat="server" CssClass="btn btn-dark w-100 mt-2">Downlod Invoice</asp:LinkButton>
                     <asp:LinkButton ID="btnReturn" OnClick="btnReturn_Click" runat="server" Visible="false" CssClass="btn btn-dark w-100 mt-2">Apply Return</asp:LinkButton>
                 </div>
                    <hr />
             </ItemTemplate>
         </asp:Repeater>
     </div>
    

 </div>
    </div>
      <!-- Modal-RefundPolicy -->
    <div>
        
  <div class="modal fade" id="modalAccount" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
      <div class="modal-dialog modal-md">
          <div class="modal-content">
              <div class="modal-header">
                  <h6 class="modal-title text-bold" style="text-align: center; font-size: larger; font: bolder; text-decoration: none; color: black; cursor: pointer; font-style: italic; font-weight: 600;">Profile Info</h6>
                  <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
              </div>
              <div class="modal-body" style="text-align:center">
                  <asp:Label ID="Label1" Font-Bold="true" runat="server" Text="Vikash kumar singh"></asp:Label><br />
                  <asp:Label ID="Label2" Font-Bold="true" runat="server" Text="9999963147"></asp:Label><br />
                  <asp:Label ID="Label3" Font-Bold="true" runat="server" Text="Vinodkumarsingh894@gmail.com"></asp:Label>
             
              </div>
              <%--<div class="modal-footer ms-0">
                 <%-- &copy Art-Candervilla--%>
              </div>
          </div>
      </div>          
  </div>
    <div>
        <div class="modal fade" id="modalWishlist" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
            <div class="modal-dialog modal-xl">
                <div class="modal-content">
                    <div class="modal-header">
                        <h6 class="modal-title text-bold" style="text-align: center; font-size: larger; font: bolder; text-decoration: none; color: black; cursor: pointer; font-style: italic; font-weight: 600;">My Wishlist</h6>
                        <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                    </div>
                    <div class="modal-body" style="text-align: center">
                        <div class="row">
                            <asp:Repeater ID="RepeaterWishlist" runat="server">
                                <ItemTemplate>
                                    <div class="col-6 col-md-4 col-lg-3">
                                        <a target="_blank" href="Productdetailpage.aspx?productid=<%#Eval("product_id") %>&&productrefid=<%#Eval("product_ref_id") %>">
                                            <asp:Image ID="imgwhish" CssClass="img-fluid img-thumbnail" ImageUrl='<%#Eval("Image1") %>' Width="70%" Height="175px" runat="server" /><br />
                                            <asp:Label ID="lblinStock" Font-Bold="true" Font-Size="X-Small" style="font-style:italic;text-decoration:none;color:black" Text='<%#Eval("Avl_Quantity").ToString()=="0"?"Out of Stock":"In Stock" %>' runat="server"></asp:Label>
                                        </a>
                                    </div>
                                </ItemTemplate>
                            </asp:Repeater>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
  <!-- Modal-RefundPolicy -->
    <script>
        function copytocliboard(ev) {
            alert("copied to clipboart");
            navigator.clipboard.writeText(ev.innerText);
        }
    </script>
    <script>
      
        function dropchange() {
            window.location = 'Default.aspx';
        }

        function Trackingweb() {
            //window.open('https://www.delhivery.com/tracking', target = '_blank');
            var btntrack = document.getElementById('track');
            btntrack.click();
        }


        function trackorder() {
            var btntrack = document.getElementById('track');
            btntrack.click();
        }


        var obj = { status: false, ele: null };
        function AreYouSure(ev) {
            if (obj.status) {
                return true;
            };
            swal({
                title: "Are you sure?",
                text: "Are You Sure Want To Cancel your Order ?",
                type: "warning",
                showCancelButton: true,
                confirmButtonClass: "btn-danger",
                confirmButtonText: "Yes, Cancel Order!",
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
