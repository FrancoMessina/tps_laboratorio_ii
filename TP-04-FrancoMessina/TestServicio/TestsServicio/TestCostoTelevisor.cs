using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;
namespace TestsProyecto.TestServicio
{
    [TestClass]
    public class TestCostoTelevisor
    {
        [TestMethod]
        public void CalcularCosto_DeberiaRetornar13450_CuandoTelevisorTienePantallaRotaYEsLCD()
        {
            //Arrange
            List<string> listaFallas = new List<string>();
            listaFallas.Add(EFallaTv.PantallaRota.ToString());
            Televisor televisor = new Televisor(EMarcaTV.TopHouse.ToString(),EModeloTv.T30Pulgadas.ToString(),listaFallas,ETipoTv.LCD);
            float valorEsperado = 13450;

            //Act
            float valorActual = televisor.CalcularCosto();

            //Assert
            Assert.AreEqual(valorEsperado, valorActual);
        }
        [TestMethod]
        public void CalcularCosto_DeberiaRetornar19500_CuandoTelevisorTienePantallaRotaYEsLED()
        {
            //Arrange
            List<string> listaFallas = new List<string>();
            listaFallas.Add(EFallaTv.PantallaRota.ToString());
            Televisor televisor = new Televisor(EMarcaTV.Hitachi.ToString(), EModeloTv.T32Pulgadas.ToString(), listaFallas, ETipoTv.LED);
            float valorEsperado = 19500;

            //Act
            float valorActual = televisor.CalcularCosto();

            //Assert
            Assert.AreEqual(valorEsperado, valorActual);
        }
        [TestMethod]
        public void CalcularCosto_DeberiaRetornar5500_CuandoTelevisorNoTieneAudioYEsLCD()
        {
            //Arrange
            List<string> listaFallas = new List<string>();
            listaFallas.Add(EFallaTv.SinAudio.ToString());
            Televisor televisor = new Televisor(EMarcaTV.Hitachi.ToString(), EModeloTv.T32Pulgadas.ToString(), listaFallas, ETipoTv.LCD);
            float valorEsperado = 5500;

            //Act
            float valorActual = televisor.CalcularCosto();

            //Assert
            Assert.AreEqual(valorEsperado, valorActual);
        }
        [TestMethod]
        public void CalcularCosto_DeberiaRetornar8750_CuandoTelevisorNoTieneAudioYEsLED()
        {
            //Arrange
            List<string> listaFallas = new List<string>();
            listaFallas.Add(EFallaTv.SinAudio.ToString());
            Televisor televisor = new Televisor(EMarcaTV.Hitachi.ToString(), EModeloTv.T32Pulgadas.ToString(), listaFallas, ETipoTv.LED);
            float valorEsperado = 8750;

            //Act
            float valorActual = televisor.CalcularCosto();

            //Assert
            Assert.AreEqual(valorEsperado, valorActual);
        }
        [TestMethod]
        public void CalcularCosto_DeberiaRetornar7000_CuandoTelevisorNoTieneImagenYEsLCD()
        {
            //Arrange
            List<string> listaFallas = new List<string>();
            listaFallas.Add(EFallaTv.SinImagen.ToString());
            Televisor televisor = new Televisor(EMarcaTV.LG.ToString(), EModeloTv.T32Pulgadas.ToString(), listaFallas, ETipoTv.LCD);
            float valorEsperado = 7000;

            //Act
            float valorActual = televisor.CalcularCosto();

            //Assert
            Assert.AreEqual(valorEsperado, valorActual);
        }
        [TestMethod]
        public void CalcularCosto_DeberiaRetornar12000_CuandoTelevisorNoTieneImagenYEsLED()
        {
            //Arrange
            List<string> listaFallas = new List<string>();
            listaFallas.Add(EFallaTv.SinImagen.ToString());
            Televisor televisor = new Televisor(EMarcaTV.LG.ToString(), EModeloTv.T32Pulgadas.ToString(), listaFallas, ETipoTv.LED);
            float valorEsperado = 12000;

            //Act
            float valorActual = televisor.CalcularCosto();

            //Assert
            Assert.AreEqual(valorEsperado, valorActual);
        }
        [TestMethod]
        public void CalcularCosto_DeberiaRetornar40250_CuandoTelevisorNoTieneImagenTienePantallaRotaNoTieneAudioYEsLED()
        {
            //Arrange
            List<string> listaFallas = new List<string>();
            listaFallas.Add(EFallaTv.SinImagen.ToString());
            listaFallas.Add(EFallaTv.PantallaRota.ToString());
            listaFallas.Add(EFallaTv.SinAudio.ToString());
            Televisor televisor = new Televisor(EMarcaTV.LG.ToString(), EModeloTv.T32Pulgadas.ToString(), listaFallas, ETipoTv.LED);
            float valorEsperado = 40250;

            //Act
            float valorActual = televisor.CalcularCosto();

            //Assert
            Assert.AreEqual(valorEsperado, valorActual);
        }
        [TestMethod]
        public void CalcularCosto_DeberiaRetornar25950_CuandoTelevisorNoTieneImagenTienePantallaRotaNoTieneAudioYEsLCD()
        {
            //Arrange
            List<string> listaFallas = new List<string>();
            listaFallas.Add(EFallaTv.SinImagen.ToString());
            listaFallas.Add(EFallaTv.PantallaRota.ToString());
            listaFallas.Add(EFallaTv.SinAudio.ToString());
            Televisor televisor = new Televisor(EMarcaTV.LG.ToString(), EModeloTv.T32Pulgadas.ToString(), listaFallas, ETipoTv.LCD);
            float valorEsperado = 25950;

            //Act
            float valorActual = televisor.CalcularCosto();

            //Assert
            Assert.AreEqual(valorEsperado, valorActual);
        }
    }
}
