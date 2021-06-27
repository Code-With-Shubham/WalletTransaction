using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
public partial class SearchTransactionByDate : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        SqlConnection scon;
        SqlCommand scmd;
        SqlDataAdapter sda;
        DataSet ds;

        try
        {
            string uid = Convert.ToString(Session["userid"]);
            Label1.Text = uid;
            DateTime dt = Convert.ToDateTime(TextBox1.Text);

            DBConnector dbc = new DBConnector();
            scon = dbc.GetDBConnection();
            scon.Open();
            scmd = new SqlCommand("select walletid from wallet where userid=@a;", scon);
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
                    
                    scmd = new SqlCommand("select walletid,status,amt from WalletTransaction where dt=@a and walletid=@b;", scon);
                    scmd.Parameters.AddWithValue("a", dt);
                    scmd.Parameters.AddWithValue("b", wid);
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
                        Label2.Text = "No Transaction Found";
                        Label1.ForeColor = System.Drawing.Color.Red;
                    }
                    
                }
            }
           
        }
        catch (Exception ex)
        {
            Label2.Text="Error : " + ex.Message;
        }

    }
}