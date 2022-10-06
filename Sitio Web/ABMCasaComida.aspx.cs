using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EntidadesCompartidas;
using Logica;

public partial class ABMCasaComida : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ((LinkButton)Master.FindControl("lbtnCasaComida")).Enabled = false;

        List<Casa> casas = new List<Casa>();
        
        if (txtRut.Enabled)
        {
            txtRut.Focus();
        }
        else
        {
            txtNombre.Focus();
        }
    }

    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        int rut = 0;
        txtRut.Enabled = false;

        if (String.IsNullOrWhiteSpace(txtRut.Text))
        {
            mostrarMensajeError("El Rut no puede quedar vacio.");
            return;
        }

        try
        {
            rut = Convert.ToInt32(txtRut.Text);

            if (rut <= 0)
            {
                mostrarMensajeError("Para buscar una casa debe ingresar un numero positivo.");
                return;
            }
        }
        catch (FormatException)
        {
            mostrarMensajeError("El Rut debe ser un numero entero.");
            return;
        }

        Casa casa = null;

        try
        {
            casa = LogicaCasa.Buscar(rut);
        }
        catch (ExcepcionPersonalizada ex)
        {
            mostrarMensajeError(ex.Message);
            return;
        }
        catch
        {
            mostrarMensajeError("Ocurrio un problema al buscar la casa de comida.");
        }

        if (casa != null)
        {
            txtNombre.Text = casa.Nombre;
            ddlEspecializacion.SelectedValue = casa.Especializacion;

            btnBuscar.Enabled = false;
            btnModificar.Enabled = true;
            btnEliminar.Enabled = true;

            btnMostrarCasas.Enabled = false;

            ddlEspecializacion.Enabled = true;
            txtNombre.Enabled = true;


            lblMensaje.Text = "Casa encontrada con exito.";
        }
        else
        {
            btnBuscar.Enabled = false;
            btnAgregar.Enabled = true;

            txtNombre.Enabled = true;
            txtNombre.Focus();
            ddlEspecializacion.Enabled = true;

            lblMensaje.Text = "No existe una casa con el rut " + rut + ". Puede agregarla ahora.";
        }

        gvCasas.DataBind();
    }

    protected void mostrarMensajeError(string mensajeError)
    {
        lblMensaje.ForeColor = System.Drawing.Color.Red;
        lblMensaje.Text = "¡ERROR! " + mensajeError;
    }

    protected void limpiarFormulario()
    {
        txtRut.Enabled = true;
        txtRut.Text = string.Empty;
        txtRut.Focus();

        txtNombre.Enabled = false;
        txtNombre.Text = string.Empty;

        gvCasas.DataBind();

        btnBuscar.Enabled = true;
        btnAgregar.Enabled = false;
        btnModificar.Enabled = false;
        btnEliminar.Enabled = false;
        ddlEspecializacion.Enabled = false;
        btnMostrarCasas.Enabled = true;
    }

    protected void btnAgregar_Click(object sender, EventArgs e)
    {
        int rut = 0;
        string nombre = txtNombre.Text;
        string especializacion = ddlEspecializacion.SelectedValue;
        Casa casa = null;

        try
        {
            rut = Convert.ToInt32(txtRut.Text);
            casa = new Casa(rut, nombre, especializacion);
            LogicaCasa.Agregar(casa);
        }
        catch (FormatException)
        {
            mostrarMensajeError("El Rut debe ser un Numero entero.");
            return;
        }
        catch (ExcepcionPersonalizada ex)
        {
            mostrarMensajeError(ex.Message);
            return;
        }
        catch
        {
            mostrarMensajeError("Ocurrio un problema al agregar la casa de comida.");
            return;
        }

        lblMensaje.Text = "Casa agregada con Exito.";

        limpiarFormulario();
        
    }

    protected void btnModificar_Click(object sender, EventArgs e)
    {
        int rut = 0;
        string nombre = txtNombre.Text;
        string especializacion = ddlEspecializacion.SelectedValue;
        Casa casa = null;

        try
        {
            rut = Convert.ToInt32(txtRut.Text);
            casa = new Casa(rut, nombre, especializacion);
            LogicaCasa.Modificar(casa);
        }
        catch (FormatException)
        {
            mostrarMensajeError("El Rut debe ser un Numero entero.");
            return;
        }
        catch (ExcepcionPersonalizada ex)
        {
            mostrarMensajeError(ex.Message);
            return;
        }
        catch
        {
            mostrarMensajeError("Ocurrio un problema al Modificar la casa de comida.");
            return;
        }

        lblMensaje.Text = "Casa Modificada con Exito.";

        limpiarFormulario();   
    }

    protected void btnEliminar_Click(object sender, EventArgs e)
    {
        int rut = 0;
        string nombre = txtNombre.Text;
        string especializacion = ddlEspecializacion.SelectedValue;
        Casa casa = null;

        try
        {
            rut = Convert.ToInt32(txtRut.Text);
            casa = new Casa(rut, nombre, especializacion);
            LogicaCasa.Eliminar(casa);
        }
        catch (FormatException)
        {
            mostrarMensajeError("El Rut debe ser un Numero entero.");
            return;
        }
        catch (ExcepcionPersonalizada ex)
        {
            mostrarMensajeError(ex.Message);
            return;
        }
        catch
        {
            mostrarMensajeError("Ocurrio un problema al Elimiar la casa de comida.");
            return;
        }

        lblMensaje.Text = "Casa elminado con Exito.";

        limpiarFormulario();
    }

    protected void btnLimpiar_Click(object sender, EventArgs e)
    {
        limpiarFormulario();
    }

    protected void btnMostrarCasas_Click(object sender, EventArgs e)
    {
        List<Casa> casas;

        try
        {
            casas = LogicaCasa.Listar();
        }
        catch (ExcepcionPersonalizada ex)
        {
            mostrarMensajeError(ex.Message);

            return;
        }
        catch
        {
            mostrarMensajeError("Se produjo un error al listar las Casas.");

            return;
        }

        gvCasas.DataSource = casas;
        gvCasas.DataBind();

    }
}