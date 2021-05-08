<%@ Page Title="Bill Header Add Edit" Language="C#" MasterPageFile="~/PDF Generator/Content/AdminPanel.master" AutoEventWireup="true" CodeFile="BillHeaderAddEdit.aspx.cs" Inherits="PDF_Generator_Admin_Panel_BillHeader_BillHeaderAddEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="Server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="cphHeadContent" runat="Server">

    <asp:Label ID="lblTitle" runat="server" Font-Size="30px" ForeColor="#353c4e" />

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="cphBreadcrum" runat="Server">

    <li class="breadcrumb-item" style="float: left;">
        <a href="../Home/Home.aspx"><i class="feather icon-home"></i></a>
    </li>
    <li class="breadcrumb-item" style="float: left;"><a href="BillHeaderGridViewList.aspx">Bill Header List</a> </li>

</asp:Content>


<asp:Content ID="Content6" ContentPlaceHolderID="cphCardTitle" runat="Server">

    <asp:Label ID="lblItemName" Font-Underline="true" runat="server" EnableViewState="false" Font-Size="25px" />

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

        .radio-toolbar input[type="radio"] {
            display: none;
        }

        .radio-toolbar label {
            display: inline-block;
            background-color: none;
            padding: 4px 11px;
            font-family: Arial;
            font-size: 16px;
            border-radius: 7px;
        }

        .radio-toolbar input[type="radio"]:checked + label {
            background-color: dimgray;
            color: white;
        }
    </style>


    <div class="container">

        <div class="text-center pb-5">
            <div class="row text-right pt-3">
                <div class="col-md-4">
                    Party ID
                </div>
                <div class="col-md-4 text-center">
                    <asp:TextBox runat="server" ID="txtPartyID" CssClass="form-control" placeholder="Enter partyID" ReadOnly="true" />
                    <%--<asp:RequiredFieldValidator ID="rfvPartyID" runat="server" ErrorMessage="Enter Party ID" ControlToValidate="txtPartyID" CssClass="alert-danger" ForeColor="Red" Display="Dynamic" ValidationGroup="Save" SetFocusOnError="true"></asp:RequiredFieldValidator>--%>
                </div>
            </div>

            <div class="row text-right pt-3">
                <div class="col-md-4">
                    Order Date
                </div>
                <div class="col-md-4 text-center">
                    <asp:TextBox runat="server" ID="txtOrderDate" CssClass="form-control" TextMode="DateTimeLocal" />
                    <asp:RequiredFieldValidator ID="rfvOrderDate" runat="server" ErrorMessage="Enter Order Date" ControlToValidate="txtOrderDate" CssClass="alert-danger" ForeColor="Red" Display="Dynamic" ValidationGroup="Save" SetFocusOnError="true"></asp:RequiredFieldValidator>
                    <%--<asp:CompareValidator ID="cvOrderDate" runat="server" ErrorMessage="Enter  proper order date" ControlToValidate="txtOrderDate" CssClass="alert-danger" ForeColor="Red" Display="Dynamic" ValidationGroup="Save" SetFocusOnError="true"></asp:CompareValidator>--%>
                </div>
            </div>

            <div class="row text-right pt-3">
                <div class="col-md-4">
                    Total
                </div>
                <div class="col-md-4 text-center">
                    <asp:TextBox runat="server" ID="txtTotal" CssClass="form-control" placeholder="Enter total" ReadOnly="true" />
                    <%--<asp:RequiredFieldValidator ID="rfvTotal" runat="server" ErrorMessage="Enter Total" ControlToValidate="txtTotal" CssClass="alert-danger" ForeColor="Red" Display="Dynamic" ValidationGroup="Save" SetFocusOnError="true"></asp:RequiredFieldValidator>--%>
                </div>
            </div>

            <div class="row text-right pt-3">
                <div class="col-md-4">
                    Payment Status
                </div>
                <div class="col-md-4 text-center radio-toolbar">
                    <asp:RadioButton ID="rbPending" runat="server" CssClass="radio" GroupName="PaymentStatus" Text="Pending" Checked="True" />
                    <asp:RadioButton ID="rbPaid" runat="server" GroupName="PaymentStatus" Text="Paid" />
                </div>
            </div>

            <div class="row pt-4">
                <div class="col-md-4">
                </div>
                <div class="col-md-4">
                    <asp:Button Text="  Save  " ID="btnSave" runat="server" CssClass="btn btn-info left-btn" EnableViewState="false" ValidationGroup="Save" OnClick="btnSave_Click" />

                    <asp:Button Text=" Cancel " ID="btnCancle" runat="server" CssClass="btn btn-danger right-btn" OnClick="btnCancle_Click" />
                </div>
            </div>

        </div>
    </div>
</asp:Content>

