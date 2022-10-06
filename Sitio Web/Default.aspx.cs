using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Logica;
using EntidadesCompartidas;


public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string mensaje = (string)Session["Mensaje"];

        if (mensaje != null)
        {
            if (mensaje.Contains("¡ERROR!"))
            {
                lblMensaje.ForeColor = System.Drawing.Color.Red;
            }

            lblMensaje.Text = mensaje;

            Session.Remove("Mensaje");
        }
    }
    protected void btnIngresar_Click(object sender, EventArgs e)
    {
        if (String.IsNullOrWhiteSpace(txtNomLogueo.Text))
        {
            lblMensaje.Text = "Debe ingresar el nombre de logueo.";
            return;
        }

        if (String.IsNullOrWhiteSpace(txtContraseña.Text))
        {
            lblMensaje.Text = "Debe ingresar la contraseña.";
            return;
        }
        string nomLogueo = txtNomLogueo.Text;
        string contraseña = txtContraseña.Text;
        Usuario usuario ;

        try 
        {
            usuario = LogicaUsuario.Buscar(nomLogueo);
            
        }

        catch (FormatException)
        {
            mostrarMensajeError("La cedula tiene que ser un numero entero.");
            return;
        }
        catch (ExcepcionPersonalizada ex)
        {
            mostrarMensajeError(ex.Message);
            return;
        }
        catch
        {
            mostrarMensajeError("Ocurrio un problema al buscar el Usuario.");
            return;
        }


        if (usuario != null && usuario.Contraceña == contraseña)
        {
            Session["Usuario"] = usuario;

            if (usuario is EntidadesCompartidas.Administrador)
            {
                Response.Redirect("~/ABMAdministradores.aspx");
            }
            else if (usuario is EntidadesCompartidas.Cliente)
            {
                Response.Redirect("~/RealizarPedido.aspx");
            }
        }
        else
        {
            lblMensaje.Text = "¡ERROR! Nombre de usuario y/o contraseña incorrecto/a(s).";
        }
    }
    protected void mostrarMensajeError(string mensajeError)
    {
        lblMensaje.ForeColor = System.Drawing.Color.Red;
        lblMensaje.Text = "¡ERROR! " + mensajeError;
    }

}