<%@ Page Title="" Language="C#" MasterPageFile="~/PDF Generator/Content/index.master" AutoEventWireup="true" CodeFile="ItemValue.aspx.cs" Inherits="PDF_Generator_Admin_Panel_value_ItemValue" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="Server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="cphHeadContent" runat="Server">

    Item Value

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="cphPageContent" runat="Server">

    


    <br />

    <div class="row">
        <h1>
            <asp:Label ID="lblTitle" runat="server" Text="" />
        </h1>
    </div>

    <div class="row" style="padding-top: 10px;">
        <asp:Label ID="lblError" runat="server" CssClass="text-danger" />
    </div>

    <div class="row text-left" style="padding-top: 50px; padding-left: 250px;">
        <div class="col-md-2 font-weight-bold">
            Item Number
        </div>
        <div class="col-md-4 text-center text-center">
            <asp:DropDownList ID="ddlCountry" runat="server" CssClass="form-control text-center" AutoPostBack="True">

                <asp:ListItem Value="-1" Text="-- Select Item Number --" />
                <asp:ListItem Value="1" Text="1" />
                <asp:ListItem Value="2" Text="2" />
                <asp:ListItem Value="3" Text="3" />
                <asp:ListItem Value="4" Text="4" />

            </asp:DropDownList>
            <asp:RequiredFieldValidator ID="rfvCountyName" runat="server" ErrorMessage="Select Country" ControlToValidate="ddlCountry" CssClass="alert-danger" ForeColor="Red" Display="Dynamic" ValidationGroup="Save" InitialValue="-1"></asp:RequiredFieldValidator>
        </div>
    </div>
    <br />
    <hr style="border:0.1px solid ;" />
    <br />

    <div class="row text-right" style="padding-top: 15px; padding-left: 30px;">
        <div class="col-md-2 text-right">
            Category 1 Name
        </div>
        <div class="col-md-3">
            <asp:TextBox runat="server" ID="txtCategory1Name" CssClass="form-control" />
            <asp:RequiredFieldValidator ID="rfvCategory1Name" runat="server" ErrorMessage="Enter Category Name" ControlToValidate="txtCategory1Name" CssClass="alert-danger" ForeColor="Red" Display="Dynamic" ValidationGroup="Save" SetFocusOnError="true"></asp:RequiredFieldValidator>
        </div>

        <div class="col-md-2 text-right">
            Item 1 Name
        </div>
        <div class="col-md-3">
            <asp:TextBox runat="server" ID="txtItem1Name" CssClass="form-control" />
            <asp:RequiredFieldValidator ID="rfvItem1Name" runat="server" ErrorMessage="Enter Item Name" ControlToValidate="txtItem1Name" CssClass="alert-danger" ForeColor="Red" Display="Dynamic" ValidationGroup="Save" SetFocusOnError="true"></asp:RequiredFieldValidator>
        </div>
    </div>

    <div class="row text-right" style="padding-top: 15px; padding-left: 30px;">
        <div class="col-md-2 text-right">
            Item 1 Quantity
        </div>
        <div class="col-md-3">
            <asp:TextBox runat="server" ID="txtItem1Quantity" CssClass="form-control" TextMode="Number"/>
            <asp:RequiredFieldValidator ID="rfvItem1Quantity" runat="server" ErrorMessage="Enter Item 1 Quantity" ControlToValidate="txtItem1Quantity" CssClass="alert-danger" ForeColor="Red" Display="Dynamic" ValidationGroup="Save" SetFocusOnError="true"></asp:RequiredFieldValidator>
        </div>

        <div class="col-md-2 text-right">
            Item 1 Value
        </div>
        <div class="col-md-3">
            <asp:TextBox runat="server" ID="txtItem1Value" CssClass="form-control" TextMode="Number" OnTextChanged="txtItem2Value_TextChanged"/>
            <asp:RequiredFieldValidator ID="rfvItem1Value" runat="server" ErrorMessage="Enter Item 1 Value" ControlToValidate="txtItem1Value" CssClass="alert-danger" ForeColor="Red" Display="Dynamic" ValidationGroup="Save" SetFocusOnError="true"></asp:RequiredFieldValidator>
        </div>
    </div>

    <div class="row text-right" style="padding-top: 15px; padding-left: 30px;">
        <div class="col-md-2 text-right">
            Item 1 Total Rs.
        </div>
        <div class="col-md-3">
            <asp:TextBox runat="server" ID="txtItem1TotalRS" CssClass="form-control" TextMode="Number"/>
            <asp:RequiredFieldValidator ID="rfvItem1TotalRS" runat="server" ErrorMessage="Enter Item 1 Total Rs." ControlToValidate="txtItem1TotalRS" CssClass="alert-danger" ForeColor="Red" Display="Dynamic" ValidationGroup="Save" SetFocusOnError="true"></asp:RequiredFieldValidator>
        </div>

    </div>

    <br /><br />

</asp:Content>
