<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<GerenciadorProjeto.Models.Produto>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Details
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<div id="menu-interno">
    <div id="sub-menu">
        <ul>
            <li class = "active"><%=Html.ActionLink("Visão Geral", "Details", new { EmpresaId = Model.ProdutoId }, new { Class = "active" })%> |</li>
            <li><%=Html.ActionLink("Backulog", "Backlog", new { id = Model.ProdutoId })%></li>
        </ul>
    </div>
</div>

</asp:Content>

