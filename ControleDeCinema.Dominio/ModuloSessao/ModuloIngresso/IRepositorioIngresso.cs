namespace ControleDeCinema.Dominio.ModuloSessao.ModuloIngresso
{
	public interface IRepositorioIngresso
	{
		void Inserir(Ingresso registro);
		bool Editar(Ingresso registroOriginal, Ingresso registroAtualizado);
		bool Excluir(Ingresso registro);
		Ingresso SelecionarPorId(int idSelecionado);
		List<Ingresso> SelecionarTodos();
	}
}
