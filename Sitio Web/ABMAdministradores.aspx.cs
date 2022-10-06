using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EntidadesCompartidas;
using Logica;

public partial class ABMAdministradores : System.Web.UI.Page
{
    protected void mostrarMensajeError(string mensajeError)
    {
        lblMensaje.ForeColor = System.Drawing.Color.Red;
        lblMensaje.Text = "¡ERROR! " + mensajeError;
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        ((LinkButton)Master.FindControl("lbtnAdministrador")).Enabled = false;

        btnSi.Visible = false;
        btnNo.Visible = false;

        if (!IsPostBack)
        {
            txtNombre.Focus();
        }
    }

    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        int cedula = 0;
        EntidadesCompartidas.Administrador ad = null;

        if(String.IsNullOrWhiteSpace(txtCedula.Text))
        {
            mostrarMensajeError("Debe ingresar la cedula para buscar un administrador.");
            return;
        }

        try
        {
            cedula = Convert.ToInt32(txtCedula.Text);

            if (cedula <= 0)
            {
                mostrarMensajeError("La cedula debe ser un numero positivo.");
                return;
            }

            ad = (EntidadesCompartidas.Administrador)LogicaUsuario.Buscar(cedula);
        }
        catch (FormatException)
        {
            mostrarMensajeError("La cedula debe ser un numero entero.");
            return;
        }
        catch (ExcepcionPersonalizada ex)
        {
            mostrarMensajeError(ex.Message);
            return;
        }
        catch
        {
            mostrarMensajeError("Ocurrió un problema al buscar el administrador.");
        }

        if (ad != null)
        {
            if (ad is EntidadesCompartidas.Administrador)
            {
                txtCedula.Enabled = false;

                txtNombre.Enabled = true;
                txtNombre.Text = ad.NombreCompleto;
                txtNombre.Focus();

                txtNomLogueo.Enabled = true;
                txtNomLogueo.Text = ad.NombreLogueo;

                txtContraceña.Enabled = true;
                txtContraceña.Text = ad.Contraceña;

                txtRepita.Enabled = true;
                txtRepita.Text = ad.Contraceña;

                txtCargo.Enabled = true;
                txtCargo.Text = ad.Cargo;

                btnEliminar.Visible = false;

                btnModificar.Enabled = true;
            }
            else
            {
                lblMensaje.Text = "El usuario con la cedula " + cedula + " no es un administrador.";
                return;
            }
        }
        else
        {
            lblMensaje.Text = "No se encontro ningun administrador con la cedula " + cedula + ". Puede agregarlo ahora.";

            txtCedula.Enabled = false;
            txtNombre.Enabled = true;
            txtNombre.Focus();
            txtNomLogueo.Enabled = true;
            txtContraceña.Enabled = true;
            txtRepita.Enabled = true;
            txtCargo.Enabled = true;

            btnEliminar.Visible = false;

            btnCrearCuenta.Enabled = true;
        }  

        lblEliminar.Text = string.Empty;
    }

    protected void btnModificar_Click(object sender, EventArgs e)
    {
        EntidadesCompartidas.Administrador ad = null;
        int cedula = Convert.ToInt32(txtCedula.Text);
        string nombre = txtNombre.Text;
        string nomLogueo = txtNomLogueo.Text;

        if (txtContraceña.Text != txtRepita.Text)
        {
            throw new ExcepcionPersonalizada("Debe repetir correctamente la contraseña.");
        }

        string contraseña = txtContraceña.Text;
        string repita = txtRepita.Text;
        string cargo = txtCargo.Text;

        try
        {
            ad = new EntidadesCompartidas.Administrador(cedula, nomLogueo, contraseña, nombre, cargo);
            LogicaUsuario.Modificar(ad);
        }
        catch (ExcepcionPersonalizada ex)
        {
            mostrarMensajeError(ex.Message);
            return;
        }
        catch
        {
            mostrarMensajeError("Ocurrió un problema al modificar el administrador.");
            return;
        }

        LimpiarFormulario();
    }

    protected void LimpiarFormulario()
    {
        txtCedula.Enabled = true;
        txtCedula.Text = string.Empty;
        txtCedula.Focus();

        txtNombre.Enabled = false;
        txtNombre.Text = string.Empty;

        txtNomLogueo.Enabled = false;
        txtNomLogueo.Text = string.Empty;

        txtContraceña.Enabled = false;
        txtContraceña.Text = string.Empty;

        txtRepita.Enabled = false;
        txtRepita.Text = string.Empty;

        txtCargo.Enabled = false;
        txtCargo.Text = string.Empty;

        btnBuscar.Enabled = true;
        btnCrearCuenta.Enabled = false;
        btnModificar.Enabled = false;

        lblEliminar.Text = string.Empty;

        btnEliminar.Visible = true;

        btnSi.Visible = false;
        btnNo.Visible = false;
    }

    protected void btnCrearCuenta_Click(object sender, EventArgs e)
    {
        EntidadesCompartidas.Administrador ad = null;
        int cedula = Convert.ToInt32(txtCedula.Text);
        string nombre = txtNombre.Text;
        string nomLogueo = txtNomLogueo.Text;

        

        if (txtContraceña.Text != txtRepita.Text)
        {
            mostrarMensajeError("Debe repetir correctamente la contraseña.");
            return;
        }

        string contraseña = txtContraceña.Text;
        string repita = txtRepita.Text;
        string cargo = txtCargo.Text;

        try
        {
            ad = new EntidadesCompartidas.Administrador(cedula, nomLogueo, contraseña, nombre, cargo);
            LogicaUsuario.Agregar(ad);
        }
        catch (ExcepcionPersonalizada ex)
        {
            mostrarMensajeError(ex.Message);
            return;
        }
        catch
        {
            mostrarMensajeError("Ocurrió un problema al agregar el administrador.");
            return;
        }

        LimpiarFormulario();
        lblMensaje.Text = "El Administrador fue agregado con exito.";
    }

    protected void btnEliminar_Click(object sender, EventArgs e)
    {
        lblEliminar.ForeColor = System.Drawing.Color.Red;
        lblEliminar.Text = "Seguro que decesa Eliminar la cuenta ?";

        btnSi.Visible = true;
        btnNo.Visible = true;
    }

    protected void btnLimpiar_Click1(object sender, EventArgs e)
    {
        LimpiarFormulario();
    }

    protected void btnSi_Click(object sender, EventArgs e)
    {
         try
        {

        EntidadesCompartidas.Administrador ad = (EntidadesCompartidas.Administrador)Session["Usuario"];
        LogicaUsuario.Eliminar(ad);
        Session.Remove("Usuario");

        Response.Redirect("~/Default.aspx");

        }
        catch (ExcepcionPersonalizada ex)
        {
            mostrarMensajeError(ex.Message);
            return;
        }
        catch
        {
            mostrarMensajeError("Ocurrió un problema al eliminar el administrador.");
            return;
        }
    }

    protected void btnNo_Click(object sender, EventArgs e)
    {
        lblEliminar.Text = string.Empty;
        return;
    }
}