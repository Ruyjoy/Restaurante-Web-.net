using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntidadesCompartidas
{
    public class Administrador : Usuario
    {
        private string _cargo;

        public string Cargo
        {
            get
            {
                return _cargo;
            }

            set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ExcepcionPersonalizada("Debe ingresar el cargo del administrador.");
                }

                _cargo = value;
            }
        }

        public Administrador(int cedlua, string nombreLogueo, string contraceña, string nombreComleto, string cargo)
            : base(cedlua, nombreLogueo, contraceña, nombreComleto)
        {
            Cargo = cargo;
        }

        public override string ToString()
        {
            return base.ToString() + ", Cargo: " + Cargo + ".";
        }
    }
}
