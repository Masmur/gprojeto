<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<GerenciadorProjeto.Models.Colaborador>>" %>
<div class="pageActions">
    <p>
        <%= Ajax.ActionLink("Adicionar", "Create", new { EmpresaId = Convert.ToInt64(Session["EmpresaId"]) },
                                                    new AjaxOptions
                                                    {
                                                        HttpMethod = "GET",
                                                        InsertionMode = InsertionMode.Replace,
                                                        UpdateTargetId = "formCreateColaborador",
                                                        LoadingElementId = "carregando"
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
                          <img src="../../Content/images/ico_colaborador.png" alt="ico_colaborador"/>
                          <%= Html.Encode(item.Nome)%>
                    </label>       
                </div>
                <ul class="rightContainer">
                    <li>
                        <%= Ajax.ActionLink("Editar", "Edit", "Colaborador", new { ColaboradorId = item.ColaboradorId },
                                                                            new AjaxOptions {   HttpMethod = "GET",
                                                                                                InsertionMode = InsertionMode.Replace,
                                                                                                UpdateTargetId = "container_formEdit_colaborador_" + item.ColaboradorId.ToString(),
                                                                                                LoadingElementId = "carregando"
                                                                            },
                                                                            new { Class = "radiusMenu" })%>
                    </li>
                    <li>
                        <%= Ajax.ActionLink("Apagar", "Delete", "Colaborador", new { ColaboradorId = item.ColaboradorId },
                                                                            new AjaxOptions {   Confirm = "Confirma a dele��o??",
                                                                                                HttpMethod = "POST",
                                                                                                InsertionMode = InsertionMode.Replace,
                                                                                                UpdateTargetId = "listColaborador",
                                                                                                LoadingElementId = "carregando"
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


