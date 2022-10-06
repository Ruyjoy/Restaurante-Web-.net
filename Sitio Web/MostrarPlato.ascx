<%@ Control Language="C#" AutoEventWireup="true" CodeFile="MostrarPlato.ascx.cs" Inherits="MostrarPlato" %>

<span <%--style="margin: 5px; padding: 5px; border: solid 1px #CCCCCC; background-color: #EEEEEE;" id="mostrarPlato"--%>>
    
    <asp:Label ID="lblNombre" runat="server" Text="" style="font-size: x-large"></asp:Label>
    <br />
    <br />
    Casa de Comida: 
    <asp:Label ID="lblNombreCasa" runat="server" Text=""></asp:Label>
    &nbsp;
    Rut:
    <asp:Label ID="lblRut" runat="server" Text=""></asp:Label>
    <br />
    <br />
    ID del Plato:
    <asp:Label ID="lblId" runat="server" Text=""></asp:Label>
    &nbsp;
    Precio:
    <asp:Label ID="lblPrecio" runat="server" Text=""></asp:Label>
    <br />
    <asp:Image ID="imgFoto" runat="server" Height="159px" Width="298px" />
</span>