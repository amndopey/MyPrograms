<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="MyPrograms._default_mobile" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta content='width=device-width, initial-scale=1, maximum-scale=1' name='viewport'/>
    <link rel="stylesheet" href="/CSS/Mobile_Default.css" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div id="Welcome">
        Welcome to our mobile site
    </div>
    <div id="login_link">
        Please 
        <asp:LinkButton ID="LinkButton1" runat="server" PostBackUrl="~/Login.aspx">tap here</asp:LinkButton>
         to log in
    </div>
    </form>
</body>
</html>