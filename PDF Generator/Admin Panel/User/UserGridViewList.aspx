<%@ Page Title="User Table" Language="C#" MasterPageFile="~/PDF Generator/Content/AdminPanel.master" AutoEventWireup="true" CodeFile="UserGridViewList.aspx.cs" Inherits="PDF_Generator_Admin_Panel_User_UserGridViewList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="cphHeadContent" runat="Server">
    User List

</asp:Content>

<asp:Content ID="Content6" ContentPlaceHolderID="cphBreadcrum" runat="Server">

    <li class="breadcrumb-item" style="float: left;">
        <a href="../Home/Home.aspx"><i class="feather icon-home"></i></a>
    </li>
    <li class="breadcrumb-item" style="float: left;"><a href="UserGridViewList.aspx">User List</a> </li>

</asp:Content>

<asp:Content ID="Content7" ContentPlaceHolderID="cphCardTitle" runat="Server">
    User Data List

</asp:Content>

<asp:Content ID="Content8" ContentPlaceHolderID="cphError" runat="Server">

    <asp:Label ID="lblError" EnableViewState="false" runat="server" CssClass="text-danger" />

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="cphPageContent" runat="Server">

    <div class="container pb-5">
        <div>

            <div class="table-responsive">
                <asp:GridView ID="gvUser" runat="server" CssClass="table table-bordered table-hover table-striped" AutoGenerateColumns="false" BackColor="White" BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Horizontal">
                    <Columns>
                        <asp:TemplateField ItemStyle-CssClass="text-center" HeaderText="Photo" HeaderStyle-BorderColor="#ff00ff" HeaderStyle-BackColor="RosyBrown" HeaderStyle-Font-Bold="true" HeaderStyle-Font-Italic="true">
                            <ItemTemplate>
                                <asp:Image ID="photo" runat="server" ImageUrl='<%# Eval("PhotoPath") %>' Height="50" BackColor="RosyBrown" BorderColor="#ff00ff" AlternateText="User Image" />
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:BoundField DataField="UserName" HeaderText="Name" HeaderStyle-BorderColor="#ff00ff" HeaderStyle-BackColor="RosyBrown" HeaderStyle-Font-Bold="true" HeaderStyle-Font-Italic="true" />
                        <asp:BoundField DataField="MobileNo" HeaderText="Mobile Number" HeaderStyle-BorderColor="#ff00ff" HeaderStyle-BackColor="RosyBrown" HeaderStyle-Font-Bold="true" HeaderStyle-Font-Italic="true" />
                        <asp:BoundField DataField="Password" HeaderText="Password" HeaderStyle-BorderColor="#ff00ff" HeaderStyle-BackColor="RosyBrown" HeaderStyle-Font-Bold="true" HeaderStyle-Font-Italic="true" />
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>
    <%--<script>
        $(function () {
            $('#<%= gvUser.ClientID %>').prepend($("<thead></thead>").append($(this).find("tr:first"))).DataTable({
                "autoWidth": false,
            });
        });
    </script>--%>
</asp:Content>

