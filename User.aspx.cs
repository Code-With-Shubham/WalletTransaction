using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class User : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        string uid = Convert.ToString(Session["userid"]);
        Label1.Text = uid;

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        string uid = Convert.ToString(Session["userid"]);
        Label1.Text = uid;

        try
        {
            SqlConnection scon;
            SqlCommand scmd;

            DBConnector dbc = new DBConnector();
            scon = dbc.GetDBConnection();
            scon.Open();

            if (FileUpload1.HasFile)
            {
                string str = FileUpload1.FileName;
                FileUpload1.PostedFile.SaveAs(Server.MapPath("~/ProfilePhoto/" + str));
                string Image = "~/ProfilePhoto/" + str.ToString();

                scmd = new SqlCommand("insert into profile values(@uid,@Image)", scon);
                scmd.Parameters.AddWithValue("@uid", uid);
                scmd.Parameters.AddWithValue("Image", Image);
                int cnt1 = scmd.ExecuteNonQuery();
                if (cnt1 > 0)
                {
                    Label2.Text = "Image Uploaded..";
                    Label1.ForeColor = System.Drawing.Color.Green;
                }
                else
                {
                    Label2.Text = "image Updation Failed..";
                    Label1.ForeColor = System.Drawing.Color.Red;
                }

            }

        }
        catch (Exception)
        {

        }
    }
}