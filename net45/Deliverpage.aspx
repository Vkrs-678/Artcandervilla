<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Deliverpage.aspx.cs" Inherits="RazorpaySampleApp.WebForm22" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap-sweetalert@1.0.1/dist/sweetalert.min.css">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel ID="Panel1" runat="server">
         <div class="container-fluid">

     <div class="col-sm-8 offset-sm-2 col-lg-6 offset-lg-3 col-xl-4 offset-xl-4 text-center" style="margin-top:20vh">
         <asp:HiddenField ID="HiddenField1" runat="server" />
         <div class="rounded bg-white shadow p-5">
             <h5><span style="color: deeppink; font-family: cursive; font-weight: 600">Art</span><span style="color: forestgreen; font-family: cursive; font-weight: 600">-Candervilla</span></h5>
             <div class="form-floating mb-3 mt-4">
                 <asp:TextBox ID="TxtDeliverboyid" class="form-control shadow" TextMode="Password" placeholder="Mobile Number" Style="border-color: #f1ecec; box-shadow: 0px 0px 0px hotpink" runat="server"></asp:TextBox>
                 <label for="TxtDeliverboyid">Delivery Person's Id</label>
             </div>
             <div class="text-center">
                 <asp:LinkButton ID="LnkNext" OnClick="LnkNext_Click"  CssClass="btn btn-dark mt-3 w-100" runat="server">Next</asp:LinkButton>
             </div>
           
         </div>
         <asp:HiddenField ID="Hdnalreadydelivered" runat="server" />

     </div>
 </div>
    </asp:Panel>
     <asp:Panel ID="Panel2" runat="server">
         <div class="container-fluid">
             <asp:HiddenField ID="HdnEmail" runat="server" />
             <asp:HiddenField ID="Hdnorderid" runat="server" />
             <asp:HiddenField ID="Hdnproductname" runat="server" />
             <asp:HiddenField ID="HdnImageurl" runat="server" />
             <asp:HiddenField ID="Hdnusername" runat="server" />
             <asp:HiddenField ID="HdnPaymentmode" runat="server" />
             <asp:HiddenField ID="HdnTotalPrice" runat="server" />
             <div class="col-sm-8 offset-sm-2 col-lg-6 offset-lg-3 col-xl-4 offset-xl-4 text-center" style="margin-top: 20vh">

                 <div class="rounded bg-white shadow p-5">
                     <h5><span style="color: deeppink; font-family: cursive; font-weight: 600">Art</span><span style="color: forestgreen; font-family: cursive; font-weight: 600">-Candervilla</span></h5>
                   
                     <div class="text-center">
                         <asp:LinkButton ID="LnkSendOtp" OnClick="LnkSendOtp_Click" CssClass="btn btn-dark mt-3 w-100" runat="server">Send OTP To Customers</asp:LinkButton>
                     </div>

                 </div>


             </div>
         </div>

     </asp:Panel>
     <asp:Panel ID="Panel3" runat="server">
         <div class="container-fluid">
             
             <div class="col-sm-8 offset-sm-2 col-lg-6 offset-lg-3 col-xl-4 offset-xl-4 text-center" style="margin-top: 20vh">

                 <div class="rounded bg-white shadow p-5">
                     <h5><span style="color: deeppink; font-family: cursive; font-weight: 600">Art</span><span style="color: forestgreen; font-family: cursive; font-weight: 600">-Candervilla</span></h5>
                     <div class="form-floating mb-3 mt-4">
                         <asp:TextBox ID="TxtOtpUser" class="form-control shadow" TextMode="Phone" MaxLength="4" placeholder="Mobile Number" Style="border-color: #f1ecec; box-shadow: 0px 0px 0px hotpink" runat="server"></asp:TextBox>
                         <label for="TxtEmail">Enter OTP</label>
                     </div>
                     <div class="text-center">
                         <asp:LinkButton ID="LnkDeliver" OnClick="LnkDeliver_Click" CssClass="btn btn-dark mt-3 w-100" runat="server">Deliver</asp:LinkButton>
                     </div>

                 </div>


             </div>
         </div>
     </asp:Panel>
        <!---sweet alert---->
<script src="https://cdn.jsdelivr.net/npm/bootstrap-sweetalert@1.0.1/dist/sweetalert.min.js"></script>
     <script>
   window.history.forward();
     </script>
</asp:Content>
