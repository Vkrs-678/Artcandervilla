<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="AdminLogin.aspx.cs" Inherits="RazorpaySampleApp.WebForm4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
      <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap-sweetalert@1.0.1/dist/sweetalert.min.css">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <asp:Panel ID="Panelforgotpassword" runat="server">
    <section class="wrapper" style="margin-top: 120px">
        <div class="container">

            <div class="col-sm-8 offset-sm-2 col-lg-6 offset-lg-3 col-xl-4 offset-xl-4 text-center">

                <div class="rounded bg-white shadow p-5">
                    <h5><span style="color: deeppink; font-family: cursive; font-weight: 600">Art</span><span style="color: forestgreen; font-family: cursive; font-weight: 600">-Candervilla</span></h5>
                    <span class="text-dark text-muted mb-5 fw-bold" style="cursor: auto">Admin Window </span>
                   
                    <div class="form-floating mb-3 mt-4">
                        <asp:TextBox ID="TxtEmail" class="form-control shadow" TextMode="Password" placeholder="Mobile Number" Style="border-color: #f1ecec; box-shadow: 0px 0px 0px hotpink" runat="server"></asp:TextBox>
                        <label for="TxtEmail">Admin</label>
                    </div>                
                    
                    <div class="text-center">
                        <asp:LinkButton ID="LnkSendOtp" OnClick="LnkSendOtp_Click"   CssClass="btn btn-primary mt-3 w-100" runat="server">Send OTP</asp:LinkButton>
                    </div>
                  
                 
                </div>


            </div>
        </div>
    </section>
</asp:Panel>

    <asp:Panel ID="PanelEnterOTp" runat="server">
        <section class="wrapper" style="margin-top: 120px">
            <div class="container">

                <div class="col-sm-8 offset-sm-2 col-lg-6 offset-lg-3 col-xl-4 offset-xl-4 text-center">

                    <div class="rounded bg-white shadow p-5">
                        <h5><span style="color: deeppink; font-family: cursive; font-weight: 600">Art</span><span style="color: forestgreen; font-family: cursive; font-weight: 600">-Candervilla</span></h5>


                        <div class="form-floating mb-3 mt-4">
                            <asp:TextBox ID="TxtEnterOtp" class="form-control shadow fw-bold" TextMode="Phone" MaxLength="10" placeholder="Mobile Number" Style="border-color: #f1ecec; box-shadow: 0px 0px 0px hotpink" runat="server"></asp:TextBox>
                            <label for="TxtMobileNo">Enter OTP</label>
                        </div>

                        <div class="text-center">
                            <asp:LinkButton ID="LnkEnterotp" OnClick="LnkEnterotp_Click"  CssClass="btn btn-primary mt-3 w-100" runat="server">Enter OTP</asp:LinkButton>
                        </div>


                    </div>


                </div>
            </div>
        </section>
    </asp:Panel>

            <!---sweet alert---->
<script src="https://cdn.jsdelivr.net/npm/bootstrap-sweetalert@1.0.1/dist/sweetalert.min.js"></script>
</asp:Content>
