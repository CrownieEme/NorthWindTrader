<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmProducts.aspx.cs" Inherits="NorhtWindTraders.Cust.frmProducts" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
    <div class="row">
        <div class="col-lg-12">
            <br />
            <div class="col-md-3 col-md-offset-4">
                <br />
           <%--     <div class="input-group">
                    <input type="text" class="form-control" placeholder="Search for...">
                    <span class="input-group-btn">
                        <button class="btn btn-default" type="button">Go!</button>
                    </span>
                </div>--%>
            </div>
        </div>
    </div>
    <br />
    <br />
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
        <!---Product List Start-->
        
        <div class="col-lg-9 col-md-6 col-sm-2">
            <h2>Products</h2>
            <hr />
            <asp:Literal ID="litHtmlProdCode" runat="server"></asp:Literal>
        </div>
        <!---Product List End-->
    </div>
</asp:Content>
