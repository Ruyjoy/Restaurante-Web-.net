<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            width: 240px;
            height: 101px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <h1>
            <img alt="" class="style1" src="Logo/Logo/Logo.png" /></h1>
        <h2>
            Formulario de Ingreso</h2>
        <table>
            <tr>
                <td>
                    Usuario:</td>
                <td>
                    <asp:TextBox ID="txtNomLogueo" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    Contraseña:</td>
                <td>
                    <asp:TextBox ID="txtContraseña" runat="server" TextMode="Password"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Button ID="btnIngresar" runat="server" OnClick="btnIngresar_Click" 
                        Text="Ingresar" />
                &nbsp;&nbsp;&nbsp;&nbsp;
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:LinkButton ID="lbtnRegistrarse" runat="server" 
                        PostBackUrl="~/RegistroCliente.aspx">Registrarse</asp:LinkButton>
                </td>
            </tr>
        </table>
        <p>
            <asp:Label ID="lblMensaje" runat="server" EnableViewState="false"></asp:Label>
        </p>
    
    </div>
    </form>
</body>
</html>
