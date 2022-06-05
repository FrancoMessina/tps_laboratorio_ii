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
        public frmRegistro()
        {
            InitializeComponent();

        }
        public frmRegistro(Administracion gestionServicios) : this()
        {
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
                        MessageBox.Show(mensaje,"Registro",MessageBoxButtons.OK,MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK;
                    }
                }
            }
            catch (CamposVaciosONullException ex)
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

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
