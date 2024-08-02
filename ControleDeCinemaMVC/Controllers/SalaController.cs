using ControleDeCinema.Dominio.ModuloSala;
using ControleDeCinema.Infra.Orm.Compartilhado;
using ControleDeCinema.Infra.Orm.ModuloSala;
using ControleDeCinemaMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace ControleDeCinemaMVC.Controllers
{
	public class SalaController : Controller
	{
		public ViewResult Listar()
		{
			var db = new ControleDeCinemaDbContext();
			var repositorioSala = new RepositorioSalaEmOrm(db);

			var salas = repositorioSala.SelecionarTodos();

			var listarSalasVm = salas
				.Select(s => new ListarSalaViewModel
				{
					Id = s.Id,
					Numero = s.Numero,
					Capacidade = s.Capacidade
				});

			return View(listarSalasVm);
		}

		public ViewResult Inserir()
		{
			return View();
		}

		[HttpPost]
		public ViewResult Inserir(InserirSalaViewModel inserirSalaVm)
		{
			if (!ModelState.IsValid)
				return View(inserirSalaVm);

			var db = new ControleDeCinemaDbContext();
			var repositorioSala = new RepositorioSalaEmOrm(db);

			var sala = new Sala(inserirSalaVm.Numero, inserirSalaVm.Capacidade);

			repositorioSala.Inserir(sala);

			HttpContext.Response.StatusCode = 201;

			var notificacaoVm = new NotificacaoViewModel
			{
				Mensagem = $"O registro com o ID [{sala.Id}] foi cadastrado com sucesso!",
				LinkRedirecionamento = "/sala/listar"
			};

			return View("mensagens", notificacaoVm);
		}

		public ViewResult Editar(int id)
		{
			var db = new ControleDeCinemaDbContext();
			var repositorioSala = new RepositorioSalaEmOrm(db);

			var sala = repositorioSala.SelecionarPorId(id);

			var editarSalaVm = new EditarSalaViewModel
			{
				Id = id,
				Numero = sala.Numero,
				Capacidade = sala.Capacidade
			};

			return View(editarSalaVm);
		}

		[HttpPost]
		public ViewResult Editar(EditarSalaViewModel editarSalaVm)
		{
			if (!ModelState.IsValid)
				return View(editarSalaVm);

			var db = new ControleDeCinemaDbContext();
			var repositorioSala = new RepositorioSalaEmOrm(db);

			var salaOriginal = repositorioSala.SelecionarPorId(editarSalaVm.Id);
			var salaEditada = repositorioSala.SelecionarPorId(editarSalaVm.Id);

			salaEditada.Numero = editarSalaVm.Numero;
			salaEditada.Capacidade = editarSalaVm.Capacidade;

			repositorioSala.Editar(salaOriginal, salaEditada);

			var notificacaoVm = new NotificacaoViewModel
			{
				Mensagem = $"O registro com o ID [{salaEditada.Id}] foi editado com sucesso!",
				LinkRedirecionamento = "/sala/listar"
			};

			return View("mensagens", notificacaoVm);
		}

		public ViewResult Excluir(int id)
		{
			var db = new ControleDeCinemaDbContext();
			var repositorioSala = new RepositorioSalaEmOrm(db);

			var sala = repositorioSala.SelecionarPorId(id);

			var excluirSalaVm = new ExcluirSalaViewModel()
			{
				Id = sala.Id,
				Numero = sala.Numero,
				Capacidade = sala.Capacidade,
				Sessoes = sala.Sessoes
					.Select(c => new ListarSessaoSalaViewModel() { DataHorario = c.Horario.ToString() })
			};


			return View(excluirSalaVm);
		}

		[HttpPost, ActionName("excluir")]
		public ViewResult ExcluirConfirmado(ExcluirSalaViewModel excluirSalaVm)
		{
			var db = new ControleDeCinemaDbContext();
			var repositorioSala = new RepositorioSalaEmOrm(db);

			var sala = repositorioSala.SelecionarPorId(excluirSalaVm.Id);

			repositorioSala.Excluir(sala);

			var notificacaoVm = new NotificacaoViewModel
			{
				Mensagem = $"O registro com o ID [{sala.Id}] foi excluído com sucesso!",
				LinkRedirecionamento = "/sala/listar"
			};

			return View("mensagens", notificacaoVm);
		}

		public ViewResult Detalhes(int id)
		{
			var db = new ControleDeCinemaDbContext();
			var repositorioSala = new RepositorioSalaEmOrm(db);

			var sala = repositorioSala.SelecionarPorId(id);

			var detalhesSalaVm = new DetalhesSalaViewModel()
			{
				Id = sala.Id,
				Numero = sala.Numero,
				Capacidade = sala.Capacidade,
				Sessoes = sala.Sessoes
					.Select(c => new ListarSessaoSalaViewModel() { DataHorario = c.Horario.ToString() })
			};

			return View(detalhesSalaVm);
		}
	}
}
