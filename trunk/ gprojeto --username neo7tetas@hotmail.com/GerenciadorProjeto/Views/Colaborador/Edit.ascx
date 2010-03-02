<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<GerenciadorProjeto.Models.Colaborador>" %>
    <% using (Ajax.BeginForm("Edit", "Colaborador", new { ColaboradorId = Model.ColaboradorId }, new AjaxOptions
       {
           HttpMethod = "POST",
           InsertionMode = InsertionMode.Replace,
           UpdateTargetId = "listColaborador"
       }))
       {%>

        <fieldset>
            <legend>Editar Colaborador</legend>
                <%= Html.Hidden("EmpresaId", ViewData["EmpresaId"])%>
            <p>
                <label for="Nome">Nome:</label>
                <%= Html.TextBox("Nome", Model.Nome) %>
                <%= Html.ValidationMessage("Nome", "*") %>
            </p>
            <p>
                <input type="submit" value="Atualizar" />
                <%= Ajax.ActionLink("Cancelar", "List", new AjaxOptions { InsertionMode = InsertionMode.Replace, UpdateTargetId = "listColaborador" })%>                
            </p>
        </fieldset>

    <% } %>



