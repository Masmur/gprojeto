<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<GerenciadorProjeto.Models.BacklogTask>>" %>
<script type="text/javascript">
function teste()
{
    // Dialog Link
    $('#container_formConclui_BackLogTask').dialog('open');

}
$(function(){
    // Dialog
    $('#container_formConclui_BackLogTask').dialog({
            autoOpen: false,
            width: 600
    });
});
</script>

<div class="innerContainer">
    <div class="pageActions">
        <p>
            <%= Ajax.ActionLink("Adicionar tarefas", "Create", new { BacklogItemId = ViewData["BacklogItemId"] },
                                                        new AjaxOptions
                                                        {
                                                            HttpMethod = "GET",
                                                            InsertionMode = InsertionMode.Replace,
                                                            UpdateTargetId = "formCreateBackLogTask_" + ViewData["BacklogItemId"],
                                                            LoadingElementId = "carregando"
                                                        })%>
        </p> 
        <div id="formCreateBackLogTask_<%= ViewData["BacklogItemId"]%>">
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
                            <%= Ajax.ActionLink("Concluir", "Create", "BacklogTask", new { BacklogItemId = item.BacklogItemId },
                                                                                new AjaxOptions {   Confirm = "Confirma a deleção??",
                                                                                                    HttpMethod = "POST",
                                                                                                    InsertionMode = InsertionMode.Replace,
                                                                                                    UpdateTargetId = "container_formConclui_BackLogTask",
                                                                                                    LoadingElementId = "carregando",
                                                                                                    OnComplete = "teste()"                                                                                                    
                                                                                },
                                                                                new { Class = "radiusMenu" })%>
                        </li>                    
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
                <div id="container_formConclui_BackLogTask_<%= item.BacklogItemId.ToString() %>">
                </div>
                <div id="container_formConclui_BackLogTask">
                </div>                
            </li>
        </ul>
        <% } %>
</div>
