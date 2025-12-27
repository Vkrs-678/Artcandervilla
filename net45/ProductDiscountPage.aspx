<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="ProductDiscountPage.aspx.cs" Inherits="RazorpaySampleApp.WebForm12" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
   
     <script>
         $(document).ready(function () {
             $("#<%=DropdownMaincat.ClientID%>").select2();
         });
         $(document).ready(function () {
             $("#<%=DropdownSubcat.ClientID%>").select2();
         });
     </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container rounded shadow mb-3" style="margin-top:100px;background-color:#e8e4e4">
        <center><h1>Enter Your Discount</h1></center>
        <div class="row">
            <div class="col-6 col-md-4">
                <asp:RadioButton ID="RdoMaincatwise" onclick="offermaincat()" CssClass="fw-bold" GroupName="discount" Text=" Main Category Wise" runat="server" />
            </div>
            <div class="col-6 col-md-4">
                 <asp:RadioButton ID="RdoSubcatwise" onclick="offersubcat()" CssClass="fw-bold" GroupName="discount" Text=" Sub Category Wise" runat="server" />
            </div>
            <div class="col-6 col-md-4">
                 <asp:RadioButton ID="RdoProductRefwise" onclick="offerproduct()" CssClass="fw-bold" GroupName="discount" Text=" Product Wise" runat="server" />
            </div>
        </div>
        <div class="row">
            <asp:Panel ID="PanelMaincat"  style="text-align:center;display:none" runat="server">
                <div>
                    <asp:DropDownList ID="DropdownMaincat" Width="70%"  runat="server"></asp:DropDownList>
                   
                </div>
                <div>
                     <asp:TextBox ID="Txtmaincatdiscount" placeholder="Enter Maincat discount" CssClass="form-control" runat="server"></asp:TextBox>
                </div>
                <div class="mt-2">
                    <asp:LinkButton ID="LnkMaindiscount" OnClick="LnkMaindiscount_Click" CssClass="btn btn-dark" runat="server">Dicounted</asp:LinkButton>
                </div>
            </asp:Panel>
            <asp:Panel ID="PanelSubcat" Style="text-align: center;display:none" runat="server">
                <div>
                    <asp:DropDownList ID="DropdownSubcat" Width="70%" runat="server"></asp:DropDownList>
                   
                </div>
                <div>
                     <asp:TextBox ID="Txtsubcatdiscount" placeholder="Enter Subcategory discount" CssClass="form-control" runat="server"></asp:TextBox>
                </div>
                <div class="mt-2">
                    <asp:LinkButton ID="LnkSubDicount" OnClick="LnkSubDicount_Click" CssClass="btn btn-dark" runat="server">Dicounted</asp:LinkButton>
                </div>
            </asp:Panel>

            <asp:Panel ID="PanelProduct"  Style="text-align: center;display:none" runat="server">
                <div>
                    <asp:TextBox ID="Txtrefid" placeholder="Enter Product Reference id"  CssClass="form-control" runat="server"></asp:TextBox>
                   

                </div>
                <div>
                     <asp:TextBox ID="TxtrefidDiscount" placeholder="Enter Product discount" CssClass="form-control" runat="server"></asp:TextBox>
                </div>
                <div class="mt-2">
                    <asp:LinkButton ID="Lnkproductwisediscount" OnClick="Lnkproductwisediscount_Click" CssClass="btn btn-dark" runat="server">Dicounted</asp:LinkButton>
                </div>
            </asp:Panel>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <div class="row">
                        <div class="col">
                            <asp:LinkButton ID="LnkBack" runat="server" OnClick="LnkBack_Click">Back</asp:LinkButton>
                            <asp:Panel ID="GridOfProducts" runat="server">
                            <table class="table table-hover table-bordered">
                                <thead class="bg-dark text-light">
                                    <th>Product Id</th>
                                    <th>Product Ref</th>
                                    <th>Image</th>
                                    <th>Action</th>
                                </thead>
                                <tbody>
                                    <asp:Repeater ID="Rptrproduct" runat="server">
                                        <ItemTemplate>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblproductid" runat="server" Text='<%#Eval("product_id") %>'></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="Lblproductref" runat="server" Text='<%#Eval("product_ref_id") %>'></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Image ID="Imageproduct" runat="server" ImageUrl='<%#Eval("image1") %>' Height="150" Width="130" />
                                                </td>
                                                <td>
                                                    <asp:LinkButton ID="LnkUpdate" OnClick="LnkUpdate_Click"  runat="server" CssClass="btn btn-dark">Update</asp:LinkButton>
                                                </td>
                                            </tr>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </tbody>
                            </table>
                                </asp:Panel>
                            <hr />
                            <asp:HiddenField ID="Productid" runat="server" />
                            <asp:Panel ID="PanelKeyword" Visible="false" runat="server">
                                <div class="row d-flex">
                                    <div class="col-1">
                                        <h6 class="float-end">KeyWord :</h6>
                                    </div>
                                    <div class="col-11 d-flex">
                                        <asp:TextBox ID="TxtKeyword" runat="server" CssClass="form-control"></asp:TextBox>
                                        <asp:LinkButton ID="LnkUpdateKeyword" OnClick="LnkUpdateKeyword_Click" runat="server" CssClass="btn btn-dark">Update</asp:LinkButton>
                                    </div>
                                </div>
                            </asp:Panel><br />
                            <asp:Panel ID="PanelCloth" Visible="false" runat="server">
                                <div class="row">
                                    <div class="col-1">
                                        <h6>Small :</h6>
                                    </div>
                                    <div class="col-11 d-flex">
                                        <asp:TextBox ID="TxtClothSmall" runat="server" CssClass="form-control"></asp:TextBox>

                                    </div>
                                  

                                </div><br />
                                <div class="row">
                                    <div class="col-1">
                                        <h6>Medium :</h6>
                                    </div>
                                    <div class="col-11 d-flex">
                                        <asp:TextBox ID="TxtClothMedium" runat="server" CssClass="form-control"></asp:TextBox>

                                    </div>
                                </div><br />
                                <div class="row">
                                    <div class="col-1">
                                        <h6>Large :</h6>
                                    </div>
                                    <div class="col-11 d-flex">
                                        <asp:TextBox ID="TxtClothlarge" runat="server" CssClass="form-control"></asp:TextBox>

                                    </div>
                                </div><br />
                                <div class="row">
                                    <div class="col-1">
                                        <h6>X-Large :</h6>
                                    </div>
                                    <div class="col-11 d-flex">
                                        <asp:TextBox ID="TxtClothxl" runat="server" CssClass="form-control"></asp:TextBox>

                                    </div>
                                </div><br />
                                <div class="row">
                                    <div class="col-1">
                                        <h6>XX-Large :</h6>
                                    </div>
                                    <div class="col-11 d-flex">
                                        <asp:TextBox ID="TxtClothxxl" runat="server" CssClass="form-control"></asp:TextBox>

                                    </div>
                                </div><br />
                                <div class="row">
                                    <asp:LinkButton ID="LnkupdateClothing" OnClick="LnkupdateClothing_Click" runat="server" CssClass="btn btn-dark">Update Quantity</asp:LinkButton>
                                </div>
                            </asp:Panel>
                            <asp:Panel ID="PanelFootwear" Visible="false" runat="server">
                                <div class="row">
                                    <div class="col-1">
                                        <h6>Size-4 :</h6>
                                    </div>
                                    <div class="col-11 d-flex">
                                        <asp:TextBox ID="Txtfoot4" runat="server" CssClass="form-control"></asp:TextBox>

                                    </div>
                                </div>
                                <br />
                                <div class="row">
                                    <div class="col-1">
                                        <h6>Size-5 :</h6>
                                    </div>
                                    <div class="col-11 d-flex">
                                        <asp:TextBox ID="Txtfoot5" runat="server" CssClass="form-control"></asp:TextBox>

                                    </div>
                                </div>
                                <br />
                                <div class="row">
                                    <div class="col-1">
                                        <h6>Size-6 :</h6>
                                    </div>
                                    <div class="col-11 d-flex">
                                        <asp:TextBox ID="Txtfoot6" runat="server" CssClass="form-control"></asp:TextBox>

                                    </div>
                                </div>
                                <br />
                                <div class="row">
                                    <div class="col-1">
                                        <h6>Size-7 :</h6>
                                    </div>
                                    <div class="col-11 d-flex">
                                        <asp:TextBox ID="Txtfoot7" runat="server" CssClass="form-control"></asp:TextBox>

                                    </div>
                                </div>
                                <br />
                                <div class="row">
                                    <div class="col-1">
                                        <h6>Size-8 :</h6>
                                    </div>
                                    <div class="col-11 d-flex">
                                        <asp:TextBox ID="Txtfoot8" runat="server" CssClass="form-control"></asp:TextBox>

                                    </div>
                                </div>
                                <br />
                                <div class="row">
                                    <div class="col-1">
                                        <h6>Size-9 :</h6>
                                    </div>
                                    <div class="col-11 d-flex">
                                        <asp:TextBox ID="Txtfoot9" runat="server" CssClass="form-control"></asp:TextBox>

                                    </div>
                                </div>
                                <br />
                                <div class="row">
                                    <div class="col-1">
                                        <h6>Size-10 :</h6>
                                    </div>
                                    <div class="col-11 d-flex">
                                        <asp:TextBox ID="Txtfoot10" runat="server" CssClass="form-control"></asp:TextBox>

                                    </div>
                                </div>
                                <br />
                                <div class="row">
                                    <div class="col-1">
                                        <h6>Size-11 :</h6>
                                    </div>
                                    <div class="col-11 d-flex">
                                        <asp:TextBox ID="Txtfoot11" runat="server" CssClass="form-control"></asp:TextBox>

                                    </div>
                                </div>
                                <br />
                                <div class="row">
                                    <div class="col-1">
                                        <h6>Size-12 :</h6>
                                    </div>
                                    <div class="col-11 d-flex">
                                        <asp:TextBox ID="Txtfoot12" runat="server" CssClass="form-control"></asp:TextBox>

                                    </div>
                                </div>
                                <br />
                                <div class="row">
                                    <asp:LinkButton ID="LnkupdateFootwear" OnClick="LnkupdateFootwear_Click" runat="server" CssClass="btn btn-dark">Update Quantity</asp:LinkButton>
                                </div>
                            </asp:Panel>
                            <asp:Panel ID="PanelOther" Visible="false" runat="server">
                                <div class="row">
                                    <div class="col-1">
                                        <h6>Quatity :</h6>
                                    </div>
                                    <div class="col-11 d-flex">
                                        <asp:TextBox ID="TxtOthersQuntity" runat="server" CssClass="form-control"></asp:TextBox>

                                    </div>
                                </div>
                                <br />
                                <div class="row">
                                    <asp:LinkButton ID="LnkUpdateOthers" OnClick="LnkUpdateKeyword_Click" runat="server" CssClass="btn btn-dark">Update Quantity</asp:LinkButton>
                                </div>
                            </asp:Panel>
                        </div>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
        
    </div>
          <!---sweet alert---->
<script src="https://cdn.jsdelivr.net/npm/bootstrap-sweetalert@1.0.1/dist/sweetalert.min.js"></script>
          <script>
              function offermaincat() {
                  document.getElementById('<%=PanelMaincat.ClientID%>').style.display = 'block';
                  document.getElementById('<%=PanelSubcat.ClientID%>').style.display = 'none';
                  document.getElementById('<%=PanelProduct.ClientID%>').style.display = 'none';

              }

              function offersubcat() {
                  document.getElementById('<%=PanelMaincat.ClientID%>').style.display = 'none';
                  document.getElementById('<%=PanelSubcat.ClientID%>').style.display = 'block';
                   document.getElementById('<%=PanelProduct.ClientID%>').style.display = 'none';
              }

              function offerproduct() {
                  document.getElementById('<%=PanelMaincat.ClientID%>').style.display = 'none';
                   document.getElementById('<%=PanelSubcat.ClientID%>').style.display = 'none';
                  document.getElementById('<%=PanelProduct.ClientID%>').style.display = 'block';
              }
          </script>
</asp:Content>
