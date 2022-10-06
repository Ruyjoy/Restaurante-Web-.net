<%@ Page Title="" Language="C#" MasterPageFile="~/Administrador.master" AutoEventWireup="true" CodeFile="ListadoPedidos.aspx.cs" Inherits="ListadoPedidos" %>

<%@ Register src="CalendarioPersonalizado.ascx" tagname="CalendarioPersonalizado" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <p>
        <br />
    </p>
    <p>
    </p>
    <p>
        <uc1:CalendarioPersonalizado ID="CalendarioPersonalizado1" runat="server" />
        <asp:Button ID="btnBuscar" runat="server" onclick="btnBuscar_Click" 
            Text="Buscar" />
    </p>
    <p>
    </p>
    <p>
        <asp:GridView ID="gvPedidos" runat="server" EnableViewState="False">
        </asp:GridView>
    </p>
    <p>
        <asp:Label ID="lblMensaje" runat="server"></asp:Label>
    </p>
    <p>
        <asp:Button ID="btnExportar" runat="server" Text="Exportar Xml" 
            onclick="btnExportar_Click" />
    </p>
    <p>
    </p>
    <p>
    </p>
    <p>
    </p>
</asp:Content>

