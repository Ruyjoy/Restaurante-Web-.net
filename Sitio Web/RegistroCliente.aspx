<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RegistroCliente.aspx.cs" Inherits="RegistroCliente" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <style type="text/css">

        .style4
        {
            font-size: xx-large;
        }
        

        .style1
        {
            width: 161px;
        }
        .style6
        {
            font-size: large;
            font-weight: 700;
        }
        .style3
        {
            width: 49px;
            font-size: large;
            font-weight: 700;
        }
        .style7
        {
            width: 161px;
            height: 65px;
        }
        </style>
</head>
<body>
    <form id="form1" runat="server">
   
      <table style="font-family:Arial">
    <tr>
        <td colspan="2" style="width:800px; height:80px; background-color:#99FFCC; 
            text-align:center">
            <h1 style="background-color: #FFFFFF">
                <span class="style4">Registro de Clientes&nbsp; </span>
                <img alt="" class="style7" src="Logo/Logo/Logo.png" /></h1>
        </td>
    </tr>
    <tr>

        <td style="height:500px; background-color:#99CCFF; width:650px">
               
            <table style="width:100%; margin-right: 0px;">
                <tr>
                    <td class="style1">
                        Nombre Completo:</td>
                    <td class="style6">
                        <asp:TextBox ID="txtNombre" runat="server" style="background-color: #CCFFCC"></asp:TextBox>
                    </td>
                    <td class="style3">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="style1">
                        Ingrese Cedula:
                    </td>
                    <td class="style6">
                        <asp:TextBox ID="txtCedula" runat="server" style="background-color: #CCFFCC"></asp:TextBox>
                    </td>
                    <td class="style3">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="style1">
                        &nbsp;</td>
                    <td class="style6">
                        &nbsp;</td>
                    <td class="style3">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="style1">
                        Nombre de Logueo:</td>
                    <td class="style6">
                        <asp:TextBox ID="txtLogueo" runat="server" style="background-color: #CCFFCC"></asp:TextBox>
                    </td>
                    <td class="style3">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="style1">
                        Contraseña:</td>
                    <td class="style6">
                        <asp:TextBox ID="txtConstraseña" runat="server" 
                            style="background-color: #CCFFCC" TextMode="Password"></asp:TextBox>
                    </td>
                    <td class="style3">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="style1">
                        Repita Contraseña:</td>
                    <td class="style6">
                        <asp:TextBox ID="txtRepetir" runat="server" style="background-color: #CCFFCC" 
                            TextMode="Password"></asp:TextBox>
                    </td>
                    <td class="style3">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="style1">
                        &nbsp;Nº Tarjeta de credito:</td>
                    <td class="style6">
                        <asp:TextBox ID="txtTarjeta" runat="server" style="background-color: #CCFFCC"></asp:TextBox>
                    </td>
                    <td class="style3">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="style1">
                        Direccion:</td>
                    <td class="style6">
                        <asp:TextBox ID="txtDireccion" runat="server" style="background-color: #CCFFCC"></asp:TextBox>
                    </td>
                    <td class="style3">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="style1">
                        &nbsp;</td>
                    <td class="style6">
                        &nbsp;</td>
                    <td class="style3">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="style1">
                        <asp:Button ID="btnCrear" runat="server" onclick="btnCrear_Click" 
                            Text="Crear Cuenta" Width="110px" />
                        &nbsp;</td>
                    <td class="style6">
                        <asp:Button ID="btnLimpiar" runat="server" onclick="btnLimpiar_Click" 
                            Text="Limpiar Formulario" Width="130px" />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    </td>
                    <td class="style3">
                        &nbsp;</td>
                </tr>
            </table>
            <br />
            <asp:LinkButton ID="lbtnvolver" runat="server" PostBackUrl="~/Default.aspx">Volver...</asp:LinkButton>
            <br />
            <br />
            <asp:Label ID="lblMensaje" runat="server" EnableTheming="False"></asp:Label>
               
        </td>
    </tr>
    <tr>
        <td colspan="2" style="background-color:#3399FF; text-align:center">
            &nbsp;</td>
    </tr>
</table>


    </form>
</body>
</html>
