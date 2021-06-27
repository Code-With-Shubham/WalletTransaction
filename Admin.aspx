<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Admin.aspx.cs" Inherits="Admin" %>

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
                <h4 style="color:darkblue">WelCome</h4><br />
                <asp:Label ID="Label1" runat="server" Font-Size="Larger" ForeColor="#000066"></asp:Label>  <br /><br />
            </header>
            <div class="container">
                <a href="ShowKYCdoc.aspx">Show KYC Documents</a>   || 
                <a href="GenerateCompanyWallet.aspx">Company Wallet</a>   ||
                <a href="CheckWalletBalanceByIDUsingWebService.aspx">Check Balance</a>   ||<br />
                <a href="DailyTransactionReport.aspx">Dailly Report</a>   || 
                <a href="ActiveDeactiveUsers.aspx">Show Active Deactive Users</a>   ||
                <a href="changepassword.aspx">Change Password</a>   || <br />
                <a href="Logout.aspx">Logout</a>

            </div>
             <br /><hr /><br /><br />
                &copy;SohamGlobal.com<br />Developed in Microsoft.Net
        </div>
    </form>
</body>
</html>
