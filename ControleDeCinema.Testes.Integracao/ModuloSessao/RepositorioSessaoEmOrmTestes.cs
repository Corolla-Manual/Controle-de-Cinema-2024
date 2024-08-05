using System;
using System.Collections.Generic;
using ControleDeCinema.Dominio.ModuloFilme;
using ControleDeCinema.Dominio.ModuloSala;
using ControleDeCinema.Dominio.ModuloSessao;
using ControleDeCinema.Infra.Orm.Compartilhado;
using ControleDeCinema.Infra.Orm.ModuloSessao;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ControleDeCinema.Testes.Integracao.ModuloSessao;

[TestClass]
[TestCategory("Testes de Intregracao de Sessao")]
public class RepositorioSessaoEmOrmTestes
{
    private ControleDeCinemaDbContext dbContext = null;
    RepositorioSessaoEmOrm repositorioSessao = null;

    [TestInitialize]
    public void ConfigurarTestes()
    {
        dbContext = new ControleDeCinemaDbContext();
        dbContext.Sessoes.RemoveRange(dbContext.Sessoes);

        repositorioSessao = new RepositorioSessaoEmOrm(dbContext);
    }

    [TestMethod]
    public void Deve_Inserir_Sessao_Corretamente()
    {
        //Arrange
        Sala sala = new Sala(0, 0);
        Filme filme = new Filme("", 0, "", false);

        Sessao novaSessao = new Sessao(filme, sala, DateTime.MinValue, StatusSessaoEnum.Não_Iniciado);

        //Act
        repositorioSessao.Inserir(novaSessao);

        //Arrange
        Sessao sessaoSelecionada = repositorioSessao.SelecionarPorId(novaSessao.Id);

        Assert.AreEqual(novaSessao, sessaoSelecionada);
    }

    [TestMethod]
    public void Deve_Editar_Sessao_Corretamente()
    {
        //Arrange
        Sala sala = new Sala(0, 0);
        Filme filme = new Filme("", 0, "", false);

        Sessao sessaoOriginal = new Sessao(filme, sala, DateTime.MinValue, StatusSessaoEnum.Não_Iniciado);

        repositorioSessao.Inserir(sessaoOriginal);

        Sessao sessaoParaAtualizacao = repositorioSessao.SelecionarPorId(sessaoOriginal.Id);

        //Act
        repositorioSessao.Editar(sessaoOriginal, sessaoParaAtualizacao);

        //Assert 
        Assert.AreEqual(sessaoOriginal, sessaoParaAtualizacao);
    }

    [TestMethod]
    public void Deve_Excluir_Sessao_Corretamente()
    {
        //Arrange 
        Sala sala = new Sala(0, 0);
        Filme filme = new Filme("", 0, "", false);

        Sessao sessao = new Sessao(filme, sala, DateTime.MinValue, StatusSessaoEnum.Não_Iniciado);

        repositorioSessao.Inserir(sessao);

        //Act
        repositorioSessao.Excluir(sessao);

        //Assert
        Sessao sessaoSelecionada = repositorioSessao.SelecionarPorId(sessao.Id);

        Assert.IsNull(sessaoSelecionada);
    }

    [TestMethod]
    public void Deve_Selecionar_Sessao_Corretamente()
    {
        Sala sala = new Sala(0, 0);
        Filme filme = new Filme("", 0, "", false);

        //Arrange
        List<Sessao> sessoesParaCadastro =
        [
            new Sessao(filme, sala, DateTime.MinValue, StatusSessaoEnum.Não_Iniciado),
            new Sessao(filme, sala, DateTime.MinValue, StatusSessaoEnum.Em_Andamento),
            new Sessao(filme, sala, DateTime.MinValue, StatusSessaoEnum.Finalizado)
        ];

        foreach(Sessao sessao in sessoesParaCadastro)
            repositorioSessao.Inserir(sessao);

        //Act
        List<Sessao> sessoesSelecionadas = repositorioSessao.SelecionarTodos();

        //Assert
        CollectionAssert.AreEqual(sessoesParaCadastro, sessoesSelecionadas);
    }
}

