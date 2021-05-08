<%@ Page Title="Category Table" Language="C#" MasterPageFile="~/PDF Generator/Content/AdminPanel.master" AutoEventWireup="true" CodeFile="CategoryGridViewList.aspx.cs" Inherits="PDF_Generator_Admin_Panel_Category_CategoryGridViewList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="Server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="cphHeadContent" runat="Server">
    Category List

</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="cphBreadcrum" runat="Server">

    <li class="breadcrumb-item" style="float: left;">
        <a href="../Home/Home.aspx"><i class="feather icon-home"></i></a>
    </li>
    <li class="breadcrumb-item" style="float: left;"><a href="CategoryGridViewList.aspx">Category List</a> </li>

</asp:Content>

<asp:Content ID="Content6" ContentPlaceHolderID="cphCardTitle" runat="Server">
    <asp:Label ID="lblPartyName" Font-Underline="true" runat="server" EnableViewState="false" Font-Size="25px"/>

</asp:Content>

<asp:Content ID="Content7" ContentPlaceHolderID="cphError" runat="Server">

    <asp:Label ID="lblError" EnableViewState="false" runat="server" CssClass="text-danger" />

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="cphPageContent" runat="Server">

    <style type="text/css">
        .edit {
            background: #ffd710;
            padding-left: 15px;
            padding-right: 15px;
            border-radius: 7em 2em;
            //border-color: #0f0d94;
            border-color: yellow hsla(60, 90%, 50%, .8);
            color: #000;
            //box-shadow: 3px 5px 10px 0px #000000;
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
            padding-left: 15px;
            padding-right: 15px;
            border-radius: 2em 7em;
            //border-color: #ff0000;
            border-color: red red red hsla(0, 90%, 50%, .8);
            color: #fff;
            //box-shadow: 3px 5px 10px 0px #000000;
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

        .responsive {
            width: 100%;
            max-width: 100%;
            height: 300px;
        }

        /*.card-deck {
            display: flex;
            justify-content: flex-start;
            flex-flow: row wrap;
            align-items: stretch;
        }

            .card-deck .card {
                display: block;
                flex-basis: 33.3%;
            }*/
    </style>


    <div class="container pb-5">
        <div>

            <div class="col-md-12 text-right pb-4">
                <asp:Button ID="btnAdd" runat="server" CssClass="btn btn-success" Text="Add" OnClick="btnAdd_Click" />
            </div>

        </div>

        <div class="row">
            <asp:Repeater ID="rptCategory" runat="server" OnItemCommand="rptCategory_ItemCommand">

                <%--<asp:TemplateField ItemStyle-CssClass="text-center" HeaderStyle-BorderColor="#ff00ff" HeaderStyle-BackColor="RosyBrown" HeaderText="Photo" HeaderStyle-CssClass="text-center" HeaderStyle-Font-Italic="true">--%>

                <%-- </asp:TemplateField> --%>
                <%-- <asp:TemplateField ItemStyle-CssClass="text-center" HeaderStyle-BorderColor="#ff00ff" HeaderStyle-BackColor="RosyBrown" HeaderText="Name" HeaderStyle-CssClass="text-center" HeaderStyle-Font-Italic="true"> --%>
                <ItemTemplate>
                    <div class="col-md-12 col-xl-4">
                        <div class="card user-card">
                            <div class="card-header-img">
                                <asp:ImageButton runat="server" ID="imgbtnCategoryPhoto" AlternateText="Category Image" CssClass="responsive" ImageUrl='<%# Eval("CategoryPhotoPath") %>' PostBackUrl='<%# "~/PDF Generator/Admin Panel/Item/ItemGridViewList.aspx?CategoryID=" + Eval("CategoryID").ToString().Trim() %>' />
                                <div class="card-body">
                                    <h4>
                                        <asp:HyperLink ID="lblCategoryName" ForeColor="Black" runat="server" Font-Names="Geneva" Font-Bold="true" Font-Size="X-Large" Text='<%# Eval("CategoryName") %>' CssClass="text-center" NavigateUrl='<%# "~/PDF Generator/Admin Panel/Item/ItemGridViewList.aspx?CategoryID=" + Eval("CategoryID").ToString().Trim() %>' />
                                    </h4>
                                </div>
                                <div class="card-footer">
                                    <div class="btn-wrapper">
                                        <asp:Button ID="btnEdit" runat="server" CssClass="btn edit btn-m" Text="   Edit   " CommandName="EditRecord" CommandArgument='<%# "~/PDF Generator/Admin Panel/Category/CategoryAddEdit.aspx?CategoryID=" + Eval("CategoryID").ToString().Trim() %>' />
                                        <div class="pull-right">
                                            <asp:Button ID="btndelete" runat="server" CssClass="btn delete btn-m" Text=" Delete " OnClientClick="javascript:return confirm('Are you sure you want to Delete record ?');" CommandName="DeleteID" CommandArgument='<%# Eval("CategoryID") %>' />
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </ItemTemplate>
                <%-- </asp:TemplateField> --%>
            </asp:Repeater>
        </div>
    </div>

    <%--<div class="row simple-cards users-card">
                <div class="col-md-12 col-xl-4">
                    <div class="card user-card">
                        <asp:Repeater ID="rptCategory" runat="server" OnItemCommand="rptCategory_ItemCommand">
                            <ItemTemplate>
                                <div class="card-header-img">
                                    <asp:ImageButton runat="server" ID="imgbtnCategoryPhoto" AlternateText="Category Image" CssClass="responsive" ImageUrl='<%# Eval("CategoryPhotoPath") %>' PostBackUrl='<%# "~/PDF Generator/Admin Panel/Item/ItemGridViewList.aspx?CategoryID=" + Eval("CategoryID").ToString().Trim() %>' />
                                    <h4>
                                        <asp:HyperLink ID="lblCategoryName" ForeColor="Black" runat="server" Font-Names="Geneva" Font-Bold="true" Font-Size="X-Large" Text='<%# Eval("CategoryName") %>' CssClass="text-center" NavigateUrl='<%# "~/PDF Generator/Admin Panel/Item/ItemGridViewList.aspx?CategoryID=" + Eval("CategoryID").ToString().Trim() %>' />
                                    </h4>
                                </div>

                                <div>
                                    <asp:Button ID="btnEdit" runat="server" CssClass="btn edit btn-sm" Text="   Edit   " CommandName="EditRecord" CommandArgument='<%# "~/PDF Generator/Admin Panel/Category/CategoryAddEdit.aspx?CategoryID=" + Eval("CategoryID").ToString().Trim() %>' />
                                    <asp:Button ID="btndelete" runat="server" CssClass="btn delete btn-sm" Text=" Delete " OnClientClick="javascript:return confirm('Are you sure you want to Delete record ?');" CommandName="DeleteID" CommandArgument='<%# Eval("CategoryID") %>' />
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                </div>
            </div>--%>
</asp:Content>

