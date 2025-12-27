<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Slip.aspx.cs" Inherits="RazorpaySampleApp.WebForm21" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        
        function printDiv(divName) {
            var printContents = document.getElementById('cont').innerHTML;
            var originalContents = document.body.innerHTML;

            document.body.innerHTML = printContents;
            printContents.title = 'Hello'
            window.print();
           
            document.body.innerHTML = originalContents;
           

        }

       
    </script>
   

    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   
 
    <asp:Panel ID="Panel1" runat="server">
       
        <div class="container-fluid" id="cont">
    <div class="row">      
        <div style="margin-top: 40px;text-align:center;">
            <h1 style='font-family: cursive; color: green; background-color: white; padding: 20px; margin-top: 30px; margin-bottom: 30px'>Art<span style='font-family: cursive; color: deeppink; background-color: white;'>-Candervilla</span></h1>
        </div>
        <div class="col-8">
            <div style="text-align: left; display: inline-flex">
                <asp:Label ID="Label2" Font-Size="Small" Font-Bold="true" runat="server" Text="Order Placed:-  "></asp:Label>&nbsp;           
        <asp:Label ID="LblOrderPlaceDate" Font-Size="Small" runat="server" Text="  12 May 2024"></asp:Label>
            </div><br />
            <div style="text-align: left; display: inline-flex">
                <asp:Label ID="Label3" Font-Size="Small" Font-Bold="true" runat="server" Text="Order Id:-  "></asp:Label>&nbsp;
        <asp:Label ID="LblOrderId" Font-Size="Small" runat="server" Text="ord_463dbb63-f685-4a28-9d32-f96f8748be7b"></asp:Label>
            </div><br />
            <div style="text-align: left; display: inline-flex">
                <asp:Label ID="Label5" Font-Size="Small" Font-Bold="true" runat="server" Text="Payment Id:-  "></asp:Label>&nbsp;
        <asp:Label ID="LblPaymentId" Font-Size="Small" runat="server" Text="pay_OUV268Qd28p1hB"></asp:Label>
            </div>
        </div>
        <div class="col-4">
            <div style="text-align:right!important; display: inline-flex">
                <asp:Label ID="Label15" Font-Size="Small" Font-Bold="true" runat="server" Text="Sold By:-  "></asp:Label>&nbsp;           
        <asp:Label ID="Lblheadsoldby" Font-Size="Small" runat="server" Text="Artcandervilla Store"></asp:Label>
            </div><br />
            <div style="text-align: right; display: inline-flex">
             
        <asp:Label ID="lblheadselleraddress" Font-Size="Small" runat="server" Text="Artcandervilla store New Delhi India 110043"></asp:Label>
            </div><br />
            <div style="text-align: right; display: inline-flex">
                <asp:Label ID="Label16" Font-Size="Small" Font-Bold="true" runat="server" Text="Pancard No:-  "></asp:Label>&nbsp;
        <asp:Label ID="lblsellerpan" Font-Size="Small" runat="server" Text="HZLPS5549K"></asp:Label>
            </div><br />
            <div style="text-align: right; display: inline-flex">
                <asp:Label ID="Label17" Font-Size="Small" Font-Bold="true" runat="server" Text="GST No:-  "></asp:Label>&nbsp;
                <asp:Label ID="lblsellergst" Font-Size="Small" runat="server" Text="798280723266"></asp:Label>
            </div>
        </div>
    
        <div style="height:2px;background-color:black;">

        </div>
        <div style="text-align:center">
            <asp:Label ID="LblDispatchedDate" Font-Bold="true" Font-Size="Small" runat="server" Text="Dispatched on 12/05/2024"></asp:Label>
        </div>
        <div style="text-align: left;" class="col-9">                
            <asp:Label ID="Label8" Font-Size="Small" Font-Bold="true" runat="server" Text="Item Ordered"></asp:Label>                                  
            <br />
            <asp:Label ID="LblProductDetail" Visible="false"  runat="server" Font-Size="X-Small" Text=" LINGO MEN'S SOLID SLIM FIT COTTON CASUAL SHIRT WITH SPREAD COLLAR & FULL SLEEVES (ALSO AVAILABLE IN PLUS SIZE)"></asp:Label>
              <asp:Label ID="Label4" Font-Size="X-Small" runat="server" Text="Price"></asp:Label><br />
              <asp:Label ID="Lblwarranty" Font-Size="X-Small" runat="server" Text=""></asp:Label>

        </div>
        <div style="text-align: right;" class="col-3">
            <asp:Label ID="Label11" Font-Bold="true" runat="server" Text="Price"></asp:Label>
            <br />
            <asp:Label ID="LblPrice" runat="server" Font-Size="Small" Text="299/-"></asp:Label>
        </div>
        <div style="text-align: left;">
            <asp:Label ID="LblSoldby" Font-Size="X-Small" runat="server" Text="Sold By : Appario Retail Private Ltd"></asp:Label><br />
        </div>
        <div style="text-align: left;margin-top:30px" class="col-4">
            <asp:Label ID="Label13" Font-Bold="true" Font-Size="Small" runat="server" Text="Shipping Address"></asp:Label>
            <br />
            <asp:Label ID="Lblperson" runat="server" Font-Size="Small" Text="Vikash Kumar Singh"></asp:Label><br />
            <asp:Label ID="LblfullAddress" runat="server" Font-Size="Small" Text="house no.1,Laxman singh Niwas"></asp:Label><br />
            <asp:Label ID="LblDistrict" runat="server" Font-Size="Small" Text="Arrah"></asp:Label><br />
             <asp:Label ID="LblCity" runat="server" Font-Size="Small" Text="Arrah,"></asp:Label>
             <asp:Label ID="LblState" runat="server" Font-Size="Small" Text="Bihar"></asp:Label>
             <asp:Label ID="Lblpincode" runat="server" Font-Size="Small" Text="802222"></asp:Label><br />
             
              <asp:Label ID="LblNearby" runat="server" Font-Size="Small" Text="Nearby : Shanti Medical Store"></asp:Label>
        </div>
        <div style="text-align: left; margin-top: 30px" class="col-4">
            <asp:Label ID="Label1" Font-Bold="true" Font-Size="Small" runat="server" Text="Billing Address"></asp:Label>
            <br />
            <asp:Label ID="Lblpersonbill" runat="server" Font-Size="Small" Text="Vikash Kumar Singh"></asp:Label><br />
            <asp:Label ID="LblfullAddressbill" runat="server" Font-Size="Small" Text="house no.1,Laxman singh Niwas"></asp:Label><br />
            <asp:Label ID="LblDistrictbill" runat="server" Font-Size="Small" Text="Arrah"></asp:Label><br />
            <asp:Label ID="LblCitybill" runat="server" Font-Size="Small" Text="Arrah,"></asp:Label>
            <asp:Label ID="LblStatebill" runat="server" Font-Size="Small" Text="Bihar"></asp:Label>
            <asp:Label ID="Lblpincodebill" runat="server" Font-Size="Small" Text="802222"></asp:Label><br />

            <asp:Label ID="LblNearbybill" runat="server" Font-Size="Small" Text="Nearby : Shanti Medical Store"></asp:Label>
        </div>
         <div style="text-align: right;margin-top:30px" class="col-4">
            <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
             
         </div>

        <div style="height: 2px; background-color: black; margin-top: 50px">
        </div>
        <div style="text-align: center">
            <asp:Label ID="Label20" Font-Bold="true" Font-Size="Larger" runat="server" Text="Payment Information"></asp:Label>
        </div>
        <div style="text-align: left; display: inline-flex">
            <asp:Label ID="Label21" Font-Size="Small" Font-Bold="true" runat="server" Text="Payment Mode:-  "></asp:Label>&nbsp;           
   <asp:Label ID="LblPaymentmode" Font-Size="Small" runat="server" Text="Online"></asp:Label>
        </div>

        <div style="text-align: left;" class="col-8">
            <asp:Label ID="Label23" Font-Size="Small" Font-Bold="true" runat="server" Text="Item Subtotal :"></asp:Label>
            <br />
            <asp:Label ID="Label24" Font-Size="Small" Font-Bold="true" runat="server" Text="Discount :"></asp:Label>
             <br />
             <asp:Label ID="Label26" Font-Size="Small" Font-Bold="true" runat="server" Text="Delivery Charge :"></asp:Label>
             <br />
            
            <hr />
             <asp:Label ID="Label27" Font-Size="Small" Font-Bold="true" runat="server" Text="Grand Total (With GST) :"></asp:Label>
        </div>
        <div style="text-align: right;" class="col-4">
            <asp:Label ID="Lblsubtotal" Font-Size="Small" runat="server" Text="299"></asp:Label>
            <br />
            <asp:Label ID="Lbldiscount" Font-Size="Small" runat="server" Text="30"></asp:Label>
            <br />
            <asp:Label ID="LblDeliveryCharge" Font-Size="Small" runat="server" Text="100"></asp:Label>
            <br />
            <hr />
             <asp:Label ID="LblGrandtotal" Font-Size="Small" runat="server" Text="279"></asp:Label>

        </div>
        <footer>
            <div style="text-align: center;margin-top:20px">
                <asp:Label ID="Label31" Font-Size="X-Small" runat="server" Text="This is a system generated invoice Doesn't Require any signature"></asp:Label><br />
                <asp:Label ID="Label32" Font-Size="X-Small" runat="server" Text="© Art-Candervilla"></asp:Label>
            </div>
        </footer>
       
    </div>
 
</div>
    </asp:Panel>
    
    <center class="mt-5">
         <a style="cursor:pointer;color:navy" onclick="printDiv('printMe')">Print</a>             
    

    </center>
 

</asp:Content>
