using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EntidadesCompartidas;

/// <summary>
/// Descripción breve de MostrarPedido
/// </summary>
public class MostrarPedido
{
	
    private DateTime _fecha;
    private string _plato;
    private string _casa;
    private int _numero;

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

    public string Plato
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

    public string CasaComida
    {
        get
        {
            return _casa;
        }

        set
        {
            _casa = value;
        }
    }

    public int NumeroDelPedido
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

    public MostrarPedido(DateTime fecha, string plato, string casa,int numero)
        {
            Fecha = fecha;
            Plato = plato;
            CasaComida = casa;
            NumeroDelPedido = numero;
        }
}