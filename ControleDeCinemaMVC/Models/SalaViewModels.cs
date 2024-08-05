using System.ComponentModel.DataAnnotations;

namespace ControleDeCinemaMVC.Models
{
	public class InserirSalaViewModel
	{
		[Required(ErrorMessage = "O campo número é obrigatório!")]
		public int Numero { get; set; }

		[Required(ErrorMessage = "O campo capacidade é obrigatório!")]
		public int Capacidade { get; set; }
	}
	public class EditarSalaViewModel
	{
		public int Id { get; set; }

		[Required(ErrorMessage = "O campo número é obrigatório!")]
		public int Numero { get; set; }

		[Required(ErrorMessage = "O campo capacidade é obrigatório!")]
		public int Capacidade { get; set; }
	}
	public class ExcluirSalaViewModel
	{
		public int Id { get; set; }
		public int Numero { get; set; }
		public int Capacidade { get; set; }

		public IEnumerable<ListarSessaoSalaViewModel> Sessoes { get; set; }
	}
	public class ListarSalaViewModel
	{
		public int Id { get; set; }
		public int Numero { get; set; }
		public int Capacidade { get; set; }
	}

	public class DetalhesSalaViewModel
	{
		public int Id { get; set; }
		public int Numero { get; set; }
		public int Capacidade { get; set; }
		public IEnumerable<ListarSessaoSalaViewModel> Sessoes { get; set; }
	}

	public class ListarSessaoSalaViewModel
	{
		public string DataHorario { get; set; }
	}
}
