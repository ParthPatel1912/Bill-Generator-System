﻿<%@ Page Title="City Add Edit" Language="C#" MasterPageFile="~/PDF Generator/Content/AdminPanel.master" AutoEventWireup="true" CodeFile="CityAddEdit.aspx.cs" Inherits="PDF_Generator_Admin_Panel_City_CityAddEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="Server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="cphHeadContent" runat="Server">

    <asp:Label ID="lblTitle" runat="server" Font-Size="30px" ForeColor="#353c4e" />

</asp:Content>

<asp:Content ID="Content6" ContentPlaceHolderID="cphBreadcrum" runat="Server">

    <li class="breadcrumb-item" style="float: left;">
        <a href="../Home/Home.aspx"><i class="feather icon-home"></i></a>
    </li>
    <li class="breadcrumb-item" style="float: left;"><a href="CityGridViewList.aspx">City List</a> </li>
    <li class="breadcrumb-item" style="float: left;"><a href="CityAddEdit.aspx">City Add-Edit</a> </li>

</asp:Content>

<asp:Content ID="Content7" ContentPlaceHolderID="cphCardTitle" runat="Server">
    City and its State name Add or Edit

</asp:Content>

<asp:Content ID="Content8" ContentPlaceHolderID="cphError" runat="Server">

    <asp:Label ID="lblError" EnableViewState="false" runat="server" CssClass="text-danger" />

</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="cphPageContent" runat="Server">

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
        .left-btn {
            float: left;
        }

        .right-btn {
            float: right;
        }
    </style>


    <div class="container">

        <div class="text-center">
            <div class="row text-right pt-3">
                <div class="col-md-4">
                    City Name
                </div>
                <div class="col-md-4 text-center">
                    <asp:TextBox runat="server" ID="txtCityName" CssClass="form-control" placeholder="Enter city name" />
                    <asp:RequiredFieldValidator ID="rfvCityName" runat="server" ErrorMessage="Enter City Name" ControlToValidate="txtCityName" CssClass="alert-danger" ForeColor="Red" Display="Dynamic" ValidationGroup="Save" SetFocusOnError="true"></asp:RequiredFieldValidator>
                </div>
            </div>

            <div class="row text-right pt-3">
                <div class="col-md-4 ">
                    State
                </div>
                <div class="col-md-4 text-center">
                    <asp:DropDownList ID="ddlState" runat="server" CssClass="form-control text-center" />
                    <asp:RequiredFieldValidator ID="rfvStateName" runat="server" ErrorMessage="Select State" ControlToValidate="ddlState" CssClass="alert-danger" ForeColor="Red" Display="Dynamic" InitialValue="-1" ValidationGroup="Save" SetFocusOnError="true"></asp:RequiredFieldValidator>
                </div>
            </div>

            <div class="row pt-4">
                <div class="col-md-4">
                </div>
                <div class="col-md-4 text-left">
                    <asp:Button Text="  Save  " ID="btnSave" runat="server" CssClass="btn btn-info" EnableViewState="false" ValidationGroup="Save" OnClick="btnSave_Click" />
                    <a style="padding-left:20px" />
                    <asp:Button Text=" Cancel " ID="btnCancle" runat="server" CssClass="btn btn-danger" OnClick="btnCancle_Click" />
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

