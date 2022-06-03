using System;
using Entidades.ValidacionesCliente;
using System.Windows.Forms;
using Entidades;
using Entidades.Excepciones;
using System.Collections.Generic;
using Entidades.Gestor_de_Archivos;
namespace Vista
{
    public partial class frmPrincipal : Form
    {
        private Administracion gestionServicios;

        public frmPrincipal()
        {
            InitializeComponent();
            this.gestionServicios = new Administracion();
        }
        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            
            try
            {
                Serializador<List<Cliente>> serializador = new Serializador<List<Cliente>>(GestorDeArchivo.ETipoArchivo.XML);
                gestionServicios.ListaClientes = serializador.Leer("ListaClientes.xml");
            }
            catch (Exception)
            {
            }
            finally
            {
                cmbProductos.DataSource = Enum.GetNames(typeof(EProductos));
                cmbEntrega.DataSource = Enum.GetValues(typeof(ETipoEntrega));
                MostrarDatosTv();
                ActualizarListaClientes();
            }
            
            
        }
        private void btnRegistarse_Click(object sender, EventArgs e)
        {
            frmRegistro formRegistro = new frmRegistro(gestionServicios);
            formRegistro.ShowDialog();
            this.ActualizarListaClientes();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidarExisteClienteEnLista())
                {
                    int index = lstClientes.SelectedIndex;
                    Cliente cliente = (Cliente)lstClientes.SelectedItem;
                    frmModificar formModificar = new frmModificar(gestionServicios, cliente);
                    formModificar.ShowDialog();
                    this.ActualizarListaClientes();
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
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidarExisteClienteEnLista())
                {
                    int index = lstClientes.SelectedIndex;
                    Cliente cliente = (Cliente)lstClientes.SelectedItem;
                    string mensaje = gestionServicios - cliente;
                    ActualizarListaClientes();
                    MessageBox.Show($"{mensaje}");
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
        private void btnCargarServicio_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidarExisteClienteEnLista())
                {
                    Cliente cliente = (Cliente)lstClientes.SelectedItem;
                    string producto = (string)cmbProductos.SelectedItem;
                    string mensaje;
                    if (cliente is not null)
                    {
                        mensaje = AgregarServicio(cliente, producto);
                        LimpiarCheckBox();
                        MessageBox.Show(mensaje);
                    }
                    
                }
            }
            catch (ClienteNoExistenteException ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception)
            {
                MessageBox.Show("Error");
            }
        }
        private void btnMostrarServicio_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidarExisteClienteEnLista())
                {
                    Cliente cliente = (Cliente)lstClientes.SelectedItem;
                    if (cliente.ListaServicios.Count > 0)
                    {
                        frmServicios ventanServicios = new frmServicios(gestionServicios, cliente);
                        ventanServicios.ShowDialog();
                    }
                    else
                        MessageBox.Show("El cliente seleccionado no tiene servicios!");
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
        private void ActualizarListaClientes()
        {
            this.lstClientes.DataSource = null;
            this.lstClientes.DataSource = gestionServicios.ListaClientes;

        }

        private List<string> CargarFallas()
        {
            List<string> fallas = new List<string>();
            if (ckbFallaUno.Checked)
            {
                fallas.Add(ckbFallaUno.Text);
            }
            if (ckbFallaDos.Checked)
            {
                fallas.Add(ckbFallaDos.Text);
            }
            if (ckbFallaTres.Checked)
            {
                fallas.Add(ckbFallaTres.Text);
            }
            return fallas;
        }
        private Servicio CargarServicioTv()
        {
            string marca = (string)cmbMarca.SelectedItem;
            string modelo = (string)cmbModelo.SelectedItem;
            List<string> fallas = CargarFallas();
            ETipoEntrega tipoEntrega = (ETipoEntrega)cmbEntrega.SelectedItem;
            ETipoTv tipoTv = (ETipoTv)cmbTipo.SelectedItem;
            Televisor televisor = new Televisor(marca, modelo, fallas, tipoTv);
            Servicio servicio = new Servicio(tipoEntrega, televisor, televisor.CalcularCosto());
            return servicio;

        }
        private Servicio CargarServicioAire()
        {
            string marca = (string)cmbMarca.SelectedItem;
            string modelo = (string)cmbModelo.SelectedItem;
            List<string> fallas = CargarFallas();
            ETipoEntrega tipoEntrega = (ETipoEntrega)cmbEntrega.SelectedItem;
            AireAcondicionado aireAcondicionado = new AireAcondicionado(marca, modelo, fallas);
            Servicio servicio = new Servicio(tipoEntrega, aireAcondicionado, aireAcondicionado.CalcularCosto());
            return servicio;
        }
        private Servicio CargarServicioControl()
        {
            string marca = (string)cmbMarca.SelectedItem;
            string modelo = (string)cmbModelo.SelectedItem;
            List<string> fallas = CargarFallas();
            ETipoEntrega tipoEntrega = (ETipoEntrega)cmbEntrega.SelectedItem;
            ETipoControl tipoControl = rdbAire.Checked ? ETipoControl.Aire : ETipoControl.TV;
            Entidades.Control control = new Entidades.Control(marca, modelo, fallas, tipoControl);
            Servicio servicio = new Servicio(tipoEntrega, control, control.CalcularCosto());
            return servicio;
        }

        private bool ValidarExisteClienteEnLista()
        {
            int index = lstClientes.SelectedIndex;
            if(index == -1 && lstClientes.Items.Count == 0)
            {
                throw new ClienteNoExistenteException("No hay ningun cliente en la lista!");
            }
            else if(index == -1)
            {
                throw new ClienteNoExistenteException("No hay ningun cliente seleccionado!");
            }
            return true;
        }
        private void cmbProductos_SelectedIndexChanged(object sender, EventArgs e)
        {
            string producto = (string)cmbProductos.SelectedItem;
            switch (producto)
            {
                case "Tv":
                    MostrarDatosTv();
                    break;
                case "Control":
                    MostrarDatosControl();
                    break;
                case "AireAcondicionado":
                    MostrarDatosAire();
                    break;
            }
            LimpiarCheckBox();
        }
        private void MostrarDatosTv()
        {
            lblTipo.Text = "Tipo ";
            gpbProducto.Text = "Televisor";
            lblTipoControl.Visible = false;
            rdbAire.Visible = false;
            rdbTv.Visible = false;
            lblTipo.Visible = true;
            cmbTipo.Visible = true;
            cmbMarca.DataSource = Enum.GetNames(typeof(EMarcaTV));
            cmbTipo.DataSource = Enum.GetValues(typeof(ETipoTv));
            cmbModelo.DataSource = Enum.GetNames(typeof(EModeloTv));
            MostrarFallasTv();
        }
        private void MostrarDatosControl()
        {
            lblTipo.Text = "Tipo ";
            gpbProducto.Text = "Control";
            lblTipoControl.Visible = true;
            rdbAire.Visible = true;
            rdbTv.Visible = true;
            lblTipo.Visible = false;
            cmbTipo.Visible = false;
            rdbTv.Checked = true;
            cmbModelo.DataSource = Enum.GetNames(typeof(EModeloControl));
            MostrarFallasControlTv();

        }
        private void MostrarDatosAire()
        {
            gpbProducto.Text = "Aire";
            lblTipoControl.Visible = false;
            rdbAire.Visible = false;
            rdbTv.Visible = false;
            cmbTipo.Visible = false;
            lblTipo.Visible = false;
            lblTipoControl.Visible = false;
            cmbMarca.DataSource = Enum.GetNames(typeof(EMarcaAire));
            cmbModelo.DataSource = Enum.GetNames(typeof(EModeloAire));
            MostrarFallasAire();

        }
        private void rdbTv_CheckedChanged(object sender, EventArgs e)
        {
            cmbMarca.DataSource = Enum.GetNames(typeof(EMarcaTV));
            MostrarFallasControlTv();
        }

        private void rdbAire_CheckedChanged(object sender, EventArgs e)
        {
            cmbMarca.DataSource = Enum.GetNames(typeof(EMarcaAire));
            MostrarFallasControlAire();
        }
        private void MostrarFallasControlTv()
        {
            ckbFallaUno.Text = EFallaControlTv.NoEmiteSenial.ToString();
            ckbFallaDos.Text = EFallaControlTv.NoFuncionaBoton.ToString();
            ckbFallaTres.Text = EFallaControlTv.PortaPilaSulfatado.ToString();
        }
        private void MostrarFallasControlAire()
        {
            ckbFallaUno.Text = EFallaControlAire.NoEmiteSenial.ToString();
            ckbFallaDos.Text = EFallaControlAire.BajaSenial.ToString();
            ckbFallaTres.Text = EFallaControlAire.DisplayRoto.ToString();
        }
        private void MostrarFallasTv()
        {
            ckbFallaUno.Text = EFallaTv.SinAudio.ToString();
            ckbFallaDos.Text = EFallaTv.PantallaRota.ToString();
            ckbFallaTres.Text = EFallaTv.SinImagen.ToString();
        }
        private void MostrarFallasAire()
        {
            ckbFallaUno.Text = EFallaAire.PierdeAgua.ToString();
            ckbFallaDos.Text = EFallaAire.SoloFrio.ToString();
            ckbFallaTres.Text = EFallaAire.SoloCalor.ToString();
        }
        private void LimpiarCheckBox()
        {
            ckbFallaUno.Checked = false;
            ckbFallaDos.Checked = false;
            ckbFallaTres.Checked = false;
        }
        private string AgregarServicio(Cliente cliente, string producto)
        {
            Servicio servicio;
            string mensaje = string.Empty;
            if (ckbFallaUno.Checked || ckbFallaDos.Checked || ckbFallaTres.Checked)
            {
                if (producto == "Tv")
                {
                    servicio = CargarServicioTv();
                    mensaje = Administracion.AgregarServicio(gestionServicios, cliente, servicio);
                }
                else if (producto == "Control")
                {
                    servicio = CargarServicioControl();
                    mensaje = Administracion.AgregarServicio(gestionServicios, cliente, servicio);
                }
                else if (producto == "AireAcondicionado")
                {
                    servicio = CargarServicioAire();
                    mensaje = Administracion.AgregarServicio(gestionServicios, cliente, servicio);
                }
               
            }
            else
            {
                mensaje = "No seleccionaste ninguna falla en el producto.";
            }
            return mensaje;
        }

        private void btnGuardarClientes_Click(object sender, EventArgs e)
        {
            try
            {
                Serializador<List<Cliente>> serializador = new Serializador<List<Cliente>>(GestorDeArchivo.ETipoArchivo.XML);
                string mensaje = serializador.Escribir("ListaClientes.xml", gestionServicios.ListaClientes);
                MessageBox.Show(mensaje);
            }
            catch(ArchivoSerializacionException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception)
            {

                MessageBox.Show("Error al serializar");
            }
            
        }

        private void timerHoraFecha_Tick(object sender, EventArgs e)
        {
            lblFecha.Text = DateTime.Now.ToString("dddd MMMM yyyy");
            lblHora.Text = DateTime.Now.ToString("HH:mm:ss");
        }
    }
}
