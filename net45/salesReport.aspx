<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="salesReport.aspx.cs" Inherits="RazorpaySampleApp.WebForm31" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid" style="margin-top:100px">
        <div class="row">
            <div class="col-6">
              
                <asp:TextBox ID="fromDate" TextMode="Date" runat="server" CssClass="form-control w-25 float-end"></asp:TextBox>
            </div>             
            <div class="col-6 d-flex">
              
                <asp:TextBox ID="ToDate" TextMode="Date" runat="server" CssClass="form-control w-25"></asp:TextBox>
                <asp:LinkButton ID="Searchbtn" runat="server" OnClick="Searchbtn_Click" CssClass="btn btn-dark">Search</asp:LinkButton>
            </div>
            <div class="col-6"></div>
        </div><br />
        <div class="row">
            <div class="col-3">
                <asp:LinkButton ID="btnDelivered" runat="server" OnClick="btnDelivered_Click" CssClass="btn btn-dark w-100">Delivered</asp:LinkButton>
            </div>
            <div class="col-2">
                <asp:LinkButton ID="LnkReturn" runat="server" OnClick="LnkReturn_Click" CssClass="btn btn-dark w-100">Return</asp:LinkButton>
            </div>
            <div class="col-3">
                <asp:LinkButton ID="LnkCancelled" OnClick="LnkCancelled_Click" runat="server" CssClass="btn btn-dark w-100">Cancelled</asp:LinkButton>
            </div>
            <div class="col-2">
                <asp:LinkButton ID="LnkSetteled" runat="server" OnClick="LnkSetteled_Click" CssClass="btn btn-dark w-100">Settled</asp:LinkButton>
            </div>
            <div class="col-2">
                <asp:LinkButton ID="LnkUnsettled" OnClick="LnkUnsettled_Click" runat="server" CssClass="btn btn-dark w-100">UnSettled</asp:LinkButton>
            </div>
        </div><br />
        <div class="row">
             <asp:LinkButton ID="LinkReport" CssClass="btn btn-dark w-25 float-end" OnClick="LinkReport_Click" runat="server">Generate Excel Report</asp:LinkButton>
            <div class="col-12" style="height:100vh;overflow-y:scroll">
               
                <asp:GridView ID="GridSaleReport" class="table table-hover table-bordered" runat="server">                    
                </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>
