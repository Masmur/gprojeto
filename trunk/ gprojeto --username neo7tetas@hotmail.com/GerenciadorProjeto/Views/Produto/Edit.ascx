<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<GerenciadorProjeto.Models.Produto>" %>
<div class="innerContainer">
    <% using (Ajax.BeginForm("Edit", "Produto", new { ProdutoId = Model.ProdutoId }, new AjaxOptions
       {
           HttpMethod = "POST",
           InsertionMode = InsertionMode.Replace,
           UpdateTargetId = "listProduto",
           LoadingElementId = "carregando"
       }))
       {%>

        <fieldset>
            <legend>Editar Produto</legend>
                <%= Html.Hidden("EmpresaId", ViewData["EmpresaId"])%>
            <p>
                <label for="Nome">Nome:</label>
                <%= Html.TextBox("Nome", Model.Nome)%>
            </p>
            <p>
                <input type="submit" value="Atualizar" />
                <%= Ajax.ActionLink("Cancelar", "List", new AjaxOptions { InsertionMode = InsertionMode.Replace, UpdateTargetId = "listProduto" })%>                
            </p>
        </fieldset>

    <% } %>
</div>
