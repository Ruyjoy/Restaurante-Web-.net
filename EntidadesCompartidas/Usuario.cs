using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntidadesCompartidas
{
    public class Usuario
    {
        private int _cedula;
        private string _nombreLogueo;
        private string _contraceña;
        private string _nombreCompleto;

        public int Cedula
        {
            get
            {
                return _cedula;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ExcepcionPersonalizada("La cedula debe ser un número positivo.");
                }

                _cedula = value;
            }
        }

        public string NombreLogueo
        {
            get
            {
                return _nombreLogueo;
            }

            set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ExcepcionPersonalizada("El nombre de logueo no puede quedar vacio.");
                }

                _nombreLogueo = value;
            }
        }

        public string Contraceña
        {
            get
            {
                return _contraceña;
            }

            set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ExcepcionPersonalizada("La contraceña no puede quear vacia.");
                }

                _contraceña = value;
            }
        }

        public string NombreCompleto
        {
            get
            {
                return _nombreCompleto;
            }

            set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ExcepcionPersonalizada("El nombre no puede quedar vacio.");
                }

                _nombreCompleto = value;
            }
        }

        public Usuario(int cedula, string nombreLogueo, string contraceña, string nombrecomleto)
        {
            Cedula = cedula;
            NombreLogueo = nombreLogueo;
            Contraceña = contraceña;
            NombreCompleto = nombrecomleto;
        }

        public override string ToString()
        {
            return "Cedula: " + Cedula + ", Nombre de logueo: " + NombreLogueo + ", Nombre completo: " + NombreCompleto;
        }
    }
}
