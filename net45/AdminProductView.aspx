<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="AdminProductView.aspx.cs" Inherits="RazorpaySampleApp.WebForm13" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <!----Bootstrap--->
 <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-EVSTQN3/azprG1Anm3QDgpJLIm9Nao0Yz1ztcQTwFspd3yD65VohhpuuCOmLASjC" crossorigin="anonymous">

 <script src="magnific-popup/jquery.magnific-popup.js"></script>
 <script src="https://code.jquery.com/jquery-3.7.1.min.js" integrity="sha256-/JqT3SQfawRcv/BIHPThkBvs0OEvtFFmqPF/lYI/Cxo=" crossorigin="anonymous"></script>
 <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap-sweetalert@1.0.1/dist/sweetalert.min.css">
 <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-sweetalert/1.0.1/sweetalert.css" />
 <script>
     var obj = { status: false, ele: null };
     function AreYouSure(ev) {
         if (obj.status) {
             return true;
         };
         swal({
             title: "Are you sure?",
             text: "Your will not be able to recover this imaginary file!",
             type: "warning",
             showCancelButton: true,
             confirmButtonClass: "btn-dark",
             confirmButtonText: "Yes, Remove it!",
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
     function AreYouSure1(ev) {
         if (obj.status) {
             return true;
         };
         swal({
             title: "Are you sure?",
             text: "Your will not be able to recover this imaginary file!",
             type: "warning",
             showCancelButton: true,
             confirmButtonClass: "btn-dark",
             confirmButtonText: "Yes, Deactivate it!",
             closeOnConfirm: true
         },
             function () {
                 obj.status = true;
                 obj.ele = ev;
                 obj.ele.click();
             });

         return false;
     }
     function openModal() { $('#showmodalbutton').trigger('click'); }
     function openModalforOffer() { $('#offerpopbutton').trigger('click'); }
 </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row" style="margin-top:100px;margin-left:10px">
        <div class="col-2">
            <asp:LinkButton ID="LnkPendingforapproval" OnClick="LnkPendingforapproval_Click" class="btn btn-dark position-relative" runat="server">
                Pending For Approval
                 <span class="position-absolute top-0 start-100 translate-middle badge rounded-pill bg-danger">
                     <asp:Label ID="Lblpendingcount" runat="server" Text="99+"></asp:Label>
     <span class="visually-hidden">unread messages</span>
 </span>
            </asp:LinkButton>
           
        </div>
    </div>
        <div class="container-fluid shadow" style="margin-top: 10px">
        <div class="row">          
            <div class="col">
                <table class="table table-hover">
                    <thead>
                        <tr>
                            
                            <th>ID</th>
                            <th>Ref Id</th>
                            <th>Product Name</th>
                            <th>Product Brand</th>
                            <th>Product Price</th>
                            <th>Current Discount %</th>
                            <th>Status</th>
                            <th>Images</th>
                            <th>Active</th>
                            <th>Approve</th>
                            <th>View</th>
                           
                        </tr>
                    </thead>
                    <tbody>
                        <asp:Repeater ID="RptrProducts" runat="server">
                            <ItemTemplate>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label2" runat="server" Text='<%#Eval("product_id")%>'></asp:Label></td>
                                    <td><%#Eval("product_ref_id")%></td>
                                    <td><%#Eval("productname")%></td>
                                    <td><%#Eval("productbrand")%></td>
                                    <td><%#Eval("productprice")%></td>
                                    <td><%#Eval("productdiscount")%></td>
                                     <td><%#Eval("Status")%></td>
                                    <td>
                                        <center>
                                            <asp:Image ID="Image1" Height="100px" Width="80px" ImageUrl='<%#Eval("image1")%>' runat="server" />
                                        </center>
                                    </td>
                                    <td><%#Eval("isactive").ToString()=="1"?"Active":"Not Active"%></td>
                                    <td><%#Eval("isAproved").ToString()=="1"?"Approved":"Disapproved"%></td>
                                    <td>
                                        <asp:LinkButton ID="Lnkview" OnClick="Lnkview_Click" CssClass="btn btn-dark" runat="server">View</asp:LinkButton>

                                    </td>                                    
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>

                    </tbody>
                </table>
                <!-- Button trigger modal -->
                <button type="button" id="showmodalbutton" style="display:none" class="btn btn-primary" data-bs-toggle="modal" data-bs-target="#showviewmodal">
                    Launch demo modal
                </button>
                <!-- Modal -->
                <div class="modal fade" id="showviewmodal" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
                    <div class="modal-dialog modal-fullscreen">
                        <div class="modal-content">
                            <div class="modal-header">
                                <h5 class="modal-title" id="exampleModalLabel">Show All Product Details</h5>
                                <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                            </div>
                            <div class="modal-body">
                                <table class="table tabhle-hover table-border">
                                    <thead>
                                        <tr>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <asp:Repeater ID="Rptrproductview" runat="server">
                                            <ItemTemplate>
                                                <tr>
                                                    <td colspan="2">
                                                         <center>
                                                             <div>
                                                                  <asp:Label ID="lblReason" Font-Bold="true" ForeColor="Red" runat="server" Text='<%#Eval("disaproved_reason") %>'></asp:Label>
                                                             </div>
                                                        <div class="col-4">                                                           
                                                            <asp:Image ID="Imageproduct1" Height="150px" Width="130px" ImageUrl='<%#Eval("Image1") %>' runat="server" />
                                                            <asp:Image ID="Imageproduct2" Height="150px" Width="130px" ImageUrl='<%#Eval("Image2") %>' runat="server" />
                                                            <asp:Image ID="Imageproduct3" Height="150px" Width="130px" ImageUrl='<%#Eval("Image3") %>' runat="server" />
                                                            <asp:Image ID="Imageproduct4" Height="150px" Width="130px" ImageUrl='<%#Eval("Image4") %>' runat="server" />
                                                            <asp:Image ID="Imageproduct5" Height="150px" Width="130px" ImageUrl='<%#Eval("Image5") %>' runat="server" />
                                                                
                                                        </div>
                                                             </center>
                                                    </td>

                                                </tr>
                                                <tr>
                                                    <td>Seller ID: </td>
                                                    <td><%#Eval("seller_id") %></td>
                                                </tr>
                                                <tr>
                                                    <td>Product Id: </td>
                                                    <td><%#Eval("product_id") %></td>
                                                </tr>
                                                <tr>
                                                    <td>Product Ref Id: </td>
                                                    <td><%#Eval("product_ref_id") %></td>
                                                </tr>
                                                <tr>
                                                    <td>MainCategory </td>
                                                    <td><%#Eval("maincat_id").ToString()+"+"+Eval("Catname") %></td>
                                                </tr>
                                                <tr>
                                                    <td>SubcatName </td>
                                                    <td><%#Eval("subcat_id").ToString()+"+"+Eval("SubcatName") %></td>
                                                </tr>
                                                <tr>
                                                    <td>Product Name: </td>
                                                    <td><%#Eval("productname") %></td>
                                                </tr>
                                                <tr>
                                                    <td>Product Brand: </td>
                                                    <td><%#Eval("productbrand") %></td>
                                                </tr>
                                                <tr>
                                                    <td>Product Details: </td>
                                                    <td><%#Eval("productdetail") %></td>
                                                </tr>
                                                <tr>
                                                    <td>Product Description: </td>
                                                    <td><%#Eval("productdescription") %></td>
                                                </tr>
                                                <tr>
                                                    <td>Product keyword: </td>
                                                    <td><%#Eval("productkeyword") %></td>
                                                </tr>
                                                <tr>
                                                    <td>Product Specification: </td>
                                                    <td><%#Eval("productspecification") %></td>
                                                </tr>
                                                <tr>
                                                    <td>Product Type: </td>
                                                    <td><%#Eval("productType") %></td>
                                                </tr>
                                                <tr>
                                                    <td>Product Color: </td>
                                                    <td><%#Eval("productcolor") %></td>
                                                </tr>
                                                <tr>
                                                    <td>Product Size: </td>
                                                    <td><%#Eval("productsize") %></td>
                                                </tr>
                                                <tr>
                                                    <td>Product Price: </td>
                                                    <td><%#Eval("productprice") %></td>
                                                </tr>
                                                <tr>
                                                    <td>Discount %: </td>
                                                    <td><%#Eval("productdiscount") %></td>
                                                </tr>
                                                <tr>
                                                    <td>COD : </td>
                                                    <td><%#Eval("iscod").ToString()=="1"?"Yes":"No" %></td>
                                                </tr>
                                                <tr>
                                                    <td>Offer : </td>
                                                    <td><%#Eval("isfestiveoffer").ToString()=="0"?"No":Eval("isfestiveoffer").ToString()=="1"?"Limited":"Festive" %></td>
                                                </tr>
                                                <tr>
                                                    <td>Is Active : </td>
                                                    <td><%#Eval("isactive").ToString()=="1"?"Active":"Deactive" %></td>
                                                </tr>
                                                <tr>
                                                    <td>Return Day : </td>
                                                    <td><%#Eval("returnday")%></td>
                                                </tr>
                                                <tr>
                                                    <td>Replacement Day : </td>
                                                    <td><%#Eval("replacementday")%></td>
                                                </tr>
                                                <tr>
                                                    <td>Delivery Price : </td>
                                                    <td><%#Eval("deliveryprice")%></td>

                                                </tr>
                                                <tr>
                                                    <td>Available Quantity: </td>
                                                    <td><%#Eval("Avl_Quantity") %></td>
                                                </tr>
                                                <tr>
                                                    <td>List Date : </td>
                                                    <td><%#Eval("Listdateonly")%></td>
                                                </tr>
                                            </ItemTemplate>
                                        </asp:Repeater>

                                    </tbody>
                                </table>
                            </div>

                        </div>
                    </div>
                </div>


<!-- Button Offer button -->
<button type="button" id="offerpopbutton" style="display:none" class="btn btn-primary" data-bs-toggle="modal" data-bs-target="#offerpopup">
  Launch static backdrop modal
</button>


<!-- Modal -->
<div class="modal fade" id="offerpopup" data-bs-backdrop="static" data-bs-keyboard="false" tabindex="-1" aria-labelledby="staticBackdropLabel" aria-hidden="true">
  <div class="modal-dialog modal-dialog-centered">
    <div class="modal-content">
      <div class="modal-header">
        <h5 class="modal-title" id="staticBackdropLabel">Select Offer Type</h5>
        <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
      </div>
      <div class="modal-body">
          <div class="d-flex">
              <asp:HiddenField ID="Hiddenproductid" runat="server" />
              <center>
                  <asp:RadioButton ID="RdoFestive" Text="Festival Offer" CssClass="fw-bold" GroupName="Offer" Style="margin-right: 20px" runat="server" />
                  <asp:RadioButton ID="RdoLimitedOffer" Text="Limited Time Offer" GroupName="Offer" CssClass="fw-bold" runat="server" />
              </center>

          </div>
          <div class="mt-3">
              <center>
                   <asp:LinkButton ID="Lnkoffer"  CssClass="btn btn-dark" runat="server">Update Offer</asp:LinkButton>
              </center>
             
          </div>
      </div>
     
    </div>
  </div>
</div>
            </div>
        </div>
    </div>
    <!-----bootstrap js----->
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/js/bootstrap.bundle.min.js" integrity="sha384-MrcW6ZMFYlzcLA8Nl+NtUVF0sA7MsXsP1UyJoMp4YLEuNSfAP+JcXn/tWtIaxVXM" crossorigin="anonymous"></script>
    <script src="https://code.jquery.com/jquery-3.7.1.min.js" integrity="sha256-/JqT3SQfawRcv/BIHPThkBvs0OEvtFFmqPF/lYI/Cxo=" crossorigin="anonymous"></script>
    <!-----Jquery For Filtering rows in Table--->
    <script src="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-sweetalert/1.0.1/sweetalert.js"></script>

</asp:Content>
