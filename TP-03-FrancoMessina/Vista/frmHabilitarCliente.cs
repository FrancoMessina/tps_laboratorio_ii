using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using Entidades.Excepciones;
using Entidades;
namespace Vista
{
    public partial class frmHabilitarCliente : Form
    {
        private Administracion gestionServicios;
        public frmHabilitarCliente()
        {   
            InitializeComponent();
        }
        public frmHabilitarCliente(Administracion gestionServicios):this()
        {
            this.gestionServicios = gestionServicios;
        }
        private void frmHabilitarCliente_Load(object sender, EventArgs e)
        {
            this.ActualizarListaClientes();
        }
        private bool ValidarExisteClienteEnLista()
        {
            int index = lstClientes.SelectedIndex;
            if (index == -1 && lstClientes.Items.Count == 0)
            {
                throw new ClienteNoExistenteException("No hay ningun cliente en la lista!");
            }
            else if (index == -1)
            {
                throw new ClienteNoExistenteException("No hay ningun cliente seleccionado!");
            }
            return true;
        }
        private void ActualizarListaClientes()
        {
            this.lstClientes.DataSource = null;
            this.lstClientes.DataSource = gestionServicios.ListaClienteBaja();

        }

        private void btnHabilitarCliente_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidarExisteClienteEnLista())
                {
                    int index = lstClientes.SelectedIndex;
                    Cliente cliente = (Cliente)lstClientes.SelectedItem;
                    string mensaje = Administracion.RehabilitarCliente(gestionServicios,cliente);
                    this.ActualizarListaClientes();
                    MessageBox.Show(mensaje, "Alta",MessageBoxButtons.OK,MessageBoxIcon.Information);
                }
            }
            catch (ClienteNoExistenteException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception)
            {
                MessageBox.Show("Error!");
            }
        }
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
