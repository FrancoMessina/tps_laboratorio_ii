using System;
using System.Windows.Forms;
using Entidades;
using Entidades.Excepciones;
using Entidades.Gestor_de_Archivos;
namespace Vista
{
    public partial class frmServicios : Form
    {
        private Administracion gestionServicios;
        private Cliente cliente;
        int indexCliente;
        public frmServicios(Administracion gestionServicios, Cliente cliente)
        {
            InitializeComponent();
            this.gestionServicios = gestionServicios;
            indexCliente = gestionServicios.ListaClientes.IndexOf(cliente);
            this.cliente = cliente;
        }
        /// <summary>
        /// Muestra la lista de servicios al cargar y un label con los datos personales del cliente.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmServicios_Load(object sender, EventArgs e)
        {
            this.ActualizarListaServicios();
            lblDatos.Text = $"{cliente.Nombre} {cliente.Apellido}";
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
        /// Elimina el servicio seleccionado.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidarExisteServicio())
                {
                    Servicio servicio = (Servicio)lstServicios.SelectedItem;
                    Administracion.EliminarServicio(gestionServicios, gestionServicios.ListaClientes[indexCliente], servicio);
                    this.ActualizarListaServicios();
                    MessageBox.Show("Servicio removido exitosamente!","Servicio eliminado",MessageBoxButtons.OK,MessageBoxIcon.None);
                }
                
            }
            catch (ServicioNoExistenteException ex)
            {
                MessageBox.Show(ex.Message,"Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception)
            {
                MessageBox.Show("Error!");
            }
            
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
    }
}
