<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<GerenciadorProjeto.Models.Produto>" %>
    <% using (Ajax.BeginForm("Create","Produto", new AjaxOptions
       {
           HttpMethod = "POST",
           InsertionMode = InsertionMode.Replace,
           UpdateTargetId = "listProduto"
       }))
       {%>

        <fieldset>
            <legend>Fields</legend>
                <%= Html.Hidden("EmpresaId", ViewData["EmpresaID"])%>
            <p>
                <label for="Nome">Nome:</label>
                <%= Html.TextBox("Nome")%>
            </p>
            <p>
                <input type="submit" value="Adicionar" />
            </p>
        </fieldset>

    <% } %>



