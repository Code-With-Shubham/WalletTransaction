using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
public partial class ActiveDeactiveUsers : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        SqlConnection scon;
        SqlCommand scmd;
        SqlDataAdapter sda;
        DataSet ds;

        try
        {
            
            DBConnector dbc = new DBConnector();
            scon = dbc.GetDBConnection();
            scon.Open();

            scmd = new SqlCommand("select userid,userstatus from users;", scon);
            sda = new SqlDataAdapter(scmd);
            ds = new DataSet();
            sda.Fill(ds, "ut");
            int cnt1 = ds.Tables["ut"].Rows.Count;
            if (cnt1 > 0)
            {
                GridView1.DataSource = ds;
                GridView1.DataBind();

            }
           
        }
        catch (Exception ex)
        {
           
        }

    }

}
