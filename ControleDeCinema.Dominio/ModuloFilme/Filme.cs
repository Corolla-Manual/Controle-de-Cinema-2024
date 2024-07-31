using ControleDeCinema.Dominio.Compartilhado;

namespace ControleDeCinema.Dominio.ModuloFilme
{
    public class Filme : EntidadeBase
    {
        public string Titulo { get; set; }
        public DateTime Duracao { get; set; }
        public string Genero { get; set; }
        public bool Estreia { get; set; }
        //public List<Sessao> Sessao { get; set; }

        public Filme(string titulo, DateTime duracao, string genero, bool estreia)
        {
            Titulo = titulo;
            Duracao = duracao;
            Genero = genero;
            Estreia = estreia;

            //Sessao = new List<Sessao>();
        }

        public override void AtualizarInformacoes(EntidadeBase registroAtualizado)
        {
            Filme filmeAtualizado = (Filme)registroAtualizado;

            Titulo = filmeAtualizado.Titulo;
            Duracao = filmeAtualizado.Duracao;
            Genero = filmeAtualizado.Genero;
            Estreia = filmeAtualizado.Estreia;
        }

        public override List<string> Validar()
        {
            List<string> erros = new List<string>();

            if (string.IsNullOrEmpty(Titulo.Trim()))
                erros.Add("O campo \"Titulo\" é obrigatório!");

            if (string.IsNullOrEmpty(Genero.Trim()))
                erros.Add("O campo \"Genero\" é obrigatório!");

            return erros;
        }

        public override string ToString()
        {
            return Titulo;
        }
    }
}