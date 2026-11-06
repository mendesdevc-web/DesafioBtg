namespace DesafioBTG.Requisicao
{
    public class Requisicoes
    {
        public int NumeroFundo { get; set; }
        public int AplicacaoId { get; set; }
        public decimal Valor { get; set; }
        public int ClienteId { get; set; }
        public DateTime Data { get; set; }

        public Requisicoes(int aplicacaoId, decimal valor, DateTime data)
        {
            AplicacaoId = aplicacaoId;
            Valor = valor;
            Data = data;
        }
    }
}
