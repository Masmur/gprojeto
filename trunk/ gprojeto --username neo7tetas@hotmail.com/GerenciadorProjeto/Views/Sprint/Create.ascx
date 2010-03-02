<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<GerenciadorProjeto.Models.Sprint>" %>
    <% using (Ajax.BeginForm("Create","Sprint", new AjaxOptions
       {
           HttpMethod = "POST",
           InsertionMode = InsertionMode.Replace,
           UpdateTargetId = "listSprint"
       }))
       {%>
        <fieldset>
            <legend>Novo Sprint</legend>
                <%= Html.Hidden("EmpresaId", ViewData["EmpresaId"])%>            
            <p>
                <label for="Objetivo">Objetivo:</label>
                <%= Html.TextBox("Objetivo") %>
            </p>
            <p>
                <input type="submit" value="Adicionar" />
                <%= Ajax.ActionLink("Cancelar", "List", new { EmpresaId = ViewData["EmpresaId"] }, new AjaxOptions { InsertionMode = InsertionMode.Replace, UpdateTargetId = "listSprint" })%>                                
            </p>
        </fieldset>

    <% } %>


