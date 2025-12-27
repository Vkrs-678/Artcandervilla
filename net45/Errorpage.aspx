<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Errorpage.aspx.cs" Inherits="RazorpaySampleApp.Errorpage" %>

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
           
            <div style="width:fit-content;height:fit-content;padding:10px;border:solid;border-color:red;border-radius:10px;text-align:center">
                 <img src="Images/Loader/Error.gif" height="120" width="140" />
                <h1 style="color:red;font-family:Verdana">Some Error Has Occurred !</h1>
                <h3 style="color:red;font-family:Verdana">Don't Worry We Will Fix it Soon ! <br /><span style="color:forestgreen;font-family:cursive">Art-</span><span style="color:deeppink;font-family:cursive">Candervilla</span></h3>
              
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
