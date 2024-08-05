using ControleDeCinema.Infra.Orm.Compartilhado;
using ControleDeCinema.Infra.Orm.ModuloSala;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ControleDeCinema.Testes.Integracao.ModuloSala;

public class RepositorioSalaEmOrmTestes
{
    ControleDeCinemaDbContext dbContext = null;
    RepositorioSalaEmOrm repositorioSala = null;

    [TestInitialize]
    public void ConfigurarTestes()
    {
        dbContext = new ControleDeCinemaDbContext();
        dbContext.Salas.RemoveRange(dbContext.Salas);

        repositorioSala = new RepositorioSalaEmOrm(dbContext);
    }

    //[TestMethod]
}
// AAA - Arrange, Act, Assert
