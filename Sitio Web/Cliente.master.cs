using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EntidadesCompartidas;
using Logica;


public partial class Cliente : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {

        Response.CacheControl = "no-cache";

        Usuario usuario = (Usuario)Session["Usuario"];

        if (usuario == null || !(usuario is EntidadesCompartidas.Cliente))
        {
            Session["Mensaje"] = "¡ERROR! Usted no está autorizado para acceder a la página privada del cliente.";

            Response.Redirect("~/Default.aspx");
        }

        lblNombre.Text = usuario.NombreCompleto;
    }

    protected void lbtnSalir_Click(object sender, EventArgs e)
    {
        Session.Remove("Usuario");
    }
}
