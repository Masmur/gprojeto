<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<GerenciadorProjeto.Models.Sprint>>" %>
<div class="pageActions">
    <p>
        <%= Ajax.ActionLink("Adicionar", "Create", new { EmpresaId = Convert.ToInt64(Session["EmpresaId"]) },
                                                    new AjaxOptions
                                                    {
                                                        HttpMethod = "GET",
                                                        InsertionMode = InsertionMode.Replace,
                                                        UpdateTargetId = "formCreateSprint"
                                                    })%>
    </p> 
    <div id="formCreateSprint">
    </div>    
</div>                                           
    <% foreach (var item in Model) { %>
    <ul id="sprints">
        <li id=id="conteiner_sprint_<%= item.SprintId.ToString() %>">
            <div class="itemContainer">
                <div class="leftContainer lastContainer">
                    <label title="<%= Html.Encode(item.Objetivo)%>" >
                        <%= Html.Encode(item.Objetivo)%>
                    </label>       
                </div>
                <ul class="rightContainer">
                    <li>
                        <%= Html.ActionLink("Abrir", "Details", new { SprintId = item.SprintId }, new { Class = "radiusMenu" })%>                                    
                    </li>
                    <li>
                        <%= Ajax.ActionLink("Editar", "Edit", "Sprint",    new { SprintId = item.SprintId },
                                                                            new AjaxOptions {   HttpMethod = "GET",
                                                                                                InsertionMode = InsertionMode.Replace,
                                                                                                UpdateTargetId = "container_formEdit_sprint_" + item.SprintId.ToString()
                                                                            },
                                                                            new { Class = "radiusMenu" })%>
                    </li>
                    <li>
                        <%= Ajax.ActionLink("Apagar", "Delete", "Sprint", new { SprintId = item.SprintId },
                                                                            new AjaxOptions {   Confirm = "Confirma a deleção??",
                                                                                                HttpMethod = "POST",
                                                                                                InsertionMode = InsertionMode.Replace,
                                                                                                UpdateTargetId = "listSprint"
                                                                            },
                                                                            new { Class = "radiusMenu" })%>
                    </li>
                </ul>
            </div>
            <div id="container_formEdit_sprint_<%= item.SprintId.ToString() %>">
            </div>           
        </li>
    </ul>
    <% } %>