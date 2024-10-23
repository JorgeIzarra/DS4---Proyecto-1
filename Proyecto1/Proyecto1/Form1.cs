namespace Proyecto1
{
    public partial class Form1 : Form
    {
        
        private double numero1 = 0;
        private double numero2 = 0;
        private string operacion = "";
        private bool operacionElegida = false; 

        public Form1()
        {
            InitializeComponent();
        }

        private void btn1_Click(object sender, EventArgs e) { AgregarNumero("1"); }
        private void btn2_Click(object sender, EventArgs e) { AgregarNumero("2"); }
        private void btn3_Click(object sender, EventArgs e) { AgregarNumero("3"); }
        private void btn4_Click(object sender, EventArgs e) { AgregarNumero("4"); }
        private void btn5_Click(object sender, EventArgs e) { AgregarNumero("5"); }
        private void btn6_Click(object sender, EventArgs e) { AgregarNumero("6"); }
        private void btn7_Click(object sender, EventArgs e) { AgregarNumero("7"); }
        private void btn8_Click(object sender, EventArgs e) { AgregarNumero("8"); }
        private void btn9_Click(object sender, EventArgs e) { AgregarNumero("9"); }
        private void btn0_Click(object sender, EventArgs e) { AgregarNumero("0"); }

        private void btnSuma_Click(object sender, EventArgs e) { SeleccionarOperacion("+"); }
        private void btnResta_Click(object sender, EventArgs e) { SeleccionarOperacion("-"); }
        private void btnMultiplicar_Click(object sender, EventArgs e) { SeleccionarOperacion("*"); }
        private void btnDividir_Click(object sender, EventArgs e) { SeleccionarOperacion("/"); }
        private void btnPotencia_Click(object sender, EventArgs e) { SeleccionarOperacion("^"); }
        private void btnRaiz_Click(object sender, EventArgs e)
        {
            
            numero1 = double.Parse(textBox1.Text);

            
            if (numero1 < 0)
            {
                MessageBox.Show("Error: No se puede calcular la raíz cuadrada de un número negativo.");
                return;
            }

            
            double resultado = Math.Sqrt(numero1);
            textBox1.Text = resultado.ToString();

        
            listBox1.Items.Add($"√{numero1} = {resultado}");

            operacionElegida = false;
        }

        private void btnIgual_Click(object sender, EventArgs e)
        {
            // Realizar la operación seleccionada
            numero2 = double.Parse(textBox1.Text);
            double resultado = 0;

            switch (operacion)
            {
                case "+":
                    resultado = numero1 + numero2;
                    break;
                case "-":
                    resultado = numero1 - numero2;
                    break;
                case "*":
                    resultado = numero1 * numero2;
                    break;
                case "/":
                    if (numero2 != 0)
                        resultado = numero1 / numero2;
                    else
                        MessageBox.Show("Error: División por cero.");
                    break;
                case "^":
                    resultado = Math.Pow(numero1, numero2);
                    break;
                case "√":
                    resultado = Math.Sqrt(numero1);
                    break;
            }

            textBox1.Text = resultado.ToString();
            listBox1.Items.Add($"{numero1} {operacion} {numero2} = {resultado}");
            operacionElegida = false;
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            // Borrar todo
            textBox1.Clear();
            numero1 = 0;
            numero2 = 0;
            operacion = "";
            operacionElegida = false;
        }

        private void btnDecimal_Click(object sender, EventArgs e)
        {
            if (!textBox1.Text.Contains("."))
            {
                textBox1.Text += ".";
            }
        }

        private void AgregarNumero(string numero)
        {
            if (operacionElegida)
            {
                textBox1.Clear();
                operacionElegida = false;
            }
            textBox1.Text += numero;
        }

        private void SeleccionarOperacion(string op)
        {
            numero1 = double.Parse(textBox1.Text);
            operacion = op;
            operacionElegida = true;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }
}



