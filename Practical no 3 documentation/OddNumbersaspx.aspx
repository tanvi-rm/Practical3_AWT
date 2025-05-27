<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OddNumbersaspx.aspx.cs" Inherits="Practical_no_3_documentation.OddNumbersaspx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Find Odd Numbers from Array using LINQ</h2>
            <asp:Label ID="Label1" runat="server" Text="Enter numbers (comma-separated): "></asp:Label>
            <asp:TextBox ID="txtNumbers" runat="server" Width="300px"></asp:TextBox>
            <asp:Button ID="btnFindOdd" runat="server" Text="Find Odd Numbers" OnClick="btnFindOdd_Click" />
            <br /><br />
            <asp:Label ID="lblResult" runat="server" Font-Bold="true" ForeColor="Green"></asp:Label>
        </div>
    </form>
</body>
</html>
