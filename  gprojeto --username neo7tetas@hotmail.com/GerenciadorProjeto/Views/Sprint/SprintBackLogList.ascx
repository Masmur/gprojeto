<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<GerenciadorProjeto.Models.vSprintBackLog>>" %>
<div class="pageActions">
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
                        <%= Ajax.ActionLink("Remover", "RemoverBackLogItem", "Sprint", new { BacklogItemId = item.BacklogItemId, SprintId = item.SprintId },
                                                                            new AjaxOptions {   Confirm = "Confirma a remoção??",
                                                                                                HttpMethod = "POST",
                                                                                                InsertionMode = InsertionMode.Replace,
                                                                                                UpdateTargetId = "listSprintBackLog",
                                                                                                LoadingElementId = "carregando"
                                                                            },
                                                                            new { Class = "radiusMenu" })%>
                    </li>
                </ul>
            </div> 
            <div id="container_produtoInfo_BackLogItem_<%= item.BacklogItemId.ToString() %>">
                <div class="innerContainer">
                    <label title="<%= Html.Encode(item.NomeProduto)%>" >
                        <%= Html.Encode(item.NomeProduto)%>
                    </label>                                      
                </div>
            </div>                        
        </li>
    </ul>
    <% } %>
