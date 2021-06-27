<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ShowKYCdoc.aspx.cs" Inherits="ShowKYCdoc" %>

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
        .auto-style2 {
            margin-top: 1px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <br /><br />
            <h2>Search KYC Documents</h2>
            <br /><hr /><br />
            <div>
                <table>
                    <tr>
                        <td>UserID</td>
                        <td>
                            <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td></td>
                        <td>
                            <asp:Button ID="Button1" runat="server" Text="Search"  CssClass="auto-style1"  Width="140px" OnClick="Button1_Click"/></td>
                    </tr>

                </table>
                <div class="container">
                    <br />
                    
                    <br />
                    
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4" CssClass="auto-style2" DataKeyNames="userid" DataSourceID="SqlDataSource1" ForeColor="#333333" GridLines="None" Height="16px" Width="398px">
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:BoundField DataField="userid" HeaderText="userid" ReadOnly="True" SortExpression="userid">
                            <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:ImageField DataImageUrlField="Image" HeaderText="Aadhar Card">
                                <ItemStyle CssClass="form-control" ForeColor="#CCCC00" Height="30px" HorizontalAlign="Center" Width="50px" />
                            </asp:ImageField>
                        </Columns>
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
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:SohamGlobalConnectionString %>" SelectCommand="SELECT [userid], [Image] FROM [KYCDocuments] WHERE ([userid] = @userid)">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="TextBox1" DefaultValue="na" Name="userid" PropertyName="Text" Type="String" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                    <br />
                </div>
            </div>

        </div>
    </form>
</body>
</html>
