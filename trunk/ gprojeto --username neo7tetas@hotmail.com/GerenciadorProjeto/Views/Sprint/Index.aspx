<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<GerenciadorProjeto.Models.Sprint>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div id="content">
        <h1>Sprints</h1>    
        <div id="listSprint">
            <% Html.RenderPartial("List"); %>
        </div>        
    </div>
</asp:Content>

