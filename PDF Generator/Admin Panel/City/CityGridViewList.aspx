<%@ Page Title="City Table" Language="C#" MasterPageFile="~/PDF Generator/Content/AdminPanel.master" AutoEventWireup="true" CodeFile="CityGridViewList.aspx.cs" Inherits="PDF_Generator_Admin_Panel_City_CityFridView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="Server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="cphHeadContent" runat="Server">
    City List

</asp:Content>

<asp:Content ID="Content5" ContentPlaceHolderID="cphBreadcrum" runat="Server">

    <li class="breadcrumb-item" style="float: left;">
        <a href="../Home/Home.aspx"><i class="feather icon-home"></i></a>
    </li>
    <li class="breadcrumb-item" style="float: left;"><a href="CityGridViewList.aspx">City List</a> </li>

</asp:Content>

<asp:Content ID="Content6" ContentPlaceHolderID="cphCardTitle" runat="Server">
    Cities

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
    </style>


    <div class="container pb-5">
        <div>

            <div class="col-md-12 text-right pb-4">
                <asp:Button ID="btnAdd" runat="server" CssClass="btn btn-success" Text="Add" OnClick="btnAdd_Click" />
            </div>
            
            <div class="table-responsive">
                <asp:GridView ID="gvCity" runat="server" CssClass="table table-bordered table-hover table-striped" AutoGenerateColumns="false" BackColor="White" BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Horizontal" OnRowCommand="gvCity_RowCommand">
                    <Columns>
                        <asp:BoundField DataField="CityID" HeaderText="ID" HeaderStyle-BorderColor="#ff00ff" HeaderStyle-BackColor="RosyBrown" HeaderStyle-Font-Bold="true" HeaderStyle-Font-Italic="true" />
                        <asp:BoundField DataField="CityName" HeaderText="City Name" HeaderStyle-BorderColor="#ff00ff" HeaderStyle-BackColor="RosyBrown" HeaderStyle-Font-Bold="true" HeaderStyle-Font-Italic="true" />
                        <asp:BoundField DataField="StateID" HeaderText="State ID" HeaderStyle-BorderColor="#ff00ff" HeaderStyle-BackColor="RosyBrown" HeaderStyle-Font-Bold="true" HeaderStyle-Font-Italic="true" />
                        <asp:BoundField DataField="StateName" HeaderText="State Name" HeaderStyle-BorderColor="#ff00ff" HeaderStyle-BackColor="RosyBrown" HeaderStyle-Font-Bold="true" HeaderStyle-Font-Italic="true" />
                        <asp:BoundField DataField="CountryID" HeaderText="Country ID" HeaderStyle-BorderColor="#ff00ff" HeaderStyle-BackColor="RosyBrown" HeaderStyle-Font-Bold="true" HeaderStyle-Font-Italic="true" />
                        <asp:BoundField DataField="CountryName" HeaderText="Country Name" HeaderStyle-BorderColor="#ff00ff" HeaderStyle-BackColor="RosyBrown" HeaderStyle-Font-Bold="true" HeaderStyle-Font-Italic="true" />

                        <asp:TemplateField HeaderStyle-BorderColor="#ff00ff" HeaderStyle-BackColor="RosyBrown" ItemStyle-CssClass="text-center" HeaderStyle-Font-Italic="true">
                            <ItemTemplate>
                                <asp:Button ID="btnedit" runat="server" Text="Edit" CssClass="button btn edit" CommandName="EditRecord" CommandArgument='<%# "~/PDF Generator/Admin Panel/City/CityAddEdit.aspx?CityID=" + Eval("CityID").ToString().Trim() %>' />
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderStyle-BorderColor="#ff00ff" HeaderStyle-BackColor="RosyBrown" ItemStyle-CssClass="text-center" HeaderStyle-Font-Italic="true">
                            <ItemTemplate>
                                <asp:Button ID="btnDelete" runat="server" Text="Delete" CssClass="button btn delete" OnClientClick="javascript:return confirm('Are you sure you want to Delete record ?');" CommandName="DeleteID" CommandArgument='<%# Eval("CityID") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>

                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>

</asp:Content>

