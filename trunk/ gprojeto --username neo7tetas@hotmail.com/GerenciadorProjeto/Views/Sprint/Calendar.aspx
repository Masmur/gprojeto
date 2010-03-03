<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Calendar
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div id="content">
        <h1>Calendario
        </h1>    
        <div id="calendario">
            <!---
            <asp:Calendar ID="Calendar1" BorderStyle="None" CellPadding="0" 
                CellSpacing="4" CssClass="calendar" DayNameFormat="Full" EnableTheming="False" 
                EnableViewState="False" UseAccessibleHeader="False">
                <SelectedDayStyle BorderStyle="None" CssClass="day date" />
                <SelectorStyle BorderStyle="None" />
                <WeekendDayStyle BorderStyle="Solid" CssClass="day non-commercial date" />
                <TodayDayStyle BorderStyle="Solid" CssClass="day date" />
                <OtherMonthDayStyle BorderStyle="Solid" 
                    CssClass="day non-commercial other_month date" Wrap="True" />
                <DayStyle BorderStyle="Solid" CssClass="day date" />
                <NextPrevStyle BorderStyle="None" />
                <DayHeaderStyle BorderStyle="None" />
                <TitleStyle BorderStyle="None" Font-Bold="False" Font-Italic="False" 
                    Font-Underline="False" />
            </asp:Calendar>            
            --->
        </div>        
    </div>
</asp:Content>
