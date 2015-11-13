<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="CalendarTracking.Register" %>

<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        body
        {
            background-color:#242424;
        }
        h1
        {
            color:white;
            position:relative;
            font-size:60px;
            top: 17px;
            left: 155px;
            width: 390px;
        }
        #username
        {
            border: 3px solid white;
            position:relative;
            top: 38px;
            left: 171px;
            height: 85px;
            width: 273px;
            }
        #username_field
        {
            position:relative;
            top: 45px;
            left: 18px;
            height: 23px;
            width: 240px;
        }
        #username_label
        {
            position:relative;
            top: -14px;
            left: 18px;
            width: 239px;
            color:white;
        }
        #password
        {
            border: 3px solid white;
            position:relative;
            top: 55px;
            left: 170px;
            height: 174px;
            width: 275px;
            }
        #password_label
        {
            position:relative;
            top: 13px;
            left: 20px;
            width: 189px;
            color:white;
        }
        #password_field
        {
            position:relative;
            top: 24px;
            left: 19px;
            width: 236px;
        }
        #confirmPassword_label
        {
            position:relative;
            top: 60px;
            left: 19px;
            width: 158px;
            color:white;
        }
        #confirmPassword_field
        {
            position:relative;
            top: 71px;
            left: 19px;
            width: 234px;
        }
        #register_button
        {
            position:relative;
            top: 67px;
            left: 356px;
            width: 96px;
            height: 31px;
        }
        #username_error
        {
            position:relative;
            top: -212px;
            left: 458px;
            width: 156px;
            color:lightsalmon
        }
        #password_error
        {
            position:relative;
            top: -125px;
            left: 454px;
            width: 196px;
            color:lightsalmon;
        }
        #confirm_password_error
        {
            position:relative;
            color:lightsalmon;
            top: -54px;
            left: 457px;
            width: 213px;
        }
        #form1 {
            height: 91px;
        }
    </style>

</head>
<body>
    <form id="form1" runat="server">
        <div id="myHeader">
            <h1>
                Registration
            </h1>
        </div>
        <div id="username">
            <div id="username_field">
                <telerik:RadTextBox ID="username_textbox" Runat="server" Height="17px" Width="242px">
                </telerik:RadTextBox>
            </div>
            <div id="username_label">
                <asp:Label ID="Label1" runat="server" Text="Requested Username"></asp:Label>
            </div>
        </div>
        <div id="password">
            <div id="password_label">
                <asp:Label ID="Label2" runat="server" Text="Password"></asp:Label>
            </div>
            <div id="password_field">
                <telerik:RadTextBox ID="password_textbox" Runat="server" Height="18px" Width="240px" TextMode="Password">
                    <emptymessagestyle resize="None" />
                    <readonlystyle resize="None" />
                    <focusedstyle resize="None" />
                    <disabledstyle resize="None" />
                    <invalidstyle resize="None" />
                    <hoveredstyle resize="None" />
                    <enabledstyle resize="None" />
                </telerik:RadTextBox>
            </div>
            <div id="confirmPassword_label">
                <asp:Label ID="Label3" runat="server" Text="Confirm Password"></asp:Label>
            </div>
            <div id="confirmPassword_field">
                <telerik:RadTextBox ID="confirm_password_textbox" Runat="server" Height="18px" Width="240px" TextMode="Password">
                </telerik:RadTextBox>
            </div>
        </div>
        <div id="register_button">
            <telerik:RadButton ID="RadButton1" runat="server" Height="28px" style="top: 0px; left: 0px" Text="Register" Width="90px" OnClick="RadButton1_Click">
            </telerik:RadButton>
        </div>
        <div id="username_error">

            <asp:Label ID="username_error_label" runat="server"></asp:Label>

        </div>
        <div id="password_error">
            <asp:Label ID="password_error_label" runat="server"></asp:Label>
        </div>
        <div id="confirm_password_error">
            <asp:Label ID="confirm_password_error_label" runat="server"></asp:Label>
        </div>
        <telerik:RadScriptManager ID="RadScriptManager1" Runat="server">
        </telerik:RadScriptManager>
    </form>
</body>
</html>
