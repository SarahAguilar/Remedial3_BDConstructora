<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AgregaMaterial.aspx.cs" Inherits="CapaPresentacionWeb.AgregaMaterial" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Agrega Material<br />
            <asp:Button ID="btnRegresar" runat="server" OnClick="btnRegresar_Click" Text="Regresar" />
            <br />
            <br />
            Descripción<br />
            <asp:TextBox ID="txtDesc" runat="server"></asp:TextBox>
            <br />
            <br />
            Marca<br />
            <asp:TextBox ID="txtMarca" runat="server"></asp:TextBox>
            <br />
            <br />
            Presentación<br />
            <asp:TextBox ID="txtPresentacion" runat="server"></asp:TextBox>
            <br />
            <br />
            <br />
            Tipo material<br />
            <asp:DropDownList ID="dropTipoM" runat="server" AutoPostBack="True" OnSelectedIndexChanged="dropMarcas_SelectedIndexChanged">
                <asp:ListItem Selected="True" Value="0">Seleccione un tipo de material</asp:ListItem>
            </asp:DropDownList>
            <br />
            <br />
            <br />
            <br />
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Agregar" />
            <br />
            <br />
            <asp:TextBox ID="TextBox1" runat="server" Enabled="False"></asp:TextBox>
        </div>
    </form>
</body>
</html>
