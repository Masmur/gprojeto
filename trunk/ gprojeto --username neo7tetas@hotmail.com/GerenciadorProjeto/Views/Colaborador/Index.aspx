<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<GerenciadorProjeto.Models.Colaborador>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div id="content">
        <h1>Colaboradores</h1>    
        <div id="listColaborador">
            <% Html.RenderPartial("List"); %>
        </div>        
    </div>
</asp:Content>

