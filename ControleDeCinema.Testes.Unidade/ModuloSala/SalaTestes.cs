using System.Collections.Generic;
using ControleDeCinema.Dominio.ModuloSala;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ControleDeCinema.Testes.Unidade.ModuloSala;

[TestClass]
[TestCategory("Teste de Unidade de Sala")]
public class SalaTestes
{
    [TestMethod]
    public void Deve_Validar_Sala_Corretamente()
    {
        //Arrange
        Sala salaInvalida = new Sala(0, 0);

        List<string> errosEsperados =
        [
            "O campo \"Numero\" é obrigatório!",
            "O campo \"Capacidade\" é obrigatório!"
        ];

        //Act
        List<string> erros = salaInvalida.Validar();

        //Assert
        CollectionAssert.AreEqual(errosEsperados, erros);
    }
}

