using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;
using Entidades.Excepciones;
using Entidades.Gestor_de_Archivos;
using Entidades.Gestor_de_Costos;
namespace Vista
{
    public partial class frmServicios : Form
    {
        private Administracion gestionServicios;
        private Cliente cliente;
        private GestionCostos gestionCostos;
        int indexCliente;
        public frmServicios(Administracion gestionServicios, Cliente cliente)
        {
            InitializeComponent();
            this.gestionServicios = gestionServicios;
            indexCliente = gestionServicios.ListaClientes.IndexOf(cliente);
            this.cliente = cliente;
            gestionCostos = new GestionCostos();
        }
        /// <summary>
        /// Muestra la lista de servicios al cargar y un label con los datos personales del cliente.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmServicios_Load(object sender, EventArgs e)
        {
            try
            {
                this.cliente.ListaServicios.Sort((servicioUno, servicioDos) => servicioUno.Precio.CompareTo(servicioDos.Precio));
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                this.ActualizarListaServicios();
            }
        }
        /// <summary>
        /// Actualiza la lista de servicios
        /// </summary>
        private void ActualizarListaServicios()
        {
            this.lstServicios.DataSource = null;
            this.lstServicios.DataSource = gestionServicios.ListaClientes[indexCliente].ListaServicios;

        }
        /// <summary>
        /// Valida si la listbox tiene un servicio y  si esta seleccionado
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ServicioNoExistenteException"></exception>
        public bool ValidarExisteServicio()
        {
            int index = lstServicios.SelectedIndex;
            if (index == -1 && lstServicios.Items.Count == 0)
            {
                throw new ServicioNoExistenteException("No hay ningun servicio en la lista!");
            }
            else if (index == -1)
            {
                throw new ServicioNoExistenteException("No hay ningun servicio seleccionado!");
            }
            return true;
        }
        /// <summary>
        /// Cuando el formulario se esta cerrando, le pregunta al usuario si quiere salir.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmServicios_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dialogRespuesta = MessageBox.Show("¿Seguro de queres salir?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogRespuesta == DialogResult.Yes)
                e.Cancel = false;
            else
                e.Cancel = true;
        }
        /// <summary>
        /// Crea el ticket del servicio seleccionado.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCrearTicket_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidarExisteServicio())
                {
                    Servicio servicio = (Servicio)lstServicios.SelectedItem;
                    ArchivoTXT archivoTexto = new ArchivoTXT();
                    string mensaje = archivoTexto.Escribir($"{cliente.Nombre}{cliente.Apellido} ", Servicio.GenerarTicket(cliente, servicio));
                    MessageBox.Show(mensaje, "Ticket generado", MessageBoxButtons.OK, MessageBoxIcon.None);
                }
            }
            catch (ServicioNoExistenteException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception)
            {
                MessageBox.Show("Error!");
            }
        }
        /// <summary>
        /// El evento click en el boton salir te oculta el formulario.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
        /// <summary>
        /// El evento InformacionDeCostoFinal se va a suscribir al metodo CalcularCostoFinal
        /// El evento InformacionDeTiempo se va a suscribir al metodo CargandoCosto
        /// Se deshabilita el boton CalcularCosto
        /// Un run de la nueva tarea en otro hilo utilizando el metodo IniciarCalculo.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCalcularCosto_Click(object sender, EventArgs e)
        {
            gestionCostos.InformarCostoFinal += CalcularCostoFinal;
            gestionCostos.InformarTiempo += CargandoCosto;
            List<Servicio> listaAux = gestionServicios.ListaClientes[indexCliente].ListaServicios;
            btnCalcularCosto.Enabled = false;
            Task tarea = Task.Run(() => gestionCostos.IniciarCalculo(listaAux));
        }
        /// <summary>
        /// Se pregunta si se quiere modificar el lblFinal si la prop InvokeRequired da true 
        /// se hace un callback y luego entra al else modificando el control.
        /// </summary>
        /// <param name="precioFinal">Precio Final del calculo</param>
        public void CalcularCostoFinal(float precioFinal)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new InformacionDeCostoFinal(CalcularCostoFinal),new object[] { precioFinal });
            }
            else
            {
                lblCostoFinal.Text = $"Costo Final de todos los Servicios ${precioFinal}";
                lblCostoFinal.BackColor = Color.Green;
            }
        }
        /// <summary>
        /// Se pregunta si se quiere modificar el lblCostoFinal si la prop InvokeRequired da true 
        /// se hace un callback y luego entra al else modificando el control.
        /// </summary>
        /// <param name="tiempo">Tiempo que tarda para cargar el costo</param>
        public void CargandoCosto(int tiempo)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new InformacionDeTiempo(CargandoCosto), new object[] { tiempo });
            }
            else
            {
                lblCostoFinal.Text = $"Calculando costos... {tiempo / 1000}";
                lblCostoFinal.BackColor = Color.Red;
            }
        }
    }
}
