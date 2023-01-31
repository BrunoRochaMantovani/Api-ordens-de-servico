namespace API_ORDEM_SERVICO.Models
{
    public class Tecnico
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public IList<Ordem_De_Servico> Ordem_De_Servico { get; set; }
    }
}
