<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="AdminReturnrequest.aspx.cs" Inherits="RazorpaySampleApp.WebForm30" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid shadow" style="margin-top: 130px; overflow-x: scroll">
        <h4 class="text-center">Update Status</h4>
        <div class="row">
            <div class="col">
                <table class="table table-hover">
                    <thead class="bg-dark text-white">
                        <tr>
                            <th>Product Id</th>
                            <th>Reference Id</th>
                            <th>Order Id</th>
                            <th>Price</th>
                            <th>Buyer</th>
                            <th>Seller</th>

                            <th>Dispatch date</th>
                            <th>Shipping date</th>
                            <th>Pickup date</th>
                            <th>Final Delivery date</th>
                            <th>Reason</th>
                            <th>Return Date</th>
                            <th>Images</th>
                            <th>Status</th>
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
                                    <td class="text-center"><%#Eval("buyer") %></td>
                                    <td><%#Eval("seller") %></td>
                                    <td><%#Convert.ToDateTime(Eval("dispatched_date")).ToString("dd/MM/yyyy") %></td>
                                    <td><%#Convert.ToDateTime(Eval("deliverydate")).ToString("dd/MM/yyyy") %></td>
                                    <td><%#Convert.ToDateTime(Eval("pickup")).ToString("dd/MM/yyyy") %></td>
                                    <td><%#Convert.ToDateTime(Eval("delivery_date")).ToString("dd/MM/yyyy") %></td>
                                    <td><%#Eval("returnreason").ToString() %></td>
                                    <td><%#Convert.ToDateTime(Eval("returnapplydate")).ToString("dd/MM/yyyy") %></td>
                                    <td>
                                        <asp:Image ID="Image1" Height="100px" Width="100px" runat="server" ImageUrl='<%#Eval("productimage") %>' /></td>
                                    <td>
                                        <%#Eval("accepted").ToString()=="1"?"Accepted":Eval("accepted").ToString()=="2"?"Rejected":"Pending"%>
                                    </td>
                                    <td class="d-flex">
                                        <asp:HiddenField ID="Hdnrequestid" Value='<%#Eval("requestid") %>' runat="server" />
                                        <a href="#" class="btn btn-success" data-bs-toggle="modal" data-bs-target="#modalaccept">Accept</a>
                                        <asp:LinkButton ID="btnReject" OnClick="btnReject_Click" OnClientClick="return AreYouSure(this)" runat="server" CssClass="btn btn-danger">Reject</asp:LinkButton>
                                    </td>
                                    <td></td>
                                    <!----return price--->
                                    <div class="modal fade" id="modalaccept" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
                                        <div class="modal-dialog">
                                            <div class="modal-content">
                                                <div class="modal-header">
                                                    <h5 class="modal-title" id="exampleModalLabel">Enter Return Price</h5>
                                                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                                                </div>
                                                <div class="modal-body">
                                                    <div class="modal-body">

                                                        <div class="mb-3">
                                                            <label for="recipient-name" class="col-form-label">Return Shipping Price:</label>
                                                            <asp:TextBox ID="TxtReturnShippingPrice" required CssClass="form-control" TextMode="Number" runat="server"></asp:TextBox>
                                                        </div>
                                                    </div>

                                                </div>
                                                <asp:LinkButton ID="btnAccept" OnClick="btnAccept_Click" runat="server" OnClientClick="return AreYouSureAccept(this)" CssClass="btn btn-success m-4">Accept</asp:LinkButton>&nbsp;
                                            </div>
                                        </div>
                                    </div>
                                    <!----return price--->
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
                text: "Are You Sure Want To Reject This Request ?",
                type: "warning",
                showCancelButton: true,
                confirmButtonClass: "btn-danger",
                confirmButtonText: "Yes, Reject it!",
                closeOnConfirm: true
            },
                function () {
                    obj.status = true;
                    obj.ele = ev;
                    obj.ele.click();
                });

            return false;
        }


        var obj = { status: false, ele: null };
        function AreYouSureAccept(ev) {
            if (obj.status) {
                return true;
            };
            swal({
                title: "Are you sure?",
                text: "Are You Sure Want To Accept Return ?",
                type: "warning",
                showCancelButton: true,
                confirmButtonClass: "btn-success",
                confirmButtonText: "Yes, Accept it!",
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
