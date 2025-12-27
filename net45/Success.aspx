<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Success.aspx.cs" Inherits="RazorpaySampleApp.Success" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
      <meta name="viewport" content="width=device-width, initial-scale=1.0"/>
     <link rel="icon" type="image/x-icon" href="Images/Brand Logo/brandlogo.png"/>
</head>
<body>
    <form id="form1" runat="server">
        <div style="text-align:center">
            <%-- <h3 style="color:red">Disclaimer : This Website is in  Tesing Phase Now, No Product Will be Deliver.Although You Can Just Experience The Full Funcitonalities.</h3>--%>
        </div>
        <div style="display:flex;justify-content:center;align-items:center;min-height:100vh">
           
            <div style="width:fit-content;height:fit-content;padding:10px;border:solid;border-color:orangered;border-radius:10px;text-align:center">
                 <img src="Images/Loader/success.gif" height="100" width="140" />
                <h1 style="color:orangered;font-family:Verdana">Your Order Has Been Booked !</h1>
                <h3 style="color:orangered;font-family:Verdana">Thank you for Shopping With <br /><span style="color:forestgreen;font-family:cursive">Art-</span><span style="color:deeppink;font-family:cursive">Candervilla</span></h3>
                <asp:Label ID="lblorderid" style="color:orangered;font-family:Verdana" runat="server" Text="Order NO. : 244534334"></asp:Label><br />
                <asp:Label ID="lblpaymentid" style="color:orangered;font-family:Verdana" runat="server" Text="PaymentId : fdjdk73847JEH"></asp:Label><br />
                <asp:LinkButton ID="LinkButton1" OnClick="LinkButton1_Click" runat="server">Continue Shopping</asp:LinkButton>
            </div>
        </div>
      
     
    </form>
    <script>
        window.history.pushState(null, "", window.location.href);
        window.onpopstate = function () {
            window.history.pushState(null, "", window.location.href);
        };
    </script>
</body>

</html>
