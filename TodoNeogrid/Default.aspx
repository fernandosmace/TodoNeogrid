<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TodoNeogrid._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main>
        <div class="container text-center">
            <div class="d-flex justify-content-end mb-3 ">
                <input type="button" class="btn btn-small btn-success" onclick="adicionarTarefa(this)" value="Nova Tarefa" />
            </div>
            <nav class="nav justify-content-center">
                <div class="nav nav-tabs" id="nav-tab" role="tablist">
                    <button class="nav-link" id="nav-todos-tab" data-bs-toggle="tab" data-bs-target="#nav-todos" type="button" role="tab" aria-controls="nav-todos" aria-selected="false"><i class="bi bi-award"></i> Todos</button>
                    <button class="nav-link active" id="nav-pendentes-tab" data-bs-toggle="tab" data-bs-target="#nav-pendentes" type="button" role="tab" aria-controls="nav-pendentes" aria-selected="true"><i class="bi bi-clock"></i> Pendentes</button>
                    <button class="nav-link" id="nav-concluidas-tab" data-bs-toggle="tab" data-bs-target="#nav-concluidas" type="button" role="tab" aria-controls="nav-concluidas" aria-selected="false"><i class="bi bi-check-all"></i> Concluídas</button>
                </div>
            </nav>
            <div class="tab-content" id="nav-tabContent">
                <div class="tab-pane fade" id="nav-todos" role="tabpanel" aria-labelledby="nav-profile-tab">
                    <div class="table-responsive">
                        <table class="table table-success table-hover table-sm">
                            <thead>
                                <tr>
                                    <th scope="col">Status</th>
                                    <th scope="col">Título</th>
                                    <th scope="col"></th>
                                    <th scope="col"></th>
                                </tr>
                            </thead>
                            <tbody style="text-align: center; vertical-align: middle;">
                                <% foreach (var todo in todosList)
                                    { %>
                                <tr class="table-light">
                                    <td width="5%">
                                        <input class="form-check-input" id="<%=todo.Id.ToString()%>" type="checkbox" onchange="alterarStatusTarefa(this)" <%= todo.Concluido ? "checked" : ""%>></td>
                                    <td>
                                        <label <%= todo.Concluido ? "style='text-decoration: line-through;'" : ""%> type="text"><%= todo.Titulo %></label>
                                    </td>
                                    <td width="5%">
                                        <button type="button" class="btn btn-small btn-success" id="btnEditar-<%=todo.Id.ToString()%>" data-titulo="<%=todo.Titulo.ToString()%>" Descricao="<%=todo.Descricao.ToString()%>" onclick="editarTarefa(this)">
                                            <i class="bi bi-pencil-square"></i>
                                        </button>
                                    </td>
                                    <td width="5%">
                                        <button type="button" class="btn btn-small btn-danger" id="btnExcluir-<%=todo.Id.ToString()%>" onclick="excluirTarefa(this)"><i class="bi bi-trash"></i></button>
                                    </td>
                                </tr>
                                <% } %>
                            </tbody>
                        </table>
                    </div>
                </div>
                <div class="tab-pane fade show active" id="nav-pendentes" role="tabpanel" aria-labelledby="nav-profile-tab">
                    <div class="table-responsive">
                        <table class="table table-success table-hover table-sm">
                            <thead>
                                <tr>
                                    <th scope="col">Status</th>
                                    <th scope="col">Título</th>
                                    <th scope="col"></th>
                                    <th scope="col"></th>
                                </tr>
                            </thead>
                            <tbody style="text-align: center; vertical-align: middle;">
                                <% foreach (var todo in todosListPendentes)
                                    { %>
                                <tr class="table-light">
                                    <td width="5%">
                                        <input class="form-check-input" id="<%=todo.Id.ToString()%>" type="checkbox" onchange="alterarStatusTarefa(this)" <%= todo.Concluido ? "checked" : ""%>></td>
                                    <td>
                                        <label <%= todo.Concluido ? "style='text-decoration: line-through;'" : ""%> type="text"><%= todo.Titulo %></label>
                                    </td>
                                    <td width="5%">
                                        <button type="button" class="btn btn-small btn-success" id="btnEditar-<%=todo.Id.ToString()%>" data-titulo="<%=todo.Titulo.ToString()%>" Descricao="<%=todo.Descricao.ToString()%>" onclick="editarTarefa(this)">
                                            <i class="bi bi-pencil-square"></i>
                                        </button>
                                    </td>
                                    <td width="5%">
                                        <button type="button" class="btn btn-small btn-danger" id="btnExcluir-<%=todo.Id.ToString()%>" onclick="excluirTarefa(this)"><i class="bi bi-trash"></i></button>
                                    </td>
                                </tr>
                                <% } %>
                            </tbody>
                        </table>
                    </div>
                </div>
                <div class="tab-pane fade" id="nav-concluidas" role="tabpanel" aria-labelledby="nav-profile-tab">
                    <div class="table-responsive">
                        <table class="table table-success table-hover table-sm">
                            <thead>
                                <tr>
                                    <th scope="col">Status</th>
                                    <th scope="col">Título</th>
                                    <th scope="col"></th>
                                    <th scope="col"></th>
                                </tr>
                            </thead>
                            <tbody style="text-align: center; vertical-align: middle;">
                                <% foreach (var todo in todosListConcluidas)
                                    { %>
                                <tr class="table-light">
                                    <td width="5%">
                                        <input class="form-check-input" id="<%=todo.Id.ToString()%>" type="checkbox" onchange="alterarStatusTarefa(this)" <%= todo.Concluido ? "checked" : ""%>></td>
                                    <td>
                                        <label <%= todo.Concluido ? "style='text-decoration: line-through;'" : ""%> type="text"><%= todo.Titulo %></label>
                                    </td>
                                    <td width="5%">
                                        <button type="button" class="btn btn-small btn-success" id="btnEditar-<%=todo.Id.ToString()%>" data-titulo="<%=todo.Titulo.ToString()%>" Descricao="<%=todo.Descricao.ToString()%>" onclick="editarTarefa(this)">
                                            <i class="bi bi-pencil-square"></i>
                                        </button>
                                    </td>
                                    <td width="5%">
                                        <button type="button" class="btn btn-small btn-danger" id="btnExcluir-<%=todo.Id.ToString()%>" onclick="excluirTarefa(this)"><i class="bi bi-trash"></i></button>
                                    </td>
                                </tr>
                                <% } %>
                            </tbody>
                        </table>
                    </div>
                </div>
            </div>
        </div>
    </main>
</asp:Content>
