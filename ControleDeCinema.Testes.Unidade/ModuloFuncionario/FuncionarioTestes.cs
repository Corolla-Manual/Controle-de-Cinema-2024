using System.Collections.Generic;
using ControleDeCinema.Dominio.ModuloFuncionario;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ControleDeCinema.Testes.Unidade.ModuloFuncionario;

[TestClass]
[TestCategory("Testes de Unidade de Funcionarios")]
public class FuncionarioTestes
{
    [TestMethod]
    public void Deve_Validar_Funcionario_Corretamente()
    {
        //Arrange
        Funcionario funcionarioInvalido = new Funcionario("", "", "");

        List<string> errosEsperados =
        [
            "O campo \"Nome\" é obrigatório!",
            "O campo \"Login\" é obrigatório!",
            "O campo \"Senha\" é obrigatório!"
        ];

        // Act
        List<string> erros = funcionarioInvalido.Validar();

        //Assert
        CollectionAssert.AreEqual(errosEsperados, erros);
    }
}

