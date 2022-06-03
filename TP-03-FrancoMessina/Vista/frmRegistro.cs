using System;
using System.Windows.Forms;
using Entidades;
using Entidades.ValidacionesCliente;
using Entidades.Excepciones;
namespace Vista
{
    public partial class frmRegistro : Form
    {
        private Administracion gestionServicios;
        public frmRegistro(Administracion gestionServicios)
        {
            InitializeComponent();
            this.gestionServicios = gestionServicios;
        }

        private void btnRegistarse_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidarCliente.ValidarCamposCliente(txtNombre.Text, txtApellido.Text, txtDni.Text, txtTelefono.Text))
                {

                    if (ValidarCliente.ValidarNombre(txtNombre.Text) && ValidarCliente.ValidarApellido(txtApellido.Text) && ValidarCliente.ValidarDni(txtDni.Text) && ValidarCliente.ValidarNumeroTel(txtTelefono.Text))
                    {
                        Cliente cliente = new Cliente(txtDni.Text, txtNombre.Text, txtApellido.Text, txtTelefono.Text);
                        string mensaje = gestionServicios + cliente;
                        this.LimpiarCamposCliente();
                        MessageBox.Show(mensaje);
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
        private void LimpiarCamposCliente()
        {
            txtNombre.Text = string.Empty;
            txtApellido.Text = string.Empty;
            txtTelefono.Text = string.Empty;
            txtDni.Text = string.Empty;
        }
    }
}
