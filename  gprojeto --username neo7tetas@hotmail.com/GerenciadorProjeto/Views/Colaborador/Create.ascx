<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<GerenciadorProjeto.Models.Colaborador>" %>
    <% using (Ajax.BeginForm("Create", "Colaborador", new AjaxOptions
       {
           HttpMethod = "POST",
           InsertionMode = InsertionMode.Replace,
           UpdateTargetId = "listColaborador",
           LoadingElementId = "carregando"
       }))
       {%>

        <fieldset>
            <legend>Adicionar Colaborador</legend>
                <%= Html.Hidden("EmpresaId", ViewData["EmpresaId"])%>
            <p>
                <label for="Nome">Nome:</label>
                <%= Html.TextBox("Nome") %>
            </p>
            <p>
                <input type="submit" value="Adicionar" />
                <%= Ajax.ActionLink("Cancelar", "List", new AjaxOptions
                                                                        {
                                                                            InsertionMode = InsertionMode.Replace,
                                                                            UpdateTargetId = "listColaborador",
                                                                            LoadingElementId = "carregando"
                                                                        })%>
            </p>
        </fieldset>

    <% } %>


