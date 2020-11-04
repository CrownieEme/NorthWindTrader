<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmProduct.aspx.cs" Inherits="NorhtWindTraders.Cust.frmProduct" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-lg-9 col-md-7 col-md-2">
            <asp:Literal ID="litHtmlCode_1" runat="server"></asp:Literal>
            <asp:DropDownList ID="ddlQty" runat="server" AutoPostBack="True">
            </asp:DropDownList>
            <asp:Literal ID="litHtmlCode_3" runat="server"></asp:Literal>
            
            <asp:ImageButton ID="btnCart" ImageUrl="../Content/images/AddToCart.gif" runat="server" OnClick="btnCart_Click"  />
            </div>
        </div>
    </div>
</asp:Content>
