<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<GerenciadorProjeto.Models.Sprint>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Backlog
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div id="content">
    
        <h1>Product Backlog</h1> 
        <div id="listProductBackLog">
            <%Html.RenderAction("SprintBackLogList", "Sprint", new { SprintId = Model.SprintId}); %>
        </div>                   
    
        <h1>Sprint BackLog</h1> 
        <div id="listSprintBackLog">
            <%Html.RenderAction("SprintBackLogList", "Sprint", new { SprintId = Model.SprintId}); %>
        </div>                   
    </div>
</asp:Content>
