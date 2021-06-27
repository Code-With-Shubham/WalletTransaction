<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CheckWalletBalanceByIDUsingWebService.aspx.cs" Inherits="CheckWalletBalanceByIDUsingWebService" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="bootstrap.min.css" />
    <style type="text/css">
        .auto-style1 {
            display: block;
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
            <br />
            <h2>Search Balance</h2>
            <h4>By Using Web Service</h4>
            <br />
            <hr /><br />
            <table>
                <tr>
                    <td>Wallet ID</td>
                    <td>
                        <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control"></asp:TextBox>
                    </td>
                
                   
                    <td>
                        <asp:Button ID="Button1" runat="server" Text="Check Balance" OnClick="Button1_Click"  CssClass="form-control"/></td>
                </tr>
                
            </table>
            <br />
            <div class="container">
                <br />
                <asp:Label ID="Label1" runat="server" font-size="Larger"></asp:Label>
                <br />
            </div>
        </div>
    </form>
</body>
</html>
