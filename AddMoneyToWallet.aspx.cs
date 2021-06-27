using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
public partial class AddMoneyToWallet : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string uid = Convert.ToString(Session["userid"]);
        Label2.Text = uid;
    }

    protected void addmoney(object sender, EventArgs e)
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

            string uid = Convert.ToString(Session["userid"]);
            DateTime dt = DateTime.Now;
            double amt = Convert.ToDouble(TextBox1.Text);

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
                    Label3.Text = "Wallet id : "+wid;

                    scmd = new SqlCommand("update wallet set balance=balance+@a where userid=@b;", scon);
                    scmd.Parameters.AddWithValue("a", amt);
                    scmd.Parameters.AddWithValue("b", uid);
                    int cnt1 = scmd.ExecuteNonQuery();
                    if (cnt1 > 0)
                    {
                        scmd = new SqlCommand("insert into WalletTransaction values(@p1,@p2,@p3,@p4,@p5);", scon);
                        scmd.Parameters.AddWithValue("p1", uid);
                        scmd.Parameters.AddWithValue("p2", wid);
                        scmd.Parameters.AddWithValue("p3", "Deposite");
                        scmd.Parameters.AddWithValue("p4", amt);
                        scmd.Parameters.AddWithValue("p5", dt);
                        int cnt2 = scmd.ExecuteNonQuery();
                        if (cnt2 > 0)
                        {

                            Label1.Text = "Money Added Successfully..";
                            Label1.ForeColor = System.Drawing.Color.Green;
                        }
                        else
                        {
                            Label1.Text = "Failed..Make Sure Your KYC Is Complete";
                            Label1.ForeColor = System.Drawing.Color.Red;
                        }
                        scon.Close();
                    }
                    else
                    {
                        Label1.Text = " Money Added Successfully But Entry Is Not Completed Successfully";
                    }



                }
            }
            else
            {
                Label1.Text = "Wallet id not found";
            }

               
        }
        catch(Exception ex)
        {
            Label1.Text = "Error : "+ex.Message;
            Label1.ForeColor = System.Drawing.Color.Red;
        }
    }
}