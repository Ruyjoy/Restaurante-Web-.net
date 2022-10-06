using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntidadesCompartidas;
using Persistencia;

namespace Logica
{
    public class LogicaCasa
    {
        public static Casa Buscar(int rut)
        {
            return PersistenciaCasa.Buscar(rut);
        }

        public static void Agregar(Casa casa)
        {
            if (casa == null)
            {
                throw new ExcepcionPersonalizada("La casa es nula.");
            }

            PersistenciaCasa.Agregar(casa);
        }

        public static void Modificar(Casa casa)
        {
            if (casa == null)
            {
                throw new ExcepcionPersonalizada("La casa es nula.");
            }

            PersistenciaCasa.Modificar(casa);
        }

        public static void Eliminar(Casa casa)
        {
            if (casa == null)
            {
                throw new ExcepcionPersonalizada("La casa es nula.");
            }

            PersistenciaCasa.Eliminar(casa);
        }

        public static List<Casa> Listar()
        {
            return PersistenciaCasa.Listar();
        }

        public static List<Casa> Listar(string especializacion)
        {
            List<Casa> casas = PersistenciaCasa.Listar();
            List<Casa> c = new List<Casa>();

            foreach (Casa casa in casas)
            {
                if (casa.Especializacion == especializacion)
                {
                    c.Add(casa);
                }
            }

            return c;
        }
    }
}
