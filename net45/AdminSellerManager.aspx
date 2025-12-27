<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="AdminSellerManager.aspx.cs" Inherits="RazorpaySampleApp.WebForm7" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        #buttonclose:focus {
            box-shadow: none;
            color: white;
        }
    </style>

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

        function AreYouSureDelete(ev) {
            if (obj.status) {
                return true;
            };
            swal({
                title: "Delete?",
                text: "Seller Account Will be Deleted ?",
                type: "warning",
                showCancelButton: true,
                confirmButtonClass: "btn-danger",
                confirmButtonText: "Yes, Delete",
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
                title: "Disapprove?",
                text: "Seller DisApprove Will Approve ?",
                type: "info",
                showCancelButton: true,
                confirmButtonClass: "btn-danger",
                confirmButtonText: "Yes, Disapprove",
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
            title: "Deactivate?",
                text: "Seller Account Will DiActivate ?",
                type: "info",
                showCancelButton: true,
                confirmButtonClass: "btn-danger",
                confirmButtonText: "Yes, Deactivate",
                closeOnConfirm: true
            },
                function () {
                obj.status = true;
                obj.ele = ev;
                obj.ele.click();
            });

            return false;
        }

        function openModal() { $('#btnSubmit').trigger('click'); }
        function openModalforDelete() { $('#btnDelete').trigger('click'); }

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid shadow">
        <div class="row" style="margin-top: 90px">
            <div class="col" style="overflow-x:scroll">
                <div>
                    <input type="text" class="search" />
                </div>
                <div>

                    <table class="table table-hover" id="userTbl">
                        <thead>
                            <tr>
                                <th>Seller id</th>
                                <th>Seller Name</th>
                                <th>Seller Mobile</th>
                                <th>Seller Email</th>
                                <th>Seller GST</th>
                                <th>UPI Number</th>
                                <th>Adhar Number</th>
                                <th>Pancard Number</th>
                                <th>Seller Adhar</th>
                                <th>Seller PanCard</th>
                                <th>Address</th>
                                <th>Status</th>
                                <th>Action</th>

                            </tr>

                        </thead>
                        <asp:Repeater ID="RptrSellerData" runat="server">
                            <ItemTemplate>
                                <tbody>
                                    <tr>
                                        <td>
                                            <asp:Label ID="LblSellerid" runat="server" Text='<%# Eval("Sellerid") %>'></asp:Label>
                                        </td>
                                        <td>
                                            <h6><%# Eval("SellerName") %></h6>
                                        </td>
                                        <td>
                                            <h6><%# Eval("Mobile") %></h6>
                                        </td>
                                        <td>
                                            <h6><%# Eval("Email") %></h6>
                                        </td>
                                        <td>
                                            <h6><%# Eval("gst") %></h6>
                                        </td>
                                        <td>
                                            <h6><%# Eval("upino") %></h6>
                                        </td>
                                        <td>
                                            <h6><%# Eval("Pancardno") %></h6>
                                        </td>
                                        <td>
                                            <h6><%# Eval("Adharno") %></h6>
                                        </td>
                                        <td>
                                            <asp:Image ID="ImgAdharCard" Height="70px" Width="90px" data-bs-toggle="modal" data-bs-target="#staticBackdrop" Style="cursor: pointer" onclick="popimage(this);" ImageUrl='<%# Eval("Adharcard") %>' runat="server" /></td>
                                        <td>
                                            <asp:Image ID="ImgPancard" Height="70px" Width="90px" data-bs-toggle="modal" data-bs-target="#staticBackdrop" onclick="popimage(this);" Style="cursor: pointer" ImageUrl='<%# Eval("Pancard") %>' runat="server" /></td>
                                        <td>
                                            <h6><%# Eval("FullAdress") %></h6>
                                        </td>
                                        <td>
                                            <asp:Label ID="LblStatus" runat="server" Text='<%# Eval("is_Approve").ToString()=="1"?"Apporved":"DisApproved" %>'></asp:Label>
                                        </td>
                                        <td>
                                            <asp:LinkButton ID="LinkButton2" OnClientClick="return AreYouSureApprove(this)" OnClick="LinkButton1_Click" CssClass="btn btn-success" ToolTip="Approve" runat="server"><i class="fa-solid fa-person-circle-check" style="color: #fcfbf7;"></i></asp:LinkButton>

                                            <asp:LinkButton ID="LinkButton1" OnClick="LnkDisaaprove_Click" OnClientClick="return AreYouSureDisApprove(this)"  ToolTip="DisApprove" CssClass="btn btn-danger" runat="server"><i class="fa-solid fa-thumbs-down" style="color: #ffffff;"></i></asp:LinkButton>

                                           <asp:LinkButton ID="LinkButton3" OnClick="LnkActivate_Click" OnClientClick="return AreYouSureDeActivate(this)" ToolTip="DiActivate" CssClass="btn btn-primary" runat="server"><i class="fa-solid fa-person-circle-xmark" style="color: #fcfcfc;"></i></asp:LinkButton>

                                            <asp:LinkButton ID="LnkDelete" OnClick="LnkDelete_Click1"  OnClientClick="return AreYouSureDelete(this);" ToolTip="Delete" CssClass="btn btn-danger" runat="server"><i class="fa-solid fa-trash" style="color: #fbfcfe;"></i></asp:LinkButton>

                                        </td>

                                    </tr>
                                </tbody>


                             
                                <!----modal Deactivated---->
                                <div class="modal fade" id="reasonDeactivated" data-bs-backdrop="static" data-bs-keyboard="false" tabindex="-1" aria-labelledby="staticBackdropLabel" aria-hidden="true">
                                    <div class="modal-dialog">
                                        <div class="modal-content">
                                            <div class="modal-header">
                                                <h5 class="modal-title" id="staticBackdropLabelss">Reason for DeAction</h5>
                                                <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                                            </div>
                                            <div class="modal-body">
                                                <asp:TextBox ID="TxtReasonDeactivated" CssClass="form-control fw-bold" TextMode="MultiLine" Rows="5" Style="resize: none" runat="server"></asp:TextBox>

                                            </div>
                                            <div class="modal-footer">
                                                

                                            </div>
                                        </div>
                                    </div>
                                </div>

                              
                            </ItemTemplate>
                        </asp:Repeater>

                    </table>
                       <!----modal DisApprove---->

                    <div class="modal fade" id="reasonApproved" data-bs-backdrop="static" data-bs-keyboard="false" tabindex="-1" aria-labelledby="staticBackdropLabel" aria-hidden="true">
                        <div class="modal-dialog">
                            <div class="modal-content">
                                <div class="modal-header">
                                    <h5 class="modal-title" id="staticBackdropLabels">Reason for Disapprove</h5>
                                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                                </div>
                                <div class="modal-body">
                                    <asp:HiddenField ID="HiddenIdForDisaaprove" runat="server" />
                                    <asp:TextBox ID="TxtreasonForDisApproved" CssClass="form-control fw-bold" TextMode="MultiLine" Rows="5" Style="resize: none" runat="server"></asp:TextBox>

                                </div>
                                <div class="modal-footer">
                                    <asp:LinkButton ID="LinkfinalDisaaprove" OnClick="LinkfinalDisaaprove_Click"  ToolTip="DisApprove" CssClass="btn btn-danger" runat="server"><i class="fa-solid fa-thumbs-down" style="color: #ffffff;"></i></asp:LinkButton>
                                </div>
                            </div>
                        </div>
                    </div>


                    <!----modal Deleted---->
                    <div class="modal fade" id="reasonDeleted" data-bs-backdrop="static" data-bs-keyboard="false" tabindex="-1" aria-labelledby="staticBackdropLabel" aria-hidden="true">
                        <div class="modal-dialog">
                            <div class="modal-content">
                                <div class="modal-header">
                                    <h5 class="modal-title" id="staticBackdropLabele">Reason for Delete</h5>
                                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                                </div>
                                <div class="modal-body">
                                    <asp:HiddenField ID="HdnDeleteid" runat="server" />
                                    <asp:TextBox ID="TxtreasonDeleted" CssClass="form-control fw-bold" TextMode="MultiLine" Rows="5" Style="resize: none" runat="server"></asp:TextBox>

                                </div>
                                <div class="modal-footer">
                                    <asp:LinkButton ID="LnkfinalDelete" OnClick="LnkfinalDelete_Click"  ToolTip="Delete" CssClass="btn btn-danger" runat="server"><i class="fa-solid fa-trash" style="color: #fbfcfe;"></i></asp:LinkButton>

                                </div>
                            </div>
                        </div>
                    </div>


                    <input id="btnSubmit" style="display:none" data-bs-toggle="modal" data-bs-target="#reasonApproved" type="button" value="button" />
                    <input id="btnDelete" style="display:none" data-bs-toggle="modal" data-bs-target="#reasonDeleted" type="button" value="button" />
                   
                </div>
               
            </div>
        </div>
    </div>



    <!-- Modal -->
    <div class="modal fade" id="staticBackdrop" data-bs-backdrop="static" data-bs-keyboard="false" tabindex="-1" aria-labelledby="staticBackdropLabel" aria-hidden="true">
        <div class="modal-dialog modal-dialog-centered modal-lg">

            <div class="modal-content" style="background-color: transparent; border: none;">
                <button type="button" id="buttonclose" class="btn-close ms-auto" style="border: none" data-bs-dismiss="modal" aria-label="Close"></button>


                <asp:Image ID="Image1" class="img-fluid" Height="400" Width="100%" ImageUrl="~/Images/Brand%20Logo/logo-no-background.png" runat="server" />
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
    <script type="text/javascript">
        function popimage(ev) {
            document.getElementById("<%=Image1.ClientID%>").src = ev.src;
        }


    </script>
</asp:Content>
