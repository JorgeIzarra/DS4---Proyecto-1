using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Web.Http;
using CalculadoraAPI.Models;

namespace CalculadoraAPI.Controllers
{
    [RoutePrefix("api/Calculos")]
    public class CalculosController : ApiController
    {
        // GET: api/Calculos
        [HttpGet]
        public IHttpActionResult GetTodosLosCalculos()
        {
            List<Calculo> calculos = new List<Calculo>();
            try
            {
                using (SqlConnection conn = DBConnection.GetConnection())
                {
                    conn.Open();
                    string query = "SELECT * FROM Calculos ORDER BY FechaCalculo DESC";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                calculos.Add(new Calculo
                                {
                                    Id = Convert.ToInt32(reader["Id"]),
                                    Numero1 = Convert.ToDouble(reader["Numero1"]),
                                    Numero2 = Convert.ToDouble(reader["Numero2"]),
                                    Operacion = reader["Operacion"].ToString(),
                                    Resultado = Convert.ToDouble(reader["Resultado"]),
                                    FechaCalculo = Convert.ToDateTime(reader["FechaCalculo"])
                                });
                            }
                        }
                    }
                }
                return Ok(calculos);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // GET: api/Calculos/Sumas
        [HttpGet]
        [Route("Sumas")]
        public IHttpActionResult GetSumas()
        {
            List<Calculo> sumas = new List<Calculo>();
            try
            {
                using (SqlConnection conn = DBConnection.GetConnection())
                {
                    conn.Open();
                    string query = "SELECT * FROM Calculos WHERE Operacion = '+' ORDER BY FechaCalculo DESC";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                sumas.Add(new Calculo
                                {
                                    Id = Convert.ToInt32(reader["Id"]),
                                    Numero1 = Convert.ToDouble(reader["Numero1"]),
                                    Numero2 = Convert.ToDouble(reader["Numero2"]),
                                    Operacion = reader["Operacion"].ToString(),
                                    Resultado = Convert.ToDouble(reader["Resultado"]),
                                    FechaCalculo = Convert.ToDateTime(reader["FechaCalculo"])
                                });
                            }
                        }
                    }
                }
                return Ok(sumas);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // GET: api/Calculos/Restas
        [HttpGet]
        [Route("Restas")]
        public IHttpActionResult GetRestas()
        {
            List<Calculo> restas = new List<Calculo>();
            try
            {
                using (SqlConnection conn = DBConnection.GetConnection())
                {
                    conn.Open();
                    string query = "SELECT * FROM Calculos WHERE Operacion = '-' ORDER BY FechaCalculo DESC";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                restas.Add(new Calculo
                                {
                                    Id = Convert.ToInt32(reader["Id"]),
                                    Numero1 = Convert.ToDouble(reader["Numero1"]),
                                    Numero2 = Convert.ToDouble(reader["Numero2"]),
                                    Operacion = reader["Operacion"].ToString(),
                                    Resultado = Convert.ToDouble(reader["Resultado"]),
                                    FechaCalculo = Convert.ToDateTime(reader["FechaCalculo"])
                                });
                            }
                        }
                    }
                }
                return Ok(restas);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // GET: api/Calculos/Multiplicaciones
        [HttpGet]
        [Route("Multiplicaciones")]
        public IHttpActionResult GetMultiplicaciones()
        {
            List<Calculo> multiplicaciones = new List<Calculo>();
            try
            {
                using (SqlConnection conn = DBConnection.GetConnection())
                {
                    conn.Open();
                    string query = "SELECT * FROM Calculos WHERE Operacion = '*' ORDER BY FechaCalculo DESC";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                multiplicaciones.Add(new Calculo
                                {
                                    Id = Convert.ToInt32(reader["Id"]),
                                    Numero1 = Convert.ToDouble(reader["Numero1"]),
                                    Numero2 = Convert.ToDouble(reader["Numero2"]),
                                    Operacion = reader["Operacion"].ToString(),
                                    Resultado = Convert.ToDouble(reader["Resultado"]),
                                    FechaCalculo = Convert.ToDateTime(reader["FechaCalculo"])
                                });
                            }
                        }
                    }
                }
                return Ok(multiplicaciones);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // GET: api/Calculos/Divisiones
        [HttpGet]
        [Route("Divisiones")]
        public IHttpActionResult GetDivisiones()
        {
            List<Calculo> divisiones = new List<Calculo>();
            try
            {
                using (SqlConnection conn = DBConnection.GetConnection())
                {
                    conn.Open();
                    string query = "SELECT * FROM Calculos WHERE Operacion = '/' ORDER BY FechaCalculo DESC";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                divisiones.Add(new Calculo
                                {
                                    Id = Convert.ToInt32(reader["Id"]),
                                    Numero1 = Convert.ToDouble(reader["Numero1"]),
                                    Numero2 = Convert.ToDouble(reader["Numero2"]),
                                    Operacion = reader["Operacion"].ToString(),
                                    Resultado = Convert.ToDouble(reader["Resultado"]),
                                    FechaCalculo = Convert.ToDateTime(reader["FechaCalculo"])
                                });
                            }
                        }
                    }
                }
                return Ok(divisiones);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // GET: api/Calculos/Potencias
        [HttpGet]
        [Route("Potencias")]
        public IHttpActionResult GetPotencias()
        {
            List<Calculo> potencias = new List<Calculo>();
            try
            {
                using (SqlConnection conn = DBConnection.GetConnection())
                {
                    conn.Open();
                    string query = "SELECT * FROM Calculos WHERE Operacion = '^' ORDER BY FechaCalculo DESC";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                potencias.Add(new Calculo
                                {
                                    Id = Convert.ToInt32(reader["Id"]),
                                    Numero1 = Convert.ToDouble(reader["Numero1"]),
                                    Numero2 = Convert.ToDouble(reader["Numero2"]),
                                    Operacion = reader["Operacion"].ToString(),
                                    Resultado = Convert.ToDouble(reader["Resultado"]),
                                    FechaCalculo = Convert.ToDateTime(reader["FechaCalculo"])
                                });
                            }
                        }
                    }
                }
                return Ok(potencias);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // POST: api/Calculos
        [HttpPost]
        public IHttpActionResult PostCalculo(Calculo calculo)
        {
            try
            {
                // Calcular el resultado según la operación
                switch (calculo.Operacion)
                {
                    case "+":
                        calculo.Resultado = calculo.Numero1 + calculo.Numero2;
                        break;
                    case "-":
                        calculo.Resultado = calculo.Numero1 - calculo.Numero2;
                        break;
                    case "*":
                        calculo.Resultado = calculo.Numero1 * calculo.Numero2;
                        break;
                    case "/":
                        if (calculo.Numero2 == 0)
                            return BadRequest("No se puede dividir por cero");
                        calculo.Resultado = calculo.Numero1 / calculo.Numero2;
                        break;
                    case "^":
                        calculo.Resultado = Math.Pow(calculo.Numero1, calculo.Numero2);
                        break;
                    default:
                        return BadRequest("Operación no válida");
                }

                using (SqlConnection conn = DBConnection.GetConnection())
                {
                    conn.Open();
                    string query = @"INSERT INTO Calculos (Numero1, Numero2, Operacion, Resultado) 
                                   VALUES (@Numero1, @Numero2, @Operacion, @Resultado)";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Numero1", calculo.Numero1);
                        cmd.Parameters.AddWithValue("@Numero2", calculo.Numero2);
                        cmd.Parameters.AddWithValue("@Operacion", calculo.Operacion);
                        cmd.Parameters.AddWithValue("@Resultado", calculo.Resultado);
                        cmd.ExecuteNonQuery();
                    }
                }

                return Ok(calculo);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}
