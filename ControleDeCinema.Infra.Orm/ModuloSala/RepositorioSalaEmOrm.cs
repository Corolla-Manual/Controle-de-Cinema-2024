using ControleDeCinema.Dominio.ModuloSala;
using ControleDeCinema.Infra.Orm.Compartilhado;

namespace ControleDeCinema.Infra.Orm.ModuloSala;

public class RepositorioSalaEmOrm : IRepositorioSala
{
    private ControleDeCinemaDbContext dbContext;

    public RepositorioSalaEmOrm(ControleDeCinemaDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public void Inserir(Sala registro)
    {
        dbContext.Salas.Add(registro);

        dbContext.SaveChanges();
    }

    public bool Editar(Sala registroOriginal, Sala registroAtualizado)
    {
        if (registroOriginal == null || registroAtualizado == null)
            return false;

        registroOriginal.AtualizarInformacoes(registroAtualizado);

        dbContext.Salas.Update(registroOriginal);

        dbContext.SaveChanges();

        return true;
    }

    public bool Excluir(Sala registro)
    {
        if (registro == null)
            return false;

        dbContext.Salas.Remove(registro);

        dbContext.SaveChanges();

        return true;
    }

    public Sala SelecionarPorId(int id)
    {
        return dbContext.Salas.Find(id)!;
    }

    public List<Sala> SelecionarTodos()
    {
        return dbContext.Salas.ToList();
    }
}

