using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntidadesCompartidas;
using Persistencia;

namespace Logica
{
    public class LogicaUsuario
    {
        public static Usuario Buscar(string nomLogueo)
        {
            Usuario usuario = null;

            usuario = PersistenciaCliente.Buscar(nomLogueo);

            if (usuario == null)
            {
                usuario = PersistenciaAdministrador.Buscar(nomLogueo);
            }

            return usuario;
        }

        public static Usuario Buscar(int cedula)
        {
            Usuario usuario = null;

            usuario = PersistenciaCliente.Buscar(cedula);

            if (usuario == null)
            {
                usuario = PersistenciaAdministrador.Buscar(cedula);
            }

            return usuario;
        }

        public static void Agregar(Usuario usuario)
        {
            if (usuario is Administrador)
            {
                PersistenciaAdministrador.Agregar((Administrador)usuario);
            }
            else if (usuario is Cliente)
            {
                PersistenciaCliente.Agregar((Cliente)usuario);
            }
            else 
            {
                throw new ExcepcionPersonalizada("Tipo de usuario no valido.");
            }
        }

        public static void Modificar(Usuario usuario)
        {
            if (usuario is Administrador)
            {
                PersistenciaAdministrador.Modificar((Administrador)usuario);
            }
            else 
            {
                throw new ExcepcionPersonalizada("Tipo de usuario no valido.");
            }
        }

        public static void Eliminar(Usuario usuario)
        {
            if (usuario is Administrador)
            {
                PersistenciaAdministrador.Eliminar((Administrador)usuario);
            }
            else 
            {
                throw new ExcepcionPersonalizada("Tipo de usuario no valido.");
            }
        }
    }
}
