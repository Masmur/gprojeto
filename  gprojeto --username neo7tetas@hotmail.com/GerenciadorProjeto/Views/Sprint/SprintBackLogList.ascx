<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<GerenciadorProjeto.Models.vSprintBackLog>>" %>
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
                        <%= Html.Encode(item.Nome)%>
                    </label>       
                </div>
                <ul class="rightContainer">
                    <li>
                        <%= Ajax.ActionLink("Remover", "Remove", "Sprint", new { BacklogItemId = item.BacklogItemId, ProdutoId = ViewData["ProdutoId"] },
                                                                            new AjaxOptions {   Confirm = "Confirma a dele��o??",
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
        </li>
    </ul>
    <% } %>
