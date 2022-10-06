using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntidadesCompartidas;
using System.Data.SqlClient;
using System.Data;

namespace Persistencia
{
    public class PersistenciaCliente
    {
        public static Cliente Buscar(string nomLogueo)
        {
            SqlConnection conexion = null;
            SqlDataReader drCliente = null;

            try
            {
                conexion = new SqlConnection(Conexion.CadenaConexion);

                SqlCommand cmdBuscarCliente = new SqlCommand("BuscarCliente", conexion);
                cmdBuscarCliente.CommandType = CommandType.StoredProcedure;

                cmdBuscarCliente.Parameters.AddWithValue("@nombreLogueo", nomLogueo);

                conexion.Open();
                drCliente = cmdBuscarCliente.ExecuteReader();

                Cliente cliente = null;

                if (drCliente.Read())
                {
                    cliente = new Cliente((int)drCliente["cedula"], (string)drCliente["nombreLogueo"], (string)drCliente["contraseña"], (string)drCliente["nombreCompleto"], (string)drCliente["tarjetaCredito"], (string)drCliente["direccion"]);
                }

                return cliente;
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
                if (drCliente != null)
                {
                    drCliente.Close();
                }

                if (conexion != null)
                {
                    conexion.Close();
                }
            }
        }

        public static Cliente Buscar(int cedula)
        {
            SqlConnection conexion = null;
            SqlDataReader drCliente = null;

            try
            {
                conexion = new SqlConnection(Conexion.CadenaConexion);

                SqlCommand cmdBuscarCliente = new SqlCommand("BuscarClienteCedula", conexion);
                cmdBuscarCliente.CommandType = CommandType.StoredProcedure;

                cmdBuscarCliente.Parameters.AddWithValue("@cedula", cedula);

                conexion.Open();
                drCliente = cmdBuscarCliente.ExecuteReader();

                Cliente cliente = null;

                if (drCliente.Read())
                {
                    cliente = new Cliente((int)drCliente["cedula"], (string)drCliente["nombreLogueo"], (string)drCliente["contraseña"], (string)drCliente["nombreCompleto"], (string)drCliente["tarjetaCredito"], (string)drCliente["direccion"]);
                }

                return cliente;
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
                if (drCliente != null)
                {
                    drCliente.Close();
                }

                if (conexion != null)
                {
                    conexion.Close();
                }
            }
        }

        public static void Agregar(Cliente cliente)
        {
            SqlConnection conexion = null;

            try
            {
                conexion = new SqlConnection(Conexion.CadenaConexion);

                SqlCommand cmdAgregarCliente = new SqlCommand("AgregarCliente", conexion);
                cmdAgregarCliente.CommandType = CommandType.StoredProcedure;

                cmdAgregarCliente.Parameters.AddWithValue("@cedula", cliente.Cedula);
                cmdAgregarCliente.Parameters.AddWithValue("@nombreLogueo", cliente.NombreLogueo);
                cmdAgregarCliente.Parameters.AddWithValue("@contraceña", cliente.Contraceña);
                cmdAgregarCliente.Parameters.AddWithValue("@nombreCompleto", cliente.NombreCompleto);
                cmdAgregarCliente.Parameters.AddWithValue("@tarjetaCredito", cliente.TarjetaCredito);
                cmdAgregarCliente.Parameters.AddWithValue("@direccion", cliente.Direccion);

                SqlParameter valorRetorno = new SqlParameter("@valorRetorno", SqlDbType.Int);
                valorRetorno.Direction = ParameterDirection.ReturnValue;
                cmdAgregarCliente.Parameters.Add(valorRetorno);

                conexion.Open();
                int filasAfectadas = cmdAgregarCliente.ExecuteNonQuery();

                switch ((int)valorRetorno.Value)
                {
                    case -1:
                        throw new ExcepcionPersonalizada("Ya existe un usuario con la cedula " + cliente.Cedula + ".");

                        break;

                    case -2:
                        throw new ExcepcionPersonalizada("Ya existe un usuario con el nombre de logueo " + cliente.NombreLogueo + ".");

                        break;

                    case -3:
                        throw new ExcepcionPersonalizada("Ocurrio un problema al agregar el usuario.");

                        break;

                    case -4:
                        throw new ExcepcionPersonalizada("Ocurrio un problema al agregar el cliente.");

                        break;
                }

                if (filasAfectadas < 1)
                {
                    throw new ExcepcionPersonalizada("Se produjo un error al agregar el cliente.");
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
