using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntidadesCompartidas
{
    public class Plato
    {
        private int _id;
        private string _nombre;
        private double _precio;
        private string _foto;

        private Casa _casa;

        public int Id
        {
            get
            {
                return _id;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ExcepcionPersonalizada("El Id debe ser un número positivo.");
                }

                _id = value;
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

        public double Precio
        {
            get
            {
                return _precio;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ExcepcionPersonalizada("El precio debe ser mayor a cero.");
                }

                _precio = value;
            }
        }

        public string Foto
        {
            get
            {
                return _foto;
            }

            set
            {
                _foto = value;
            }
        }

        public Casa Casa
        {
            get 
            {
                return _casa;
            }

            set 
            {
                if(value == null)
                {
                    throw new ExcepcionPersonalizada("Debe ingresar la casa donde se preparo el plato.");
                }

                _casa = value;
            }
        }

        public Plato(string nombre, double precio, string foto, Casa casa)
        {
            Nombre = nombre;
            Precio = precio;
            Foto = foto;
            Casa = casa;
        }

        public Plato(int id, string nombre, double precio, string foto, Casa casa)
        {
            Id = id;
            Nombre = nombre;
            Precio = precio;
            Foto = foto;
            Casa = casa;
        }

        public override string ToString()
        {
            return "Id: " + Id + ", Nombre: " + Nombre + ", Precio: " + Precio + ", Casa: " + Casa.Nombre + ", Rut: " + Casa.Rut + ".";
        }
    }
}
