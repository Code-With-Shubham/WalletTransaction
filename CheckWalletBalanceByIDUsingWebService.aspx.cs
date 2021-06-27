using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class CheckWalletBalanceByIDUsingWebService : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        int wid = Convert.ToInt32(TextBox1.Text);
        ServiceReference2.SearchBalanceSoapClient obj = new ServiceReference2.SearchBalanceSoapClient();
        int bal = obj.FindBalance(wid);
        Label1.Text = "Balance : " + bal;
    }
}