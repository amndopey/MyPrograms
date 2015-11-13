<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="MyPrograms.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="/CSS/Main_Stylesheet.css" />
</head>
<body>
    <form id="form1" runat="server">
    <div id="Welcome">
        Welcome to our website
    </div>
    <div id="login_link">
        Please 
        <asp:LinkButton ID="LinkButton1" runat="server" PostBackUrl="~/Login.aspx">click here</asp:LinkButton>
         to log in
    </div>
    </form>
</body>
</html>
