<%@ Page Title="" Language="C#" MasterPageFile="~/Cliente.master" AutoEventWireup="true" CodeFile="RealizarPedido.aspx.cs" Inherits="RelaizarPedido" %><%@ Register src="MostrarPlato.ascx" tagname="MostrarPlato" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style1
        {
            font-size: xx-large;
        }
        .style2
        {
            text-align: center;
        }
        .style3
        {
            width: 170px;
        }
        .style4
        {
            width: 152px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <p class="style2">
        <span class="style1">Realizar un pedido</span></p>
    <p class="style2">
        <br />
    <asp:Label ID="lblMensaje" runat="server" EnableViewState="False"></asp:Label>
    </p>
    <p>
        <table style="width: 100%;">
            <tr>
                <td class="style3">
                    Especializaciones</td>
                <td class="style4">
                    Casas de Comidas</td>
                <td>
                    Platos</td>
            </tr>
            <tr>
                <td class="style3">
                    <asp:DropDownList ID="ddlEspecializacion" runat="server" AutoPostBack="True" 
                        onselectedindexchanged="ddlEspecializacion_SelectedIndexChanged">
                        <asp:ListItem Value="0">Seleccione una Especializacion</asp:ListItem>
                        <asp:ListItem Value="Pizzeria">Pizzeria</asp:ListItem>
                        <asp:ListItem Value="Parilla">Parrilla</asp:ListItem>
                        <asp:ListItem Value="Minutas">Minutas</asp:ListItem>
                        <asp:ListItem Value="Internacional">Internacional</asp:ListItem>
                        <asp:ListItem Value="Vegetariano">Vegetariano</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td class="style4">
                    <asp:DropDownList ID="ddlCasas" runat="server" AutoPostBack="True" 
                        Enabled="False" onselectedindexchanged="ddlCasas_SelectedIndexChanged">
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:DropDownList ID="ddlPlatos" runat="server" AutoPostBack="True" 
                        Enabled="False" onselectedindexchanged="ddlPlatos_SelectedIndexChanged">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="style3">
                    &nbsp;</td>
                <td class="style4">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
    </p>
    <p>
        <uc1:MostrarPlato ID="mostrarPlato" runat="server" EnableViewState="True" 
            Visible="False" />
    </p>
    <p>
        Ingrese la cantidad:
        <asp:TextBox ID="txtCantidad" runat="server" Enabled="False" 
            EnableViewState="False"></asp:TextBox>
    </p>
    <p>
    &nbsp;<asp:Button ID="btnCalcular" runat="server" Enabled="False" 
            onclick="btnCalcular_Click" Text="Calcular Total" />
&nbsp;&nbsp;
        <asp:Label ID="lblTotal" runat="server" EnableViewState="False"></asp:Label>
    </p>
    <p>
        <asp:Button ID="btnConfirmar" runat="server" onclick="btnConfirmar_Click" 
            Text="Confirmar Pedido" Width="160px" />
&nbsp;
        <asp:Button ID="btnLimpiar" runat="server" onclick="btnLimpiar_Click" 
            Text="Limpiar Formulario" Width="160px" />
    </p>
    <p>
    </p>
</asp:Content>

