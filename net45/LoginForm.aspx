<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="LoginForm.aspx.cs" Inherits="RazorpaySampleApp.WebForm2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap-sweetalert@1.0.1/dist/sweetalert.min.css">
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   
    <asp:Panel ID="PanelLogin" runat="server">
        <section class="wrapper" style="margin-top: 120px">
          
            <div class="container">
            
    
                <div class="col-sm-8 offset-sm-2 col-lg-6 offset-lg-3 col-xl-4 offset-xl-4 text-center">
          
                    <div class="rounded bg-white shadow p-5">
                       
                        <h5>Login to <span style="color: deeppink; font-family: cursive; font-weight: 600">Art</span><span style="color: forestgreen; font-family: cursive; font-weight: 600">-Candervilla</span></h5>
                        <span class="text-dark text-muted mb-5 fw-bold" style="cursor: auto">New Here? </span>
                        <asp:LinkButton class="text-primary fw-bold text-decoration-none" OnClick="LnkShowsignup_Click" style="cursor: pointer" ID="LnkShowsignup" runat="server">Sign-Up</asp:LinkButton>
                        <div class="form-floating mb-3 mt-4">
                            <asp:TextBox ID="TxtMobileNo" class="form-control shadow" TextMode="Phone" MaxLength="10" placeholder="Mobile Number" Style="border-color: #f1ecec; box-shadow: 0px 0px 0px hotpink" runat="server"></asp:TextBox>
                            <label for="TxtMobileNo">Mobile Number</label>
                        </div>
                        <div class="form-floating">
                            <asp:TextBox ID="Txtpassword" class="form-control shadow" TextMode="Password" placeholder="Password" Style="border-color: #f1ecec; box-shadow: 0px 0px 0px hotpink" BorderColor="Gray" runat="server"></asp:TextBox>

                            <label for="Txtpassword">Password</label>
                        </div>
                        <div class="form-check d-flex">
                            <asp:CheckBox ID="ChkRememberme" onchange="showpass();" Style="border: none" class="form-check-input mt-2" runat="server" />
                            <span style="font-weight: bold; color: grey; margin-top: 7px">Show Password</span>
                        </div>
                        <div class="text-center">
                            <asp:LinkButton ID="LnkLogin" OnClick="LnkLogin_Click" CssClass="btn btn-primary mt-3 w-100" runat="server">Login</asp:LinkButton>
                        </div>
                        <div class="text-center fw-bold" style="color: gray">
                            OR
                        </div>
                        <div class="text-center m-2 shadow" style="padding: 10px; background-color: #fcf5f5">
                            <asp:LinkButton ID="LnkLoginwithgoogle" OnClick="LnkLoginwithgoogle_Click" CssClass="text-decoration-none" Style="color: gray" runat="server"> <img src="Images/GoogleLogo/google.png" style="width:38px;height:40px;margin:2px" />Login With Google</asp:LinkButton>
                        </div>
                        <div>
                            <asp:LinkButton ID="Lnkforgotpassword" OnClick="Lnkforgotpassword_Click" CssClass="fw-bold text-primary" runat="server">Forgot Password ?</asp:LinkButton>
                        </div>

                    </div>


                </div>
            </div>
        </section>
    </asp:Panel>
    
    <asp:Panel ID="PanelSignup" runat="server">
        <section class="wrapper" style="margin-top: 120px">
            <div class="container">

                <div class="col-sm-8 offset-sm-2 col-lg-6 offset-lg-3 col-xl-4 offset-xl-4 text-center">

                    <div class="rounded bg-white shadow p-5">

                        <h5>Sign-Up With </h5><h5><span style="color: deeppink; font-family: cursive; font-weight: 600">Art</span><span style="color: forestgreen; font-family: cursive; font-weight: 600">-Candervilla</span></h5>
                        <div class="form-floating mb-3 mt-4">

                            <asp:TextBox ID="TxtUserName"  class="form-control shadow" placeholder="Mobile Number" Style="border-color: #f1ecec; box-shadow: 0px 0px 0px hotpink" runat="server"></asp:TextBox>
                            <label for="TxtUserName">Name</label>
                        </div>
                        <div class="form-floating mb-3 mt-4">

                            <asp:TextBox ID="TxtSignMobile" class="form-control shadow" TextMode="Phone" MaxLength="10" placeholder="Mobile Number" Style="border-color: #f1ecec; box-shadow: 0px 0px 0px hotpink" runat="server"></asp:TextBox>
                            <label for="TxtSignMobile">Mobile Number</label>
                        </div>
                     
                        <div class="form-floating mb-3 mt-4">                             
                            <asp:TextBox ID="TxtsignEmail" class="form-control shadow" TextMode="Email" placeholder="Mobile Number" Style="border-color: #f1ecec; box-shadow: 0px 0px 0px hotpink" runat="server"></asp:TextBox>
                            <label for="TxtsignEmail">Email Address</label>
                            <asp:Label ID="msgverifyemail" runat="server" Font-Bold="true" ForeColor="Green">Verified</asp:Label>
                        </div>
                        <asp:LinkButton ID="btnsendopt" OnClick="btnsendopt_Click" CssClass="btn btn-primary" runat="server">Verify Email</asp:LinkButton>
                        <asp:Panel ID="panelverifyemail" runat="server">
                            <div class="form-floating mb-3 mt-4">
                                <asp:TextBox ID="Txtenterotpforverification" class="form-control shadow"  placeholder="Password" Style="border-color: #f1ecec; box-shadow: 0px 0px 0px hotpink" BorderColor="Gray" runat="server"></asp:TextBox>

                                <label for="TxtsignPassword">Enter Otp</label>
                            </div>
                            <asp:LinkButton ID="BtnverifyEmail" OnClick="BtnverifyEmail_Click" CssClass="btn btn-primary" runat="server">Verify</asp:LinkButton>
                        </asp:Panel>
                        <asp:Panel ID="panelofemailconfirmation" runat="server">
                        <div class="form-floating mb-3 mt-4">
                            <asp:TextBox ID="TxtsignPassword" class="form-control shadow" TextMode="Password" placeholder="Password" Style="border-color: #f1ecec; box-shadow: 0px 0px 0px hotpink" BorderColor="Gray" runat="server"></asp:TextBox>

                            <label for="TxtsignPassword">Password</label>
                        </div>
                        <div class="form-floating mb-3 mt-4">
                            <asp:TextBox ID="TxtconfirmPassword" onkeyup="check()" class="form-control shadow" TextMode="Password" placeholder="Password" Style="border-color: #f1ecec; box-shadow: 0px 0px 0px hotpink" BorderColor="Gray" runat="server"></asp:TextBox>

                            <label for="TxtconfirmPassword">Confirm Password</label>
                        </div>
                        <label id="passwordcheck" style="color:red;font-weight:600;"></label>
                        
                        
                        <div class="text-center">
                            <asp:LinkButton ID="LnkSignup" OnClick="LnkSignup_Click" CssClass="btn btn-primary mt-3 w-100" runat="server">Sign-up</asp:LinkButton>
                        </div>
                        <div class="text-center fw-bold" style="color: gray">
                            OR
                        </div>
                       
                        <asp:LinkButton ID="LnkgoLogin" OnClick="LnkgoLogin_Click" class="text-primary fw-bold text-decoration-none" style="cursor: pointer" runat="server">go to Login</asp:LinkButton>
                 </asp:Panel>
                        <div class="form-check d-flex">
                            <asp:CheckBox ID="ChkTermandConditions" Style="border: none" class="form-check-input" runat="server" />
                            <span data-bs-toggle="modal" data-bs-target="#modalTemcon" style="font-weight: bold; color: grey; margin-top: 5px">I Agree With<span style="font-weight: bold; margin-top: 5px; margin-left: 3px; color: #1129b6; cursor: pointer">Term & Conditions</span> </span>
                        </div>
                        <div class="text-center m-2 shadow" style="padding: 10px; background-color: #fcf5f5">
                            <asp:LinkButton ID="LnkGoogleSignup" OnClick="LnkGoogleSignup_Click" CssClass="text-decoration-none" Style="color: gray" runat="server"> <img src="Images/GoogleLogo/google.png" style="width:38px;height:40px;margin:2px" />Signup With Google</asp:LinkButton>
                        </div>
                    </div>


                </div>
            </div>
        </section>
    </asp:Panel>

      <!-- Modal-RefundPolicy -->
  <div class="modal fade" id="modalTemcon" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
      <div class="modal-dialog modal-fullscreen">
          <div class="modal-content">
              <div class="modal-header">
                  <h6 class="modal-title text-bold" style="text-align: center; font-size: larger; font: bolder; text-decoration: none; color: black; cursor: pointer; font-style: italic; font-weight: 600;">Terms & Conditions</h6>
                  <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
              </div>
              <div class="modal-body">
             <p>
                 These terms and conditions outline the rules and regulations for the use of art-candervilla Website, located at art-candervilla Website.

                    By accessing this website we assume you accept these terms and conditions. Do not continue to use art-candervilla if you do not agree to take all of the terms and conditions stated on this page.

                    The following terminology applies to these Terms and Conditions, Privacy Statement and Disclaimer Notice and all Agreements: "Client", "You" and "Your" refers to you, the person log on this website and compliant to the Company’s terms and conditions. "The Company", "Ourselves", "We", "Our" and "Us", refers to our Company. "Party", "Parties", or "Us", refers to both the Client and ourselves. All terms refer to the offer, acceptance and consideration of payment necessary to undertake the process of our assistance to the Client in the most appropriate manner for the express purpose of meeting the Client’s needs in respect of provision of the Company’s stated services, in accordance with and subject to, prevailing law of Netherlands. Any use of the above terminology or other words in the singular, plural, capitalization and/or he/she or they, are taken as interchangeable and therefore as referring to same.

             </p>
                  <h6>Cookies</h6>
                  <p>
                      We employ the use of cookies. By accessing art-candervilla Website, you agreed to use cookies in agreement with the art-candervilla's Privacy Policy.

              Most interactive websites use cookies to let us retrieve the user’s details for each visit. Cookies are used by our website to enable the functionality of certain areas to make it easier for people visiting our website. Some of our affiliate/advertising partners may also use cookies.

                  </p>
                  <h6>License</h6>
                  <p>Unless otherwise stated, art-candervilla and/or its licensors own the intellectual property rights for all material on art-candervilla. All intellectual property rights are reserved. You may access this from art-candervilla for your own personal use subjected to restrictions set in these terms and conditions.</p>
                  <p>You must not:</p>
                  <p>&#9679;&nbsp;Republish material from art-candervilla</p>
                  <p>&#9679;&nbsp;Sell, rent or sub-license material from art-candervilla</p>
                  <p>&#9679;&nbsp;Reproduce, duplicate or copy material from art-candervilla</p>
                  <p>&#9679;&nbsp;Redistribute content from art-candervilla</p>

                  <h6>The following organizations may link to our Website without prior written approval:</h6>
                   <p>&#9679;&nbsp;Government agencies;</p>
                   <p>&#9679;&nbsp;Search engines;</p>
                   <p>&#9679;&nbsp;News organizations;</p>
                   <p>&#9679;&nbsp;Online directory distributors may link to our Website in the same manner as they hyperlink to the Websites of other listed businesses; and</p>
                   <p>&#9679;&nbsp;System wide Accredited Businesses except soliciting non-profit organizations, charity shopping malls, and charity fundraising groups which may not hyperlink to our Web site.</p>

                  <h6>Reservation of Rights</h6>
                  <p>We reserve the right to request that you remove all links or any particular link to our Website. You approve to immediately remove all links to our Website upon request. We also reserve the right to amen these terms and conditions and it’s linking policy at any time. By continuously linking to our Website, you agree to be bound to and follow these linking terms and conditions.</p>
                  <h6>Disclaimer</h6>
                  <p>To the maximum extent permitted by applicable law, we exclude all representations, warranties and conditions relating to our website and the use of this website. Nothing in this disclaimer will:</p>
                  <p>&#9679;&nbsp;limit or exclude our or your liability for death or personal injury;</p>
                  <p>&#9679;&nbsp;limit or exclude our or your liability for fraud or fraudulent misrepresentation;</p>
                  <p>&#9679;&nbsp;limit any of our or your liabilities in any way that is not permitted under applicable law; or</p>
                  <p>&#9679;&nbsp;exclude any of our or your liabilities that may not be excluded under applicable law.</p>
                  <p>The limitations and prohibitions of liability set in this Section and elsewhere in this disclaimer:</p>
                   <p>&#9679;&nbsp;are subject to the preceding paragraph; and;</p>
                   <p>&#9679;&nbsp;govern all liabilities arising under the disclaimer, including liabilities arising in contract, in tort and for breach of statutory duty.</p>
                  <p>As long as the website and the information and services on the website are provided free of charge, we will not be liable for any loss or damage of any nature.</p>
              </div>
              <div class="modal-footer ms-0">
                  &copy Art-Candervilla
              </div>
          </div>
      </div>
  </div>
  <!-- Modal-RefundPolicy -->


    <asp:Panel ID="Panelforgotpassword" runat="server">
    <section class="wrapper" style="margin-top: 120px">
        <div class="container">

            <div class="col-sm-8 offset-sm-2 col-lg-6 offset-lg-3 col-xl-4 offset-xl-4 text-center">

                <div class="rounded bg-white shadow p-5">
                    <h5><span style="color: deeppink; font-family: cursive; font-weight: 600">Art</span><span style="color: forestgreen; font-family: cursive; font-weight: 600">-Candervilla</span></h5>
                    <span class="text-dark text-muted mb-5 fw-bold" style="cursor: auto">Forgot Password ? </span>
                   
                    <div class="form-floating mb-3 mt-4">
                        <asp:TextBox ID="Txtforgotemail" class="form-control shadow" TextMode="Email" placeholder="Mobile Number" Style="border-color: #f1ecec; box-shadow: 0px 0px 0px hotpink" runat="server"></asp:TextBox>
                        <label for="TxtMobileNo">E-mail Address</label>
                    </div>                
                    
                    <div class="text-center">
                        <asp:LinkButton ID="LnkSendOtp" OnClick="LnkSendOtp_Click"  CssClass="btn btn-primary mt-3 w-100" runat="server">Send OTP</asp:LinkButton>
                    </div>
                  
                 
                </div>


            </div>
        </div>
    </section>
</asp:Panel>

    <asp:Panel ID="PanelEnterOTp" runat="server">
        <section class="wrapper" style="margin-top: 120px">
            <div class="container">

                <div class="col-sm-8 offset-sm-2 col-lg-6 offset-lg-3 col-xl-4 offset-xl-4 text-center">

                    <div class="rounded bg-white shadow p-5">
                        <h5><span style="color: deeppink; font-family: cursive; font-weight: 600">Art</span><span style="color: forestgreen; font-family: cursive; font-weight: 600">-Candervilla</span></h5>


                        <div class="form-floating mb-3 mt-4">
                            <asp:TextBox ID="TxtEnterOtp" class="form-control shadow fw-bold" TextMode="Phone" MaxLength="10" placeholder="Mobile Number" Style="border-color: #f1ecec; box-shadow: 0px 0px 0px hotpink" runat="server"></asp:TextBox>
                            <label for="TxtMobileNo">Enter OTP</label>
                        </div>

                        <div class="text-center">
                            <asp:LinkButton ID="LnkEnterotp" OnClick="LnkEnterotp_Click" CssClass="btn btn-primary mt-3 w-100" runat="server">Enter OTP</asp:LinkButton>
                        </div>


                    </div>


                </div>
            </div>
        </section>
    </asp:Panel>

     <asp:Panel ID="PanelNewpassword" runat="server">
     <section class="wrapper" style="margin-top: 120px">
         <div class="container">

             <div class="col-sm-8 offset-sm-2 col-lg-6 offset-lg-3 col-xl-4 offset-xl-4 text-center">

                 <div class="rounded bg-white shadow p-5">
                     <h5><span style="color: deeppink; font-family: cursive; font-weight: 600">Art</span><span style="color: forestgreen; font-family: cursive; font-weight: 600">-Candervilla</span></h5>


                     <div class="form-floating mb-3 mt-4">
                         <asp:TextBox ID="TxtNewpassword" class="form-control shadow" TextMode="Password" placeholder="Mobile Number" Style="border-color: #f1ecec; box-shadow: 0px 0px 0px hotpink" runat="server"></asp:TextBox>
                         <label for="TxtNewpassword">New Password</label>
                     </div>
                     <div class="form-floating mb-3 mt-4">
                         <asp:TextBox ID="TxtconfNewpassword" onkeyup="checks()" class="form-control shadow" TextMode="Password" placeholder="Mobile Number" Style="border-color: #f1ecec; box-shadow: 0px 0px 0px hotpink" runat="server"></asp:TextBox>
                         <label for="TxtconfNewpassword">Confirm New Password</label>
                     </div>
                      <label id="passwordchecks" style="color:red;font-weight:600;"></label>
                     <div class="text-center">
                         <asp:LinkButton ID="LnkChangepassword" OnClick="LnkChangepassword_Click" CssClass="btn btn-primary mt-3 w-100" runat="server">Change Password</asp:LinkButton>
                     </div>


                 </div>

                
             </div>
         </div>
     </section>
 </asp:Panel>
   
    <script src="https://cdn.jsdelivr.net/npm/bootstrap-sweetalert@1.0.1/dist/sweetalert.min.js"></script>
  <script type="text/javascript">
      function hello() {
         
          swal('Already', 'Already Exist', 'info')
      }

    

      function check() {
          
          if (document.getElementById('<%=TxtsignPassword.ClientID%>').value ==
              document.getElementById('<%=TxtconfirmPassword.ClientID%>').value) {
              document.getElementById('passwordcheck').style.color = 'green';
              document.getElementById('passwordcheck').innerHTML = 'confirm Password is matching';
          } else {
              document.getElementById('passwordcheck').style.color = 'red';
              document.getElementById('passwordcheck').innerHTML = 'Confirm not matching';
          }

          if (document.getElementById('<%=TxtconfirmPassword.ClientID%>').value == '') {
              document.getElementById('passwordcheck').style.display = 'none';
          }
      }

      function checks() {

          if (document.getElementById('<%=TxtNewpassword.ClientID%>').value ==
              document.getElementById('<%=TxtconfNewpassword.ClientID%>').value) {
              document.getElementById('passwordchecks').style.color = 'green';
              document.getElementById('passwordchecks').innerHTML = 'Password Matched';
          } else {
              document.getElementById('passwordchecks').style.color = 'red';
              document.getElementById('passwordchecks').innerHTML = 'Password is Not Matching';
          }

          if (document.getElementById('<%=TxtconfirmPassword.ClientID%>').value == '') {
              document.getElementById('passwordchecks').style.display = 'none';
          }
        }
         
      
      function showpass(ev) {
         
          if (document.getElementById('<%=ChkRememberme.ClientID%>').checked == true) {
              
              document.getElementById('<%=Txtpassword.ClientID%>').type = 'text';
              
          }
          else {
              document.getElementById('<%=Txtpassword.ClientID%>').type = 'password';
          }
      }

     
    
  </script>
        <!---sweet alert---->

</asp:Content>
