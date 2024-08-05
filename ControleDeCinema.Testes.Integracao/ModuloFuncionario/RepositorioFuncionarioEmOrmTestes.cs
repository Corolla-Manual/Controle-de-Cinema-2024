using ControleDeCinema.Infra.Orm.Compartilhado;
using ControleDeCinema.Infra.Orm.ModuloFuncionario;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ControleDeCinema.Testes.Integracao.ModuloFuncionario;

[TestClass]
[TestCategory("Testes de Integração de Funcionarios")]
public class RepositorioFuncionarioEmOrmTestes
{
    private ControleDeCinemaDbContext dbContext = null;
    private RepositorioFuncionarioEmOrm repositorioFuncionario = null;

    [TestInitialize]
    public void ConfigurarTestes()
    {
        dbContext = new ControleDeCinemaDbContext();
        dbContext.Funcionarios.RemoveRange(dbContext.Funcionarios);

        repositorioFuncionario = new RepositorioFuncionarioEmOrm(dbContext);
    }

    //[TestMethod]
}
// AAA - Arrange , Act, Assert
