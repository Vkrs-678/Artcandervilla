<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="AdminDashbord.aspx.cs" Inherits="RazorpaySampleApp.WebForm5" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <asp:Panel ID="PanelLogin" runat="server">
     <section class="wrapper" style="margin-top: 120px">

         <div class="container-fluid">

             <div class="col-sm-8 offset-sm-2 col-lg-6 offset-lg-3 col-xl-4 offset-xl-4 text-center">

                 <div class="rounded bg-white shadow p-5">
                     <h5><span style="color: deeppink; font-family: cursive; font-weight: 600">Art</span><span style="color: forestgreen; font-family: cursive; font-weight: 600">-Candervilla</span></h5>
                     <span class="text-dark text-muted mb-5 fw-bold" style="cursor: auto">HELLO ADMIN <i class="fa-regular fa-face-smile fa-bounce" style="color: #FFD43B;"></i></span>
                     <br /><asp:Label ID="LblAdminName" class="text-dark text-muted mb-5 fw-bold" runat="server" Text="AMAN"></asp:Label>
                     <div class="text-center">
                         <asp:LinkButton ID="LnkLogin" OnClick="LnkLogin_Click" CssClass="btn btn-dark mt-3 w-100" runat="server">Manage Seller</asp:LinkButton>
                     </div>
                     <div class="text-center">
                         <asp:LinkButton ID="LnManagerBuyers" OnClick="LnManagerBuyers_Click" CssClass="btn btn-dark mt-3 w-100" runat="server">Manage Buyers</asp:LinkButton>
                     </div>
                     <div class="text-center">
                         <asp:LinkButton ID="LnkManageproducts" OnClick="LnkManageproducts_Click"  CssClass="btn btn-dark mt-3 w-100" runat="server">Manage Products</asp:LinkButton>
                     </div>

                     <div class="text-center">
                         <asp:LinkButton ID="LnkAddCatSub" OnClick="LnkAddCatSub_Click" CssClass="btn btn-dark mt-3 w-100" runat="server">Add Category And SubCategory</asp:LinkButton>
                     </div>
                     <div class="text-center">
                         <asp:LinkButton ID="LnkShipProduct" OnClick="LnkShipProduct_Click" CssClass="btn btn-dark mt-3 w-100" runat="server">Ship Products</asp:LinkButton>
                     </div>

                     <div class="text-center">
                         <asp:LinkButton ID="LnkDelivery" OnClick="LnkDelivery_Click" Visible="false" CssClass="btn btn-dark mt-3 w-100" runat="server">Final Delivery</asp:LinkButton>
                     </div>
                     <div class="text-center">
                         <asp:LinkButton ID="LnkFinalDeliveryPage" OnClick="LnkFinalDeliveryPage_Click" CssClass="btn btn-dark mt-3 w-100" runat="server">Final Delivery Update</asp:LinkButton>
                     </div>
                     <div class="text-center">
                         <asp:LinkButton ID="LnkreturnRequest" OnClick="LnkreturnRequest_Click" CssClass="btn btn-dark mt-3 w-100" runat="server">Return Requests</asp:LinkButton>
                     </div>
                     <div class="text-center">
                         <asp:LinkButton ID="LnkSellerPayment" OnClick="LnkSellerPayment_Click" CssClass="btn btn-dark mt-3 w-100" runat="server">Payment To Seller</asp:LinkButton>
                     </div>
                     <div class="text-center">
                         <asp:LinkButton ID="LnkCancelRefund" OnClick="LnkCancelRefund_Click" CssClass="btn btn-dark mt-3 w-100" runat="server">Refund of Cancel Products</asp:LinkButton>
                     </div>
                 </div>


             </div>
         </div>
     </section>
 </asp:Panel>
</asp:Content>
