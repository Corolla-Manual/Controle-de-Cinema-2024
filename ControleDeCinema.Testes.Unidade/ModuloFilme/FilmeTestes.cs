using System.Collections.Generic;
using ControleDeCinema.Dominio.ModuloFilme;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ControleDeCinema.Testes.Unidade.ModuloFilme;

[TestClass]
[TestCategory("Testes de Unidade de Filme")]
public class FilmeTestes
{
    [TestMethod]
    public void Deve_Validar_Filme_Corretamente()
    {
        //Arrange
        Filme filmeInvalido = new Filme("", 0, "", false);

        List<string> errosEsperados =
        [
            "O campo \"Titulo\" é obrigatório!",
            "O campo \"Genero\" é obrigatório!",
            "O campo \"Duracao\" não pode ser igual ou menor que 0!"
        ];

        //Act
        List<string> erros = filmeInvalido.Validar();

        //Assert
        CollectionAssert.AreEqual(errosEsperados, erros);
    }
}