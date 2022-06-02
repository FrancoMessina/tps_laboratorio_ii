using System;
using System.IO;
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
            try
            {
                if (ValidarCamposCliente(txtNombre.Text, txtApellido.Text, txtDni.Text, txtTelefono.Text))
                {
                    
                    if (ValidarNombre(txtNombre.Text) && ValidarApellido(txtApellido.Text) && ValidarDni(txtDni.Text) && ValidarNumeroTel(txtTelefono.Text))
                    {
                        Cliente cliente = new Cliente(txtDni.Text, txtNombre.Text, txtApellido.Text, txtTelefono.Text);
                        string mensaje = gestionServicios + cliente;
                        MessageBox.Show(mensaje);
                        ActualizarListaClientes();
                        LimpiarCamposCliente();
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
            catch (NumeroInvalidoExcepcion ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception)
            {
                MessageBox.Show("Error.Ingrese los datos nuevamente!");
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidarCamposCliente(txtNombre.Text, txtApellido.Text, txtDni.Text, txtTelefono.Text) && ValidarExisteClienteEnLista())
                {
                    if(ValidarNombre(txtNombre.Text) && ValidarApellido(txtApellido.Text) && ValidarDni(txtDni.Text) && ValidarNumeroTel(txtTelefono.Text))
                    {
                        string mensaje = string.Empty;
                        Cliente cliente = (Cliente)lstClientes.SelectedItem;
                        Cliente nuevoCliente = new Cliente(txtDni.Text, txtNombre.Text, txtApellido.Text, txtTelefono.Text);
                        mensaje = Administracion.ModificarCliente(gestionServicios, cliente, nuevoCliente);
                        if (cliente is not null)
                        {
                            LimpiarCamposCliente();
                            ActualizarListaClientes();
                        }
                        MessageBox.Show(mensaje);
                    }                                        
                }
            }
            catch (CamposVaciosONullException ex)
            {
                MessageBox.Show(ex.Message,"Error",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
            catch (ClienteNoExistenteException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch(NombreInvalidoException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch(DniInvalidoException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch(ApellidoInvalidoException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch(NumeroInvalidoExcepcion ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception)
            {
                MessageBox.Show("Error.Ingrese los datos nuevamente!");
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
                    LimpiarCamposCliente();
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

        private void lstClientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = lstClientes.SelectedIndex;
            if (index != -1)
            {
                txtNombre.Text = gestionServicios.ListaClientes[index].Nombre;
                txtApellido.Text = gestionServicios.ListaClientes[index].Apellido;
                txtTelefono.Text = gestionServicios.ListaClientes[index].NumeroTel;
                txtDni.Text = gestionServicios.ListaClientes[index].Dni;
            }

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

        private bool ValidarCamposCliente(string nombre, string apellido, string dni, string numeroTel)
        {
            if (string.IsNullOrWhiteSpace(nombre)|| string.IsNullOrWhiteSpace(apellido) || string.IsNullOrWhiteSpace(dni) || string.IsNullOrWhiteSpace(numeroTel))
            {
                throw new CamposVaciosONullException("Cargar todos los datos del cliente!");
            }
            return true;
          
        }
        private bool ValidarNombre(string nombre)
        {
            if (nombre.Length > 20 || nombre.Length < 3)
            {
                throw new NombreInvalidoException("El nombre tiene que tener más de 3 letras y menos de 20");
            }
            else if (!VerificarContieneSoloLetras(nombre))
            {
                throw new NombreInvalidoException("El nombre tiene que contener solo letras.");
            }
            return true;
        }
        private bool ValidarApellido(string apellido)
        {
            if (apellido.Length > 20 || apellido.Length < 3)
            {
                throw new ApellidoInvalidoException("El apellido tiene que tener más de 3 letras y menos de 20");
            }
            else if (!VerificarContieneSoloLetras(apellido))
            {
                throw new ApellidoInvalidoException("El apellido tiene que contener solo letras.");
            }
            return true;
        }
        private bool ValidarDni(string dni)
        {
            if (!double.TryParse(dni, out double dniAux))
            {
                throw new DniInvalidoException("El Dni tiene que ser númerico!");
            }
            else if (dniAux < 0 || dniAux > 999999999)
            {
                throw new DniInvalidoException("DNI INVALIDO!");
            }
            return true;
        }
        private bool ValidarNumeroTel(string numeroTel)
        {
            if (!double.TryParse(numeroTel, out double auxNumeroTel))
            {
                throw new NumeroInvalidoExcepcion("El Número de telefono tiene que ser númerico!");
            }
            else if (numeroTel.Length != 10)
            {
                throw new NumeroInvalidoExcepcion("Los numeros telefonicos tienen 10 digitos!");
            }
            return true;
        }
        private bool VerificarContieneSoloLetras(string nombre)
        {
            foreach (char letra in nombre)
            {
                if (!Char.IsLetter(letra))
                    return false;
            }
            return true;
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
        private void LimpiarCamposCliente()
        {
            txtNombre.Text = string.Empty;
            txtApellido.Text = string.Empty;
            txtTelefono.Text = string.Empty;
            txtDni.Text = string.Empty;
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
