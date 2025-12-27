<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeFile="ShippingPage.aspx.cs" Inherits="RazorpaySampleApp.WebForm25" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="mt-5" >
        <div class="container" style="margin-top:100px">
            <div class="row">
                <div class="col-12 col-md-6 shadow">
                    <div class="text-center mt-2">
                        <h6>Seller Address</h6>
                    </div>
                    <hr />
                    <div class="p-3 m-3 text-center">
                        <asp:Label ID="SellerName" ForeColor="Gray" Font-Bold="true" runat="server" ></asp:Label><br />
                        <asp:Label ID="SellerMobile" ForeColor="Gray" Font-Bold="true" runat="server" ></asp:Label><br />
                        <asp:Label ID="SellerEmail" ForeColor="Gray" Font-Bold="true" runat="server" ></asp:Label><br />
                        <asp:Label ID="SellerAddress" ForeColor="Gray" Font-Bold="true" runat="server" Text="Artcandervilla store New Delhi India 110043"></asp:Label>
                    </div>
                </div>
                <div class="col-12 col-md-6 shadow">
                    <div class="text-center mt-2">
                        <h6>Customer Address</h6>
                    </div>
                    <hr />
                    <div class="p-3 m-3 text-center">
                        <asp:Label ID="CustomerName" ForeColor="Gray" Font-Bold="true" runat="server"></asp:Label><br />
                        <asp:Label ID="CustomerMobile" ForeColor="Gray" Font-Bold="true" runat="server"></asp:Label><br />
                        <asp:Label ID="CustomerEmail" ForeColor="Gray" Font-Bold="true" runat="server"></asp:Label><br />
                        <asp:Label ID="CustomerAdress" ForeColor="Gray" Font-Bold="true" runat="server" Text="Artcandervilla store New Delhi India 110043"></asp:Label>
                    </div>
                </div>
                
            </div>
            <div class="row">
                <div class="mt-2 col-6 offset-3 shadow">
                    <div class="text-center mt-2">
                        <h6>Product Specification</h6>
                    </div>
                    <hr />
                    <div class="p-3 m-3 text-center">
                        <asp:Label ID="LblOrderid" ForeColor="Gray" Font-Bold="true" runat="server" Text="Order id:- 11Cm"></asp:Label><br />
                        <asp:Label ID="Lblproductid" ForeColor="Gray" Font-Bold="true" runat="server" Text="Product id:-11Cm"></asp:Label><br />
                        <asp:Label ID="Lblproductrefid" ForeColor="Gray" Font-Bold="true" runat="server" Text="Productrefid id:-11Cm"></asp:Label><br />
                        <asp:Label ID="LblLogisticsorder" ForeColor="Gray" Font-Bold="true" runat="server" Text="Order id(Logistics) :-11Cm"></asp:Label><br />
                        <asp:Label ID="Lblheight" ForeColor="Gray" Font-Bold="true" runat="server" Text="Height:-11Cm"></asp:Label><br />
                        <asp:Label ID="Lblwidth" ForeColor="Gray" Font-Bold="true" runat="server" Text="Width:-11Cm"></asp:Label><br />
                        <asp:Label ID="Lbllength" ForeColor="Gray" Font-Bold="true" runat="server" Text="Length:-11Cm"></asp:Label><br />
                        <asp:Label ID="lblweight" ForeColor="Gray" Font-Bold="true" runat="server" Text="Weight:-11Cm"></asp:Label><br />
                    </div>
                </div>
            </div>
            <div>
                <a href="#" data-bs-toggle="modal" data-bs-target="#modalaccept" class="btn btn-dark w-100 mt-4">Ship</a>
            </div>
        </div>
    </div>

    <!----modal accept----->
    <div class="modal fade" id="modalaccept" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="exampleModalLabel">Fill Delivery Details</h5>
                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                </div>
                <div class="modal-body">
                    <div class="modal-body">
                        <div class="mb-3">
                            <label for="recipient-name" class="col-form-label">Tracking id:</label>
                            <asp:TextBox ID="Txttracking" required  CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                        <div class="mb-3">
                            <label for="recipient-name" class="col-form-label">Expected Pickup Date:</label>
                            <asp:TextBox ID="TxtDelivered" required CssClass="form-control" TextMode="Date" runat="server"></asp:TextBox>
                        </div>
                        <div class="mb-3">
                            <label for="recipient-name" class="col-form-label">Shipping Charge:</label>
                            <asp:TextBox ID="TxtShippingPrice" required CssClass="form-control" TextMode="Number" runat="server"></asp:TextBox>
                        </div>
                    </div>

            </div>
                <asp:LinkButton ID="btnShip" OnClick="btnShip_Click" CssClass="btn btn-dark" runat="server">Send</asp:LinkButton>
        </div>
    </div>
    </div>
    <!----modal accept----->

           <!-----bootstrap js----->
   <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/js/bootstrap.bundle.min.js" integrity="sha384-MrcW6ZMFYlzcLA8Nl+NtUVF0sA7MsXsP1UyJoMp4YLEuNSfAP+JcXn/tWtIaxVXM" crossorigin="anonymous"></script>
   <script src="https://code.jquery.com/jquery-3.7.1.min.js" integrity="sha256-/JqT3SQfawRcv/BIHPThkBvs0OEvtFFmqPF/lYI/Cxo=" crossorigin="anonymous"></script>
   <!-----Jquery For Filtering rows in Table--->
   <script src="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-sweetalert/1.0.1/sweetalert.js"></script>
</asp:Content>
