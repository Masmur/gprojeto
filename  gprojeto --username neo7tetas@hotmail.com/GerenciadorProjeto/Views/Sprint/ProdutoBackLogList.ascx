<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<GerenciadorProjeto.Models.vBackLogProduto>>" %>
<div class="innerContainer">
    <div class="pageActions">
    </div>                                           
        <% foreach (var item in Model) { %>
        <ul>
            <li id="baklogitens">
                <div class="itemContainer">
                    <div class="leftContainer lastContainer">
                        <label title="<%=Html.Encode(item.Nome)%>" >
                            <%= Html.Encode(item.Nome)%>
                        </label> 
                    </div>                
                    <ul class="rightContainer">
                        <li>
                            <%= Ajax.ActionLink("Adicionar ao Sprint", "AdicionarBackLogItem", "Sprint", new { BacklogItemId = item.BacklogItemId, SprintId = ViewData["SprintId"], ProdutoId = item.ProdutoId },
                                                                                new AjaxOptions {   HttpMethod = "POST",
                                                                                                    InsertionMode = InsertionMode.Replace,
                                                                                                    UpdateTargetId = "container_backlog_produto_" + item.ProdutoId.ToString(),
                                                                                                    LoadingElementId = "carregando"
                                                                                },
                                                                                new { Class = "radiusMenu" })%>
                        </li>
                    </ul>
                </div> 
            </li>
        </ul>
        <% } %>
</div>