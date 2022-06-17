using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;

namespace TestsProyecto.TestsServicio
{
    [TestClass]
    public class TestCostoControlTv
    {
        [TestMethod]
        public void CalcularCosto_DeberiaRetornar600_CuandoControlDeTvNoEmiteSenial()
        {
            //Arrange
            List<string> listaFallas = new List<string>();
            listaFallas.Add(EFallaControlTv.NoEmiteSenial.ToString());
            Control controlTv = new Control(EMarcaTV.Sony.ToString(),EModeloControl.RF.ToString(), listaFallas,ETipoControl.TV);
            float valorEsperado = 600;

            //Act
            float valorActual = controlTv.CalcularCosto();

            //Assert
            Assert.AreEqual(valorEsperado, valorActual);
        }
        [TestMethod]
        public void CalcularCosto_DeberiaRetornar400_CuandoControlDeTvNoFuncionaBoton()
        {
            //Arrange
            List<string> listaFallas = new List<string>();
            listaFallas.Add(EFallaControlTv.NoFuncionaBoton.ToString());
            Control controlTv = new Control(EMarcaTV.Philips.ToString(), EModeloControl.IR.ToString(), listaFallas, ETipoControl.TV);
            float valorEsperado = 400;

            //Act
            float valorActual = controlTv.CalcularCosto();

            //Assert
            Assert.AreEqual(valorEsperado, valorActual);
        }
        [TestMethod]
        public void CalcularCosto_DeberiaRetornar900_CuandoControlDeTvTienePortaPilaSulfatado()
        {
            //Arrange
            List<string> listaFallas = new List<string>();
            listaFallas.Add(EFallaControlTv.PortaPilaSulfatado.ToString());
            Control controlTv = new Control(EMarcaTV.Philips.ToString(), EModeloControl.IR.ToString(), listaFallas, ETipoControl.TV);
            float valorEsperado = 900;

            //Act
            float valorActual = controlTv.CalcularCosto();

            //Assert
            Assert.AreEqual(valorEsperado, valorActual);
        }
        [TestMethod]
        public void CalcularCosto_DeberiaRetornar1300_CuandoControlDeTvTienePortaPilaSulfatadoYNoFuncionaBoton()
        {
            //Arrange
            List<string> listaFallas = new List<string>();
            listaFallas.Add(EFallaControlTv.PortaPilaSulfatado.ToString());
            listaFallas.Add(EFallaControlTv.NoFuncionaBoton.ToString());
            Control controlTv = new Control(EMarcaTV.Philips.ToString(), EModeloControl.IR.ToString(), listaFallas, ETipoControl.TV);
            float valorEsperado = 1300;

            //Act
            float valorActual = controlTv.CalcularCosto();

            //Assert
            Assert.AreEqual(valorEsperado, valorActual);
        }
        [TestMethod]
        public void CalcularCosto_DeberiaRetornar1900_CuandoControlDeTvTienePortaPilaSulfatadoNoFuncionaBotonYNoEmiteSenial()
        {
            //Arrange
            List<string> listaFallas = new List<string>();
            listaFallas.Add(EFallaControlTv.PortaPilaSulfatado.ToString());
            listaFallas.Add(EFallaControlTv.NoFuncionaBoton.ToString());
            listaFallas.Add(EFallaControlTv.NoEmiteSenial.ToString());
            Control controlTv = new Control(EMarcaTV.Philips.ToString(), EModeloControl.IR.ToString(), listaFallas, ETipoControl.TV);
            float valorEsperado = 1900;

            //Act
            float valorActual = controlTv.CalcularCosto();

            //Assert
            Assert.AreEqual(valorEsperado, valorActual);
        }
    }
}
