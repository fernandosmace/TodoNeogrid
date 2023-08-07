using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using TodoNeogrid.Domain.Models;
using TodoNeogrid.Services;

namespace TodoNeogrid
{
    public partial class _Default : Page
    {
        private readonly TodoService _todoService = new TodoService();
        public IEnumerable<Todo> todosList { get; private set; }
        public IEnumerable<Todo> todosListPendentes { get; private set; }
        public IEnumerable<Todo> todosListConcluidas { get; private set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            todosList = _todoService.GetTodos().OrderBy(x => x.Concluido);
            todosListPendentes = todosList.Where(x => x.Concluido == false);
            todosListConcluidas = todosList.Where(x => x.Concluido == true);
        }

        [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Json)]
        [WebMethod]
        public static void AdicionarTodo(string titulo, string descricao)
        {

            WebException webException = null;

            var response = HttpContext.Current.Response;
            var js = new System.Web.Script.Serialization.JavaScriptSerializer();

            if (String.IsNullOrEmpty(titulo) || String.IsNullOrEmpty(descricao))
            {
                response.Clear();
                response.ContentType = "application/json; charset=utf-8";
                response.StatusCode = 500;
                response.Write(js.Serialize("O titulo e descrição devem ser preenchidos."));
                response.Flush();
                response.End();
            }

            var _todoService = new TodoService();
            _todoService.AdicionarTodo(titulo, descricao);
        }



        [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Json)]
        [WebMethod]
        public static void EditarTodo(Guid id, string titulo, string descricao)
        {

            WebException webException = null;

            var response = HttpContext.Current.Response;
            var js = new System.Web.Script.Serialization.JavaScriptSerializer();

            if (String.IsNullOrEmpty(titulo) || String.IsNullOrEmpty(descricao))
            {
                response.Clear();
                response.ContentType = "application/json; charset=utf-8";
                response.StatusCode = 500;
                response.Write(js.Serialize("O titulo e descrição devem ser preenchidos."));
                response.Flush();
                response.End();
            }

            var _todoService = new TodoService();
            _todoService.EditarTodo(id, titulo, descricao);
        }


        [WebMethod]
        public static void AlteraStatusTodo(Guid id, bool status)
        {
            var _todoService = new TodoService();
            _todoService.AlteraStatusTodo(id, status);
        }

        [WebMethod]
        public static void ExcluirTodo(Guid id)
        {
            var _todoService = new TodoService();
            _todoService.ExcluirTodo(id);
        }
    }
}