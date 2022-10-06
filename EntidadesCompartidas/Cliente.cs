using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntidadesCompartidas
{
    public class Cliente : Usuario
    {
        private string _tarjetaCredito;
        private string _direccion;

        public string TarjetaCredito
        {
            get 
            { 
                return _tarjetaCredito; 
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ExcepcionPersonalizada("La Tarjeta de credito no puede quedar vacia.");
                }

                try
                {
                    //verifica solo numeros
                    Convert.ToInt32(value.Trim());
                }
                catch (FormatException)
                {
                    throw new ExcepcionPersonalizada("La Tarjeta de credito debe contener solamente caracteres numéricos");
                }

                _tarjetaCredito = value.Trim();
            }
        }

        public string Direccion
        {
            get
            {
                return _direccion;
            }

            set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ExcepcionPersonalizada("La direccion no puede quedar vacia.");
                }

                _direccion = value;
            }
        }

        public Cliente(int cedlua, string nombreLogueo, string contraceña, string nombrecomleto, string tarjeta, string direccion)
            : base(cedlua, nombreLogueo, contraceña, nombrecomleto)
        {
            TarjetaCredito = tarjeta;
            Direccion = direccion;
        }

        public override string ToString()
        {
            return base.ToString() + ", Tarjeta de credito: " + TarjetaCredito + ", Dirección: " + Direccion + ".";
        }
    }
}
