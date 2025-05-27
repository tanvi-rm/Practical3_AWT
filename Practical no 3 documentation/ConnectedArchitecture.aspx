Design an ASP.NET web Applications using Connected Database architecture to add, update, delete
and search customer information from database table. Consider following schema for customer_info
table customer_info(cid primary key, cname, cadd)


<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ConnectedArchitecture.aspx.cs" Inherits="Practical_no_3_documentation.ConnectedArchitecture" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            font-size: x-large;
            text-align: center;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="auto-style1">
            <strong>CONNECTED ARCHITECTURE<br />
            </strong>
        </div>
        <p>
            Enter customer Id:
            <asp:TextBox ID="cidt" runat="server"></asp:TextBox>
        </p>
        <p>
            Enter customer name:
            <asp:TextBox ID="cnamet" runat="server"></asp:TextBox>
        </p>
        <p>
            Enter customer address:
            <asp:TextBox ID="caddt" runat="server"></asp:TextBox>
        </p>
        <p>
            <asp:GridView ID="custTable" runat="server">
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
