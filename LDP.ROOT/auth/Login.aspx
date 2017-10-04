<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="LDP.ROOT.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width,initial-scale=1" />
    <link rel="stylesheet" type="text/css" href="https://fonts.googleapis.com/icon?family=Material+Icons" />
    <link rel="stylesheet" type="text/css" href="/assets/CSS/Plugins/bootstrap/bootstrap.css" />
    <link rel="stylesheet" type="text/css" href="/assets/CSS/Plugins/global.css" />
    <link rel="stylesheet" type="text/css" href="/assets/CSS/Site/login.css" />
    <!--if lt IE 9-->
    <script src="assets/js/html5shiv.js"></script>
    <!-- Favicons ==================================================-->
    <asp:PlaceHolder ID="phHeader" runat="server"></asp:PlaceHolder>
</head>
<body>
    <asp:PlaceHolder ID="phBody" runat="server"></asp:PlaceHolder>
    <form id="form1" runat="server">
        <section class="loginbody">
            <div class="container login-container">
                <div class="loginbox text-center box effect7 pd20">
                    <img src="/data/img/logo-login.jpg" alt="Logo" height="90" class="mrb15">
                    <div class="login-box row">
                            <div class="col-md-12">
                                <div class="form-group label-floating">
                                    <label class="control-label">Tên truy cập</label>
                                    <asp:TextBox ID="UserName" required="true" runat="server" CssClass="form-control" AutoCompleteType="Disabled"></asp:TextBox>
                                </div>
                            </div>
                       
                            <div class="col-md-12">
                                <div class="form-group label-floating">
                                    <label class="control-label">Mật khẩu</label>
                                    <asp:TextBox ID="Password" required="true" runat="server" CssClass="form-control" TextMode="Password" AutoCompleteType="Disabled"></asp:TextBox>
                                </div>
                            </div>
                       
                            <div class="col-md-12 text-center">
                                <asp:Button ID="btnLogin" runat="server" CssClass="login-buttonbtn btn btn-danger" Text="Đăng nhập" OnClick="btnLogin_Click" />
                            </div>
                        <div class="col-md-12 message error pdt15">
                            <asp:Literal ID="ltrError" runat="server"></asp:Literal>
                        </div>
                    </div>
                </div>

            </div>
        </section>
    </form>
</body>
<script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.1/jquery.min.js"></script>
<script src="/assets/JS/Plugins/material.min.js"></script>
    <script>
        $(document).ready(function () {
            $.material.init();
        });
    </script>
</html>
