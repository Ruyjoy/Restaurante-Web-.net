using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EntidadesCompartidas;
using Logica;

public partial class Administrador : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.CacheControl = "no-cache";

        Usuario usuario = (Usuario)Session["Usuario"];

        if (usuario == null || !(usuario is EntidadesCompartidas.Administrador))
        {
            Session["Mensaje"] = "¡ERROR! Usted no está autorizado para acceder a esta página.";

            Response.Redirect("~/Default.aspx");
        }

        lblNombre.Text = usuario.NombreCompleto;
    }

    protected void lbtnSalir_Click(object sender, EventArgs e)
    {
        Session.Remove("Usuario");
    }
}
