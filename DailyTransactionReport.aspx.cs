using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
public partial class DailyTransactionReport : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        SqlConnection scon;
        SqlCommand scmd;
        SqlDataAdapter sda;
        DataSet ds;

        try
        {
            string dt = DateTime.Now.ToString("dd/mm/yyyy");
            DBConnector dbc = new DBConnector();
            scon = dbc.GetDBConnection();
            scon.Open();

                    scmd = new SqlCommand("select * from WalletTransaction where dt=@a;", scon);
                    scmd.Parameters.AddWithValue("a", dt);
                    sda = new SqlDataAdapter(scmd);
                    ds = new DataSet();
                    sda.Fill(ds, "ut");
                    int cnt1 = ds.Tables["ut"].Rows.Count;
                    if (cnt1 > 0)
                    {
                        GridView1.DataSource = ds;
                        GridView1.DataBind();

                    }
                    else
                    {
                        Label1.Text = "No Transaction Found";
                         Label1.ForeColor = System.Drawing.Color.Red;
                    }
        }
        catch (Exception ex)
        {
            Label1.Text = "Error : " + ex.Message;
        }

    }

}
