<%@ Page Title="" Language="C#" MasterPageFile="~/Administrador.master" AutoEventWireup="true" CodeFile="ABMCasaComida.aspx.cs" Inherits="ABMCasaComida" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
   <style type="text/css">

        .style56
        {
            width: 157px;
            text-align: center;
            height: 35px;
        }
        .style11
        {
            font-size: small;
        }
        .style57
        {
            width: 517px;
            height: 35px;
        }
        .style40
        {
            height: 26px;
            text-align: center;
            width: 157px;
        }
        .style29
        {
            height: 26px;
            width: 517px;
        }
        .style60
        {
            height: 50px;
            text-align: center;
            width: 157px;
        }
        .style61
        {
            width: 517px;
            height: 50px;
            text-align: center;
        }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="lblMensaje" runat="server" EnableViewState="False" 
        ForeColor="Red"> </asp:Label>
            <br />
    <br />
    <br />
    <table align="center" border="1" style="width:60%;">
        <tr>
            <td class="style56">
                <span class="style11"><strong>Rut :</strong></span><br />
            </td>
            <td class="style57">
                <asp:TextBox ID="txtRut" runat="server" Height="25px" 
                    style="font-size: small; color: #0066FF" Width="300px"></asp:TextBox>
                &nbsp;&nbsp;
                <asp:Button ID="btnBuscar" runat="server" Height="30px" 
                    onclick="btnBuscar_Click" style="text-align: center" Text="BUSCAR " 
                    Width="90px" />
            </td>
        </tr>
        <tr>
            <td class="style56">
                <span class="style11"><strong>Nombre&nbsp; :</strong></span></td>
            <td class="style57">
                <asp:TextBox ID="txtNombre" runat="server" Enabled="False" Height="25px" 
                    style="font-size: small; color: #0066FF" Width="300px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style56">
                Espe<span class="style11"><strong>cializacion :</strong></span><br 
                    class="style11" />
            </td>
            <td class="style57">
                <asp:DropDownList ID="ddlEspecializacion" runat="server" Enabled="False">
                    <asp:ListItem Selected="True" Value="Pizzeria">Pizzeria</asp:ListItem>
                    <asp:ListItem Value="Parrilla">Parrilla</asp:ListItem>
                    <asp:ListItem Value="Minutas">Minutas</asp:ListItem>
                    <asp:ListItem Value="Internacional">Internacional</asp:ListItem>
                    <asp:ListItem Value="Vegetariano">Vegetariano</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="style40">
            </td>
            <td class="style29">
            </td>
        </tr>
        <tr>
            <td class="style60">
            </td>
            <td class="style61">
                <asp:Button ID="btnAgregar" runat="server" Enabled="False" Height="30px" 
                    onclick="btnAgregar_Click" style="text-align: center" Text="Agregar" 
                    Width="90px" />
                &nbsp;<asp:Button ID="btnModificar" runat="server" Enabled="False" Height="30px" 
                    onclick="btnModificar_Click" style="text-align: center" Text="MODIFICAR " 
                    Width="90px" />
                &nbsp;<asp:Button ID="btnEliminar" runat="server" Enabled="False" Height="30px" 
                    onclick="btnEliminar_Click" style="text-align: center" Text="Eliminar" 
                    Width="90px" />
                &nbsp;<asp:Button ID="btnLimpiar" runat="server" Height="30px" 
                    onclick="btnLimpiar_Click" Text="LIMPIAR" Width="90px" />
            </td>
        </tr>
        <tr>
            <td class="style60">
                <asp:Button ID="btnMostrarCasas" runat="server" onclick="btnMostrarCasas_Click" 
                    Text="Mostrar Casas" />
            </td>
            <td class="style61">
                <asp:GridView ID="gvCasas" runat="server" CellPadding="4" ForeColor="#333333" 
                    GridLines="None">
                    <AlternatingRowStyle BackColor="White" />
                    <EditRowStyle BackColor="#7C6F57" />
                    <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#E3EAEB" />
                    <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                    <SortedAscendingCellStyle BackColor="#F8FAFA" />
                    <SortedAscendingHeaderStyle BackColor="#246B61" />
                    <SortedDescendingCellStyle BackColor="#D4DFE1" />
                    <SortedDescendingHeaderStyle BackColor="#15524A" />
                </asp:GridView>
            </td>
        </tr>
        </table>
</asp:Content>

