<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="RazorpaySampleApp.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Css/style.css" rel="stylesheet" />
    <!---- Responsive--->
  <link href="Css/Responsive/ResponsiveStyle.css" rel="stylesheet" />
      
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

   
  
     
  
    <!----Carasoul---->
    <div id="carouselExampleIndicators" class="carousel slide" data-bs-ride="carousel" style="margin-top:80px">
        <div id="carsol" class="carousel-indicators">
            <button type="button" data-bs-target="#carouselExampleIndicators" data-bs-slide-to="0" class="active" aria-current="true" aria-label="Slide 1" style="color:#e66e6e"></button>
            <button type="button" data-bs-target="#carouselExampleIndicators" data-bs-slide-to="1" aria-label="Slide 2"></button>
            <button type="button" data-bs-target="#carouselExampleIndicators" data-bs-slide-to="2" aria-label="Slide 3"></button>
            <button type="button" data-bs-target="#carouselExampleIndicators" data-bs-slide-to="3" aria-label="Slide 4"></button>
            <button type="button" data-bs-target="#carouselExampleIndicators" data-bs-slide-to="4" aria-label="Slide 5"></button>

        </div>
        <div class="carousel-inner">
            <div class="carousel-item active">
                <div  class="bannersAx" style="background-image:url('../images/banner/banner1.jpg'); min-height: 490px;background-repeat: no-repeat; background-size: cover;background-position: 90% center;">
                    <div class="home-banner-text" style=" position: absolute; top: 50%;left: 60%;transform: translate(-110%,-50%);">
                        <h1 style="color:white">E-Shop</h1>
                        <h2 style="color:white">100% Payment Protection With Razorpay</h2>
                        <a href="Productpage.aspx" class="btn-danger btn text-uppercase mt-4">Shop Now</a>
                    </div>
                </div>
            </div>
            <div class="carousel-item">
                <div class="bannersB" style="background-image:url('../images/banner/banner2.jpg'); min-height: 490px;background-repeat: no-repeat; background-size: cover;background-position: 90% center;">
                    <div class="home-banner-text" style=" position: absolute; top: 50%;left: 60%;transform: translate(-110%,-50%);">
                        <h1>WOMEN PRODUCTS</h1>
                        <h2>50% Discount For The Season</h2>
                        <a href="Productpage.aspx" class="btn-danger btn text-uppercase mt-4">Buy Nows</a>
                    </div>
                </div>
            </div>
            <div class="carousel-item">
                <div class="bannersC" style="background-image:url('../images/banner/banner3.jpg'); min-height: 490px;background-repeat: no-repeat; background-size: cover;background-position: 90% center;">
                    <div class="home-banner-text" style=" position: absolute; top: 50%;left: 60%;transform: translate(-110%,-50%);">
                        <h1 style="color:green">FOOTWEARS</h1>
                        <h2 style="color:green;">40% Discount For The Season</h2>
                        <a href="Productpage.aspx" class="btn-danger btn text-uppercase mt-4">Buy Nows</a>
                    </div>
                </div>
            </div>

            <div class="carousel-item">
                <div class="bannersD" style="background-image:url('../images/banner/banner4.jpg'); min-height: 490px;background-repeat: no-repeat; background-size: cover;background-position: 90% center;">
                    <div class="home-banner-text" style=" position: absolute; top: 50%;left: 60%;transform: translate(-110%,-50%);">
                        <h1>PERSONAL CARE</h1>
                        <h2 >20% Discount For The Season</h2>
                        <a href="Productpage.aspx"  class="btn-danger btn text-uppercase mt-4">Buy Nows</a>
                    </div>
                </div>
            </div>

            <div class="carousel-item">
                <div class="bannersEx" style="background-image:url('../images/banner/banner5.jpg'); min-height: 490px;background-repeat: no-repeat; background-size: cover;background-position: 90% center;">
                    <div class="home-banner-text" style=" position: absolute; top: 50%;left: 60%;transform: translate(-110%,-50%);">
                        <h1 style="color:white">MENS PRODUCTS</h1>
                        <h2 style="color:white">70% Discount For The Season</h2>
                        <a href="Productpage.aspx?subcatid=11" class="btn-danger btn text-uppercase mt-4">Buy Nows</a>
                    </div>
                </div>
   </div>

        </div>
        <button class="carousel-control-prev" type="button" data-bs-target="#carouselExampleIndicators" data-bs-slide="prev">
            <span class="carousel-control-prev-icon" aria-hidden="true" style="background-color:#e66e6e"></span>
            <span class="visually-hidden">Previous</span>
        </button>
        <button class="carousel-control-next" type="button" data-bs-target="#carouselExampleIndicators" data-bs-slide="next">
            <span class="carousel-control-next-icon" aria-hidden="true" style="background-color:#e66e6e"></span>
            <span class="visually-hidden">Next</span>
        </button>
        <button class="carousel-control-next" type="button" data-bs-target="#carouselExampleIndicators" data-bs-slide="next">
            <span class="carousel-control-next-icon" aria-hidden="true" style="color:#e66e6e"></span>
            <span class="visually-hidden">Next</span>
        </button>
        <button class="carousel-control-next" type="button" data-bs-target="#carouselExampleIndicators" data-bs-slide="next">
            <span class="carousel-control-next-icon" aria-hidden="true" style="color:#e66e6e"></span>
            <span class="visually-hidden">Next</span>
        </button>
    </div>
   
    
    <!----Carasoul---->
     <!--------Top Categories---------->
    <h3 class="text-center mb-5">Top Categories to choose from</h3>
    <hr />
        <div id="player" class="container mt-3 text-center d-flex align-content-center ps-4">
            <a href="productpage.aspx"></a>
               <%-- <iframe width="1025" height="615" src="https://www.youtube.com/embed/75nNqaNOYrs?autoplay=1&mute=1&loop=1&rel=0&controls=0&showinfo=0;" frameborder="0"></iframe>--%>
              
           <%-- <img src="Images/banner/4669729edda.jpeg"  class="img-fluid" style="width:100%;height:50%" /></a>--%>
       <%-- <video loop muted autoplay="autoplay" style="width:100%;height:50%">
            <source src="Video/M&S Women's Fashion_ The New Autumn Season A_W16 TV Ad - M&S (720p, h264, youtube).mp4" />
        </video>--%>
    </div>
     <br />
 <br />
 <br />
    <div class="container" style="border-radius:5px;background-color:antiquewhite">
        <div class="row">
            <div class="col-12 col-md-4">
                  <img class="p-2 img-fluid " style="border-radius:5px;height:100%;width:100%" src="Images/banner/GuoIrIVtAfGm0s6voZff.jpeg" />
            </div>
            <div class="col-12 col-md-4">
                <img class="p-2 img-fluid " style="border-radius: 5px; height: 100%; width: 100%" src="Images/banner/7QO0pZmUxtBfone7JE.jpeg" />
            </div>
            <div class="col-12 col-md-4">
                <img class="p-2 img-fluid " style="border-radius: 5px; height: 100%; width: 100%" src="Images/banner/AnCZDEZqWirTKX.jpeg" />
            </div>
        </div>
      
      
    </div>
    <br />
    <br />
    <br />
    <div class="container" style="border-radius:5px;background-color:antiquewhite;text-align:center">
      <div class="row">
          <div class="col-4">
              <img class="p-2 img-fluid mt-3" style="border-radius: 5px;" src="Images/banner/shoesformen.jpeg" />
          </div>
          <div class="col-4">
               <img class="p-2 img-fluid mt-3" style="border-radius: 5px;" src="Images/banner/levitatin.jpeg" />             

          </div>
          <div class="col-4">
              <img class="p-2 img-fluid mt-3" src="Images/banner/notebook.jpeg" /> 
          </div>
      </div>
        <div class="row text-center">
            <div class="col-4"></div>
            <div class="col-4">
                 <a href="Productpage.aspx" class="btn btn-danger m-3">View All</a>
            </div>
            <div class="col-4"></div>
            
        </div>
 
 </div>
      <h3 class="text-center mt-5">Top Quility Brands</h3>
  <hr />
      
   <div class="container" style="border-radius:5px;background-color:antiquewhite;text-align:center">
     <div class="row">
         <div class="col-6">
             <img class="p-4 img-fluid mt-3" height="390" width="370" style="border-radius: 5px;" src="https://images.surferseo.art/8c2a0ef9-800a-4aa1-89f8-116aefeb516f.webp" />
         </div>
         <div class="col-6">
              <img class="p-4 img-fluid mt-3" style="border-radius: 5px;" src="https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQD34nb8j-d13wnlhEQNrN1mRt1OoLFOBoTPQ&s" />
         </div>
     </div>
        <div class="row">
     <div class="col-6">
         <img class="p-4 img-fluid mt-3" style="border-radius: 5px;" src="https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTBoyP9xUigGl6cbWK19VpKfT26PyItL9RjVw&s" />
     </div>
     <div class="col-6">
          <img class="p-4 img-fluid mt-3" style="border-radius: 5px;" src="https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcROyomiM956pYr7S3J9plLy-so154O2mu7ixA&s" />
     </div>
 </div>         
</div>





  

       <br />
   <br />
   <br />
   <div class="container" style="border-radius:5px;background-color:antiquewhite;text-align:center">
     <a href="SellerLogin.aspx">
<img class="p-4 img-fluid mt-3"  style="border-radius: 5px;" src="Images/banner/imagesforbanner.jpeg" />
</a>
</div>

    <!--------Top Categories---------->
    <!---Category---->
    <h3 class="text-center mt-5">Categories</h3>
    <hr />
    <div class="container">
        <div class="row gy-2 my-4">

            <asp:Repeater ID="Rptrmenu" runat="server">
                <ItemTemplate>
                    <div class="col-md-4 col-sm-6 col-lg-3 col-6">
                        <a href="Productpage.aspx?mainid=<%#Eval("id") %>">
                            <div class="card shadow" style="cursor: pointer">
                                <asp:Image ID="Image1" CssClass="img-fluid" ImageUrl='<%#Eval("CatImage") %>' Height="250px" Width="100%" class="card-img-top" runat="server" />
                                <div class="card-body">
                                    <center>
                                        <a  href="Productpage.aspx?mainid=<%#Eval("id") %>" class="card-text" style="color:saddlebrown;font-weight:bolder; font-style:italic;text-decoration:none"><%#Eval("Catname") %></a>
                                    </center>
                                </div>
                            </div>
                        </a>
                    </div>
                </ItemTemplate>
            </asp:Repeater>


        </div>


    </div>


    <!---Category---->
    <!-----Paymetn declaration---->
    <asp:LinkButton ID="btnsendsms" Visible="false" CssClass="btn btn-dark" OnClick="btnsendsms_Click" runat="server">Send Sms</asp:LinkButton>
    <asp:Label ID="smsmsg" Text="" runat="server"></asp:Label>
    <!---sent sms-->
    <div style="text-align: center">
       <h5 style="color: gray;font-size:smaller">100% Payment Protection</h5>
    </div>
    <div style="display: flex; justify-content: center; align-items: center;">
      <%--  <img src="Images/PaymentTypes/bhartapay.png" height="50" width="120" class="me-2" />--%>
         
        <img src="Images/PaymentTypes/razorpay.png" height="50" width="120" />
       <%-- <img src="Images/PaymentTypes/RuPay.png" height="25" width="110" />--%>
    </div>
    <!-----Paymetn declaration end---->
  <%--  <div action="Charge.aspx" method="post" name="razorpayForm">
        <input id="razorpay_payment_id" type="hidden" name="razorpay_payment_id" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<input id="razorpay_order_id" type="hidden" name="razorpay_order_id" />
        <input id="razorpay_signature" type="hidden" name="razorpay_signature" />
    </div>
  
    <div style="display: flex; justify-content: center; align-content: center">

        <div>
            <button id="rzp-button1">Pay with Razorpay</button>
        </div>
    </div>

    <script src="https://checkout.razorpay.com/v1/checkout.js"></script>
    <script>
        var orderId = "<%=orderId%>"
        var options = {
            "name": "DJ Tiesto",
            "description": "Tron Legacy",
            "order_id": orderId,
            "image": "https://s29.postimg.org/r6dj1g85z/daft_punk.jpg",
            "prefill": {
                "name": "Daft Punk",
                "email": "customer@merchant.com",
                "contact": "+919999999999",
            },
            "notes": {
                "address": "Hello World",
                "merchant_order_id": "12312321",
            },
            "theme": {
                "color": "#F37254"
            }
        }
        // Boolean whether to show image inside a white frame. (default: true)
        options.theme.image_padding = false;
        options.handler = function (response) {
            document.getElementById('razorpay_payment_id').value = response.razorpay_payment_id;
            document.getElementById('razorpay_order_id').value = orderId;
            document.getElementById('razorpay_signature').value = response.razorpay_signature;
            document.razorpayForm.submit();
        };
        options.modal = {
            ondismiss: function () {
                console.log("This code runs when the popup is closed");
            },
            // Boolean indicating whether pressing escape key 
            // should close the checkout form. (default: true)
            escape: true,
            // Boolean indicating whether clicking translucent blank
            // space outside checkout form should close the form. (default: false)
            backdropclose: false
        };
        var rzp = new Razorpay(options);
        document.getElementById('rzp-button1').onclick = function (e) {
            rzp.open();
            e.preventDefault();
        }
    </script>--%>

  <%--  <script>
      window.history.forward();
    </script>--%>

    <script>
       
// 2. This code loads the IFrame Player API code asynchronously.
            var tag = document.createElement('script');

            tag.src = "https://www.youtube.com/iframe_api";
            var firstScriptTag = document.getElementsByTagName('script')[0];
            firstScriptTag.parentNode.insertBefore(tag, firstScriptTag);

      // 3. This function creates an <iframe> (and YouTube player)
                //    after the API code downloads.
                var player;
                function onYouTubeIframeAPIReady() {
                    player = new YT.Player('player', {
                        height: '100%',
                        width: '100%',
                        fitToBackground: true,
                        videoId: '75nNqaNOYrs',
                        playerVars: {
                            'autoplay': 1,
                            'controls': 0,
                            'autohide': 1,
                            'enablejsapi': 1,
                            'loop': 1,
                            'disablekb': 1,
                            'fs': 0,
                            'modestbranding': 0,
                            'showinfo': 0,
                            'color': 'white',
                            'theme': 'light',
                            'rel': 0,
                            'playlist': '75nNqaNOYrs'
                        },
                        events: {
                            'onReady': onPlayerReady
                        }
                    });
      }

                // 4. The API will call this function when the video player is ready.
                function onPlayerReady(event) {
                    event.target.playVideo();
                player.mute();
                player.setVolume(0);
                player.setSize(600, 500);
                player.setLoop(true);
                player.setPlaybackQuality('hd1080');
      }
    </script>
</asp:Content>
