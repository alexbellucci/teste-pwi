using test_pwi.DL.Services.DAL;

namespace test_pwi.DL.DB
{
    public class TodoItem : IEntity
    {
        public long Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime? DataConclusao { get; set; }
        public bool Concluido { get; set; }
    }
}
