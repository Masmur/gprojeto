<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<GerenciadorProjeto.Classes.Calendario>" %>
    <div id="calendar-months">
        <%= Ajax.ActionLink("Anterior", "Calendar", new
                            {
                                SprintId = ViewData["SprintId"],
                                mes = Convert.ToInt32(ViewData["mes"]) -1,
                                Ano =  ViewData["ano"]
                            },
                                                    new AjaxOptions {   InsertionMode = InsertionMode.Replace,
                                                                        UpdateTargetId = "calendario",
                                                                        LoadingElementId = "carregando"
                                                    })%>
        <h3><%= ViewData["mes-nome"] + " de " + ViewData["ano"]%></h3>
        <%= Ajax.ActionLink("Proximo", "Calendar", new
                            {
                                SprintId = ViewData["SprintId"],
                                mes = Convert.ToInt32(ViewData["mes"]) + 1,
                                Ano = ViewData["ano"]
                            },
                                                    new AjaxOptions {   InsertionMode = InsertionMode.Replace,
                                                                        UpdateTargetId = "calendario",
                                                                        LoadingElementId = "carregando"
                                                    })%>
    </div>
        <div id="calendar">
            <table class="calendar">
                <thead>
                    <tr>
                      <th>Domingo</th>
                      <th>Segunda</th>
                      <th>Terça</th>
                      <th>Quarta</th>
                      <th>Quinta</th>
                      <th>Sexta</th>
                      <th>Sábado</th>
                    </tr>
                </thead>
                <tbody>
                    <tr>
                    <% int c = 0;
                        foreach (var item in Model.dias)
                        {%>
                                <% if (item.dia_semana == "Sunday")
                                   {%>
                                        <% c = 1; %>
                                        </tr>
                                        <tr>
                                        <td class="day">
                                            <div class="date">
                                                <%=item.dia.ToString()%>
                                            </div>
                                        </td>                                       
                                   <%}%>

                                <% if (item.dia_semana == "Monday")
                                   {%>
                                        <% if (c != 1){ %>
                                            <td></td>       
                                        <%} %>
                                        <% c = 2; %>
                                        <td class="day">
                                            <div class="date">
                                                <%=item.dia.ToString()%>
                                            </div>
                                        </td>                                       
                                   <%}%>
                                   
                                <% if (item.dia_semana == "Tuesday")
                                   {%>
                                        <% if (c != 2){ %>
                                            <td></td>
                                            <td></td>
                                        <%} %>
                                        <% c = 3; %>                                   
                                        <td class="day">
                                            <div class="date">
                                                <%=item.dia.ToString()%>
                                            </div>
                                        </td>                                       
                                   <%}%>
                                                                      
                                <% if (item.dia_semana == "Wednesday")
                                   {%>
                                        <% if (c != 3){ %>
                                            <td></td> 
                                            <td></td>
                                            <td></td>      
                                        <%} %>
                                        <% c = 4; %>                                   
                                        <td class="day">
                                            <div class="date">
                                                <%=item.dia.ToString()%>
                                            </div>
                                        </td>                                       
                                   <%}%>
                                                                   
                                <% if (item.dia_semana == "Thursday")
                                   {%>
                                        <% if (c != 4){ %>
                                            <td></td>
                                            <td></td>
                                            <td></td>
                                            <td></td>       
                                        <%} %>
                                        <% c = 5; %>                                   
                                        <td class="day">
                                            <div class="date">
                                                <%=item.dia.ToString()%>
                                            </div>
                                        </td>                                       
                                   <%}%>

                                                                   
                                <% if (item.dia_semana == "Friday")
                                   {%>
                                        <% if (c != 5){ %>
                                            <td></td>
                                            <td></td>
                                            <td></td>
                                            <td></td>
                                            <td></td>      
                                        <%} %>
                                        <% c = 6; %>                                   
                                        <td class="day">
                                            <div class="date">
                                                <%=item.dia.ToString()%>
                                            </div>
                                        </td>                                       
                                   <%}%>

                                                                   
                                <% if (item.dia_semana == "Saturday")
                                   {%>
                                        <% if (c != 6){ %>
                                            <td></td>
                                            <td></td>
                                            <td></td>
                                            <td></td>
                                            <td></td>
                                            <td></td>       
                                        <%} %>
                                        <% c = 7; %>                                   
                                        <td class="day">
                                            <div class="date">
                                                <%=item.dia.ToString()%>
                                            </div>
                                        </td>
                                        </tr>
                                   <%}%>
                       <%} %>
                 </tbody>
            </table>
        </div>        