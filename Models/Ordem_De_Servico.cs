namespace API_ORDEM_SERVICO.Models
{
    public class Ordem_De_Servico
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }

        public string DescProblema { get; set; }
        public string Equipamento { get; set; }

        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }

        public int TecnicoId { get; set; }
        public Tecnico Tecnico { get; set; }

        public int FinalizacaoId { get; set; }
        public Finalizacao Finalizacao { get; set; }

        public List<Servico> Servicos { get; set; }

    }
}
