<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DeliverySuccess.aspx.cs" Inherits="RazorpaySampleApp.DeliverySuccess" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
      <meta name="viewport" content="width=device-width, initial-scale=1.0"/>
     <link rel="icon" type="image/x-icon" href="Images/Brand Logo/brandlogo.png"/>
   
</head>
<body>
    <form id="form1" runat="server">
        <div style="display:flex;justify-content:center;align-items:center;min-height:100vh">
           
            <div style="width:fit-content;height:fit-content;padding:10px;border:solid;border-color:black;border-radius:10px;text-align:center">
                <h3 style="color:orangered;font-family:Verdana"> <br /><span style="color:forestgreen;font-family:cursive">Art-</span><span style="color:deeppink;font-family:cursive">Candervilla</span></h3>
                 <img src="Images/Loader/success.gif" height="100" width="140" />
                <h4 style="color:gray;font-family:Verdana">Thank You</h4>                              
                <h2 style="color:gray;font-family:Verdana">Product has been Delivered !</h2>    
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
