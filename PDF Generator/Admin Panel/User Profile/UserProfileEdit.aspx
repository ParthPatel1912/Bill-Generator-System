<%@ Page Title="Edit Profile" Language="C#" MasterPageFile="~/PDF Generator/Content/AdminPanel.master" AutoEventWireup="true" CodeFile="UserProfileEdit.aspx.cs" Inherits="PDF_Generator_Admin_Panel_User_Profile_UserProfileEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="cphHeadContent" runat="Server">
    User Edit Profile

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="cphBreadcrum" runat="Server">

    <li class="breadcrumb-item" style="float: left;">
        <a href="../Home/Home.aspx"><i class="feather icon-home"></i></a>
    </li>
    <li class="breadcrumb-item" style="float: left;"><a href="UserProfile.aspx">User Profile</a> </li>
    <li class="breadcrumb-item" style="float: left;"><a href="UserProfileEdit.aspx">User Profile Edit</a> </li>

</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="cphCardTitle" runat="Server">
</asp:Content>

<asp:Content ID="Content5" ContentPlaceHolderID="cphError" runat="Server">

    <asp:Label ID="lblError" runat="server" CssClass="text-danger" />

</asp:Content>

<asp:Content ID="Content6" ContentPlaceHolderID="cphPageContent" runat="Server">

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
                                        <span>
                                            <asp:FileUpload ID="fuProfile" runat="server" ForeColor="GreenYellow" />
                                        </span>
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

        </div>
        <div class="card-block">
            <div class="view-info">
                <div class="row">
                    <div class="col-lg-12">
                        <div class="general-info">
                            <div class="row">
                                <div class="col-lg-12">
                                    <div class="table-responsive">
                                        <table class="table m-0">
                                            <tbody>
                                                <tr>
                                                    <th scope="row">User Name
                                                    </th>
                                                    <td>
                                                        <asp:TextBox runat="server" ID="txtUserName" CssClass="form-control" placeholder="Enter name" />
                                                        <asp:RequiredFieldValidator ID="rfvUserName" runat="server" ErrorMessage="Enter User Name" ControlToValidate="txtUserName" CssClass="alert-danger" ForeColor="Red" Display="Dynamic" ValidationGroup="save" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <th scope="row">Mobile No.</th>
                                                    <td>
                                                        <asp:TextBox runat="server" ID="txtUserMobileNumber" CssClass="form-control" TextMode="Number" onkeypress="return this.value.length<=9" MaxLength="10" placeholder="Enter mobile number" />
                                                        <asp:RequiredFieldValidator ID="rfvUserMobileNumber" runat="server" ErrorMessage="Enter Mobile Number" ControlToValidate="txtUserMobileNumber" CssClass="alert-danger" ForeColor="Red" Display="Dynamic" ValidationGroup="save" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                                        <asp:RegularExpressionValidator ID="revMobile" runat="server" ErrorMessage="Enter 10 digit Mobile No." ControlToValidate="txtUserMobileNumber" CssClass="alert-danger" Display="Dynamic" ForeColor="Red" ValidationExpression="[0-9]{10}" ValidationGroup="save"></asp:RegularExpressionValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <th scope="row">Password
                                                    </th>
                                                    <td>
                                                        <asp:TextBox runat="server" ID="txtPassword" CssClass="form-control" TextMode="Password" MaxLength="12" placeholder="Enter password"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="rfvPassword" runat="server" ErrorMessage="Enter Password" ControlToValidate="txtPassword" CssClass="alert-danger" ForeColor="Red" Display="Dynamic" ValidationGroup="save" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                                        <asp:CustomValidator ID="csvPassword" runat="server" ControlToValidate="txtPassword" ErrorMessage="Minimum 8 characters required" ClientValidationFunction="MinLength" ForeColor="Red" Display="Dynamic" ValidationGroup="save" SetFocusOnError="true"></asp:CustomValidator>
                                                        <asp:LinkButton ID="btnEyeImg" runat="server" CssClass="fa fa-eye" OnClick="btnEyeImg_Click" />

                                                        <script type="text/javascript">
                                                            function MinLength(sender, args) {
                                                                args.IsValid = (args.Value.length >= 8);
                                                            }
                                                        </script>
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
                            <div class="text-center pt-3">
                                <asp:Button ID="Save" runat="server" CssClass="btn btn-primary waves-effect waves-light m-r-20" Text="Save" ValidationGroup="save" OnClick="Save_Click" />
                                <asp:Button ID="Cancel" runat="server" CssClass="btn btn-danger waves-effect" Text="Cancel" OnClick="Cancel_Click" />
                            </div>
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

