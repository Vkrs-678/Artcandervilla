<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="SellerDashbord.aspx.cs" Inherits="RazorpaySampleApp.WebForm6" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel ID="Panelone" CssClass="d-none d-sm-none d-md-none d-lg-block"  runat="server">
        <div class="container-fluid mt-3">
            <div class="row">
            <div class="col-2">
               
                   
                    <br />
            
                <div class="text-center" style="margin-top: 90px">
                    <span class="text-dark text-muted mb-5 fw-bold" style="cursor: auto">HELLO PARTNER <i class="fa-regular fa-face-smile fa-bounce" style="color: #FFD43B;"></i></span>
                    <br />
                    <asp:Label ID="Label3" class="text-dark text-muted mb-5 fw-bold" runat="server" Text="AMAN"></asp:Label>
                    <br />
                    <asp:Label ID="Label4" ForeColor="White" class="mb-1 fw-bold badge bg-dark" Style="cursor: pointer; text-decoration-color: white" runat="server" Text="Active"></asp:Label>
                    <hr />
                    <asp:Label ID="Label5" class="text-dark text-muted mb-5 fw-bold" runat="server" Text="Vinod894@gmail.com"></asp:Label>
                   <br />
                    <asp:Label ID="Label6" class="text-dark text-muted mb-5 fw-bold" runat="server" Text="99999999"></asp:Label>
                        <br />         
                     <asp:Label ID="Label7" class="text-dark text-muted mb-5 fw-bold" runat="server" Text="UPI No:-"></asp:Label>
                </div>
                    <div class="text-center">
                        <asp:LinkButton ID="LinkButton1" OnClick="LnkLogin_Click" CssClass="btn btn-dark mt-3 w-100" runat="server">Add Products</asp:LinkButton>
                    </div>
                    <div class="text-center">
                        <asp:LinkButton ID="LinkButton3" OnClick="LnkDeleteDeactivate_Click" CssClass="btn btn-dark mt-3 w-100" runat="server">View /Deactivation/Offer</asp:LinkButton>
                    </div>
                    <div class="text-center">
                        <asp:LinkButton ID="LinkButton4" OnClick="LinkButton2_Click" CssClass="btn btn-dark mt-3 w-100" runat="server">Quantity/Discount</asp:LinkButton>
                    </div>
                    <div class="text-center">
                        <asp:LinkButton ID="LinkButton5" OnClick="LinkDispatch_Click" CssClass="btn btn-dark mt-3 w-100" runat="server">DisPatch Product</asp:LinkButton>
                    </div>
                    <div class="text-center">
                        <asp:LinkButton ID="LinkButton6" OnClick="LnkprintShipmentLabel_Click" CssClass="btn btn-dark mt-3 w-100" runat="server">Shipment Label</asp:LinkButton>
                    </div>
                  <div class="text-center">
                    <asp:LinkButton ID="LinkButton7" OnClick="LnkPrintReport_Click" CssClass="btn btn-dark mt-3 w-100" runat="server">Print Report</asp:LinkButton>
                   </div>
              
             
            </div>
            <div class="col-9 " style="margin-top:100px">
                <h6>Annual Sales Chart</h6>
                <hr />
              
                        <asp:DropDownList ID="Barchartyear" OnTextChanged="Barchartyear_TextChanged" AutoPostBack="true" runat="server">
                            <asp:ListItem Value="2024" Text="2024"></asp:ListItem>
                            <asp:ListItem Value="2025" Text="2025"></asp:ListItem>
                            <asp:ListItem Value="2026" Text="2026"></asp:ListItem>
                            <asp:ListItem Value="2027" Text="2027"></asp:ListItem>
                        </asp:DropDownList>
                         <canvas class="w-100 h-75 ms-5" id="myChart"></canvas>
             
            </div>
                </div>
            <hr />
            <div class="row ">
                <div class="col-5 border">
                    <h6 class="text-center">Sale Analysis(Quantity Wise)</h6>
                    <hr>
                    <asp:HiddenField ID="Doughnutvalue" runat="server" />
                    <asp:HiddenField ID="pievalue" runat="server" />
                    <canvas  id="chartId" aria-label="chart" height="350" width="580"></canvas>
                </div>
                <div class="col-2">

                </div>
                <div class="col-5 border">
                    <h6 class="text-center">Sale Vs Return(Rs)</h6>
                    <hr>
                 <canvas  id="chartSale" aria-label="charts" height="350" width="580"></canvas>
                </div>
              

            </div>
        </div>
    </asp:Panel>
    <asp:Panel ID="PanelLogin" CssClass="d-lg-none" runat="server">
        <section class="wrapper" style="margin-top: 120px">

            <div class="container-fluid">

                <div class="col-sm-8 offset-sm-2 col-lg-6 offset-lg-3 col-xl-4 offset-xl-4 text-center">

                    <div class="rounded bg-white shadow p-5">
                        <h5><span style="color: deeppink; font-family: cursive; font-weight: 600">Art</span><span style="color: forestgreen; font-family: cursive; font-weight: 600">-Candervilla</span></h5>
                        <span class="text-dark text-muted mb-5 fw-bold" style="cursor: auto">HELLO PARTNER <i class="fa-regular fa-face-smile fa-bounce" style="color: #FFD43B;"></i></span>
                        <br /><asp:Label ID="Label1" class="text-dark text-muted mb-5 fw-bold" runat="server" Text="AMAN"></asp:Label>
                        <br />
                        <asp:Label ID="Label2" ForeColor="White" class="mb-1 fw-bold badge bg-dark" style="cursor:pointer;text-decoration-color:white" runat="server" Text="Active"></asp:Label>
                        <hr />
                        <asp:Label ID="Label8" class="text-dark text-muted mb-5 fw-bold" runat="server" Text="Vinod894@gmail.com"></asp:Label>
                        <br />
                        <asp:Label ID="Label9" class="text-dark text-muted mb-5 fw-bold" runat="server" Text="99999999"></asp:Label>
                        <br />
                        <asp:Label ID="Label10" class="text-dark text-muted mb-5 fw-bold" runat="server" Text="UPI No:-"></asp:Label>
                        <div class="text-center">
                            <asp:LinkButton ID="LnkLogin" OnClick="LnkLogin_Click" CssClass="btn btn-dark mt-3 w-100" runat="server">Add Products</asp:LinkButton>
                        </div>
                        <div class="text-center">
                            <asp:LinkButton ID="LnkDeleteDeactivate" OnClick="LnkDeleteDeactivate_Click" CssClass="btn btn-dark mt-3 w-100" runat="server">View /Deactivation/Offer</asp:LinkButton>
                        </div>
                        <div class="text-center">
                            <asp:LinkButton ID="LinkButton2" OnClick="LinkButton2_Click" CssClass="btn btn-dark mt-3 w-100" runat="server">Quantity/Discount</asp:LinkButton>
                        </div>
                        <div class="text-center">
                            <asp:LinkButton ID="LinkDispatch" OnClick="LinkDispatch_Click"  CssClass="btn btn-dark mt-3 w-100" runat="server">DisPatch Product</asp:LinkButton>
                        </div>
                        <div class="text-center">
                            <asp:LinkButton ID="LnkprintShipmentLabel" OnClick="LnkprintShipmentLabel_Click" CssClass="btn btn-dark mt-3 w-100" runat="server">Shipment Label</asp:LinkButton>
                        </div>
                        <div class="text-center">
                            <asp:LinkButton ID="LnkPrintReport" OnClick="LnkPrintReport_Click" CssClass="btn btn-dark mt-3 w-100" runat="server">Print Report</asp:LinkButton>
                        </div>
                      
                    </div>


                </div>
            </div>
        </section>
    </asp:Panel>

    <script src="https://cdnjs.cloudflare.com/ajax/libs/Chart.js/3.1.1/chart.min.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/chart.js"></script>

   <%-- <script>
        function printchart(values) {
            const ctx = document.getElementById('myChart');

            new Chart(ctx, {
                type: 'bar',
                data: {
                    labels: ['Red', 'Blue', 'Yellow', 'Green', 'Purple', 'Orange'],
                    datasets: [{
                        label: '# of Votes',
                        data: [12, 19, 3, 5, 2, 3],
                        borderWidth: 1
                    }]
                },
                options: {
                    scales: {
                        y: {
                            beginAtZero: true
                        }
                    }
                }
            });
        }
        
    </script>--%>
   <script>
       const hdnvalue = document.getElementById('<%=Doughnutvalue.ClientID%>'); 
       const arrays = hdnvalue.value.split(',');
           const chrt = document.getElementById("chartId").getContext("2d");
           const chartId = new Chart(chrt, {
               type: 'doughnut',
               data: {
                   labels: ["TotalSale", "ActualSale", "Cancel", "Return"],
                   datasets: [{
                       label: "Qty",
                       data: [arrays[0],arrays[1], arrays[2], arrays[3]],
                       backgroundColor: ['yellow', 'aqua', 'pink', 'lightgreen'],
                       hoverOffset: 5
                   }],
               },
               options: {
                   responsive: false,
               },
           });

           <%---pie char---%>


       const hdnsalevsreturn = document.getElementById('<%=pievalue.ClientID%>');
       const salreturn = hdnsalevsreturn.value.split(','); 
       const chrts = document.getElementById("chartSale").getContext("2d");
       const chartSale = new Chart(chrts, {
           type: 'pie',
           data: {
               labels: ["TotalSale", "ReturnCost"],
               datasets: [{
                   label: "Rs",
                   data: [salreturn[0], salreturn[1]],
                   backgroundColor: ['lightgreen', 'red'],
                   hoverOffset: 5
               }],
           },
           options: {
               responsive: false,
           },
       });
      
   </script>
   
</asp:Content>
