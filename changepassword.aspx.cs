using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
public partial class changepassword : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string ty = Session["usertype"].ToString();
        if (ty == "user")
        {
            HyperLink1.Text = "User Home";
            HyperLink1.NavigateUrl = "User.aspx";
        }

        if (ty == "admin")
        {
            HyperLink1.Text = "Admin Home";
            HyperLink1.NavigateUrl = "Admin.aspx";
        }
    }

    protected void change(object sender, EventArgs e)
    {
        try
        {
            SqlConnection scon;
            SqlCommand scmd;
            

            string id, curps, newps, confps;
            id = Convert.ToString(Session["userid"]);
            curps = TextBox1.Text;
            newps = TextBox2.Text;
            confps = TextBox3.Text;
            if (newps == confps)
            {

                DBConnector dbc = new DBConnector();
                scon = dbc.GetDBConnection();
                scon.Open();
                scmd = new SqlCommand("update users set pswd=@p1 where userid=@p2 and pswd=@p3;", scon);
                scmd.Parameters.AddWithValue("p1", newps);
                scmd.Parameters.AddWithValue("p2", id);
                scmd.Parameters.AddWithValue("p3", curps);
                int cnt = scmd.ExecuteNonQuery();
                if (cnt > 0)
                {
                    l1.Text = "Password Changed Successfully...";
                    l1.ForeColor = System.Drawing.Color.Green;
                }
                else
                {
                    l1.Text = "Failed...";
                    l1.ForeColor = System.Drawing.Color.Red;
                }
                scon.Close();
            }
            else
                l1.Text = "New Passwords Mismatched";


        }
        catch (Exception ex)
        {
            l1.Text = "Error : " + ex.Message;
        }
    }
}