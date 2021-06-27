using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
public partial class ShowTransactionLog : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        SqlConnection scon;
        SqlCommand scmd;
        SqlDataAdapter sda;
        DataSet ds;

        try
        {
            string uid = Convert.ToString(Session["userid"]);
            Label1.Text = uid;
            DBConnector dbc = new DBConnector();
            scon = dbc.GetDBConnection();
            scon.Open();

            //code to find walletid from userid
            scmd = new SqlCommand("select * from wallet where userid=@a;", scon);
            scmd.Parameters.AddWithValue("a", uid);
            sda = new SqlDataAdapter(scmd);
            ds = new DataSet();
            sda.Fill(ds, "ut");
            int cnt = ds.Tables["ut"].Rows.Count;
            if (cnt > 0)
            {
                for (int i = 0; i < cnt; i++)
                {
                    int wid = Convert.ToInt32(ds.Tables["ut"].Rows[i]["walletid"]);

                    scmd = new SqlCommand("select walletid,status,amt from WalletTransaction where walletid=@a;", scon);
                    scmd.Parameters.AddWithValue("a", wid);
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
                        Label2.Text = "Something Went Wrong Retry..";
                        Label2.ForeColor = System.Drawing.Color.Green;
                    }
                }
            }
            else
            {
                Label2.Text = "User Identity Failed...Contact to Admin";
                Label2.ForeColor = System.Drawing.Color.Red;
            }
        }
        catch (Exception ex)
        {
            Response.Write("Error : " + ex.Message);
        }
    }
}