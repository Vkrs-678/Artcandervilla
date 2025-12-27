<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="SellerPrintLabel.aspx.cs" Inherits="RazorpaySampleApp.WebForm27" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   
    <div class="container-fluid shadow" style="margin-top: 130px">
         <h4 class="text-center">Print Label For Shipment</h4>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div class="row">
                    <div class="col">
                        <table class="table table-hover">
                            <thead>
                                <tr>
                                    <th>Product Id</th>                                   
                                    <th>Reference Id</th>                                   
                                    <th>Order Id</th>                                   
                                    <th>Price</th>
                                    <th>Pickup date</th>
                                    <th>Images</th>
                                    <th>Print Label</th>
                                </tr>
                            </thead>
                          
                            <tbody>
                                <asp:Repeater ID="RptrProducts" runat="server">

                                    <ItemTemplate>


                                        <tr>
                                            <td><%#Eval("productid") %></td>                                           
                                            <td><%#Eval("productrefid") %></td>                                           
                                            <td><%#Eval("orderid") %></td>                                           
                                            <td><%#(Convert.ToInt32(Eval("buyPrice"))+Convert.ToInt32(Eval("deliveryprice"))).ToString() %></td> 
                                             <td><%#Convert.ToDateTime(Eval("pickup")).ToString("dd/MM/yyyy") %></td> 
                                            <td>
                                                <asp:Image ID="Image1" Height="100px" Width="100px" runat="server" ImageUrl='<%#Eval("productimage") %>' /></td>
                                            <td>
                                                <asp:HiddenField ID="Hdnawbno" Value='<%#Eval("awb") %>' runat="server" />
                                               <asp:LinkButton ID="btnPrintlabel" runat="server" OnClick="btnPrintlabel_Click" CssClass="btn btn-dark">Print Shipment Label</asp:LinkButton>
                                            </td>
                                            <td></td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>

                            </tbody>
                        </table>
                          <asp:Label ID="dfd" runat="server"></asp:Label>
                        <!-- Button trigger modal -->
                        <button type="button" id="showmodalbutton" style="display: none" class="btn btn-primary" data-bs-toggle="modal" data-bs-target="#showviewmodal">
                            Launch demo modal
                        </button>


                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>

    </div>
</asp:Content>
