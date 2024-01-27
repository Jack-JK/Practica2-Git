using PracticoSI1.Business.Contracts;
using PracticoSI1.Models;
using System.Data.SqlClient;

namespace PracticoSI1.Business.Clases
{
    public class cIGrupoArticuloRepository : IcIGrupoArticuloRepository
    {
        private readonly string conect;
        public cIGrupoArticuloRepository(IConfiguration _IConfiguration)
        {
            conect = _IConfiguration.GetConnectionString("conBase");
        }
        public async Task<List<cIGrupoArticulo>> GetList()
        {
            List<cIGrupoArticulo> list = new List<cIGrupoArticulo>();
            cIGrupoArticulo l;
            using (SqlConnection obj = new SqlConnection(conect))
            {
                await obj.OpenAsync();
                SqlCommand cmd = new SqlCommand("select * from cIGrupoArticulo", obj);
                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        l = new cIGrupoArticulo();
                        l.IdGrupoArticulo = Convert.ToInt32(reader["IdGrupoArticulo"]);
                        l.NombreGrupoArticulo = Convert.ToString(reader["NombreGrupoArticulo"]);
                        l.Abreviatura = Convert.ToString(reader["Abreviatura"]);
                        l.IdPadre = Convert.ToInt32(reader["IdPadre"]);
                        l.IdPartida = Convert.ToInt32(reader["IdPartida"]);
                        l.Nivel = Convert.ToInt32(reader["Nivel"]);
                        l.Sector = Convert.ToString(reader["Sector"]);
                        l.FechaRegistro = Convert.ToDateTime(reader["FechaRegistro"]);
                        l.EstadoRegistro = Convert.ToString(reader["EstadoRegistro"]);

                        list.Add(l);
                    }
                }
            }
            return list;
        }
        public async Task<cIGrupoArticulo> AgregaActualiza(cIGrupoArticulo l, string t)
        {
            using (SqlConnection obj = new SqlConnection(conect))
            {
                string cadena = "";

                if (t == "c")
                {
                    cadena = "INSERT INTO cIGrupoArticulo ( NombreGrupoArticulo , Abreviatura, IdPadre, IdPartida, Nivel, Sector, FechaRegistro, EstadoRegistro) " +
                             "VALUES ( @NombreGrupoArticulo, @Abreviatura, @IdPadre, @IdPartida, @Nivel, @Sector, @FechaRegistro, @EstadoRegistro); SELECT SCOPE_IDENTITY();";
                }
                else if (t == "u")
                {
                    cadena = "UPDATE cIGrupoArticulo SET NombreGrupoArticulo = @NombreGrupoArticulo, " +
                             "Abreviatura = @Abreviatura, IdPadre = @IdPadre, " +
                             "IdPartida = @IdPartida, Nivel = @Nivel, " +
                             "Sector = @Sector, FechaRegistro = @FechaRegistro, " +
                             "EstadoRegistro = @EstadoRegistro WHERE IdGrupoArticulo = @IdGrupoArticulo; ";
                }
                using (SqlCommand cmd = new SqlCommand(cadena, obj))
                {
                    cmd.Parameters.AddWithValue("@IdGrupoArticulo", l.IdGrupoArticulo);
                    cmd.Parameters.AddWithValue("@NombreGrupoArticulo", l.NombreGrupoArticulo);
                    cmd.Parameters.AddWithValue("@Abreviatura", l.Abreviatura);
                    cmd.Parameters.AddWithValue("@IdPadre", l.IdPadre);
                    cmd.Parameters.AddWithValue("@IdPartida", l.IdPartida);
                    cmd.Parameters.AddWithValue("@Nivel", l.Nivel);
                    cmd.Parameters.AddWithValue("@Sector", l.Sector);
                    cmd.Parameters.AddWithValue("@FechaRegistro", l.FechaRegistro);
                    cmd.Parameters.AddWithValue("@EstadoRegistro", l.EstadoRegistro);
                    await obj.OpenAsync();
                    if (t == "c")
                    {
                        // Si es una operación de inserción, obtenemos el nuevo ID
                        object result = await cmd.ExecuteScalarAsync();
                        l.IdGrupoArticulo = Convert.ToInt32(result);
                    }
                    else if (t == "u")
                    {
                        // Si es una operación de actualización, ejecutamos la consulta directamente
                        await cmd.ExecuteNonQueryAsync();
                    }
                }
                return l;
            }
        }

        public async Task<int> Elimina(cIGrupoArticulo l)
        {
            using (SqlConnection con = new SqlConnection(conect))
            {
                string cadena = "DELETE FROM cIGrupoArticulo WHERE IdGrupoArticulo = @IdGrupoArticulo;";

                using (SqlCommand cmd = new SqlCommand(cadena, con))
                {
                    cmd.Parameters.AddWithValue("@IdGrupoArticulo", l.IdGrupoArticulo);

                    await con.OpenAsync();

                    // Ejecutamos la consulta de eliminación
                    return await cmd.ExecuteNonQueryAsync();
                }
            }
        }

    }
}
