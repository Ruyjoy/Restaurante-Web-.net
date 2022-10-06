using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntidadesCompartidas
{
    public class Casa
    {
        private int _rut;
        private string _nombre;
        private string _especializacion;

        public int Rut
        {
            get
            {
                return _rut;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ExcepcionPersonalizada("El Rut debe ser un número positivo.");
                }

                _rut = value;
            }
        }

        public string Nombre
        {
            get
            {
                return _nombre;
            }

            set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ExcepcionPersonalizada("El nombre no puede quedar vacio.");
                }

                _nombre = value;
            }
        }

        public string Especializacion
        {
            get
            {
                return _especializacion;
            }

            set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ExcepcionPersonalizada("Debe indicar una especializacion.");
                }

                _especializacion = value;
            }
        }

        
        public Casa(int rut, string nombre, string especializacion)
        {
            Rut = rut;
            Nombre = nombre;
            Especializacion = especializacion;
        }

        public override string ToString()
        {
            return "Rut: " + Rut + ", Nombre: " + Nombre + ", Especializacion: " + Especializacion + ".";
        }
    }
}
