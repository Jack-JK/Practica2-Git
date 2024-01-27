using Microsoft.Extensions.Configuration;
using PracticoSI1.Business.Contracts;
using PracticoSI1.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace PracticoSI1.Business.Clases
{
    public class clUnidadDeMedidaRepository : IclUnidadDeMedidaRepository
    {
        private readonly string conect;
        public clUnidadDeMedidaRepository(IConfiguration _con)
        {
            conect = _con.GetConnectionString("conBase");
        }
        public async Task<List<clUnidadDeMedida>> GetList()
        {
            List<clUnidadDeMedida> list = new List<clUnidadDeMedida>();
            clUnidadDeMedida l;
            using (SqlConnection con = new SqlConnection(conect))
            {
                await con.OpenAsync();
                SqlCommand cmd = new SqlCommand("SELECT IdUnidadDeMedida, NombreUnidadDeMedida, Abreviacion, FechaRegistro, EstadoRegistro FROM clUnidadDeMedida;", con);

                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        l = new clUnidadDeMedida();
                        l.IdUnidadDeMedida = Convert.ToInt32(reader["IdUnidadDeMedida"]);
                        l.NombreUnidadDeMedida = Convert.ToString(reader["NombreUnidadDeMedida"]);
                        l.Abreviacion = Convert.ToString(reader["Abreviacion"]);
                        l.FechaRegistro = Convert.ToDateTime(reader["FechaRegistro"]);
                        l.EstadoRegistro = Convert.ToString(reader["EstadoRegistro"]);

                        list.Add(l);
                    }
                }
                return list;
            }
        }
        public async Task<int> Elimina(clUnidadDeMedida l)
        {
            using (SqlConnection con = new SqlConnection(conect))
            {
                string cadena = "DELETE FROM clUnidadDeMedida WHERE IdUnidadDeMedida = @IdUnidadDeMedida;";

                using (SqlCommand cmd = new SqlCommand(cadena, con))
                {
                    cmd.Parameters.AddWithValue("@IdUnidadDeMedida", l.IdUnidadDeMedida);

                    await con.OpenAsync();

                    // Ejecutamos la consulta de eliminación
                    return await cmd.ExecuteNonQueryAsync();
                }
            }
        }
        public async Task<clUnidadDeMedida> AgregaActualiza(clUnidadDeMedida l, string t)
        {
            using (SqlConnection con = new SqlConnection(conect))
            {
                string cadena = "";
                if (t == "c")
                {
                    cadena = "INSERT INTO clUnidadDeMedida (NombreUnidadDeMedida, Abreviacion, FechaRegistro, EstadoRegistro) " +
                             "VALUES (@NombreUnidadDeMedida, @Abreviacion, @FechaRegistro, @EstadoRegistro); SELECT SCOPE_IDENTITY();";
                }
                else if (t == "u")
                {
                    cadena = "UPDATE clUnidadDeMedida SET NombreUnidadDeMedida = @NombreUnidadDeMedida, " +
                             "Abreviacion=@Abreviacion, FechaRegistro = @FechaRegistro, " +
                             "EstadoRegistro = @EstadoRegistro WHERE IdUnidadDeMedida = @IdUnidadDeMedida;";
                }

                using (SqlCommand cmd = new SqlCommand(cadena, con))
                {
                    cmd.Parameters.AddWithValue("@IdUnidadDeMedida", l.IdUnidadDeMedida);
                    cmd.Parameters.AddWithValue("@NombreUnidadDeMedida", l.NombreUnidadDeMedida);
                    cmd.Parameters.AddWithValue("@Abreviacion", l.Abreviacion);
                    cmd.Parameters.AddWithValue("@FechaRegistro", l.FechaRegistro);
                    cmd.Parameters.AddWithValue("@EstadoRegistro", l.EstadoRegistro);

                    await con.OpenAsync();

                    if (t == "c")
                    {
                        // Si es una operación de inserción, obtenemos el nuevo ID
                        object result = await cmd.ExecuteScalarAsync();
                        l.IdUnidadDeMedida = Convert.ToInt32(result);
                    }
                    else if (t == "u")
                    {
                        // Si es una operación de actualización, ejecutamos la consulta directamente
                        await cmd.ExecuteNonQueryAsync();
                    }
                }
            }
            return l;
        }


    }
}
