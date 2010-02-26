<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<GerenciadorProjeto.Models.BacklogItem>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div id="content">
        <h1>Backlog</h1>    
        <div id="listBacklog">
            <% Html.RenderPartial("List"); %>
        </div>        
    </div>
</asp:Content>

