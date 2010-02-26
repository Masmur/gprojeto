<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<GerenciadorProjeto.Models.Produto>>" %>
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
    <table>
        <tr>
            <th>
                ID
            </th>
            <th>
                Nome
            </th>
            <th>
                Data
            </th>
            <th>A��es</th>            
        </tr>

    <% foreach (var item in Model) { %>
    
        <tr>
            <td>
                <%= Html.Encode(item.ProdutoId) %>
            </td>
            <td>
                <%= Html.Encode(item.Nome) %>
            </td>
            <td>
                <%= Html.Encode(String.Format("{0:g}", item.Data)) %>
            </td>
            <td>
                <%= Html.ActionLink("Editar", "Edit", new { ProdutoId=item.ProdutoId }) %> |
                <%= Html.ActionLink("Abrir", "Details", new { ProdutoId=item.ProdutoId })%>
            </td>            
        </tr>
    
    <% } %>

    </table>

