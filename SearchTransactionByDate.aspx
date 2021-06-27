<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SearchTransactionByDate.aspx.cs" Inherits="SearchTransactionByDate" %>

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
            <asp:Label ID="Label1" runat="server" font-size="Larger"></asp:Label>
            <br />
            <h2>Search Transaction By Date</h2>
            <br /><hr /><br />
            <div class="container">
                <table>
                    <tr>
                        <td>Date</td>
                        <td>
                            <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control" placeholder="2021-01-01"></asp:TextBox>
                        </td>
                        </tr>
                    <tr>

                        <td></td>
                        <td>
                            <asp:Button ID="Button1" runat="server" Text="Search" OnClick="Button1_Click" CssClass="form-control" />
                            <br />
                            <br />
                        </td>
                    </tr>
                </table>
           
            <div class="container">
                &nbsp;&nbsp;&nbsp;
               <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" Height="202px" Width="335px">
                   <AlternatingRowStyle BackColor="White" />
                   <EditRowStyle BackColor="#2461BF" />
                   <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                   <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                   <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                   <RowStyle BackColor="#EFF3FB" />
                   <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                   <SortedAscendingCellStyle BackColor="#F5F7FB" />
                   <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                   <SortedDescendingCellStyle BackColor="#E9EBEF" />
                   <SortedDescendingHeaderStyle BackColor="#4870BE" />
                </asp:GridView>
               
                <br />
                 </div>

            </div>
             <asp:Label ID="Label2" runat="server" font-size="Larger"></asp:Label>
        </div>
    </form>
</body>
</html>
