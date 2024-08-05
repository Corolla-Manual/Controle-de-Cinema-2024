using ControleDeCinema.Dominio.ModuloFilme;
using ControleDeCinema.Infra.Orm.Compartilhado;
using ControleDeCinema.Infra.Orm.ModuloFilme;
using ControleDeCinemaMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace ControleDeCinemaMVC.Controllers
{
	public class FilmeController : Controller
	{
		public ViewResult Listar()
		{
			var db = new ControleDeCinemaDbContext();
			var repositorioFilme = new RepositorioFilmeEmOrm(db);

			var filmes = repositorioFilme.SelecionarTodos();

			var listarFilmesVm = filmes
				.Select(f => new ListarFilmeViewModel
				{
					Id = f.Id,
					Titulo = f.Titulo,
					Duracao = f.Duracao,
					Genero = f.Genero,
					Estreia = f.Estreia,
					Sessoes = f.Sessoes
						.Select(c => new ListarSessaoFilmeViewModel() { DataHorario = c.Horario })
				});

			return View(listarFilmesVm);
		}

		public ViewResult Inserir()
		{
			return View();
		}

		[HttpPost]
		public ViewResult Inserir(InserirFilmeViewModel inserirFilmeVm)
		{
			if (!ModelState.IsValid)
				return View(inserirFilmeVm);

			var db = new ControleDeCinemaDbContext();
			var repositorioFilme = new RepositorioFilmeEmOrm(db);

			var filme = new Filme(inserirFilmeVm.Titulo, inserirFilmeVm.Duracao, inserirFilmeVm.Genero, inserirFilmeVm.Estreia);

			repositorioFilme.Inserir(filme);

			HttpContext.Response.StatusCode = 201;

			var notificacaoVm = new NotificacaoViewModel
			{
				Mensagem = $"O registro com o ID [{filme.Id}] foi cadastrado com sucesso!",
				LinkRedirecionamento = "/filme/listar"
			};

			return View("mensagens", notificacaoVm);
		}

		public ViewResult Editar(int id)
		{
			var db = new ControleDeCinemaDbContext();
			var repositorioFilme = new RepositorioFilmeEmOrm(db);

			var filme = repositorioFilme.SelecionarPorId(id);

			var editarFilmeVm = new EditarFilmeViewModel
			{
				Id = id,
				Titulo = filme.Titulo,
				Duracao = filme.Duracao,
				Genero = filme.Genero,
				Estreia = filme.Estreia

			};

			return View(editarFilmeVm);
		}

		[HttpPost]
		public ViewResult Editar(EditarFilmeViewModel editarFilmeVm)
		{
			if (!ModelState.IsValid)
				return View(editarFilmeVm);

			var db = new ControleDeCinemaDbContext();
			var repositorioFilme = new RepositorioFilmeEmOrm(db);

			var filmeOriginal = repositorioFilme.SelecionarPorId(editarFilmeVm.Id);
			var filmeEditada = repositorioFilme.SelecionarPorId(editarFilmeVm.Id);

			filmeEditada.Titulo = editarFilmeVm.Titulo;
			filmeEditada.Duracao = editarFilmeVm.Duracao;
			filmeEditada.Genero = editarFilmeVm.Genero;
			filmeEditada.Estreia = editarFilmeVm.Estreia;

			repositorioFilme.Editar(filmeOriginal, filmeEditada);

			var notificacaoVm = new NotificacaoViewModel
			{
				Mensagem = $"O registro com o ID [{filmeEditada.Id}] foi editado com sucesso!",
				LinkRedirecionamento = "/filme/listar"
			};

			return View("mensagens", notificacaoVm);
		}

		public ViewResult Excluir(int id)
		{
			var db = new ControleDeCinemaDbContext();
			var repositorioFilme = new RepositorioFilmeEmOrm(db);

			var filme = repositorioFilme.SelecionarPorId(id);

			var excluirFilmeVm = new ExcluirFilmeViewModel()
			{
				Id = filme.Id,
				Titulo = filme.Titulo,
				Duracao = filme.Duracao,
				Genero = filme.Genero,
				Estreia = filme.Estreia,
				Sessoes = filme.Sessoes
					.Select(c => new ListarSessaoFilmeViewModel() { DataHorario = c.Horario })
			};


			return View(excluirFilmeVm);
		}

		[HttpPost, ActionName("excluir")]
		public ViewResult ExcluirConfirmado(ExcluirFilmeViewModel excluirFilmeVm)
		{
			var db = new ControleDeCinemaDbContext();
			var repositorioFilme = new RepositorioFilmeEmOrm(db);

			var filme = repositorioFilme.SelecionarPorId(excluirFilmeVm.Id);

			repositorioFilme.Excluir(filme);

			var notificacaoVm = new NotificacaoViewModel
			{
				Mensagem = $"O registro com o ID [{filme.Id}] foi excluído com sucesso!",
				LinkRedirecionamento = "/filme/listar"
			};

			return View("mensagens", notificacaoVm);
		}

		public ViewResult Detalhes(int id)
		{
			var db = new ControleDeCinemaDbContext();
			var repositorioFilme = new RepositorioFilmeEmOrm(db);

			var filme = repositorioFilme.SelecionarPorId(id);

			var detalhesFilmeVm = new DetalhesFilmeViewModel()
			{
				Id = filme.Id,
				Titulo = filme.Titulo,
				Duracao = filme.Duracao,
				Genero = filme.Genero,
				Estreia = filme.Estreia,
				Sessoes = filme.Sessoes
					.Select(c => new ListarSessaoFilmeViewModel() { DataHorario = c.Horario })
			};

			return View(detalhesFilmeVm);
		}
	}
}
