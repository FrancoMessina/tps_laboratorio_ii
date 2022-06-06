using System;
using System.Windows.Forms;
using Entidades.Excepciones;
using Entidades.ValidacionesCliente;
using Entidades;
namespace Vista
{
    public partial class frmModificar : Form
    {
        private Administracion gestionServicios;
        private Cliente cliente;
        public frmModificar(Administracion gestionServicios, Cliente cliente)
        {
            InitializeComponent();
            this.gestionServicios = gestionServicios;
            this.cliente = cliente;
        }
        /// <summary>
        /// Modifica los datos del cliente seleccionado.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidarCliente.ValidarCamposCliente(txtNombre.Text, txtApellido.Text, txtDni.Text, txtTelefono.Text))
                {
                    if (ValidarCliente.ValidarNombre(txtNombre.Text) && ValidarCliente.ValidarApellido(txtApellido.Text) 
                        && ValidarCliente.ValidarDni(txtDni.Text) && ValidarCliente.ValidarNumeroTel(txtTelefono.Text))
                    {
                        string mensaje = string.Empty;
                        Cliente nuevoCliente = new Cliente(txtDni.Text, txtNombre.Text, txtApellido.Text, txtTelefono.Text);
                        mensaje = Administracion.ModificarCliente(gestionServicios, cliente, nuevoCliente);
                        MessageBox.Show(mensaje,"Modificacion",MessageBoxButtons.OK,MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK;
                    }
                }
            }
            catch (CamposVaciosONullException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (ClienteNoExistenteException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (NombreInvalidoException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (DniInvalidoException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (ApellidoInvalidoException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (NumeroInvalidoExcepction ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception)
            {
                MessageBox.Show("Error.Ingrese los datos nuevamente!");
            }
        
        }
        /// <summary>
        /// Carga los datos en los textbox del cliente seleccionado en el form principal.
        /// </summary>
        private void CargarDatos()
        {
            this.txtNombre.Text = cliente.Nombre;
            this.txtApellido.Text = cliente.Apellido;
            this.txtDni.Text = cliente.Dni;
            this.txtTelefono.Text = cliente.NumeroTel;
        }
        /// <summary>
        /// Carga los datos del cliente.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmModificar_Load(object sender, EventArgs e)
        {
            this.CargarDatos();
        }
        /// <summary>
        /// Sale del formulario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
