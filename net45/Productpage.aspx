<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Productpage.aspx.cs" Inherits="RazorpaySampleApp.WebForm15" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .rounded:hover {
            box-shadow: 2px 2px 5px black;
        }

       .row .card .fa-heart{
            left:85%
        }

       @media(min-device-width:344px) and (max-device-width:882px){
        .row .card .fa-heart {
            left: 75%
        }
       }

        @media(min-device-width:820px) and (max-device-width:1180px) {
            .row .card .fa-heart {
                left: 80%
            }
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container" style="margin-top: 100px; background-color: white;">
        <a class="ms-3" data-bs-toggle="modal" data-bs-target="#Sortingmodal" style="cursor: pointer;">Sort item</a>


       
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <fieldset style="width: 100%">
                    <!----Repeater--->
                    <div class="row gy-0 gy-md-2 my-2 gx-0 gx-md-3">

                        <asp:Repeater ID="Rptrimage" OnItemDataBound="Rptrimage_ItemDataBound" runat="server">
                            <ItemTemplate>                               
                                    <div class="col-md-4 col-sm-6 col-lg-3 col-6 col-xl-3">
                                        <a target="_blank" style="text-decoration: none"  href="Productdetailpage.aspx?productid=<%#Eval("product_id") %>&&productrefid=<%#Eval("product_ref_id") %>">
                                            <div class="card rounded w-60 w-lg-50" id="cardshadow" style="cursor: pointer;border-radius: 25px;">
                                                
                                                <div id="carouselExampleSlidesOnly" class="carousel slide" data-bs-ride="carousel" data-bs-interval="3000" style="position:relative">
                                                    <div class="carousel-inner">

                                                        <div class="carousel-item active">
                                                            <asp:Image ID="Image1" CssClass="img-fluid d-block w-100" ImageUrl='<%#Eval("Image1") %>' Height="300px" Width="100%" class="card-img-top" runat="server" />

                                                        </div>
                                                        <div class="carousel-item">

                                                            <asp:Image ID="Image7" CssClass="img-fluid d-block w-100" ImageUrl='<%#Eval("Image2") %>' Height="300px" Width="100%" class="card-img-top" runat="server" />
                                                        </div>
                                                        <div class="carousel-item">
                                                            <asp:Image ID="Image8" CssClass="img-fluid d-block w-100" ImageUrl='<%#Eval("Image3") %>' Height="300px" Width="100%" class="card-img-top" runat="server" />
                                                        </div>
                                                        <div class="carousel-item">
                                                            <asp:Image ID="Image9" CssClass="img-fluid d-block w-100" ImageUrl='<%#Eval("Image4") %>' Height="300px" Width="100%" class="card-img-top" runat="server" />
                                                        </div>
                                                        <div class="carousel-item">
                                                            <asp:Image ID="Image10" CssClass="img-fluid d-block w-100" ImageUrl='<%#Eval("Image5") %>' Height="300px" Width="100%" class="card-img-top" runat="server" />
                                                        </div>
                                                    </div>    
                                                    <asp:HiddenField ID="hdnproductrefid" runat="server"  Value='<%#Eval("product_ref_id") %>' />
                                                    <asp:HiddenField ID="hdnproductid" runat="server"  Value='<%#Eval("product_id") %>' />
                                                    <asp:HiddenField ID="hdbaddedwishlist" runat="server"  Value='<%#Eval("wishlist") %>' />
                                                      <asp:Label ID="totalcolors" Font-Bold="true" CssClass="float-end" ForeColor="Violet" style="position:absolute; top:5%;left:0%"  Font-Size="X-Small" runat="server" ></asp:Label>
                                                       <asp:Label ID="lblisAddedtowhishlist" Visible="false" class="fa-solid fa-heart p-2 m-2  float-end" style=" position: absolute; top: 1%; cursor: pointer;z-index:9" ForeColor="Red" runat="server"></asp:Label>

                                                </div>

                                               
                                                 <!---modal share---->  
                                              
   
                                                <!---modal share---->
                                                <div class="ms-1 text-center" style="position:absolute;bottom:30%;left:25%">
                                                    <asp:HiddenField ID="HdnTotalrate" Value='<%#Eval("totalrate")%>' runat="server" />
                                                    <asp:HiddenField ID="Hdngainrate" Value='<%#Eval("gainrate")%>' runat="server" />
                                                    <asp:Label ID="Label7" class="fa-solid fa-star" Style="color:black" Font-Size="X-Small" runat="server"></asp:Label>
                                                    <asp:Label ID="Label8" class="fa-solid fa-star" Font-Size="X-Small" Style="color: black" runat="server"></asp:Label>
                                                    <asp:Label ID="Label9" class="fa-solid fa-star" Font-Size="X-Small" Style="color: black" runat="server"></asp:Label>
                                                    <asp:Label ID="Label10" class="fa-solid fa-star" Font-Size="X-Small" Style="color: black" runat="server"></asp:Label>
                                                    <asp:Label ID="Label11" class="fa-solid fa-star" Font-Size="X-Small" Style="color: black" runat="server"></asp:Label>
                                                    <asp:Label ID="Label13" Font-Italic="true" Font-Bold="true" ForeColor="GrayText" Style="color: black" Font-Size="Smaller" runat="server" Text='<%#"("+Eval("comments").ToString()+")"%>'></asp:Label>                                                   
                                                </div>

                                                <div class="ms-1">
                                                    <asp:Label ID="Label1" Font-Bold="true" Font-Italic="true" ForeColor="GrayText" runat="server" Text='<%#Eval("productbrand").ToString().Length<10?Eval("productbrand").ToString():Eval("productbrand").ToString().Substring(0,10)+".."%>'></asp:Label>&nbsp;
                                                  

                                                </div>
                                                <div class="d-flex ms-1">
                                                    
                                                    <asp:Label ID="Label2" Font-Italic="true" ForeColor="GrayText" Font-Size="X-Small" runat="server" Text='<%#Eval("productname").ToString().Length<30?Eval("productname").ToString(): Eval("productname").ToString().Substring(0,30)+"...."%>'></asp:Label>&nbsp;&nbsp;
                                                  
                                                </div>
                                                <div class="d-flex ms-1">
                                                    <asp:Label ID="Label3" ForeColor="GrayText" runat="server" Text='<%#"₹ "+Eval("finaprice")%>'>></asp:Label>&nbsp;
                                                    <asp:Label ID="Label6" class="badge bg-dark" Font-Italic="true" ForeColor="white" Font-Size="XX-Small" runat="server" Text='<%#Eval("isfestiveoffer").ToString()=="0"?"":Eval("isfestiveoffer").ToString()=="1"?"Limited Time Offer":Eval("isfestiveoffer").ToString()=="2"?"Festive Offer":""%>'></asp:Label>
                                                </div>
                                                <div class="d-flex ms-1">
                                                    <asp:Label ID="Label4" ForeColor="GrayText" Style="text-decoration: line-through" runat="server" Text='<%#"₹ "+Eval("originalprice")%>'></asp:Label>&nbsp;
                                                    <asp:Label ID="Label5" ForeColor="GrayText" runat="server" Text='<%#"("+Eval("productdiscount")+"% off)"%>'></asp:Label>
                                                </div>
                                            </div>
                                        </a>
                                    </div>
                               
                            </ItemTemplate>
                        </asp:Repeater>

                    </div>
                    <!----Repeater--->
                   <br />
                    <div style="text-align: center">
                        <asp:Button ID="Btnloadmore" CssClass="btn btn-dark" OnClick="Btnloadmore_Click" runat="server" Text="Load More" />
                        <asp:UpdateProgress ID="UpdateProgress1" ClientIDMode="Static" DisplayAfter="10" runat="server">
                            <ProgressTemplate>
                                <img src="Images/Loader/loader.gif" alt="Loading" style="height: 46px; width: 45px" />
                            </ProgressTemplate>
                        </asp:UpdateProgress>
                    </div>
                </fieldset>

            </ContentTemplate>
        </asp:UpdatePanel>

    </div>







    <!-- Modal sorting-->
    <div class="modal fade" id="Sortingmodal" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog modal-dialog-centered">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="exampleModalLabel">Sort Items</h5>
                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                </div>
                <div class="modal-body">
                    <div>
                        <asp:RadioButton ID="Rdodiscount" GroupName="Sorting" Text="Discount" Font-Bold="true" ForeColor="#666666" runat="server" />
                    </div>
                    <div>
                        <asp:RadioButton ID="RdoLowtoHigh" GroupName="Sorting" Text="Low To High" Font-Bold="true" ForeColor="#666666" runat="server" />
                    </div>
                    <div>
                        <asp:RadioButton ID="RdoHightoLow" GroupName="Sorting" Text="High To Low" Font-Bold="true" ForeColor="#666666" runat="server" />
                    </div>
                    <div style="text-align: right">
                        <asp:LinkButton ID="LnkApply" OnClick="LnkApply_Click" CssClass="btn btn-primary" runat="server">Apply</asp:LinkButton>
                    </div>

                </div>

            </div>
        </div>
    </div>


</asp:Content>
