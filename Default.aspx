<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="bootstrap.min.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
           <br /><br /> <h2>
                Online Payment Application 
            </h2>
            <br /><hr />
            <br />
            <div class="container">
               <table>
                   <tr>
                       <td>UserID</td>
                       <td>
                           <asp:TextBox ID="TextBox1" runat="server" Class="form-control"></asp:TextBox>
                       </td>
                   </tr>

                   <tr>
                       <td>Password</td>
                       <td>
                           <asp:TextBox ID="TextBox2" runat="server" TextMode="Password" Class="form-control"></asp:TextBox>
                       </td>
                   </tr>
                   <tr>
                       <td></td>
                       <td>
                           <asp:Button ID="Button1" runat="server" Text="Login" OnClick="check"  Class="form-control" />
                       </td>
                   </tr>
               </table>
                <br />
                <br />
                <a href="NewReg.aspx">Create New Account</a>
                <br />
                <a href="RecoverPass.aspx">Forget Password</a>
            </div>
             <br /><hr /><br /><br />
                &copy;SohamGlobal.com<br />Developed in Microsoft.Net
        </div>

    </form>
</body>
</html>
