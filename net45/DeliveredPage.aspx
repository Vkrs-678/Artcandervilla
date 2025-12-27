<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="DeliveredPage.aspx.cs" Inherits="RazorpaySampleApp.WebForm26" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <h4 class="text-center"  style="margin-top: 130px">Order To Ship</h4>
    <div class="container shadow" >
         
        <div class="row">
            <div class="col">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <table class="table table-hover">
                            <thead>
                                <tr>
                                    <th>Order Id</th>
                                    <th>Order Date</th>
                                    <th>Shiped Date</th>
                                    <th>Images</th>
                                    <th>Action</th>
                                </tr>
                            </thead>
                            <tbody>
                                <asp:Repeater ID="RptrProducts" runat="server">
                                    <ItemTemplate>
                                        <tr>
                                            <td><%#Eval("orderid") %></td>
                                            <td><%#Convert.ToDateTime(Eval("orderdate")).ToString("dd/MM/yyyy") %></td>
                                            <td><%#Convert.ToDateTime(Eval("deliverydate")).ToString("dd/MM/yyyy") %></td>                                           
                                            <td>
                                                <asp:Image ID="Image1" Height="100px" Width="100px" runat="server" ImageUrl='<%#Eval("productimage") %>' />

                                            </td>                                           
                                            <td>
                                                <asp:LinkButton ID="btnDelivered" OnClick="btnDelivered_Click" CssClass="btn btn-dark" runat="server">Delivered</asp:LinkButton>
                                            </td>
                                            <td></td>
                                            <asp:HiddenField ID="Hdnorderid" runat="server" Value='<%#Eval("orderid") %>' />
                                            <asp:HiddenField ID="Hdnproductname" runat="server" Value='<%#Eval("productname") %>' />
                                            <asp:HiddenField ID="Hdnimage" runat="server" Value='<%#Eval("productimage") %>' />
                                            <asp:HiddenField ID="Hdnusername" runat="server" Value='<%#Eval("Nameofthecustomer")%>' />
                                            <asp:HiddenField ID="Hdnemail" runat="server" Value='<%#Eval("email") %>' />
                                            <asp:HiddenField ID="Hdnpaymentmode" runat="server" Value='<%#Eval("paymentMode") %>' />
                                            <asp:HiddenField ID="Hdnprice" runat="server" Value='<%#Eval("buyPrice") %>' />
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>

                            </tbody>
                        </table>
                    </ContentTemplate>
                    
                </asp:UpdatePanel>



            </div>
        </div>
    </div>
</asp:Content>
