using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntidadesCompartidas;
using Persistencia;

namespace Logica
{
    public class LogicaPlato
    {
        public static Plato Buscar(int rut, int id)
        {
            return PersistenciaPlato.Buscar(rut, id);
        }

        public static void Agregar(Plato plato)
        {
            if (plato == null)
            {
                throw new ExcepcionPersonalizada("El plato es nulo.");
            }

            PersistenciaPlato.Agregar(plato);
        }

        public static void Modificar(Plato plato)
        {
            if (plato == null)
            {
                throw new ExcepcionPersonalizada("El plato es nulo.");
            }

            PersistenciaPlato.Modificar(plato);
        }

        public static void Eliminar(Plato plato)
        {
            if (plato == null)
            {
                throw new ExcepcionPersonalizada("El plato es nulo.");
            }

            PersistenciaPlato.Eliminar(plato);
        }

        public static List<Plato> Listar()
        {
            return PersistenciaPlato.Listar();
        }

        public static List<Plato> ListarPlatosCasa(int rut)
        {
            return PersistenciaPlato.ListarPlatosCasa(rut);
        }

     }
}
