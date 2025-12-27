<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Placeorder.aspx.cs" Inherits="RazorpaySampleApp.WebForm19" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
  <%--  <script src="https://code.jquery.com/jquery-3.7.1.min.js" integrity="sha256-/JqT3SQfawRcv/BIHPThkBvs0OEvtFFmqPF/lYI/Cxo=" crossorigin="anonymous"></script>--%>
    <script>
        function openModal() { $('#rzp-button1').trigger('click'); }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container" style="margin-top:100px">
        <div class="row justify-content-center">
            <asp:Label ID="lblwarning" ForeColor="red" CssClass="text-center" Font-Bold="true" runat="server"></asp:Label>
            <asp:Repeater ID="RepeaterImages" runat="server">
                <ItemTemplate>
                    <div class="col-6 col-sm-6 col-md-4 col-lg-3 col-xl-3 ">
                        <center>
                            <asp:Image ID="Image1" CssClass="img-fluid img-thumbnail" ImageUrl='<%#Eval("image")%>' Height="180px" Width="160px" runat="server" />
                        </center>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
            <asp:Panel ID="Panel1" Visible="false" runat="server">
                <div class="mb-4" style="display: flex; justify-content: space-between; align-items: end">
                    <asp:RadioButton ID="RdoCOD" onclick="checkcod();" GroupName="Paymode" Text="COD" Font-Bold="true" runat="server" />
                    <asp:RadioButton ID="RdoPayonline" GroupName="Paymode" Text="Pay Online" Font-Bold="true" runat="server" />
                </div>
            </asp:Panel>
            <div style="display: flex; justify-content: center; align-content: center">
                <asp:Label ID="lblpricesymbo" Font-Bold="true" Text="₹" runat="server"></asp:Label>&nbsp;
                <asp:Label ID="lblprice" Font-Bold="true"  Text="" runat="server"></asp:Label>
                <asp:Label ID="lblpricepipe" Font-Bold="true" Text="/-" runat="server"></asp:Label>
                <asp:Label ID="lbliscod" Style="display: none;" Font-Bold="true" Text="" runat="server"></asp:Label>
            </div>

            <asp:Repeater ID="Repeater1" runat="server">
                <ItemTemplate>
                     <asp:Button ID="btnplaceorder" Width="80%" OnClick="btnplaceorder_Click" CssClass="btn btn-warning" ForeColor="white" runat="server" Text="Place Order" />
                </ItemTemplate>
            </asp:Repeater>
           
              <button id="rzp-button1" style="display:none;" class="btn btn-warning">Place Order</button>

    </div>
    </div>
     <div action="Charge.aspx" method="post" name="razorpayForm">
     <input id="razorpay_payment_id" type="hidden" name="razorpay_payment_id" />
     &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<input id="razorpay_order_id" type="hidden" name="razorpay_order_id" />
     <input id="razorpay_signature" type="hidden" name="razorpay_signature" />
 </div>
  
 <div style="display: flex; justify-content: center; align-content: center">

     <div>
        <%-- <button id="rzp-button1">Pay with Razorpay</button>--%>
     </div>
 </div>

 <script src="https://checkout.razorpay.com/v1/checkout.js"></script>
 <script>
     var orderId = "<%=orderId%>";
     var description = "<%=description%>";
     var image = "<%=image%>";     
     var Name = "<%=username%>";
     var email = "<%=email%>";
     var mobile = "<%=number%>";
     var options = {         
         "name": "Art-Candervilla",
         "description": description,
         "order_id": orderId,
         "image": "Images/Brand Logo/brandlogo.png",
         "prefill": {
             "name": Name,
             "email": email,
             "contact": mobile,
         },
         "notes": {
             "address": "",
             "merchant_order_id": "",
         },
         "theme": {
             "color": "#ff006e"
         }
     }
     // Boolean whether to show image inside a white frame. (default: true)
     options.theme.image_padding = false;
     options.handler = function (response) {
         window.location.href = "Success.aspx?orderid=" + orderId + "&&paymentid=" + response.razorpay_payment_id +"";
         //document.getElementById('razorpay_payment_id').value = response.razorpay_payment_id;
         //document.getElementById('razorpay_order_id').value = orderId;
         //document.getElementById('razorpay_signature').value = response.razorpay_signature;
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
     rzp.on('payment.failed', function (response) {

         alert("OOps, Something went wron and Payment Failed");

     });
    
 </script>




    <script>
        function checkcod() {
            var iscod = document.getElementById('<%=lbliscod.ClientID%>');
            var Rdo = document.getElementById('<%=RdoCOD.ClientID%>');
            if (iscod.innerHTML!="COD") {
                Rdo.checked = false;
                swal('COD', 'COD is Not Available For This Product', 'info');
            }

        }
    </script>
</asp:Content>
