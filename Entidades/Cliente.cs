namespace DesafioBTG.Entidades
{
    public class Cliente
    {
        public Cliente(int id, string nome)
        {
            Id = id;
            Nome = nome;
        }

        public int Id { get; set; }
        public string Nome { get; set; }

         
        public List<Aplicacao> Aplicacoes { get; set; } = new List<Aplicacao>();
        public List<Resgate> Resgates { get; set; } = new List<Resgate>();

        private Cliente()
        {

        }

    }
}
