using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EntidadesCompartidas;
using Logica;

public partial class ABMPlatos : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ((LinkButton)Master.FindControl("lbtnPlatos")).Enabled = false;

        if (!IsPostBack)
        {
            List<Casa> casas = null;
            gvPlatos.DataBind();

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
                mostrarMensajeError("Ocurrio un problema al listar las casas de comidas.");
                return;
            }

            for (int i = 0; i < casas.Count; i++)
            {
                ddlRut.Items.Add(new ListItem(casas[i].Nombre + ", Rut: " + casas[i].Rut, casas[i].Rut.ToString()));
            }



        }

    }

    protected void mostrarMensajeError(string mensajeError)
    {
        lblMensaje.ForeColor = System.Drawing.Color.Red;
        lblMensaje.Text = "¡ERROR! " + mensajeError;
    }

    protected void btnMostrar_Click(object sender, EventArgs e)
    {
        List<Plato> platos;
        int rut = Convert.ToInt32(ddlRut.SelectedValue);

        try
        {
            platos = LogicaPlato.ListarPlatosCasa(rut);
        }
        catch (ExcepcionPersonalizada ex)
        {
            mostrarMensajeError(ex.Message);

            return;
        }
        catch
        {
            mostrarMensajeError("Se produjo un error al listar los Platos.");

            return;
        }

        gvPlatos.DataSource = platos;
        gvPlatos.DataBind();

    }

    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        gvPlatos.DataBind();

        int id = 0;
        int rut = Convert.ToInt32(ddlRut.SelectedValue);
        Plato plato = null;

        try
        {
            id = Convert.ToInt32(txtId.Text);

            plato = LogicaPlato.Buscar(rut, id);
        }
        catch (FormatException)
        {
            mostrarMensajeError("El Id debe ser un numero entero.");
            return;
        }
        catch (ExcepcionPersonalizada ex)
        {
            mostrarMensajeError(ex.Message);
            return;
        }
        catch
        {
            mostrarMensajeError("Ocurrio un problema al buscar el plato.");
            return;
        }

        if (plato != null)
        {
            txtNombre.Text = plato.Nombre;
            txtPrecio.Text = plato.Precio.ToString();
            ImgFoto.ImageUrl = plato.Foto;

            btnBuscar.Enabled = false;
            txtId.Enabled = false;
            ddlRut.Enabled = false;

            txtNombre.Enabled = true;
            txtPrecio.Enabled = true;

            btnModificar.Enabled = true;
            btnEliminar.Enabled = true;

            btnAgregar.Enabled = false;

            btnMostrar.Enabled = false;

            Session["Foto"] = plato.Foto;
        }
        else
        {
            //btnBuscar.Enabled = false;
            //txtId.Enabled = false;
            //txtNombre.Enabled = true;
            //txtPrecio.Enabled = true;
            //btnAgregar.Enabled = true;

            lblMensaje.Text = "El plato con el id " + id + " no existe.";
        }
    }

    protected void btnAgregar_Click(object sender, EventArgs e)
    {
        int rut = Convert.ToInt32(ddlRut.SelectedValue);
        Plato plato = null;
        string nombre = txtNombre.Text;
        string foto;



        string nombreFoto;

        if (String.IsNullOrWhiteSpace(txtNombre.Text))
        {
            mostrarMensajeError("Debe ingresar el nombre del plato");
            return;
        }

        if (String.IsNullOrWhiteSpace(txtPrecio.Text))
        {
            mostrarMensajeError("Debe ingresar el precio del plato");
            return;
        }

        if (fuFoto.HasFile)
        {
            nombreFoto = fuFoto.PostedFile.FileName;

            foto = "~/FotosPlatos/" + nombreFoto;
        }
        else if (Session["Foto"] != null)
        {
            foto = (string)Session["Foto"];
            Session.Remove("Foto");
        }
        else
        {
            mostrarMensajeError("Debe seleccionar una foto para el plato.");
            return;
        }


        try
        {
            double precio = Convert.ToDouble(txtPrecio.Text);

            Casa casa = LogicaCasa.Buscar(rut);

            plato = new Plato(rut, nombre, precio, foto, casa);
            LogicaPlato.Agregar(plato);
        }
        catch (FormatException)
        {
            mostrarMensajeError("El precio debe ser un Numero positivo.");
            return;
        }
        catch (ExcepcionPersonalizada ex)
        {
            mostrarMensajeError(ex.Message);
            return;
        }
        catch
        {
            mostrarMensajeError("Ocurrio un problema al agregar el plato.");
            return;
        }

        lblMensaje.Text = "Plato agregado con Exito. Su id es " + plato.Id + ".";
        limpiarFormulario();


    }

    protected void limpiarFormulario()
    {
        gvPlatos.DataBind();

        txtId.Enabled = true;
        txtId.Text = string.Empty;
        txtId.Focus();


        txtNombre.Text = string.Empty;


        txtPrecio.Text = string.Empty;

        btnBuscar.Enabled = true;

        btnModificar.Enabled = false;
        btnEliminar.Enabled = false;

        btnAgregar.Enabled = true;

        ImgFoto.ImageUrl = string.Empty;

        ddlRut.Enabled = true;
        btnMostrar.Enabled = true;
    }

    protected void btnModificar_Click(object sender, EventArgs e)
    {
        int id = 0;
        int rut = Convert.ToInt32(ddlRut.SelectedValue);
        Plato plato = null;
        string nombre = txtNombre.Text;
        string foto;

        string nombreFoto;

        if (fuFoto.HasFile)
        {
            nombreFoto = fuFoto.PostedFile.FileName;

            foto = "~/FotosPlatos/" + nombreFoto;
        }
        else if (Session["Foto"] != null)
        {
            foto = (string)Session["Foto"];
            Session.Remove("Foto");
        }
        else
        {
            mostrarMensajeError("Debe seleccionar una foto para el plato.");
            return;
        }

        try
        {
            double precio = Convert.ToDouble(txtPrecio.Text);
            id = Convert.ToInt32(txtId.Text);

            Casa casa = LogicaCasa.Buscar(rut);

            plato = new Plato(id, nombre, precio, foto, casa);
            LogicaPlato.Modificar(plato);
        }
        catch (FormatException)
        {
            mostrarMensajeError("El precio debe ser un Numero positivo.");
            return;
        }
        catch (ExcepcionPersonalizada ex)
        {
            mostrarMensajeError(ex.Message);
            return;
        }
        catch
        {
            mostrarMensajeError("Ocurrio un problema al modificar el plato.");
            return;
        }

        lblMensaje.Text = "El plato fue modificado con Exito.";
        limpiarFormulario();
        btnAgregar.Enabled = true;
    }

    protected void btnEliminar_Click(object sender, EventArgs e)
    {
        int id = 0;
        int rut = Convert.ToInt32(ddlRut.SelectedValue);
        Plato plato = null;
        string nombre = txtNombre.Text;
        string foto = ImgFoto.ImageUrl;

        try
        {
            double precio = Convert.ToDouble(txtPrecio.Text);
            id = Convert.ToInt32(txtId.Text);

            Casa casa = LogicaCasa.Buscar(rut);

            plato = new Plato(id, nombre, precio, foto, casa);
            LogicaPlato.Eliminar(plato);
        }
        catch (FormatException)
        {
            mostrarMensajeError("El precio debe ser un Numero positivo.");
            return;
        }
        catch (ExcepcionPersonalizada ex)
        {
            mostrarMensajeError(ex.Message);
            return;
        }
        catch
        {
            mostrarMensajeError("Ocurrio un problema al Eliminar el plato.");
            return;
        }

        lblMensaje.Text = "Plato Eliminado con Exito.";
        limpiarFormulario();
        btnAgregar.Enabled = true;
    }

    protected void btnMostrarFoto_Click(object sender, EventArgs e)
    {
        string nombreFoto;

        if (fuFoto.HasFile)
        {
            nombreFoto = fuFoto.PostedFile.FileName;

            ImgFoto.ImageUrl = "~/FotosPlatos/" + nombreFoto;

            Session["Foto"] = "~/FotosPlatos/" + nombreFoto;
        }
        else
        {
            mostrarMensajeError("Debe seleccionar una foto");
            return;
        }
    }

    protected void btnLimpiar_Click(object sender, EventArgs e)
       {
           limpiarFormulario();
       }
}