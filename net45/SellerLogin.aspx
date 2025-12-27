<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="SellerLogin.aspx.cs" Inherits="RazorpaySampleApp.WebForm3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
      <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap-sweetalert@1.0.1/dist/sweetalert.min.css">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel ID="PanelsellerLogin" runat="server">
        <section class="wrapper" style="margin-top: 120px">

            <div class="container">

                <div class="col-sm-8 offset-sm-2 col-lg-6 offset-lg-3 col-xl-4 offset-xl-4 text-center">

                    <div class="rounded bg-white shadow p-5">
                        <h5>Login As Seller to
                            <br />
                            <span style="color: deeppink; font-family: cursive; font-weight: 600">Art</span><span style="color: forestgreen; font-family: cursive; font-weight: 600">-Candervilla</span></h5>
                        <span class="text-dark text-muted mb-5 fw-bold" style="cursor: auto">New Here? </span>
                        <asp:LinkButton class="text-primary fw-bold text-decoration-none" OnClick="LnkShowsignup_Click" Style="cursor: pointer" ID="LnkShowsignup" runat="server">Sign-Up</asp:LinkButton>
                        <div class="form-floating mb-3 mt-4">
                            <asp:TextBox ID="TxtMobileNo" class="form-control shadow" placeholder="Mobile Number" Style="border-color: #f1ecec; box-shadow: 0px 0px 0px hotpink" runat="server"></asp:TextBox>
                            <label for="TxtMobileNo">Mobile Number/Email</label>
                        </div>


                        <div class="text-center">
                            <asp:LinkButton ID="LnkLogin" OnClick="LnkLogin_Click" CssClass="btn btn-primary mt-3 w-100" runat="server">Send OTP</asp:LinkButton>
                        </div>



                    </div>


                </div>
            </div>
        </section>
    </asp:Panel>
    <!-----Otp enter ---->


      <asp:Panel ID="PanelEnterotp" runat="server">
      <section class="wrapper" style="margin-top: 120px">

          <div class="container">

              <div class="col-sm-8 offset-sm-2 col-lg-6 offset-lg-3 col-xl-4 offset-xl-4 text-center">

                  <div class="rounded bg-white shadow p-5">
                      <h5>Login As Seller to
                          <br />
                          <span style="color: deeppink; font-family: cursive; font-weight: 600">Art</span><span style="color: forestgreen; font-family: cursive; font-weight: 600">-Candervilla</span></h5>
                      <span class="text-dark text-muted mb-5 fw-bold" style="cursor: auto">New Here? </span>
                      <asp:LinkButton class="text-primary fw-bold text-decoration-none" OnClick="LnkShowsignup_Click" Style="cursor: pointer" ID="LinkButton1" runat="server">Sign-Up</asp:LinkButton>
                      <div class="form-floating mb-3 mt-4">
                          <asp:TextBox ID="TxtEnterOtp" class="form-control shadow fw-bold" placeholder="Mobile Number" Style="border-color: #f1ecec; box-shadow: 0px 0px 0px hotpink" runat="server"></asp:TextBox>
                          <label for="TxtEnterOtp">Enter OTP</label>
                      </div>


                      <div class="text-center">
                          <asp:LinkButton ID="lnkEnterOtp" OnClick="lnkEnterOtp_Click" CssClass="btn btn-primary mt-3 w-100" runat="server">Enter OTP</asp:LinkButton>
                      </div>



                  </div>


              </div>
          </div>
      </section>
  </asp:Panel>



    <asp:Panel ID="PanelSellerSignup" runat="server">
        <section class="wrapper" style="margin-top: 120px">
            <div class="container">

                <div class="col-sm-8 offset-sm-2 col-lg-6 offset-lg-3 col-xl-4 offset-xl-4 text-center">

                    <div class="rounded bg-white shadow p-5">                       
                        <h5>Seller Sign-Up</h5>
                        <h5><span style="color: deeppink; font-family: cursive; font-weight: 600">Art</span><span style="color: forestgreen; font-family: cursive; font-weight: 600">-Candervilla</span></h5>
                        <div class="form-floating mb-3 mt-4">

                            <asp:TextBox ID="TxtsellerName" class="form-control shadow" required placeholder="Mobile Number" Style="border-color: #f1ecec; box-shadow: 0px 0px 0px hotpink" runat="server"></asp:TextBox>
                            <label for="TxtsellerName"> Warehouse/Brand/Shop Name</label>
                        </div>
                        <div class="form-floating mb-3 mt-4">

                            <asp:TextBox ID="Txtmobile" class="form-control shadow" required TextMode="Phone" MaxLength="10" placeholder="Mobile Number" Style="border-color: #f1ecec; box-shadow: 0px 0px 0px hotpink" runat="server"></asp:TextBox>
                            <label for="Txtmobile">Seller's Mobile No</label>
                        </div>
                        <div class="form-floating mb-1 mt-4">

                            <asp:TextBox ID="TxtEmailAddress" class="form-control shadow" required TextMode="Email" placeholder="Mobile Number" Style="border-color: #f1ecec; box-shadow: 0px 0px 0px hotpink" runat="server"></asp:TextBox>
                            <label for="TxtEmailAddress">Seller's E-Mail Address</label>
                        </div>
                        <asp:Label ID="LblVerifyEmail" runat="server" Visible="false"  ForeColor="Green" style="font-weight:300;font-family:cursive;font-size:small" Text="Verified"></asp:Label>
                        <div class="text-center">
                            <asp:LinkButton ID="LnkveifySelleremail" OnClick="LnkveifySelleremail_Click" CssClass="btn btn-primary mt-3 w-100" runat="server">Verify Email</asp:LinkButton>
                        </div>
                        <asp:Panel ID="PanelSellerEmailVeriry" runat="server">
                            <div class="form-floating mb-3 mt-4">

                                <asp:TextBox ID="TxtVerifyOtpSeller" class="form-control shadow" required TextMode="Email" placeholder="Mobile Number" Style="border-color: #f1ecec; box-shadow: 0px 0px 0px hotpink" runat="server"></asp:TextBox>
                                <label for="TxtVerifyOtpSeller">Enter OTP</label>
                            </div>
                            <div class="text-center">
                                <asp:LinkButton ID="LnkOtpVerifySellerEmail" OnClick="LnkOtpVerifySellerEmail_Click" CssClass="btn btn-primary mt-3 w-100" runat="server">Verify</asp:LinkButton>
                            </div>
                            <div class="text-center">
                                <asp:LinkButton ID="LnkReEnterEmail" OnClick="LnkReEnterEmail_Click" CssClass="btn btn-primary mt-3 w-100" runat="server">Change in E-Mail</asp:LinkButton>
                            </div>
                        </asp:Panel>

                        <asp:Panel ID="PanelAfterEmailVerify"  runat="server">
                            <div class="form-floating mb-3 mt-4">
                                <asp:TextBox ID="Txtupino" class="form-control shadow fw-bold" required placeholder="Mobile Number" TextMode="Phone" MaxLength="10" Style="border-color: #f1ecec; box-shadow: 0px 0px 0px hotpink" runat="server"></asp:TextBox>
                                <label for="Txtupino">UPI Number To Receive Payment</label>
                                <a style="cursor:pointer;color:blue" onclick="insertupi();">Same as Contact</a>
                            </div>
                            <div class="form-floating mb-3 mt-4">
                                <asp:TextBox ID="TxtGstNo" class="form-control shadow fw-bold" required placeholder="Mobile Number" Style="border-color: #f1ecec; box-shadow: 0px 0px 0px hotpink" runat="server"></asp:TextBox>
                                <label for="TxtGstNo">GST Number(Optional)</label>
                            </div>
                            <div class="form-floating mb-3 mt-4">
                                <asp:TextBox ID="TxtAdharno" class="form-control shadow fw-bold" required placeholder="Mobile Number" Style="border-color: #f1ecec; box-shadow: 0px 0px 0px hotpink" runat="server"></asp:TextBox>
                                <label for="TxtGstNo">Adhar Number</label>
                            </div>
                            <div class="form-floating mb-3 mt-4">
                                <asp:TextBox ID="Txtpancardno" class="form-control shadow fw-bold" required placeholder="Mobile Number" Style="border-color: #f1ecec; box-shadow: 0px 0px 0px hotpink" runat="server"></asp:TextBox>
                                <label for="TxtGstNo">PanCard Number</label>
                            </div>
                            <asp:Label ID="lblAdharcard" runat="server" ForeColor="Gray" Font-Bold="true" Text="Adhar Card"></asp:Label>
                            <div class="form-floating mb-3">
                                <asp:FileUpload ID="fileadhar" onchange="Validate()" class="form-control shadow" Style="border-color: white;" runat="server" />
                            </div>
                            <p id="size"></p>
                            <asp:Label ID="lblPancard" runat="server" ForeColor="Gray" Font-Bold="true" Text="Pan Card"></asp:Label>
                            <div class="form-floating mb-3">
                                <asp:FileUpload ID="filepancard" onchange="ValidatePancard();" class="form-control shadow" Style="border-color: white;" runat="server" />
                            </div>
                            <p id="sizepan"></p>

                             <h6>Full Address of Warehouse/shop with Pincode</h6>
                            <div class="form-floating mb-3">
                               
                                <asp:TextBox ID="fullAdress" TextMode="MultiLine" CssClass="form-control" Rows="8" style="resize:none" placeholder="Enter Complete Address With Pincode" runat="server"></asp:TextBox>
                            </div>

                            <div class="form-check d-flex">
                                <asp:CheckBox ID="ChkTermandConditions" Style="border: none" class="form-check-input" runat="server" />
                                <span style="font-weight: bold; color: grey; margin-top: 5px">I Agree With </span><a data-bs-toggle="modal" data-bs-target="#modaltermaandconditionseller" style="font-weight: bold; margin-top: 5px; margin-left: 3px; color: #1129b6; cursor: pointer">Term & Conditions</a>
                            </div>

                            <div class="text-center">
                                <asp:LinkButton ID="LnkSignup" OnClick="LnkSignup_Click" CssClass="btn btn-primary mt-3 w-100" runat="server">Sign-up</asp:LinkButton>
                                <asp:Label ID="LblCustomeerror" Visible="false" ForeColor="Red" runat="server" Text="Label"></asp:Label>
                            </div>
                            <div class="text-center fw-bold" style="color: gray">

                                <asp:LinkButton ID="LnkgoLogin" OnClick="LnkgoLogin_Click" class="text-primary fw-bold text-decoration-none" Style="cursor: pointer" runat="server">go to Login</asp:LinkButton>

                            </div>
                        </asp:Panel>
                    </div>
                </div>


            </div>
            <!---Seller Term And condition--->
               <div class="modal fade" id="modaltermaandconditionseller" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
       <div class="modal-dialog modal-fullscreen">
           <div class="modal-content">
               <div class="modal-header">
                   <center>
                       <h6 class="modal-title text-bold" style="text-align: center; font-size: larger; font: bolder; text-decoration: none; color: black; cursor: pointer; font-style: italic; font-weight: 600;">Terms and Conditions for Sellers</h6>
                   </center>

                   <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
               </div>
               <div class="modal-body">
                   <p>Last updated: 05 July 2024</p>
                   <p>This Privacy Policy describes Our policies and procedures on the collection, use and disclosure of Your information when You use the Service and tells You about Your privacy rights and how the law protects You.</p>
                   <p>We use Your Personal data to provide and improve the Service. By using the Service, You agree to the collection and use of information in accordance with this Privacy Policy.</p>
                   <h5>Collecting and Using Your Personal Data</h5>
                   <h6>Types of Data Collected</h6>
                   <h6>Personal Data</h6>
                   <p>While using Our Service, We may ask You to provide Us with certain personally identifiable information that can be used to contact or identify You. Personally identifiable information may include, but is not limited to:</p>
                   <p>&#9679;&nbsp;Email address</p>
                   <p>&#9679;&nbsp;Name of Ware house</p>
                   <p>&#9679;&nbsp;Phone number</p>
                   <p>&#9679;&nbsp;Adhar Card</p>
                   <p>&#9679;&nbsp;PanCard</p>
                   <p>&#9679;&nbsp;Address, State, Province, ZIP/Postal code, City</p>
                   <p>&#9679;&nbsp;Usage Data</p>
                   <h6>Usage Data</h6>
                   <p>Usage Data is collected automatically when using the Service.</p>
                   <p>
                       Usage Data may include information such as Your Device's Internet Protocol address (e.g. IP address), browser type, browser version, the pages of our Service that You visit, the time and date of Your visit, 
                       the time spent on those pages, unique device identifiers and other diagnostic data.
                   </p>
                   <p>When You access the Service by or through a mobile device, We may collect certain information automatically, including, but not limited to, the type of mobile device You use, Your mobile device unique ID, the IP address of Your mobile device, Your mobile operating system, the type of mobile Internet browser You use, unique device identifiers and other diagnostic data.</p>
                   <p>We may also collect information that Your browser sends whenever You visit our Service or when You access the Service by or through a mobile device.</p>
                  <h6> Account Registration:</h6><br />
&#9679; &nbspSellers must provide accurate information during registration.<br />
&#9679; Only one account is allowed per seller.<br />
<h6>Compliance with Laws:</h6>

&#9679; Sellers must comply with all applicable Indian laws, including GST regulations, Consumer Protection Act, and other trade laws.<br />
<h6>Product Listing:</h6>

&#9679 Sellers must list products accurately, including price, description, and images.<br />
&#9679 Prohibited or restricted items, as per platform and government policies, cannot be listed.<br />
<h6>Pricing Policy:</h6>

&#9679 Sellers are responsible for setting product prices.<br />
&#9679 Prices must include applicable taxes and follow government pricing regulations.
<h6>Order Fulfillment:</h6>

&#9679Sellers must process and ship orders within specified timelines.<br />
&#9679Quality and condition of products must meet listing descriptions.<br />
<h6>Returns and Refunds:</h6>

&#9679 Sellers must comply with the platform's return and refund policies.<br />
&#9679 Faulty or misrepresented products are the seller’s responsibility to replace or refund.<br />
<h6>Commission and Fees:</h6>

&#9679 Platform fees, including commissions, payment gateway charges, and other applicable charges, will be deducted as per the agreed terms.<br />
<h6>Tax Obligations:</h6>

&#9679 Sellers are responsible for filing their GST returns and other tax obligations.<br />
&#9679 must be provided if applicable.<br />
<h6>Intellectual Property Rights:</h6>

&#9679 Sellers must ensure that listed products do not infringe on third-party intellectual property rights.<br />
<h6>Prohibited Activities:</h6>

&#9679 Misrepresentation of products or false advertising.<br />
&#9679 Engaging in fraudulent activities or manipulating platform systems.<br />
<h6>Customer Data Protection:</h6>

&#9679 Sellers must not misuse customer data obtained through the platform.<br />
<h6>Termination of Account:</h6>

&#9679The platform reserves the right to suspend or terminate a seller’s account for violations of terms or poor performance.<br />
                   <h6>Amendments:</h6>
                   &#9679 The platform reserves the right to amend these terms, and sellers will be notified of changes. Continued use implies acceptance.<br />
                   <h6>Contact Us</h6>
                   <p>
                       If you have any doughts about any thing written above, Feel free to contact us:
                   </p>
                   <p>
                       By email: artcandervilla@gmail.com
                   </p>                                             
               </div>
               <div class="modal-footer ms-0">
                   &copy Art-Candervilla
               </div>
           </div>
       </div>
   </div>
            <!---Seller Term And condition--->
        </section>
    </asp:Panel>

  <script type="text/javascript">
    function Validate() {
        var file = document.getElementById('<%=fileadhar.ClientID%>');        
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


      function ValidatePancard() {
          var file = document.getElementById('<%=filepancard.ClientID%>');
         var fileName = file.value;
         var ext = fileName.substring(fileName.lastIndexOf('.') + 1);
          var msg = document.getElementById("sizepan");
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


      function insertupi() {
          const contactmobile = document.getElementById('<%=Txtmobile.ClientID%>');
          var gstno = document.getElementById('<%=Txtupino.ClientID%>');

          gstno.value = contactmobile.value;
      }
  </script>
            <!---sweet alert---->
<script src="https://cdn.jsdelivr.net/npm/bootstrap-sweetalert@1.0.1/dist/sweetalert.min.js"></script>
</asp:Content>
