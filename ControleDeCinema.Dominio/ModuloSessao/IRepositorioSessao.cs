namespace ControleDeCinema.Dominio.ModuloSessao
{
	public interface IRepositorioSessao
	{
		void Inserir(Sessao registro);
		bool Editar(Sessao registroOriginal, Sessao registroAtualizado);
		bool Excluir(Sessao registro);
		Sessao SelecionarPorId(int idSelecionado);
		List<Sessao> SelecionarTodos();
	}
}
