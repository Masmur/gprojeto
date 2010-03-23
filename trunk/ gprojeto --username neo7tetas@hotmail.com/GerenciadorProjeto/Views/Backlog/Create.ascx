<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<GerenciadorProjeto.Models.BacklogItem>" %>
<div class="outerContainer">
    <% using (Ajax.BeginForm("Create","Backlog", new AjaxOptions
       {
           HttpMethod = "POST",
           InsertionMode = InsertionMode.Replace,
           UpdateTargetId = "listBacklog",
           LoadingElementId = "carregando"
       }))
       {%>
        <fieldset>
            <legend>Adicionar item ao Backlog</legend>
            <p>
                <%= Html.Hidden("ProdutoId", ViewData["ProdutoId"]) %>
                <label for="Nome">Nome:</label>
                <%= Html.TextBox("Nome") %>
            </p>
            <p>
                <label for="Nota">Nota:</label>
                <%= Html.TextArea("Nota") %>
            </p>
            <p>
                <label for="Estimativa">Estimativa:</label>
                <%= Html.TextBox("Estimativa") %>
            </p>
            <p>
                <input type="submit" value="Adicionar" />
                <%= Ajax.ActionLink("Cancelar", "List", new { ProdutoId = ViewData["ProdutoId"] }, 
                                                        new AjaxOptions         {
                                                                                    InsertionMode = InsertionMode.Replace,
                                                                                    UpdateTargetId = "listBacklog",
                                                                                    LoadingElementId = "carregando"
                                                                                })%>                
            </p>
        </fieldset>

    <% } %>
</div>