namespace DesafioBTG.Entidades
{
    public class Aplicacao
    {
        public int Id { get; set; }
        public Decimal Valor { get; set; }
        public DateTime DataAplicacao { get; set; }
        public int  FundoId { get; set; }
        public Fundo Fundo { get; set; }

        public  int  ClienteId { get; set; }
        public Cliente Cliente { get; set; }

        private Aplicacao()
        {
            
        }

       public Aplicacao( decimal valor, int fundoId, int clienteId)
        {
            if (valor <= 0)
            {
                throw new ArgumentException("O valor da aplicação deve ser maior que zero.");
            }

            Valor = valor;
            DataAplicacao = DateTime.Now;
            FundoId = fundoId;
            ClienteId = clienteId;
        }

        public void RetirarValor(decimal valor)
        {
            if (valor > Valor)
            {
                throw new InvalidOperationException("Valor a ser retirado é maior que o valor disponível na aplicação.");
            }
            Valor -= valor;
        }
    }
}
