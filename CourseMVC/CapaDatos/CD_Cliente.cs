using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaEntidad;
using System.Data;
using System.Data.SqlClient;



namespace CapaDatos
{
    public class CD_Cliente
    {
        public int Add(Cliente obj, out string Mensaje )
        {
            int IdAutogen = 0;

            Mensaje = string.Empty;

            try
            {
                using (SqlConnection xConec = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("sp_RegistrarCliente", xConec);
                    cmd.Parameters.AddWithValue("Nombres", obj.Nombres);
                    cmd.Parameters.AddWithValue("Apellidos", obj.Apellidos);
                    cmd.Parameters.AddWithValue("Correo", obj.Correo);
                    cmd.Parameters.AddWithValue("Clave", obj.Clave);
                    cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;

                    cmd.CommandType = CommandType.StoredProcedure;

                    xConec.Open();

                    cmd.ExecuteNonQuery();

                    IdAutogen = Convert.ToInt32(cmd.Parameters["Resultado"].Value);
                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString();

                } 
            }catch(Exception ex)
            {

                IdAutogen = 0;
                Mensaje = ex.Message;

            }
            return IdAutogen;
        }

        public List<Cliente> Fetch()
        {
            List<Cliente> list = new List<Cliente>();

            try
            {
                using (SqlConnection xCon = new SqlConnection(Conexion.cn))
                {
                    string query = "Select IdCliente,Nombres,Apellidos,Mail,Clave,Reestablecer from Cliente";

                    SqlCommand cmd = new SqlCommand(query, xCon);
                    cmd.CommandType = CommandType.Text;

                    xCon.Open();

                    using(SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            list.Add(
                                new Cliente()
                                {
                                    IdCliente = Convert.ToInt32(dr["IdCliente"]),
                                    Nombres = dr["Nombres"].ToString(),
                                    Apellidos = dr["Apellidos"].ToString(),
                                    Correo = dr["Mail"].ToString(),
                                    Clave = dr["Clave"].ToString(),
                                    Reestablecer = Convert.ToBoolean(dr["Reestablecer"])
                                }
                                );


                        }
                    }
                }

            }
            catch
            {
                list = new List<Cliente>();
            }
            return list;
        }

        public bool ChangePassword(int idCliente, string newPass, out string Mensaje)
        {
            bool resultado = false;
            Mensaje = string.Empty;

            try
            {
                using(SqlConnection xCon = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("update cliente set clave = @newPass, reestablecer = 0 where idCliente = @id", xCon);
                    cmd.Parameters.AddWithValue("@id", idCliente);
                    cmd.Parameters.AddWithValue("@newPass", newPass);
                    cmd.CommandType = CommandType.Text;

                    xCon.Open();
                    resultado = cmd.ExecuteNonQuery() > 0 ? true : false;
                }

            }
            catch(Exception ex)
            {
                resultado = false;
                Mensaje = ex.Message;
            }
            return resultado;

        }

        public bool RestorePassword(int idCliente, string clave, out string Mensaje)
        {
            bool resultado = false;
            Mensaje=string.Empty;

            try
            {

                using(SqlConnection xCon=new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("update cliente set clave = @clave, reestablecer = 1 where idCliente = @id", xCon);
                    cmd.Parameters.AddWithValue("@id", idCliente);
                    cmd.Parameters.AddWithValue("@clave", clave);
                    cmd.CommandType = CommandType.Text;
                    xCon.Open();
                    resultado =cmd.ExecuteNonQuery() >= 0 ? true : false;
                }

            }catch(Exception ex)
            {
                resultado=false;
                Mensaje = ex.Message;
            }
            return resultado;
        }


    }
}
