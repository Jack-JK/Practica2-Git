using Microsoft.AspNetCore.Authorization;
using PracticoSI1.Business.Contracts;
using PracticoSI1.Models;
using System;
using System.Data.SqlClient;

namespace PracticoSI1.Business.Clases
{
    [Authorize]
    public class clStockRepository : IclStockRepository
    {
        private readonly string connec;
        public clStockRepository(IConfiguration _IConfiguration)
        {
            connec = _IConfiguration.GetConnectionString("conBase");
        }
        public async Task<List<clStock>> GetList()
        {
            List<clStock> list = new List<clStock>();
            clStock l;
            using (SqlConnection conn = new SqlConnection(connec))
            {
                await conn.OpenAsync();
                SqlCommand cmd = new SqlCommand("select * from clStock", conn);
                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        l = new clStock();
                        l.IdStock = Convert.ToInt32(reader["IdStock"]);
                        l.Cantidad = Convert.ToInt32(reader["Cantidad"]);
                        l.IdInsumo = Convert.ToInt32(reader["IdInsumo"]);
                        l.IdAlmacen = Convert.ToInt32(reader["IdAlmacen"]);
                        l.IdIngreso = Convert.ToInt32(reader["IdIngreso"]);
                        l.FechaIngreso = Convert.ToDateTime(reader["FechaIngreso"]);
                        l.EstadoRegistra = Convert.ToString(reader["EstadoRegistra"]);

                        list.Add(l);
                    }
                }
            }
            return list;
        }
        public async Task<clStock> AgregaActualiza(clStock l, string t)
        {
            using (SqlConnection conn = new SqlConnection(connec))
            {
                string cadena = "";

                if (t == "c")
                {
                    // Si estás creando un nuevo registro
                    cadena = "INSERT INTO clStock (Cantidad, IdInsumo, IdAlmacen, IdIngreso, FechaIngreso, EstadoRegistra) OUTPUT INSERTED.IdStock VALUES (@Cantidad, @IdInsumo, @IdAlmacen, @IdIngreso, @FechaIngreso, @EstadoRegistra)";

                }
                else if (t == "u")
                {
                    // Si estás actualizando un registro existente
                    cadena = "UPDATE clStock SET Cantidad = @Cantidad, IdInsumo = @IdInsumo, IdAlmacen = @IdAlmacen, IdIngreso = @IdIngreso, FechaIngreso = @FechaIngreso, EstadoRegistra = @EstadoRegistra WHERE IdStock = @IdStock";

                }

                using (SqlCommand cmd = new SqlCommand(cadena, conn))
                {
                    cmd.Parameters.AddWithValue("@IdStock", l.IdStock);
                    cmd.Parameters.AddWithValue("@Cantidad", l.Cantidad);
                    cmd.Parameters.AddWithValue("@IdInsumo", l.IdInsumo);
                    cmd.Parameters.AddWithValue("@IdAlmacen", l.IdAlmacen);
                    cmd.Parameters.AddWithValue("@IdIngreso", l.IdIngreso);
                    cmd.Parameters.AddWithValue("@FechaIngreso", l.FechaIngreso);
                    cmd.Parameters.AddWithValue("@EstadoRegistra", l.EstadoRegistra);

                    await conn.OpenAsync();

                    if (t == "c")
                    {
                        // Si estás creando, asigna el nuevo valor de Id
                        l.IdStock = (int)await cmd.ExecuteScalarAsync();
                    }
                    else
                    {
                        // Si estás actualizando, simplemente ejecuta la actualización
                        await cmd.ExecuteNonQueryAsync();
                    }
                }

                return l;
            }
        }
        public async Task<int> EliminarRegistro(clStock l)
        {
            using (SqlConnection con = new SqlConnection(connec))
            {
                string cadena = "DELETE FROM clStock WHERE IdStock = @IdStock";

                using (SqlCommand cmd = new SqlCommand(cadena, con))
                {
                    cmd.Parameters.AddWithValue("@IdStock", l.IdStock);

                    await con.OpenAsync();

                    // Ejecutamos la consulta de eliminación
                    return await cmd.ExecuteNonQueryAsync();
                }
            }            
        }

    }
}
