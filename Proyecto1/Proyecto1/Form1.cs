using System.Data.SqlClient;
using System.Configuration;

namespace Proyecto1
{
    public partial class Form1 : Form
    {
        // Conexion de bd
        private readonly string connectionString = @"Data Source=DESKTOP-3IOUQVC\SQLEXPRESS;Initial Catalog=CalculadoraDB;Integrated Security=True;TrustServerCertificate=True";

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
        private void btnRaiz_Click(object sender, EventArgs e) { SeleccionarOperacion("√"); }

        private void GuardarOperacion(double num1, double num2, string operador, double resultado)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string insertQuery = @"INSERT INTO Calculos (Numero1, Numero2, Operacion, Resultado) 
                                        VALUES (@Numero1, @Numero2, @Operacion, @Resultado)";

                    using (SqlCommand cmd = new SqlCommand(insertQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@Numero1", num1);
                        cmd.Parameters.AddWithValue("@Numero2", num2);
                        cmd.Parameters.AddWithValue("@Operacion", operador);
                        cmd.Parameters.AddWithValue("@Resultado", resultado);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar en la base de datos: " + ex.Message);
            }
        }

        private void CargarHistorial()
        {
            try
            {
                listBox1.Items.Clear();
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string selectQuery = @"SELECT Numero1, Numero2, Operacion, Resultado, FechaCalculo 
                                         FROM Calculos 
                                         ORDER BY FechaCalculo DESC";

                    using (SqlCommand cmd = new SqlCommand(selectQuery, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                double num1 = Convert.ToDouble(reader["Numero1"]);
                                double num2 = Convert.ToDouble(reader["Numero2"]);
                                string op = reader["Operacion"].ToString();
                                double resultado = Convert.ToDouble(reader["Resultado"]);
                                DateTime fecha = Convert.ToDateTime(reader["FechaCalculo"]);

                                // Crear una descripción de op
                                string operacionStr = "";
                                switch (op)
                                {
                                    case "√":
                                        operacionStr = $"√{num2} = {resultado}";
                                        break;
                                    case "^":
                                        operacionStr = $"{num1} ^ {num2} = {resultado}";
                                        break;
                                    default:
                                        operacionStr = $"{num1} {op} {num2} = {resultado}";
                                        break;
                                }

                                listBox1.Items.Add($"{operacionStr} [{fecha}]");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar el historial: " + ex.Message);
            }
        }

        private void btnRegistro_Click(object sender, EventArgs e)
        {
            CargarHistorial();
        }

        private void btnIgual_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(textBox1.Text))
                {
                    MessageBox.Show("Por favor, ingrese un número antes de realizar la operación.");
                    return;
                }

                if (string.IsNullOrEmpty(operacion))
                {
                    MessageBox.Show("Por favor, seleccione una operación antes de presionar igual.");
                    return;
                }

                if (!double.TryParse(textBox1.Text, out numero2))
                {
                    MessageBox.Show("El valor ingresado no es un número válido.");
                    return;
                }

                double resultado = 0;
                bool operacionExitosa = true;

                switch (operacion)
                {
                    case "+":
                        if (numero1 + numero2 > double.MaxValue)
                        {
                            MessageBox.Show("El resultado es demasiado grande.");
                            operacionExitosa = false;
                        }
                        else
                        {
                            resultado = numero1 + numero2;
                        }
                        break;
                    case "-":
                        resultado = numero1 - numero2;
                        break;
                    case "*":
                        if (numero1 * numero2 > double.MaxValue)
                        {
                            MessageBox.Show("El resultado es demasiado grande.");
                            operacionExitosa = false;
                        }
                        else
                        {
                            resultado = numero1 * numero2;
                        }
                        break;
                    case "/":
                        if (numero2 == 0)
                        {
                            MessageBox.Show("Error: No es posible dividir por cero.");
                            operacionExitosa = false;
                        }
                        else
                        {
                            resultado = numero1 / numero2;
                        }
                        break;
                    case "^":
                        if (numero2 > 100)
                        {
                            MessageBox.Show("El exponente es demasiado grande.");
                            operacionExitosa = false;
                        }
                        else
                        {
                            resultado = Math.Pow(numero1, numero2);
                        }
                        break;
                    case "√":
                        if (numero2 < 0)
                        {
                            MessageBox.Show("Error: No se puede calcular la raíz cuadrada de un número negativo.");
                            operacionExitosa = false;
                        }
                        else
                        {
                            resultado = Math.Sqrt(numero2);
                        }
                        break;
                    default:
                        MessageBox.Show("Operación no válida");
                        return;
                }

                if (operacionExitosa)
                {
                    if (double.IsInfinity(resultado))
                    {
                        MessageBox.Show("El resultado es demasiado grande para mostrarse.");
                        return;
                    }

                    textBox1.Text = resultado.ToString();
                    GuardarOperacion(numero1, numero2, operacion, resultado);
                    operacionElegida = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al realizar la operación: " + ex.Message);
            }
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            numero1 = 0;
            numero2 = 0;
            operacion = "";
            operacionElegida = false;
        }

        private void btnDecimal_Click(object sender, EventArgs e)
        {
            // Si está vacío, agregar un 0 antes del punto
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                textBox1.Text = "0.";
                return;
            }

            // Si ya tiene un punto decimal, no hacer nada
            if (textBox1.Text.Contains("."))
                return;

            // Si se acaba de elegir una operación, empezar con "0."
            if (operacionElegida)
            {
                textBox1.Text = "0.";
                operacionElegida = false;
                return;
            }

            textBox1.Text += ".";
        }

        private void AgregarNumero(string numero)
        {
            try
            {
                if (operacionElegida)
                {
                    textBox1.Clear();
                    operacionElegida = false;
                }

                // número largo
                if (textBox1.Text.Length >= 15)
                {
                    MessageBox.Show("El número es demasiado largo.");
                    return;
                }

                // Evitar múltiples ceros al inicio
                if (textBox1.Text == "0" && numero == "0")
                    return;

                // Si el texto es "0" y se presiona cualquier número, reemplazar el 0
                if (textBox1.Text == "0" && numero != ".")
                    textBox1.Text = numero;
                else
                    textBox1.Text += numero;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar número: " + ex.Message);
            }
        }

        private void SeleccionarOperacion(string op)
        {
            try
            {
                if (!double.TryParse(textBox1.Text, out numero1))
                {
                    MessageBox.Show("El valor ingresado no es un número válido.");
                    return;
                }

                operacion = op;
                operacionElegida = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al seleccionar operación: " + ex.Message);
            }
        }

        private void btnRegistro_Click_1(object sender, EventArgs e)
        {
            CargarHistorial();
        }
    }
}




