using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntidadesCompartidas;
using System.Data.SqlClient;
using System.Data;

namespace Persistencia
{
    public class PersistenciaAdministrador
    {
        public static Administrador Buscar(string nomLogueo)
        {
            SqlConnection conexion = null;
            SqlDataReader drAdministrador = null;

            try
            {
                conexion = new SqlConnection(Conexion.CadenaConexion);

                SqlCommand cmdBuscarAdministrador = new SqlCommand("BuscarAdministrador", conexion);
                cmdBuscarAdministrador.CommandType = CommandType.StoredProcedure;

                cmdBuscarAdministrador.Parameters.AddWithValue("@nombreLogueo", nomLogueo);

                conexion.Open();
                drAdministrador = cmdBuscarAdministrador.ExecuteReader();

                Administrador administrador = null;

                if (drAdministrador.Read())
                {
                    administrador = new Administrador((int)drAdministrador["cedula"], (string)drAdministrador["nombreLogueo"], (string)drAdministrador["contraseña"], (string)drAdministrador["nombreCompleto"], (string)drAdministrador["cargo"]);
                }

                return administrador;
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
                if (drAdministrador != null)
                {
                    drAdministrador.Close();
                }

                if (conexion != null)
                {
                    conexion.Close();
                }
            }
        }

        public static Administrador Buscar(int cedula)
        {
            SqlConnection conexion = null;
            SqlDataReader drAdministrador = null;

            try
            {
                conexion = new SqlConnection(Conexion.CadenaConexion);

                SqlCommand cmdBuscarAdministrador = new SqlCommand("BuscarAdministradorCedula", conexion);
                cmdBuscarAdministrador.CommandType = CommandType.StoredProcedure;

                cmdBuscarAdministrador.Parameters.AddWithValue("@cedula", cedula);

                conexion.Open();
                drAdministrador = cmdBuscarAdministrador.ExecuteReader();

                Administrador administrador = null;

                if (drAdministrador.Read())
                {
                    administrador = new Administrador((int)drAdministrador["cedula"], (string)drAdministrador["nombreLogueo"], (string)drAdministrador["contraseña"], (string)drAdministrador["nombreCompleto"], (string)drAdministrador["cargo"]);
                }

                return administrador;
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
                if (drAdministrador != null)
                {
                    drAdministrador.Close();
                }

                if (conexion != null)
                {
                    conexion.Close();
                }
            }
        }

        public static void Agregar(Administrador administrador)
        {
            SqlConnection conexion = null;

            try
            {
                conexion = new SqlConnection(Conexion.CadenaConexion);

                SqlCommand cmdAgregarAdministrador = new SqlCommand("AgregarAdministrador", conexion);
                cmdAgregarAdministrador.CommandType = CommandType.StoredProcedure;

                cmdAgregarAdministrador.Parameters.AddWithValue("@cedula", administrador.Cedula);
                cmdAgregarAdministrador.Parameters.AddWithValue("@nombreLogueo", administrador.NombreLogueo);
                cmdAgregarAdministrador.Parameters.AddWithValue("@contraceña", administrador.Contraceña);
                cmdAgregarAdministrador.Parameters.AddWithValue("@nombreCompleto", administrador.NombreCompleto);
                cmdAgregarAdministrador.Parameters.AddWithValue("@cargo", administrador.Cargo);

                SqlParameter valorRetorno = new SqlParameter("@valorRetorno", SqlDbType.Int);
                valorRetorno.Direction = ParameterDirection.ReturnValue;
                cmdAgregarAdministrador.Parameters.Add(valorRetorno);

                conexion.Open();
                int filasAfectadas = cmdAgregarAdministrador.ExecuteNonQuery();

                switch ((int)valorRetorno.Value)
                {
                    case -1:
                        throw new ExcepcionPersonalizada("Ya existe un administrador con esa cedula.");

                        break;
                    case -2:
                        throw new ExcepcionPersonalizada("El nombre de logueo ya existe.");

                        break;
                    case -3:
                        throw new ExcepcionPersonalizada("Ocurrio un problema al agregar el usuario.");

                        break;
                    case -4:
                        throw new ExcepcionPersonalizada("Ocurrio un problema al agregar el administrador.");

                        break;
                }

                if (filasAfectadas < 1)
                {
                    throw new ExcepcionPersonalizada("Se produjo un error al agregar el administrador.");
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

        public static void Modificar(Administrador administrador)
        {
            SqlConnection conexion = null;

            try
            {
                conexion = new SqlConnection(Conexion.CadenaConexion);

                SqlCommand cmdModificarAdministrador = new SqlCommand("ModificarAdministrador", conexion);
                cmdModificarAdministrador.CommandType = CommandType.StoredProcedure;

                cmdModificarAdministrador.Parameters.AddWithValue("@cedula", administrador.Cedula);
                cmdModificarAdministrador.Parameters.AddWithValue("@nombreLogueo", administrador.NombreLogueo);
                cmdModificarAdministrador.Parameters.AddWithValue("@contraceña", administrador.Contraceña);
                cmdModificarAdministrador.Parameters.AddWithValue("@nombreCompleto", administrador.NombreCompleto);
                cmdModificarAdministrador.Parameters.AddWithValue("@cargo", administrador.Cargo);

                SqlParameter valorRetorno = new SqlParameter("@valorRetorno", SqlDbType.Int);
                valorRetorno.Direction = ParameterDirection.ReturnValue;
                cmdModificarAdministrador.Parameters.Add(valorRetorno);

                conexion.Open();
                int filasAfectadas = cmdModificarAdministrador.ExecuteNonQuery();

                switch ((int)valorRetorno.Value)
                {
                    case -1:
                        throw new ExcepcionPersonalizada("Ocurrio un problema al modificar el usuario.");

                        break;
                    case -2:
                        throw new ExcepcionPersonalizada("Ocurrio un problema al modificar el administrador.");

                        break;
                }

                if (filasAfectadas < 1)
                {
                    throw new ExcepcionPersonalizada("Ocurrió un problema al modificar el administrador.");
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

        public static void Eliminar(Administrador administrador)
        {
            SqlConnection conexion = null;

            try
            {
                conexion = new SqlConnection(Conexion.CadenaConexion);

                SqlCommand cmdEliminarAdministrador = new SqlCommand("EliminarAdministrador", conexion);
                cmdEliminarAdministrador.CommandType = CommandType.StoredProcedure;

                cmdEliminarAdministrador.Parameters.AddWithValue("@cedula", administrador.Cedula);

                SqlParameter valorRetorno = new SqlParameter("@valorRetorno", SqlDbType.Int);
                valorRetorno.Direction = ParameterDirection.ReturnValue;
                cmdEliminarAdministrador.Parameters.Add(valorRetorno);

                conexion.Open();
                int filasAfectadas = cmdEliminarAdministrador.ExecuteNonQuery();

                switch ((int)valorRetorno.Value)
                {
                    case -1:
                        throw new ExcepcionPersonalizada("Ocurrio un problema al eliminar el administrador.");

                        break;
                    case -2:
                        throw new ExcepcionPersonalizada("Ocurrio un problema al eliminar el usuario.");

                        break;
                }

                if (filasAfectadas < 1)
                {
                    throw new ExcepcionPersonalizada("Se produjo un error al eliminar el administrador.");
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
    }
}
