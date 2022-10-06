<%@ Page Title="" Language="C#" MasterPageFile="~/Administrador.master" AutoEventWireup="true" CodeFile="ABMPlatos.aspx.cs" Inherits="ABMPlatos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">


        .style56
        {
            width: 209px;
            text-align: center;
            height: 35px;
        }
        .style57
        {
            width: 517px;
            height: 35px;
        }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="lblMensaje" runat="server" EnableViewState="False" 
        ForeColor="Red"> </asp:Label>
            <br />
    <br />
    <table align="center" border="1" style="width:60%;">
        <tr>
            <td class="style56">
                Casa de Comida :</td>
            <td class="style57">
&nbsp;<asp:DropDownList ID="ddlRut" runat="server">
                </asp:DropDownList>
                &nbsp;
                <asp:Button ID="btnMostrar" runat="server" onclick="btnMostrar_Click" 
                    Text="Mostrar Platos" Height="28px" Width="107px" />
            &nbsp;
                <asp:Button ID="btnLimpiar" runat="server" onclick="btnLimpiar_Click" 
                    Text="Limpiar" />
            </td>
        </tr>
        <tr>
            <td class="style56">
                Platos</td>
            <td class="style57">
                <asp:GridView ID="gvPlatos" runat="server" AutoGenerateColumns="False" 
                    BackColor="White" BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" 
                    CellPadding="3" GridLines="Horizontal" PageSize="5">
                    <AlternatingRowStyle BackColor="#F7F7F7" />
                    <Columns>
                        <asp:BoundField DataField="Id" HeaderText="Id" />
                        <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                        <asp:BoundField DataField="Precio" HeaderText="Precio" />
                        <asp:ImageField DataAlternateTextField="Foto" DataImageUrlField="Foto" 
                            HeaderText="Foto">
                        </asp:ImageField>
                    </Columns>
                    <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
                    <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" />
                    <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />
                    <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
                    <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
                    <SortedAscendingCellStyle BackColor="#F4F4FD" />
                    <SortedAscendingHeaderStyle BackColor="#5A4C9D" />
                    <SortedDescendingCellStyle BackColor="#D8D8F0" />
                    <SortedDescendingHeaderStyle BackColor="#3E3277" />
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td class="style56">
                ID Plato</td>
            <td class="style57">
                <asp:TextBox ID="txtId" runat="server" Height="25px" 
                    style="font-size: small; color: #0066FF" Width="154px"></asp:TextBox>
&nbsp;&nbsp;
                <asp:Button ID="btnBuscar" runat="server" Height="30px" 
                    onclick="btnBuscar_Click" style="text-align: center" Text="BUSCAR " 
                    Width="90px" />
            </td>
        </tr>
        <tr>
            <td class="style56">
                Nombre </td>
            <td class="style57">
                <asp:TextBox ID="txtNombre" runat="server" Height="25px" 
                    style="font-size: small; color: #0066FF" Width="157px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style56">
                Precio </td>
            <td class="style57">
                <asp:TextBox ID="txtPrecio" runat="server" Height="25px" 
                    style="font-size: small; color: #0066FF" Width="158px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style56">
                Foto</td>
            <td class="style57">
                <asp:FileUpload ID="fuFoto" runat="server" Width="229px" />
                &nbsp;
                <asp:Button ID="btnMostrar0" runat="server" onclick="btnMostrarFoto_Click" 
                    Text="MostrarFoto" />
                <br />
                <asp:Image ID="ImgFoto" runat="server" EnableViewState="False" Height="113px" 
                    Width="145px" />
            </td>
        </tr>
        <tr>
            <td class="style56">
                &nbsp;</td>
            <td class="style57">
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnAgregar" runat="server" 
                    Height="30px" onclick="btnAgregar_Click" style="text-align: center" 
                    Text="Agregar" Width="90px" />
&nbsp;
                <asp:Button ID="btnModificar" runat="server" Enabled="False" Height="30px" 
                    onclick="btnModificar_Click" style="text-align: center" Text="Modificar" 
                    Width="90px" />
&nbsp;
                <asp:Button ID="btnEliminar" runat="server" Enabled="False" Height="30px" 
                    onclick="btnEliminar_Click" style="text-align: center" Text="Eliminar" 
                    Width="90px" />
&nbsp; </td>
        </tr>
        </table>
</asp:Content>

