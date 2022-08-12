<%@ Page Language="C#" AutoEventWireup="true" CodeFile="default.aspx.cs"  EnableEventValidation="false"  Inherits="_Default" %>
<!doctype html>
<html lang="en">

    <head>
        <meta charset="utf-8" />
        <title>Kriptone - Admin Control Panel</title>
        <meta name="viewport" content="width=device-width, initial-scale=1.0">
        <meta content="Kriptone" name="description" />
        <meta content="Themesdesign" name="author" />
        <!-- App favicon -->
        <link rel="shortcut icon" href="assets/images/favicon.png">

        <!-- Bootstrap Css -->
        <link href="assets/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
        <!-- Icons Css -->
        <link href="assets/css/icons.min.css" rel="stylesheet" type="text/css" />
        <!-- App Css-->
        <link href="assets/css/app.min.css" rel="stylesheet" type="text/css" />
        <link href="../assets/libs/toast/toast.css" rel="stylesheet" type="text/css" />
         <style>
            .bg-primary {
    background-color: #2e3859 !important;
}    input#btnLogin {
            background: grey;
            border: grey;
            border-radius: 30px;
        }
        </style>
    </head>
     <script type="text/javascript">
         var statusMsg = '<%=tclib.StatusMsg()%>';
    var statusType = '<%=tclib.StatusType()%>';
         statusType = statusType.toLowerCase();
     </script>
<%
    tclib.Toast(null, null);
%>
    <body class="bg-primary bg-pattern">
        <form runat="server">
            <div class="statusMain"></div>
        <%--<div class="home-btn d-none d-sm-block">
            <a href="login"><i class="mdi mdi-home-variant h2 text-white"></i></a>
        </div>--%>

        <div class="account-pages my-5 pt-sm-5">
            <div class="container">
                <div class="row">
                    <div class="col-lg-12">
                        <div class="text-center mb-5">
                            
                            <h5 class="font-size-16 text-white-50 mb-4">Kriptone - Admin Control Panel</h5>
</div>
                    </div>
                </div>
                <!-- end row -->

                <div class="row justify-content-center">
                    <div class="col-xl-5 col-sm-8">
                        <div class="card">
                            <div class="card-body p-4">
                                <div class="p-2">
                                    <h5 class="mb-5 text-center">Login in to Kriptone</h5>
                                    <form class="form-horizontal" action="login">

                                        <div class="row">
                                            <div class="col-md-12">
                                                <div class="form-group form-group-custom mb-4">
                                                    <asp:TextBox runat="server" placeholder="Username" class="form-control" ID="txtUsername"></asp:TextBox>
                                                </div>

                                                <div class="form-group form-group-custom mb-4">
                                                    <asp:TextBox runat="server" placeholder="Password" class="form-control" ID="txtPassword" TextMode="Password"></asp:TextBox>
                                                </div>

                                                <div class="row">
                                                    <div class="col-md-6">
                                                        <div class="custom-control custom-checkbox">
                                                            <input type="checkbox" class="custom-control-input" id="customControlInline">
                                                        </div>
                                                    </div>
                                                   
                                                </div>
                                                <div class="mt-4">
                                                    <asp:Button runat="server" CssClass="btn btn-success btn-block waves-effect waves-light" ID="btnLogin" OnClick="btnLogin_Click" type="submit" Text="Log In" />
                                                </div>
                                               
                                            </div>
                                        </div>
                                    </form>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <!-- end row -->
            </div>
        </div>
        <!-- end Account pages -->

        <!-- JAVASCRIPT -->
        <script src="assets/libs/jquery/jquery.min.js"></script>
        <script src="assets/libs/bootstrap/js/bootstrap.bundle.min.js"></script>
        <script src="assets/libs/metismenu/metisMenu.min.js"></script>
        <script src="assets/libs/simplebar/simplebar.min.js"></script>
        <script src="assets/libs/node-waves/waves.min.js"></script>

        <script src="https://unicons.iconscout.com/release/v2.0.1/script/monochrome/bundle.js"></script>

        <script src="assets/js/app.js"></script>
            <script src="../assets/libs/toast/toast.js"></script>
</form>
    </body>
</html>
