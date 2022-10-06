using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntidadesCompartidas
{
    public class Pedido
    {
        private int _numero;
        private bool _entregado;
        private int _cantidad;
        private DateTime _fecha;
        private Plato _plato;
        private Cliente _cliente;

        public int Numero
        {
            get
            {
                return _numero;
            }
            set
            {
                _numero = value;
            }
        }

        public bool Entregado
        {
            get
            {
                return _entregado;
            }
            set
            {
                _entregado = value;
            }
        }

        public int Cantidad
        {
            get
            {
                return _cantidad;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ExcepcionPersonalizada("La cantidad debe ser un número positivo.");
                }

                _cantidad = value;
            }
        }

        public DateTime Fecha
        {
            get
            {
                return _fecha;
            }
            set
            {
                _fecha = value;
            }
        }

        public Plato Plato
        {
            get
            {
                return _plato;
            }
            set
            {
                if (value == null)
                {
                    throw new ExcepcionPersonalizada("Debe ingresar un plato.");
                }

                _plato = value;
            }
        }

        public Cliente Cliente
        {
            get
            {
                return _cliente;
            }
            set
            {
                if (value == null)
                {
                    throw new ExcepcionPersonalizada("Debe ingresar un cliente.");
                }

                _cliente = value;
            }
        }

        public Pedido(bool entregado, int cantidad, DateTime fecha, Plato plato, Cliente cliente)
        {
            Entregado = entregado;
            Cantidad = cantidad;
            Fecha = fecha;
            Plato = plato;
            Cliente = cliente;
        }

        public Pedido(int numero, bool entregado, int cantidad, DateTime fecha, Plato plato, Cliente cliente)
        {
            Numero = numero;
            Entregado = entregado;
            Cantidad = cantidad;
            Fecha = fecha;
            Plato = plato;
            Cliente = cliente;
        }

        public override string ToString()
        {
            return "Numero: " + Numero + ", Cliente: " + Cliente.NombreLogueo + ", Plato: " + Plato.Nombre + ", Cantidad " + Cantidad + ", Fecha: " + Fecha + ", Entregado: " + (Entregado == true ? "Si." : "No.");
        }
    }
}
