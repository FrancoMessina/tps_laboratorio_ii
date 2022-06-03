using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades.ValidacionesCliente;
using Entidades.Excepciones;
namespace TestsProyecto.TestsClienteExcepciones
{
    [TestClass]
    public class TestDatosCliente
    {
        [TestMethod]
        [ExpectedException(typeof(NombreInvalidoException))]
        public void ValidarNombre_CuandoRecibeMenosDe3Letras_DeberiaLanzarNombreInvalidoException()
        {
            //Arrange
            string nombre = "fr";

            //Act
            bool actual = ValidarCliente.ValidarNombre(nombre); 

            //Assert

        }
        [TestMethod]
        [ExpectedException(typeof(NombreInvalidoException))]
        public void ValidarNombre_CuandoRecibeMasDe20Letras_DeberiaLanzarNombreInvalidoException()
        {
            //Arrange
            string nombre = "carodasjskadjkaskjsakjadjkjkasjkddjkaskjsa";

            //Act
            bool actual = ValidarCliente.ValidarNombre(nombre);

            //Assert
        }
        [TestMethod]
        [ExpectedException(typeof(NombreInvalidoException))]
        public void ValidarNombre_CuandoRecibeNumeros_DeberiaLanzarNombreInvalidoException()
        {
            //Arrange
            string nombre = "Facu1234";

            //Act
            bool actual = ValidarCliente.ValidarNombre(nombre);

            //Assert
        }
        [TestMethod]
        [ExpectedException(typeof(ApellidoInvalidoException))]
        public void ValidarApellido_CuandoRecibeMenosDe3Letras_DeberiaLanzarApellidoInvalidoException()
        {
            //Arrange
            string apellido = "ad";

            //Act
            bool actual = ValidarCliente.ValidarApellido(apellido);

            //Assert

        }
        [TestMethod]
        [ExpectedException(typeof(ApellidoInvalidoException))]
        public void ValidarApellido_CuandoRecibeMasDe20Letras_DeberiaLanzarApellidoInvalidoException()
        {
            //Arrange
            string apellido = "faodasjskadjkaskjsakja";

            //Act
            bool actual = ValidarCliente.ValidarApellido(apellido);

            //Assert
        }
        [TestMethod]
        [ExpectedException(typeof(ApellidoInvalidoException))]
        public void ValidarApellido_CuandoRecibeNumeros_DeberiaLanzarApellidoInvalidoException()
        {
            //Arrange
            string apellido = "Messina1234";

            //Act
            bool actual = ValidarCliente.ValidarApellido(apellido);

            //Assert
        }
        [TestMethod]
        [ExpectedException(typeof(DniInvalidoException))]
        public void ValidarDni_CuandoRecibeLetras_DeberiaLanzarDniInvalidoException()
        {
            //Arrange
            string dni = "4119528a";

            //Act
            bool actual = ValidarCliente.ValidarDni(dni);

            //Assert
        }
        [TestMethod]
        [ExpectedException(typeof(DniInvalidoException))]
        public void ValidarDni_CuandoRecibeDniMayorA999999999_DeberiaLanzarDniInvalidoException()
        {
            //Arrange
            string dni = "99999999999999999999999";

            //Act
            bool actual = ValidarCliente.ValidarDni(dni);

            //Assert
        }
        [TestMethod]
        [ExpectedException(typeof(DniInvalidoException))]
        public void ValidarDni_CuandoRecibeDniMenorA0_DeberiaLanzarDniInvalidoException()
        {
            //Arrange
            string dni = "-1";

            //Act
            bool actual = ValidarCliente.ValidarDni(dni);

            //Assert
        }
        [TestMethod]
        [ExpectedException(typeof(NumeroInvalidoExcepction))]
        public void ValidarNumeroTel_CuandoRecibeLetras_DeberiaLanzarNumeroInvalidoExcepction()
        {
            //Arrange
            string numero = "11394277asd";

            //Act
            bool actual = ValidarCliente.ValidarNumeroTel(numero);

            //Assert
        }
        [TestMethod]
        [ExpectedException(typeof(NumeroInvalidoExcepction))]
        public void ValidarNumeroTel_CuandoNoRecibe10Digitos_DeberiaLanzarNumeroInvalidoExcepction()
        {
            //Arrange
            string numero = "11394277621";

            //Act
            bool actual = ValidarCliente.ValidarNumeroTel(numero);

            //Assert
        }
        [TestMethod]
        [ExpectedException(typeof(CamposVaciosONullException))]
        public void ValidarCamposCliente_CuandoRecibeNombreVacioONull_DeberiaLanzarCamposVaciosONullException()
        {
            //Arrange
            string nombre = string.Empty;

            //Act
            bool actual = ValidarCliente.ValidarCamposCliente(nombre,"Messina","41195283","1139427766");

            //Assert
        }
        [TestMethod]
        [ExpectedException(typeof(CamposVaciosONullException))]
        public void ValidarCamposCliente_CuandoRecibeApellidoVacioONull_DeberiaLanzarCamposVaciosONullException()
        {
            //Arrange
            string apellido = string.Empty;

            //Act
            bool actual = ValidarCliente.ValidarCamposCliente("Lucas", apellido, "41195281", "1139421123");

            //Assert
        }
        [TestMethod]
        [ExpectedException(typeof(CamposVaciosONullException))]
        public void ValidarCamposCliente_CuandoRecibeDniVacioONull_DeberiaLanzarCamposVaciosONullException()
        {
            //Arrange
            string dni = string.Empty;

            //Act
            bool actual = ValidarCliente.ValidarCamposCliente("Lucas", "Rodriguez", dni, "1139427766");

            //Assert
        }
        [TestMethod]
        [ExpectedException(typeof(CamposVaciosONullException))]
        public void ValidarCamposCliente_CuandoRecibeNumeroTelVacioONull_DeberiaLanzarCamposVaciosONullException()
        {
            //Arrange
            string numeroTel = string.Empty;

            //Act
            bool actual = ValidarCliente.ValidarCamposCliente("Lucas", "Rodriguez", "39195283", numeroTel);

            //Assert
        }
    }
    
}
