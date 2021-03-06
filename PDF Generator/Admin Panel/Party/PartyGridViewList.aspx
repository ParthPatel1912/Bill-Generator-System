<%@ Page Title="Party Table" Language="C#" MasterPageFile="~/PDF Generator/Content/AdminPanel.master" AutoEventWireup="true" CodeFile="PartyGridViewList.aspx.cs" Inherits="PDF_Generator_Admin_Panel_PartyGridViewList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="Server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="cphHeadContent" runat="Server">
    Party List

</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="cphBreadcrum" runat="Server">

    <li class="breadcrumb-item" style="float: left;">
        <a href="../Home/Home.aspx"><i class="feather icon-home"></i></a>
    </li>
    <li class="breadcrumb-item" style="float: left;"><a href="PartyGridViewList.aspx">Party List</a> </li>

</asp:Content>

<asp:Content ID="Content6" ContentPlaceHolderID="cphCardTitle" runat="Server">
    Parties Details

</asp:Content>

<asp:Content ID="Content7" ContentPlaceHolderID="cphError" runat="Server">

    <asp:Label ID="lblError" EnableViewState="false" runat="server" CssClass="text-danger" />

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="cphPageContent" runat="Server">

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

        .enter {
            background: #4fbf2e;
            padding-left: 20px;
            padding-right: 20px;
            border-radius: 3em;
            //border-color: #ff0000;
            border-color: green green green green;
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
    </style>


    <div class="container pb-5">
        <div>

            <div class="col-md-12 text-right pb-4">
                <asp:Button ID="btnAdd" runat="server" CssClass="btn btn-success" Text="Add" OnClick="btnAdd_Click" />
            </div>

            <div class="table-responsive">
                <asp:GridView ID="gvParty" runat="server" CssClass="table table-bordered table-hover table-striped" AutoGenerateColumns="false" BackColor="White" BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Horizontal" OnRowCommand="gvParty_RowCommand">
                    <Columns>

                        <asp:TemplateField HeaderStyle-BorderColor="#ff00ff" HeaderText="Party Name" HeaderStyle-BackColor="RosyBrown" ItemStyle-Font-Bold="true" ItemStyle-Font-Underline="true" HeaderStyle-Font-Italic="true">
                            <ItemTemplate>
                                <asp:HyperLink ID="PartyName" runat="server" Text='<%# Eval("PartyName") %>' NavigateUrl='<%# "~/PDF Generator/Admin Panel/BillTeam/BillTeamGridViewList.aspx?PartyID=" + Eval("PartyID").ToString().Trim() %>' />                                
                            </ItemTemplate>
                        </asp:TemplateField>

                        <%--<asp:BoundField DataField="PartyName" HeaderText="Name" HeaderStyle-BorderColor="#ff00ff" HeaderStyle-BackColor="RosyBrown" HeaderStyle-Font-Bold="true" HeaderStyle-Font-Italic="true" />--%>
                        <asp:BoundField DataField="PartyMobileNumber" HeaderText="Mobile Number" HeaderStyle-BorderColor="#ff00ff" HeaderStyle-BackColor="RosyBrown" HeaderStyle-Font-Bold="true" HeaderStyle-Font-Italic="true" />
                        <asp:BoundField DataField="CityName" HeaderText="City" HeaderStyle-BorderColor="#ff00ff" HeaderStyle-BackColor="RosyBrown" HeaderStyle-Font-Bold="true" HeaderStyle-Font-Italic="true" />

                        <asp:TemplateField HeaderStyle-BorderColor="#ff00ff" HeaderStyle-BackColor="RosyBrown" ItemStyle-CssClass="text-center" HeaderStyle-Font-Italic="true">
                            <ItemTemplate>
                                <asp:Button ID="hledit" runat="server" Text="Edit" CssClass="button btn edit" CommandName="EditRecord" CommandArgument='<%# "~/PDF Generator/Admin Panel/Party/PartyAddEdit.aspx?PartyID=" + Eval("PartyID").ToString().Trim() %>' />
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderStyle-BorderColor="#ff00ff" HeaderStyle-BackColor="RosyBrown" ItemStyle-CssClass="text-center" HeaderStyle-Font-Italic="true">
                            <ItemTemplate>
                                <asp:Button ID="btnDelete" runat="server" Text="Delete" CssClass="button btn delete" OnClientClick="javascript:return confirm('Are you sure you want to Delete record ?');" CommandName="DeleteID" CommandArgument='<%# Eval("PartyID") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>


                        <asp:TemplateField HeaderStyle-BorderColor="#ff00ff" HeaderStyle-BackColor="RosyBrown" ItemStyle-CssClass="text-center" HeaderStyle-Font-Italic="true">
                            <ItemTemplate>
                                <asp:HyperLink ID="hlEnter" runat="server" Text="Enter" CssClass="button btn enter" NavigateUrl='<%# "~/PDF Generator/Admin Panel/Category/CategoryGridViewList.aspx?PartyID=" + Eval("PartyID").ToString().Trim() %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>

</asp:Content>

