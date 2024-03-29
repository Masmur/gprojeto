<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<GerenciadorProjeto.Models.Produto>" %>
<div class="outerContainer">
    <% using (Ajax.BeginForm("Create","Produto", new AjaxOptions
       {
           HttpMethod = "POST",
           InsertionMode = InsertionMode.Replace,
           UpdateTargetId = "listProduto",
           LoadingElementId = "carregando"
       }))
       {%>

        <fieldset>
            <legend>Adicionar Produto</legend>
                <%= Html.Hidden("EmpresaId", ViewData["EmpresaId"])%>
            <p>
                <label for="Nome">Nome:</label>
                <%= Html.TextBox("Nome")%>
            </p>
            <p>
                <input type="submit" value="Adicionar" />
                <%= Ajax.ActionLink("Cancelar", "List", new AjaxOptions { InsertionMode = InsertionMode.Replace, UpdateTargetId = "listProduto" })%>
            </p>
        </fieldset>

    <% } %>
</div>


