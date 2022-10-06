<%@ Page Title="" Language="C#" MasterPageFile="~/Cliente.master" AutoEventWireup="true" CodeFile="ListadoPedidosPendientes.aspx.cs" Inherits="ListadoPedidosPendientes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">

        .style1
        {
            font-size: xx-large;
        }
    .style2
    {
        width: 259px;
    }
    .style3
    {
            width: 94px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <p>
        <span class="style1">Lista de Pedidos Pendientes</span><br class="style1" />
    </p>
    <p>
        <asp:GridView ID="gvPedidos" runat="server" 
            onselectedindexchanged="gvPedidos_SelectedIndexChanged">
            <Columns>
                <asp:CommandField ButtonType="Button" ShowSelectButton="True" />
            </Columns>
        </asp:GridView>
    </p>
    <p>
        <table style="width:100%;">
            <tr>
                <td class="style2">
                    &nbsp;<asp:Label ID="lblTexCasa" runat="server" EnableViewState="False" 
                        Text="Casa de Comida: " Visible="False"></asp:Label>
&nbsp;
                    <asp:Label ID="lblCasa" runat="server"></asp:Label>
                </td>
                <td class="style3">
                    &nbsp;<asp:Label ID="lblTexRut" runat="server" EnableViewState="False" 
                        Text="Rut: " Visible="False"></asp:Label>
&nbsp;<asp:Label ID="LblRut" runat="server"></asp:Label>
                </td>
                <td>
                    &nbsp;<asp:Label ID="lblTexEspecializacion" runat="server" 
                        EnableViewState="False" Text="Especializacion: " Visible="False"></asp:Label>
&nbsp;<asp:Label ID="lblEspecializacion" runat="server"></asp:Label>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style2">
                    &nbsp;<asp:Label ID="lblTexPlato" runat="server" EnableViewState="False" 
                        Text="Plato: " Visible="False"></asp:Label>
&nbsp;<asp:Label ID="lblPlato" runat="server"></asp:Label>
                </td>
                <td id="lblID0" class="style3">
                    &nbsp;<asp:Label ID="lblTexId" runat="server" EnableViewState="False" 
                        Text="Id: " Visible="False"></asp:Label>
&nbsp;<asp:Label ID="lblID" runat="server"></asp:Label>
                </td>
                <td id="lblPrecio0">
                    &nbsp;<asp:Label ID="lblTexPrecio" runat="server" EnableViewState="False" 
                        Text="Precio:" Visible="False"></asp:Label>
&nbsp;<asp:Label ID="lblPrecio" runat="server"></asp:Label>
                </td>
                <td id="lblPrecio1">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style2">
                    &nbsp;<asp:Label ID="lblTexCantidad" runat="server" EnableViewState="False" 
                        Text="Cantidad: " Visible="False"></asp:Label>
&nbsp;<asp:Label ID="lblCantidad" runat="server"></asp:Label>
                </td>
                <td id="lblID1" class="style3">
                    <asp:Label ID="lblTexTotal" runat="server" EnableViewState="False" Text="Total" 
                        Visible="False"></asp:Label>
&nbsp;<asp:Label ID="lblTotal" runat="server"></asp:Label>
                </td>
                <td id="lblPrecio2">
                    &nbsp;</td>
                <td id="lblPrecio3">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style2">
                    <asp:Image ID="imgfoto" runat="server" Height="153px" Width="254px" 
                        EnableViewState="False" Visible="False" />
                </td>
                <td id="lblID1" class="style3">
                    &nbsp;</td>
                <td id="lblPrecio2">
                    &nbsp;</td>
                <td id="lblPrecio3">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style2">
                    &nbsp;</td>
                <td class="style3">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
    </p>
    <p>
        <asp:Label ID="lblMensaje" runat="server"></asp:Label>
    </p>
    <p>
        &nbsp;</p>
</asp:Content>

