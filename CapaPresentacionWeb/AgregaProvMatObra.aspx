<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AgregaProvMatObra.aspx.cs" Inherits="CapaPresentacionWeb.AgregaProvMatObra" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Agrega Proveedor Material Obra<br />
            <br />
            <asp:Button ID="RegresarBtn" runat="server" OnClick="RegresarBtn_Click" Text="Regresar" />
            <br />
            <br />
            Recbio<br />
            <asp:TextBox ID="txtRecibio" runat="server"></asp:TextBox>
            <br />
            <br />
            Entrega<br />
            <asp:TextBox ID="txtEntrego" runat="server"></asp:TextBox>
            <br />
            <br />
            Cantidad<br />
            <asp:TextBox ID="txtCantidad" runat="server"></asp:TextBox>
            <br />
            <br />
            Fecha Entregado<br />
            <asp:Calendar ID="FechaEntrego" runat="server"></asp:Calendar>
            <br />
            <br />
            Precio<br />
            <asp:TextBox ID="txtPrecio" runat="server"></asp:TextBox>
            <br />
            <br />
            <br />
            Obra<br />
            <asp:DropDownList ID="dropObra" runat="server" AutoPostBack="True" OnSelectedIndexChanged="dropObra_SelectedIndexChanged">
            </asp:DropDownList>
            <br />
            <br />
            <br />
            Material<br />
            <asp:DropDownList ID="dropMaterial" runat="server" AutoPostBack="True" OnSelectedIndexChanged="dropMaterial_SelectedIndexChanged">
            </asp:DropDownList>
            <br />
            <br />
            Proveedor<br />
            <asp:DropDownList ID="dropProveedor" runat="server" AutoPostBack="True" OnSelectedIndexChanged="dropProveedor_SelectedIndexChanged">
            </asp:DropDownList>
            <br />
            <br />
            <asp:Button ID="btnAdd" runat="server" OnClick="btnAdd_Click" Text="Agregar" />
            <br />
            <br />
            <asp:TextBox ID="TextBox1" runat="server" Enabled="False"></asp:TextBox>
            <br />
        </div>
    </form>
</body>
</html>
