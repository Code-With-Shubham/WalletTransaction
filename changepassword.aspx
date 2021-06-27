<%@ Page Language="C#" AutoEventWireup="true" CodeFile="changepassword.aspx.cs" Inherits="changepassword" %>

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
            <h2>Change Password Form</h2>
            <br /><hr /><br />
            <div class="container">
               <table>
                  
                    <tr>
                       <td>Old Password</td>
                       <td><asp:TextBox ID="TextBox1" runat="server" class="form-control" TextMode="Password" ></asp:TextBox></td>
                   </tr>
                    <tr>
                       <td>New Password</td>
                       <td><asp:TextBox ID="TextBox2" runat="server" class="form-control" TextMode="Password"></asp:TextBox></td>
                   </tr>
                    <tr>
                       <td>Confirm Password</td>
                       <td><asp:TextBox ID="TextBox3" runat="server" class="form-control" TextMode="Password"></asp:TextBox></td>
                   </tr>
                   <tr>
                       <td></td>
                       <td>
                           <asp:Button ID="Button1" runat="server" Text="Change" OnClick="change" /></td>
                   </tr>
               </table>
                <br />
            <asp:Label ID="l1" runat="server"></asp:Label>
            <br /><br />
            <asp:HyperLink ID="HyperLink1" runat="server"></asp:HyperLink>
            </div>
             <br /><hr /><br /><br />
                &copy;SohamGlobal.com<br />Developed in Microsoft.Net
        </div>
    </form>
</body>
</html>
