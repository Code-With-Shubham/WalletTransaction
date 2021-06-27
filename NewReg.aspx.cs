using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
public partial class NewReg : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void newreg(object sender, EventArgs e)
    {
        SqlConnection scon;
        SqlCommand scmd;
       
        try
        {
            string uid, pswd, nm, gn = "", city, email, mo, sq, ans;
            int age;
            uid = TextBox1.Text;
            pswd = TextBox2.Text;
            nm = TextBox3.Text;
            age = Convert.ToInt32(TextBox4.Text);
            if (RadioButton1.Checked)
                gn = "male";
            else
                gn = "female";
            city = TextBox5.Text;
            mo = TextBox6.Text;
            email = TextBox7.Text;
            sq = DropDownList1.SelectedItem.Text;
            ans = TextBox8.Text;

            DBConnector dbc = new DBConnector();
            scon = dbc.GetDBConnection();
            scon.Open();

            scmd = new SqlCommand("insert into users values(@p1,@p2,@p3,@p4,@p5);", scon);
            scmd.Parameters.AddWithValue("p1", uid);
            scmd.Parameters.AddWithValue("p2", pswd);
            scmd.Parameters.AddWithValue("p3", nm);
            scmd.Parameters.AddWithValue("p4", "user");
            scmd.Parameters.AddWithValue("p5", "active");
           
            int cnt=scmd.ExecuteNonQuery();
            if (cnt > 0)
            {
                scmd = new SqlCommand("insert into userpersonal values(@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8);", scon);

                scmd.Parameters.AddWithValue("p1", uid);
                scmd.Parameters.AddWithValue("p2", age);
                scmd.Parameters.AddWithValue("p3", gn);
                scmd.Parameters.AddWithValue("p4", city);
                scmd.Parameters.AddWithValue("p5", mo);
                scmd.Parameters.AddWithValue("p6", email);
                scmd.Parameters.AddWithValue("p7", sq);
                scmd.Parameters.AddWithValue("p8", ans);
                int cnt1=scmd.ExecuteNonQuery();
                if(cnt1>0)
                 Response.Redirect("RegSuccess.aspx");
                else
                 Response.Redirect("RegFailed.aspx");
                
                scon.Close();
             }
            else
            {
                Response.Redirect("RegFailed.aspx");
            }
        }
        catch (Exception ex)
        {
            Response.Write("Error : "+ex.Message);
        }
    }
}