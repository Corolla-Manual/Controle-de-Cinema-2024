using System.ComponentModel.DataAnnotations;

namespace ControleDeCinemaMVC.Models
{
	public class InserirFilmeViewModel
	{
		[Required(ErrorMessage = "O campo Titulo é obrigatório!")]
		public string Titulo { get; set; }

		[Required(ErrorMessage = "O campo Duração é obrigatório!")]
		public int Duracao { get; set; }

		[Required(ErrorMessage = "O campo Genero é obrigatório!")]
		public string Genero { get; set; }
		public bool Estreia { get; set; }
	}
	public class EditarFilmeViewModel
	{
		public int Id { get; set; }

		[Required(ErrorMessage = "O campo Titulo é obrigatório!")]
		public string Titulo { get; set; }

		[Required(ErrorMessage = "O campo Duração é obrigatório!")]
		public int Duracao { get; set; }

		[Required(ErrorMessage = "O campo Genero é obrigatório!")]
		public string Genero { get; set; }
		public bool Estreia { get; set; }
	}
	public class ExcluirFilmeViewModel
	{
		public int Id { get; set; }
		public string Titulo { get; set; }
		public int Duracao { get; set; }
		public string Genero { get; set; }
		public bool Estreia { get; set; }

		public IEnumerable<ListarSessaoFilmeViewModel> Sessoes { get; set; }
	}
	public class ListarFilmeViewModel
	{
		public int Id { get; set; }
		public string Titulo { get; set; }
		public int Duracao { get; set; }
		public string Genero { get; set; }
		public bool Estreia { get; set; }
		public IEnumerable<ListarSessaoFilmeViewModel> Sessoes { get; set; }
	}

	public class DetalhesFilmeViewModel
	{
		public int Id { get; set; }
		public string Titulo { get; set; }
		public int Duracao { get; set; }
		public string Genero { get; set; }
		public bool Estreia { get; set; }
		public IEnumerable<ListarSessaoFilmeViewModel> Sessoes { get; set; }
	}

	public class ListarSessaoFilmeViewModel
	{
		public DateTime DataHorario { get; set; }
	}
}