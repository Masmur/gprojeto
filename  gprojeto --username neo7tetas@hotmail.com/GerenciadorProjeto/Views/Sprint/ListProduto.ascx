<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<GerenciadorProjeto.Models.vListProdutoSprint>>" %>
<div class="pageActions">
</div>                                           
    <% foreach (var item in Model) { %>
    <ul id="produtos">
        <li id="conteiner_produto_<%= item.ProdutoId.ToString() %>">
            <div class="itemContainer">
                <div class="leftContainer lastContainer">
                    <label title="<%= Html.Encode(item.Nome)%>" >
                        <img src="../../Content/images/ico_produto.png" alt="ico_produto"/>
                        <%= Html.Encode(item.Nome)%>
                    </label>       
                </div>
                <ul class="rightContainer">
                    <li>
                        <%= Ajax.ActionLink("exibir backlog", "ProdutoBackLogList", "Sprint", new { ProdutoId = item.ProdutoId, SprintId = ViewData["SprintId"] },
                                                                            new AjaxOptions {   HttpMethod = "GET",
                                                                                                InsertionMode = InsertionMode.Replace,
                                                                                                UpdateTargetId = "container_backlog_produto_" + item.ProdutoId.ToString(),
                                                                                                LoadingElementId = "carregando"
                                                                            },
                                                                            new { Class = "radiusMenu" })%>
                    </li>
                </ul>
            </div>
            <div id="container_backlog_produto_<%= item.ProdutoId.ToString() %>">
            </div>           
        </li>
    </ul>
    <% } %>
