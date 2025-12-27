<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="AddCategorySubCategory.aspx.cs" Inherits="RazorpaySampleApp.WebForm9" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <!----Bootstrap--->
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-EVSTQN3/azprG1Anm3QDgpJLIm9Nao0Yz1ztcQTwFspd3yD65VohhpuuCOmLASjC" crossorigin="anonymous">

    
    <script src="https://code.jquery.com/jquery-3.7.1.min.js" integrity="sha256-/JqT3SQfawRcv/BIHPThkBvs0OEvtFFmqPF/lYI/Cxo=" crossorigin="anonymous"></script>
    <!--Sweet Alert--->
     <!-----sweet alert---->
   <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap-sweetalert@1.0.1/dist/sweetalert.min.css">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid" style="margin-top: 100px">
        <div class="row">
            <div class="col-6">
                <div class="row">
                    <div class="col d-flex mb-2">
                        <asp:TextBox ID="TxtMainCategory" Placeholder="Enter Category Name" Height="40px" CssClass="form-control" runat="server"></asp:TextBox>
                        <asp:LinkButton ID="LnkAddCategoory" OnClick="LnkAddCategoory_Click" Height="40px" CssClass="btn btn-dark" runat="server">Add</asp:LinkButton>
                    </div>
                </div>
                <div class="row">
                    <div class="col mb-2">
                        <asp:FileUpload ID="FileMainImage" onchange="Validate()" CssClass="form-control" runat="server" />
                    </div>
                    <p id="size"></p>
                </div>
                <div class="row">
                    <div class="col">
                        <input type="text" class="search" />
                        <table class="table table-hover table-bordered" id="userTbl">
                            <thead>
                                <tr>
                                    <th>id</th>
                                    <th>Name</th>
                                    <th>Image</th>
                                    <th>Action</th>
                                </tr>
                            </thead>
                            <asp:Repeater ID="RptrMainCat" runat="server">
                                <ItemTemplate>
                                    <tbody>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblMainCatid" runat="server" Text='<%#Eval("id") %>'></asp:Label>
                                            </td>
                                            <td>
                                                <h6><%#Eval("Catname") %></h6>
                                            </td>
                                            <td>
                                                <asp:Image ID="ImgCatImage"  data-bs-toggle="modal" data-bs-target="#staticBackdrop" Style="cursor: pointer" onclick="popimage(this);" Height="80px" Width="100px" ImageUrl='<%#Eval("CatImage") %>' runat="server" />
                                            </td>
                                            <td>
                                                <asp:LinkButton ID="LinDelete" OnClientClick="return AreYouSure(this)" OnClick="LinDelete_Click" CssClass="btn btn-dark" runat="server">REMOVE</asp:LinkButton>
                                            </td>
                                        </tr>
                                    </tbody>
                                </ItemTemplate>
                            </asp:Repeater>
                           

                        </table>
                    </div>
                </div>
            </div>
            <div class="col-6">
                <div class="row">
                    <div class="col my-2">
                        <asp:DropDownList ID="DropMainCat" CssClass="btn-dark form-control text-align-center" runat="server">
                           
                        </asp:DropDownList>
                        <asp:Label ID="LblDropAlert" Visible="false" runat="server" ForeColor="Red" Font-Bold="true" Text="Select MainCategory"></asp:Label>
                    </div>
                </div>
                <div class="row">
                    <div class="col d-flex my-2">
                        <asp:TextBox ID="TxtSubCat" Placeholder="Enter SubCategory Name" Height="40px" CssClass="form-control" runat="server"></asp:TextBox>
                        <asp:LinkButton ID="LnkAddSub" Height="40px" OnClick="LnkAddSub_Click" CssClass="btn btn-dark" runat="server">Add</asp:LinkButton>
                    </div>
                </div>
                <div class="row">
                    <div class="col">
                        <input type="text" class="search2" />
                        <table class="table table-hover table-bordered" id="userTbl2">
                            <thead>
                                <tr>
                                    <th>id</th>
                                    <th>Name</th>
                                    <th>MainCat</th>
                                    <th>Action</th>
                                </tr>
                            </thead>
                            <asp:Repeater ID="RptrSubcategory" runat="server">
                                <ItemTemplate>
                                    <tbody>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblSubCatid" runat="server" Text='<%#Eval("id") %>'></asp:Label>
                                            </td>
                                            <td>
                                                <h6><%#Eval("SubCatName") %></h6>
                                            </td>
                                            <td>
                                                <h6><%#Eval("Catname") %></h6>
                                            </td>                                           
                                            <td>
                                                <asp:LinkButton ID="LinDeletesub" OnClientClick="return AreYouSure(this)" OnClick="LinDeletesub_Click" CssClass="btn btn-dark" runat="server">REMOVE</asp:LinkButton>
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

        <!---Modal pop for the image zoom-->
        <!-- Modal -->
        <div class="modal fade" id="staticBackdrop" data-bs-backdrop="static" data-bs-keyboard="false" tabindex="-1" aria-labelledby="staticBackdropLabel" aria-hidden="true">
            <div class="modal-dialog modal-dialog-centered modal-lg">

                <div class="modal-content" style="background-color: transparent; border: none;">
                    <button type="button" id="buttonclose" class="btn-close ms-auto" style="border: none" data-bs-dismiss="modal" aria-label="Close"></button>


                    <asp:Image ID="Image1" class="img-fluid" Height="400" Width="100%" ImageUrl="~/Images/Brand%20Logo/logo-no-background.png" runat="server" />
                </div>
            </div>
        </div>
    </div>
    
        <!---sweet alert---->
    <script src="https://cdn.jsdelivr.net/npm/bootstrap-sweetalert@1.0.1/dist/sweetalert.min.js"></script>
    <!-----bootstrap js----->
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/js/bootstrap.bundle.min.js" integrity="sha384-MrcW6ZMFYlzcLA8Nl+NtUVF0sA7MsXsP1UyJoMp4YLEuNSfAP+JcXn/tWtIaxVXM" crossorigin="anonymous"></script>
    <script src="https://code.jquery.com/jquery-3.7.1.min.js" integrity="sha256-/JqT3SQfawRcv/BIHPThkBvs0OEvtFFmqPF/lYI/Cxo=" crossorigin="anonymous"></script>
    <!-----Jquery For Filtering rows in Table--->
    <script type="text/javascript">
        function Validate() {
            var file = document.getElementById('<%=FileMainImage.ClientID%>');
            var fileName = file.value;
            var ext = fileName.substring(fileName.lastIndexOf('.') + 1);
            var msg = document.getElementById("size");
            msg.innerHTML = "";
            var size = parseFloat(file.files[0].size);
            var maxSizeKB = 1024;//Size in KB.


            var maxSize = maxSizeKB * 1024; //File size is returned in Bytes.
            if (size > maxSize) {
                msg.style.color = "red";
                msg.style.fontWeight = "bold";
                msg.innerText = "Max file size 1MB allowed.";
                file.value = "";
                return false;
            }

            if (ext == "gif" || ext == "GIF" || ext == "JPEG" || ext == "jpeg" || ext == "jpg" || ext == "JPG" || ext == "PNG" || ext == "png") {

            }
            else {
                msg.style.color = "red";
                msg.style.fontWeight = "bold";
                msg.innerText = "only jpg,gif,jpeg,png are allowed";
                file.value = "";
                return false;
            }
        }


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


        $(document).ready(function () {
            $('.search2').on('keyup', function () {
                var searchTerm = $(this).val().toLowerCase();
                $('#userTbl2 tbody tr').each(function () {
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

    <script>
        function popimage(ev) {
            document.getElementById("<%=Image1.ClientID%>").src = ev.src;
        }
    </script>

</asp:Content>
