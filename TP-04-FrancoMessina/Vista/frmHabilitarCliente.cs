using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using Entidades.Excepciones;
using Entidades;
using Entidades.GestorSQL;

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
        /// <summary>
        /// Cuando se carga el formulario carga la lista de clientes que estan dados de baja.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmHabilitarCliente_Load(object sender, EventArgs e)
        {
            this.ActualizarListaClientes();
        }
        /// <summary>
        /// Valida si existe un cliente en la listbox y si esta seleccionado.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ClienteNoExistenteException">Lanza la excepcion con el mensaje adecuado.</exception>
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
        /// <summary>
        /// Actualiza la lista de clientes.
        /// </summary>
        private void ActualizarListaClientes()
        {
            this.lstClientes.DataSource = null;
            this.lstClientes.DataSource = gestionServicios.ListaClienteBaja();
        }
        /// <summary>
        /// Vuelve a dar a de alta el cliente seleccionado.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnHabilitarCliente_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidarExisteClienteEnLista())
                {
                    int index = lstClientes.SelectedIndex;
                    Cliente cliente = (Cliente)lstClientes.SelectedItem;
                    string mensaje = Administracion.RehabilitarCliente(gestionServicios,cliente);
                    ClienteDAO.RecuperarCliente(cliente);
                    this.ActualizarListaClientes();
                    MessageBox.Show(mensaje, "Alta",MessageBoxButtons.OK,MessageBoxIcon.Information);
                }
            }
            catch (ClienteNoExistenteException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (CargaInvalidaSQLException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception)
            {
                MessageBox.Show("Error!");
            }
        }
        /// <summary>
        /// Sale del formulario.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
