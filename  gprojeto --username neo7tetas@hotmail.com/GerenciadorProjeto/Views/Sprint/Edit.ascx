<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<GerenciadorProjeto.Models.Sprint>" %>
    <% using (Ajax.BeginForm("Edit","Sprint", new { SprintId = Model.SprintId }, new AjaxOptions
       {
           HttpMethod = "POST",
           InsertionMode = InsertionMode.Replace,
           UpdateTargetId = "listSprint",
           LoadingElementId = "carregando"
       }))
       {%>
        <fieldset>
            <legend>Editar Sprint</legend>
                <%= Html.Hidden("EmpresaId", ViewData["EmpresaId"])%>            
            <p>
                <label for="Objetivo">Objetivo:</label>
                <%= Html.TextBox("Objetivo", Model.Objetivo) %>
            </p>
            <p>
                <input type="submit" value="Atualizar" />
                <%= Ajax.ActionLink("Cancelar", "List", new { EmpresaId = ViewData["EmpresaId"] }, new AjaxOptions { InsertionMode = InsertionMode.Replace, UpdateTargetId = "listSprint" })%>                                                
            </p>
        </fieldset>

    <% } %>


