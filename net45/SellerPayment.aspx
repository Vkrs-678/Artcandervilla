<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="SellerPayment.aspx.cs" Inherits="RazorpaySampleApp.WebForm32" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid" style="margin-top:100px">
       
        <div class="row" style="overflow-y:scroll;overflow-x:scroll">
            <div class="d-flex mb-3">
                <asp:TextBox ID="Txtordersearch" CssClass="form-control" Placeholder="Enter Orderid" runat="server"></asp:TextBox>
                <asp:LinkButton ID="Lnksearch" OnClick="Lnksearch_Click" CssClass="btn btn-dark" runat="server">Search</asp:LinkButton>
            </div>
             
            <div class="col-12">
                <table class="table table-hover table-bordered">
    <thead class="bg-dark text-white">
        <tr>
              <th>Order Id</th>
              <th>Order date</th>
            <th>Product Id</th>
            <th>Reference Id</th>
              <th>Images</th>
              <th>Qty</th>
              <th>Size</th>
            <th>SellerName</th>
            <th>Seller Mobile</th>
            <th>Seller Email</th>
            <th>Settlement Amount</th>                       
            <th>Payment Mode</th>                       
            <th>Status</th>
            <th>Settlement Date</th>
            <th>Action</th>
        </tr>
    </thead>

    <tbody>
        <asp:Repeater ID="RptrProducts" OnItemDataBound="RptrProducts_ItemDataBound" runat="server">

            <ItemTemplate>


                <tr>
                    <td><%#Eval("orderid") %></td>
                    <td><%# Convert.ToDateTime( Eval("orderdate")).ToString("dd/MM/yyyy") %></td>
                    <td><%#Eval("productid") %></td>
                    <td><%#Eval("ProductReferenceId")%></td>
                    <td>
                        <asp:Image ID="Image1" Height="100px" Width="100px" runat="server" ImageUrl='<%#Eval("productimage") %>' />
                    </td>
                    <td><%#Eval("quantity") %></td>
                    <td><%#Eval("size") %></td>                                      
                    <td><%#Eval("SellerName").ToString() %></td>
                    <td><%#(Eval("Mobile"))%></td>
                    <td><%#(Eval("Email"))%></td>
                    <td><%#Math.Round(Convert.ToDouble(Eval("Revenue Generated")),0) %></td>  
                    <td><%#(Eval("paymentMode")) %></td>                      
                    <td>
                        <%#Eval("Settlement")%>
                    </td>
                    <td>
                        <%#(Eval("settleMentDAte")) %>
                    </td>
                    <td class="d-flex">
                        <asp:HiddenField ID="Hdnorderid" Value='<%#Eval("orderid") %>' runat="server" />                       
                        <asp:HiddenField ID="Hdnproductid" Value='<%#Eval("productid") %>' runat="server" />                       
                        <asp:HiddenField ID="Hdproductrefid" Value='<%#Eval("ProductReferenceId") %>' runat="server" />                       
                        <asp:HiddenField ID="HdnEmail" Value='<%#Eval("Email") %>' runat="server" />                       
                        <asp:HiddenField ID="HdnproductImage" Value='<%#Eval("productimage") %>' runat="server" />                       
                        <asp:HiddenField ID="Hdnproductname" Value='<%#Eval("productdetail") %>' runat="server" />                       
                        <asp:HiddenField ID="Hdnproductamount" Value='<%#Eval("Revenue Generated") %>' runat="server" />                       
                        <asp:HiddenField ID="Hdnproductqty" Value='<%#Eval("quantity") %>' runat="server" />                       
                        <asp:HiddenField ID="Hdnproductsize" Value='<%#Eval("size") %>' runat="server" />                       
                        <asp:HiddenField ID="Hdnpaymentmode" Value='<%#Eval("paymentMode") %>' runat="server" />                       
                        <asp:HiddenField ID="Hdnsettled" Value='<%#Eval("Settlement")%>' runat="server" />                       
                        <asp:LinkButton ID="BtnPayNow" OnClick="BtnPayNow_Click" OnClientClick="return AreYouSure(this)" runat="server" CssClass="btn btn-danger">Pay Now</asp:LinkButton>
                    </td>                                                     
                </tr>
            </ItemTemplate>
        </asp:Repeater>

    </tbody>
</table>
            </div>
        </div>
    </div>
    <script>
        var obj = { status: false, ele: null };
        function AreYouSure(ev) {
            if (obj.status) {
                return true;
            };
            swal({
                title: "Are you sure?",
                text: "Are You Sure Want To Pay the Settlement ?",
                type: "warning",
                showCancelButton: true,
                confirmButtonClass: "btn-dark",
                confirmButtonText: "Yes,Pay Now!",
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
