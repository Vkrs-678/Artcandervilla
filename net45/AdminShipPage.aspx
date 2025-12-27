<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="AdminShipPage.aspx.cs" Inherits="RazorpaySampleApp.WebForm24" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h4 class="text-center">Order To Ship</h4>
           <div class="container-fluid shadow" style="margin-top: 10px">
       <div class="row">          
           <div class="col">
               <table class="table table-hover">
                   <thead>
                       <tr>                           
                           <th>Order Id</th>
                           <th>Payment Id</th>
                           <th>Price</th>
                           <th>Order date</th>                        
                           <th>Images</th>                                        
                           <th>Action</th>                                                       
                       </tr>
                   </thead>
                   <tbody>
                       <asp:Repeater ID="RptrProducts" runat="server">

                           <ItemTemplate>
                         
                              
                               <tr>                                                                                                             
                                    <td><%#Eval("orderid") %></td>                                
                                    <td><%#Eval("Paymentid") %></td>                                
                                    <td><%#(Convert.ToInt32(Eval("buyPrice"))+Convert.ToInt32(Eval("deliveryprice"))).ToString() %></td>                                
                                    <td><%#Eval("dates") %></td>                                                                                                                                   
                                   <td>
                                       <asp:Image ID="Image1" Height="100px" Width="100px" runat="server" ImageUrl='<%#Eval("productimage") %>' /></td>
                                   <td>
                                     <a href="ShippingPage.aspx?orderid=<%#Eval("orderid")+"&&productid="+Eval("productid")+"&&productrefid="+Eval("productrefid") %>" class="btn btn-dark">Fill Details</a>                                     
                                   </td>
                                   <td >
                                       
                                      
                                    
                                     
                                   </td>
                               </tr>
                           </ItemTemplate>
                       </asp:Repeater>

                   </tbody>
               </table>
               <!-- Button trigger modal -->
               <button type="button" id="showmodalbutton" style="display:none" class="btn btn-primary" data-bs-toggle="modal" data-bs-target="#showviewmodal">
                   Launch demo modal
               </button>
              
         
           </div>
       </div>
   </div>
</asp:Content>
