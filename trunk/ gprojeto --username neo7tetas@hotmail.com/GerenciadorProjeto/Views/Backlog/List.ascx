<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<GerenciadorProjeto.Models.BacklogItem>>" %>
<div class="pageActions">
    <p>
        <%= Ajax.ActionLink("Adicionar", "Create", new { ProdutoId = ViewData["ProdutoId"] },
                                                    new AjaxOptions
                                                    {
                                                        HttpMethod = "GET",
                                                        InsertionMode = InsertionMode.Replace,
                                                        UpdateTargetId = "formCreateBackLog",
                                                        LoadingElementId = "carregando"
                                                    })%>
    </p> 
    <div id="formCreateBackLog">
    </div>
</div>                                           
    <% foreach (var item in Model) { %>
    <ul>
        <li id="baklogitens">
            <div class="itemContainer">
                <div class="leftContainer lastContainer">
                    <label title="<%= Html.Encode(item.Nome)%>" >
                        <img src="../../Content/images/ico_userstory.png" alt="ico_userstory"/>
                        <%= Html.Encode(item.Nome)%>
                    </label>       
                </div>
                <ul class="rightContainer">
                    <li>
                        <%= Ajax.ActionLink("Listar tarefas", "List", "BacklogTask", new { BacklogItemId = item.BacklogItemId},
                                                                            new AjaxOptions {   HttpMethod = "GET",
                                                                                                InsertionMode = InsertionMode.Replace,
                                                                                                UpdateTargetId = "container_TaskList_BackLogItem_" + item.BacklogItemId.ToString(),
                                                                                                LoadingElementId = "carregando"
                                                                            },
                                                                            new { Class = "radiusMenu" })%>
                    </li>
                
                    <li>
                        <%= Ajax.ActionLink("Editar", "Edit", "Backlog", new { BacklogItemId = item.BacklogItemId, ProdutoId = ViewData["ProdutoId"] },
                                                                            new AjaxOptions {   HttpMethod = "GET",
                                                                                                InsertionMode = InsertionMode.Replace,
                                                                                                UpdateTargetId = "container_formEdit_BackLogItem_" + item.BacklogItemId.ToString(),
                                                                                                LoadingElementId = "carregando"
                                                                            },
                                                                            new { Class = "radiusMenu" })%>
                    </li>
                    <li>
                        <%= Ajax.ActionLink("Apagar", "Delete", "Backlog", new { BacklogItemId = item.BacklogItemId, ProdutoId = ViewData["ProdutoId"] },
                                                                            new AjaxOptions {   Confirm = "Confirma a deleção??",
                                                                                                HttpMethod = "POST",
                                                                                                InsertionMode = InsertionMode.Replace,
                                                                                                UpdateTargetId = "listBacklog",
                                                                                                LoadingElementId = "carregando"
                                                                            },
                                                                            new { Class = "radiusMenu" })%>
                    </li>
                </ul>
            </div> 
            <div id="container_formEdit_BackLogItem_<%= item.BacklogItemId.ToString() %>">
            </div>                        
            <div id="container_TaskList_BackLogItem_<%= item.BacklogItemId.ToString() %>">              
            </div>                                                                                    
        </li>
    </ul>
    <% } %>


