<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<GerenciadorProjeto.Models.Colaborador>>" %>
<div class="pageActions">
    <p>
        <%= Ajax.ActionLink("Adicionar", "Create", new { EmpresaId = Convert.ToInt64(Session["EmpresaId"]) },
                                                    new AjaxOptions
                                                    {
                                                        HttpMethod = "GET",
                                                        InsertionMode = InsertionMode.Replace,
                                                        UpdateTargetId = "formCreateColaborador"
                                                    })%>
    </p> 
    <div id="formCreateColaborador">
    </div>    
</div>      
    <% foreach (var item in Model) { %>
    <ul id="colaboradores">
        <li id="conteiner_colaborador_<%= item.ColaboradorId.ToString() %>">
            <div class="itemContainer">
                <div class="leftContainer lastContainer">
                    <label title="<%= Html.Encode(item.Nome)%>" >
                        <%= Html.Encode(item.Nome)%>
                    </label>       
                </div>
                <ul class="rightContainer">
                    <li>
                        <%= Ajax.ActionLink("Editar", "Edit", "Colaborador", new { ColaboradorId = item.ColaboradorId },
                                                                            new AjaxOptions {   HttpMethod = "GET",
                                                                                                InsertionMode = InsertionMode.Replace,
                                                                                                UpdateTargetId = "container_formEdit_colaborador_" + item.ColaboradorId.ToString()
                                                                            },
                                                                            new { Class = "radiusMenu" })%>
                    </li>
                    <li>
                        <%= Ajax.ActionLink("Apagar", "Delete", "Colaborador", new { ColaboradorId = item.ColaboradorId },
                                                                            new AjaxOptions {   Confirm = "Confirma a deleção??",
                                                                                                HttpMethod = "POST",
                                                                                                InsertionMode = InsertionMode.Replace,
                                                                                                UpdateTargetId = "listColaborador"
                                                                            },
                                                                            new { Class = "radiusMenu" })%>
                    </li>
                </ul>
            </div>
            <div id="container_formEdit_colaborador_<%= item.ColaboradorId.ToString() %>">
            </div>           
        </li>
    </ul>
    <% } %>


