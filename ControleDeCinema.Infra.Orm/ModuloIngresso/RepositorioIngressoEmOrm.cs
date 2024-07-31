using ControleDeCinema.Dominio.ModuloSessao.ModuloIngresso;
using ControleDeCinema.Infra.Orm.Compartilhado;

namespace ControleDeCinema.Infra.Orm.ModuloIngresso
{
	public class RepositorioIngressoEmOrm : IRepositorioIngresso
	{
		private ControleDeCinemaDbContext dbContext;

		public RepositorioIngressoEmOrm(ControleDeCinemaDbContext context)
		{
			dbContext = context;
		}

		public void Inserir(Ingresso registro)
		{
			dbContext.Ingressos.Add(registro);

			dbContext.SaveChanges();
		}

		public bool Editar(Ingresso registroOriginal, Ingresso registroAtualizado)
		{
			if (registroOriginal == null || registroAtualizado == null)
				return false;

			registroOriginal.AtualizarInformacoes(registroAtualizado);

			dbContext.Ingressos.Update(registroOriginal);

			dbContext.SaveChanges();

			return true;
		}

		public bool Excluir(Ingresso registro)
		{
			if (registro == null)
				return false;

			dbContext.Ingressos.Remove(registro);

			dbContext.SaveChanges();

			return true;
		}

		public Ingresso SelecionarPorId(int id)
		{
			return dbContext.Ingressos.Find(id)!;
		}

		public List<Ingresso> SelecionarTodos()
		{
			return dbContext.Ingressos.ToList();
		}
	}
}
