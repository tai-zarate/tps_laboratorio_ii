using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace MiCalculadora
{
    public partial class FormCalculadora : Form
    {
        public FormCalculadora()
        {
            InitializeComponent();
        }

        private void FormCalculadora_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult respuesta = MessageBox.Show("¿Seguro de querer salir?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

            if (respuesta == DialogResult.Yes)
            {
                e.Cancel = false;
            }
            else
            {
                e.Cancel = true;
            }
        }

        private static double Operar(string numero1, string numero2, string operador)
        {
            double resultado;
            Operando num1 = new Operando(numero1);
            Operando num2 = new Operando(numero2);
            char operadorCaracter = '+';

            for (int i = 0; i < operador.Length; i++)
            {
                operadorCaracter = operador[i];
            }

            resultado = Calculadora.Operar(num1, num2, operadorCaracter);

            return resultado;
        }

        private void btnOperar_Click(object sender, EventArgs e)
        {
            string numero1String;
            string numero2String;
            string operadorString;
            double resultado;

            numero1String = this.txtNumero1.Text;
            numero2String = this.txtNumero2.Text;
            operadorString = (string)this.cmbOperador.SelectedItem;

            resultado = Operar(numero1String, numero2String, operadorString);

            if (string.IsNullOrEmpty(operadorString))
            {
                lstOperaciones.Items.Add(numero1String + " + " + numero2String + " = " + resultado);
            }
            else
            {
                lstOperaciones.Items.Add(numero1String + " " + operadorString + " " + numero2String + " = " + resultado);
            }

            lblResultado.Text = resultado.ToString();
        }

        private void FormCalculadora_Load(object sender, EventArgs e)
        {
            this.cmbOperador.SelectedIndex = 0;
        }

        private void Limpiar()
        {
            this.cmbOperador.SelectedIndex = 0;
            this.lblResultado.Text = "0";
            this.lstOperaciones.Items.Clear();
            this.txtNumero1.Clear();
            this.txtNumero2.Clear();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.Limpiar();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            Operando num = new Operando();
            string numeroDecimal = this.lblResultado.Text;
            string numeroBinario = num.DecimalBinario(numeroDecimal);

            lblResultado.Text = numeroBinario;
            lstOperaciones.Items.Add(numeroBinario);
        }

        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            Operando num = new Operando();
            string numeroBinario = this.lblResultado.Text;
            string numeroDecimal = num.BinarioDecimal(numeroBinario);

            lblResultado.Text = numeroDecimal;
            lstOperaciones.Items.Add(numeroDecimal);
        }
    }
}
