<%@ Page Title="" Language="C#" MasterPageFile="~/Administrador.master" AutoEventWireup="true" CodeFile="ABMAdministradores.aspx.cs" Inherits="ABMAdministradores" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
       <style type="text/css">



        .style4
        {
            font-size: x-large;
            color: #FF3300;
        }
        .style7
        {
            width: 83px;
        }
        .style9
        {
            width: 217px;
        }
        .style10
        {
            width: 528px;
        }
           .style11
           {
               font-size: x-large;
               color: #006600;
           }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <p>
        <span class="style4">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    </span>
        <span class="style11">ABM de Administradores
    </span>
    
    </p>
    <p>
        &nbsp;</p>
    <p>
        Crear Nuevo&nbsp;
        <span class="style11">Administradores</span><span class="style4">
    </span>
    
    </p>
    <p>
        <table style="width:100%;">
            <tr>
                <td class="style7">
                    Cedula:</td>
                <td class="style9">
                    <asp:TextBox ID="txtCedula" runat="server"></asp:TextBox>
&nbsp;
                    <asp:Button ID="btnBuscar" runat="server" onclick="btnBuscar_Click" 
                        Text="Buscar" Width="63px" />
                </td>
                <td class="style10">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style7">
                    Nombre Completo:</td>
                <td class="style9">
                    <asp:TextBox ID="txtNombre" runat="server" Enabled="False"></asp:TextBox>
                </td>
                <td class="style10">
                    &nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="lblEliminar" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style7">
                    Nombre de Logueo:</td>
                <td class="style9">
                    <asp:TextBox ID="txtNomLogueo" runat="server" Enabled="False"></asp:TextBox>
                </td>
                <td class="style10">
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btnSi" runat="server" onclick="btnSi_Click" Text="Si" 
                        Width="60px" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btnNo" runat="server" onclick="btnNo_Click" Text="No" 
                        Width="60px" />
                </td>
            </tr>
            <tr>
                <td class="style7">
                    Contraseña:</td>
                <td class="style9">
                    <asp:TextBox ID="txtContraceña" runat="server" Enabled="False" 
                        TextMode="Password"></asp:TextBox>
                </td>
                <td class="style10">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style7">
                    Repita Contraseña:</td>
                <td class="style9">
                    <asp:TextBox ID="txtRepita" runat="server" Enabled="False" TextMode="Password"></asp:TextBox>
                </td>
                <td class="style10">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style7">
                    Cargo:</td>
                <td class="style9">
                    <asp:TextBox ID="txtCargo" runat="server" Enabled="False"></asp:TextBox>
                </td>
                <td class="style10">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style7">
                    &nbsp;</td>
                <td class="style9">
                    &nbsp;</td>
                <td class="style10">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style7">
                    &nbsp;</td>
                <td class="style9">
                    <asp:Button ID="btnCrearCuenta" runat="server" Enabled="False" 
                        Text="Crear Cuenta" Width="96px" onclick="btnCrearCuenta_Click" />
&nbsp;
                    <asp:Button ID="btnModificar" runat="server" Enabled="False" Height="29px" 
                        Text="Modificar" Width="96px" onclick="btnModificar_Click" />
                </td>
                <td class="style10">
&nbsp;
                    <asp:Button ID="btnLimpiar" runat="server" Text="Limpiar Formulario" 
                        Width="125px" onclick="btnLimpiar_Click1" />
                </td>
            </tr>
            <tr>
                <td class="style7">
                    &nbsp;</td>
                <td class="style9">
                    <asp:Label ID="lblMensaje" runat="server" EnableViewState="False"></asp:Label>
                </td>
                <td class="style10">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style7">
                    <asp:Button ID="btnEliminar" runat="server" Text="Eliminar mi cuenta" 
                        Width="125px" onclick="btnEliminar_Click" style="margin-bottom: 17px" />
                </td>
                <td class="style9">
                    &nbsp;</td>
                <td class="style10">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style7">
                    &nbsp;</td>
                <td class="style9">
                    &nbsp;</td>
                <td class="style10">
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
    
    </p>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
</asp:Content>
