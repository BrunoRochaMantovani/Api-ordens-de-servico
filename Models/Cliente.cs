namespace API_ORDEM_SERVICO.Models
{
    public class Cliente
    {
        public int id { get; set; }
        public string Nome { get; set; }
        public string Empresa { get; set; }
        public string Telefone  { get; set; }

        public IList<Ordem_De_Servico> Ordem_De_Servicos { get; set; }
    }
}
