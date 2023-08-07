using System;
using System.Collections.Generic;
using TodoNeogrid.Domain.Models;
using TodoNeogrid.Infra.Repository;

namespace TodoNeogrid.Services
{
    public class TodoService
    {
        private readonly TodoRepository _todoRepository = new TodoRepository();

        public void CriarBancoDeDados()
        {
            _todoRepository.CriarBancoDeDados();
        }

        public List<Todo> GetTodos()
        {
            var todosList = _todoRepository.GetTodoList();

            return todosList;
        }

        public void AdicionarTodo(string titulo, string descricao)
        {
            var todo = new Todo(titulo, descricao);
            _todoRepository.AdicionarTodo(todo);
        }

        public void EditarTodo(Guid id, string titulo, string descricao)
        {
            _todoRepository.EditarTodo(id, titulo, descricao);
        }

        public void AlteraStatusTodo(Guid id, bool status)
        {
            _todoRepository.AlteraStatusTodo(id, status);
        }

        public void ExcluirTodo(Guid id)
        {
            _todoRepository.ExcluirTodo(id);
        }

    }
}