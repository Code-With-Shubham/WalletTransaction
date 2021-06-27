<%@ Page Language="C#" AutoEventWireup="true" CodeFile="NewReg.aspx.cs" Inherits="NewReg" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="bootstrap.min.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <br />
            <h2>New Registration form</h2>
            <br /><hr /><br />
            <div class="container">
                <table>
                    <tr>
                        <td>Userid</td>
                        <td>
                            <asp:TextBox ID="TextBox1" runat="server" Class="form-control"></asp:TextBox>
                        </td>
                    </tr>
                     <tr>
                        <td>Password</td>
                        <td>
                            <asp:TextBox ID="TextBox2" runat="server" TextMode="Password" Class="form-control" ></asp:TextBox>
                        </td>
                    </tr>
                     <tr>
                        <td>Name</td>
                        <td>
                            <asp:TextBox ID="TextBox3" runat="server" Class="form-control"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>Age</td>
                        <td>
                            <asp:TextBox ID="TextBox4" runat="server" Class="form-control"></asp:TextBox>
                        </td>
                    </tr>
                     <tr>
                        <td>Gender</td>
                        <td>
                            <asp:RadioButton ID="RadioButton1" runat="server" GroupName="gen" Text="male" Checked="true" />
                            <asp:RadioButton ID="RadioButton2" runat="server" GroupName="gen" Text="female" />
                        </td>
                    </tr>
                     <tr>
                        <td>City</td>
                        <td>
                            <asp:TextBox ID="TextBox5" runat="server" Class="form-control" ></asp:TextBox>
                        </td>
                    </tr>
                     <tr>
                        <td>Mobile</td>
                        <td>
                            <asp:TextBox ID="TextBox6" runat="server" Class="form-control"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>EmailID</td>
                        <td>
                            <asp:TextBox ID="TextBox7" runat="server" TextMode="Email" Class="form-control"></asp:TextBox>
                        </td>
                    </tr>
                        <tr>
                    <td>Security Question</td>
                    <td>
                        <asp:DropDownList ID="DropDownList1" runat="server" CssClass="form-control">
                            <asp:ListItem>What was the name of your first school?</asp:ListItem>
                            <asp:ListItem>Which is your favorite color?</asp:ListItem>
                            <asp:ListItem>What is your pet name?</asp:ListItem>
                        </asp:DropDownList></td>
                </tr>
                <tr>
                    <td>Answer</td>
                    <td>
                        <asp:TextBox ID="TextBox8" runat="server"></asp:TextBox></td>
                </tr>
                    <tr>
                        <td></td>
                        <td>
                            <asp:Button ID="Button1" runat="server" Text="Submit" OnClick="newreg" />
                        </td>
                    </tr>
                </table>
            </div>
             <br /><hr /><br /><br />
                &copy;SohamGlobal.com<br />Developed in Microsoft.Net
        </div>
    </form>
</body>
</html>
