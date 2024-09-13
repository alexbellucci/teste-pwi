namespace test_pwi.DL.Request.TodoItem
{
    public class TodoItemRequest
    {
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime? DataConclusao { get; set; }
        public bool Concluido { get; set; }
    }
}
