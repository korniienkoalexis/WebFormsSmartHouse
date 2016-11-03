<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebFormsSmartHouse.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Фигуры</title>
    <style>
        .device-div {
            border: 1px solid black;
            float: left;
            margin: 3px;
            padding: 3px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:DropDownList ID="dropDownFiguresList" runat="server">
            <asp:ListItem>Radio</asp:ListItem>
            <asp:ListItem>TV</asp:ListItem>
            <asp:ListItem>Refrigitator</asp:ListItem>
            <asp:ListItem>Conditioner</asp:ListItem>
            <asp:ListItem>MisicCenter</asp:ListItem>
        </asp:DropDownList>
        <asp:Button ID="addButton" runat="server" Text="Добавить" OnClick="AddDeviceButtonClick" />
        <br />
        <br />
        Name:<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <asp:Panel ID="figuresPanel" runat="server">
            </asp:Panel>
        <br />
        <br />
        <br />
    
    </div>
    </form>
</body>
</html>
