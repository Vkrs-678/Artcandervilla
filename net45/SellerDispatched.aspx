<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="SellerDispatched.aspx.cs" Inherits="RazorpaySampleApp.WebForm20" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        var obj = { status: false, ele: null };
        function AreYouSureAccept(ev) {
            if (obj.status) {
                return true;
            };
            swal({
                title: "Are you sure?",
                text: "Your are Accepting The Order",
                type: "warning",
                showCancelButton: true,
                confirmButtonClass: "btn-success",
                confirmButtonText: "Accept !",
                closeOnConfirm: true
            },
                function () {
                    obj.status = true;
                    obj.ele = ev;
                    obj.ele.click();
                });

            return false;
        }


        var obj = { status: false, ele: null };
        function AreYouSureReject(ev) {
            if (obj.status) {
                return true;
            };
            swal({
                title: "Are you sure?",
                text: "Your Are Rejection The Order !",
                type: "warning",
                showCancelButton: true,
                confirmButtonClass: "btn-danger",
                confirmButtonText: "Reject",
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
        <div class="row" style="margin-top:100px;margin-left:10px">
        <div class="col-2">
            <asp:LinkButton ID="LnkPendingforapproval" OnClick="LnkPendingforapproval_Click" class="btn btn-dark position-relative" runat="server">
                Pending For Dispatch
                 <span class="position-absolute top-0 start-100 translate-middle badge rounded-pill bg-danger">
                     <asp:Label ID="Lblpendingcount" runat="server" Text="1"></asp:Label>
     <span class="visually-hidden">unread messages</span>
 </span>
            </asp:LinkButton>
           
        </div>
            <div class="col-4 d-flex">
                <asp:TextBox ID="Txtorderid" Placeholder="Enter Order Id" CssClass="form-control" runat="server"></asp:TextBox>
                <asp:LinkButton ID="Lnksearchorderid" OnClick="Lnksearchorderid_Click" CssClass="btn btn-success" runat="server">Search</asp:LinkButton>
            </div>
    </div>
        <div class="container-fluid shadow" style="margin-top: 10px">
        <div class="row">          
            <div class="col">
                <table class="table table-hover">
                    <thead>
                        <tr>
                            
                            <th>ID</th>
                            <th>Order id</th>
                            <th>Ref Id</th>
                            <th>Product Name</th>
                            <th>Product Brand</th>
                            <th>Product Price</th>
                            <th>Qty</th>
                            <th>Size</th>
                            <th>Color</th>
                            <th>Images</th>
                            <th>Prodcut Acceptance</th>                            
                            <th>Action</th>                                                       
                        </tr>
                    </thead>
                    <tbody>
                        <asp:Repeater ID="RptrProducts" OnItemDataBound="RptrProducts_ItemDataBound" runat="server">

                            <ItemTemplate>
                               
                               
                                <tr>                                                                                                             
                                     <td><%#Eval("productid") %></td>                                
                                     <td>
                                         <asp:Label ID="LblOrderid" runat="server" Text='<%#Eval("orderid") %>'></asp:Label>
                                     </td>                                
                                     <td><%#Eval("productrefid") %></td>                                
                                     <td><%#Eval("productname") %></td>                                
                                     <td><%#Eval("productbrand") %></td>                                
                                     <td><%#Math.Round(Convert.ToDouble(Eval("buyPrice")),0) %></td>                                
                                     <td><%#Eval("quantity") %></td>                                
                                     <td><%#Eval("size") %></td>                                
                                     <td><%#Eval("color") %></td>                                                                   
                                    <td>
                                        <asp:Image ID="Image1" Height="100px" Width="100px" runat="server" ImageUrl='<%#Eval("productimage") %>' /></td>
                                    <td>
                                        <asp:Label ID="Label1" Font-Bold="true" ForeColor="Black" runat="server" Text='<%#Eval("dispachedstatus").ToString()=="1"?"Accepted":Eval("dispachedstatus").ToString()=="2"?"Rejected":"Pending" %>'></asp:Label>
                                        <asp:HiddenField ID="Orderid" Value='<%#Eval("orderid")%>' runat="server" />
                                        <asp:HiddenField ID="Hdnuserid" Value='<%#Eval("userid")%>' runat="server" />
                                        <asp:HiddenField ID="HdnSellerid" Value='<%#Eval("sellerid") %>' runat="server" />
                                        <asp:HiddenField ID="Hdnproductid" Value='<%#Eval("productid") %>' runat="server" />
                                        <asp:HiddenField ID="Hdnproductname" Value='<%#Eval("productname") %>' runat="server" />
                                        <asp:HiddenField ID="Hdnproductrefid" Value='<%#Eval("productrefid") %>' runat="server" />
                                        <asp:HiddenField ID="Hdnimageurl" Value='<%#Eval("productimage") %>' runat="server" />
                                        <asp:HiddenField ID="Hdnusername" Value='<%#Eval("Nameofthecustomer") %>' runat="server" />
                                        <asp:HiddenField ID="Hdnuseremail" Value='<%#Eval("email") %>' runat="server" />
                                        <asp:HiddenField ID="Hdntotalprice" Value='<%#Eval("totalprice") %>' runat="server" />
                                        <asp:HiddenField ID="Hdnpaymentmode" Value='<%#Eval("paymentMode")%>' runat="server" />
                                        <asp:HiddenField ID="Hdndispatchedstatus" Value='<%#Eval("dispachedstatus")%>' runat="server" />
                                    </td>
                                    <td >
                                        
                                        <asp:Panel ID="Panelaccept" runat="server">
                                            <div class="d-flex" style="column-gap:5px">
                                               
                                               
                                               
                                                  <asp:LinkButton ID="LnkAccept"   OnClick="LnkAccept_Click" CssClass="btn btn-dark w-100" runat="server">Accepts</asp:LinkButton>
                                       
                                         <asp:LinkButton ID="Lnkreject" OnClientClick="return AreYouSureReject(this)" OnClick="Lnkreject_Click" CssClass="btn btn-dark" runat="server">Reject</asp:LinkButton>
                                        </div>
                                                </asp:Panel>                                      
                                        <asp:Panel ID="panelprint" runat="server">
                                             <a target="_blank" href="Slip.aspx?orderid=<%#Eval("orderid") %>&&productid=<%#Eval("productid") %>&&productrefid=<%#Eval("productrefid") %>" style="margin:10px"  class="btn btn-dark">Print Invoice</a>
                                        </asp:Panel>

                                     
                                      
                                    </td>
                                </tr>
                               
                            </ItemTemplate>
                        </asp:Repeater>

                    </tbody>
                </table>
                 <a class="btn btn-dark" id="popup" data-bs-toggle="modal" style="visibility:hidden" data-bs-target="#modalaccept" data-bs-whatever="@mdo">Accept</a>                                            <!----modal accept----->
                                       <div class="modal fade" id="modalaccept" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
                                           <div class="modal-dialog">
                                               <asp:HiddenField ID="Hdnfinalorderid" runat="server" />
                                                <asp:HiddenField ID="Hdnfinaluserid" runat="server" />
                                                <asp:HiddenField ID="Hdnfinalsellerid" runat="server" />
                                                <asp:HiddenField ID="Hdnfinalproductid" runat="server" />
                                                <asp:HiddenField ID="Hdnfinalproductrefid" runat="server" />
                                                <asp:HiddenField ID="Hdnfinalname" runat="server" />
                                                <asp:HiddenField ID="Hdnfinalusername" runat="server" />
                                                <asp:HiddenField ID="Hdnfinalemail" runat="server" />
                                                <asp:HiddenField ID="Hdnfinaltotalprice" runat="server" />
                                                <asp:HiddenField ID="Hdnfinalimageurl" runat="server" />
                                                <asp:HiddenField ID="Hdnfinalpaymentmode" runat="server" />
                                               <div class="modal-content">
                                                   <div class="modal-header">
                                                       <h5 class="modal-title" id="exampleModalLabel">Fill Delivery Details</h5>
                                                       <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                                                   </div>
                                                   <div class="modal-body">
                                                       <div class="mb-3">
                                                           <asp:CheckBox ID="chksizeandcolor" runat="server" Text="Confirm Size & Color" />

                                                       </div>
                                                       <div class="mb-3">
                                                           <label for="recipient-name" class="col-form-label">Height (CM):</label>
                                                            <asp:TextBox ID="Txtheight" required TextMode="Number" CssClass="form-control" runat="server"></asp:TextBox>

                                                       </div>
                                                       <div class="mb-3">
                                                           <label for="recipient-name" class="col-form-label">Width (CM):</label>
                                                           <asp:TextBox ID="Txtwidth" required TextMode="Number" CssClass="form-control" runat="server"></asp:TextBox>
                                                           
                                                       </div>
                                                       <div class="mb-3">
                                                           <label for="recipient-name" class="col-form-label">Length (CM):</label>
                                                           <asp:TextBox ID="Txtlength" required TextMode="Number" CssClass="form-control" runat="server"></asp:TextBox>
                                                       </div>
                                                       <div class="mb-3">
                                                           <label for="recipient-name" class="col-form-label">Weight (Gram):</label>
                                                           <asp:TextBox ID="TxtWeight" required TextMode="Number" CssClass="form-control" runat="server"></asp:TextBox>
                                                       </div>
                                                       
                                                       <asp:LinkButton ID="LnkfinalAccept" runat="server" CssClass="btn btn-dark" OnClientClick="return AreYouSureAccept(this)" OnClick="LnkfinalAccept_Click">Accept</asp:LinkButton>
                                                   </div>

                                               </div>
                                           </div>
                                       </div>
                                <!----modal accept----->
               
          
            </div>
        </div>
    </div>
   
    <!-----bootstrap js----->
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/js/bootstrap.bundle.min.js" integrity="sha384-MrcW6ZMFYlzcLA8Nl+NtUVF0sA7MsXsP1UyJoMp4YLEuNSfAP+JcXn/tWtIaxVXM" crossorigin="anonymous"></script>
    <script src="https://code.jquery.com/jquery-3.7.1.min.js" integrity="sha256-/JqT3SQfawRcv/BIHPThkBvs0OEvtFFmqPF/lYI/Cxo=" crossorigin="anonymous"></script>
    <!-----Jquery For Filtering rows in Table--->
    <script src="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-sweetalert/1.0.1/sweetalert.js"></script>
    <script>
        function popup() {
            const button = document.getElementById('popup');
            button.click();
        }
    </script>
</asp:Content>
