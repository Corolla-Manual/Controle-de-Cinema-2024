using System.ComponentModel.DataAnnotations;

namespace ControleDeCinemaMVC.Models
{
	public class InserirFuncionarioViewModel
	{
		[Required(ErrorMessage = "O campo Nome é obrigatório!")]
		public string Nome { get; set; }

		[Required(ErrorMessage = "O campo Login é obrigatório!")]
		public string Login { get; set; }

		[Required(ErrorMessage = "O campo Senha é obrigatório!")]
		public string Senha { get; set; }
	}
	public class EditarFuncionarioViewModel
	{
		public int Id { get; set; }

		[Required(ErrorMessage = "O campo Nome é obrigatório!")]
		public string Nome { get; set; }

		[Required(ErrorMessage = "O campo Login é obrigatório!")]
		public string Login { get; set; }

		[Required(ErrorMessage = "O campo Senha é obrigatório!")]
		public string Senha { get; set; }
	}
	public class ExcluirFuncionarioViewModel
	{
		public int Id { get; set; }
		public string Nome { get; set; }
		public string Login { get; set; }
	}
	public class ListarFuncionarioViewModel
	{
		public int Id { get; set; }
		public string Nome { get; set; }
		public string Login { get; set; }
	}

	public class DetalhesFuncionarioViewModel
	{
		public int Id { get; set; }
		public string Nome { get; set; }
		public string Login { get; set; }
		public string Senha { get; set; }
	}
}
