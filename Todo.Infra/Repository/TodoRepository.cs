using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using TodoNeogrid.Domain.Models;
using TodoNeogrid.Infra.Context;
using TodoNeogrid.Infra.Mapping;

namespace TodoNeogrid.Infra.Repository
{
    public class TodoRepository
    {
        private readonly TodoContext _context = new TodoContext();

        public void CriarBancoDeDados()
        {
            try
            {
                using (var conexao = _context.CriarConexao())
                {
                    var query = $@"CREATE DATABASE IF NOT EXISTS ToDo;";

                    conexao.Execute(
                        new CommandDefinition(
                        query));


                    query = $@"CREATE TABLE ToDo.Todo (
	                                Id varchar(100) NOT NULL,
	                                Titulo varchar(100) NOT NULL,
	                                Descricao varchar(100) NOT NULL,
	                                Concluido BOOL DEFAULT 0 NOT NULL,
	                                Excluido BOOL DEFAULT 0 NOT NULL
                                   );";

                    conexao.Execute(
                        new CommandDefinition(
                        query));
                }
            }
            catch (Exception ex)
            {

            }
        }
        public Todo GetTodo(string titulo, string descricao)
        {
            try
            {
                using (var conexao = _context.CriarConexao())
                {
                    var query = $@"
                                  SELECT	*
                                  FROM ToDo.Todo t 
                                  WHERE t.Titulo = @titulo AND t.Descricao = @descricao AND t.Excluido = 0;";

                    var resultado = conexao.Query<TodoMap>(
                        new CommandDefinition(
                        query,
                        new
                        {
                            titulo,
                            descricao
                        }))
                        .FirstOrDefault();

                    if (resultado == null)
                        return null;

                    return new Todo(
                            Guid.Parse(resultado.Id),
                            resultado.Titulo,
                            resultado.Descricao,
                            resultado.Concluido,
                            resultado.Excluido
                        );
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Todo> GetTodoList()
        {
            try
            {
                using (var conexao = _context.CriarConexao())
                {
                    var query = $@"
                                  SELECT	*
                                  FROM ToDo.Todo t 
                                  WHERE t.Excluido = 0;";

                    var resultado = conexao.Query<TodoMap>(
                        new CommandDefinition(
                        query))
                        .ToList();

                    var todosList = new List<Todo>();
                    resultado.ForEach(x =>
                    {
                        todosList.Add(new Todo(
                            Guid.Parse(x.Id),
                            x.Titulo,
                            x.Descricao,
                            x.Concluido,
                            x.Excluido
                        ));
                    });

                    return todosList;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void AdicionarTodo(Todo todo)
        {
            try
            {
                using (var conexao = _context.CriarConexao())
                {
                    var query = $@"
                                  INSERT INTO ToDo.Todo
                                  VALUES(@Id, @Titulo, @Descricao, @Concluido, @Excluido);";

                    conexao.Execute(
                        new CommandDefinition(
                        query,
                        new
                        {
                            todo.Id,
                            todo.Titulo,
                            todo.Descricao,
                            todo.Concluido,
                            todo.Excluido
                        }));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void EditarTodo(Guid id, string titulo, string descricao)
        {
            try
            {
                using (var conexao = _context.CriarConexao())
                {
                    var query = $@"
                                  UPDATE ToDo.Todo
                                  SET Titulo = @titulo, Descricao = @descricao
                                  WHERE Id = @Id;";

                    conexao.Execute(
                        new CommandDefinition(
                        query,
                        new
                        {
                            id,
                            titulo,
                            descricao
                        }));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void AlteraStatusTodo(Guid id, bool status)
        {
            try
            {
                using (var conexao = _context.CriarConexao())
                {
                    var query = $@"
                                  UPDATE ToDo.Todo
                                  SET Concluido = @status
                                  WHERE Id = @Id;";

                    conexao.Execute(
                        new CommandDefinition(
                        query,
                        new
                        {
                            id,
                            status
                        }));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ExcluirTodo(Guid id)
        {
            try
            {
                using (var conexao = _context.CriarConexao())
                {
                    var query = $@"
                                  DELETE
                                  FROM ToDo.Todo
                                  WHERE Id = @Id;";

                    conexao.Execute(
                        new CommandDefinition(
                        query,
                        new
                        {
                            id,
                        }));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}