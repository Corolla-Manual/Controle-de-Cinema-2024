using System.Collections.Generic;
using ControleDeCinema.Dominio.ModuloSala;
using ControleDeCinema.Infra.Orm.Compartilhado;
using ControleDeCinema.Infra.Orm.ModuloSala;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ControleDeCinema.Testes.Integracao.ModuloSala;

[TestClass]
[TestCategory("Testes de Intregracao de Sala")]
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

    [TestMethod]
    public void Deve_Inserir_Sala_Corretamente()
    {
        //Arrange
        Sala novaSala = new Sala(0, 0);

        //Act
        repositorioSala.Inserir(novaSala);

        //Arrange
        Sala salaSelecionada = repositorioSala.SelecionarPorId(novaSala.Id);

        Assert.AreEqual(novaSala, salaSelecionada);
    }

    [TestMethod]
    public void Deve_Editar_Sala_Corretamente()
    {
        //Arrange
        Sala salaOriginal = new Sala(0, 0);

        repositorioSala.Inserir(salaOriginal);

        Sala salaParaAtualizacao = repositorioSala.SelecionarPorId(salaOriginal.Id);

        //Act
        repositorioSala.Editar(salaOriginal, salaParaAtualizacao);

        //Assert
        Assert.AreEqual(salaOriginal,salaParaAtualizacao);
    }

    [TestMethod]
    public void Deve_Excluir_Sala_Corretamente()
    {
        //Arrange
        Sala sala = new Sala(0, 0);

        repositorioSala.Inserir(sala);

        //Act
        repositorioSala.Excluir(sala);

        //Assert
        Sala salaSelecionada = repositorioSala.SelecionarPorId(sala.Id);

        Assert.IsNull(salaSelecionada);
    }

    [TestMethod]
    public void Deve_Selecionar_Sala_Corretamente()
    {
        //Arrange
        List<Sala> salaParaCadastro =
        [
            new Sala(0, 0),
            new Sala(1, 1),
            new Sala(2, 2)
        ];

        foreach(Sala sala in salaParaCadastro)
            repositorioSala.Inserir(sala);

        //Act
        List<Sala> salaSelecionadas = repositorioSala.SelecionarTodos();

        //Assert
        CollectionAssert.AreEqual(salaParaCadastro, salaSelecionadas);
    }
}