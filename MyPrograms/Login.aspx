<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="MyPrograms.Login" %>

<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta content='width=device-width, initial-scale=1' name='viewport'/>
    <title>Login Page</title>
    <link rel="stylesheet" href="/CSS/Login.css" />

    </head>

    <body>
        <form id="form1" runat="server" defaultfocus="username_textbox">
                <telerik:RadScriptManager ID="RadScriptManager1" Runat="server">
                </telerik:RadScriptManager>
            <div id="Login_Label">
                <asp:Label ID="Label4" runat="server" Text="Log In"></asp:Label>
            </div>
            <div id="input_fields">
                <asp:Label ID="Label1" runat="server" Text="Username: "></asp:Label>
                <telerik:RadTextBox ID="username_textbox" runat="server"></telerik:RadTextBox>
                <asp:RequiredFieldValidator ID="Username_Validator" runat="server" ControlToValidate="username_textbox" ErrorMessage="Username Required" ForeColor="Red">*</asp:RequiredFieldValidator>
                <br />
                <br />
                <asp:Label ID="Label2" runat="server" Text="Password:   "></asp:Label>
                <telerik:RadTextBox ID="password_textbox" runat="server" TextMode="Password" style="margin-left: 2px" Width="160px"></telerik:RadTextBox>

                <asp:RequiredFieldValidator ID="Password_Validator" runat="server" ControlToValidate="password_textbox" ErrorMessage="Password Required" ForeColor="Red">*</asp:RequiredFieldValidator>

                <div id="Login_Button">
                    <telerik:RadButton ID="RadButton1" runat="server" Text="Log in" OnClick="RadButton1_Click"></telerik:RadButton>
                </div>
                <div id="Register">
                    <asp:Label ID="Label3" runat="server" Text="Don't have a login? "></asp:Label>
                    <asp:LinkButton ID="LinkButton1" runat="server" PostBackUrl="~/Register.aspx">Register</asp:LinkButton>
                </div>

            </div>
            <div id="status">
                <asp:Label ID="statusLabel" runat="server"></asp:Label>
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
            </div>
        </form>
    </body>
</html>