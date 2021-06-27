<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RecoverPass.aspx.cs" Inherits="RecoverPass" %>

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
            <h2>Recover Password Form</h2>
            <br /><hr /><br />
            <div class="container">
                <table>
                    <tr>
                        <td>Userid</td>
                        <td>
                            <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td>Security Quetions</td>
                        <td>
                            <asp:DropDownList ID="DropDownList1" runat="server" CssClass="form-control">
                            <asp:ListItem>What was the name of your first school?</asp:ListItem>
                            <asp:ListItem>Which is your favorite color?</asp:ListItem>
                            <asp:ListItem>What is your pet name?</asp:ListItem>
                        </asp:DropDownList>
                        </td>
                    </tr>
                     <tr>
                        <td>Answer</td>
                        <td>
                            <asp:TextBox ID="TextBox3" runat="server" CssClass="form-control"></asp:TextBox>
                        </td>
                    </tr>
                     <tr>
                        <td></td>
                        <td>
                            <asp:Button ID="Button1" runat="server" Text="Recover" OnClick="recover" />
                        </td>
                    </tr>
                </table>
                <br /><br />
                <asp:Label ID="Label1" runat="server" Font-Size="Larger" ForeColor="Green"></asp:Label>
               <br /><hr /><br /><br />
                &copy;SohamGlobal.com<br />Developed in Microsoft.Net
            </div>
        </div>
    </form>
</body>
</html>
