<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="AddProductPage.aspx.cs" Inherits="RazorpaySampleApp.WebForm10" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="https://cdnjs.cloudflare.com/ajax/libs/select2/4.0.13/css/select2.min.css" rel="stylesheet" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/select2/4.0.13/js/select2.min.js"></script>
    <script>
        $(document).ready(function () {
            $("#<%=Dropdowncolor.ClientID%>").select2();
        });
    </script>
    <script>
        $(document).ready(function () {
            $("#<%=DropdownMain.ClientID%>").select2();
         });
    </script>
    <script>
        $(document).ready(function () {
            $("#<%=DropDownSub.ClientID%>").select2();
         });
    </script>
    <script type="text/javascript">
        setInterval(function () {
            fetch('/AddProductPage.aspx', { cache: 'no-store' });            

        }, 1 * 60 * 1000); // every 1 minutes
    </script>
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container shadow" style="border-radius: 5px; margin-top: 100px">
        <div class="row rounded bg-white shadow p-5">
            <div class="form-floating mb-3 mt-4">

                <center>
                    <h1>Add Products</h1>
                </center>
            </div>
            <div>
                <a data-bs-toggle="modal" data-bs-target="#staticBackdrop" style="color: black; cursor: pointer; text-underline-position: under;text-decoration:underline;color:blue">Reference Product</a>
               

                <!-- Modal -->
                <div class="modal fade" id="staticBackdrop" data-bs-backdrop="static" data-bs-keyboard="false" tabindex="-1" aria-labelledby="staticBackdropLabel" aria-hidden="true">
                    <div class="modal-dialog modal-xl">
                        <div class="modal-content">
                            <div class="modal-header">
                                <h5 class="modal-title" id="staticBackdropLabel">Select Reference Of Products</h5>
                                <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                            </div>
                            <div class="modal-body">
                                <table class="table table-hover table-bordered" id="userTbl">
                                    <thead>
                                        <tr>
                                            <th>id</th>
                                            <th>Reference ID</th>
                                            <th>Name</th>
                                            <th>Image</th>                                            
                                            <th>Selection</th>                                            
                                        </tr>
                                    </thead>
                                    <asp:Repeater ID="RptrProducts" runat="server">
                                        <ItemTemplate>
                                            <tbody>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lblMainCatid" runat="server" Text='<%#Eval("product_id") %>'></asp:Label>
                                                    </td>
                                                    <td>
                                                       <asp:Label ID="LblProductReferenceid" runat="server" Text='<%#Eval("product_ref_id") %>'></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="LblProductName" runat="server" Text='<%#Eval("productname") %>'></asp:Label>
                                                    </td>
                                                    <td>
                                                        <center><asp:Image ID="ImgProductImage" data-bs-toggle="modal" data-bs-target="#imageZoom" Style="cursor: pointer" onclick="popimage(this);" Height="80px" Width="100px" ImageUrl='<%#Eval("image1") %>' runat="server" /></center>
                                                    </td>
                                                    <td>
                                                        <asp:LinkButton ID="LnkSelect" OnClick="LnkSelect_Click"   CssClass="btn btn-dark" runat="server">Select</asp:LinkButton>
                                                    </td>
                                                </tr>
                                            </tbody>
                                        </ItemTemplate>
                                    </asp:Repeater>


                                </table>

                                <!---Modal pop for the image zoom-->
                                <!-- Modal -->
                                <div class="modal fade mod" id="imageZoom" data-bs-backdrop="static" data-bs-keyboard="false" tabindex="-1" aria-labelledby="staticBackdropLabel" aria-hidden="true">
                                    <div class="modal-dialog modal-dialog-centered modal-lg">

                                        <div class="modal-content" style="background-color: transparent; border: none;">
                                            <button type="button" id="buttonclose" class="btn-close ms-auto" style="border: none" data-bs-dismiss="modal" aria-label="Close"></button>


                                            <asp:Image ID="Image1" class="img-fluid" Height="400" Width="100%" ImageUrl="~/Images/Brand%20Logo/logo-no-background.png" runat="server" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="modal-footer">
                               
                        </div>
                    </div>
                </div>
            </div>
            <div>
                <asp:TextBox ID="TxtreferenceProductId" Enabled="false" class="form-control" placeholder="Enter Product Reference" runat="server"></asp:TextBox>            
            </div>                
                <asp:UpdatePanel ID="UpdatePanelforCategory" runat="server">
                    <ContentTemplate>
                        <div class="form-floating mb-3 mt-4 row">
                            <div class="col-12 col-sm-6 col-md-6 col-xl-6">
                                <h6>Main Category</h6>
                                <asp:DropDownList ID="DropdownMain" AutoPostBack="true" OnSelectedIndexChanged="DropdownMain_SelectedIndexChanged" Width="100%" class="form-control shadow" runat="server"></asp:DropDownList>
                            </div>
                            <div class="col-12 col-sm-6 col-md-6 col-xl-6">
                                <h6>Sub Category</h6>
                                <asp:DropDownList ID="DropDownSub" Width="100%" class="form-control shadow" runat="server"></asp:DropDownList>
                            </div>
                        </div>
                    </ContentTemplate>                    
                </asp:UpdatePanel>   
                <asp:UpdateProgress ID="UpdateProgress" runat="server" AssociatedUpdatePanelID="UpdatePanelforCategory">
                    <ProgressTemplate>
                        <div class="loading" style="text-align:center">
                          <img src="Images/Preloader/Loader.gif" style="height:250px;width:400px" alt="Loading..."/>            
                            <span>Processing...</span>
                        </div>
                    </ProgressTemplate>
                </asp:UpdateProgress>                 
            <div class="form-floating mb-3 mt-4">
                <asp:TextBox ID="TxtProductName" class="form-control shadow" placeholder="Mobile Number" Style="border-color: #f1ecec; box-shadow: 0px 0px 0px hotpink" runat="server"></asp:TextBox>
                <label for="TxtMobileNo">Product Name</label>
            </div>
            <div class="form-floating mb-3 mt-4">
                <asp:TextBox ID="TxtProductBrand" class="form-control shadow" placeholder="Mobile Number" Style="border-color: #f1ecec; box-shadow: 0px 0px 0px hotpink" runat="server"></asp:TextBox>
                <label for="TxtMobileNo">Product Brand</label>
            </div>
            <div class="mb-3 mt-4">
                <asp:TextBox ID="TxtProductDetails" class="form-control shadow" TextMode="MultiLine" Rows="7" Width="100%" placeholder="Product Details" Style="border-color: #f1ecec; box-shadow: 0px 0px 0px hotpink; outline-color: #f1eded; resize: none" runat="server"></asp:TextBox>

            </div>
            <div class="mb-3 mt-4">
                <asp:TextBox ID="TxtProductDescription" class="form-control shadow" TextMode="MultiLine" Rows="7" Width="100%" placeholder="Product Description" Style="border-color: #f1ecec; box-shadow: 0px 0px 0px hotpink; outline-color: #f1eded; resize: none" runat="server"></asp:TextBox>

            </div>
            <div class="form-floating mb-3 mt-4">
                <asp:TextBox ID="TxtProductkeyword" class="form-control shadow" TextMode="MultiLine" Rows="10" placeholder="Mobile Number" Style="border-color: #f1ecec; box-shadow: 0px 0px 0px hotpink; outline-color: gray; resize: none" runat="server"></asp:TextBox>
                <label for="TxtMobileNo">Product Keyword</label>
            </div>
            <div class="form-floating mb-3 mt-4">
                <asp:TextBox ID="TxtProductSpecification" class="form-control shadow" TextMode="MultiLine" Rows="10" placeholder="Mobile Number" Style="border-color: #f1ecec; box-shadow: 0px 0px 0px hotpink" runat="server"></asp:TextBox>
                <label for="TxtMobileNo">Product Specification</label>
            </div>
            <div class="mb-3 mt-4 d-flex">
                <asp:RadioButton ID="RdoClothing" runat="server" onclick="VisibleclothSelection();" GroupName="Type" Text="Clothing" />
                <asp:RadioButton ID="RdoFootwear" onclick="VisiblecfootSelection();" Style="margin-left: 90px" runat="server" GroupName="Type" Text="Footwear" />
                <asp:RadioButton ID="RdoOthers" onclick="OtherSelection();" runat="server" Style="margin-left: 90px" GroupName="Type" Text="Others" />
            </div>

                <div id="chooseclothsize" style="display:none" class="form-floating mb-3 mt-4">
                    <div class="col-12" style="display:none">
                        <h6>Choose Size</h6>
                        <asp:DropDownList ID="DropdwnClothsize"  class="form-control shadow" runat="server">
                            <asp:ListItem Value="0" Text="Choose Size">Choose Size</asp:ListItem>
                            <asp:ListItem Value="1" Text="Small">Small</asp:ListItem>
                            <asp:ListItem Value="2" Text="Medium">Medium</asp:ListItem>
                            <asp:ListItem Value="3" Text="Large">Large</asp:ListItem>
                            <asp:ListItem Value="4" Text="X-Large">X-Large</asp:ListItem>
                            <asp:ListItem Value="5" Text="XX-Large">XX-Large</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                     <!--small-->
                    <div class="row">
                        <div class="col-6">
                            <div class="form-floating mb-3 mt-4 text-center">

                                <label style="font-size:larger;font:bolder">Small :</label>
                            </div>
                            
                        </div>
                        <div class="col-6">
                            <div class="form-floating mb-3 mt-4">
                                <asp:TextBox ID="TxtsmallsizeQuantity" onchange="Add_available();" class="form-control shadow"  MaxLength="5"  placeholder="Enter Quanity" Style="border-color: #f1ecec; box-shadow: 0px 0px 0px hotpink; outline-color: gray; resize: none" runat="server"></asp:TextBox>
                                <label for="TxtMobileNo">Enter Quantity</label>
                            </div>
                        </div>
                    </div>
                    <!--medium-->
                    <div class="row">
                        <div class="col-6">
                            <div class="form-floating mb-3 mt-4 text-center">

                                <label style="font-size: larger; font: bolder">Medium :</label>
                            </div>

                        </div>
                        <div class="col-6">
                            <div class="form-floating mb-3 mt-4">
                                <asp:TextBox ID="TxtmediumsizeQuantity" onchange="Add_available();" class="form-control shadow"  MaxLength="5" placeholder="Enter Quanity" Style="border-color: #f1ecec; box-shadow: 0px 0px 0px hotpink; outline-color: gray; resize: none" runat="server"></asp:TextBox>
                                <label for="TxtMobileNo">Enter Quantity</label>
                            </div>
                        </div>
                    </div>
                       <!--Large-->
                    <div class="row">
                        <div class="col-6">
                            <div class="form-floating mb-3 mt-4 text-center">

                                <label style="font-size: larger; font: bolder">Large :</label>
                            </div>

                        </div>
                        <div class="col-6">
                            <div class="form-floating mb-3 mt-4">
                                <asp:TextBox ID="TxtlargesizeQuantity" onchange="Add_available();" class="form-control shadow"  MaxLength="5" placeholder="Enter Quanity" Style="border-color: #f1ecec; box-shadow: 0px 0px 0px hotpink; outline-color: gray; resize: none" runat="server"></asp:TextBox>
                                <label for="TxtsmallsizeQuantity">Enter Quantity</label>
                            </div>
                        </div>
                    </div>

                       <!--X-Large-->
                    <div class="row">
                        <div class="col-6">
                            <div class="form-floating mb-3 mt-4 text-center">

                                <label style="font-size: larger; font: bolder">X-Large :</label>
                            </div>

                        </div>
                        <div class="col-6">
                            <div class="form-floating mb-3 mt-4">
                                <asp:TextBox ID="TxtxlsizeQuantity" onchange="Add_available();" class="form-control shadow" MaxLength="5" placeholder="Enter Quanity" Style="border-color: #f1ecec; box-shadow: 0px 0px 0px hotpink; outline-color: gray; resize: none" runat="server"></asp:TextBox>
                                <label for="TxtxlsizeQuantity">Enter Quantity</label>
                            </div>
                        </div>
                    </div>

                    <!--XX-Large-->
                    <div class="row">
                        <div class="col-6">
                            <div class="form-floating mb-3 mt-4 text-center">

                                <label style="font-size: larger; font: bolder">XX-Large :</label>
                            </div>

                        </div>
                        <div class="col-6">
                            <div class="form-floating mb-3 mt-4">
                                <asp:TextBox ID="TxtxxlsizeQuantity" onchange="Add_available();" class="form-control shadow" MaxLength="5" placeholder="Enter Quanity" Style="border-color: #f1ecec; box-shadow: 0px 0px 0px hotpink; outline-color: gray; resize: none" runat="server"></asp:TextBox>
                                <label for="TxtxxlsizeQuantity">Enter Quantity</label>
                            </div>
                        </div>
                    </div>

                </div>
               
                <div id="choosefootsize" style="display:none" class="form-floating mb-3 mt-4">
                    <div class="col-12" style="display:none">
                        <h6>Choose Size</h6>
                        <asp:DropDownList ID="Dropdownfoot" class="form-control shadow" runat="server">
                            <asp:ListItem Value="0" Text="Choose Size">Choose Size</asp:ListItem>
                            <asp:ListItem Value="1" Text="4">4</asp:ListItem>
                            <asp:ListItem Value="2" Text="5">5</asp:ListItem>
                            <asp:ListItem Value="3" Text="6">6</asp:ListItem>
                            <asp:ListItem Value="3" Text="7">7</asp:ListItem>
                            <asp:ListItem Value="3" Text="8">8</asp:ListItem>
                            <asp:ListItem Value="3" Text="9">9</asp:ListItem>
                            <asp:ListItem Value="3" Text="10">10</asp:ListItem>
                            <asp:ListItem Value="3" Text="11">11</asp:ListItem>
                            <asp:ListItem Value="3" Text="12">12</asp:ListItem>
                        </asp:DropDownList>
                    </div>

                    <!--4-->
                    <div class="row">
                        <div class="col-6">
                            <div class="form-floating mb-3 mt-4 text-center">

                                <label style="font-size: larger; font: bolder">Size(4) :</label>
                            </div>

                        </div>
                        <div class="col-6">
                            <div class="form-floating mb-3 mt-4">
                                <asp:TextBox ID="Txtsize4" class="form-control shadow" onchange="Add_available();" MaxLength="5" placeholder="Enter Quanity" Style="border-color: #f1ecec; box-shadow: 0px 0px 0px hotpink; outline-color: gray; resize: none" runat="server"></asp:TextBox>
                                <label for="TxtMobileNo">Enter Quantity</label>
                            </div>
                        </div>
                    </div>
                     <!--5-->
                    <div class="row">
                        <div class="col-6">
                            <div class="form-floating mb-3 mt-4 text-center">

                                <label style="font-size: larger; font: bolder">Size(5) :</label>
                            </div>

                        </div>
                        <div class="col-6">
                            <div class="form-floating mb-3 mt-4">
                                <asp:TextBox ID="Txtsize5" class="form-control shadow" onchange="Add_available();"  MaxLength="5" placeholder="Enter Quanity" Style="border-color: #f1ecec; box-shadow: 0px 0px 0px hotpink; outline-color: gray; resize: none" runat="server"></asp:TextBox>
                                <label for="TxtMobileNo">Enter Quantity</label>
                            </div>
                        </div>
                    </div>
                    <!--6-->
                    <div class="row">
                        <div class="col-6">
                            <div class="form-floating mb-3 mt-4 text-center">

                                <label style="font-size: larger; font: bolder">Size(6) :</label>
                            </div>

                        </div>
                        <div class="col-6">
                            <div class="form-floating mb-3 mt-4">
                                <asp:TextBox ID="Txtsize6" class="form-control shadow" onchange="Add_available();" MaxLength="5" placeholder="Enter Quanity" Style="border-color: #f1ecec; box-shadow: 0px 0px 0px hotpink; outline-color: gray; resize: none" runat="server"></asp:TextBox>
                                <label for="TxtMobileNo">Enter Quantity</label>
                            </div>
                        </div>
                    </div>
                    <!--7-->
                    <div class="row">
                        <div class="col-6">
                            <div class="form-floating mb-3 mt-4 text-center">

                                <label style="font-size: larger; font: bolder">Size(7) :</label>
                            </div>

                        </div>
                        <div class="col-6">
                            <div class="form-floating mb-3 mt-4">
                                <asp:TextBox ID="Txtsize7" class="form-control shadow" onchange="Add_available();" MaxLength="5" placeholder="Enter Quanity" Style="border-color: #f1ecec; box-shadow: 0px 0px 0px hotpink; outline-color: gray; resize: none" runat="server"></asp:TextBox>
                                <label for="TxtMobileNo">Enter Quantity</label>
                            </div>
                        </div>
                    </div>
                    <!--8-->
                    <div class="row">
                        <div class="col-6">
                            <div class="form-floating mb-3 mt-4 text-center">

                                <label style="font-size: larger; font: bolder">Size(8) :</label>
                            </div>

                        </div>
                        <div class="col-6">
                            <div class="form-floating mb-3 mt-4">
                                <asp:TextBox ID="Txtsize8" class="form-control shadow" onchange="Add_available();"  MaxLength="5" placeholder="Enter Quanity" Style="border-color: #f1ecec; box-shadow: 0px 0px 0px hotpink; outline-color: gray; resize: none" runat="server"></asp:TextBox>
                                <label for="TxtMobileNo">Enter Quantity</label>
                            </div>
                        </div>
                    </div>
                    <!--9-->
                    <div class="row">
                        <div class="col-6">
                            <div class="form-floating mb-3 mt-4 text-center">

                                <label style="font-size: larger; font: bolder">Size(9) :</label>
                            </div>

                        </div>
                        <div class="col-6">
                            <div class="form-floating mb-3 mt-4">
                                <asp:TextBox ID="Txtsize9" class="form-control shadow" onchange="Add_available();" MaxLength="5" placeholder="Enter Quanity" Style="border-color: #f1ecec; box-shadow: 0px 0px 0px hotpink; outline-color: gray; resize: none" runat="server"></asp:TextBox>
                                <label for="TxtMobileNo">Enter Quantity</label>
                            </div>
                        </div>
                    </div>
                    <!--10-->
                    <div class="row">
                        <div class="col-6">
                            <div class="form-floating mb-3 mt-4 text-center">

                                <label style="font-size: larger; font: bolder">Size(10) :</label>
                            </div>

                        </div>
                        <div class="col-6">
                            <div class="form-floating mb-3 mt-4">
                                <asp:TextBox ID="Txtsize10" class="form-control shadow" onchange="Add_available();" MaxLength="5" placeholder="Enter Quanity" Style="border-color: #f1ecec; box-shadow: 0px 0px 0px hotpink; outline-color: gray; resize: none" runat="server"></asp:TextBox>
                                <label for="Txtsize10">Enter Quantity</label>
                            </div>
                        </div>
                    </div>
                    <!--11-->
                    <div class="row">
                        <div class="col-6">
                            <div class="form-floating mb-3 mt-4 text-center">

                                <label style="font-size: larger; font: bolder">Size(11) :</label>
                            </div>

                        </div>
                        <div class="col-6">
                            <div class="form-floating mb-3 mt-4">
                                <asp:TextBox ID="Txtsize11" class="form-control shadow" onchange="Add_available();" MaxLength="5" placeholder="Enter Quanity" Style="border-color: #f1ecec; box-shadow: 0px 0px 0px hotpink; outline-color: gray; resize: none" runat="server"></asp:TextBox>
                                <label for="Txtsize11">Enter Quantity</label>
                            </div>
                        </div>
                    </div>
                    <!--12-->
                    <div class="row">
                        <div class="col-6">
                            <div class="form-floating mb-3 mt-4 text-center">

                                <label style="font-size: larger; font: bolder">Size(12) :</label>
                            </div>

                        </div>
                        <div class="col-6">
                            <div class="form-floating mb-3 mt-4">
                                <asp:TextBox ID="Txtsize12" class="form-control shadow" onchange="Add_available();" MaxLength="5" placeholder="Enter Quanity" Style="border-color: #f1ecec; box-shadow: 0px 0px 0px hotpink; outline-color: gray; resize: none" runat="server"></asp:TextBox>
                                <label for="TxtMobileNo">Enter Quantity</label>
                            </div>
                        </div>
                    </div>
                </div>

            <div class="form-floating mb-3 mt-4 ">
                <div class="col-12">
                    <h6>Choose Color</h6>
                    <asp:DropDownList ID="Dropdowncolor" class="form-control shadow" runat="server">
                        <asp:ListItem Value="0" Text="Choose Colour">Choose Colour</asp:ListItem>
                        <asp:ListItem Value="1" Text="White">White</asp:ListItem>
                        <asp:ListItem Value="2" Text="Black">Black</asp:ListItem>
                        <asp:ListItem Value="3" Text="Red">Red</asp:ListItem>
                        <asp:ListItem Value="4" Text="Blue">Blue</asp:ListItem>
                        <asp:ListItem Value="5" Text="Green">Green</asp:ListItem>
                        <asp:ListItem Value="6" Text="Yellow">Yellow</asp:ListItem>
                        <asp:ListItem Value="7" Text="Orange">Orange</asp:ListItem>
                        <asp:ListItem Value="8" Text="Pink">Pink</asp:ListItem>
                        <asp:ListItem Value="9" Text="Purple">Purple</asp:ListItem>
                        <asp:ListItem Value="10" Text="Gray">Gray</asp:ListItem>
                        <asp:ListItem Value="11" Text="Brown">Brown</asp:ListItem>
                        <asp:ListItem Value="12" Text="Cyan">Cyan</asp:ListItem>
                        <asp:ListItem Value="13" Text="Magenta">Magenta</asp:ListItem>
                        <asp:ListItem Value="14" Text="Turquoise">Turquoise</asp:ListItem>
                        <asp:ListItem Value="15" Text="Teal">Teal</asp:ListItem>
                        <asp:ListItem Value="16" Text="Indigo">Indigo</asp:ListItem>
                        <asp:ListItem Value="17" Text="Lavender">Lavender</asp:ListItem>
                        <asp:ListItem Value="18" Text="Beige">Beige</asp:ListItem>
                        <asp:ListItem Value="19" Text="Maroon">Maroon</asp:ListItem>
                        <asp:ListItem Value="20" Text="Gold">Gold</asp:ListItem>
                        <asp:ListItem Value="21" Text="Silver">Silver</asp:ListItem>
                        <asp:ListItem Value="22" Text="Navy">Navy</asp:ListItem>
                        <asp:ListItem Value="23" Text="Olive">Olive</asp:ListItem>
                        <asp:ListItem Value="24" Text="Peach">Peach</asp:ListItem>
                        <asp:ListItem Value="25" Text="Tan">Tan</asp:ListItem>
                        <asp:ListItem Value="26" Text="Coral">Coral</asp:ListItem>
                        <asp:ListItem Value="27" Text="Sky Blue">Sky Blue</asp:ListItem>
                        <asp:ListItem Value="28" Text="Mint Green">Mint Green</asp:ListItem>
                        <asp:ListItem Value="29" Text="Violet">Violet</asp:ListItem>
                        <asp:ListItem Value="30" Text="Slate">Slate</asp:ListItem>
                        <asp:ListItem Value="31" Text="Ruby">Ruby</asp:ListItem>
                        <asp:ListItem Value="32" Text="Emerald">Emerald</asp:ListItem>
                        <asp:ListItem Value="33" Text="Lemon">Lemon</asp:ListItem>
                        <asp:ListItem Value="34" Text="Light Pink">Light Pink</asp:ListItem>
                        <asp:ListItem Value="35" Text="Amber">Amber</asp:ListItem>
                        <asp:ListItem Value="36" Text="Apricot">Apricot</asp:ListItem>
                        <asp:ListItem Value="37" Text="Aquamarine">Aquamarine</asp:ListItem>
                        <asp:ListItem Value="38" Text="Brick">Brick</asp:ListItem>
                        <asp:ListItem Value="39" Text="Charcoal">Charcoal</asp:ListItem>
                        <asp:ListItem Value="40" Text="Chocolate">Chocolate</asp:ListItem>
                        <asp:ListItem Value="41" Text="Cobalt">Cobalt</asp:ListItem>
                        <asp:ListItem Value="42" Text="Crimson">Crimson</asp:ListItem>
                        <asp:ListItem Value="43" Text="Forest Green">Forest Green</asp:ListItem>
                        <asp:ListItem Value="44" Text="Fuchsia">Fuchsia</asp:ListItem>
                        <asp:ListItem Value="45" Text="Granite">Granite</asp:ListItem>
                        <asp:ListItem Value="46" Text="Ivory">Ivory</asp:ListItem>
                        <asp:ListItem Value="47" Text="Jade">Jade</asp:ListItem>
                        <asp:ListItem Value="48" Text="Mauve">Mauve</asp:ListItem>
                        <asp:ListItem Value="49" Text="Mustard">Mustard</asp:ListItem>
                        <asp:ListItem Value="50" Text="Salmon">Salmon</asp:ListItem>
                    </asp:DropDownList>
                </div>

            </div>
             <label class="text-danger">Marked price== Cost Price+Your Profit+ GST + 2.5% Payment Processing charge + 10 Rs Platform charge + Delivery Charge(200-250Rs)</label>
            <div class="form-floating mb-3 mt-4">
              
                <asp:TextBox ID="Txtmarkedprice" class="form-control shadow"  MaxLength="3" placeholder="Mobile Number" Style="border-color: #f1ecec; box-shadow: 0px 0px 0px hotpink" runat="server"></asp:TextBox>
                <label for="TxtMobileNo">Marked Price</label>
            </div>
            <div class="form-floating mb-3 mt-4">
                <asp:TextBox ID="TxtProductDiscount" onkeyup="CheckDiscount();" class="form-control shadow"  placeholder="Mobile Number" Style="border-color: #f1ecec; box-shadow: 0px 0px 0px hotpink" runat="server"></asp:TextBox>
                <label for="TxtMobileNo">Product Discount</label>
            </div>
            <div class=" mb-3 mt-4 d-flex ms-auto">
                <asp:CheckBox ID="ChkCashonDelivery" Text="COD Applicable" runat="server" />
                <!----0.No offer 1.Limited Time Deal 2.festive Offer--->
                <asp:RadioButton ID="RdoFestival" onclick="VerifyDiscountAmount();" Style="margin-left: 40px" Text="Festival Offer" GroupName="offer" runat="server" />
                <asp:RadioButton ID="RdoLimitedtimeOffer" onclick="VerifyDiscountAmount();" Style="margin-left: 40px" Text="Limited Time Deal" GroupName="offer" runat="server" />
                
            </div>
            <div class="mb-3 mt-4 d-flex">
                <asp:RadioButton ID="RdoReturn" onclick="ShowReturnPanel();" runat="server" GroupName="ChangePolicy" Text="Return Applicable" />
                <asp:RadioButton ID="RdoReplcement" onclick="ShowReplacementPanel();" Style="margin-left: 90px" runat="server" GroupName="ChangePolicy" Text="Replacement Applicable" />
                <asp:RadioButton ID="RdoNoReplaceReturn" onclick="NoReplacement();" Style="margin-left: 90px" runat="server" GroupName="ChangePolicy" Text="Nothing Applicable" />
            </div>
            <asp:Panel ID="PanelReturn" Style="display: none" runat="server">
                <div class="form-floating mb-3 mt-4">
                    <asp:TextBox ID="Txtreturnday" class="form-control shadow"  placeholder="Mobile Number" Style="border-color: #f1ecec; box-shadow: 0px 0px 0px hotpink;" runat="server"></asp:TextBox>
                    <label for="TxtReturnDay">Return Day</label>
                </div>
            </asp:Panel>
            <asp:Panel ID="PanelReplacement" Style="display: none" runat="server">
                <div class="form-floating mb-3 mt-4">
                    <asp:TextBox ID="TxtReplacementday" class="form-control shadow"  placeholder="Mobile Number" Style="border-color: #f1ecec; box-shadow: 0px 0px 0px hotpink;" runat="server"></asp:TextBox>
                    <label for="TxtReplacementDay">Replacement Day</label>
                </div>
            </asp:Panel>
                <div class="form-floating mb-3 mt-4">
                   
                    <asp:TextBox ID="Txtwarant" class="form-control shadow"  placeholder="Mobile Number" Style="border-color: #f1ecec; box-shadow: 0px 0px 0px hotpink" runat="server"></asp:TextBox>
                    <label for="TxtMobileNo">Warranty in months</label>
                </div>
            <div class="form-floating mb-3 mt-4">
                <asp:TextBox ID="Txtdeliveryprice" class="form-control shadow" placeholder="Mobile Number" Style="border-color: #f1ecec; box-shadow: 0px 0px 0px hotpink" runat="server"></asp:TextBox>
                <label for="TxtMobileNo">Delivery Price</label>
            </div>
                <div class="form-floating mb-3 mt-4">
                    <asp:TextBox ID="Txtavlquantity" class="form-control shadow"  placeholder="Mobile Number" Style="border-color: #f1ecec; box-shadow: 0px 0px 0px hotpink" runat="server"></asp:TextBox>
                    <label for="TxtMobileNo">Available quantity</label>
                </div>
            <div>
                <center>
                    <img id="imagePreview" class="img-thumbnail" width="150" height="175" src="http://placehold.it/100x100" />
                    <div>
                        <label id="size" style="color: red"></label>
                    </div>
                </center>
            </div>
            <div class="mb-3 mt-4">
                <asp:FileUpload ID="ProfileFileUpload" onchange="Showpicture1(this);" CssClass="form-control custom-file-input" runat="server" />
                <label id="erroimgmsg1"></label>
            </div>
            <div>
                <center>
                    <img id="imagePreview2" class="img-thumbnail" width="150" height="175" src="http://placehold.it/100x100" />
                    <div>
                        <label id="size2" style="color: red"></label>
                    </div>
                </center>
            </div>
            <div class="mb-3 mt-4">
                <asp:FileUpload ID="ProfileFileUpload2" onchange="Showpicture2(this);" CssClass="form-control custom-file-input" runat="server" />
                 <label id="erroimgmsg2"></label>
            </div>
            <div>
                <center>
                    <img id="imagePreview3" class="img-thumbnail" width="150" height="175" src="http://placehold.it/100x100" />
                    <div>
                        <label id="size3" style="color: red"></label>
                    </div>
                </center>
            </div>
            <div class="mb-3 mt-4">
                <asp:FileUpload ID="ProfileFileUpload3" onchange="Showpicture3(this);" CssClass="form-control custom-file-input" runat="server" />
                 <label id="erroimgmsg3"></label>
            </div>
            <div>
                <center>
                    <img id="imagePreview4" class="img-thumbnail" width="150" height="175" src="http://placehold.it/100x100" />
                    <div>
                        <label id="size4" style="color: red"></label>
                    </div>
                </center>
            </div>
            <div class="mb-3 mt-4">
                <asp:FileUpload ID="ProfileFileUpload4" onchange="Showpicture4(this);" CssClass="form-control custom-file-input" runat="server" />
                 <label id="erroimgmsg4"></label>
            </div>
            <div>
                <center>
                    <img id="imagePreview5" class="img-thumbnail" width="150" height="175" src="http://placehold.it/100x100" />
                    <div>
                        <label id="size5" style="color: red"></label>
                    </div>

                </center>
            </div>
                <label style="color:red">If Your Product Is Related To Sizing It's Advisable To Add Size image To Reduce Returns</label>
            <div class="mb-3 mt-4">
                <asp:FileUpload ID="ProfileFileUpload5" onchange="Showpicture5(this);" CssClass="form-control custom-file-input" runat="server" />
                 <label id="erroimgmsg5"></label>
            </div>
            <div class="my-2">
                <asp:LinkButton ID="LnklistProduct" OnClick="LnklistProduct_Click" Width="100%" CssClass="btn btn-dark" runat="server">Upload The Product</asp:LinkButton>
            </div>


        </div>
    </div>
    <!-----bootstrap js----->
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/js/bootstrap.bundle.min.js" integrity="sha384-MrcW6ZMFYlzcLA8Nl+NtUVF0sA7MsXsP1UyJoMp4YLEuNSfAP+JcXn/tWtIaxVXM" crossorigin="anonymous"></script>
    <!---sweet alert---->
    <script src="https://cdn.jsdelivr.net/npm/bootstrap-sweetalert@1.0.1/dist/sweetalert.min.js"></script>
    <script>
        function VerifyDiscountAmount() {
            var a = document.getElementById('<%=TxtProductDiscount.ClientID%>');
            var b = document.getElementById('<%=RdoFestival.ClientID%>');
            var c = document.getElementById('<%=RdoLimitedtimeOffer.ClientID%>');
            if (a.value =="" || a.value == 0) {
               
                b.checked = false;
                c.checked = false;
                swal("Enter Discount", "Give Some Discount Amount", "error")
            }
           
        }

        function CheckDiscount() {
            var a = document.getElementById('<%=TxtProductDiscount.ClientID%>');
            if (a.value > 100 || a.value < 0) {
                swal("Correct Value", "Enter Correct Value!", "error")               
                a.value = "";
            }
        }

        function ShowReplacementPanel() {
            var a = document.getElementById('<%=PanelReplacement.ClientID%>').style.display = "";
            var b = document.getElementById('<%=PanelReturn.ClientID%>').style.display = "none";

        }

        function ShowReturnPanel() {
            document.getElementById('<%=PanelReplacement.ClientID%>').style.display = "none";
            document.getElementById('<%=PanelReturn.ClientID%>').style.display = "";

        }

        function NoReplacement() {
            document.getElementById('<%=PanelReplacement.ClientID%>').style.display = "none";
            document.getElementById('<%=PanelReturn.ClientID%>').style.display = "none";

        }




    </script>
  

        <script>
            function popimage(ev) {
                document.getElementById("<%=Image1.ClientID%>").src = ev.src;
            }

            function VisibleclothSelection() {
                document.getElementById('chooseclothsize').style.display = 'block';
                document.getElementById('choosefootsize').style.display = 'none';
            }

            function VisiblecfootSelection() {
                document.getElementById('chooseclothsize').style.display = 'none';
                document.getElementById('choosefootsize').style.display = 'block';
            }

            function OtherSelection() {
                document.getElementById('chooseclothsize').style.display = 'none';
                document.getElementById('choosefootsize').style.display = 'none';
            }                reader.readAsDataURL(input.files[0]);
                    


           

            function Showpicture1(ev) {

                var fileName = ev.value;
                var c = fileName.split("\\");
                var ext = fileName.substring(fileName.lastIndexOf('.') + 1);
                var size = parseFloat(ev.files[0].size);
                var maxSizeKB = 512;//Size in KB.

                

                if (c[2].includes('_') == true || c[2].includes('-') == true || c[2].includes('+') == true) {
                    document.getElementById('erroimgmsg1').innerText = 'special character like *,&,%,$,#,@,!,-,_,+,= are not allowed in image name'
                    document.getElementById('erroimgmsg1').style.color = 'red'
                    document.getElementById('erroimgmsg1').style.font = 'bold'
                    ev.value = "";
                }
                else if (size > (maxSizeKB * 512))
                {
                    document.getElementById('erroimgmsg1').innerText = 'Max file size is 500 kb';
                    document.getElementById('erroimgmsg1').style.color = 'red'
                    document.getElementById('erroimgmsg1').style.font = 'bold'
                    ev.value = "";
                }
               
                else {
                    document.getElementById('erroimgmsg1').innerText = '';
                    var reader = new FileReader();
                    reader.onload = function () {
                        var output = document.getElementById('imagePreview');
                        output.src = reader.result;
                    };
                    reader.readAsDataURL(ev.files[0]);
                 
                }



                if (ext == "gif" || ext == "jpeg" || ext == 'jpg' || ext == "png") {
                   
                }
                else {
                    document.getElementById('erroimgmsg1').innerText = 'Only gif,jpeg,jpg,png formats are allowed';
                    document.getElementById('erroimgmsg1').style.color = 'red'
                    document.getElementById('erroimgmsg1').style.font = 'bold'
                    ev.value = "";
                }
            }

            function Showpicture2(ev) {

                var fileName = ev.value;
                var c = fileName.split("\\");
                var ext = fileName.substring(fileName.lastIndexOf('.') + 1);
                var size = parseFloat(ev.files[0].size);
                var maxSizeKB = 512;//Size in KB.


                if (c[2].includes('_') == true) {
                    document.getElementById('erroimgmsg2').innerText = 'not allowed'
                    document.getElementById('erroimgmsg2').style.color = 'red'
                    fileName = "";
                }
                else if (size > (maxSizeKB * 512)) {
                    document.getElementById('erroimgmsg2').innerText = 'Max file size is 500 kb';
                    document.getElementById('erroimgmsg2').style.color = 'red'
                    document.getElementById('erroimgmsg2').style.font = 'bold'
                    ev.value = "";
                }
                else {
                    document.getElementById('erroimgmsg2').innerText = '';
                    var reader = new FileReader();
                    reader.onload = function () {
                        var output = document.getElementById('imagePreview2');
                        output.src = reader.result;
                    };
                    reader.readAsDataURL(ev.files[0]);
                }


                if (ext == "gif" || ext == "jpeg" || ext == 'jpg' || ext == "png") {

                }
                else {
                    document.getElementById('erroimgmsg2').innerText = 'Only gif,jpeg,jpg,png formats are allowed';
                    document.getElementById('erroimgmsg2').style.color = 'red'
                    document.getElementById('erroimgmsg2').style.font = 'bold'
                    ev.value = "";
                }
            }

            function Showpicture3(ev) {

                var fileName = ev.value;
                var c = fileName.split("\\");
                var ext = fileName.substring(fileName.lastIndexOf('.') + 1);
                var size = parseFloat(ev.files[0].size);
                var maxSizeKB = 512;//Size in KB.


                if (c[2].includes('_') == true) {
                    document.getElementById('erroimgmsg3').innerText = 'not allowed'
                    document.getElementById('erroimgmsg3').style.color = 'red'
                    fileName = "";
                }
                else if (size > (maxSizeKB * 512)) {
                    document.getElementById('erroimgmsg3').innerText = 'Max file size is 500 kb';
                    document.getElementById('erroimgmsg3').style.color = 'red'
                    document.getElementById('erroimgmsg3').style.font = 'bold'
                    ev.value = "";
                }
                else {
                    document.getElementById('erroimgmsg3').innerText = '';
                    var reader = new FileReader();
                    reader.onload = function () {
                        var output = document.getElementById('imagePreview3');
                        output.src = reader.result;
                    };
                    reader.readAsDataURL(ev.files[0]);
                }

                if (ext == "gif" || ext == "jpeg" || ext == 'jpg' || ext == "png") {

                }
                else {
                    document.getElementById('erroimgmsg3').innerText = 'Only gif,jpeg,jpg,png formats are allowed';
                    document.getElementById('erroimgmsg3').style.color = 'red'
                    document.getElementById('erroimgmsg3').style.font = 'bold'
                    ev.value = "";
                }
            }

            function Showpicture4(ev) {

                var fileName = ev.value;
                var c = fileName.split("\\");
                var ext = fileName.substring(fileName.lastIndexOf('.') + 1);
                var size = parseFloat(ev.files[0].size);
                var maxSizeKB = 512;//Size in KB.


                if (c[2].includes('_') == true) {
                    document.getElementById('erroimgmsg4').innerText = 'not allowed'
                    document.getElementById('erroimgmsg4').style.color = 'red'
                    fileName = "";
                   
                }
                else if (size > (maxSizeKB * 512)) {
                    document.getElementById('erroimgmsg4').innerText = 'Max file size is 500 kb';
                    document.getElementById('erroimgmsg4').style.color = 'red'
                    document.getElementById('erroimgmsg4').style.font = 'bold'
                    ev.value = "";
                }
                else {
                    document.getElementById('erroimgmsg4').innerText = '';
                    var reader = new FileReader();
                    reader.onload = function () {
                        var output = document.getElementById('imagePreview4');
                        output.src = reader.result;
                    };
                    reader.readAsDataURL(ev.files[0]);
                }

                if (ext == "gif" || ext == "jpeg" || ext == 'jpg' || ext == "png") {

                }
                else { 
                    document.getElementById('erroimgmsg4').innerText = 'Only gif,jpeg,jpg,png formats are allowed';
                    document.getElementById('erroimgmsg4').style.color = 'red'
                    document.getElementById('erroimgmsg4').style.font = 'bold'
                    ev.value = "";
                }
            }

            function Showpicture5(ev) {

                var fileName = ev.value;
                var c = fileName.split("\\");
                var ext = fileName.substring(fileName.lastIndexOf('.') + 1);
                var size = parseFloat(ev.files[0].size);
                var maxSizeKB = 512;//Size in KB.


                if (c[2].includes('_') == true) {
                    document.getElementById('erroimgmsg5').innerText = 'not allowed'
                    document.getElementById('erroimgmsg5').style.color = 'red'
                    fileName = "";
                }
                else if (size > (maxSizeKB * 512)) {
                    document.getElementById('erroimgmsg5').innerText = 'Max file size is 500 kb';
                    document.getElementById('erroimgmsg5').style.color = 'red'
                    document.getElementById('erroimgmsg5').style.font = 'bold'
                    ev.value = "";
                }
                else {
                    document.getElementById('erroimgmsg5').innerText = '';
                    var reader = new FileReader();
                    reader.onload = function () {
                        var output = document.getElementById('imagePreview5');
                        output.src = reader.result;
                    };
                    reader.readAsDataURL(ev.files[0]);
                }


                if (ext == "gif" || ext == "jpeg" || ext == 'jpg' || ext == "png") {

                }
                else {
                    document.getElementById('erroimgmsg5').innerText = 'Only gif,jpeg,jpg,png formats are allowed';
                    document.getElementById('erroimgmsg5').style.color = 'red'
                    document.getElementById('erroimgmsg5').style.font = 'bold'
                    ev.value = "";
                }
            }


            function Add_available() {
                var rdoclothingCheck = document.getElementById('<%=RdoClothing.ClientID%>');
                var rdofootwearCheck = document.getElementById('<%=RdoFootwear.ClientID%>');
                var availableqty = document.getElementById('<%=Txtavlquantity.ClientID%>');
                var clothlargesize = document.getElementById('<%=TxtlargesizeQuantity.ClientID%>').value;
                var clothsmallsize = document.getElementById('<%=TxtsmallsizeQuantity.ClientID%>').value;
                var clothmediumsize = document.getElementById('<%=TxtmediumsizeQuantity.ClientID%>').value;
                var clothxlsize = document.getElementById('<%=TxtxlsizeQuantity.ClientID%>').value;
                var clothxxlsize = document.getElementById('<%=TxtxxlsizeQuantity.ClientID%>').value;
               
                //footweart
                var size4 = document.getElementById('<%=Txtsize4.ClientID%>').value;
                var size5 = document.getElementById('<%=Txtsize5.ClientID%>').value;
                var size6 = document.getElementById('<%=Txtsize6.ClientID%>').value;
                var size7 = document.getElementById('<%=Txtsize7.ClientID%>').value;
                var size8 = document.getElementById('<%=Txtsize8.ClientID%>').value;
                var size9 = document.getElementById('<%=Txtsize9.ClientID%>').value;
                var size10 = document.getElementById('<%=Txtsize10.ClientID%>').value;
                var size11 = document.getElementById('<%=Txtsize11.ClientID%>').value;
                var size12 = document.getElementById('<%=Txtsize12.ClientID%>').value;

                if (rdoclothingCheck.checked == true) {
                    
                    availableqty.value = parseInt(clothsmallsize) + parseInt(clothmediumsize) + parseInt(clothlargesize) + parseInt(clothxlsize) + parseInt(clothxxlsize);
                    
                }
                else if (rdofootwearCheck.checked == true) {

                    availableqty.value = parseInt(size4) + parseInt(size5) + parseInt(size6) + parseInt(size7) + parseInt(size8) + parseInt(size9) + parseInt(size10) + parseInt(size11) + parseInt(size12);
                   

                }

            }
        </script>
        <script>
            function isNumber(text) {
                return /^\d+$/.test(text);
            }
            function checkfornumber(ev) {               
                if (!isNumber(ev.value)) {
                    alert('Test number');
                }                 
            }
        </script>
</asp:Content>
