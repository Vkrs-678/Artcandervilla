<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="returnpage.aspx.cs" Inherits="RazorpaySampleApp.WebForm29" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .container .row .col-12 .text-start{
            margin-left:580px;
        }

        @media(min-width:344px) and (max-width:882px){
            .container .row .col-12 .text-start {
                margin-left: 90px;
            }
        }

        @media(min-width:768px) and (max-width:1024px) {
            .container .row .col-12 .text-start {
                margin-left: 280px;
            }
        }

        @media(min-width:1024px) and (max-width:1366px) {
            .container .row .col-12 .text-start {
                margin-left: 400px;
            }
        }
    </style>
     <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap-sweetalert@1.0.1/dist/sweetalert.min.css">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container" style="margin-top:100px">
        <h5 class="text-center">Return Page</h5>
        <hr />
        <div class="row">
            <div class="col-12">
                <div class="text-center">
                    <asp:Image ID="Image1" Height="200px" Width="150px" CssClass="img fluid img-thumbnail" ImageUrl="https://m.media-amazon.com/images/I/618l+SmWivL._SY741_.jpg" runat="server" />
                </div>
                <br />
                <div class="text-start">
                    <asp:RadioButton ID="RdoDefecteditem" BorderColor="Yellow" GroupName="Return" Text="Defective Item" runat="server" /><br /><br />
                    <asp:RadioButton ID="Rdowrongitem" GroupName="Return" Text="Wrong Item Delivered" runat="server" /><br /><br />
                    <asp:RadioButton ID="Rdosizeorfitissue" GroupName="Return" Text="Size or Fit Issue" runat="server" /><br /><br />                   
                    <asp:RadioButton ID="RdoBetterpricefound" GroupName="Return" Text="Better Price Found" runat="server" /><br /><br />                   
                    <asp:RadioButton ID="Rdocolorstyle" GroupName="Return" Text="Color/Style Mismatch" runat="server" /><br /><br />        
                    <asp:RadioButton ID="Rdootherreason" onclick="visiblereason()" GroupName="Return" Text="Other Reason" runat="server" />
                </div>
               
                <div class="text-center">
                    <asp:TextBox ID="TxtotherReason"  style="display:none" TextMode="MultiLine" Rows="7" placeholder="Please Mention Your Reason" CssClass="form-control" runat="server"></asp:TextBox>
                </div><br />

                <div>
                    <asp:LinkButton ID="btnSubmitReason" OnClick="btnSubmitReason_Click" OnClientClick="return AreYouSure(this)" runat="server" CssClass="btn btn-dark w-100">Submit Request</asp:LinkButton>
                </div><br />
            </div>
        </div>
    </div>
    <script>
        function visiblereason(){

            document.getElementById('<%=TxtotherReason.ClientID%>').style.display = 'block';

        }

        var obj = { status: false, ele: null };
        function AreYouSure(ev) {
            if (obj.status) {
                return true;
            };
            swal({
                title: "Are you sure?",
                text: "Are You Sure Want To Return this product ?",
                type: "warning",
                showCancelButton: true,
                confirmButtonClass: "btn-primary",
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
    </script>
      <script src="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-sweetalert/1.0.1/sweetalert.js"></script>
</asp:Content>
