using System;
using System.Collections.Generic;
using ControleDeCinema.Dominio.ModuloFuncionario;
using ControleDeCinema.Infra.Orm.Compartilhado;
using ControleDeCinema.Infra.Orm.ModuloFuncionario;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ControleDeCinema.Testes.Integracao.ModuloFuncionario;

[TestClass]
[TestCategory("Testes de Integração de Funcionario")]
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

    [TestMethod]
    public void Deve_Inserir_Funcionario_Corretamente()
    {
        //Arrange
        Funcionario novoFuncionario = new Funcionario("", "", "");

        //Act
        repositorioFuncionario.Inserir(novoFuncionario);

        //Assert
        Funcionario funcionarioSelecionado = repositorioFuncionario.SelecionarPorId(novoFuncionario.Id);

        Assert.AreEqual(novoFuncionario, funcionarioSelecionado);
    }

    [TestMethod]
    public void Deve_Editar_Funcionario_Corretamente()
    {
        //Arrange 
        Funcionario funcionarioOriginal = new Funcionario("", "", "");

        repositorioFuncionario.Inserir(funcionarioOriginal);

        Funcionario funcionarioParaAtualizacao = repositorioFuncionario.SelecionarPorId(funcionarioOriginal.Id);

        //Act
        repositorioFuncionario.Editar(funcionarioOriginal, funcionarioParaAtualizacao);

        //Assert
        Assert.AreEqual(funcionarioOriginal, funcionarioParaAtualizacao);
    }

    [TestMethod]
    public void Deve_Excluir_Funcionario_Corretamente()
    {
        //Arrange
        Funcionario funcionario = new Funcionario("", "", "");

        repositorioFuncionario.Inserir(funcionario);

        //Act
        repositorioFuncionario.Excluir(funcionario);

        //Assert
        Funcionario funcionarioSelecionado = repositorioFuncionario.SelecionarPorId(funcionario.Id);

        Assert.IsNull(funcionarioSelecionado);
    }

    [TestMethod]
    public void Deve_Selecionar_Funcionario_Corretamente()
    {
        //Assert
        List<Funcionario> funcionariosParaCadastro =
        [
            new Funcionario("", "", ""),
            new Funcionario("a", "a", "a"),
            new Funcionario("b", "b", "b")
        ];

        foreach (Funcionario funcionario in funcionariosParaCadastro)
            repositorioFuncionario.Inserir(funcionario);

        //Act
        List<Funcionario> funcionariosSelecionados = repositorioFuncionario.SelecionarTodos();

        //Assert
        CollectionAssert.AreEqual(funcionariosParaCadastro, funcionariosSelecionados);
    }
}