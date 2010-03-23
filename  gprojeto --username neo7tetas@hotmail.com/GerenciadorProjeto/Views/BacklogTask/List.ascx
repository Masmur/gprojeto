<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<GerenciadorProjeto.Models.BacklogTask>>" %>
<div class="innerContainer">
    <div class="pageActions">
        <p>
            <%= Ajax.ActionLink("Adicionar Tarefa", "Create", new { BacklogItemId = ViewData["BacklogItemId"] },
                                                        new AjaxOptions
                                                        {
                                                            HttpMethod = "GET",
                                                            InsertionMode = InsertionMode.Replace,
                                                            UpdateTargetId = "formCreateBackLogTask",
                                                            LoadingElementId = "carregando"
                                                        })%>
        </p> 
        <div id="formCreateBackLogTask">
        </div>
    </div>                                           
        <% foreach (var item in Model) { %>
        <ul>
            <li id="baklogitens">
                <div class="itemContainer">
                    <div class="leftContainer lastContainer">
                        <label title="<%= Html.Encode(item.Nome)%>" >
                            <img src="../../Content/images/ico_usertask.png" alt="ico_usertask"/>
                            <%= Html.Encode(item.Nome)%>
                        </label>       
                    </div>
                    <ul class="rightContainer">
                        <li>
                            <%= Ajax.ActionLink("Apagar", "Delete", "BacklogTask", new { BacklogTaskId = item.BacklogTaskId ,BacklogItemId = item.BacklogItemId },
                                                                                new AjaxOptions {   Confirm = "Confirma a deleção??",
                                                                                                    HttpMethod = "POST",
                                                                                                    InsertionMode = InsertionMode.Replace,
                                                                                                    UpdateTargetId = "container_TaskList_BackLogItem_" + item.BacklogItemId.ToString(),
                                                                                                    LoadingElementId = "carregando"
                                                                                },
                                                                                new { Class = "radiusMenu" })%>
                        </li>
                    </ul>
                </div> 
                <div id="container_formEdit_BackLogTask_<%= item.BacklogItemId.ToString() %>">
                </div>                        
            </li>
        </ul>
        <% } %>
</div>
