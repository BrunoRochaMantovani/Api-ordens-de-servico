namespace API_ORDEM_SERVICO.Models
{
    public class Finalizacao
    {
        public int Id { get; set; }
        public decimal valorTotal { get; set; }
        public DateTime Data { get; set; }
        public DateTime Data_Entrega { get; set; }
    }
}
