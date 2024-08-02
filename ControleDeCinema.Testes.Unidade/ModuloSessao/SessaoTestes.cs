using System;
using System.Collections.Generic;
using ControleDeCinema.Dominio.ModuloFilme;
using ControleDeCinema.Dominio.ModuloSala;
using ControleDeCinema.Dominio.ModuloSessao;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ControleDeCinema.Testes.Unidade.ModuloSessao;

[TestClass]
[TestCategory("Testes de Unidade de Sessao")]
public class SessaoTestes
{
    [TestMethod]
    public void Deve_Validar_Sessao_Corretamente()
    {
        //Arrange
        Filme filme = new Filme();
        Sala sala = new Sala();
        Sessao sessaoInvalida = new Sessao(filme, sala, DateTime.MinValue, StatusSessaoEnum.Em_Andamento);

        List<string> errosEsperados =
        [
            "O campo \"Filme\" é obrigatório",
            "O campo \"Sala\" é obrigatório",
            "O campo \"Horario\" é obrigatório"
        ];

        //Act
        List<string> erros = sessaoInvalida.Validar();

        //Assert
        CollectionAssert.AreEqual(errosEsperados, erros);
    }
}

