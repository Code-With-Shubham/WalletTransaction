using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
public partial class RecoverPass : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void recover(object sender, EventArgs e)
    {
        string id, sq, an, np;
        id = TextBox1.Text;
        sq = DropDownList1.SelectedItem.Text;
        an = TextBox3.Text;
        SqlConnection scon;
        SqlCommand scmd;
        SqlDataAdapter sda;
        DataSet ds;

        DBConnector dbc = new DBConnector();
        scon = dbc.GetDBConnection();
        scmd = new SqlCommand("select * from userpersonal where userid=@p1 and secques=@p2 and answer=@p3;", scon);
        scmd.Parameters.AddWithValue("p1", id);
        scmd.Parameters.AddWithValue("p2", sq);
        scmd.Parameters.AddWithValue("p3", an);
        sda = new SqlDataAdapter(scmd);
        ds = new DataSet();
        sda.Fill(ds, "us");
        if (ds.Tables["us"].Rows.Count > 0)
        {
            //code to recover password
            np = id.Substring(1, 3) + "@" + DateTime.Now.Minute + DateTime.Now.Second;
            Label1.Text = "Your New Password is " + np;
            Label1.ForeColor = System.Drawing.Color.Green;
            scon.Open();
            scmd = new SqlCommand("update users set pswd=@a where userid=@b;", scon);
            scmd.Parameters.AddWithValue("a", np);
            scmd.Parameters.AddWithValue("b", id);
            scmd.ExecuteNonQuery();
            scon.Close();
           
        }
      
        else
        {
           Label1.Text="User Identity Failed...";
            Label1.ForeColor = System.Drawing.Color.Red;
        }
    }
}
