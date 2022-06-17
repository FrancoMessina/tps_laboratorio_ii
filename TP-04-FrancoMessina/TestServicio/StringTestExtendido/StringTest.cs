using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades.ValidacionesCliente;

namespace TestsProyecto.StringTestExtendido
{
    [TestClass]
    public class StringTest
    {
        //Public void y [TestMethod]
        [TestMethod]
        public void VerificarContieneSoloLetras_CuandoRecibeDosPalabrasSeparadaPorEspacio_DeberiaRetornarTrue()
        {
            //Arrange
            string texto = "Franco Messina";
            bool expected = true; 
            bool actual;

            //Act
            actual = texto.VerificarContieneSoloLetras();

            //Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void VerificarContieneSoloLetras_CuandoRecibeUnNumeroDeberiaRetornarFalse()
        {
            //Arrange
            string texto = "Lucas1";
            bool expected = false;
            bool actual;

            //Act
            actual = texto.VerificarContieneSoloLetras();

            //Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void VerificarContieneSoloLetras_CuandoRecibeUnSignoMasDeberiaRetornarFalse()
        {
            //Arrange
            string texto = "Mauricio +";
            bool expected = false;
            bool actual;

            //Act
            actual = texto.VerificarContieneSoloLetras();

            //Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void VerificarContieneSoloLetras_CuandoRecibeCualquierSignoDeberiaRetornarFalse()
        {
            //Arrange
            string texto = "Pepe +*¨_: Argento";
            bool expected = false;
            bool actual;

            //Act
            actual = texto.VerificarContieneSoloLetras();

            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
