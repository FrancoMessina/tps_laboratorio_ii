using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;

namespace TestsProyecto.TestsServicio
{
    [TestClass]
    public class TestCostoControlAire
    {
        [TestMethod]
        public void CalcularCosto_DeberiaRetornar600_CuandoControlAireNoEmiteSenial()
        {
            //Arrange
            List<string> listaFallas = new List<string>();
            listaFallas.Add(EFallaControlAire.NoEmiteSenial.ToString());
            Control controlTv = new Control(EMarcaTV.LG.ToString(), EModeloControl.IR.ToString(), listaFallas, ETipoControl.Aire);
            float valorEsperado = 600;

            //Act
            float valorActual = controlTv.CalcularCosto();

            //Assert
            Assert.AreEqual(valorEsperado, valorActual);
        }
        [TestMethod]
        public void CalcularCosto_DeberiaRetornar700_CuandoControlAireTieneDisplayRoto()
        {
            //Arrange
            List<string> listaFallas = new List<string>();
            listaFallas.Add(EFallaControlAire.DisplayRoto.ToString());
            Control controlTv = new Control(EMarcaTV.Philips.ToString(), EModeloControl.IR.ToString(), listaFallas, ETipoControl.Aire);
            float valorEsperado = 700;

            //Act
            float valorActual = controlTv.CalcularCosto();

            //Assert
            Assert.AreEqual(valorEsperado, valorActual);
        }
        [TestMethod]
        public void CalcularCosto_DeberiaRetornar300_CuandoControlAireTieneBajaSenial()
        {
            //Arrange
            List<string> listaFallas = new List<string>();
            listaFallas.Add(EFallaControlAire.BajaSenial.ToString());
            Control controlTv = new Control(EMarcaTV.Sony.ToString(), EModeloControl.RF.ToString(), listaFallas, ETipoControl.Aire);
            float valorEsperado = 300;

            //Act
            float valorActual = controlTv.CalcularCosto();

            //Assert
            Assert.AreEqual(valorEsperado, valorActual);
        }
    }
}
