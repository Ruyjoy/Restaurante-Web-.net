using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntidadesCompartidas;
using Persistencia;

namespace Logica
{
    public class LogicaPedido
    {
        public static Pedido Buscar(int numero)
        {
            return PersistenciaPedido.Buscar(numero);
        }

        public static void Agregar(Pedido pedido)
        {
            if (pedido == null)
            {
                throw new ExcepcionPersonalizada("El pedido es nulo.");
            }

            PersistenciaPedido.Agregar(pedido);
        }

        public static void Modificar(Pedido pedido)
        {
            if (pedido == null)
            {
                throw new ExcepcionPersonalizada("El pedido es nulo.");
            }

            PersistenciaPedido.Modificar(pedido);
        }

        public static List<Pedido> ListarPendientes()
        {
            List<Pedido> pedidos = PersistenciaPedido.Listar();
            List<Pedido> p = new List<Pedido>();

            foreach (Pedido x in pedidos)
            {
                if (x.Entregado == false)
                {
                    p.Add(x);
                }
            }

            return p;
        }

        public static List<Pedido> ListarPendientes(int cedula)
        {
            List<Pedido> pedidos = PersistenciaPedido.Listar();
            List<Pedido> p = new List<Pedido>();

            foreach (Pedido x in pedidos)
            {
                if (x.Cliente.Cedula == cedula)
                {
                    if (x.Entregado == false)
                    {
                        p.Add(x);
                    }
                }
            }

            return p;
        }

        public static List<Pedido> ListarEntregadosPorFecha(DateTime fecha)
        {
            List<Pedido> pedidos = PersistenciaPedido.Listar();
            List<Pedido> p = new List<Pedido>();

            foreach (Pedido x in pedidos)
            {
                if (x.Entregado)
                {

                    if (x.Fecha.Date == fecha.Date)
                    {
                        p.Add(x);
                    }
                }
            }

            return p;
        }
    }
}
