using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Logica;
using EntidadesCompartidas;


public partial class EntregaPedido : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ((LinkButton)Master.FindControl("lbtnEntregaPedido")).Enabled = false;

        List<Pedido> pedidos = new List<Pedido>();
        List<MostrarPedido2> mostrarPedidos = new List<MostrarPedido2>();

        try
        {
            Usuario usuario = (Usuario)Session["Usuario"];

            pedidos = LogicaPedido.ListarPendientes();
            Session["Pedidos"] = pedidos;

            for (int i = 0; i < pedidos.Count; i++)
            {
                MostrarPedido2 m = new MostrarPedido2(pedidos[i].Fecha, pedidos[i].Plato.Nombre, pedidos[i].Plato.Casa.Nombre, pedidos[i].Plato.Casa.Rut, pedidos[i].Cliente.NombreCompleto, pedidos[i].Cliente.Direccion, pedidos[i].Numero, pedidos[i].Cantidad, pedidos[i].Plato.Precio);
                mostrarPedidos.Add(m);
            }

            gvPedidos.DataSource = mostrarPedidos;
            gvPedidos.DataBind();
        }
        catch (ExcepcionPersonalizada ex)
        {
            mostrarMensajeError(ex.Message);
            return;
        }
        catch (Exception ex)
        {
            mostrarMensajeError("Ocurrio un error al listar los pedidos.");
            return;
        }
    }

    protected void gvPedidos_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            int numero = Convert.ToInt32(gvPedidos.Rows[gvPedidos.SelectedIndex].Cells[1].Text);

            Pedido pedido = LogicaPedido.Buscar(numero);

            pedido.Entregado = true;

            LogicaPedido.Modificar(pedido);
        }
        catch (ExcepcionPersonalizada ex)
        {
            mostrarMensajeError(ex.Message);
            return;
        }
        catch (Exception ex)
        {
            mostrarMensajeError("Ocurrio un error al entregar el pedido.");
            return;
        }

        List<Pedido> pedidos = new List<Pedido>();
        List<MostrarPedido2> mostrarPedidos = new List<MostrarPedido2>();

        try
        {
            Usuario usuario = (Usuario)Session["Usuario"];

            pedidos = LogicaPedido.ListarPendientes();
            Session["Pedidos"] = pedidos;

            for (int i = 0; i < pedidos.Count; i++)
            {
                MostrarPedido2 m = new MostrarPedido2(pedidos[i].Fecha, pedidos[i].Plato.Nombre, pedidos[i].Plato.Casa.Nombre, pedidos[i].Plato.Casa.Rut, pedidos[i].Cliente.NombreCompleto, pedidos[i].Cliente.Direccion, pedidos[i].Numero, pedidos[i].Cantidad, pedidos[i].Plato.Precio);
                mostrarPedidos.Add(m);
            }

            gvPedidos.DataSource = mostrarPedidos;
            gvPedidos.DataBind();
        }
        catch (ExcepcionPersonalizada ex)
        {
            mostrarMensajeError(ex.Message);
            return;
        }
        catch (Exception ex)
        {
            mostrarMensajeError("Ocurrio un error al listar los pedidos.");
            return;
        }
    }

    protected void mostrarMensajeError(string mensajeError)
    {
        lblMensaje.ForeColor = System.Drawing.Color.Red;
        lblMensaje.Text = "¡ERROR! " + mensajeError;
    }
}