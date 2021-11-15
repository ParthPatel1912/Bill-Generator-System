<%@ Page Title="Item Add Edit" Language="C#" MasterPageFile="~/PDF Generator/Content/AdminPanel.master" AutoEventWireup="true" CodeFile="ItemAddEdit.aspx.cs" Inherits="PDF_Generator_Admin_Panel_Item_ItemAddEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="cphHeadContent" runat="Server">

    <asp:Label ID="lblTitle" runat="server" Font-Size="30px" ForeColor="#353c4e"/>

</asp:Content>

<asp:Content ID="Content6" ContentPlaceHolderID="cphBreadcrum" runat="Server">

    <li class="breadcrumb-item" style="float: left;">
        <a href="../Home/Home.aspx"><i class="feather icon-home"></i></a>
    </li>
    <li class="breadcrumb-item" style="float: left;"><a href="ItemGridViewList.aspx">Item List</a> </li>
    <li class="breadcrumb-item" style="float: left;"><a href="ItemAddEdit.aspx">Item Add-Edit</a></li>

</asp:Content>

<asp:Content ID="Content7" ContentPlaceHolderID="cphCardTitle" runat="Server">
    Item Name and Photo with Category Name Add or Edit

</asp:Content>

<asp:Content ID="Content8" ContentPlaceHolderID="cphError" runat="Server">

    <asp:Label ID="lblError" EnableViewState="false" runat="server" CssClass="text-danger" />

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="cphPageContent" runat="Server">

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

        <div class="text-center pb-5">
            <div class="row text-right pt-3">
                <div class="col-md-4">
                    Item Name
                </div>
                <div class="col-md-4 text-center">
                    <asp:TextBox runat="server" ID="txtItemName" CssClass="form-control" placeholder="Enter item name" />
                    <asp:RequiredFieldValidator ID="rfvItemName" runat="server" ErrorMessage="Enter Category Name" ControlToValidate="txtItemName" CssClass="alert-danger" ForeColor="Red" Display="Dynamic" ValidationGroup="Save" SetFocusOnError="true"></asp:RequiredFieldValidator>
                </div>
            </div>

            <div class="row text-right pt-3">
                <div class="col-md-4 ">
                    Category Name
                </div>
                <div class="col-md-4 text-center">
                    <asp:DropDownList ID="ddlCategory" runat="server" CssClass="form-control text-left" />
                    <asp:RequiredFieldValidator ID="rfvCategoryName" runat="server" ErrorMessage="Select Category" ControlToValidate="ddlCategory" CssClass="alert-danger" ForeColor="Red" Display="Dynamic" InitialValue="-1" ValidationGroup="Save" SetFocusOnError="true"></asp:RequiredFieldValidator>
                </div>
            </div>

            <div class="row text-right pt-3">
                <div class="col-md-4">
                    Item Photo
                </div>
                <div class="col-md-4 text-center">
                    <asp:FileUpload ID="fuPhoto" runat="server" />
                    <asp:RequiredFieldValidator ID="rfvPhoto" runat="server" ErrorMessage="Upload Photo" ControlToValidate="fuPhoto" ValidationGroup="Save" SetFocusOnError="true" ForeColor="Red" CssClass="alert-danger" Display="Dynamic"></asp:RequiredFieldValidator>
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

            <div class="row pt-4">
                <div class="col-md-4">
                </div>
                <div class="col-md-4 text-center">
                </div>
            </div>

        </div>
    </div>

</asp:Content>

