<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LINQtoSQL.aspx.cs" Inherits="Practical_no_3_documentation.LINQtoSQL" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <p>
            Enter Employee Id:
            <asp:TextBox ID="eidt" runat="server"></asp:TextBox>
        </p>
        <p>
            Enter Employee name: <asp:TextBox ID="enamet" runat="server"></asp:TextBox>
        </p>
        <p>
            Enter Employee designation: <asp:TextBox ID="edest" runat="server"></asp:TextBox>
        </p>
        <p>
            Enter Employee salary:
            <asp:TextBox ID="esalt" runat="server"></asp:TextBox>
        </p>
        <p>
            <asp:GridView ID="empTable" runat="server">
            </asp:GridView>
        </p>
        <p>
            <asp:Label ID="lbl1" runat="server"></asp:Label>
        </p>
        <p>
            <asp:Button ID="addb" runat="server" OnClick="addb_Click" Text="ADD" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="updateb" runat="server" Text="UPDATE" OnClick="updateb_Click" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="deleteb" runat="server" Text="DELETE" OnClick="deleteb_Click" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="searchb" runat="server" Text="SEARCH" OnClick="searchb_Click" />
        </p>
        <p>
            &nbsp;</p>
    </form>
</body>
</html>
