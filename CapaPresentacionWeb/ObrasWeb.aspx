<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ObrasWeb.aspx.cs" Inherits="CapaPresentacionWeb.ObrasWeb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Agrega Obra<br />
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click1" Text="Regresar" />
            <br />
            <br />
            Nombre obra:
            <br />
            <asp:TextBox ID="TextBox1" runat="server" Width="193px"></asp:TextBox>
            <br />
            <br />
            Direccion:
            <br />
            <asp:TextBox ID="TextBox2" runat="server" Width="209px"></asp:TextBox>
            <br />
            <br />
            Fecha inicio:
            <br />
            <asp:Calendar ID="fechaIni" runat="server"></asp:Calendar>
            <br />
            <br />
            Fecha termino:
            <br />
            <asp:Calendar ID="fechatermino" runat="server"></asp:Calendar>
            <br />
            <br />
            Dueño: <br />
            <asp:DropDownList ID="DropDownList1" runat="server" Height="16px" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" Width="227px">
            </asp:DropDownList>
            <br />
            <br />
            Encargado:
            <br />
            <br />
            <asp:DropDownList ID="DropDownList2" runat="server" Height="29px" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged" Width="197px">
            </asp:DropDownList>
            <br />
            <br />
            <asp:Button ID="ButtonAgregarObra" runat="server" OnClick="Button1_Click" Text="Agregar obra" />
            <br />
            <asp:TextBox ID="TextBoxStatus" runat="server" Height="22px" Width="389px"></asp:TextBox>
        </div>
    </form>
</body>
</html>
