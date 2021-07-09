<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DeleteAccount.aspx.cs" Inherits="PDF_Generator_Admin_Panel_DeleteAccount" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <title>Delete Account</title>


    <meta charset="UTF-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />

    <link rel="icon" type="image/png" href="<%=ResolveClientUrl("~/PDF Generator/Content/Content_Login/images/icons/favicon.ico")%>" />

    <link rel="stylesheet" type="text/css" href="<%=ResolveClientUrl("~/PDF Generator/Content/Content_Login/vendor/bootstrap/css/bootstrap.min.css")%>" />

    <link rel="stylesheet" type="text/css" href="<%=ResolveClientUrl("~/PDF Generator/Content/Content_Login/fonts/font-awesome-4.7.0/css/font-awesome.min.css")%>" />

    <link rel="stylesheet" type="text/css" href="<%=ResolveClientUrl("~/PDF Generator/Content/Content_Login/fonts/Linearicons-Free-v1.0.0/icon-font.min.css")%>" />

    <link rel="stylesheet" type="text/css" href="<%=ResolveClientUrl("~/PDF Generator/Content/Content_Login/vendor/animate/animate.css")%>" />

    <link rel="stylesheet" type="text/css" href="<%=ResolveClientUrl("~/PDF Generator/Content/Content_Login/vendor/css-hamburgers/hamburgers.min.css")%>" />
    <link rel="stylesheet" type="text/css" href="<%=ResolveClientUrl("~/PDF Generator/Content/Content_Login/vendor/animsition/css/animsition.min.css")%>" />

    <link rel="stylesheet" type="text/css" href="<%=ResolveClientUrl("~/PDF Generator/Content/Content_Login/vendor/select2/select2.min.css")%>" />

    <link rel="stylesheet" type="text/css" href="<%=ResolveClientUrl("~/PDF Generator/Content/Content_Login/vendor/daterangepicker/daterangepicker.css")%>" />

    <link rel="stylesheet" type="text/css" href="<%=ResolveClientUrl("~/PDF Generator/Content/Content_Login/css/util.css")%>" />
    <link rel="stylesheet" type="text/css" href="<%=ResolveClientUrl("~/PDF Generator/Content/Content_Login/css/main.css")%>" />

    <style type="text/css">
        .body {
            margin:0px;
            padding:0px;
            background-image: url(<%=ResolveClientUrl("~/PDF Generator/Content/Content_Login/images/bg.jpg); ")%>;
            background-repeat:repeat;
        }
    </style>

</head>
<body>

    <form id="form1" runat="server">
        <div class="limiter">
            <div class="container-login100">
                <div class="wrap-login100">
                    <div class="login100-form-title" style="background-image: url(<%=ResolveClientUrl("~/PDF Generator/Content/Content_Login/images/bg-01.jpg); ")%>">
                        <span class="login100-form-title-1">Billing System <br /> Delete Account
                        </span>
                    </div>
                    <div class="login100-form validate-form">
                        <div class="wrap-input100 validate-input m-b-26" data-validate="Username is required">
                            <span class="label-input100">Username</span>
                            <asp:TextBox runat="server" ID="txtUserName" CssClass="input100" placeholder="Enter username"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvUserName" runat="server" ErrorMessage="Enter User Name" ControlToValidate="txtUserName" CssClass="alert-danger" ForeColor="Red" Display="Dynamic" ValidationGroup="delete" SetFocusOnError="true"></asp:RequiredFieldValidator>
                            <%--<input class="input100" type="text" name="username" placeholder="Enter username" />--%>
                            <span class="focus-input100"></span>
                        </div>
                        <div class="wrap-input100 validate-input m-b-18" data-validate="Password is required">
                            <span class="label-input100">Password</span>
                            <asp:TextBox runat="server" ID="txtPassword" CssClass="width" TextMode="Password" MaxLength="12" placeholder="Enter password"></asp:TextBox>
                            <i id="togglePassword" class="fa fa-eye"></i>
                            <asp:RequiredFieldValidator ID="rfvPassword" runat="server" ErrorMessage="Enter Password" ControlToValidate="txtPassword" CssClass="alert-danger" ForeColor="Red" Display="Dynamic" ValidationGroup="delete" SetFocusOnError="true"></asp:RequiredFieldValidator>
                            <asp:CustomValidator ID="csvPassword" runat="server" ControlToValidate="txtPassword" ErrorMessage="Minimum 8 characters required" ClientValidationFunction="MinLength" ForeColor="Red" Display="Dynamic" ValidationGroup="delete" SetFocusOnError="true"></asp:CustomValidator>
                            <%--<input class="input100" type="password" name="pass" placeholder="Enter password" />--%>
                            <span class="focus-input100"></span>
                        </div>

                        <%--//MINIMUM PASSWORD LENGTH SCRIPT--%>
                        <script type="text/javascript">
                            function MinLength(sender, args) {
                                args.IsValid = (args.Value.length >= 8);
                            }
                        </script>

                        <%--//EYE SCRIPT--%>
                        <script type="text/javascript">
                            var togglePassword = document.querySelector('#togglePassword');
                            var password = document.querySelector('#txtPassword');
                            togglePassword.addEventListener('click', function (e) {
                                const type = password.getAttribute('type') === 'password' ? 'text' : 'password';
                                password.setAttribute('type', type);
                                this.classList.toggle('fa-eye-slash');
                            });
                        </script>


                        <div class="wrap-input100 validate-input m-b-26" data-validate="Username is required">
                            <span class="label-input100">Mobile No</span>
                            <asp:TextBox runat="server" ID="txtMobileNo" TextMode="Number" CssClass="input100" onkeypress="return this.value.length<=9" MaxLength="10" placeholder="Enter mobile number"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvMobileNo" runat="server" ErrorMessage="Enter Mobile No" ControlToValidate="txtMobileNo" CssClass="alert-danger" ForeColor="Red" Display="Dynamic" ValidationGroup="delete" SetFocusOnError="true"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="revMobile" runat="server" ErrorMessage="Enter 10 digit mobile no." ControlToValidate="txtMobileNo" CssClass="alert-dark" Display="Dynamic" ForeColor="Red" ValidationExpression="[0-9]{10}" SetFocusOnError="true" ValidationGroup="delete"></asp:RegularExpressionValidator>
                            <%--<input class="input100" type="text" name="username" placeholder="Enter username" />--%>
                            <span class="focus-input100"></span>
                        </div>
                        <div class="flex-sb-m w-full p-b-30">
                            <div class="contact100-form-checkbox">
                                <asp:Label runat="server" ID="lblErrorMessage" EnableViewState="false" ForeColor="#999999"></asp:Label>
                            </div>
                            <div>
                                <asp:HyperLink runat="server" ID="hlForgetPassword" Text="Forget Password?" NavigateUrl="~/PDF Generator/Admin Panel/ForgetPassword.aspx"></asp:HyperLink>
                            </div>
                        </div>
                        <div class="container-login100-form-btn row-cols-1 col-md-12">
                            <asp:Button runat="server" ID="btnDelete" Text="  Delete  " CssClass="login100-form-btn-delete" ValidationGroup="delete" OnClick="btnDelete_Click" />
                            <%--<button class="login100-form-btn">
                                Login
                            </button>--%>
                            <%--<button class="login100-form-btn" style="background-color:#4649b8;">
                                Sign Up
                            </button>--%>
                        </div>
                        <div style="padding-top: 20px; width:100% !important">
                             <hr style="border:0.1px solid gray" />
                        </div>

                        <div style="padding-top: 20px;" class="container-login100-form-btn row-cols-1 col-md-12">
                            <asp:Button runat="server" ID="btnCancelDeleteAccount" Text="Cancel Delete" CssClass="login100-form-btn col-md-4" ValidationGroup="canceldeleteaccount" OnClick="btnCancelDeleteAccount_Click" />
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <script src="<%=ResolveClientUrl("~/PDF Generator/Content/Content_Login/vendor/jquery/jquery-3.2.1.min.js")%>"></script>

        <script src="<%=ResolveClientUrl("~/PDF Generator/Content/Content_Login/vendor/animsition/js/animsition.min.js")%>"></script>

        <script src="<%=ResolveClientUrl("~/PDF Generator/Content/Content_Login/vendor/bootstrap/js/popper.js")%>"></script>
        <script src="<%=ResolveClientUrl("~/PDF Generator/Content/Content_Login/vendor/bootstrap/js/bootstrap.min.js")%>"></script>

        <script src="<%=ResolveClientUrl("~/PDF Generator/Content/Content_Login/vendor/select2/select2.min.js")%>"></script>

        <script src="<%=ResolveClientUrl("~/PDF Generator/Content/Content_Login/vendor/daterangepicker/moment.min.js")%>"></script>
        <script src="<%=ResolveClientUrl("~/PDF Generator/Content/Content_Login/vendor/daterangepicker/daterangepicker.js")%>"></script>

        <script src="<%=ResolveClientUrl("~/PDF Generator/Content/Content_Login/vendor/countdowntime/countdowntime.js")%>"></script>

        <script src="<%=ResolveClientUrl("~/PDF Generator/Content/Content_Login/js/main.js")%>"></script>

        <script async src="https://www.googletagmanager.com/gtag/js?id=UA-23581568-13"></script>
        <script>
            window.dataLayer = window.dataLayer || [];
            function gtag() { dataLayer.push(arguments); }
            gtag('js', new Date());

            gtag('config', 'UA-23581568-13');
        </script>
    </form>

</body>
</html>
