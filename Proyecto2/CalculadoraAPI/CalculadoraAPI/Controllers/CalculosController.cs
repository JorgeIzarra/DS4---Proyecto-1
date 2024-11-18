using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.SqlClient;
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
    }
}
