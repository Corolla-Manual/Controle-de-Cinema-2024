using ControleDeCinema.Dominio.ModuloFuncionario;
using ControleDeCinema.Infra.Orm.Compartilhado;

namespace ControleDeCinema.Infra.Orm.ModuloFuncionario
{
    public class RepositorioFuncionarioEmOrm : IRepositorioFuncionario
    {
        private ControleDeCinemaDbContext dbContext;

        public RepositorioFuncionarioEmOrm(ControleDeCinemaDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Inserir(Funcionario registro)
        {
            dbContext.Funcionarios.Add(registro);

            dbContext.SaveChanges();
        }

        public bool Editar(Funcionario registroOriginal, Funcionario registroAtualizado)
        {
            if (registroOriginal == null || registroOriginal == null)
                return false;

            registroOriginal.AtualizarInformacoes(registroAtualizado);

            dbContext.Funcionarios.Update(registroOriginal);

            dbContext.SaveChanges();

            return true;
        }

        public bool Excluir(Funcionario registro)
        {
            if (registro == null)
                return false;

            dbContext.Funcionarios.Remove(registro);

            dbContext.SaveChanges();

            return true;
        }

        public Funcionario SelecionarPorId(int id)
        {
            return dbContext.Funcionarios.Find(id)!;
        }

        public List<Funcionario> SelecionarTodos()
        {
            return dbContext.Funcionarios.ToList();
        }
    }
}
