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

        private void frmServicios_Load(object sender, EventArgs e)
        {
            this.ActualizarListaClientes();
            lblDatos.Text = $"{cliente.Nombre} {cliente.Apellido}";
        }
        private void ActualizarListaClientes()
        {
            this.lstServicios.DataSource = null;
            this.lstServicios.DataSource = gestionServicios.ListaClientes[indexCliente].ListaServicios;

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidarExisteServicio())
                {
                    Servicio servicio = (Servicio)lstServicios.SelectedItem;
                    Administracion.EliminarServicio(gestionServicios, gestionServicios.ListaClientes[indexCliente], servicio);
                    ActualizarListaClientes();
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

        private void frmServicios_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dialogRespuesta = MessageBox.Show("¿Seguro de queres salir?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogRespuesta == DialogResult.Yes)
                e.Cancel = false;
            else
                e.Cancel = true;
        }

        private void btnCrearTicket_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidarExisteServicio())
                {
                    Servicio servicio = (Servicio)lstServicios.SelectedItem;
                    ArchivoTXT archivoTexto = new ArchivoTXT();
                    string mensaje = archivoTexto.Escribir($"{cliente.Nombre}{cliente.Apellido}", Servicio.GenerarTicket(cliente, servicio));
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
    }
}
