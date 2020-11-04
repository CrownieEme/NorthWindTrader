<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CustomerIndex.aspx.cs" Inherits="NorhtWindTraders.Cust.CustomerIndex" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
   <div class="row">
        <div class="col-lg-12 col-md-9 col-sm-9" >
            <div class="col-lg-3 col-md-3 col-sm-2 text-center">
            <h1>Special Deals:</h1>
        </div>
            </div>
    </div>
    <hr />
    <div class="row">
        <div class="col-lg-12 col-md-9 col-sm-9" >
            <asp:Literal ID="litHtmlCode" runat="server"></asp:Literal>
        </div>
    </div>
</asp:Content>
