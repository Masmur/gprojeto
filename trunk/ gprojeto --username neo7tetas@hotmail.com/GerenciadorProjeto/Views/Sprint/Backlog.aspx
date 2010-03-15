<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<GerenciadorProjeto.Models.Sprint>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Backlog
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div id="content">
        <h1>Sprint BackLog</h1> 
        <div id="listSprintBackLog">
        </div>                   
    </div>
</asp:Content>
