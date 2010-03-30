<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<GerenciadorProjeto.Models.BacklogTask>" %>
<div class="outerContainer">
    <% using (Ajax.BeginForm("Create", "BacklogTask", new AjaxOptions
       {
           HttpMethod = "POST",
           InsertionMode = InsertionMode.Replace,
           UpdateTargetId = "container_TaskList_BackLogItem_" + ViewData["BacklogItemId"],
           LoadingElementId = "carregando"
       }))
       {%>
        <fieldset>
            <legend>Adicionar Tarefa</legend>
                <%= Html.Hidden("BacklogItemId", ViewData["BacklogItemId"])%>                            
            <p>
                <label for="Nome">Nome:</label>
                <%= Html.TextBox("Nome") %>
            </p>
            <p>
                <label for="Estimativa">Estimativa:</label>
                <%= Html.TextBox("Estimativa") %>
            </p>
            <p>
                <input type="submit" value="Adicionar" />
                <%= Ajax.ActionLink("Cancelar", "List", "BacklogTask", new { BacklogItemId = ViewData["BacklogItemId"] }, 
                                                        new AjaxOptions         {
                                                                                    InsertionMode = InsertionMode.Replace,
                                                                                    UpdateTargetId = "container_TaskList_BackLogItem_" + ViewData["BacklogItemId"],
                                                                                    LoadingElementId = "carregando"
                                                                                })%>                
                
            </p>
        </fieldset>

    <% } %>
</div>
