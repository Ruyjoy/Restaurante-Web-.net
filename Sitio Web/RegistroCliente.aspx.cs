using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EntidadesCompartidas;
using Logica;

public partial class RegistroCliente : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            txtNombre.Focus();
        }
    }

    protected void btnCrear_Click(object sender, EventArgs e)
    {
        EntidadesCompartidas.Cliente cliente = null;
        string nombre = txtNombre.Text;
        string logueo = txtLogueo.Text;
        string tarjeta = txtTarjeta.Text; ;
        string direccion = txtDireccion.Text;

        if (txtConstraseña.Text != txtRepetir.Text)
        {
            mostrarMensajeError("Debe repetir correctamente la contraseña.");
            return;
        }

        string contraseña = txtConstraseña.Text;
        int cedula = 0;

        try
        {
            cedula = Convert.ToInt32(txtCedula.Text);

            if (cedula <= 0)
            {
                mostrarMensajeError("La cedula debe ser un numero positivo.");
                return;
            }

            cliente = new EntidadesCompartidas.Cliente(cedula, logueo, contraseña, nombre, tarjeta, direccion);
            LogicaUsuario.Agregar(cliente);
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
            mostrarMensajeError("Ocurrió un problema al crear la cuenta.");
            return;
        }

        lblMensaje.Text = "Cuenta creada con exito";
    }

    protected void mostrarMensajeError(string mensajeError)
    {
        lblMensaje.ForeColor = System.Drawing.Color.Red;
        lblMensaje.Text = "¡ERROR! " + mensajeError;
    }

    protected void btnLimpiar_Click(object sender, EventArgs e)
    {
        txtNombre.Text = string.Empty;
        txtCedula.Text = string.Empty;
        txtLogueo.Text = string.Empty;
        txtConstraseña.Text = string.Empty;
        txtRepetir.Text = string.Empty;
        txtTarjeta.Text = string.Empty;
        txtDireccion.Text = string.Empty;
    }
}