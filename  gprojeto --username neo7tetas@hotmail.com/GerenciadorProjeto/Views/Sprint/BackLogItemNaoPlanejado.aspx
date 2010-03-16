<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<GerenciadorProjeto.Models.Sprint>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	BackLogItemNaoPlanejado
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div id="content">  
        <h1>Itens não planejados</h1>           
        <div id="listProduct">
            <%Html.RenderAction("ListProduto", "Sprint", new { EmpresaId = Model.EmpresaId, SprintId = ViewData["SprintId"] }); %>
        </div>
    </div>                   
</asp:Content>

