using System.Collections.Generic;
using ControleDeCinema.Dominio.ModuloFilme;
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

    [TestMethod]
    public void Deve_Inserir_Filme_Corretamente()
    {
        //Arrange
        Filme novoFilme = new Filme("", 0, "", false);
        
        //Act
        repositorioFilme.Inserir(novoFilme);
        
        //Assert
        Filme filmeSelecionado = repositorioFilme.SelecionarPorId(novoFilme.Id);

        Assert.AreEqual(novoFilme, filmeSelecionado);
    }

    [TestMethod]
    public void Deve_Editar_Filme_Corretamente()
    {
        //Arrange
        Filme filmeOriginal = new Filme("", 0, "", false);

        repositorioFilme.Inserir(filmeOriginal);

        Filme filmeParaAtualizacao = repositorioFilme.SelecionarPorId(filmeOriginal.Id);
        
        //Act
        repositorioFilme.Editar(filmeOriginal, filmeParaAtualizacao);

        //Assert
        Assert.AreEqual(filmeOriginal, filmeParaAtualizacao);
    }

    [TestMethod]
    public void Deve_Excluir_Filme_Corretamente()
    {
        //Arrange
        Filme filme = new Filme("", 0, "", false);

        repositorioFilme.Inserir(filme);

        //Act
        repositorioFilme.Excluir(filme);

        //Arrange
        Filme filmeSelecionado = repositorioFilme.SelecionarPorId(filme.Id);

        Assert.IsNull(filmeSelecionado);
    }

    [TestMethod]
    public void Deve_Selecionar_Filme_Corretamente()
    {
        //Arrange
        List<Filme> filmesParaCadastro =
        [
            new Filme("", 0, "", false),
            new Filme("a", 1, "a", false),
            new Filme("b", 2, "b", true)
        ];

        foreach (Filme filme in filmesParaCadastro)
            repositorioFilme.Inserir(filme);

        //Act
        List<Filme> filmesSelecionados = repositorioFilme.SelecionarTodos();

        //Assert
        CollectionAssert.AreEqual(filmesParaCadastro, filmesSelecionados);
    }
}