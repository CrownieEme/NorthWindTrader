<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmViewCart.aspx.cs" Inherits="NorhtWindTraders.Cust.frmViewCart" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <!---Category Menu Start-->
        <div class="col-lg-3 col-md-2 col-sm-2">
                <div class="no-padding">
                    <span class="title">CATEGORIES</span>
                </div>
                <div class="list-group list-categ">
                    <asp:Literal ID="litHtmlCatCode" runat="server"></asp:Literal>            
                </div>
            </div>
        <!---Category Menu End-->
        <div class="col-lg-9 col-md-6 col-sm-2">
            <h2><i class="fa fa-shopping-cart"></i>Cart Stuff:</h2>
            <div class="col-lg-9 col-md-5 col-sm-2 text-center ">
             
               <asp:Literal ID="litHTML_1" runat="server"></asp:Literal>
               <div class="col-lg-2 col-md-2 col-sm-2">
                 <asp:DropDownList ID="ddlQty" runat="server"></asp:DropDownList></div>
                                        <div class="col-lg-2 col-md-2 col-sm-2">
<%--                    <asp:Button ID="UpdateOrder" Text="Update Order" CssCLass="btn btn-info" runat="server"  />--%>
                   <input class="btn-info" name="btnSubmit" id="btnSubmit" runat="server" type ="button" value="Update" onserverclick="Update" />
                </div>
                </div>
                <hr />
                <div class="col-md-offset-10 ">
                    <p><b>Total:$</b></p><asp:Literal ID="TotalinCart" runat="server"></asp:Literal>

                </div>
                <hr />

                <div class="col-md-offset-10 ">
                    <asp:Button ID="PlaceOrder" Text="Place Order" CssCLass="btn btn-info" runat="server" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
