<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<GerenciadorProjeto.Models.BacklogItem>" %>
    <% using (Ajax.BeginForm("Create","Backlog", new AjaxOptions
       {
           HttpMethod = "POST",
           InsertionMode = InsertionMode.Replace,
           UpdateTargetId = "listBacklog"
       }))
       {%>
        <fieldset>
            <legend>Adicionar item ao Backlog</legend>
            <p>
                <%= Html.Hidden("ProdutoId", ViewData["ProdutoId"]) %>
                <label for="Nome">Nome:</label>
                <%= Html.TextBox("Nome") %>
                <%= Html.ValidationMessage("Nome", "*") %>
            </p>
            <p>
                <label for="Nota">Nota:</label>
                <%= Html.TextBox("Nota") %>
                <%= Html.ValidationMessage("Nota", "*") %>
            </p>
            <p>
                <label for="Estimativa">Estimativa:</label>
                <%= Html.TextBox("Estimativa") %>
                <%= Html.ValidationMessage("Estimativa", "*") %>
            </p>
            <p>
                <input type="submit" value="Adicionar" />
                <%= Ajax.ActionLink("Cancelar", "List", new { ProdutoId = ViewData["ProdutoId"]}, new AjaxOptions { InsertionMode = InsertionMode.Replace, UpdateTargetId = "listBacklog" })%>                
            </p>
        </fieldset>

    <% } %>


