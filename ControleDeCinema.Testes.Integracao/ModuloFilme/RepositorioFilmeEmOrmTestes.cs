using ControleDeCinema.Infra.Orm.Compartilhado;
using ControleDeCinema.Infra.Orm.ModuloFilme;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ControleDeCinema.Testes.Integracao.ModuloFilme;

[TestClass]
[TestCategory("Testes de Integração de Filme")]
public class RepositorioFilmeEmOrmTestes
{
    ControleDeCinemaDbContext dbContext = null;
    RepositorioFilmeEmOrm repositorioFilme = null;

    [TestInitialize]
    public void ConfigurarTestes()
    {
        dbContext = new ControleDeCinemaDbContext();
        dbContext.Filmes.RemoveRange(dbContext.Filmes);

        repositorioFilme = new RepositorioFilmeEmOrm(dbContext);
    }

    //[TestMethod]

}
// AAA - Arrange , Act, Assert