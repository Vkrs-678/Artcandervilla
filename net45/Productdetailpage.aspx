<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Productdetailpage.aspx.cs" Inherits="RazorpaySampleApp.WebForm16" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-sweetalert/1.0.1/sweetalert.css" />
    <!----Bootstrap--->
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-EVSTQN3/azprG1Anm3QDgpJLIm9Nao0Yz1ztcQTwFspd3yD65VohhpuuCOmLASjC" crossorigin="anonymous">


    <!--searapi--->
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <link rel="stylesheet" href="https://code.jquery.com/ui/1.10.3/themes/smoothness/jquery-ui.css" />

    <style>
        body {
            position: relative;
        }


        .imgf {
            box-shadow: 2px 2px 5px #808080;
            cursor: pointer;
        }

            .imgf:hover {
                box-shadow: 2px 2px 15px #808080;
            }

        .fa-star {
            cursor: pointer;
        }

        .values {
            padding: 20px;
        }

        .box {
            border: solid;
            border-width: thin;
            border-color: orangered;
            width: fit-content;
            border-radius: 10px;
            height: 80px;
            width: 150px;
            box-shadow: 2px 2px 5px orangered;
            display: flex;
            justify-content: center;
            align-items: center;
            cursor: pointer;
        }

            .box:hover {
                box-shadow: 2px 2px 10px orangered;
            }

        .boxsize {
            border: solid;
            border-width: thin;
            border-color: gray;
            width: fit-content;
            border-radius: 5px;
            box-shadow: 2px 2px 5px gray;
        }

        .sizebox {
            border: solid;
            border-width: thin;
            border-color: gray;
            width: fit-content;
            border-radius: 45%;
            box-shadow: 2px 2px 5px gray;
            cursor: pointer;
        }

        .colss:hover {
            box-shadow: 5px 5px 10px gray;
            cursor: pointer;
        }

        #infodiv::-webkit-scrollbar {
            display: none;
        }

        .swiper {
            width: 100%;
            height: 100%;
        }

        .swiper-slide {
            font-size: 18px;
            background: #fff;
            display: flex;
            justify-content: center;
            align-items: center;
            cursor: pointer;
        }

            .swiper-slide img {
                display: block;
                width: 100%;
                height: 70%;
                object-fit: cover;
            }

        .mySwiper .swiper-wrapper .swiper-slide {
            width: 25%;
        }

        @media (min-device-width: 344px) and (max-device-width: 882px) {

            .mySwiper .swiper-wrapper .swiper-slide {
                width: 100%;
            }
        }

        @media (min-device-width: 768px) and (max-device-width: 1024px) {

            .mySwiper .swiper-wrapper .swiper-slide {
                width: 50%;
            }

            .container-fluid .row .col-12 .text-center .sideimgf {
                display: none;
            }
        }
    </style>
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/swiper@11/swiper-bundle.min.css" />

    <script>
    
        function openModal() { $('#btnSubmit').trigger('click'); }
    </script>


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
       
        <asp:HiddenField ID="Hdnurl" runat="server" />
        <div class="row" style="margin-top: 120px">

            <div class="col-12 col-sm-12 col-md-12 col-lg-1 col-xl-1 ms-lg-1 ms-xl-1 mt-5 d-none d-sm-none d-md-block">
                <div class="text-center mt-2">
                    <asp:Image ID="Sidesumimage1" CssClass="img-fluid sideimgf imgf" ImageUrl="~/Images/ProductImages/ZVMPQR985667ZVMPQR/shirt2.jpg" Height="60%" Width="60%" runat="server" />
                </div>
                <div class="text-center mt-2">
                    <asp:Image ID="Sidesumimage2" CssClass="img-fluid sideimgf imgf" ImageUrl="~/Images/ProductImages/ZVMPQR985667ZVMPQR/shirt2.jpg" Height="60%" Width="60%" runat="server" />
                </div>
                <div class="text-center mt-2">
                    <asp:Image ID="Sidesumimage3" CssClass="img-fluid sideimgf imgf" ImageUrl="~/Images/ProductImages/ZVMPQR985667ZVMPQR/shirt2.jpg" Height="60%" Width="60%" runat="server" />
                </div>
                <div class="text-center mt-2">
                    <asp:Image ID="Sidesumimage4" CssClass="img-fluid sideimgf imgf" ImageUrl="~/Images/ProductImages/ZVMPQR985667ZVMPQR/shirt2.jpg" Height="60%" Width="60%" runat="server" />
                </div>
                <div class="text-center mt-2">
                    <asp:Image ID="Sidesumimage5" CssClass="img-fluid sideimgf imgf" ImageUrl="~/Images/ProductImages/ZVMPQR985667ZVMPQR/shirt2.jpg" Height="60%" Width="60%" runat="server" />
                </div>

            </div>
            <!---modal share---->
            <div class="modal fade" id="Sharemodal" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
                <div class="modal-dialog modal-dialog-centered">
                    <div class="modal-content ">
                        <div class="text-end">
                            <button type="button" class="btn-close float-end" data-bs-dismiss="modal" aria-label="Close"></button>
                        </div>
                        <div class="modal-body">
                            <div class="container">
                                <div class="row">
                                    <div class="col-6 col-md-4">
                                        <a target="_blank" href="https://www.gmail.com">
                                            <img height="80" width="90" src="https://mailmeteor.com/logos/assets/PNG/Gmail_Logo_512px.png" />
                                        </a>
                                    </div>
                                    <div class="col-6 col-md-4">
                                        <a href="#" onclick="whatsappshare();" data-action="share/whatsapp/share">
                                            <img height="90" width="100" src="https://upload.wikimedia.org/wikipedia/commons/5/5e/WhatsApp_icon.png" />
                                        </a>
                                    </div>
                                    <div class="col-6 col-md-4">
                                        <a target="_blank" href="https://www.instagram.com/">
                                            <img height="80" width="90" src="https://upload.wikimedia.org/wikipedia/commons/thumb/a/a5/Instagram_icon.png/2048px-Instagram_icon.png" />
                                        </a>
                                    </div>
                                    <div class="col-6 col-md-4 mt-2">
                                        <a target="_blank" href="https://x.com/">
                                            <img height="90" title="x.com" width="100" src="https://static.vecteezy.com/system/resources/thumbnails/031/737/206/small_2x/twitter-new-logo-twitter-icons-new-twitter-logo-x-2023-x-social-media-icon-free-png.png" />
                                        </a>
                                    </div>
                                </div>
                                <div class="text-center">
                                    <label style="cursor: pointer; color: orangered" onclick="sharecopy(this);">Copy to Clipboard !</label>
                                </div>
                            </div>
                        </div>


                    </div>
                </div>
            </div>
            <!---modal share---->
            <div class="col-12 col-sm-12 col-md-12 col-lg-4 col-xl-4 ms-lg-2 ms-xl-2" style="height: fit-content">
                <div id="carouselExampleSlidesOnly" class="carousel slide" data-bs-ride="carousel" data-bs-interval="50000">

                    <div class="carousel-inner" style="position: relative">

                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                            <ContentTemplate>
                                <asp:Label ID="lblid" class="fa-solid fa-heart p-2 m-2 shadow rounded-circle float-end" onclick="addtocart(this);" Style="position: absolute; top: 1%; left: 88%; cursor: pointer; z-index: 9" ForeColor="Gray" runat="server"></asp:Label>
                                <%-- <i class="fa-solid fa-heart p-2 m-2 shadow rounded-circle float-end" id="whislistbutton" onclick="addtocart(this);" style="color: gray; position: absolute; top: 1%; left: 88%; cursor: pointer;z-index:9"></i>--%>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="btnaddtowhishlist" EventName="click" />
                            </Triggers>
                        </asp:UpdatePanel>

                        <i class="fa-solid fa-share p-2 m-2 shadow rounded-circle float-end" onclick="whatsappshare();" style="color: #bdbcbc; position: absolute; top: 1%; left: 77%; cursor: pointer; z-index: 9"></i>

                        <div class="carousel-item active">
                            <%-- <asp:HiddenField ID="iswhishlist" runat="server" />--%>
                            <asp:LinkButton ID="btnaddtowhishlist" OnClick="btnaddtowhishlist_Click" class="d-none" runat="server"></asp:LinkButton>

                            <asp:Image ID="MainImage" class="btn btn-primary" data-bs-toggle="modal" data-bs-target="#mainimagefullview" CssClass="img-fluid" ImageUrl="~/Images/ProductImages/ZVMPQR985667ZVMPQR/Shirt1.jpg" Height="70%" Width="100%" runat="server" />
                        </div>
                        <div class="carousel-item">
                            <asp:Image ID="MainImage1" class="btn btn-primary" data-bs-toggle="modal" data-bs-target="#mainimagefullview" CssClass="img-fluid" ImageUrl="~/Images/ProductImages/ZVMPQR985667ZVMPQR/Shirt1.jpg" Height="70%" Width="100%" runat="server" />
                        </div>
                        <div class="carousel-item">
                            <asp:Image ID="MainImage2" class="btn btn-primary" data-bs-toggle="modal" data-bs-target="#mainimagefullview" CssClass="img-fluid" ImageUrl="~/Images/ProductImages/ZVMPQR985667ZVMPQR/Shirt1.jpg" Height="70%" Width="100%" runat="server" />
                        </div>
                        <div class="carousel-item">
                            <asp:Image ID="MainImage3" class="btn btn-primary" data-bs-toggle="modal" data-bs-target="#mainimagefullview" CssClass="img-fluid" ImageUrl="~/Images/ProductImages/ZVMPQR985667ZVMPQR/Shirt1.jpg" Height="70%" Width="100%" runat="server" />
                        </div>
                        <div class="carousel-item">
                            <asp:Image ID="MainImage4" class="btn btn-primary" data-bs-toggle="modal" data-bs-target="#mainimagefullview" CssClass="img-fluid" ImageUrl="~/Images/ProductImages/ZVMPQR985667ZVMPQR/Shirt1.jpg" Height="70%" Width="100%" runat="server" />
                        </div>
                    </div>
                </div>
                

                <div class="d-flex mt-3 d-lg-none" style="display: flex; justify-content: center; align-items: center; column-gap: 15px">
                    <asp:Image ID="SubImage1" CssClass="img-fluid imgf" ImageUrl="~/Images/ProductImages/ZVMPQR985667ZVMPQR/shirt1.jpg" Height="5%" Width="15%" runat="server" />
                    <asp:Image ID="SubImage2" CssClass="img-fluid imgf" ImageUrl="~/Images/ProductImages/ZVMPQR985667ZVMPQR/shirt2.jpg" Height="5%" Width="15%" runat="server" />
                    <asp:Image ID="SubImage3" CssClass="img-fluid imgf" ImageUrl="~/Images/ProductImages/ZVMPQR985667ZVMPQR/Shirt3.jpg" Height="5%" Width="15%" runat="server" />
                    <asp:Image ID="SubImage4" CssClass="img-fluid imgf" ImageUrl="~/Images/ProductImages/ZVMPQR985667ZVMPQR/Shirt4.jpg" Height="5%" Width="15%" runat="server" />
                    <asp:Image ID="SubImage5" CssClass="img-fluid imgf" ImageUrl="~/Images/ProductImages/ZVMPQR985667ZVMPQR/Shirt5.jpg" Height="5%" Width="15%" runat="server" />
                </div>
            </div>
            <div id="infodiv" class="col-12 col-sm-12 col-md-12 col-lg-2 col-xl-4 border-start" style="overflow-y: scroll; height: 110vh;">
                <div>
                    <asp:Label ID="Lblmainbrand" runat="server" Font-Bold="true" Font-Size="Larger" Font-Italic="true" ForeColor="#ff0066" Text="RAYMOND"></asp:Label>

                </div>
                <div>
                    <asp:Label ID="lblmainproductname" runat="server" Font-Bold="true" Font-Size="Medium" Font-Italic="true" ForeColor="#ff0066" Text="SHIRT"></asp:Label>
                </div>
                <div class="d-flex" onclick="scrolltoview();">

                    <asp:Label ID="Star1" class="fa-solid fa-star" Font-Size="Small" runat="server" Text=""></asp:Label>
                    <asp:Label ID="Star2" class="fa-solid fa-star" Font-Size="Small" runat="server" Text=""></asp:Label>
                    <asp:Label ID="Star3" class="fa-solid fa-star" Font-Size="Small" runat="server" Text=""></asp:Label>
                    <asp:Label ID="Star4" class="fa-solid fa-star" Font-Size="Small" runat="server" Text=""></asp:Label>
                    <asp:Label ID="Star5" class="fa-solid fa-star" Font-Size="Small" runat="server" Text=""></asp:Label>
                    <asp:Label ID="Lblnoofreviews" runat="server" Style="cursor: pointer" Font-Bold="true" Font-Size="Small" Font-Italic="true" ForeColor="gray" Text="(535 Review)"></asp:Label>

                </div>

                <hr />
                <div class="d-flex">
                    <asp:Label ID="lbldiscount" runat="server" Style="cursor: pointer" Font-Size="Large" Font-Italic="true" ForeColor="Black" Text="(-5%)"></asp:Label>&nbsp;
                    <asp:Label ID="Label6" runat="server" Style="cursor: pointer" Font-Size="Large" Font-Italic="true" ForeColor="Black" Text="₹"></asp:Label>
                    <asp:Label ID="lblpriceafterdiscount" runat="server" Style="cursor: pointer" Font-Size="Large" Font-Italic="true" ForeColor="Black" Text="499"></asp:Label>

                </div>
                <div class="d-flex">

                    <asp:Label ID="Label7" runat="server" Font-Size="Large" Font-Italic="true" ForeColor="Gray" Text="M.R.P"></asp:Label>&nbsp;
                    <asp:Label ID="Label8" runat="server" Style="text-decoration: line-through" Font-Size="Large" Font-Italic="true" ForeColor="Gray" Text="₹"></asp:Label>
                    <asp:Label ID="lblpricebeforediscount" runat="server" Style="text-decoration: line-through" Font-Size="Large" Font-Italic="true" ForeColor="Gray" Text="699"></asp:Label>

                </div>
                <div>
                    <asp:Label ID="Label11" runat="server" Font-Size="Smaller" Font-Italic="true" ForeColor="Gray" Text="Inclusive of All Taxes"></asp:Label>
                </div>
                <div>
                    <asp:Label ID="Lblwarranty" runat="server" data-bs-toggle="modal" style="cursor:pointer" data-bs-target="#modalAccount" Font-Size="Small" Font-Bold="true" Font-Italic="true" ForeColor="HotPink" Text=""></asp:Label>
                    
                </div>
                
                <!---modal warranty seller information--->
                <div class="modal fade" id="modalAccount" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
                    <div class="modal-dialog modal-md">
                        <div class="modal-content">
                            <div class="modal-header">
                                <h6 class="modal-title text-bold" style="text-align: center; font-size: larger; font: bolder; text-decoration: none; color: black; cursor: pointer; font-style: italic; font-weight: 600;">Seller's Information</h6>
                                <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                            </div>
                            <div class="modal-body" style="text-align: center">
                                <asp:Label ID="LblSellerName" Font-Bold="true" runat="server" Text="Vikash kumar singh"></asp:Label><br />
                                <asp:Label ID="LblSellerEmail" Font-Bold="true" runat="server" Text="9999963147"></asp:Label><br />
                               

                            </div>
            
              </div>
          </div>
      </div>  
                <!---modal warranty seller information--->
              
                <hr />
                <div class="d-flex" style="column-gap: 10px">
                    <asp:Repeater ID="Rtrsize" runat="server">
                        <ItemTemplate>
                            <asp:Label ID="Label3" Font-Bold="true" onclick="changevalu(this);" Style="border: solid; border-color: gray; padding: 5px; border-radius: 25px; cursor: pointer; font-size: small" CssClass="values" ForeColor="GrayText" runat="server" Text='<%#Eval("sizename") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:Repeater>

                    <asp:LinkButton ID="Lnkbtnsize" OnClick="Lnkbtnsize_Click" runat="server"></asp:LinkButton>

                </div>

                <hr />
                <div class="d-flex" style="column-gap: 30px">
                    <div>
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
                                <asp:Label ID="Label15" Font-Bold="true" CssClass="values" Style="text-decoration: underline" ForeColor="GrayText" runat="server" Text="Size"></asp:Label>
                                <div class="boxsize">
                                    <asp:Label ID="lblsize" Font-Bold="true" CssClass="values" ForeColor="GrayText" runat="server" Text="Medium"></asp:Label>
                                    <asp:HiddenField ID="hdnsizevalue" runat="server" />
                                </div>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="Lnkbtnsize" EventName="click" />
                            </Triggers>
                        </asp:UpdatePanel>

                    </div>
                    <div class="ms-2">
                        <asp:Label ID="Label17" Font-Bold="true" CssClass="values ms-2" Style="text-decoration: underline" ForeColor="GrayText" runat="server" Text="Colour"></asp:Label>
                        <div class="boxsize">
                            <asp:Label ID="lblcolor" Font-Bold="true" CssClass="values" ForeColor="GrayText" runat="server" Text="Pink"></asp:Label>
                        </div>
                    </div>

                </div>
                <hr />
                <asp:Label ID="Label2" Font-Bold="true" CssClass="values" Style="text-decoration: underline" ForeColor="GrayText" runat="server" Text="Check For Delivery Pincode"></asp:Label>&nbsp;&nbsp;
               
                  <asp:UpdatePanel ID="updatepanel" runat="server">
                      <ContentTemplate>
                          <div class="d-flex" style="text-align: center">
                              &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                              <asp:TextBox ID="Txtcheckpincode" CssClass="form-control" BorderColor="Orange" Width="30%" TextMode="Phone" MaxLength="6" runat="server"></asp:TextBox>&nbsp;
                   <asp:LinkButton runat="server" ID="btnpincodesearch" CssClass="btn btn-dark" OnClick="btnpincodesearch_Click">Search</asp:LinkButton>
                          </div>
                          <br />
                          <asp:Label runat="server" ID="lblpincodesearch" ForeColor="Red" Font-Bold="true"></asp:Label>
                      </ContentTemplate>
                  </asp:UpdatePanel>
                <hr />
                <div class="text-center">
                    <asp:Label ID="lbloffertype" runat="server" Font-Size="Large" CssClass="badge bg-dark text-center" Font-Italic="true" ForeColor="white" Text="Limited Time Offer"></asp:Label>
                </div>
                <%-- <hr />
                <h5 style="color:red">Disclaimer : This Website is in  Tesing Phase Now, No Product Will be Deliver.Although You Can Just Experience The Full Funcitonalities.</h5>--%>
                <hr />
                <div>
                    <asp:HiddenField ID="HdnAvailablequantity" Value="" runat="server" />
                    <asp:HiddenField ID="HdnDeliveryprice" Value="" runat="server" />
                    <asp:HiddenField ID="HdnDiscountpercentage" Value="" runat="server" />
                    <asp:Label ID="Label1" Font-Bold="true" CssClass="values" Style="text-decoration: underline" ForeColor="GrayText" runat="server" Text="Qty"></asp:Label>
                    <div class="boxsize ms-3">
                        <asp:DropDownList ID="Dropqty" onchange="verifyquantity();" Style="outline: none" runat="server">
                            <asp:ListItem Value="1" Text="1">1</asp:ListItem>
                            <asp:ListItem Value="2" Text="2">2</asp:ListItem>
                            <asp:ListItem Value="3" Text="3">3</asp:ListItem>
                            <asp:ListItem Value="4" Text="4">4</asp:ListItem>
                            <asp:ListItem Value="5" Text="5">5</asp:ListItem>
                            <asp:ListItem Value="6" Text="6">6</asp:ListItem>
                            <asp:ListItem Value="7" Text="7">7</asp:ListItem>
                            <asp:ListItem Value="8" Text="8">8</asp:ListItem>
                            <asp:ListItem Value="9" Text="9">9</asp:ListItem>
                            <asp:ListItem Value="10" Text="10">10</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
                <hr />
                <asp:Panel ID="PanelButtonbuy" runat="server">
                    <div style="display: flex; justify-content: center; text-align: center; column-gap: 20px">




                        <asp:LinkButton ID="btnbuynow" OnClick="btnbuynow_Click" Width="100%" Style="padding: 10px" CssClass="btn btn-dark" runat="server">Buy Now</asp:LinkButton>
                        <asp:LinkButton ID="btnaddtocart" OnClick="btnaddtocart_Click"  Width="100%" Style="padding: 10px" CssClass="btn btn-dark" runat="server">Add To Cart</asp:LinkButton>




                    </div>
                </asp:Panel>
                <div>
                    <asp:Panel ID="PanelOutofStokc" runat="server">
                        <div style="text-align: center">
                            <h2 style="color: red">OUT OF STOCK</h2>
                        </div>
                    </asp:Panel>
                </div>
                <hr />
                <div class="row">
                    <asp:Repeater ID="Repeaterrefproducts" runat="server">
                        <ItemTemplate>
                            <div class="col-3 col-sm-3 col-md-2 col-lg-1 col-xl-2 mt-2" style="height: fit-content">
                                <a href="Productdetailpage.aspx?productid=<%#Eval("product_id") %>&&productrefid=<%#Eval("product_ref_id") %>">
                                    <asp:Image ID="Imagerefproduct" CssClass="img-fluid imgf" Style="border-radius: 5px" Height="60px" Width="60px" ImageUrl='<%#Eval("image1") %>' runat="server" />
                                </a>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
                <hr />
                <div class="d-flex" style="column-gap: 10px">
                    <div class="box">
                        <asp:Label ID="lblreturnorrplacement" Font-Bold="true" CssClass="values" ForeColor="GrayText" runat="server" Text="7 Day Return"></asp:Label>
                    </div>
                    <div class="box">
                        <asp:Label ID="lblisfreedeliveryornot" Font-Bold="true" CssClass="values" ForeColor="GrayText" runat="server" Text="free Delivery"></asp:Label>
                    </div>
                    <div class="box">
                        <asp:Label ID="lbliscod" Font-Bold="true" CssClass="values" ForeColor="GrayText" runat="server" Text="COD"></asp:Label>
                    </div>

                </div>
                <hr />
                <div style="text-align: left">
                    <asp:Label ID="Label23" Font-Bold="true" CssClass="values" Style="text-decoration: underline" ForeColor="Black" runat="server" Text="Product Specification"></asp:Label><br />
                    <asp:Label ID="lblproductspecification" CssClass="values" ForeColor="GrayText" runat="server" Font-Size="Smaller" Text="00 g  Item Dimensions LxWxH25 x 20 x 4.5 Centimeters"></asp:Label>

                </div>
                <hr />
                <div style="text-align: left">
                    <asp:Label ID="Label19" Font-Bold="true" CssClass="values" Style="text-decoration: underline" ForeColor="Black" runat="server" Text="Product Details"></asp:Label><br />
                    <asp:Label ID="lblproductdetails" CssClass="values" ForeColor="GrayText" runat="server" Font-Size="Smaller" Text="DENNIS LINGO MEN'S SOLID SLIM FIT COTTON CASUAL SHIRT WITH SPREAD COLLAR & FULL SLEEVES (ALSO AVAILABLE IN PLUS SIZE)"></asp:Label>

                </div>
            </div>
            <div class="col-lg-2 text-center">
                <label class="d-none">Hello</label>
            </div>
        </div>
        <div class="row">
            <div class="col">
                <div style="text-align: left">
                    <asp:Label ID="Label21" Font-Bold="true" CssClass="values" Style="text-decoration: underline" ForeColor="Black" runat="server" Text="Product Description"></asp:Label><br />
                    <asp:Label ID="lblproductdescription" CssClass="values" ForeColor="GrayText" runat="server" Text="100% Premium Cotton, Pre-Washed for extremely soft finish and Rich look  Stylish Slim collar casual Shirt for men  
                        Modern Slim Fit, Size chart - S-38, M-40, L-42, XL-44, 
                        XXL-46  Best for casual & smart casual wear"></asp:Label>

                </div>
            </div>
        </div>
     

        <h4>Similar Products</h4>
        <hr />



        <!-- Slider main container -->
        <div class="swiper mySwiper">
            <!-- Additional required wrapper -->
            <div class="swiper-wrapper">
                <!-- Slides -->
                <asp:Repeater ID="Repeatersimilarproduct" runat="server">
                    <ItemTemplate>

                        <div class="swiper-slide">

                            <div class="card mt-3" style="width:100%;">
                                <a href="Productdetailpage.aspx?productid=<%#Eval("product_id") %>&&productrefid=<%#Eval("product_ref_id") %>">
                                    <asp:Image ID="Image1" CssClass="img-fluid" Height="500px" Width="100%" ImageUrl='<%#Eval("image1") %>' runat="server" />
                                </a>
                                <div class="card-body">
                                    <h5 class="card-title text-secondary" style="text-decoration: none;"><%#Eval("productbrand") %></h5>
                                   <%-- <p class="card-text text-secondary" style="text-decoration: none;"><%#Eval("productdetail") %></p>--%>
                                </div>
                            </div>

                        </div>

                    </ItemTemplate>
                </asp:Repeater>

                <%-- <div class="swiper-slide">Slide 2</div>
         <div class="swiper-slide">Slide 3</div>
         <div class="swiper-slide">Slide 4</div>
         <div class="swiper-slide">Slide 5</div>
         <div class="swiper-slide">Slide 6</div>
         <div class="swiper-slide">Slide 7</div>
         <div class="swiper-slide">Slide 8</div>
         <div class="swiper-slide">Slide 9</div>--%>
            </div>
            <!-- If we need pagination -->
            <%--  <div class="swiper-pagination"></div>--%>

            <!-- If we need navigation buttons -->
            <div class="swiper-button-prev bg-white text-secondary p-2"></div>
            <div class="swiper-button-next bg-white text-secondary p-2"></div>

            <!-- If we need scrollbar -->
            <%--   <div class="swiper-scrollbar"></div>--%>
        </div>
        <hr />
        <!---Comments section start-->
           <div class="row mt-1" style="width: 100%">
       <div class="col" style="display:inline-flex; justify-content: space-between; text-align: end">
           <asp:Label ID="Label25" Font-Bold="true" CssClass="values" Font-Size="Larger" ForeColor="GrayText" runat="server" Text="Comments"></asp:Label>
           <asp:Label ID="Label26" Font-Bold="true" data-bs-toggle="modal" data-bs-target="#modalrating" Style="cursor: pointer" CssClass="values" Font-Size="Small" ForeColor="#ff0066" runat="server" Text="Write Review"></asp:Label>
       </div>
   </div>
        <div class="row">
            <section id="comments">
                <div class="col m-2 commentbox">
                    <asp:Repeater ID="RepeaterComment" OnItemDataBound="RepeaterComment_ItemDataBound" runat="server">
                        <ItemTemplate>
                            <div class="p-2 colss">
                                <asp:HiddenField ID="Hiddenratecount" Value='<%#Eval("ratecount") %>' runat="server" />
                                <div class="d-flex">
                                    <asp:Label ID="cstar1" class="fa-solid fa-star" Font-Size="X-Small" runat="server" Text=""></asp:Label>
                                    <asp:Label ID="cstar2" class="fa-solid fa-star" Font-Size="X-Small" runat="server" Text=""></asp:Label>
                                    <asp:Label ID="cstar3" class="fa-solid fa-star" Font-Size="X-Small" runat="server" Text=""></asp:Label>
                                    <asp:Label ID="cstar4" class="fa-solid fa-star" Font-Size="X-Small" runat="server" Text=""></asp:Label>
                                    <asp:Label ID="cstar5" class="fa-solid fa-star" Font-Size="X-Small" runat="server" Text=""></asp:Label>
                                </div>
                                <div>
                                    <h6><%#Eval("username")%></h6>
                                </div>
                                <div>
                                    <p>
                                        <%#Eval("comment")%>
                                    </p>
                                </div>
                                <div class="d-flex">
                                    <p style="color: gray">on  <%#Eval("Commentdate").ToString()%></p>
                                    <asp:HiddenField ID="userhdn" runat="server" Value='<%#Eval("userid") %>' />
                                    <asp:HiddenField ID="productid" runat="server" Value='<%#Eval("product_id") %>' />
                                    <asp:HiddenField ID="productrefid" runat="server" Value='<%#Eval("ref_productid") %>' />
                                    <asp:Label ID="editrating" runat="server" class="text-primary ms-3 text-dark" data-bs-toggle="modal" data-bs-target="#modalrating" Style="text-decoration: underline">Edit</asp:Label>&nbsp;
                                <asp:LinkButton ID="commentdel" OnClick="commentdel_Click" OnClientClick="return AreYouSure(this)" runat="server" class="text-primary ms1 text-dark">Delete</asp:LinkButton>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>


                </div>
            </section>

        </div>




    </div>
    <!---modal---->
    <div class="modal fade" id="mainimagefullview" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog modal-xl">
            <div class="modal-content" style="background-color: transparent; border: none">
                <button type="button" style="color: #ffffff; border: none" class="fa-solid fa-x btn-close ms-auto" data-bs-dismiss="modal" aria-label="Close"></button>
                <div class="modal-body" style="text-align: center">
                    <div id="carouselExampleFade" class="carousel slide carousel-fade" data-bs-ride="carousel">
                        <div class="carousel-inner">
                            <div class="carousel-item active">
                                <asp:Image ID="Imagecarasoul1" class="btn btn-primary" CssClass="img-fluid" ImageUrl="~/Images/ProductImages/ZVMPQR985667ZVMPQR/Shirt1.jpg" Style="height: 100vh; width: 100%" runat="server" />
                            </div>
                            <div class="carousel-item">
                                <asp:Image ID="Imagecarasoul2" class="btn btn-primary" CssClass="img-fluid" ImageUrl="~/Images/ProductImages/ZVMPQR985667ZVMPQR/Shirt2.jpg" Style="height: 100vh; width: 100%" runat="server" />
                            </div>
                            <div class="carousel-item">
                                <asp:Image ID="Imagecarasoul3" class="btn btn-primary" CssClass="img-fluid" ImageUrl="~/Images/ProductImages/ZVMPQR985667ZVMPQR/Shirt3.jpg" Style="height: 100vh; width: 100%" runat="server" />
                            </div>
                            <div class="carousel-item">
                                <asp:Image ID="Imagecarasoul4" class="btn btn-primary" CssClass="img-fluid" ImageUrl="~/Images/ProductImages/ZVMPQR985667ZVMPQR/Shirt4.jpg" Style="height: 100vh; width: 100%" runat="server" />
                            </div>
                            <div class="carousel-item">
                                <asp:Image ID="Imagecarasoul5" class="btn btn-primary" CssClass="img-fluid" ImageUrl="~/Images/ProductImages/ZVMPQR985667ZVMPQR/Shirt5.jpg" Style="height: 100vh; width: 100%" runat="server" />
                            </div>
                        </div>
                        <button class="carousel-control-prev" type="button" data-bs-target="#carouselExampleFade" data-bs-slide="prev">
                            <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                            <span class="visually-hidden">Previous</span>
                        </button>
                        <button class="carousel-control-next" type="button" data-bs-target="#carouselExampleFade" data-bs-slide="next">
                            <span class="carousel-control-next-icon" aria-hidden="true"></span>
                            <span class="visually-hidden">Next</span>
                        </button>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!---modal---->
    <!-- Modal -->
    <div class="modal fade" id="modalrating" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog modal-dialog-centered modal-lg">
            <div class="modal-content">
                <div class="ms-auto">
                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                </div>
                <div class="modal-body" style="text-align: center">
                    <asp:Panel ID="Panel1" runat="server">
                        <div style="justify-content: center; align-items: center; display: flex">

                            <h5 style="color: gray; font: bold;">Login To Comment</h5>
                        </div>
                    </asp:Panel>
                    <asp:Panel ID="Panel3" runat="server">
                        <div style="justify-content: center; align-items: center; display: flex">

                            <h5 style="color: gray; font: bold;">You Have Not Purchased This Product..</h5>
                        </div>
                    </asp:Panel>
                    <asp:Panel ID="Panel2" runat="server">
                        <div>
                            <asp:Image ID="imgcomment" class="btn btn-primary" CssClass="img-fluid img-thumbnail" ImageUrl="~/Images/ProductImages/ZVMPQR985667ZVMPQR/Shirt1.jpg" Style="height: 30vh; width: 40%" runat="server" />
                        </div>
                        <div class="mt-4">
                            <i class="fa-regular fa-star fa-2xl" id="ratestar1" onclick="starchangge();"></i>
                            <i class="fa-regular fa-star fa-2xl" id="ratestar2" onclick="starchangge1();"></i>
                            <i class="fa-regular fa-star fa-2xl" id="ratestar3" onclick="starchangge2();"></i>
                            <i class="fa-regular fa-star fa-2xl" id="ratestar4" onclick="starchangge3();"></i>
                            <i class="fa-regular fa-star fa-2xl" id="ratestar5" onclick="starchangge4();"></i>
                        </div>
                        <div>


                            <asp:Label ID="LblStarctext" Font-Bold="true" ForeColor="HotPink" runat="server" Text=""></asp:Label>
                            <asp:HiddenField ID="HiddenField1" runat="server" />
                        </div>
                        <div class="mt-2">
                            <asp:TextBox ID="Txtcomment" TextMode="MultiLine" Rows="5" Style="resize: none; outline: none; width: 100%;" runat="server"></asp:TextBox>
                        </div>
                        <div style="text-align: center">
                            <asp:LinkButton ID="BtnSaveComment" OnClick="BtnSaveComment_Click" CssClass="btn btn-dark" runat="server">Comment</asp:LinkButton>
                        </div>
                    </asp:Panel>
                </div>

            </div>
        </div>
    </div>
    <!---modal---->
    <script src="https://cdn.jsdelivr.net/npm/bootstrap-sweetalert@1.0.1/dist/sweetalert.min.js"></script>
    <script src="https://code.jquery.com/jquery-3.7.1.min.js" integrity="sha256-/JqT3SQfawRcv/BIHPThkBvs0OEvtFFmqPF/lYI/Cxo=" crossorigin="anonymous"></script>

    <script src="https://code.jquery.com/jquery-1.9.1.js"></script>
    <script src="https://code.jquery.com/ui/1.10.3/jquery-ui.js"></script>

    <!-- Swiper JS -->
    <script src="https://cdn.jsdelivr.net/npm/swiper@11/swiper-bundle.min.js"></script>

    <script>
        const swiper = new Swiper('.mySwiper', {
            // Optional parameters
            // direction: 'horizontal',
            // loop: true,

            slidesPerView: "auto",
            spaceBetween: 30,
            // If we need pagination
            pagination: {
                el: '.swiper-pagination',
                clickable: true,
            },

            // Navigation arrows
            navigation: {
                nextEl: '.swiper-button-next',
                prevEl: '.swiper-button-prev',
            },

            // And if we need scrollbar
            scrollbar: {
                el: '.swiper-scrollbar',
            },
        });
    </script>

    <script type="text/javascript">
        var star1 = document.getElementById('ratestar1');
        var star2 = document.getElementById('ratestar2');
        var star3 = document.getElementById('ratestar3');
        var star4 = document.getElementById('ratestar4');
        var star5 = document.getElementById('ratestar5');

        var startext = document.getElementById('<%=LblStarctext.ClientID%>');
        var hiddenfield = document.getElementById('<%=HiddenField1.ClientID%>');
        function starchangge() {

            star1.className = 'fa-solid fa-star fa-2xl';
            star2.className = 'fa-regular fa-star fa-2xl';
            star3.className = 'fa-regular fa-star fa-2xl';
            star4.className = 'fa-regular fa-star fa-2xl';
            star5.className = 'fa-regular fa-star fa-2xl';

            startext.innerText = 'Poor';
            hiddenfield.value = '1'

        }

        function starchangge1() {

            star1.className = 'fa-solid fa-star fa-2xl';
            star2.className = 'fa-solid fa-star fa-2xl';
            star3.className = 'fa-regular fa-star fa-2xl';
            star4.className = 'fa-regular fa-star fa-2xl';
            star5.className = 'fa-regular fa-star fa-2xl';
            hiddenfield.value = '2';
            startext.innerText = 'Ok';

        }

        function starchangge2() {

            star1.className = 'fa-solid fa-star fa-2xl';
            star2.className = 'fa-solid fa-star fa-2xl';
            star3.className = 'fa-solid fa-star fa-2xl';
            star4.className = 'fa-regular fa-star fa-2xl';
            star5.className = 'fa-regular fa-star fa-2xl';
            hiddenfield.value = '3';
            startext.innerText = 'Good';

        }

        function starchangge3() {

            star1.className = 'fa-solid fa-star fa-2xl';
            star2.className = 'fa-solid fa-star fa-2xl';
            star3.className = 'fa-solid fa-star fa-2xl';
            star4.className = 'fa-solid fa-star fa-2xl';
            star5.className = 'fa-regular fa-star fa-2xl';
            hiddenfield.value = '4';
            startext.innerText = 'Very Good';

        }

        function starchangge4() {

            star1.className = 'fa-solid fa-star fa-2xl';
            star2.className = 'fa-solid fa-star fa-2xl';
            star3.className = 'fa-solid fa-star fa-2xl';
            star4.className = 'fa-solid fa-star fa-2xl';
            star5.className = 'fa-solid fa-star fa-2xl';
            hiddenfield.value = '5';
            startext.innerText = 'Excellent';

        }

        function scrolltoview() {
            document.getElementById('comments').scrollIntoView(true);
        }


        function verifyquantity() {
            var dropdown = document.getElementById('<%=Dropqty.ClientID%>');
            var availableqty = document.getElementById('<%=HdnAvailablequantity.ClientID%>');


            if (parseInt(dropdown.value) > parseInt(availableqty.value)) {
                swal('Quanitiy', 'Only' + availableqty.value + ' Quantities are Available !', 'error');
                dropdown.value = availableqty.value;
            }

        }
    </script>




    <script>             
        var imgSrc = document.getElementById("<%=SubImage1.ClientID %>").src;
        $(function () {
            $("#<%=SubImage1.ClientID%>").on("mouseover", function (e) {
                e.preventDefault();
                $("#<%= MainImage.ClientID %>").attr("src", imgSrc);
                $("#<%= SubImage1.ClientID %>").attr("disabled", "disabled");
            });
        });


        var imgSrc1 = document.getElementById("<%=SubImage2.ClientID %>").src;
        $(function () {
            $("#<%=SubImage2.ClientID%>").on("mouseover", function (e) {
                e.preventDefault();
                $("#<%= MainImage.ClientID %>").attr("src", imgSrc1);
                $("#<%= SubImage2.ClientID %>").attr("disabled", "disabled");
            });
        });

        var imgSrc2 = document.getElementById("<%=SubImage3.ClientID %>").src;
        $(function () {
            $("#<%=SubImage3.ClientID%>").on("mouseover", function (e) {
                e.preventDefault();
                $("#<%= MainImage.ClientID %>").attr("src", imgSrc2);
                $("#<%= SubImage3.ClientID %>").attr("disabled", "disabled");
            });
        });

        var imgSrc3 = document.getElementById("<%=SubImage4.ClientID %>").src;
        $(function () {
            $("#<%=SubImage4.ClientID%>").on("mouseover", function (e) {
                e.preventDefault();
                $("#<%= MainImage.ClientID %>").attr("src", imgSrc3);
                $("#<%= SubImage4.ClientID %>").attr("disabled", "disabled");
            });


            var imgSrc4 = document.getElementById("<%=SubImage5.ClientID %>").src;
            $(function () {
                $("#<%=SubImage5.ClientID%>").on("mouseover", function (e) {
                    e.preventDefault();
                    $("#<%= MainImage.ClientID %>").attr("src", imgSrc4);
                    $("#<%=SubImage5.ClientID %>").attr("disabled", "disabled");
                });
            });
        });
    </script>
    <script>

        async function fetchdata() {
            const request = await fetch("https://ipinfo.io/json?token=efe6fe5d1dde42")
            const jsonResponse = await request.json()

            console.log(jsonResponse.ip);
        }


        fetchdata();

    </script>
    <script>
        document.getElementsByClassName('values')[0].style.borderColor = "hotpink";
        document.getElementsByClassName('values')[0].style.color = "hotpink";
        function changevalu(ev) {

            document.getElementById('<%=lblsize.ClientID%>').innerText = ev.innerText;
            document.getElementById('<%=hdnsizevalue.ClientID%>').value = ev.innerText;
            document.getElementById('<%=Lnkbtnsize.ClientID%>').click();

            var btn = document.getElementsByClassName('values');
            for (var i = 0; i < btn.length; i++) {
                btn[i].style.borderColor = "gray";
                btn[i].style.color = "gray";
            }
            ev.style.borderColor = "hotpink";
            ev.style.color = "hotpink";

        }
    </script>

    <script>
        var imgSrc = document.getElementById("<%=Sidesumimage1.ClientID %>").src;
        $(function () {
            $("#<%=Sidesumimage1.ClientID%>").on("mouseover", function (e) {
                e.preventDefault();
                $("#<%= MainImage.ClientID %>").attr("src", imgSrc);
                $("#<%= Sidesumimage1.ClientID %>").attr("disabled", "disabled");
            });
        });


        var imgSrc1 = document.getElementById("<%=Sidesumimage2.ClientID %>").src;
        $(function () {
            $("#<%=Sidesumimage2.ClientID%>").on("mouseover", function (e) {
                e.preventDefault();
                $("#<%= MainImage.ClientID %>").attr("src", imgSrc1);
                $("#<%= Sidesumimage2.ClientID %>").attr("disabled", "disabled");
            });
        });

        var imgSrc2 = document.getElementById("<%=Sidesumimage3.ClientID %>").src;
        $(function () {
            $("#<%=Sidesumimage3.ClientID%>").on("mouseover", function (e) {
                e.preventDefault();
                $("#<%= MainImage.ClientID %>").attr("src", imgSrc2);
                $("#<%= Sidesumimage3.ClientID %>").attr("disabled", "disabled");
            });
        });

        var imgSrc3 = document.getElementById("<%=Sidesumimage4.ClientID %>").src;
        $(function () {
            $("#<%=Sidesumimage4.ClientID%>").on("mouseover", function (e) {
               e.preventDefault();
               $("#<%= MainImage.ClientID %>").attr("src", imgSrc3);
               $("#<%= Sidesumimage4.ClientID %>").attr("disabled", "disabled");
           });


           var imgSrc4 = document.getElementById("<%=Sidesumimage5.ClientID %>").src;
           $(function () {
               $("#<%=Sidesumimage5.ClientID%>").on("mouseover", function (e) {
                   e.preventDefault();
                   $("#<%= MainImage.ClientID %>").attr("src", imgSrc4);
                   $("#<%=Sidesumimage5.ClientID %>").attr("disabled", "disabled");
               });
           });
       });
    </script>

    <script>
       <%-- function isWhislist() {
           
            var iswhish = document.getElementById('<%=iswhishlist.ClientID%>').value;
            
            if (iswhish == '1') {
                document.getElementById('whislistbutton').style.color = 'red';
            }
            else {
                document.getElementById('whislistbutton').style.color = 'gray';
            }
        }---%>

        function addtocart(ev) {
            document.getElementById('<%=btnaddtowhishlist.ClientID%>').click();
           


        }

        function deliveryplain() {
            var textdelivery = document.getElementById('<%=lblpincodesearch.ClientID%>');
            console.log(textdelivery);
            setTimeout(() => {
                textdelivery.innerText = '';
            },5000)
        }


        function sharecopy(ev) {

            navigator.clipboard.writeText(window.location.href);
            ev.innerText = 'Copied !';
            setTimeout(() => { ev.innerText = 'Copy to Clipboard !' }, 3000);
        }


        //remove Pop up

        var obj = { status: false, ele: null };
        function AreYouSure(ev) {
            if (obj.status) {
                return true;
            };
            swal({
                title: "Are you sure?",
                text: "Are You Sure Want To Delete This Comment ?",
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


        function addtocaralert() {
            Swal.fire({
                position: "top-end",
                icon: "success",
                title: "Your work has been saved",
                showConfirmButton: false,
                timer: 1500
            });
        }

        function whatsappshare() {
           // var a = document.URL;
            // window.open('https://api.whatsapp.com//send?text='+a);
            navigator.share({
                title: "Art-Candervilla",
                url: document.URL,
                text: "Best Products under your Budget\n",

            })
            
        }
            
    </script>



</asp:Content>
