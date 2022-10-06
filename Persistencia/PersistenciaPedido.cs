using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntidadesCompartidas;
using System.Data;
using System.Data.SqlClient;

namespace Persistencia
{
    public class PersistenciaPedido
    {
        public static Pedido Buscar(int numero)
        {
            SqlConnection conexion = null;
            SqlDataReader drPedido = null;

            try
            {
                conexion = new SqlConnection(Conexion.CadenaConexion);

                SqlCommand cmdBuscarPedido = new SqlCommand("BuscarPedido", conexion);
                cmdBuscarPedido.CommandType = CommandType.StoredProcedure;

                cmdBuscarPedido.Parameters.AddWithValue("@numero", numero);

                conexion.Open();
                drPedido = cmdBuscarPedido.ExecuteReader();

                Pedido pedido = null;

                if (drPedido.Read())
                {
                    Cliente cliente = new Cliente((int)drPedido["cedula"], (string)drPedido["nombreLogueo"], (string)drPedido["contraseña"], (string)drPedido["nombreCompleto"], (string)drPedido["tarjetaCredito"], (string)drPedido["direccion"]);

                    Casa casa = new Casa((int)drPedido["rut"], (string)drPedido["Casa"], (string)drPedido["especializacion"]);

                    Plato plato = new Plato((int)drPedido["IdPlato"], (string)drPedido["nombre"], (double)drPedido["precio"], (string)drPedido["foto"], casa);

                    pedido = new Pedido((int)drPedido["Numero"], (bool)drPedido["entregado"], (int)drPedido["cantidad"], (DateTime)drPedido["fecha"], plato, cliente);
                }

                return pedido;

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
                if (drPedido != null)
                {
                    drPedido.Close();
                }

                if (conexion != null)
                {
                    conexion.Close();
                }
            }
        }

        public static void Agregar(Pedido pedido)
        {
            SqlConnection conexion = null;

            try
            {
                conexion = new SqlConnection(Conexion.CadenaConexion);

                SqlCommand cmdAgregarPedido = new SqlCommand("AgregarPedido", conexion);
                cmdAgregarPedido.CommandType = CommandType.StoredProcedure;

                cmdAgregarPedido.Parameters.AddWithValue("@Fecha", pedido.Fecha);
                cmdAgregarPedido.Parameters.AddWithValue("@Cantidad", pedido.Cantidad);
                cmdAgregarPedido.Parameters.AddWithValue("@Entregado", pedido.Entregado);
                cmdAgregarPedido.Parameters.AddWithValue("@IdPlato", pedido.Plato.Id);
                cmdAgregarPedido.Parameters.AddWithValue("@Cedula", pedido.Cliente.Cedula);
                cmdAgregarPedido.Parameters.AddWithValue("@Rut", pedido.Plato.Casa.Rut);

                SqlParameter valorRetorno = new SqlParameter("@valorRetorno", SqlDbType.Int);
                valorRetorno.Direction = ParameterDirection.ReturnValue;
                cmdAgregarPedido.Parameters.Add(valorRetorno);

                conexion.Open();
                int filasAfectadas = cmdAgregarPedido.ExecuteNonQuery();

                switch ((int)valorRetorno.Value)
                {
                    case -1:
                        throw new ExcepcionPersonalizada("No existe un usuario con la cedula " + pedido.Cliente.Cedula + ".");

                        break;

                    case -2:
                        throw new ExcepcionPersonalizada("La casa con el Rut " + pedido.Plato.Casa.Rut + "no existe.");

                        break;

                    case -3:
                        throw new ExcepcionPersonalizada("El plato con el Id " + pedido.Plato.Id + "no existe.");

                        break;

                    case -4:
                        throw new ExcepcionPersonalizada("Ocurrio un problema al ingresar el pedido.");

                        break;
                }

                if (filasAfectadas < 1)
                {
                    throw new ExcepcionPersonalizada("Se produjo un error al ingresar el pedido.");
                }

                pedido.Numero = (int)valorRetorno.Value;
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

        public static void Modificar(Pedido pedido)
        {
            SqlConnection conexion = null;

            try
            {
                conexion = new SqlConnection(Conexion.CadenaConexion);

                SqlCommand cmdModificarPedido = new SqlCommand("ModificarPedido", conexion);
                cmdModificarPedido.CommandType = CommandType.StoredProcedure;


                cmdModificarPedido.Parameters.AddWithValue("@numero", pedido.Numero);
                cmdModificarPedido.Parameters.AddWithValue("@fecha", pedido.Fecha);
                cmdModificarPedido.Parameters.AddWithValue("@cantidad", pedido.Cantidad);
                cmdModificarPedido.Parameters.AddWithValue("@entregado", pedido.Entregado);
                cmdModificarPedido.Parameters.AddWithValue("@idPlato", pedido.Plato.Id);
                cmdModificarPedido.Parameters.AddWithValue("@cedula", pedido.Cliente.Cedula);
                cmdModificarPedido.Parameters.AddWithValue("@rut", pedido.Plato.Casa.Rut);

                conexion.Open();
                int filasAfectadas = cmdModificarPedido.ExecuteNonQuery();

                if (filasAfectadas < 1)
                {
                    throw new ExcepcionPersonalizada("Se produjo un error al modificar el pedido.");
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

        public static List<Pedido> Listar()
        {
            SqlConnection conexion = null;
            SqlDataReader drPedido = null;
            List<Pedido> pedidos = new List<Pedido>();
            try
            {
                conexion = new SqlConnection(Conexion.CadenaConexion);

                SqlCommand cmdListarPedidos = new SqlCommand("ListarPedidos", conexion);
                cmdListarPedidos.CommandType = CommandType.StoredProcedure;

                conexion.Open();
                drPedido = cmdListarPedidos.ExecuteReader();

                Pedido pedido = null;

                while (drPedido.Read())
                {
                    Cliente cliente = new Cliente((int)drPedido["cedula"], (string)drPedido["nombreLogueo"], (string)drPedido["contraseña"], (string)drPedido["nombreCompleto"], (string)drPedido["tarjetaCredito"], (string)drPedido["direccion"]);
                
                    Casa casa = new Casa((int)drPedido["rut"], (string)drPedido["Casa"], (string)drPedido["especializacion"]);

                    Plato plato = new Plato((int)drPedido["IdPlato"], (string)drPedido["nombre"], (double)drPedido["precio"], (string)drPedido["foto"], casa);
               
                    pedido = new Pedido((int)drPedido["Numero"], (bool)drPedido["entregado"], (int)drPedido["cantidad"], (DateTime)drPedido["fecha"], plato, cliente);
                    pedidos.Add(pedido);
                }

                return pedidos;
            }
            catch (ExcepcionPersonalizada ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw new ExcepcionPersonalizada("Ocurrio un problema al acceder a la base de datos.");
            }
            finally
            {
                if (drPedido != null)
                {
                    drPedido.Close();
                }
                if (conexion != null)
                {
                    conexion.Close();
                }
            }
        }
    
    }
}
