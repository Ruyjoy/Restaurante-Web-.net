using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Logica;
using EntidadesCompartidas;


public partial class ListadoPedidosPendientes : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ((LinkButton)Master.FindControl("lbtnListado")).Enabled = false;

        List<Pedido> pedidos = new List<Pedido>();
        List<MostrarPedido> mostrarPedidos = new List<MostrarPedido>();
        
        try
        {
            Usuario usuario = (Usuario)Session["Usuario"];

            pedidos = LogicaPedido.ListarPendientes(usuario.Cedula);

            if (pedidos.Count != 0)
            {
                Session["Pedidos"] = pedidos;

                for (int i = 0; i < pedidos.Count; i++)
                {
                    MostrarPedido m = new MostrarPedido(pedidos[i].Fecha, pedidos[i].Plato.Nombre, pedidos[i].Plato.Casa.Nombre, pedidos[i].Numero);
                    mostrarPedidos.Add(m);
                }

                gvPedidos.DataSource = mostrarPedidos;
                gvPedidos.DataBind();
            }
            else
            {
                lblMensaje.Text = "No se encontraron pedios pendientes.";
            }
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

    protected void  gvPedidos_SelectedIndexChanged(object sender, EventArgs e)
    {
        int numero = Convert.ToInt32(gvPedidos.Rows[gvPedidos.SelectedIndex].Cells[4].Text);

        List<Pedido> pedidos = (List<Pedido>)Session["Pedidos"];

        foreach (Pedido p in pedidos)
        {
            if (p.Numero == numero)
            {
                lblTexCasa.Visible = true;
                lblTexRut.Visible = true;
                lblTexEspecializacion.Visible = true;
                lblTexPlato.Visible = true;
                lblTexId.Visible = true;
                lblTexPrecio.Visible = true;
                lblTexCantidad.Visible = true;
                lblTexTotal.Visible = true;

                lblCasa.Text = p.Plato.Casa.Nombre;
                LblRut.Text = p.Plato.Casa.Rut.ToString();
                lblEspecializacion.Text = p.Plato.Casa.Especializacion;
                lblPlato.Text = p.Plato.Nombre;
                lblID.Text = p.Plato.Id.ToString();
                lblPrecio.Text = p.Plato.Precio.ToString();
                imgfoto.Visible = true;
                imgfoto.ImageUrl = p.Plato.Foto;
                lblCantidad.Text = p.Cantidad.ToString();
                lblTotal.Text = (p.Plato.Precio * p.Cantidad).ToString(); ;
            }
        }
    }
}