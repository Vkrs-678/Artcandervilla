<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="CancelRefund.aspx.cs" Inherits="RazorpaySampleApp.WebForm33" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
      <!-----sweet alert---->
<link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap-sweetalert@1.0.1/dist/sweetalert.min.css">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
            <div class="row d-flex" style="margin-top:100px">
        <asp:TextBox ID="TxtSearch" runat="server" placeholder="Enter Orderid" CssClass="form-control w-50"></asp:TextBox>
        <asp:LinkButton ID="LnkSearch" OnClick="LnkSearch_Click" CssClass="btn btn-danger w-25" runat="server">Search</asp:LinkButton>
    </div><br /><br /
        <div class="row">                    
            <div class="col">
                <table class="table table-hover">
                    <thead class="bg-dark text-white">
                        <tr>
                            <th>Product Id</th>
                            <th>Reference Id</th>
                            <th>Order Id</th>
                            <th>Order Id</th>
                            <th>Price</th>                           
                            <th>Images</th>
                            <th>Refund Date</th>                           
                            <th>Action</th>
                        </tr>
                    </thead>

                    <tbody>
                        <asp:Repeater ID="RptrProducts" runat="server">

                            <ItemTemplate>


                                <tr>
                                    <td><asp:Label ID="lblproductid" runat="server" Text='<%#Eval("productid") %>'></asp:Label></td>
                                    <td><asp:Label ID="lblproductrefid" runat="server" Text='<%#Eval("productrefid") %>'></asp:Label></td>
                                    <td><asp:Label ID="lblorderid" runat="server" Text='<%#Eval("orderid") %>'></asp:Label></td>
                                     <td><%#Convert.ToDateTime(Eval("orderdate")).ToString("dd/mm/yyyy") %></td>
                                    <td>
                                        <asp:Label ID="Lblprice" runat="server" Text='<%#(Convert.ToInt32(Eval("buyPrice"))+Convert.ToInt32(Eval("deliveryprice"))).ToString() %>'></asp:Label></td>                                    
                                    <td>
                                        <asp:Image ID="Image1" Height="100px" Width="100px" runat="server" ImageUrl='<%#Eval("productimage") %>' /></td>
                                    <td>
                                        <%#Eval("refunddate")%>
                                    </td>
                                  
                                    <td class="d-flex">
                                        <asp:HiddenField ID="Hdnusername" Value='<%#Eval("Nameofthecustomer")%>' runat="server" />                 
                                        <asp:HiddenField ID="Hdnuseremail" Value=' <%#Eval("email")%>' runat="server" />                                                          
                                        <asp:HiddenField ID="hdnpaymentmode" Value=' <%#Eval("paymentMode")%>' runat="server" />                                                          
                                        <asp:LinkButton ID="btnRefund" OnClick="btnRefund_Click" OnClientClick="return AreYouSureAccept(this)" runat="server" CssClass="btn btn-danger">Refund</asp:LinkButton>
                                    </td>
                                    

                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>

                    </tbody>
                </table>



            </div>
        </div>
    </div>
        <!---sweet alert---->
<script src="https://cdn.jsdelivr.net/npm/bootstrap-sweetalert@1.0.1/dist/sweetalert.min.js"></script>
    <script>
        var obj = { status: false, ele: null };
        function AreYouSureAccept(ev) {
            if (obj.status) {
                return true;
            };
            swal({
                title: "Are you sure?",
                text: "Are You Sure Want To Refund?",
                type: "warning",
                showCancelButton: true,
                confirmButtonClass: "btn-danger",
                confirmButtonText: "Yes, Refund it!",
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
