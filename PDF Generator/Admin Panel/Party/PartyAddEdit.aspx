<%@ Page Title="Party Add Edit" Language="C#" MasterPageFile="~/PDF Generator/Content/AdminPanel.master" AutoEventWireup="true" CodeFile="PartyAddEdit.aspx.cs" Inherits="PDF_Generator_Admin_Panel_PartyAddEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="Server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="cphHeadContent" runat="Server">

    <asp:Label ID="lblTitle" runat="server" Font-Size="30px" ForeColor="#353c4e" />

</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="cphBreadcrum" runat="Server">

    <li class="breadcrumb-item" style="float: left;">
        <a href="../Home/Home.aspx"><i class="feather icon-home"></i></a>
    </li>
    <li class="breadcrumb-item" style="float: left;"><a href="PartyGridViewList.aspx">Party List</a> </li>
    <li class="breadcrumb-item" style="float: left;"><a href="PartyAddEdit.aspx">Party Add-Edit</a></li>

</asp:Content>

<asp:Content ID="Content6" ContentPlaceHolderID="cphCardTitle" runat="Server">
    Party Details Add or Edit

</asp:Content>

<asp:Content ID="Content7" ContentPlaceHolderID="cphError" runat="Server">

    <asp:Label ID="lblError" EnableViewState="false" runat="server" CssClass="text-danger" />

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="cphPageContent" runat="Server">

    <script src="../../Content/JavaScript.js"></script>
    <script>
        function save() {
            Swal.fire({
                position: 'top-end',
                icon: 'success',
                title: 'Your work has been saved',
                showConfirmButton: false,
                timer: 1500
            })
        }
    </script>

    <style type="text/css">
        .left-btn{
            float:left;
        }

        .right-btn{
            float:right;
        }
    </style>


    <div class="container">

        <div class="text-center">
            <div class="row text-right pt-3">
                <div class="col-md-4">
                    Party Name
                </div>
                <div class="col-md-4 text-center">
                    <asp:TextBox runat="server" ID="txtPartyName" CssClass="form-control" placeholder="Enter party name" />
                    <asp:RequiredFieldValidator ID="rfvPartyName" runat="server" ErrorMessage="Enter Party Name" ControlToValidate="txtPartyName" CssClass="alert-danger" ForeColor="Red" Display="Dynamic" ValidationGroup="Save" SetFocusOnError="true"></asp:RequiredFieldValidator>
                </div>
            </div>

            <div class="row text-right pt-3">
                <div class="col-md-4 ">
                    Mobile Number
                </div>
                <div class="col-md-4 text-center">
                    <asp:TextBox runat="server" ID="txtPartyMobileNumber" CssClass="form-control" TextMode="Number" onkeypress="return this.value.length<=9" MaxLength="10" placeholder="Enter mobile number" />
                    <asp:RequiredFieldValidator ID="rfvPartyMobileNumber" runat="server" ErrorMessage="Enter Party Mobile Number" ControlToValidate="txtPartyMobileNumber" CssClass="alert-danger" ForeColor="Red" Display="Dynamic" ValidationGroup="Save" SetFocusOnError="true"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="revMobile" runat="server" ErrorMessage="Enter 10 digit Mobile No." ControlToValidate="txtPartyMobileNumber" CssClass="alert-danger" Display="Dynamic" ForeColor="Red" ValidationExpression="[0-9]{10}" ValidationGroup="Save"></asp:RegularExpressionValidator>
                </div>
            </div>

            <div class="row text-right pt-3">
                <div class="col-md-4 ">
                    Country
                </div>
                <div class="col-md-4 text-center">
                    <asp:DropDownList ID="ddlCountry" runat="server" CssClass="form-control text-left" AutoPostBack="true" OnSelectedIndexChanged="ddlCountry_SelectedIndexChanged" />
                    <asp:RequiredFieldValidator ID="rfvCountryName" runat="server" ErrorMessage="Select Country" ControlToValidate="ddlCountry" CssClass="alert-danger" ForeColor="Red" Display="Dynamic" InitialValue="-1" ValidationGroup="Save" SetFocusOnError="true"></asp:RequiredFieldValidator>
                </div>
            </div>

            <div class="row text-right pt-3">
                <div class="col-md-4 ">
                    State
                </div>
                <div class="col-md-4 text-center">
                    <asp:DropDownList ID="ddlState" runat="server" CssClass="form-control text-left" AutoPostBack="true" OnSelectedIndexChanged="ddlState_SelectedIndexChanged" />
                    <asp:RequiredFieldValidator ID="rfvStateName" runat="server" ErrorMessage="Select State" ControlToValidate="ddlState" CssClass="alert-danger" ForeColor="Red" Display="Dynamic" InitialValue="-1" ValidationGroup="Save" SetFocusOnError="true"></asp:RequiredFieldValidator>
                </div>
            </div>

            <div class="row text-right pt-3">
                <div class="col-md-4 ">
                    City
                </div>
                <div class="col-md-4 text-center">
                    <asp:DropDownList ID="ddlCity" runat="server" CssClass="form-control text-left" AutoPostBack="true" OnSelectedIndexChanged="ddlCity_SelectedIndexChanged" />
                    <asp:RequiredFieldValidator ID="rfvCityName" runat="server" ErrorMessage="Select City" ControlToValidate="ddlCity" CssClass="alert-danger" ForeColor="Red" Display="Dynamic" InitialValue="-1" ValidationGroup="Save" SetFocusOnError="true"></asp:RequiredFieldValidator>
                </div>
            </div>

            <div class="row pt-4">
                <div class="col-md-4">
                </div>
                <div class="col-md-4 text-left">
                    <asp:Button Text="  Save  " ID="btnSave" runat="server" CssClass="btn btn-info" EnableViewState="false" ValidationGroup="Save" OnClick="btnSave_Click" />
                    <a style="padding-left:20px" />
                    <asp:Button Text=" Cancel " ID="btnCancle" runat="server" CssClass="pl-3 btn btn-danger" OnClick="btnCancle_Click" />
                </div>
            </div>

            <div class="row pt-4 pb-5">
                <div class="col-md-4">
                </div>
                <div class="col-md-4 text-center">
                    
                </div>
            </div>

        </div>
    </div>

</asp:Content>

