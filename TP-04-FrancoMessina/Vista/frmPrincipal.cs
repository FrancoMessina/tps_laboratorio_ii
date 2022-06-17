using System;
using Entidades.ValidacionesCliente;
using System.Windows.Forms;
using Entidades;
using Entidades.Excepciones;
using System.Collections.Generic;
using Entidades.Gestor_de_Archivos;
using Entidades.GestorSQL;
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
        /// <summary>
        /// En la carga del formulario principal. Se intenta serializar(Leer) 
        /// el archivo ListaDeClientes en formato xml.En caso de existir se muestran los clientes en la listbox. 
        /// Ruta de donde se lee: En escritorio->Archivos->XML->ListaClientes.XML.
        /// Caso contrario captura la excepcion pero sin mostrarle al usuario el mensaje de error porque necesita saberlo.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            try
            {
                //Serializador<List<Cliente>> serializador = new Serializador<List<Cliente>>(GestorDeArchivo.ETipoArchivo.XML);
                //gestionServicios.ListaClientes = serializador.Leer("ListaClientes.xml");
                ActualizarListaClientes();

            }
            catch (Exception)
            {
            }
            finally
            {
                cmbProductos.DataSource = Enum.GetNames(typeof(EProductos));
                cmbEntrega.DataSource = Enum.GetValues(typeof(ETipoEntrega));
                MostrarDatosTv();
                
            }
        }
        /// <summary>
        /// Abre el formulario de Registro y luego actualiza los clientes.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRegistarse_Click(object sender, EventArgs e)
        {
            frmRegistro formRegistro = new frmRegistro(gestionServicios);
            formRegistro.ShowDialog();
            this.ActualizarListaClientes();
        }
        /// <summary>
        /// Valida si existe un cliente en la lista, y si pudo seleccionar un cliente lo modifica.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        /// <summary>
        /// Valida si existe un cliente en la lista, y si pudo seleccionar un cliente lo elimina logicamente.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidarExisteClienteEnLista())
                {
                    int index = lstClientes.SelectedIndex;
                    Cliente cliente = (Cliente)lstClientes.SelectedItem;
                    string mensaje = gestionServicios - cliente;
                    ClienteDAO.BajaCliente(cliente);
                    this.ActualizarListaClientes();
                    MessageBox.Show(mensaje,"Eliminar",MessageBoxButtons.OK,MessageBoxIcon.Information);
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
        /// Valida si existe un cliente en la lista, y si pudo seleccionar un cliente le carga el servicio seleccionado.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
                        ClienteDAO.AltaServicio(cliente.ListaServicios[cliente.ListaServicios.Count - 1], cliente.Dni);
                        this.LimpiarCheckBox();
                        MessageBox.Show(mensaje,"Cargar servicio",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    }
                    
                }
            }
            catch (ClienteNoExistenteException ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (ServicioNoExistenteException ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception)
            {
                MessageBox.Show("Error");
            }
        }
        /// <summary>
        /// Valida si existe un cliente en la lista, y si pudo seleccionar un cliente le muestra el servicio seleccionado.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        /// <summary>
        /// Actualiza la lista de clientes.
        /// </summary>
        private void ActualizarListaClientes()
        {
            this.lstClientes.DataSource = null;
            gestionServicios.ListaClientes = ClienteDAO.ListarClientes();
            this.lstClientes.DataSource = gestionServicios.ListaClienteAlta();
        }
        /// <summary>
        /// Carga las fallas seleccionadas y devuelve una lista de fallas.
        /// </summary>
        /// <returns></returns>
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
        /// <summary>
        /// Carga el servicio de Tv con los datos seleccionados
        /// </summary>
        /// <returns>Retorna un servicio</returns>
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
        /// <summary>
        /// Carga el servicio de aire con los datos seleccionados
        /// </summary>
        /// <returns>Retorna un servicio</returns>
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
        /// <summary>
        /// Carga el servicio de control con los datos seleccionados
        /// </summary>
        /// <returns>Retorna un servicio</returns>
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
        /// <summary>
        /// Valida si la listbox tiene un cliente y  si esta seleccionado
        /// </summary>
        /// <returns>Retorna true si pudo seleccionar un cliente</returns>
        /// <exception cref="ClienteNoExistenteException">Lanza la excepcion si no hay ningun cliente en la lista  o no hya ningun cliente seleccionado</exception>
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
        /// <summary>
        /// Si el combobox seleccionado es Tv muestra los datos de TV. Si es seleccionado el de control se muestra los de control
        /// y si es seleccionado el de AireAcondicionado se muestra los datos de Aire.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        /// <summary>
        /// Muestra los datos para seleccionar de TV.
        /// </summary>
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
        /// <summary>
        /// Muestra los datos para seleccionar de Control
        /// </summary>
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
        /// <summary>
        /// Muestra los datos para seleccionar de Aire.
        /// </summary>
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
        /// <summary>
        /// Si se selecciona el radioButton de Control de TV, se muestran los datos respectivamente.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rdbTv_CheckedChanged(object sender, EventArgs e)
        {
            cmbMarca.DataSource = Enum.GetNames(typeof(EMarcaTV));
            MostrarFallasControlTv();
        }
        /// <summary>
        /// Si se selecciona el radioButton de Control de Aire, se muestran los datos respectivamente.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rdbAire_CheckedChanged(object sender, EventArgs e)
        {
            cmbMarca.DataSource = Enum.GetNames(typeof(EMarcaAire));
            MostrarFallasControlAire();
        }
        /// <summary>
        /// Muestra las fallas de control de televisor en los checkbox.
        /// </summary>
        private void MostrarFallasControlTv()
        {
            ckbFallaUno.Text = EFallaControlTv.NoEmiteSenial.ToString();
            ckbFallaDos.Text = EFallaControlTv.NoFuncionaBoton.ToString();
            ckbFallaTres.Text = EFallaControlTv.PortaPilaSulfatado.ToString();
        }
        /// <summary>
        /// Muestra las fallas de control de aire acondicionado en los checkbox.
        /// </summary>
        private void MostrarFallasControlAire()
        {
            ckbFallaUno.Text = EFallaControlAire.NoEmiteSenial.ToString();
            ckbFallaDos.Text = EFallaControlAire.BajaSenial.ToString();
            ckbFallaTres.Text = EFallaControlAire.DisplayRoto.ToString();
        }
        /// <summary>
        /// Muestra las fallas de televisor en los checkbox.
        /// </summary>
        private void MostrarFallasTv()
        {
            ckbFallaUno.Text = EFallaTv.SinAudio.ToString();
            ckbFallaDos.Text = EFallaTv.PantallaRota.ToString();
            ckbFallaTres.Text = EFallaTv.SinImagen.ToString();
        }
        /// <summary>
        /// Muestra las fallas de Aire acondicionado en los checkbox.
        /// </summary>
        private void MostrarFallasAire()
        {
            ckbFallaUno.Text = EFallaAire.PierdeAgua.ToString();
            ckbFallaDos.Text = EFallaAire.SoloFrio.ToString();
            ckbFallaTres.Text = EFallaAire.SoloCalor.ToString();
        }
        /// <summary>
        /// Limpia los checkbox dejando el checked en false.
        /// </summary>
        private void LimpiarCheckBox()
        {
            ckbFallaUno.Checked = false;
            ckbFallaDos.Checked = false;
            ckbFallaTres.Checked = false;
        }
        /// <summary>
        /// Agrega el servicio escogido y lo agrega en el cliente seleccionado.
        /// </summary>
        /// <param name="cliente">Cliente al que se le agrega el Servicio</param>
        /// <param name="producto">Un string que contiene el nombre del tipo de producto</param>
        /// <returns>Retornara un mensaje dependiendo el caso.</returns>
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
                    servicio.DniCliente = cliente.Dni;
                }
                else if (producto == "Control")
                {
                    servicio = CargarServicioControl();
                    mensaje = Administracion.AgregarServicio(gestionServicios, cliente, servicio);
                    servicio.DniCliente = cliente.Dni;
                }
                else if (producto == "AireAcondicionado")
                {
                    servicio = CargarServicioAire();
                    mensaje = Administracion.AgregarServicio(gestionServicios, cliente, servicio);
                    servicio.DniCliente = cliente.Dni;
                }
               
            }
            else
            {
                throw new ServicioNoExistenteException("No seleccionaste ninguna falla en el producto.");
            }
            return mensaje;
        }
        /// <summary>
        /// Exporta la lista de clientes con sus datos a un archivo en formato XML.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 
        private void btnGuardarClientes_Click(object sender, EventArgs e)
        {
            try
            {
                Serializador<List<Cliente>> serializador = new Serializador<List<Cliente>>(GestorDeArchivo.ETipoArchivo.XML);
                string mensaje = serializador.Escribir("ListaClientes.xml", gestionServicios.ListaClientes);
                MessageBox.Show(mensaje,"Archivo",MessageBoxButtons.OK,MessageBoxIcon.Information);
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


        /// <summary>
        /// Se abre el formulario para volver a darle el alta  nuevamente a un cliente.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRecuperarCliente_Click(object sender, EventArgs e)
        {
            frmHabilitarCliente formRegistro = new frmHabilitarCliente(gestionServicios);
            formRegistro.ShowDialog();
            this.ActualizarListaClientes();
        }
    }
}
