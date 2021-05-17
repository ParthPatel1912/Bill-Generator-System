<%@ Page Title="Home" Language="C#" MasterPageFile="~/PDF Generator/Content/AdminPanel.master" AutoEventWireup="true" CodeFile="Home.aspx.cs" Inherits="PDF_Generator_Admin_Panel_Home_Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="cphHeadContent" runat="Server">
    Home

</asp:Content>

<asp:Content ID="Content5" ContentPlaceHolderID="cphBreadcrum" runat="Server">

    <li class="breadcrumb-item" style="float: left;">
        <a href="Home.aspx"><i class="feather icon-home"></i></a>
    </li>
    <li class="breadcrumb-item" style="float: left;"><a href="Home.aspx">Home</a> </li>

</asp:Content>

<asp:Content ID="Content6" ContentPlaceHolderID="cphCardTitle" runat="Server">
    Home

</asp:Content>

<asp:Content ID="Content7" ContentPlaceHolderID="cphError" runat="Server">

    <asp:Label ID="lblError" EnableViewState="false" runat="server" CssClass="text-danger" />

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="cphPageContent" runat="Server">

    <div class="container">
        <div class="row">
            <div class="offset-md-3 col-md-2 text-center">
                <a href="../Party/PartyAddEdit.aspx">
                    <i class="icon fa fa-user" style="color: #676767; font-size: 24px; margin: 5px; text-align: center; padding: 20px; width: 80px; height: 80px; border: 6px solid #d7d7d7; border-radius: 50%; background: #fcfcfc; border-color: #1D8EC7;"></i>
                </a>
                <br />
                Party
            </div>
            <div class="col-md-2 text-center">
                <a href="../Category/CategoryAddEdit.aspx">
                    <i class="icon fa fa-list-alt" style="color: #676767; font-size: 24px; margin: 5px; text-align: center; padding: 20px; width: 80px; height: 80px; border: 6px solid #d7d7d7; border-radius: 50%; background: #fcfcfc; border-color: #1D8EC7;"></i>
                </a>
                <br />
                Category
            </div>
            <div class="col-md-2 text-center">
                <a href="../Item/ItemAddEdit.aspx">
                    <i class="icon fa fa-th-large" style="color: #676767; font-size: 24px; margin: 5px; text-align: center; padding: 20px; width: 80px; height: 80px; border: 6px solid #d7d7d7; border-radius: 50%; background: #fcfcfc; border-color: #1D8EC7;"></i>
                </a>
                <br />
                Item
            </div>
        </div>


        <div class="row pb-5">
            <div class="offset-md-3 col-md-2 text-center">
                <a href="../Party/PartyGridViewList.aspx">
                    <i class="icon fa fa-table" style="color: #676767; font-size: 24px; margin: 5px; text-align: center; padding: 20px; width: 80px; height: 80px; border: 6px solid #d7d7d7; border-radius: 50%; background: #fcfcfc; border-color: #1D8EC7;"></i>
                </a>
                <br />
                Party List
            </div>
            <div class="col-md-2 text-center">
                <a href="../Category/CategoryGridViewList.aspx">
                    <i class="icon fa fa-th" style="color: #676767; font-size: 24px; margin: 5px; text-align: center; padding: 20px; width: 80px; height: 80px; border: 6px solid #d7d7d7; border-radius: 50%; background: #fcfcfc; border-color: #1D8EC7;"></i>
                </a>
                <br />
                Category List
            </div>
            <div class="col-md-2 text-center">
                <a href="../Item/ItemGridViewList.aspx">
                    <i class="icon fa fa-list-ul" style="color: #676767; font-size: 24px; margin: 5px; text-align: center; padding: 20px; width: 80px; height: 80px; border: 6px solid #d7d7d7; border-radius: 50%; background: #fcfcfc; border-color: #1D8EC7;"></i>
                </a>
                <br />
                Item List
            </div>
        </div>
    </div>

</asp:Content>

