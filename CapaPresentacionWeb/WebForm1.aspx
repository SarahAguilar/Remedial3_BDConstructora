<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="CapaPresentacionWeb.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Materiales<br />
            <br />
            <asp:Button ID="btnAgregaMaterial" runat="server" OnClick="btnAgregaMaterial_Click" Text="Agregar Material" />
            <br />
            <asp:GridView ID="gridMaterial" runat="server">
            </asp:GridView>
            <br />
            <br />
            <br />
            OBRAS<br />
            <br />
            <asp:Button ID="btnAddObra" runat="server" OnClick="btnAddObra_Click" Text="Agregar Obra" />
            <br />
            <asp:GridView ID="griObras" runat="server" OnSelectedIndexChanged="griObras_SelectedIndexChanged">
                <Columns>
                    <asp:CommandField SelectText="Eliminar" ShowSelectButton="True" />
                </Columns>
            </asp:GridView>
            <asp:TextBox ID="txtBorraObra" runat="server" Enabled="False" Width="445px"></asp:TextBox>
            <br />
            <br />
            Provedores Material Obra<br />
            <br />
            <asp:Button ID="btnAgregaProvMatObra" runat="server" OnClick="btnAgregaProvMatObra_Click" Text="Agregar Registro" />
            <br />
            <asp:GridView ID="gridProvMatObra" runat="server" OnSelectedIndexChanged="gridProvMatObra_SelectedIndexChanged">
                <Columns>
                    <asp:CommandField ShowSelectButton="True" />
                </Columns>
            </asp:GridView>
            <br />
            Dueños de obras<br />
            (Al seleccionar un dueño se mostran sus obras correspondientes)<br />
            <asp:ListBox ID="ListBox1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ListBox1_SelectedIndexChanged" Width="227px"></asp:ListBox>
            <br />
            <asp:GridView ID="GridView1" runat="server" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
            </asp:GridView>
            <br />
        </div>
    </form>
</body>
</html>
