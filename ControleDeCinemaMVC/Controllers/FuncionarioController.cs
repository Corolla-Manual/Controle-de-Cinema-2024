using ControleDeCinema.Dominio.ModuloFuncionario;
using ControleDeCinema.Infra.Orm.Compartilhado;
using ControleDeCinema.Infra.Orm.ModuloFuncionario;
using ControleDeCinemaMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace ControleDeCinemaMVC.Controllers
{
	public class FuncionarioController : Controller
	{
		public ViewResult Listar()
		{
			var db = new ControleDeCinemaDbContext();
			var repositorioFuncionario = new RepositorioFuncionarioEmOrm(db);

			var funcionarios = repositorioFuncionario.SelecionarTodos();

			var listarFuncionariosVm = funcionarios
				.Select(f => new ListarFuncionarioViewModel
				{
					Id = f.Id,
					Nome = f.Nome,
					Login = f.Login
				});

			return View(listarFuncionariosVm);
		}

		public ViewResult Inserir()
		{
			return View();
		}

		[HttpPost]
		public ViewResult Inserir(InserirFuncionarioViewModel inserirFuncionarioVm)
		{
			if (!ModelState.IsValid)
				return View(inserirFuncionarioVm);

			var db = new ControleDeCinemaDbContext();
			var repositorioFuncionario = new RepositorioFuncionarioEmOrm(db);

			var funcionario = new Funcionario(inserirFuncionarioVm.Nome, inserirFuncionarioVm.Login, inserirFuncionarioVm.Senha);

			repositorioFuncionario.Inserir(funcionario);

			HttpContext.Response.StatusCode = 201;

			var notificacaoVm = new NotificacaoViewModel
			{
				Mensagem = $"O registro com o ID [{funcionario.Id}] foi cadastrado com sucesso!",
				LinkRedirecionamento = "/funcionario/listar"
			};

			return View("mensagens", notificacaoVm);
		}

		public ViewResult Editar(int id)
		{
			var db = new ControleDeCinemaDbContext();
			var repositorioFuncionario = new RepositorioFuncionarioEmOrm(db);

			var funcionario = repositorioFuncionario.SelecionarPorId(id);

			var editarFuncionarioVm = new EditarFuncionarioViewModel
			{
				Id = id,
				Nome = funcionario.Nome,
				Login = funcionario.Login,
				Senha = funcionario.Senha
			};

			return View(editarFuncionarioVm);
		}

		[HttpPost]
		public ViewResult Editar(EditarFuncionarioViewModel editarFuncionarioVm)
		{
			if (!ModelState.IsValid)
				return View(editarFuncionarioVm);

			var db = new ControleDeCinemaDbContext();
			var repositorioFuncionario = new RepositorioFuncionarioEmOrm(db);

			var funcionarioOriginal = repositorioFuncionario.SelecionarPorId(editarFuncionarioVm.Id);
			var funcionarioEditada = repositorioFuncionario.SelecionarPorId(editarFuncionarioVm.Id);

			funcionarioEditada.Nome = editarFuncionarioVm.Nome;
			funcionarioEditada.Login = editarFuncionarioVm.Login;
			funcionarioEditada.Senha = editarFuncionarioVm.Senha;

			repositorioFuncionario.Editar(funcionarioOriginal, funcionarioEditada);

			var notificacaoVm = new NotificacaoViewModel
			{
				Mensagem = $"O registro com o ID [{funcionarioEditada.Id}] foi editado com sucesso!",
				LinkRedirecionamento = "/funcionario/listar"
			};

			return View("mensagens", notificacaoVm);
		}

		public ViewResult Excluir(int id)
		{
			var db = new ControleDeCinemaDbContext();
			var repositorioFuncionario = new RepositorioFuncionarioEmOrm(db);

			var funcionario = repositorioFuncionario.SelecionarPorId(id);

			var excluirFuncionarioVm = new ExcluirFuncionarioViewModel()
			{
				Id = funcionario.Id,
				Nome = funcionario.Nome,
				Login = funcionario.Login
			};


			return View(excluirFuncionarioVm);
		}

		[HttpPost, ActionName("excluir")]
		public ViewResult ExcluirConfirmado(ExcluirFuncionarioViewModel excluirFuncionarioVm)
		{
			var db = new ControleDeCinemaDbContext();
			var repositorioFuncionario = new RepositorioFuncionarioEmOrm(db);

			var funcionario = repositorioFuncionario.SelecionarPorId(excluirFuncionarioVm.Id);

			repositorioFuncionario.Excluir(funcionario);

			var notificacaoVm = new NotificacaoViewModel
			{
				Mensagem = $"O registro com o ID [{funcionario.Id}] foi excluído com sucesso!",
				LinkRedirecionamento = "/funcionario/listar"
			};

			return View("mensagens", notificacaoVm);
		}

		public ViewResult Detalhes(int id)
		{
			var db = new ControleDeCinemaDbContext();
			var repositorioFuncionario = new RepositorioFuncionarioEmOrm(db);

			var funcionario = repositorioFuncionario.SelecionarPorId(id);

			var detalhesFuncionarioVm = new DetalhesFuncionarioViewModel()
			{
				Id = funcionario.Id,
				Nome = funcionario.Nome,
				Login = funcionario.Login,
				Senha = funcionario.Senha
			};

			return View(detalhesFuncionarioVm);
		}
	}
}
