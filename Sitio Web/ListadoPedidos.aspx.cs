using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EntidadesCompartidas;
using Logica;
using System.Xml;
using System.Data;

public partial class ListadoPedidos : System.Web.UI.Page
{
    DataSet dsPedidos;

    protected void Page_Load(object sender, EventArgs e)
    {
        ((LinkButton)Master.FindControl("lbtnListadoPedido")).Enabled = false;

        string rutaArchivoXml = Server.MapPath("~/App_Data/ListadoPedidos.xml");
        dsPedidos = new DataSet();
        dsPedidos.ReadXml(rutaArchivoXml);
    }
    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        List<Pedido> pedidos = LogicaPedido.ListarEntregadosPorFecha(CalendarioPersonalizado1.FechaSeleccionada);

        string rutaArchivoXml = Server.MapPath("~/App_Data/ListadoPedidos.xml");

        XmlDocument documentoXml = new XmlDocument();
        documentoXml.Load(rutaArchivoXml);

        documentoXml.DocumentElement.RemoveAllAttributes();
        documentoXml.RemoveAll();

        XmlDeclaration xmlDeclaration = documentoXml.CreateXmlDeclaration("1.0", "UTF-8", null);

        XmlNode Root = documentoXml.DocumentElement;
        documentoXml.InsertBefore(xmlDeclaration, Root);

        XmlNode nodoRaiz = documentoXml.CreateElement("Pedido");
        documentoXml.AppendChild(nodoRaiz);
        documentoXml.Save(rutaArchivoXml);


        foreach (Pedido p in pedidos)
        {
            string hora = p.Fecha.Hour.ToString() + ":" + p.Fecha.Minute.ToString();

            XmlElement elementoPedido = documentoXml.CreateElement("Pedido");

            XmlElement elementoHora = documentoXml.CreateElement("Hora");
            elementoHora.InnerText = hora;
            elementoPedido.AppendChild(elementoHora);

            XmlElement elementoCasaComida = documentoXml.CreateElement("CasaComida");
            elementoCasaComida.InnerText = p.Plato.Casa.Nombre;
            elementoPedido.AppendChild(elementoCasaComida);

            XmlElement elementoPlato = documentoXml.CreateElement("Plato");
            elementoPlato.InnerText = p.Plato.Nombre;
            elementoPedido.AppendChild(elementoPlato);

            XmlElement elementoCantidad = documentoXml.CreateElement("Cantidad");
            elementoCantidad.InnerText = p.Cantidad.ToString();
            elementoPedido.AppendChild(elementoCantidad);

            XmlElement elemetoDireccionEntrega = documentoXml.CreateElement("DireccionEntrega");
            elemetoDireccionEntrega.InnerText = p.Cliente.Direccion;
            elementoPedido.AppendChild(elemetoDireccionEntrega);

            nodoRaiz.AppendChild(elementoPedido);

            documentoXml.Save(rutaArchivoXml);
        }

        dsPedidos = new DataSet();
        dsPedidos.ReadXml(rutaArchivoXml);

        if (dsPedidos.Tables.Count == 1)
        {
            gvPedidos.DataSource = dsPedidos;
            gvPedidos.DataBind();
        }
        else
        {
            lblMensaje.Text = "No Encontro Pedidos en Esta Fecha";
            return;
        }
    }
    protected void btnExportar_Click(object sender, EventArgs e)
    {
        try
        {
            dsPedidos.WriteXml(Server.MapPath("~/PedidosExportados.xml"), XmlWriteMode.WriteSchema);
        }
        catch
        {
            mostrarMensajeError("Se produjo un error al exportar los Pedidos.");

            return;
        }

        Response.Redirect("~/PedidosExportados.xml");
    }
    protected void mostrarMensajeError(string mensajeError)
    {
        lblMensaje.ForeColor = System.Drawing.Color.Red;
        lblMensaje.Text = "¡ERROR! " + mensajeError;
    }
}