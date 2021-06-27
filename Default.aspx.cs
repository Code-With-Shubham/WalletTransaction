using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void check(object sender, EventArgs e)
    {
       
        try
        {
            string uid, pswd,typ;
            uid = TextBox1.Text;
            pswd = TextBox2.Text;

            SqlConnection scon;
            SqlCommand scmd;
            SqlDataAdapter sda;
            DataSet ds;

            DBConnector dbc = new DBConnector();
            scon = dbc.GetDBConnection();
            scon.Open();

            scmd = new SqlCommand("select * from users where userid=@a and pswd=@b and userstatus='active';", scon);
            scmd.Parameters.AddWithValue("a", uid);
            scmd.Parameters.AddWithValue("b", pswd);
            sda = new SqlDataAdapter(scmd);
            ds = new DataSet();
            sda.Fill(ds, "ut");
            int cnt = ds.Tables["ut"].Rows.Count;

            if (cnt > 0)
            {
                Session["userid"] = uid;
                typ = Convert.ToString(ds.Tables["ut"].Rows[0]["usertype"]);
                Session["usertype"] = typ;
                if (typ == "user")
                    Response.Redirect("User.aspx");

                if (typ == "admin")
                    Response.Redirect("Admin.aspx");

            }
            else
                Response.Redirect("Failure.aspx");
        }
        catch(Exception ex)
        {
            Response.Write("Error : " + ex.Message);
        }
        
    }
}