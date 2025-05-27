<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProductDetails_WF.aspx.cs" Inherits="Practical_no_3_documentation.ProductDetails_WF" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="14pt" Text="Database Access using Entity Framework"></asp:Label>
            <br />
        </div>
        <asp:Label ID="Label2" runat="server" Text="Enter product id: "></asp:Label>
&nbsp;&nbsp;
        <asp:TextBox ID="pid" runat="server"></asp:TextBox>
        <br />
        Enter product name:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="pname" runat="server"></asp:TextBox>
        <br />
        Enter product price:
        <asp:TextBox ID="pprice" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:GridView ID="table1" runat="server">
        </asp:GridView>
        <br />
        <asp:Label ID="lblMessage" runat="server"></asp:Label>
        <br />
        <br />
        <asp:Button ID="add" runat="server" Text="ADD" OnClick="add_Click"/>
&nbsp;
        <asp:Button ID="delete" runat="server" Text="DELETE" OnClick="delete_Click"/>
&nbsp;
        <asp:Button ID="update" runat="server" Text="UPDATE" OnClick="update_Click"/>
&nbsp;
        <asp:Button ID="search" runat="server" Text="SEARCH" OnClick="search_Click"/>
&nbsp;
        &nbsp;
        <br />
        <br />
&nbsp;
    </form>
</body>
</html>
