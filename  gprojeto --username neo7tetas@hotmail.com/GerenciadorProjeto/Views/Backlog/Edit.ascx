<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<GerenciadorProjeto.Models.BacklogItem>" %>
<div class="innerContainer">
    <% using (Ajax.BeginForm("Edit", "Backlog", new AjaxOptions
       {
           HttpMethod = "POST",
           InsertionMode = InsertionMode.Replace,
           UpdateTargetId = "listBacklog",
           LoadingElementId = "carregando"
       }))
       {%>

        <fieldset>
            <legend>Editando BacklogItem</legend>
                <%= Html.Hidden("ProdutoId", ViewData["ProdutoId"]) %>
                <%= Html.Hidden("BacklogItemId", Model.BacklogItemId)%>
            <p>
                <label for="Nome">Nome:</label>
                <%= Html.TextBox("Nome", Model.Nome) %>
            </p>
            <p>
                <label for="Nota">Nota:</label>
                <%= Html.TextArea("Nota", Model.Nota)%>
            </p>
            <p>
                <label for="Estimativa">Estimativa:</label>
                <%= Html.TextBox("Estimativa", String.Format("{0:F}", Model.Estimativa)) %>
            </p>
            <p>
                <input type="submit" value="Atualizar" />
                <%= Ajax.ActionLink("Cancelar", "List", new { ProdutoId = ViewData["ProdutoId"] }, 
                                                        new AjaxOptions
                                                        {
                                                            InsertionMode = InsertionMode.Replace,
                                                            UpdateTargetId = "listBacklog",
                                                            LoadingElementId = "carregando"
                                                        })%>                                
            </p>
        </fieldset>
    <% } %>

