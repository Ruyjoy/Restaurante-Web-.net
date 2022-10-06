using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EntidadesCompartidas;
using System.Data;
using System.Data.SqlClient;

namespace Persistencia
{
    public class PersistenciaCasa
    {
        public static Casa Buscar(int rut)
        {
            SqlConnection conexion = null;
            SqlDataReader drCasa = null;

            try
            {
                conexion = new SqlConnection(Conexion.CadenaConexion);

                SqlCommand cmdBuscarCasa = new SqlCommand("BuscarCasa", conexion);
                cmdBuscarCasa.CommandType = CommandType.StoredProcedure;

                cmdBuscarCasa.Parameters.AddWithValue("@rut", rut);

                conexion.Open();
                drCasa = cmdBuscarCasa.ExecuteReader();

                Casa casa = null;

                if (drCasa.Read())
                {
                    casa = new Casa((int)drCasa["rut"], (string)drCasa["nombre"], (string)drCasa["especializacion"]);
                }

                return casa;
            }
            catch (ExcepcionPersonalizada ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw new ExcepcionPersonalizada("Ocurrió un problema al acceder a la base de datos.", ex);
            }
            finally
            {
                if (drCasa != null)
                {
                    drCasa.Close();
                }

                if (conexion != null)
                {
                    conexion.Close();
                }
            }
        }

        public static void Agregar(Casa casa)
        {
            SqlConnection conexion = null;

            try
            {
                conexion = new SqlConnection(Conexion.CadenaConexion);

                SqlCommand cmdAgregarCasa = new SqlCommand("AgregarCasa", conexion);
                cmdAgregarCasa.CommandType = CommandType.StoredProcedure;

                cmdAgregarCasa.Parameters.AddWithValue("@rut", casa.Rut);
                cmdAgregarCasa.Parameters.AddWithValue("@nombre", casa.Nombre);
                cmdAgregarCasa.Parameters.AddWithValue("@Especializacion", casa.Especializacion);

                conexion.Open();
                int filasAfectadas = cmdAgregarCasa.ExecuteNonQuery();

                if (filasAfectadas < 1)
                {
                    throw new ExcepcionPersonalizada("Se produjo un error al agregar la casa.");
                }
            }
            catch (ExcepcionPersonalizada ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw new ExcepcionPersonalizada("Ocurrió un problema al acceder a la base de datos.", ex);
            }
            finally
            {
                if (conexion != null)
                {
                    conexion.Close();
                }
            }
        }

        public static void Modificar(Casa casa)
        {
            SqlConnection conexion = null;

            try
            {
                conexion = new SqlConnection(Conexion.CadenaConexion);

                SqlCommand cmdModificarCasa = new SqlCommand("ModificarCasa", conexion);
                cmdModificarCasa.CommandType = CommandType.StoredProcedure;

                cmdModificarCasa.Parameters.AddWithValue("@rut", casa.Rut);
                cmdModificarCasa.Parameters.AddWithValue("@nombre", casa.Nombre);
                cmdModificarCasa.Parameters.AddWithValue("@Especializacion", casa.Especializacion);

                conexion.Open();
                int filasAfectadas = cmdModificarCasa.ExecuteNonQuery();

                if (filasAfectadas < 1)
                {
                    throw new ExcepcionPersonalizada("Ocurrió un problema al modificar la casa.");
                }
            }
            catch (ExcepcionPersonalizada ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw new ExcepcionPersonalizada("Ocurrió un problema al acceder a la base de datos.", ex);
            }
            finally
            {
                if (conexion != null)
                {
                    conexion.Close();
                }
            }
        }

        public static void Eliminar(Casa casa)
        {
            SqlConnection conexion = null;

            try
            {
                conexion = new SqlConnection(Conexion.CadenaConexion);

                SqlCommand cmdEliminarCasa = new SqlCommand("EliminarCasa", conexion);
                cmdEliminarCasa.CommandType = CommandType.StoredProcedure;

                cmdEliminarCasa.Parameters.AddWithValue("@rut", casa.Rut);

                SqlParameter valorRetorno = new SqlParameter("@valorRetorno", SqlDbType.Int);
                valorRetorno.Direction = ParameterDirection.ReturnValue;
                cmdEliminarCasa.Parameters.Add(valorRetorno);

                conexion.Open();
                int filasAfectadas = cmdEliminarCasa.ExecuteNonQuery();

                switch ((int)valorRetorno.Value)
                {
                    case -1:
                        throw new ExcepcionPersonalizada("Ocurrio un problema al eliminar los platos de la casa.");

                        break;
                    case -2:
                        throw new ExcepcionPersonalizada("Ocurrio un problema al eliminar los pedidos de la casa.");

                        break;

                    case -3:
                        throw new ExcepcionPersonalizada("Ocurrio un problema al eliminar la casa.");

                        break;
                }

                if (filasAfectadas < 1)
                {
                    throw new ExcepcionPersonalizada("Se produjo un error al eliminar la casa.");
                }
            }
            catch (ExcepcionPersonalizada ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw new ExcepcionPersonalizada("Ocurrió un problema al acceder a la base de datos.", ex);
            }
            finally
            {
                if (conexion != null)
                {
                    conexion.Close();
                }
            }
        }

        public static List<Casa> Listar()
        {
            SqlConnection conexion = null;
            SqlDataReader drCasa = null;
            List<Casa> casas = new List<Casa>();
            try
            {
                conexion = new SqlConnection(Conexion.CadenaConexion);

                SqlCommand cmdListarCasa = new SqlCommand("ListarCasas", conexion);
                cmdListarCasa.CommandType = CommandType.StoredProcedure;

                conexion.Open();
                drCasa = cmdListarCasa.ExecuteReader();

                Casa casa = null;

                while (drCasa.Read())
                {
                    casa = new Casa((int)drCasa["rut"], (string)drCasa["nombre"], (string)drCasa["especializacion"]);
                    casas.Add(casa);
                }

                return casas;
            }
            catch (ExcepcionPersonalizada ex)
            {
                throw ex;
            }
            catch
            {
                throw new ExcepcionPersonalizada("Ocurrio un problema al acceder a la base de datos.");
            }
            finally
            {
                if (drCasa != null)
                {
                    drCasa.Close();
                }
                if (conexion != null)
                {
                    conexion.Close();
                }
            }
        }
    }
}