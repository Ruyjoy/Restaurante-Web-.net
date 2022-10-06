<%@ Page Title="" Language="C#" MasterPageFile="~/Administrador.master" AutoEventWireup="true" CodeFile="EntregaPedido.aspx.cs" Inherits="EntregaPedido" %>

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
        width: 89px;
    }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <p>
        <span class="style1">Entrega de Pedido</span></p>
    <p>
        &nbsp;</p>
        <asp:GridView ID="gvPedidos" runat="server" 
            onselectedindexchanged="gvPedidos_SelectedIndexChanged" 
        EnableViewState="False">
            <Columns>
                <asp:CommandField  ButtonType="Button" ShowSelectButton="True" 
                    SelectText="Entregar" />
            </Columns>
        </asp:GridView>
    <p>
        &nbsp;</p>
    <p>
        <asp:Label ID="lblMensaje" runat="server"></asp:Label>
    </p>
    <p>
        &nbsp;</p>
</asp:Content>

