namespace DesafioBTG.Entidades
{
    public class Resgate
    {
        public int Id { get; set; }
        public Decimal ValorResgate { get; set; }
        public decimal ImpostoDeRenda { get; set; }
        public DateTime DataResgate { get; set; }

        public int FundoId { get; set; }
        public Fundo Fundo { get; set; }
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }
        public decimal ValorLiquido { get; set; }

        public Resgate(decimal valorResgate, Aplicacao aplicacao)
        {

            ValorResgate = valorResgate;
            DataResgate = DateTime.Now;

            CalcularImpostoDeRenda(aplicacao); 
        }

        private Resgate()
        {
            
        }

        private void CalcularImpostoDeRenda(Aplicacao aplicacao)
        {
            var lucro = ValorResgate - aplicacao.Valor;
            var tempoDeAplicacao = (DataResgate - aplicacao.DataAplicacao).TotalDays / 365.0;

            if (tempoDeAplicacao < 1)
            {
                ImpostoDeRenda = lucro * 0.225m; // 22,5% de imposto de renda
            }
            else if (tempoDeAplicacao < 2)
            {
                ImpostoDeRenda = lucro * 0.20m; // 20% de imposto de renda
            }
            else if (tempoDeAplicacao < 3)
            {
                ImpostoDeRenda = lucro * 0.175m; // 17,5% de imposto de renda
            }
            else
            {
                ImpostoDeRenda = lucro * 0.15m; // 15% de imposto de renda
            }   

            ValorLiquido = ValorResgate - ImpostoDeRenda;

        }
    }
}
