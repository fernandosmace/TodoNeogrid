namespace TodoNeogrid.Infra.Mapping
{
    public class TodoMap
    {
        public string Id { get; private set; }
        public string Titulo { get; private set; }
        public string Descricao { get; private set; }
        public bool Concluido { get; private set; }
        public bool Excluido { get; private set; }

        public TodoMap()
        {

        }

    }
}