<%@ Page Title="Bill Team Table" Language="C#" MasterPageFile="~/PDF Generator/Content/AdminPanel.master" AutoEventWireup="true" CodeFile="BillTeamGridViewList.aspx.cs" Inherits="PDF_Generator_Admin_Panel_BillTeam_BillTeamGridViewList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="Server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="cphHeadContent" runat="Server">
    Bill Team

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="cphBreadcrum" runat="Server">

    <li class="breadcrumb-item" style="float: left;">
        <a href="../Home/Home.aspx"><i class="feather icon-home"></i></a>
    </li>
    <li class="breadcrumb-item" style="float: left;"><a href="BillTeamGridViewList.aspx">Bill Team List</a> </li>

</asp:Content>

<asp:Content ID="Content6" ContentPlaceHolderID="cphCardTitle" runat="Server">
    All details of all Entered Bill

</asp:Content>

<asp:Content ID="Content7" ContentPlaceHolderID="cphError" runat="Server">

    <asp:Label ID="lblError" EnableViewState="false" runat="server" CssClass="text-danger" />

</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="cphPageContent" runat="Server">

    <style type="text/css">
        .edit {
            background: #ffd710;
            padding-left: 20px;
            padding-right: 20px;
            border-radius: 3em;
            //border-color: #0f0d94;
            border-color: yellow hsla(60, 90%, 50%, .8);
            color: #000;
            box-shadow: 3px 5px 10px 0px #000000;
            background:

        {
            image: linear-gradient(45deg, #f1c40f 50%, transparent 50%);
            position: 100%;
            size: 400%;
        }

        transition: background 300ms ease-in-out;

        &:hover {
            background-position: 0;
        }

        }

        .delete {
            background: #ff0000;
            padding-left: 20px;
            padding-right: 20px;
            border-radius: 3em;
            //border-color: #ff0000;
            border-color: red red red hsla(0, 90%, 50%, .8);
            color: #fff;
            box-shadow: 3px 5px 10px 0px #000000;
            background:

        {
            image: linear-gradient(45deg, #f1c40f 50%, transparent 50%);
            position: 100%;
            size: 400%;
        }

        transition: background 300ms ease-in-out;

        &:hover {
            background-position: 0;
        }

        }

        .button {
            display: inline-block;
            padding: 5px 25px;
            font-size: 24px;
            cursor: pointer;
            text-align: center;
            text-decoration: none;
            outline: none;
            color: #fff;
            background-color: #ffb300;
            border: none;
            border-radius: 15px;
            box-shadow: 0 9px #999;
        }

            .button:hover {
                background-color: #ff6600
            }

            .button:active {
                background-color: #ff6600;
                box-shadow: 0 5px #555;
                transform: translateY(4px);
            }

        .auto-style1 {
            width: 100%;
            height: 202px;
        }

        .auto-style2 {
            text-align: center;
            width: 645px;
        }

        .auto-style3 {
            text-align: right;
        }

        .auto-style4 {
            width: 645px;
        }

        .auto-style5 {
            text-align: justify;
        }
    </style>

    <div class="container pb-5">
        <div>

            <div class="col-md-12 text-right pb-5">
                <asp:Button ID="btnExcelFile" runat="server" CssClass="button" Text="Excel File" OnClick="btnExcelFile_Click" />
            </div>
            
            <div class="dt-responsive table-responsive">
                <asp:GridView ID="gvBillTeam" runat="server" CssClass="table table-striped table-hover table-bordered nowrap" AutoGenerateColumns="false" BackColor="White" BorderColor="#E7E7FF" OnRowDataBound="gvBillTeam_RowDataBound" OnRowCommand="gvBillTeam_RowCommand">
                    <Columns>
                        <asp:BoundField DataField="PartyName" HeaderText="Party Name" HeaderStyle-BorderColor="#ff00ff" HeaderStyle-BackColor="RosyBrown" HeaderStyle-Font-Bold="true" HeaderStyle-Font-Italic="true" />
                        <asp:BoundField DataField="OrderDateTime" HeaderText="Date" HeaderStyle-BorderColor="#ff00ff" HeaderStyle-BackColor="RosyBrown" HeaderStyle-Font-Bold="true" HeaderStyle-Font-Italic="true" />
                        <asp:BoundField DataField="CategoryName" HeaderText="Category" HeaderStyle-BorderColor="#ff00ff" HeaderStyle-BackColor="RosyBrown" HeaderStyle-Font-Bold="true" HeaderStyle-Font-Italic="true" />
                        <asp:BoundField DataField="ItemName" HeaderText="Item" HeaderStyle-BorderColor="#ff00ff" HeaderStyle-BackColor="RosyBrown" HeaderStyle-Font-Bold="true" HeaderStyle-Font-Italic="true" />
                        <asp:BoundField DataField="Quantity" HeaderText="Quantity" HeaderStyle-BorderColor="#ff00ff" HeaderStyle-BackColor="RosyBrown" HeaderStyle-Font-Bold="true" HeaderStyle-Font-Italic="true" />
                        <asp:BoundField DataField="Price" HeaderText="Price" HeaderStyle-BorderColor="#ff00ff" HeaderStyle-BackColor="RosyBrown" HeaderStyle-Font-Bold="true" HeaderStyle-Font-Italic="true" />
                        <asp:BoundField DataField="Amount" HeaderText="Amount" HeaderStyle-BorderColor="#ff00ff" HeaderStyle-BackColor="RosyBrown" HeaderStyle-Font-Bold="true" HeaderStyle-Font-Italic="true" />
                        <asp:BoundField DataField="Status" HeaderText="Status" HeaderStyle-BorderColor="#ff00ff" HeaderStyle-BackColor="RosyBrown" HeaderStyle-Font-Bold="true" HeaderStyle-Font-Italic="true" />
                        <asp:BoundField DataField="Discount" HeaderText="Discount" HeaderStyle-BorderColor="#ff00ff" HeaderStyle-BackColor="RosyBrown" HeaderStyle-Font-Bold="true" HeaderStyle-Font-Italic="true" />
                        <asp:BoundField DataField="CourierCharge" HeaderText="Courier" HeaderStyle-BorderColor="#ff00ff" HeaderStyle-BackColor="RosyBrown" HeaderStyle-Font-Bold="true" HeaderStyle-Font-Italic="true" />
                        <asp:BoundField DataField="Total" HeaderText="Total" HeaderStyle-BorderColor="#ff00ff" HeaderStyle-BackColor="RosyBrown" HeaderStyle-Font-Bold="true" HeaderStyle-Font-Italic="true" />

                        <asp:TemplateField HeaderStyle-BorderColor="#ff00ff" HeaderStyle-BackColor="RosyBrown" ItemStyle-CssClass="text-center" HeaderStyle-Font-Italic="true">
                            <ItemTemplate>
                                <asp:Button ID="btnEdit" runat="server" Text="Edit" CssClass="btn edit" CommandName="EditRecord" CommandArgument='<%# "~/PDF Generator/Admin Panel/BillHeader/BillHeaderAddEdit.aspx?BillHeaderID=" + Eval("BillHeaderID").ToString().Trim() %>' />
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderStyle-BorderColor="#ff00ff" HeaderStyle-BackColor="RosyBrown" ItemStyle-CssClass="text-center" HeaderStyle-Font-Italic="true">
                            <ItemTemplate>
                                <asp:Button ID="btnDelete" runat="server" Text="Delete" CssClass="btn delete" OnClientClick="javascript:return confirm('Are you sure you want to Delete record ?');" CommandName="DeleteID" CommandArgument='<%# Eval("BillHeaderID") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderStyle-BorderColor="#ff00ff" HeaderStyle-BackColor="RosyBrown" ItemStyle-CssClass="text-center" HeaderStyle-Font-Italic="true">
                            <ItemTemplate>
                                <asp:ImageButton ImageUrl="~/PDF Generator/Content/img/download.png" Width="50" ID="btnDownload" runat="server" Text="Download" CommandName="Download" CommandArgument='<%# "~/PDF Generator/Admin Panel/PDF Bill/Bill.aspx?BillTeamID=" + Eval("BillTeamID").ToString().Trim() %>' AlternateText="Download"/>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>
    <script>
        $(document).ready(function () {
            $('#cphPageContent_gvBillTeam').DataTable();
        });
    </script>
</asp:Content>

