<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<GerenciadorProjeto.Models.BacklogItem>>" %>
<div class="pageActions">
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
                        <%= Html.ActionLink("Edit", "Edit", new { id=item.BacklogItemId }, new { Class = "radiusMenu"}) %>  
                    </li>
                    <li>
                        <%= Html.ActionLink("Details", "Details", new { id = item.BacklogItemId }, new { Class = "radiusMenu" })%>
                    </li>
                </ul>
            </div>            
        </li>
    </ul>
    <% } %>


