using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntidadesCompartidas;
using System.Data;
using System.Data.SqlClient;

namespace Persistencia
{
    public class PersistenciaPlato
    {
        public static Plato Buscar(int rut, int id)
        {
            SqlConnection conexion = null;
            SqlDataReader drPlato = null;

            try
            {
                conexion = new SqlConnection(Conexion.CadenaConexion);

                SqlCommand cmdBuscarPlato = new SqlCommand("BuscarPlato", conexion);
                cmdBuscarPlato.CommandType = CommandType.StoredProcedure;

                cmdBuscarPlato.Parameters.AddWithValue("@rut", rut);
                cmdBuscarPlato.Parameters.AddWithValue("@id", id);

                conexion.Open();
                drPlato = cmdBuscarPlato.ExecuteReader();

                Plato plato = null;

                if (drPlato.Read())
                {
                    Casa casa = new Casa((int)drPlato["rut"], (string)drPlato["nombreCasa"], (string)drPlato["especializacion"]);

                    plato = new Plato((int)drPlato["id"], (string)drPlato["nombre"], (double)drPlato["precio"], (string)drPlato["foto"], casa);
                }

                return plato;
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
                if (drPlato != null)
                {
                    drPlato.Close();
                }

                if (conexion != null)
                {
                    conexion.Close();
                }
            }
        }

        public static void Agregar(Plato plato)
        {
            SqlConnection conexion = null;

            try
            {
                conexion = new SqlConnection(Conexion.CadenaConexion);

                SqlCommand cmdAgregarPlato = new SqlCommand("AgregarPlato", conexion);
                cmdAgregarPlato.CommandType = CommandType.StoredProcedure;

                cmdAgregarPlato.Parameters.AddWithValue("@rut", plato.Casa.Rut);
                cmdAgregarPlato.Parameters.AddWithValue("@nombre", plato.Nombre);
                cmdAgregarPlato.Parameters.AddWithValue("@foto", plato.Foto);
                cmdAgregarPlato.Parameters.AddWithValue("@precio", plato.Precio);

                SqlParameter valorRetorno = new SqlParameter("@valorRetorno", SqlDbType.Int);
                valorRetorno.Direction = ParameterDirection.ReturnValue;
                cmdAgregarPlato.Parameters.Add(valorRetorno);

                conexion.Open();
                int filasAfectadas = cmdAgregarPlato.ExecuteNonQuery();

                if ((int)valorRetorno.Value == -1)
                {
                    throw new ExcepcionPersonalizada("No existe una casa con el rut " + plato.Casa.Rut + ".");
                }
                else if ((int)valorRetorno.Value == -2)
                {
                    throw new ExcepcionPersonalizada("Se produjo un error al agregar el plato.");
                }
                if (filasAfectadas < 1)
                {
                    throw new ExcepcionPersonalizada("Se produjo un error al agregar el plato.");
                }

                if ((int)valorRetorno.Value == 0)
                {
                    plato.Id = 1;
                }
                else
                {
                    plato.Id = (int)valorRetorno.Value;
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

        public static void Modificar(Plato plato)
        {
            SqlConnection conexion = null;

            try
            {
                conexion = new SqlConnection(Conexion.CadenaConexion);

                SqlCommand cmdModificarPlato = new SqlCommand("ModificarPlato", conexion);
                cmdModificarPlato.CommandType = CommandType.StoredProcedure;


                cmdModificarPlato.Parameters.AddWithValue("@id", plato.Id);
                cmdModificarPlato.Parameters.AddWithValue("@rut", plato.Casa.Rut);
                cmdModificarPlato.Parameters.AddWithValue("@nombre", plato.Nombre);
                cmdModificarPlato.Parameters.AddWithValue("@foto", plato.Foto);
                cmdModificarPlato.Parameters.AddWithValue("@precio", plato.Precio);

                conexion.Open();
                int filasAfectadas = cmdModificarPlato.ExecuteNonQuery();

                if (filasAfectadas < 1)
                {
                    throw new ExcepcionPersonalizada("Se produjo un error al modificar el plato.");
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

        public static void Eliminar(Plato plato)
        {
            SqlConnection conexion = null;

            try
            {
                conexion = new SqlConnection(Conexion.CadenaConexion);

                SqlCommand cmdEliminarPlato = new SqlCommand("EliminarPlato", conexion);
                cmdEliminarPlato.CommandType = CommandType.StoredProcedure;

                cmdEliminarPlato.Parameters.AddWithValue("@id", plato.Id);
                cmdEliminarPlato.Parameters.AddWithValue("@rut", plato.Casa.Rut);

                SqlParameter valorRetorno = new SqlParameter("@valorRetorno", SqlDbType.Int);
                valorRetorno.Direction = ParameterDirection.ReturnValue;
                cmdEliminarPlato.Parameters.Add(valorRetorno);

                conexion.Open();
                int filasAfectadas = cmdEliminarPlato.ExecuteNonQuery();

                switch ((int)valorRetorno.Value)
                {
                    case -1:
                        throw new ExcepcionPersonalizada("Ocurrio un problema al eliminar los pedidos relacionados con el plato " + plato.Id + ".");

                        break;

                    case -2:
                        throw new ExcepcionPersonalizada("Ocurrio un problema al eliminar el plato.");

                        break;
                }

                if (filasAfectadas < 1)
                {
                    throw new ExcepcionPersonalizada("Se produjo un error al eliminar el plato.");
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

        public static List<Plato> Listar()
        {
            SqlConnection conexion = null;
            SqlDataReader drPlato = null;
            List<Plato> platos = new List<Plato>();
            try
            {
                conexion = new SqlConnection(Conexion.CadenaConexion);

                SqlCommand cmdListarPlatos = new SqlCommand("ListarPlatos", conexion);
                cmdListarPlatos.CommandType = CommandType.StoredProcedure;

                conexion.Open();
                drPlato = cmdListarPlatos.ExecuteReader();

                Plato plato = null;

                while (drPlato.Read())
                {
                    Casa casa = new Casa((int)drPlato["rut"], (string)drPlato["nombreCasa"], (string)drPlato["especializacion"]);

                    plato = new Plato((int)drPlato["id"], (string)drPlato["nombre"], (double)drPlato["precio"], (string)drPlato["foto"], casa);

                    platos.Add(plato);
                }

                return platos;
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
                if (drPlato != null)
                {
                    drPlato.Close();
                }
                if (conexion != null)
                {
                    conexion.Close();
                }
            }
        }

        public static List<Plato> ListarPlatosCasa(int rut)
        {
            SqlConnection conexion = null;
            SqlDataReader drPlato = null;
            List<Plato> platos = new List<Plato>();
            try
            {
                conexion = new SqlConnection(Conexion.CadenaConexion);

                SqlCommand cmdListarPlatosCasa = new SqlCommand("ListarPlatosCasa", conexion);
                cmdListarPlatosCasa.CommandType = CommandType.StoredProcedure;

                cmdListarPlatosCasa.Parameters.AddWithValue("@rut", rut);

                conexion.Open();
                drPlato = cmdListarPlatosCasa.ExecuteReader();

                Plato plato = null;

                while (drPlato.Read())
                {
                    Casa casa = new Casa((int)drPlato["rut"], (string)drPlato["nombreCasa"], (string)drPlato["especializacion"]);

                    plato = new Plato((int)drPlato["id"], (string)drPlato["nombre"], (double)drPlato["precio"], (string)drPlato["foto"], casa);

                    platos.Add(plato);
                }

                return platos;
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
                if (drPlato != null)
                {
                    drPlato.Close();
                }
                if (conexion != null)
                {
                    conexion.Close();
                }
            }
        }
    }
}
