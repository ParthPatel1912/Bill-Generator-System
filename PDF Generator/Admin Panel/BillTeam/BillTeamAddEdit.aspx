<%@ Page Title="Bill Team Add Edit" Language="C#" MasterPageFile="~/PDF Generator/Content/AdminPanel.master" AutoEventWireup="true" CodeFile="BillTeamAddEdit.aspx.cs" Inherits="PDF_Generator_Admin_Panel_BillTeam_BillTeamAddEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="Server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="cphHeadContent" runat="Server">

    <asp:Label ID="lblTitle" runat="server" Font-Size="30px" ForeColor="#353c4e" />

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="cphBreadcrum" runat="Server">

    <li class="breadcrumb-item" style="float: left;">
        <a href="../Home/Home.aspx"><i class="feather icon-home"></i></a>
    </li>
    <li class="breadcrumb-item" style="float: left;"><a href="BillTeamGridViewList.aspx">Bill Team List</a></li>
    <li class="breadcrumb-item" style="float: left;"><a href="BillTeamAddEdit.aspx">Bill Team Add-Edit</a> </li>

</asp:Content>

<asp:Content ID="Content6" ContentPlaceHolderID="cphCardTitle" runat="Server">
    All details of Item can Change

</asp:Content>

<asp:Content ID="Content7" ContentPlaceHolderID="cphError" runat="Server">

    <asp:Label ID="lblError" runat="server" CssClass="text-danger" EnableViewState="false" />

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

        <%-- <div class="row">
            <div class="col-md-4 text-right font-weight-bold">
                Item Number
            </div>
            <div class="col-md-4">
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

        <hr style="border: 0.1px solid;" />

        <br />--%>

        <div class="text-center pb-5">
            <div class="row pt-3 text-right">
                <div class="col-md-2">
                    Bill Header ID
                </div>
                <div class="col-md-3">
                    <asp:TextBox runat="server" ID="txtBillHeaderID" CssClass="form-control" placeholder="Enter bill header ID" ReadOnly="true" />
                    <%--<asp:RequiredFieldValidator ID="rfvBillHeaderID" runat="server" ErrorMessage="Enter Bill Header ID" ControlToValidate="txtBillHeaderID" CssClass="alert-danger" ForeColor="Red" Display="Dynamic" ValidationGroup="Save" SetFocusOnError="true"></asp:RequiredFieldValidator>--%>
                </div>

                <div class="col-md-3">
                    Item ID
                </div>
                <div class="col-md-3">
                    <asp:TextBox runat="server" ID="txtItemID" CssClass="form-control" placeholder="Enter item ID" ReadOnly="true" />
                    <%--<asp:RequiredFieldValidator ID="rfvItemID" runat="server" ErrorMessage="Enter Item ID" ControlToValidate="txtItemID" CssClass="alert-danger" ForeColor="Red" Display="Dynamic" ValidationGroup="Save" SetFocusOnError="true"></asp:RequiredFieldValidator>--%>
                </div>
            </div>

            <div class="row pt-3 text-right">
                <div class="col-md-2">
                    Category ID
                </div>
                <div class="col-md-3">
                    <asp:TextBox runat="server" ID="txtCategoryID" CssClass="form-control" placeholder="Enter Category ID" ReadOnly="true" />
                    <%--<asp:RequiredFieldValidator ID="rfvCategoryID" runat="server" ErrorMessage="Enter Category ID" ControlToValidate="txtCategoryID" CssClass="alert-danger" ForeColor="Red" Display="Dynamic" ValidationGroup="Save" SetFocusOnError="true"></asp:RequiredFieldValidator>--%>
                </div>

                <div class="col-md-3">
                    User ID
                </div>
                <div class="col-md-3">
                    <asp:TextBox runat="server" ID="txtUserID" CssClass="form-control" placeholder="Enter user ID" ReadOnly="true" />
                    <%--<asp:RequiredFieldValidator ID="rfvUserID" runat="server" ErrorMessage="Enter User ID" ControlToValidate="txtUserID" CssClass="alert-danger" ForeColor="Red" Display="Dynamic" ValidationGroup="Save" SetFocusOnError="true"></asp:RequiredFieldValidator>--%>
                </div>
            </div>

            <div class="row pt-3 text-right">
                <div class="col-md-2">
                    Quantity
                </div>
                <div class="col-md-3">
                    <asp:TextBox runat="server" ID="txtQuantity" CssClass="form-control" placeholder="Enter quantity" TextMode="Number" />
                    <asp:RequiredFieldValidator ID="rfvQuantity" runat="server" ErrorMessage="Enter Quantity" ControlToValidate="txtQuantity" CssClass="alert-danger" ForeColor="Red" Display="Dynamic" ValidationGroup="Save" SetFocusOnError="true"></asp:RequiredFieldValidator>
                </div>

                <div class="col-md-3">
                    Price per piece
                </div>
                <div class="col-md-3">
                    <asp:TextBox runat="server" ID="txtPrice" CssClass="form-control" placeholder="Enter per piece Price" TextMode="Number" />
                    <asp:RequiredFieldValidator ID="rfvPrice" runat="server" ErrorMessage="Enter Price" ControlToValidate="txtPrice" CssClass="alert-danger" ForeColor="Red" Display="Dynamic" ValidationGroup="Save" SetFocusOnError="true"></asp:RequiredFieldValidator>
                </div>
            </div>

            <div class="row pt-3 text-right">
                <div class="col-md-2">
                    Discount
                </div>
                <div class="col-md-3">
                    <asp:TextBox runat="server" ID="txtDiscount" CssClass="form-control" placeholder="Enter discount" TextMode="Number" />
                    <asp:RequiredFieldValidator ID="rfvDiscount" runat="server" ErrorMessage="Enter Discount" ControlToValidate="txtDiscount" CssClass="alert-danger" ForeColor="Red" Display="Dynamic" ValidationGroup="Save" SetFocusOnError="true"></asp:RequiredFieldValidator>
                </div>

                <div class="col-md-3">
                    Courier Charge
                </div>
                <div class="col-md-3">
                    <asp:TextBox runat="server" ID="txtCourierCharge" CssClass="form-control" placeholder="Enter courier charge" TextMode="Number" />
                    <asp:RequiredFieldValidator ID="rfvCourierCharge" runat="server" ErrorMessage="Enter Courier Charge" ControlToValidate="txtCourierCharge" CssClass="alert-danger" ForeColor="Red" Display="Dynamic" ValidationGroup="Save" SetFocusOnError="true"></asp:RequiredFieldValidator>
                </div>

                <%--<div class="col-md-3">
                    Order Date
                </div>
                <div class="col-md-3">
                    <asp:TextBox runat="server" ID="txtOrderDate" CssClass="form-control" TextMode="Date" />
                    <asp:RequiredFieldValidator ID="rfvOrderDate" runat="server" ErrorMessage="Enter Order Date" ControlToValidate="txtOrderDate" CssClass="alert-danger" ForeColor="Red" Display="Dynamic" ValidationGroup="Save" SetFocusOnError="true"></asp:RequiredFieldValidator>
                    <asp:CompareValidator ID="cvOrderDate" runat="server" ErrorMessage="Enter  proper order date" ControlToValidate="txtOrderDate" CssClass="alert-danger" ForeColor="Red" Display="Dynamic" ValidationGroup="Save" SetFocusOnError="true"></asp:CompareValidator>
                </div>--%>
            </div>

            <div class="row pt-5">
                <div class="col-md-4">
                </div>
                <div class="col-md-4 text-center">
                    <asp:Button Text="  Save  " ID="btnSave" runat="server" CssClass="btn btn-info" EnableViewState="false" ValidationGroup="Save" OnClick="btnSave_Click" />
                    <a style="padding-left:20px" />
                    <asp:Button Text=" Cancel " ID="btnCancle" runat="server" CssClass="btn btn-danger" OnClick="btnCancle_Click" />
                </div>
            </div>

        </div>
    </div>

</asp:Content>

