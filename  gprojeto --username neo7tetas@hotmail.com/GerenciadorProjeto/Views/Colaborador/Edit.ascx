<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<GerenciadorProjeto.Models.Colaborador>" %>
<div class="innerContainer">
    <% using (Ajax.BeginForm("Edit", "Colaborador", new AjaxOptions
       {
           HttpMethod = "POST",
           InsertionMode = InsertionMode.Replace,
           UpdateTargetId = "listColaborador",
           LoadingElementId = "carregando"
       }))
       {%>

        <fieldset>
            <legend>Editar Colaborador</legend>
                <%= Html.Hidden("EmpresaId", ViewData["EmpresaId"])%>
                <%= Html.Hidden("ColaboradorId", Model.ColaboradorId.ToString())%>
            <p>
                <label for="Nome">Nome:</label>
                <%= Html.TextBox("Nome", Model.Nome) %>
            </p>
            <p>
                <label for="Email">E-mail:</label>
                <%= Html.TextBox("email") %>
            </p>             
            <p>
                <input type="submit" value="Atualizar" />
                <%= Ajax.ActionLink("Cancelar", "List", new AjaxOptions
                                                            {
                                                                InsertionMode = InsertionMode.Replace,
                                                                UpdateTargetId = "listColaborador",
                                                                LoadingElementId = "carregando"
                                                            })%>                
            </p>
        </fieldset>

    <% } %>
</div>


