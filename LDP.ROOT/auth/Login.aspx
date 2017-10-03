<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="LDP.ROOT.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width,initial-scale=1" />
    <asp:Literal ID="ltrMeta" runat="server"></asp:Literal>
    <link rel="stylesheet" type="text/css" href="https://fonts.googleapis.com/icon?family=Material+Icons" />
    <link rel="stylesheet" type="text/css" href="/assets/CSS/Site/site.css" />
    <!--if lt IE 9-->
    <script src="assets/js/html5shiv.js"></script>
    <!-- Favicons ==================================================-->
    <asp:PlaceHolder ID="phHeader" runat="server"></asp:PlaceHolder>
</head>
<body>
    <asp:PlaceHolder ID="phBody" runat="server"></asp:PlaceHolder>
    <form id="form1" runat="server">
        <section class="body">
            <div class="logo-brand text-center">
                <img src="/data/img/logo-admin.png" class="" alt="LOGO">
            </div>
            <div class="warper login-warper">
                <div class="login-fieldset">
                    <div class="legend text-center text-16px uppercase">
                        Đăng nhập
                    </div>

                    <div class="login-box row">
                        <div class="col-sm-12 col-xs-12 pdb10 form-group">
                            <i class="icon fa fa-user"></i>
                            <input name="UserName" type="text" maxlength="100" id="UserName" class="form-control" placeholder="Tên truy cập" runat="server" />
                        </div>
                        <div class="col-sm-12 col-xs-12 pdb10 form-group">
                            <i class="icon fa fa-lock"></i>
                            <input name="Password" type="password" id="Password" class="form-control" placeholder="Mật khẩu" runat="server" />
                        </div>
                        <div class="col-sm-12 col-xs-12 pdb10 form-group">
                            <span class="spctrlogin">
                                <i class="fa fa-arrow-right"></i>
                            </span>
                            <span class='login-button-wrapper'>
                                <asp:Button ID="btnLogin" runat="server" CssClass="login-buttonbtn btn-primary" Text="Đăng nhập" OnClick="btnLogin_Click" />
                            </span>
                        </div>
                    </div>

                </div>
                <div class="text-center">
                    <asp:Literal ID="ltrError" runat="server"></asp:Literal></div>
            </div>
        </section>
    </form>
</body>
<script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.1/jquery.min.js"></script>
<asp:placeholder id="phFooter" runat="server"></asp:placeholder>
</html>
