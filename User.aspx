<%@ Page Language="C#" AutoEventWireup="true" CodeFile="User.aspx.cs" Inherits="User" %>

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
            <header>
                <h4 style="color:darkblue">WelCome
                    
                </h4>
                <asp:Label ID="Label1" runat="server" Font-Size="Larger" ForeColor="#000066"></asp:Label>
            
            </header>
            <br />
            Upload Profile Picture&nbsp;&nbsp; <asp:FileUpload ID="FileUpload1" runat="server" Height="33px" /><asp:Button ID="Button1" runat="server" Text="Upload" OnClick="Button1_Click" />
            &nbsp;&nbsp;
            <br />
            <br />
            <asp:Label ID="Label2" runat="server" Font-Size="Larger"></asp:Label>
            <br />
            <br />
            <div class="container">
                
                <a href="KYCDoc.aspx">KYC Documents</a>&nbsp;&nbsp;&nbsp; ||
                <a href="AddMoneyToWallet.aspx">Add Money To Wallet</a>&nbsp; ||
                <a href="TransferMoney.aspx">Transfer Money</a> ||
                <a href="MobileRecharge.aspx">Mobile Recharge</a> ||
                <a href="PayElectricBill.aspx">Pay Electric Bill</a> ||<br />
                <a href="FastTag.aspx">Fast Tag Payment</a> ||
                <a href="ShowTransactionLog.aspx">Show Transaction Log </a>||
                <a href="SearchTransactionByDate.aspx">Search Transaction Date Wise</a> ||
                <a href="changepassword.aspx">Change Password</a> || 
                <a href="Logout.aspx">Logout</a>
                <br />
                <br />
                    <div class="align-top">
                    &nbsp;<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="walletid" DataSourceID="SqlDataSource1" ForeColor="#333333" GridLines="None" Height="16px" Width="16px">
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:BoundField DataField="walletid" HeaderText="walletid" ReadOnly="True" SortExpression="walletid" />
                            <asp:BoundField DataField="balance" HeaderText="balance" SortExpression="balance" />
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
                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:SohamGlobalConnectionString %>" SelectCommand="SELECT [walletid], [balance] FROM [wallet] WHERE ([userid] = @userid)">
                            <SelectParameters>
                                <asp:SessionParameter DefaultValue="na" Name="userid" SessionField="userid" Type="String" />
                            </SelectParameters>
                        </asp:SqlDataSource>
                       &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                   
                    <br />
                </div>
            </div>
            <br />
&nbsp;<br />
            <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource2" Height="16px" Width="153px">
                <Columns>
                    <asp:ImageField DataImageUrlField="Image" HeaderText="Profile Picture">
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle Height="5px" HorizontalAlign="Center" Width="2px" />
                    </asp:ImageField>
                </Columns>
            </asp:GridView>
           
            <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:SohamGlobalConnectionString3 %>" SelectCommand="SELECT [Image] FROM [profile] WHERE ([userid] = @userid)">
                <SelectParameters>
                    <asp:SessionParameter Name="userid" SessionField="userid" Type="String" />
                </SelectParameters>
            </asp:SqlDataSource>
           
&nbsp;<br />
            <br />
             <br /><hr /><br /><br />
                &copy;SohamGlobal.com<br />Developed in Microsoft.Net

        </div>
    </form>
</body>
</html>
