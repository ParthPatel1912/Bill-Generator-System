<%@ Page Title="Bill Header Table" Language="C#" MasterPageFile="~/PDF Generator/Content/AdminPanel.master" AutoEventWireup="true" CodeFile="BillHeaderGridViewList.aspx.cs" Inherits="PDF_Generator_Admin_Panel_BillHeader_BillHeaderGridViewList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="Server">
</asp:Content>

<asp:Content ID="Content6" ContentPlaceHolderID="cphHeadContent" runat="Server">
    Bill Header

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="cphBreadcrum" runat="Server">

    <li class="breadcrumb-item" style="float: left;">
        <a href="../Home/Home.aspx"><i class="feather icon-home"></i></a>
    </li>
    <li class="breadcrumb-item" style="float: left;"><a href="BillHeaderGridViewList.aspx">Bill Header List</a> </li>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="cphCardTitle" runat="Server">
    Bill List with Date and Total

</asp:Content>

<asp:Content ID="Content7" ContentPlaceHolderID="cphError" runat="Server">

    <asp:Label ID="lblError" EnableViewState="false" runat="server" CssClass="text-danger" />

</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="cphPageContent" runat="Server">

    <div class="container pb-5">
        <div>

            <div class="table-responsive">
                <asp:GridView ID="gvBillHeader" runat="server" CssClass="table table-striped table-hover table-bordered table-striped" AutoGenerateColumns="true" BackColor="White" BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Horizontal">
                </asp:GridView>
            </div>
        </div>
    </div>

</asp:Content>

