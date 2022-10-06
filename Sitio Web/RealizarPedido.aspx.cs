using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EntidadesCompartidas;
using Logica;

public partial class RelaizarPedido : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ((LinkButton)Master.FindControl("lbtnRelaizar")).Enabled = false;

        if (!IsPostBack)
        {
            ddlCasas.Items.Insert(0, "Seleccione una casa");
            ddlPlatos.Items.Insert(0, "Seleccione un Plato");
        }
    }

    protected void mostrarMensajeError(string mensajeError)
    {
        lblMensaje.ForeColor = System.Drawing.Color.Red;
        lblMensaje.Text = "¡ERROR! " + mensajeError;
    }

    protected void ddlEspecializacion_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlPlatos.Items.Clear();
        ddlPlatos.Items.Insert(0, "Seleccione un Plato");
        ddlPlatos.Enabled = false;

        txtCantidad.Text = string.Empty;
        txtCantidad.Enabled = false;
        btnCalcular.Enabled = false;
        mostrarPlato.Visible = false;


        if (ddlEspecializacion.SelectedIndex != 0)
        {
            ddlCasas.Items.Clear();

            List<Casa> casas = new List<Casa>();

            try
            {
                casas = LogicaCasa.Listar(ddlEspecializacion.SelectedValue);
            }
            catch (ExcepcionPersonalizada ex)
            {
                mostrarMensajeError(ex.Message);
                return;
            }
            catch
            {
                mostrarMensajeError("Ocurrió un problema al cargar las casas de comida.");
                return;
            }

            for (int i = 0; i < casas.Count; i++)
            {
                ddlCasas.Items.Add(new ListItem(casas[i].Nombre + ", Rut: " + casas[i].Rut, casas[i].Rut.ToString()));
            }

            ddlCasas.Enabled = true;
            ddlCasas.Items.Insert(0, "Seleccione una casa");
        }
        else
        {
           ddlCasas.Items.Clear();
           ddlCasas.Items.Insert(0, "Seleccione una casa");
           ddlCasas.Enabled = false;

        }
        
    }

    protected void ddlCasas_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtCantidad.Text = string.Empty;
        txtCantidad.Enabled = false;
        btnCalcular.Enabled = false;
        mostrarPlato.Visible = false;

        if (ddlCasas.SelectedIndex != 0)
        {
            ddlPlatos.Enabled = true;
            ddlPlatos.Items.Clear();

            List<Plato> platos = new List<Plato>();

            try
            {
                platos = LogicaPlato.ListarPlatosCasa(Convert.ToInt32(ddlCasas.SelectedValue));
            }
            catch (ExcepcionPersonalizada ex)
            {
                mostrarMensajeError(ex.Message);
                return;
            }
            catch
            {
                mostrarMensajeError("Ocurrió un problema al cargar los platos.");
                return;
            }

            for (int i = 0; i < platos.Count; i++)
            {
                ddlPlatos.Items.Add(new ListItem(platos[i].Nombre + ", Id: " + platos[i].Id, platos[i].Id.ToString()));
            }

            ddlPlatos.Items.Insert(0, "Seleccione un Plato");
        }
        else
        {
            ddlPlatos.Items.Clear();
            ddlPlatos.Items.Insert(0, "Seleccione un Plato");
            ddlPlatos.Enabled = false;
        }
    }

    protected void ddlPlatos_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlPlatos.SelectedIndex != 0)
        {
            try
            {
                mostrarPlato.Cargar(LogicaPlato.Buscar(Convert.ToInt32(ddlCasas.SelectedValue), Convert.ToInt32(ddlPlatos.SelectedValue)));

                Session["Precio"] = mostrarPlato.Precio;
            }
            catch (ExcepcionPersonalizada ex)
            {
                mostrarMensajeError(ex.Message);
                return;
            }
            catch
            {
                mostrarMensajeError("Ocurrió un problema al cargar el plato.");
                return;
            }

            txtCantidad.Enabled = true;
            mostrarPlato.Visible = true;
            btnCalcular.Enabled = true;
        }
        else
        {
            txtCantidad.Text = string.Empty;
            txtCantidad.Enabled = false;
            btnCalcular.Enabled = false;
            mostrarPlato.Visible = false;
        }
    }

    protected void btnConfirmar_Click(object sender, EventArgs e)
    {
        Pedido pedido = null;
        bool entregado = false;
        int cantidad = 0;
        DateTime fecha = DateTime.Now;
        Plato plato = null;
        EntidadesCompartidas.Cliente cliente = null;

        try
        {
            if (ddlEspecializacion.SelectedIndex == 0)
            {
                mostrarMensajeError("Debe seleccionar una especializacion.");
                return;
            }

            if (ddlCasas.SelectedIndex == 0)
            {
                mostrarMensajeError("Debe seleccionar una casa de comida.");
                return;
            }

            if (ddlPlatos.SelectedIndex == 0)
            {
                mostrarMensajeError("Debe seleccionar un plato.");
                return;
            }

            if (txtCantidad.Enabled == false)
            {
                txtCantidad.Enabled = true;
            }

            cantidad = Convert.ToInt32(txtCantidad.Text);

            if (cantidad <= 0)
            {
                mostrarMensajeError("La cantidad debe ser un numero mayor a cero.");
                return;
            }

            plato = LogicaPlato.Buscar(Convert.ToInt32(ddlCasas.SelectedValue), Convert.ToInt32(ddlPlatos.SelectedValue));
            cliente = (EntidadesCompartidas.Cliente)Session["Usuario"];

            pedido = new Pedido(entregado, cantidad, fecha, plato, cliente);
            LogicaPedido.Agregar(pedido);
        }
        catch (FormatException)
        {
            mostrarMensajeError("La cantidad debe ser un numero entero.");
            return;
        }
        catch (ExcepcionPersonalizada ex)
        {
            mostrarMensajeError(ex.Message);
            return;
        }
        catch
        {
            mostrarMensajeError("Ocurrió un problema al confirmar el pedido.");
            return;
        }

        lblMensaje.ForeColor = System.Drawing.Color.Red;
        lblMensaje.Text = "Pedido realizado con exito.";

        LimpiarFormulario();
    }

    protected void btnCalcular_Click(object sender, EventArgs e)
    {
        int cantidad = 0;
        try
        {
            cantidad = Convert.ToInt32(txtCantidad.Text);
            if (cantidad <= 0)
            {
                mostrarMensajeError("La cantidad debe ser un numero mayor a cero.");
                return;
            }
        }
        catch (FormatException)
        {
            mostrarMensajeError("La cantidad debe ser un numero entero.");
            return;
        }
        double total = (double)Session["Precio"] * cantidad;
        lblTotal.Text = total.ToString();

        txtCantidad.Enabled = true;
    }

    protected void btnLimpiar_Click(object sender, EventArgs e)
    {
        LimpiarFormulario();
    }

    protected void LimpiarFormulario()
    {
        ddlEspecializacion.SelectedIndex = 0;
        ddlCasas.Items.Clear();
        ddlCasas.Items.Insert(0, "Seleccione una casa");
        ddlCasas.Enabled = false;
        ddlPlatos.Items.Clear();
        ddlPlatos.Items.Insert(0, "Seleccione un Plato");
        ddlPlatos.Enabled = false;
        mostrarPlato.Visible = false;
        txtCantidad.Text = string.Empty;
        txtCantidad.Enabled = false;
        lblTotal.Text = string.Empty;
        btnCalcular.Enabled = false;
    }
}