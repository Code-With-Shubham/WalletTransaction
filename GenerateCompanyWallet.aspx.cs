using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
public partial class GenerateCompanyWallet : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void submit(object sender, EventArgs e)
    {
        SqlConnection scon;
        SqlCommand scmd;

        try
        {
            int wid;
            string uid, email;
            DateTime dt;

            uid = TextBox1.Text;
            email = TextBox2.Text;
            
            dt = DateTime.Now;

            Random r = new Random();
            wid = r.Next(123456, 1000000);

            DBConnector dbc = new DBConnector();
            scon = dbc.GetDBConnection();
            scon.Open();

            scmd = new SqlCommand("insert into wallet values(@p1,@p2,@p3,@p4);", scon);
            scmd.Parameters.AddWithValue("p1", wid);
            scmd.Parameters.AddWithValue("p2", uid);
            scmd.Parameters.AddWithValue("p3", email);
            scmd.Parameters.AddWithValue("p4", 500);
            int cnt = scmd.ExecuteNonQuery();
            if (cnt > 0)
            {
                Label1.Text = "Wallet Created....Wallet Id Is : " + wid;
                Label1.ForeColor = System.Drawing.Color.Green;
                scmd = new SqlCommand("insert into WalletTransaction values(@p1,@p2,@p3,@p4,@p5);", scon);
                scmd.Parameters.AddWithValue("p1", uid);
                scmd.Parameters.AddWithValue("p2", wid);
                scmd.Parameters.AddWithValue("p3", "Deposite");
                scmd.Parameters.AddWithValue("p4", 500);
                scmd.Parameters.AddWithValue("p5", dt);
                scmd.ExecuteNonQuery();
            }
            else
            {
                Label1.Text = "Failed...";
                Label1.ForeColor = System.Drawing.Color.Red;
            }
        }
        catch (Exception ex)
        {
            Label1.Text = "Error : " + ex.Message;
        }
    }
}