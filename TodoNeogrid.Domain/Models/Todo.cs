using System;

namespace TodoNeogrid.Domain.Models
{
    public class Todo
    {
        public Guid Id { get; private set; }
        public string Titulo { get; private set; }
        public string Descricao { get; private set; }
        public bool Concluido { get; private set; }
        public bool Excluido { get; private set; }

        public Todo()
        {

        }

        public Todo(string titulo, string descricao)
        {
            Id = Guid.NewGuid();
            Titulo = titulo;
            Descricao = descricao;
            Concluido = false;
            Excluido = false;
        }

        public Todo(Guid id, string titulo, string descricao, bool concluido, bool excluido)
        {
            Id = id;
            Titulo = titulo;
            Descricao = descricao;
            Concluido = concluido;
            Excluido = excluido;
        }
    }
}