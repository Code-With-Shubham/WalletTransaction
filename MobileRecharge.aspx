<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MobileRecharge.aspx.cs" Inherits="MobileRecharge" %>

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
            <br /><br />
            <h2>&nbsp; Mobile Recharge</h2>
            <br /><hr />
            <br />
            <br />
            <div class="container">
                <br />
                <table>
                    <tr>
                        <td>Telicom Company</td>
                        <td>
                            <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control"></asp:TextBox>
                        </td>
                    </tr>
                     <tr>
                        <td>Mobile</td>
                        <td>
                            <asp:TextBox ID="TextBox2" runat="server" CssClass="form-control"></asp:TextBox>
                        </td>
                    </tr>
                     <tr>
                        <td>Recharge Amount</td>
                        <td>
                            <asp:TextBox ID="TextBox3" runat="server" CssClass="form-control"></asp:TextBox>
                        </td>
                    </tr>
                     <tr>
                        <td></td>
                        <td>
                            <asp:Button ID="Button1" runat="server" Text="Recharge"  CssClass="auto-style1" OnClick="Button1_Click" Width="189px"/></td>
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
