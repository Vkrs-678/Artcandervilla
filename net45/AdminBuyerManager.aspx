<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="AdminBuyerManager.aspx.cs" Inherits="RazorpaySampleApp.WebForm8" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <!----Bootstrap--->
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-EVSTQN3/azprG1Anm3QDgpJLIm9Nao0Yz1ztcQTwFspd3yD65VohhpuuCOmLASjC" crossorigin="anonymous">

    <script src="magnific-popup/jquery.magnific-popup.js"></script>
    <script src="https://code.jquery.com/jquery-3.7.1.min.js" integrity="sha256-/JqT3SQfawRcv/BIHPThkBvs0OEvtFFmqPF/lYI/Cxo=" crossorigin="anonymous"></script>
    <script>
        var obj = { status: false, ele: null };
        function AreYouSure(ev) {
            if (obj.status) {
                return true;
            };
            swal({
                title: "Are you sure?",
                text: "Your will not be able to recover this imaginary file!",
                type: "warning",
                showCancelButton: true,
                confirmButtonClass: "btn-danger",
                confirmButtonText: "Yes, delete it!",
                closeOnConfirm: true
            },
                function () {
                    obj.status = true;
                    obj.ele = ev;
                    obj.ele.click();
                });

            return false;
        }


        function AreYouSureApprove(ev) {
            if (obj.status) {
                return true;
            };
            swal({
                title: "Approve?",
                text: "Seller Account Will Approve ?",
                type: "info",
                showCancelButton: true,
                confirmButtonClass: "btn-success",
                confirmButtonText: "Yes, Approved",
                closeOnConfirm: true
            },
                function () {
                    obj.status = true;
                    obj.ele = ev;
                    obj.ele.click();
                });

            return false;
        }

        function AreYouSureApprove(ev) {
            if (obj.status) {
                return true;
            };
            swal({
                title: "Approve?",
                text: "Seller Account Will Approve ?",
                type: "info",
                showCancelButton: true,
                confirmButtonClass: "btn-success",
                confirmButtonText: "Yes, Approved",
                closeOnConfirm: true
            },
                function () {
                    obj.status = true;
                    obj.ele = ev;
                    obj.ele.click();
                });

            return false;
        }


        function AreYouSureDisApprove(ev) {
            if (obj.status) {
                return true;
            };
            swal({
                title: "DisApprove?",
                text: "Seller DisApprove Will Approve ?",
                type: "info",
                showCancelButton: true,
                confirmButtonClass: "btn-danger",
                confirmButtonText: "Yes, DisApprove",
                closeOnConfirm: true
            },
                function () {
                    obj.status = true;
                    obj.ele = ev;
                    obj.ele.click();
                });

            return false;
        }


        function AreYouSureDeActivate(ev) {
            if (obj.status) {
                return true;
            };
            swal({
                title: "DiActivate?",
                text: "Seller Account Will DiActivate ?",
                type: "info",
                showCancelButton: true,
                confirmButtonClass: "btn-danger",
                confirmButtonText: "Yes, DiActivate",
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
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid shadow">
        <div class="row" style="margin-top: 90px">
            <div class="col">
                <div>
                    <input type="text" class="search" />
                </div>
                <div>

                    <table class="table table-hover" id="userTbl">
                        <thead>
                            <tr>
                                <th style="display: none">id</th>
                                <th>Name</th>
                                <th>Mobile</th>
                                <th>Email</th>
                                <th>RegistrationType</th>
                                <th>Status</th>
                                <th>Action</th>

                            </tr>

                        </thead>
                        <asp:Repeater ID="RptrBuyerData" runat="server">
                            <ItemTemplate>
                                <tbody>
                                    <tr>
                                        <td style="display: none">
                                            <asp:Label ID="Lbluserid" runat="server" Text='<%# Eval("userid") %>'></asp:Label>
                                        </td>
                                        <td>
                                            <h6><%# Eval("username") %></h6>
                                        </td>
                                        <td>
                                            <h6><%# Eval("usermobile") %></h6>
                                        </td>
                                        <td>
                                            <h6><%# Eval("useremail") %></h6>
                                        </td>
                                        <td>
                                            <h6><%# Eval("registrationtype") %></h6>
                                        </td>
                                        <td>
                                            <asp:Label ID="LblStatus" runat="server" Text='<%# Eval("is_Approved").ToString()=="1"?"Apporved":"DisApproved" %>'></asp:Label>
                                        </td>
                                        <td>
                                            <asp:LinkButton ID="Lnkapprove" OnClientClick="return AreYouSureApprove(this)" OnClick="Lnkapprove_Click" CssClass="btn btn-success" ToolTip="Approve" runat="server"><i class="fa-solid fa-person-circle-check" style="color: #fcfbf7;"></i></asp:LinkButton>
                                             <asp:LinkButton ID="LinkButton1" OnClientClick="return AreYouSureDisApprove(this)" OnClick="LinkButton1_Click" ToolTip="DisApprove" CssClass="btn btn-danger" runat="server"><i class="fa-solid fa-thumbs-down" style="color: #ffffff;"></i></asp:LinkButton>
                                             <asp:LinkButton ID="LinkButton4" OnClientClick="return AreYouSure(this)" OnClick="LinkButton4_Click" ToolTip="Delete" CssClass="btn btn-danger" runat="server"><i class="fa-solid fa-trash" style="color: #fbfcfe;"></i></asp:LinkButton>
                                        </td>

                                    </tr>
                                </tbody>                                                        
                            </ItemTemplate>
                        </asp:Repeater>
                    </table>
                </div>
            </div>
        </div>
    </div>

    <!-----bootstrap js----->
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/js/bootstrap.bundle.min.js" integrity="sha384-MrcW6ZMFYlzcLA8Nl+NtUVF0sA7MsXsP1UyJoMp4YLEuNSfAP+JcXn/tWtIaxVXM" crossorigin="anonymous"></script>
    <script src="https://code.jquery.com/jquery-3.7.1.min.js" integrity="sha256-/JqT3SQfawRcv/BIHPThkBvs0OEvtFFmqPF/lYI/Cxo=" crossorigin="anonymous"></script>
    <!-----Jquery For Filtering rows in Table--->
    <script>
        $(document).ready(function () {
            $('.search').on('keyup', function () {
                var searchTerm = $(this).val().toLowerCase();
                $('#userTbl tbody tr').each(function () {
                    var lineStr = $(this).text().toLowerCase();
                    if (lineStr.indexOf(searchTerm) === -1) {
                        $(this).hide();
                    } else {
                        $(this).show();
                    }
                });
            });
        });


    </script>
   
</asp:Content>
