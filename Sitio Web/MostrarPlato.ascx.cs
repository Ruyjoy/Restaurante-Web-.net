using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EntidadesCompartidas;

public partial class MostrarPlato : System.Web.UI.UserControl
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
    }

    public string Nombre
    {
        get
        {
            return _nombre;
        }
    }

    public double Precio
    {
        get
        {
            return _precio;
        }
    }

    public string Foto
    {
        get
        {
            return _foto;
        }
    }

    public string NombreCasa
    {
        get
        {
            return _casa.Nombre;
        }
    }

    public int Rut
    {
        get
        {
            return _casa.Rut;
        }
    }

    public void Cargar(Plato plato)
    {
        _id = plato.Id;
        _nombre = plato.Nombre;
        _precio = plato.Precio;
        _foto = plato.Foto;
        _casa = plato.Casa;

        lblId.Text = _id.ToString();
        lblNombre.Text = _nombre;
        lblNombreCasa.Text = _casa.Nombre;
        lblPrecio.Text = _precio.ToString();
        lblRut.Text = _casa.Rut.ToString();
        imgFoto.ImageUrl = _foto;
    }

    protected void Page_Load(object sender, EventArgs e)
    {

    }
}