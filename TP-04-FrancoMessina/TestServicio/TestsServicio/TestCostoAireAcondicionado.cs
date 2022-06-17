using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;
namespace TestsProyecto.TestServicio
{
    [TestClass]
    public class TestCostoAireAcondicionado
    {
        [TestMethod]
        public void CalcularCosto_DeberiaRetornar6000_CuandoAireTieneFallaSoloFrio()
        {
            //Arrange
            List<string> listaFallas = new List<string>();
            listaFallas.Add(EFallaAire.SoloFrio.ToString());
            AireAcondicionado aireAcondicionado = new AireAcondicionado(EMarcaAire.Surrey.ToString(),EMarcaAire.Samsung.ToString(),listaFallas);
            float valorEsperado = 6000;

            //Act
            float valorActual = aireAcondicionado.CalcularCosto();

            //Assert
            Assert.AreEqual(valorEsperado, valorActual);
        }
        [TestMethod]
        public void CalcularCosto_DeberiaRetornar5600_CuandoAireTieneFallaSoloCalor()
        {
            //Arrange
            List<string> listaFallas = new List<string>();
            listaFallas.Add(EFallaAire.SoloCalor.ToString());
            AireAcondicionado aireAcondicionado = new AireAcondicionado(EMarcaAire.Samsung.ToString(), EMarcaAire.Samsung.ToString(), listaFallas);
            float valorEsperado = 5600;

            //Act
            float valorActual = aireAcondicionado.CalcularCosto();

            //Assert
            Assert.AreEqual(valorEsperado, valorActual);
        }
        [TestMethod]
        public void CalcularCosto_DeberiaRetornar9500_CuandoAireTieneFallaPierdeAgua()
        {
            //Arrange
            List<string> listaFallas = new List<string>();
            listaFallas.Add(EFallaAire.PierdeAgua.ToString());
            AireAcondicionado aireAcondicionado = new AireAcondicionado(EMarcaAire.Samsung.ToString(), EMarcaAire.Samsung.ToString(), listaFallas);
            float valorEsperado = 9500;

            //Act
            float valorActual = aireAcondicionado.CalcularCosto();

            //Assert
            Assert.AreEqual(valorEsperado, valorActual);
        }
        [TestMethod]
        public void CalcularCosto_DeberiaRetornar15500_CuandoAireTieneFallaPierdeAguaYFallaSoloFrio()
        {
            //Arrange
            List<string> listaFallas = new List<string>();
            listaFallas.Add(EFallaAire.PierdeAgua.ToString());
            listaFallas.Add(EFallaAire.SoloFrio.ToString());
            AireAcondicionado aireAcondicionado = new AireAcondicionado(EMarcaAire.Samsung.ToString(), EMarcaAire.Samsung.ToString(), listaFallas);
            float valorEsperado = 15500;

            //Act
            float valorActual = aireAcondicionado.CalcularCosto();

            //Assert
            Assert.AreEqual(valorEsperado, valorActual);
        }
        [TestMethod]
        public void CalcularCosto_DeberiaRetornar15100_CuandoAireTieneFallaPierdeAguaYFallaSoloCalor()
        {
            //Arrange
            List<string> listaFallas = new List<string>();
            listaFallas.Add(EFallaAire.PierdeAgua.ToString());
            listaFallas.Add(EFallaAire.SoloCalor.ToString());
            AireAcondicionado aireAcondicionado = new AireAcondicionado(EMarcaAire.Samsung.ToString(), EMarcaAire.Samsung.ToString(), listaFallas);
            float valorEsperado = 15100;

            //Act
            float valorActual = aireAcondicionado.CalcularCosto();

            //Assert
            Assert.AreEqual(valorEsperado, valorActual);
        }
    }
    
}
