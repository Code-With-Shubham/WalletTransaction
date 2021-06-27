<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PayElectricBill.aspx.cs" Inherits="PayElectricBill" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="bootstrap.min.css" />
</head>
<body>
    <form id="form1" runat="server">
       <div class="container">
            <br /><br />
            <h2>&nbsp; Electric Bill Payment</h2>
            <br /><hr />
            <br />
            <br />
            <div class="container">
                <br />
                <table>
                     <tr>
                        <td>Customer ID</td>
                        <td>
                            <asp:TextBox ID="TextBox2" runat="server" CssClass="form-control"></asp:TextBox>
                        </td>
                    </tr>
                     <tr>
                        <td>Amount</td>
                        <td>
                            <asp:TextBox ID="TextBox3" runat="server" CssClass="form-control"></asp:TextBox>
                        </td>
                    </tr>
                     <tr>
                        <td></td>
                        <td>
                            <asp:Button ID="Button1" runat="server" Text="Pay"  CssClass="auto-style1" OnClick="bill" Width="118px"/></td>
                    </tr>
                </table>
            </div>
            <br />
            <br />
            <asp:Label ID="Label1" runat="server" font-size="Larger"></asp:Label><br />
            <asp:Label ID="Label2" runat="server" font-size="Larger"></asp:Label>
        </div>
    </form>
</body>
</html>
