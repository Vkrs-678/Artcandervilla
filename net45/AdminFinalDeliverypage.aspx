<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="AdminFinalDeliverypage.aspx.cs" Inherits="RazorpaySampleApp.WebForm28" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
       <div class="container-fluid shadow" style="margin-top: 130px">
        <h4 class="text-center">Update Status</h4>
    <div class="row">
      <div class="col-12 d-flex">
          <asp:TextBox ID="Txtorderidforsearch" CssClass="form-control w-60" placeholder="Enter the Order No From Ithink Logistics" runat="server"></asp:TextBox>
          <asp:LinkButton ID="BtnSearch" OnClick="BtnSearch_Click" CssClass="btn btn-outline-success" runat="server">Search</asp:LinkButton><br />
      </div>
  </div>
  <div class="row">
      <div class="col">
          <table class="table table-hover">
              <thead>
                  <tr>
                      <th>Product Id</th>                                   
                      <th>Reference Id</th>                                   
                      <th>Order Id</th>                                   
                      <th>Price</th>
                      <th>Dispatch date</th>
                      <th>Shipping date</th>
                      <th>Pickup date</th>
                      <th>Images</th>
                      <th>Action</th>
                  </tr>
              </thead>
            
              <tbody>
                  <asp:Repeater ID="RptrProducts" runat="server">

                      <ItemTemplate>


                          <tr>
                              <td><%#Eval("productid") %></td>                                           
                              <td><%#Eval("productrefid") %></td>                                           
                              <td><%#Eval("orderid") %></td>                                           
                              <td><%#(Convert.ToInt32(Eval("buyPrice"))+Convert.ToInt32(Eval("deliveryprice"))).ToString() %></td> 
                               <td><%#Convert.ToDateTime(Eval("dispatched_date")).ToString("dd/MM/yyyy") %></td> 
                               <td><%#Convert.ToDateTime(Eval("deliverydate")).ToString("dd/MM/yyyy") %></td> 
                               <td><%#Convert.ToDateTime(Eval("pickup")).ToString("dd/MM/yyyy") %></td> 
                              <td>
                                  <asp:Image ID="Image1" Height="100px" Width="100px" runat="server" ImageUrl='<%#Eval("productimage") %>' /></td>
                              <td class="d-flex">
                                  <asp:HiddenField ID="HdnOrderid" Value='<%#Eval("orderid") %>' runat="server" />
                                  <asp:HiddenField ID="HdnProductid" Value='<%#Eval("productid") %>' runat="server" />
                                  <asp:HiddenField ID="HdnProductrefid" Value='<%#Eval("productrefid") %>' runat="server" />
                                  <asp:HiddenField ID="Hdnusername" Value='<%#Eval("Nameofthecustomer") %>' runat="server" />
                                  <asp:HiddenField ID="Hdnuseremail" Value='<%#Eval("email") %>' runat="server" />
                                  <asp:HiddenField ID="Hdntotalprice" Value='<%#Eval("totalprice") %>' runat="server" />
                                  <asp:HiddenField ID="HdnPaymentMode" Value='<%#Eval("paymentMode") %>' runat="server" />
                                  <asp:HiddenField ID="Hdnproductname" Value='<%#Eval("productdetail") %>' runat="server" />
                                  <asp:HiddenField ID="Hdnproductimage" Value='<%#Eval("productimage") %>' runat="server" />
                                  <asp:HiddenField ID="HdnSellerEmail" Value='<%#Eval("Email") %>' runat="server" />
                                 <asp:LinkButton ID="btnDelivered" OnClick="btnDelivered_Click" runat="server"  CssClass="btn btn-success">Delivered</asp:LinkButton>&nbsp;
                                 <asp:LinkButton ID="btnRefused" OnClientClick="return AreYouSure(this)" runat="server" OnClick="btnRefused_Click"  CssClass="btn btn-danger">Refused</asp:LinkButton>
                              </td>
                              <td></td>
                          </tr>
                      </ItemTemplate>
                  </asp:Repeater>

              </tbody>
          </table>
            <asp:Label ID="dfd" runat="server"></asp:Label>
          <!-- Button trigger modal -->
          <button type="button" id="showmodalbutton" style="display: none" class="btn btn-primary" data-bs-toggle="modal" data-bs-target="#showviewmodal">
              Launch demo modal
          </button>


      </div>
  </div>

   </div>
    <script>
        var obj = { status: false, ele: null };
        function AreYouSure(ev) {
            if (obj.status) {
                return true;
            };
            swal({
                title: "Are you sure?",
                text: "Are You Sure Want To update This As Refused ?",
                type: "warning",
                showCancelButton: true,
                confirmButtonClass: "btn-danger",
                confirmButtonText: "Yes, Remove it!",
                closeOnConfirm: true
            },
                function () {
                    obj.status = true;
                    obj.ele = ev;
                    obj.ele.click();
                });

            return false;
        }
    </script>
</asp:Content>
