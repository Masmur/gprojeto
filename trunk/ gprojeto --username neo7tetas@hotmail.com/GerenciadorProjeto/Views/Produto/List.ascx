<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<GerenciadorProjeto.Models.Produto>>" %>
<div class="pageActions">
    <p>
        <%= Ajax.ActionLink("Adicionar", "Create", new { EmpresaId = Convert.ToInt64(Session["EmpresaId"]) },
                                                    new AjaxOptions
                                                    {
                                                        HttpMethod = "GET",
                                                        InsertionMode = InsertionMode.Replace,
                                                        UpdateTargetId = "formCreateProduto"
                                                    })%>
    </p> 
    <div id="formCreateProduto">
    </div>    
</div>                                           
    <% foreach (var item in Model) { %>
    <ul>
        <li id="produtos">
            <div class="itemContainer">
                <div class="leftContainer lastContainer">
                    <label title="<%= Html.Encode(item.Nome)%>" >
                        <%= Html.Encode(item.Nome)%>
                    </label>       
                </div>
                <ul class="rightContainer">
                    <li>
                        <%= Html.ActionLink("Editar", "Edit", new { ProdutoId = item.ProdutoId }, new { Class = "radiusMenu"})%>
                    </li>
                    <li>
                        <%= Html.ActionLink("Abrir", "Details", new { ProdutoId = item.ProdutoId }, new { Class = "radiusMenu" })%>                                    
                    </li>
                </ul>
            </div>            
        </li>
    </ul>
    <% } %>

