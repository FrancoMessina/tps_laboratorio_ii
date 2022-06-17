using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Entidades;
using Entidades.Excepciones;
namespace Entidades.GestorSQL
{
    public static class ClienteDAO
    {
        private static string cadenaConexion;

        static ClienteDAO()
        {
            ClienteDAO.cadenaConexion = "Server=.;Database=TP4FRANCOMESSINA;Trusted_Connection=True;";
        }
        /// <summary>
        /// Lee los datos de los clientes
        /// </summary>
        /// <returns></returns>
        /// <exception cref="CargaInvalidaSQLException">Cualquier error lanza esta excepcion</exception>
        private static List<Cliente> LeerDatosClientes()
        {
            try
            {
                List<Cliente> lista = new List<Cliente>();
                string query = "select * from clientes";
                using (SqlConnection connection = new SqlConnection(cadenaConexion))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        string dni = reader.GetString(0);
                        string nombre = reader.GetString(1);
                        string apellido = reader.GetString(2);
                        string numeroTel = reader.GetString(3);
                        bool dadoDeAlta = reader.GetBoolean(4);

                        Cliente auxCliente = new Cliente(dni, nombre, apellido, numeroTel);
                        auxCliente.DadoDeAlta = dadoDeAlta;
                        lista.Add(auxCliente);
                    }
                }
                return lista;
            }
            catch (Exception)
            {
                throw new CargaInvalidaSQLException("Error al leer los datos de los clientes");
            }
            
        }

        /// <summary>
        /// Lee los servicios de un cliente cuando su dni coincide con algun dni de la tabla Servicios.
        /// </summary>
        /// <param name="cliente"></param>
        /// <exception cref="CargaInvalidaSQLException">Cualquier error lanza esta excepcion</exception>
        private static void LeerServiciosDeCliente(Cliente cliente)
        {
            try
            {
                string query = $"Select Servicios.precio,Servicios.tipoEntrega,Servicios.dni_cliente,Servicios.nombre, Servicios.marca, Servicios.modelo,Servicios.fallaUno, Servicios.fallaDos, Servicios.fallaTres, Servicios.tipo from Clientes JOIN  Servicios ON  Servicios.dni_cliente = Clientes.dni where Clientes.Dni = '{cliente.Dni}'";
                List<Servicio> lista = new List<Servicio>();

                using (SqlConnection connection = new SqlConnection(cadenaConexion))
                {
                    SqlCommand cmd = new SqlCommand(query, connection);
                    connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        float precio = (float)reader.GetDouble(0);
                        ETipoEntrega tipoEntrega = (ETipoEntrega)reader.GetInt32(1);
                        string dni_cliente = reader.GetString(2);
                        string nombreProducto = reader.GetString(3);
                        string marca = reader.GetString(4);
                        string modelo = reader.GetString(5);
                        string fallaUno = reader["fallaUno"] is not DBNull ? reader.GetString(6) : string.Empty;
                        string fallaDos = reader["fallaDos"] is not DBNull ? reader.GetString(7) : string.Empty;
                        string fallaTres = reader["fallaTres"] is not DBNull ? reader.GetString(8) : string.Empty;
                        List<String> listFallas = new List<String>();
                        listFallas.Add(fallaUno);
                        listFallas.Add(fallaDos);
                        listFallas.Add(fallaTres);
                        if (nombreProducto == "Televisor")
                        {
                            ETipoTv tipoTv = (ETipoTv)reader.GetInt32(9);
                            Televisor televisor = new Televisor(marca, modelo, listFallas, tipoTv);
                            lista.Add(new Servicio(tipoEntrega, televisor, precio, dni_cliente));
                        }
                        else if (nombreProducto == "Control")
                        {
                            ETipoControl tipoControl = (ETipoControl)reader.GetInt32(9);
                            Control control = new Control(marca, modelo, listFallas, tipoControl);
                            lista.Add(new Servicio(tipoEntrega, control, precio, dni_cliente));
                        }
                        else if (nombreProducto == "AireAcondicionado")
                        {
                            AireAcondicionado aire = new AireAcondicionado(marca, modelo, listFallas);
                            lista.Add(new Servicio(tipoEntrega, aire, precio, dni_cliente));
                        }
                    }
                    cliente.ListaServicios = lista;
                }
            }
            catch (Exception)
            {
                throw new CargaInvalidaSQLException("Error al leer los datos de los servicios");
            }
            
        }
        /// <summary>
        /// Lista los clientes  y le agrega los servicios que le corresponde a cada cliente.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="CargaInvalidaSQLException">Cualquier error lanza esta excepcion</exception>
        public static List<Cliente> ListarClientes()
        {
            try
            {
                List<Cliente> listaCliente = LeerDatosClientes();
                foreach (Cliente cliente in listaCliente)
                {
                    LeerServiciosDeCliente(cliente);
                }
                return listaCliente;
            }
            catch (Exception)
            {
                throw new CargaInvalidaSQLException("Error al listar todos los clientes");
            }
        }
        /// <summary>
        /// Da de alta un cliente y lo inserta en la tabla de Clientes.
        /// </summary>
        /// <param name="cliente">Cliente a dar de alta</param>
        /// <exception cref="CargaInvalidaSQLException">Cualquier error lanza esta excepcion</exception>
        public static void AltaCliente(Cliente cliente)
        {
            string query = "Insert into Clientes (dni,nombre,apellido,numeroTel,dadoDeAlta) values(@dni,@nombre,@apellido,@numeroTel,@dadoDeAlta)";
            try
            {
                using (SqlConnection connection = new SqlConnection(cadenaConexion))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("dni", cliente.Dni);
                    cmd.Parameters.AddWithValue("nombre", cliente.Nombre);
                    cmd.Parameters.AddWithValue("apellido", cliente.Apellido);
                    cmd.Parameters.AddWithValue("numeroTel", cliente.NumeroTel);
                    cmd.Parameters.AddWithValue("dadoDeAlta", cliente.DadoDeAlta);
                    cmd.ExecuteNonQuery();
                }              
            }
            catch (Exception)
            {
                throw new CargaInvalidaSQLException("Error al dar de alta el cliente");
            }

        }
        /// <summary>
        /// Alta de un servicio con el dni respectivo del cliente.
        /// </summary>
        /// <param name="servicio">Servicio a agregar</param>
        /// <param name="dni">Dni del cliente</param>
        /// <exception cref="CargaInvalidaSQLException">Cualquier error lanza esta excepcion</exception>
        public static void AltaServicio(Servicio servicio, string dni)
        {
            string query = "Insert into Servicios (precio,tipoEntrega,dni_cliente,nombre,marca,modelo,fallaUno,fallaDos,fallaTres,tipo) values(@precio,@tipoEntrega,@dni_Cliente,@nombre,@marca,@modelo,@fallaUno,@fallaDos,@fallaTres,@tipo)";
            try
            {
                using (SqlConnection connection = new SqlConnection(cadenaConexion))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand(query, connection);
                    List<String> listaFallas = CargarFallas(servicio.Producto.ListaFallas);
                    cmd.Parameters.AddWithValue("precio", servicio.Precio);
                    cmd.Parameters.AddWithValue("tipoEntrega", servicio.TipoEntrega);
                    cmd.Parameters.AddWithValue("dni_Cliente", dni);
                    cmd.Parameters.AddWithValue("nombre", servicio.Producto.GetType().Name);
                    cmd.Parameters.AddWithValue("marca", servicio.Producto.Marca);
                    cmd.Parameters.AddWithValue("modelo", servicio.Producto.Modelo);
                    cmd.Parameters.AddWithValue("fallaUno", string.IsNullOrEmpty(listaFallas[0]) ? DBNull.Value : listaFallas[0]);
                    cmd.Parameters.AddWithValue("fallaDos", string.IsNullOrEmpty(listaFallas[1]) ? DBNull.Value : listaFallas[1]);
                    cmd.Parameters.AddWithValue("fallaTres", string.IsNullOrEmpty(listaFallas[2]) ? DBNull.Value : listaFallas[2]);
                    if (servicio.Producto.GetType().Name == "AireAcondicionado")
                        cmd.Parameters.AddWithValue("tipo", DBNull.Value);
                    else if(servicio.Producto.GetType().Name == "Televisor")
                        cmd.Parameters.AddWithValue("tipo", ((Televisor)servicio.Producto).Tipo);
                    else if (servicio.Producto.GetType().Name == "Control")
                        cmd.Parameters.AddWithValue("tipo", ((Control)servicio.Producto).Tipo);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {
                throw new CargaInvalidaSQLException("Error al dar de alta el cliente");
            }

        }
        /// <summary>
        /// Baja logica se pone el bit de dadoDeAlta en 0
        /// </summary>
        /// <param name="cliente">Cliente a dar de baja</param>
        /// <exception cref="CargaInvalidaSQLException">Cualquier error lanza esta excepcion</exception>
        public static void BajaCliente(Cliente cliente)
        {
            try
            {
                string query = "update Clientes set dadoDeAlta = 0 where dni = @dni";
                using (SqlConnection connection = new SqlConnection(cadenaConexion))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("dni", cliente.Dni);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {
                throw new CargaInvalidaSQLException("Error al dar de baja el cliente");
            }
        }
        /// <summary>
        /// Recuperar cliente cargandole un 1 al bit dadoDeAlta
        /// </summary>
        /// <param name="cliente">Cliente a recuperar</param>
        /// <exception cref="CargaInvalidaSQLException">Cualquier error lanza esta excepcion</exception>
        public static void RecuperarCliente(Cliente cliente)
        {
            try
            {
                string query = "update Clientes set dadoDeAlta = 1 where dni = @dni";
                using (SqlConnection connection = new SqlConnection(cadenaConexion))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("dni", cliente.Dni);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {
                throw new CargaInvalidaSQLException("Error al recuperar cliente");
            }
        }
        /// <summary>
        /// Se updatea en la base con los datos del cliente modificado.
        /// </summary>
        /// <param name="cliente">Cliente a modificar</param>
        /// <exception cref="CargaInvalidaSQLException">Cualquier error lanza esta excepcion</exception>
        public static void ModificarCliente(Cliente cliente)
        {
            try
            {
                string query = "Update Clientes set dni = @dni, nombre = @nombre, apellido = @apellido, numeroTel = @numeroTel , dadoDeAlta = @dadoDeAlta where dni = @dni";
                using (SqlConnection connection = new SqlConnection(cadenaConexion))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("dni", cliente.Dni);
                    cmd.Parameters.AddWithValue("nombre", cliente.Nombre);
                    cmd.Parameters.AddWithValue("apellido", cliente.Apellido);
                    cmd.Parameters.AddWithValue("numeroTel", cliente.NumeroTel);
                    cmd.Parameters.AddWithValue("dadoDeAlta", cliente.DadoDeAlta);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {
                throw new CargaInvalidaSQLException("Error al modificar cliente");
            }
        }
        /// <summary>
        /// Metodo para cargar las fallas que sean necesarias que no lance una excepcion.
        /// Por ejemplo: Si el servicio tiene dos fallas se crea una lista con esas dos fallas y la tercera con un empty.
        /// </summary>
        /// <param name="lista">La lista de fallas a analizar</param>
        /// <returns>Retorna la lista de fallas.</returns>
        private static List<string> CargarFallas(List<string> lista)
        {
            for(int i = lista.Count; i >= 0; i--)
            {
                lista.Add(string.Empty);
            }
            return lista;
        }
    }
}
