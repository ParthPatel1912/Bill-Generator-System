<%@ Page Title="Category Add Edit" Language="C#" MasterPageFile="~/PDF Generator/Content/AdminPanel.master" AutoEventWireup="true" CodeFile="CategoryAddEdit.aspx.cs" Inherits="PDF_Generator_Admin_Panel_Category_CategoryAddEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="cphHeadContent" runat="Server">

    <asp:Label ID="lblTitle" runat="server" Font-Size="30px" ForeColor="#353c4e" />

</asp:Content>

<asp:Content ID="Content5" ContentPlaceHolderID="cphBreadcrum" runat="Server">

    <li class="breadcrumb-item" style="float: left;">
        <a href="../Home/Home.aspx"><i class="feather icon-home"></i></a>
    </li>
    <li class="breadcrumb-item" style="float: left;"><a href="CategoryGridViewList.aspx">Category List</a> </li>
    <li class="breadcrumb-item" style="float: left;"><a href="CategoryAddEdit.aspx">Category List Add-Edit</a> </li>

</asp:Content>

<asp:Content ID="Content6" ContentPlaceHolderID="cphCardTitle" runat="Server">
    Category Name and Photo Add or Edit

</asp:Content>

<asp:Content ID="Content7" ContentPlaceHolderID="cphError" runat="Server">

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
                    Category Name
                </div>
                <div class="col-md-4 text-center">
                    <asp:TextBox runat="server" ID="txtCategoryName" CssClass="form-control" placeholder="Enter category name" />
                    <asp:RequiredFieldValidator ID="rfvCategoryName" runat="server" ErrorMessage="Enter Category Name" ControlToValidate="txtCategoryName" CssClass="alert-danger" ForeColor="Red" Display="Dynamic" ValidationGroup="Save" SetFocusOnError="true"></asp:RequiredFieldValidator>
                </div>
            </div>

            <div class="row text-right pt-3">
                <div class="col-md-4">
                    Category Photo
                </div>
                <div class="col-md-4 text-left">
                    <asp:FileUpload ID="fuPhoto" runat="server" />
                    <asp:RequiredFieldValidator ID="rfvPhoto" runat="server" ErrorMessage="Upload Photo" ControlToValidate="fuPhoto" ValidationGroup="Save" SetFocusOnError="true" ForeColor="Red" CssClass="alert-danger" Display="Dynamic"></asp:RequiredFieldValidator>
                </div>
            </div>

            <div class="row pt-4">
                <div class="col-md-4">
                </div>
                <div class="col-md-4 text-center">
                    <asp:Button Text="  Save  " ID="btnSave" runat="server" CssClass="btn btn-info left-btn" EnableViewState="false" ValidationGroup="Save" OnClick="btnSave_Click" />

                    <asp:Button Text=" Cancel " ID="btnCancle" runat="server" CssClass="btn btn-danger right-btn" OnClick="btnCancle_Click" />
                </div>
            </div>

        </div>
    </div>

</asp:Content>

