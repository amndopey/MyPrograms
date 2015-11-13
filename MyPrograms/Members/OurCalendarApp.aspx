<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OurCalendarApp.aspx.cs" MasterPageFile="~/Members/Site1.Master" Inherits="MyPrograms.Members.OurCalendarApp" %>

<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <style type="text/css">
body { background-color: #999999; }
#Controls
{
    position:relative;
    left:200px;
}
</style>
</asp:Content>
<asp:Content ID="HeaderTitle" ContentPlaceHolderID="HeaderText" runat="server">Calendar App</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <!DOCTYPE html>

        <div id="Calendar">
            
            <telerik:RadScriptManager ID="RadScriptManager1" Runat="server">
            </telerik:RadScriptManager>
            
            <telerik:RadCalendar ID="RadCalendar1" SkinID="Glow" Width="800"  Height="400" Runat="server" EnableMultiSelect="False" EnableWeekends="True" FastNavigationNextText="&amp;lt;&amp;lt;" OnDayRender="RadCalendar1_DayRender" SelectedDate="" Skin="Glow" DayStyle-BorderColor="Gray" DayStyle-BorderStyle="Solid" DayStyle-BorderWidth="1px">
<DayStyle BorderColor="Gray" BorderWidth="1px" BorderStyle="Solid"></DayStyle>

<WeekendDayStyle CssClass="rcWeekend"></WeekendDayStyle>

<CalendarTableStyle CssClass="rcMainTable"></CalendarTableStyle>

<OtherMonthDayStyle CssClass="rcOtherMonth"></OtherMonthDayStyle>

<OutOfRangeDayStyle CssClass="rcOutOfRange"></OutOfRangeDayStyle>

<DisabledDayStyle CssClass="rcDisabled"></DisabledDayStyle>

<SelectedDayStyle CssClass="rcSelected"></SelectedDayStyle>

<DayOverStyle CssClass="rcHover"></DayOverStyle>

<FastNavigationStyle CssClass="RadCalendarMonthView RadCalendarMonthView_Glow"></FastNavigationStyle>

<ViewSelectorStyle CssClass="rcViewSel"></ViewSelectorStyle>
            </telerik:RadCalendar>
    <div id="Controls">
            <br />
&nbsp;&nbsp;
            &nbsp; Start Time&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Minutes for lunch<br />
            &nbsp;
            <asp:DropDownList ID="DropDownList2" runat="server">
            </asp:DropDownList>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:DropDownList ID="DropDownList4" runat="server">
            </asp:DropDownList>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Set" />
            <br />
            <br />
            &nbsp;&nbsp;&nbsp; End Time<br />
            &nbsp;
            <asp:DropDownList ID="DropDownList3" runat="server">
            </asp:DropDownList>
&nbsp;&nbsp;&nbsp;&nbsp;Hours remaining:
            <asp:Label ID="Label2" runat="server"></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button2" runat="server" Height="26px" OnClick="Button2_Click" Text="Clear" Width="58px" />
            <br />
            <br />
            <br />
        </div>
            <div style="width: 314px">

            Status: <asp:Label ID="tempLabel" runat="server"></asp:Label>
            <br />
        </div>
            </div>
    </asp:Content>
