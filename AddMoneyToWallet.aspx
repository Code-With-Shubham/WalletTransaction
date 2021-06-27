<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddMoneyToWallet.aspx.cs" Inherits="AddMoneyToWallet" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="bootstrap.min.css" />
    <style type="text/css">
        .auto-style1 {
            display: block;
            height: calc(1.5em + .75rem + 2px);
            font-size: 1rem;
            font-weight: 400;
            line-height: 1.5;
            color: #495057;
            background-clip: padding-box;
            border-radius: .25rem;
            transition: none;
            border: 1px solid #ced4da;
            background-color: #fff;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <br /><br />
            <h2>Add Money</h2>
            <br />
            <asp:Label ID="Label2" runat="server" ></asp:Label>
            <asp:Label ID="Label3" runat="server" ></asp:Label>
            <hr /><br />
            <div class="container">
                <table>
                    
                    <tr>
                        <td>Amount</td>
                        <td>
                            <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control"></asp:TextBox>
                        </td>
                     </tr>
                      <tr>
                        <td></td>
                        <td>
                            <asp:Button ID="Button1" runat="server" Text="Add" OnClick="addmoney" CssClass="auto-style1" />
                        </td>
                    </tr>
                </table>

            </div>
            <asp:Label ID="Label1" runat="server" Font-Size="Larger"></asp:Label>
        </div>
    </form>
</body>
</html>
