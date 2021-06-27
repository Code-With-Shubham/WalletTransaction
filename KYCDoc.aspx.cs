using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.IO;
public partial class KYCDoc : System.Web.UI.Page
{
    

    protected void Page_Load(object sender, EventArgs e)
    {
       
    }

    protected void upload(object sender, EventArgs e)
    {
        SqlConnection scon;
        SqlCommand scmd;
        SqlDataAdapter sda;
        DataSet ds;

        try
        {
            string uid = Convert.ToString(Session["userid"]);
            string email = TextBox2.Text;
            DateTime dt = DateTime.Now;

            DBConnector dbc = new DBConnector();
            scon = dbc.GetDBConnection();
            scon.Open();

            scmd = new SqlCommand("select * from userpersonal where userid=@p1 and email=@p2;", scon);
            scmd.Parameters.AddWithValue("p1", uid);
            scmd.Parameters.AddWithValue("p2", email);

            sda = new SqlDataAdapter(scmd);
            ds = new DataSet();
            sda.Fill(ds, "us");
            if (ds.Tables["us"].Rows.Count > 0)
            {

                if (FileUpload1.HasFile)
                {
                    string str = FileUpload1.FileName;
                    FileUpload1.PostedFile.SaveAs(Server.MapPath("~/AadharCardDoc/" + str));
                    string Image = "~/AadharCardDoc/" + str.ToString();
                   
                    scmd = new SqlCommand("insert into KYCDocuments values(@uid,@email,@Image,@dt)", scon);
                    scmd.Parameters.AddWithValue("@uid", uid);
                    scmd.Parameters.AddWithValue("@email", email);
                    scmd.Parameters.AddWithValue("Image", Image);
                    scmd.Parameters.AddWithValue("@dt", dt);
                    int cnt1 = scmd.ExecuteNonQuery();

                    Label1.Text = "Image Uploaded";
                    Label1.ForeColor = System.Drawing.Color.Green;
                
             
                    if (cnt1 > 0)
                    {
                        Random r = new Random();
                        int wid = r.Next(123456,1000000);
                        
                        //wid = uid.subs + "@" + DateTime.Now.Minute + DateTime.Now.Second;
                        Label1.ForeColor = System.Drawing.Color.Green;
                        scmd = new SqlCommand("insert into wallet values(@p1,@p2,@p3,@p4);", scon);
                        scmd.Parameters.AddWithValue("p1", wid);
                        scmd.Parameters.AddWithValue("p2", uid);
                        scmd.Parameters.AddWithValue("p3", email);
                        scmd.Parameters.AddWithValue("p4", 500);
                        int cnt = scmd.ExecuteNonQuery();
                        if(cnt>0)
                        {
                            Label2.Text = "Wallet Created....Wallet Id Is : " + wid;
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
                            Label2.Text = "Something Went Wrong Please Try Again";
                            Label1.ForeColor = System.Drawing.Color.Red;
                        }
                    }
                    else
                    {
                        Label1.Text = "User Data Not Found..Please Confirm user is valid";
                    }
                    scon.Close();

                }
                else
                {
                    Label1.Text = "Please Uploaded Image";
                    Label1.ForeColor = System.Drawing.Color.Red;
                }
            }
            else
            {
                Label1.Text = "Make Sure That User Is Valid....Or Enter Valid Information ";
                Label1.ForeColor = System.Drawing.Color.Red;
            }
        }
        catch (Exception ex)
        {
            Label1.Text = "Error : " + ex.Message;
            Label1.ForeColor = System.Drawing.Color.Red;
        }
    }
}