<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="PDF_Generator_Admin_Panel_Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>

    <%--<link href="~/bootstrap-4.5.2-dist/css/bootstrap.min.css" rel="stylesheet" />
    <link href="~/bootstrap-4.5.2-dist/css/bootstrap-theme.min.css" rel="stylesheet" />
    <script src="~/bootstrap-4.5.2-dist/js/bootstrap.min.js"></script>--%>


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
        .width {
            width: 92% !important;
            font-family: Poppins-Regular;
            font-size: 15px;
            color: #555;
            line-height: 2.7;
            background: 0 0;
            padding: 0 5px
        }

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
                        <span class="login100-form-title-1">Sign In
                        </span>
                    </div>
                    <div class="login100-form validate-form">
                        <div class="wrap-input100 validate-input m-b-26" data-validate="Username is required">
                            <span class="label-input100">Username</span>
                            <asp:TextBox runat="server" ID="txtUserName" CssClass="input100" placeholder="Enter username"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvUserName" runat="server" ErrorMessage="Enter User Name" ControlToValidate="txtUserName" CssClass="alert-danger" ForeColor="Red" Display="Dynamic" ValidationGroup="login" SetFocusOnError="true"></asp:RequiredFieldValidator>
                            <%--<input class="input100" type="text" name="username" placeholder="Enter username" />--%>
                            <span class="focus-input100"></span>
                        </div>

                        <div class="wrap-input100 validate-input m-b-18" data-validate="Password is required">
                            <span class="label-input100">Password</span>
                            <asp:TextBox runat="server" ID="txtPassword" CssClass="width" TextMode="Password" MaxLength="12" placeholder="Enter password"></asp:TextBox>
                            <i id="togglePassword" class="fa fa-eye"></i>
                            <asp:RequiredFieldValidator ID="rfvPassword" runat="server" ErrorMessage="Enter Password" ControlToValidate="txtPassword" CssClass="alert-danger" ForeColor="Red" Display="Dynamic" ValidationGroup="login" SetFocusOnError="true"></asp:RequiredFieldValidator>
                            <asp:CustomValidator ID="csvPassword" runat="server" ControlToValidate="txtPassword" ErrorMessage="Minimum 8 characters required" ClientValidationFunction="MinLength" ForeColor="Red" Display="Dynamic" ValidationGroup="login" SetFocusOnError="true"></asp:CustomValidator>
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


                        <div class="flex-sb-m w-full p-b-30">
                            <div class="contact100-form-checkbox">
                                <asp:Label runat="server" ID="lblErrorMessage" EnableViewState="false" ForeColor="#999999"></asp:Label>
                            </div>
                            <div>
                                <asp:HyperLink runat="server" ID="hlForgetPassword" CssClass="txt1" Text="Forget Password?" NavigateUrl="~/PDF Generator/Admin Panel/ForgetPassword.aspx"></asp:HyperLink>
                            </div>
                        </div>
                        <div class="container-login100-form-btn row-cols-1 col-md-12">
                            <asp:Button runat="server" ID="btnLogin" Text="  Login  " CssClass="login100-form-btn col-md-4" ValidationGroup="login" OnClick="btnLogin_Click" />
                            <%--<button class="login100-form-btn">
                                Login
                            </button>--%>
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Button runat="server" ID="btnSignUP" Text=" Sign UP " CssClass="login100-form-btn col-md-4 float-right" Style="background-color: #4649b8;" ValidationGroup="signup" OnClick="btnSignUP_Click" />
                            <%--<button class="login100-form-btn" style="background-color:#4649b8;">
                                Sign Up
                            </button>--%>
                        </div>
                        <div style="padding-top: 20px;">
                            <asp:HyperLink runat="server" ID="hlCreateAccount" CssClass="txt1" Text="Create Account" NavigateUrl="~/PDF Generator/Admin Panel/CreateAccount.aspx"></asp:HyperLink><br />

                            <asp:HyperLink runat="server" ID="hlDeleteAccount" CssClass="txt1" Text="Delete Account" NavigateUrl="~/PDF Generator/Admin Panel/DeleteAccount.aspx"></asp:HyperLink><br />
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




        <%--<script async src="https://www.googletagmanager.com/gtag/js?id=UA-23581568-13"></script>--%>
        <script>
            window.dataLayer = window.dataLayer || [];
            function gtag() { dataLayer.push(arguments); }
            gtag('js', new Date());

            gtag('config', 'UA-23581568-13');
        </script>
    </form>
</body>
</html>
