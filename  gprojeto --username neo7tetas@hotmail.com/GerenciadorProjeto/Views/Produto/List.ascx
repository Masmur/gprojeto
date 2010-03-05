<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<GerenciadorProjeto.Models.Produto>>" %>
<div class="pageActions">
    <p>
        <%= Ajax.ActionLink("Adicionar", "Create", new { EmpresaId = Convert.ToInt64(Session["EmpresaId"]) },
                                                    new AjaxOptions
                                                    {
                                                        HttpMethod = "GET",
                                                        InsertionMode = InsertionMode.Replace,
                                                        UpdateTargetId = "formCreateProduto",
                                                        LoadingElementId = "carregando"
                                                    })%>
    </p> 
    <div id="formCreateProduto">
    </div>    
</div>                                           
    <% foreach (var item in Model) { %>
    <ul id="produtos">
        <li id="conteiner_produto_<%= item.ProdutoId.ToString() %>">
            <div class="itemContainer">
                <div class="leftContainer lastContainer">
                    <label title="<%= Html.Encode(item.Nome)%>" >
                        <%= Html.Encode(item.Nome)%>
                    </label>       
                </div>
                <ul class="rightContainer">
                    <li>
                        <%= Html.ActionLink("Abrir", "Details", new { ProdutoId = item.ProdutoId }, new { Class = "radiusMenu" })%>                                    
                    </li>
                    <li>
                        <%= Ajax.ActionLink("Editar", "Edit", "Produto",    new { ProdutoId = item.ProdutoId },
                                                                            new AjaxOptions {   HttpMethod = "GET",
                                                                                                InsertionMode = InsertionMode.Replace,
                                                                                                UpdateTargetId = "container_formEdit_produto_" + item.ProdutoId.ToString(),
                                                                                                LoadingElementId = "carregando"
                                                                            },
                                                                            new { Class = "radiusMenu" })%>
                    </li>
                    <li>
                        <%= Ajax.ActionLink("Apagar", "Delete", "Produto",  new { ProdutoId = item.ProdutoId },
                                                                            new AjaxOptions {   Confirm = "Confirma a deleção??",
                                                                                                HttpMethod = "POST",
                                                                                                InsertionMode = InsertionMode.Replace,
                                                                                                UpdateTargetId = "listProduto",
                                                                                                LoadingElementId = "carregando"
                                                                            },
                                                                            new { Class = "radiusMenu" })%>
                    </li>
                </ul>
            </div>
            <div id="container_formEdit_produto_<%= item.ProdutoId.ToString() %>">
            </div>           
        </li>
    </ul>
    <% } %>

