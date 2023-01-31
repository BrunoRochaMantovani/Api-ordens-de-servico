namespace API_ORDEM_SERVICO.Models
{
    public class Servico
    {
        public int Id { get; set; }
        public string Atividade { get; set; }

        public List<Ordem_De_Servico>  Ordem_De_Servicos { get; set; }
    }
}
