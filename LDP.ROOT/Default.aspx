<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="LDP.ROOT.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width,initial-scale=1" />
    <title>LDP</title>

    <!--if lt IE 9-->
    <script src="assets/js/html5shiv.js"></script>
    <!-- Favicons ==================================================-->
</head>
<body>
    <form id="form1" runat="server">
        <asp:PlaceHolder ID="phContentHeader"  runat="server" ></asp:PlaceHolder> <%--ContainerGuid="f50432a6-0000-43a7-a68f-ca088f05af7b"--%>
        <asp:PlaceHolder ID="phContentTop" runat="server" ></asp:PlaceHolder>  <%--ContainerGuid="ecf1d679-58ad-44cc-84b4-62c28cd6a280"--%>           
        <asp:PlaceHolder ID="phContentLeft" runat="server" ></asp:PlaceHolder> <%--ContainerGuid="7ee0f082-2a27-4075-a184-d04e18bc6ae0"--%>
        <asp:PlaceHolder ID="phContentRight" runat="server" ></asp:PlaceHolder> <%--ContainerGuid="a2336516-70b3-4891-889b-73ee828f6f91"--%>
        <asp:PlaceHolder ID="phContentBottom" runat="server" ></asp:PlaceHolder> <%--ContainerGuid="41d0db21-312f-4249-8b7d-20badf52f1b0"--%>
        <asp:PlaceHolder ID="phContentFooter" runat="server" ></asp:PlaceHolder> <%--ContainerGuid="72086953-fe1f-48fe-819a-866e5fb9473b"--%>
    </form>
</body>
<script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.1/jquery.min.js"></script>

</html>
