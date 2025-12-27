<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="ApproveProductByAdmin.aspx.cs" Inherits="RazorpaySampleApp.WebForm14" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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

        function openModal() { $('#showmodalbutton').trigger('click'); }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container shadow rounded" style="margin-top: 100px">
          <a href="AdminProductView.aspx" class="btn btn-dark">Back To ProductView</a>
        <div class="row">
            <div class="col">
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
                                    <td><%#Eval("maincat_id").ToString()%></td>
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
                                    <td><%#Eval("Listdate")%></td>
                                </tr>
                                <tr>
                                    <td>Reason : </td>
                                    <td><%#Eval("disaproved_reason")%></td>
                                </tr>
                                <tr>
                                    <td>Status : </td>
                                    <td><%#Eval("IsAproved").ToString()=="0"&&Eval("disaproved_reason").ToString()==""?"Pending":Eval("IsAproved").ToString()=="0"&&Eval("disaproved_reason").ToString()!=""?"Disapproved":Eval("IsAproved").ToString()=="1"&&Eval("disaproved_reason").ToString()==""?"Approved":"Pending"%></td>
                                </tr>
                                <tr>

                                    <td>
                                        <asp:LinkButton ID="LnkApprove" OnClick="LnkApprove_Click" CssClass="btn btn-dark" runat="server">Approve</asp:LinkButton>
                                    </td>
                                    <td>
                                        <button type="button" class="btn btn-dark" data-bs-toggle="modal" data-bs-target="#DisapprovalReason">
                                            Disapprove
                                        </button>
                                     
                                      
                                    </td>

                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>

                    </tbody>
                </table>
                <!-- Button trigger modal -->
               

                <!-- Modal -->
                <div class="modal fade" id="DisapprovalReason" data-bs-backdrop="static" data-bs-keyboard="false" tabindex="-1" aria-labelledby="staticBackdropLabel" aria-hidden="true">
                    <div class="modal-dialog modal-dialog-centered">
                        <div class="modal-content">
                            <div class="modal-header">
                                <h5 class="modal-title" id="staticBackdropLabel">Disapprove</h5>
                                <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                            </div>
                            <div class="modal-body">
                                <asp:TextBox ID="TxtdisaaprovalReason" CssClass="shadow" Width="100%" TextMode="MultiLine" Rows="5" style="resize:none;outline:thin;outline-color:gray;font-style:italic;font-weight:600;text-decoration-color:gray" runat="server"></asp:TextBox>
                                <center>
                                     <asp:LinkButton ID="Lnkdisaaprove" OnClick="Lnkdisaaprove_Click" CssClass="btn btn-dark" runat="server">DisApprove</asp:LinkButton>
                                </center>
                            </div>
                            <div class="modal-footer">
                          
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
