using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EntidadesCompartidas;

/// <summary>
/// Descripción breve de MostrarPedido2
/// </summary>
public class MostrarPedido2
{
	private DateTime _fecha;
    private string _plato;
    private string _casa;
    private int _rut;
    private string _nombreCliente;
    private string _direccion;
    private double _total;
    private int _numero;
    private int _cantidad;
    private double _precio;
    
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

    public int Rut
    {
        get
        {
            return _rut;
        }

        set
        {
            _rut = value;
        }
    }

    public string NombreDelCliente
    {
        get
        {
            return _nombreCliente;
        }
        set
        {
             _nombreCliente = value;
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
            _direccion = value;
        }
    }

    public double Total
    {
        get
        {
            return _total;
        }

        set
        {
            _total = value;
        }
    }

    public MostrarPedido2(DateTime fecha, string plato, string casa, int rut, string nombre, string direccion, int numero, int cantidad, double precio)
    {
        NumeroDelPedido = numero;
        Fecha = fecha;
        Plato = plato;
        CasaComida = casa;
        Rut = rut;
        NombreDelCliente = nombre;
        Direccion = direccion;
        Total = cantidad * precio;
    }
}