<%@ Page Title="User Profile" Language="C#" MasterPageFile="~/PDF Generator/Content/AdminPanel.master" AutoEventWireup="true" CodeFile="UserProfile.aspx.cs" Inherits="PDF_Generator_Admin_Panel_User_Profile_UserProfile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="cphHeadContent" runat="Server">
    User Profile

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphBreadcrum" runat="Server">

    <li class="breadcrumb-item" style="float: left;">
        <a href="../Home/Home.aspx"><i class="feather icon-home"></i></a>
    </li>
    <li class="breadcrumb-item" style="float: left;"><a href="UserProfile.aspx">User Profile</a> </li>

</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="cphCardTitle" runat="Server">
</asp:Content>

<asp:Content ID="Content5" ContentPlaceHolderID="cphError" runat="Server">
</asp:Content>

<asp:Content ID="Content6" ContentPlaceHolderID="cphPageContent" runat="Server">

    <style type="text/css">
        .txtPassword{
            width: 85px;
        }
    </style>

    <div class="row">
        <div class="col-lg-12">
            <div class="cover-profile">
                <div class="profile-bg-img">
                    <img class="profile-bg-img img-fluid" src="<%=ResolveClientUrl("~/PDF Generator/Content/assets/images/bg-img1.jpg")%>" alt="bg-img">
                    <div class="card-block user-info">
                        <div class="col-md-12">
                            <div class="media-left">
                                <a class="profile-image">
                                    <asp:Image ID="imgProfile" runat="server" class="user-img img-radius" alt="User-Profile-Image" Height="150" AlternateText="User Image" />
                                    <%--<img class="user-img img-radius" src="../files/assets/images/user-profile/user-img.jpg" alt="user-img">--%>
                                </a>
                            </div>
                            <div class="media-body row">
                                <div class="col-lg-12">
                                    <div class="user-title">
                                        <h2>
                                            <asp:Label runat="server" ID="lblDisplayName" />
                                        </h2>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <div class="card">
        <div class="card-header">
            <h5 class="card-header-text">About Me</h5>
            <asp:LinkButton ID="btnEdit" runat="server" CssClass="btn btn-sm btn-primary waves-effect waves-light f-right" OnClick="btnEdit_Click">
                <i class="icofont icofont-edit"></i>
            </asp:LinkButton>
        </div>
        <div class="card-block">
            <div class="view-info">
                <div class="row">
                    <div class="col-md-6 col-lg-12">
                        <div class="general-info">
                            <div class="row">
                                <div class="col-md-6 col-lg-12">
                                    <div class="table-responsive">
                                        <table class="table m-0">
                                            <tbody>
                                                <tr>
                                                    <th scope="row">User Name
                                                    </th>
                                                    <td>
                                                        <asp:Label runat="server" ID="lblUserName" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <th scope="row">Mobile No.</th>
                                                    <td>
                                                        <asp:Label runat="server" ID="lblMobileNo" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <th scope="row">Password
                                                    </th>
                                                    <td>
                                                        <asp:TextBox runat="server" ID="txtPassword" CssClass="txtPassword" ReadOnly="true" BorderStyle="None" TextMode="Password" />
                                                        <asp:LinkButton ID="btnEyeImg" runat="server" CssClass="fa fa-eye" OnClick="btnEyeImg_Click" />
                                                    </td>
                                                </tr>
                                            </tbody>
                                        </table>
                                    </div>
                                </div>
                                <!-- end of table col-lg-6 -->

                                <!-- end of table col-lg-6 -->
                            </div>
                            <!-- end of row -->
                        </div>
                        <!-- end of general info -->
                    </div>
                    <!-- end of col-lg-12 -->
                </div>
                <!-- end of row -->
            </div>
            <!-- end of view-info -->

            <!-- end of edit-info -->
        </div>
        <!-- end of card-block -->
    </div>

</asp:Content>

