<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<GerenciadorProjeto.Models.BacklogItem>>" %>
<p>
    <%= Ajax.ActionLink("Adicionar", "Create", new { ProdutoId = ViewData["ProdutoId"] },
                                                new AjaxOptions
                                                {
                                                    HttpMethod = "GET",
                                                    InsertionMode = InsertionMode.Replace,
                                                    UpdateTargetId = "formCreateBackLog"
                                                })%>
</p>      
<div id="formCreateBackLog">
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
                Nota
            </th>
            <th>
                Data
            </th>
            <th>
                Estimativa
            </th>
            <th></th>            
        </tr>

    <% foreach (var item in Model) { %>
    
        <tr>
            <td>
                <%= Html.Encode(item.BacklogItemId) %>
            </td>
            <td>
                <%= Html.Encode(item.Nome) %>
            </td>
            <td>
                <%= Html.Encode(item.Nota) %>
            </td>
            <td>
                <%= Html.Encode(String.Format("{0:g}", item.Data)) %>
            </td>
            <td>
                <%= Html.Encode(String.Format("{0:F}", item.Estimativa)) %>
            </td>
            <td>
                <%= Html.ActionLink("Edit", "Edit", new { id=item.BacklogItemId }) %> |
                <%= Html.ActionLink("Details", "Details", new { id=item.BacklogItemId })%>
            </td>            
        </tr>
    
    <% } %>

    </table>


