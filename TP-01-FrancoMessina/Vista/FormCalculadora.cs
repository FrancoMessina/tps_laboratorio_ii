using System;
using System.Windows.Forms;
using Entidades;
using System.Drawing;
namespace Vista
{
    public partial class FormCalculadora : Form
    {
        private const string mensajeError = "Error Dividir por 0";
        public FormCalculadora()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Limpia los textbox y los pone sin valor, el operador del combobox en vacio y el resultado con el valor 0.
        /// </summary>

        private void Limpiar()
        {
            this.txtNumero1.Text = string.Empty;
            this.txtNumero2.Text = string.Empty;
            this.cmbOperador.SelectedIndex = 0;
            this.lblResultado.Text = "0";
        }

        /// <summary>
        /// LLama al metodo Limpiar.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.Limpiar();
        }
        
        /// <summary>
        /// Carga en el formulario antes de que inicie los items del combobox, el resultado en 0, y 
        /// el operador en la posician 0 donde esta el valor " "
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormCalculadora_Load(object sender, EventArgs e)
        {
            this.cmbOperador.Items.Add(" ");
            this.cmbOperador.Items.Add("+");
            this.cmbOperador.Items.Add("-");
            this.cmbOperador.Items.Add("/");
            this.cmbOperador.Items.Add("*");
            this.lblResultado.Text = "0";
            this.cmbOperador.SelectedIndex = 0;
        }
        /// <summary>
        /// Resuelve la operacion, utilizando los dos numeros y el operador.
        /// </summary>
        /// <param name="numero1">Primer operando</param>
        /// <param name="numero2">Segundo Operando</param>
        /// <param name="operador">Operador que indica que tipo de operacion lleva a cabo.</param>
        /// <returns>Retorna el resultado de la operacion.</returns>
        private static double Operar(string numero1, string numero2, string operador)
        {
            Operando operadorUno = new Operando(numero1);
            Operando operadorDos = new Operando(numero2);
            Calculadora nuevaCalculadora = new Calculadora();
            return nuevaCalculadora.Operar(operadorUno, operadorDos, Convert.ToChar(operador));
        }
        /// <summary>
        /// Cierra el formulario con confirmacion de si deseas cerrarlo o no.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// Realiza la operacion que desee el usuario, y tiene varias salidas.
        /// Por ejem: Division por 0 arroja que no se puede divdir por 0.
        /// Verifica si se se ingresaron los dos valores.
        /// Verifica si se ingresaron letras.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOperar_Click(object sender, EventArgs e)
        {
            string numeroUno = this.txtNumero1.Text;
            string numeroDos = this.txtNumero2.Text;
            string operador = (string)cmbOperador.SelectedItem;
            double resultadoCuenta;
            bool errorNumeroUno = string.IsNullOrWhiteSpace(numeroUno);
            bool errorNumeroDos = string.IsNullOrWhiteSpace(numeroDos);
            string mensaje;

            if (!errorNumeroUno && !errorNumeroDos && double.TryParse(numeroUno, out double numeroUnoErrorParse) && double.TryParse(numeroDos, out double numeroDosErrorParse) && !(numeroDos == "0" && operador == "/"))
            {
                resultadoCuenta = Operar(numeroUno, numeroDos, operador);
                this.lblResultado.Text = resultadoCuenta.ToString();
                //mensaje = operador == " " ? $"{numeroUno} + {numeroDos} = {resultadoCuenta}" : $"{numeroUno} {operador} {numeroDos} = {resultadoCuenta}";//Probando Ternario
                if (operador == " ")
                {
                    mensaje = $"{numeroUno} + {numeroDos} = {resultadoCuenta}";
                    cmbOperador.SelectedIndex = 1;
                }
                else
                    mensaje = $"{numeroUno} {operador} {numeroDos} = {resultadoCuenta}";
                this.lstOperaciones.Items.Add(mensaje);
                this.lblResultado.ForeColor = Color.Black;
                this.btnConvertirADecimal.Enabled = false;
                this.btnConvertirABinario.Enabled = true;
                
            }
            else if (errorNumeroUno && errorNumeroDos)
                MessageBox.Show("Error. Necesitas cargar los dos Valores.","Error",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            else if (errorNumeroUno)
                MessageBox.Show("Error. Necesitas cargar el primer Valor.","Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else if (errorNumeroDos)
                MessageBox.Show("Error. Necesitas cargar el segundo Valor.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else if (numeroDos == "0" && operador == "/")
            {
                this.lblResultado.Text = mensajeError;
                this.lblResultado.ForeColor = Color.Red;
            }
            else
                MessageBox.Show("Ingresar un numero válido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        /// <summary>
        /// Convierte el resultado en decimal a binario.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(lblResultado.Text) || lblResultado.Text == mensajeError)
                MessageBox.Show("No hay resultado validado para convertir a Binario.");           
            else
            {
                if (Double.TryParse(lblResultado.Text, out double resultado))
                {
                    Operando auxBinario = new Operando();
                    this.lblResultado.Text = auxBinario.DecimalBinario(resultado); //Tambien podria pasar lblResultado.Text como param
                    this.btnConvertirADecimal.Enabled = true;
                    this.btnConvertirABinario.Enabled = false;
                }
                
            }
           
        }
        /// <summary>
        /// Convierte el resultado en binario a Decimal.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(lblResultado.Text) || lblResultado.Text == mensajeError)
                MessageBox.Show("No hay resultado validado para convertir a Decimal.");
            else
            {
                if (Double.TryParse(lblResultado.Text, out double resultado))
                {
                    Operando auxBinario = new Operando();
                    this.lblResultado.Text = auxBinario.BinarioDecimal(lblResultado.Text); //Tambien podria pasar lblResultado.Text como param
                }
                this.btnConvertirADecimal.Enabled = false;
                this.btnConvertirABinario.Enabled = true;
            }
            
        }
        /// <summary>
        /// Evento para que cada vez que el usuario quiera cerrar el form, se le pregunte si desea cerrarlo.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormCalculadora_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dialogRespuesta = MessageBox.Show("¿Seguro de queres salir?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogRespuesta == DialogResult.Yes)
                e.Cancel = false;
            else
                e.Cancel = true;
        }
    }
}
