namespace DesafioBTG.Entidades
{
    public class Fundo
    {
        public int IdFundo { get; set; }
        public string Nome { get; set; }

        public List<Aplicacao> Aplicacoes { get; set; }
            = new List<Aplicacao>();

        public List<Resgate> Resgates { get; set; }
            = new List<Resgate>();

        public Fundo(string nome)
        {
            Nome = nome;
        }

        private Fundo()
        {
        }

        public Aplicacao ObterAplicacao(int aplicacaoId)
        {
            var aplicacao = Aplicacoes.Find(a => a.Id == aplicacaoId);

            if (aplicacao == null)
            {
                throw new ArgumentException("Aplicação não encontrada.");
            }

            return aplicacao;
        }
    }
}