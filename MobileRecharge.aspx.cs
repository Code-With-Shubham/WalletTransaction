using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
public partial class MobileRecharge : System.Web.UI.Page
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
            string mo = TextBox2.Text;
            double amt = Convert.ToDouble(TextBox3.Text);
            DateTime dt = DateTime.Now;

            DBConnector dbc = new DBConnector();
            scon = dbc.GetDBConnection();
            scon.Open();

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
                    int fwid = Convert.ToInt32(ds.Tables["ut"].Rows[i]["walletid"]);
                    
                    string cuid;
                    cuid = TextBox1.Text;
                    scmd = new SqlCommand("select * from wallet where userid=@a;", scon);
                    scmd.Parameters.AddWithValue("a", cuid);
                    sda = new SqlDataAdapter(scmd);
                    ds = new DataSet();
                    sda.Fill(ds, "ut");
                    int cnt1 = ds.Tables["ut"].Rows.Count;
                    if (cnt1 > 0)
                    {
                        for (int j = 0; j < cnt; j++)
                        {
                            int twid = Convert.ToInt32(ds.Tables["ut"].Rows[i]["walletid"]);
                            string cuid1 = Convert.ToString(ds.Tables["ut"].Rows[i]["userid"]);
                            if (cuid.Equals(cuid1))
                            {

                                scmd = new SqlCommand("update wallet set balance=balance-@a where walletid=@b;", scon);
                                scmd.Parameters.AddWithValue("a", amt);
                                scmd.Parameters.AddWithValue("b", fwid);
                                scmd.ExecuteNonQuery();
                                

                                scmd = new SqlCommand("update wallet set balance=balance+@a where walletid=@b;", scon);
                                scmd.Parameters.AddWithValue("a", amt);
                                scmd.Parameters.AddWithValue("b", twid);
                                int cnt2 = scmd.ExecuteNonQuery();
                                if (cnt2 > 0)
                                {
                                    //cashback
                                    if (amt >= 49)
                                    {
                                        double cashback = amt / 100 * 10;

                                        scmd = new SqlCommand("update wallet set balance=balance+@a where walletid=@b;", scon);
                                        scmd.Parameters.AddWithValue("a", cashback);
                                        scmd.Parameters.AddWithValue("b", fwid);
                                        int cb1 = scmd.ExecuteNonQuery();
                                        if(cb1>0)
                                        {
                                            Label2.Text = " Cogatulation " + uid + " You Win CashBack Rs " + cashback;
                                            Label2.ForeColor = System.Drawing.Color.Orange;

                                            scmd = new SqlCommand("insert into WalletTransaction values(@p1,@p2,@p3,@p4,@p5);", scon);
                                            scmd.Parameters.AddWithValue("p1", uid);
                                            scmd.Parameters.AddWithValue("p2", fwid);
                                            scmd.Parameters.AddWithValue("p3", "Cashback");
                                            scmd.Parameters.AddWithValue("p4", cashback);
                                            scmd.Parameters.AddWithValue("p5", dt);
                                            scmd.ExecuteNonQuery();

                                        }
                                        
                                    }

                                    scmd = new SqlCommand("insert into WalletTransaction values(@p1,@p2,@p3,@p4,@p5);", scon);
                                    scmd.Parameters.AddWithValue("p1", uid);
                                    scmd.Parameters.AddWithValue("p2", fwid);
                                    scmd.Parameters.AddWithValue("p3", "Withdraw");
                                    scmd.Parameters.AddWithValue("p4", amt);
                                    scmd.Parameters.AddWithValue("p5", dt);
                                    scmd.ExecuteNonQuery();

                                    scmd = new SqlCommand("insert into WalletTransaction values(@p1,@p2,@p3,@p4,@p5);", scon);
                                    scmd.Parameters.AddWithValue("p1", uid);
                                    scmd.Parameters.AddWithValue("p2", twid);
                                    scmd.Parameters.AddWithValue("p3", "Deposite");
                                    scmd.Parameters.AddWithValue("p4", amt);
                                    scmd.Parameters.AddWithValue("p5", dt);
                                    int cnt3 = scmd.ExecuteNonQuery();
                                    if (cnt3 > 0)
                                    {

                                        Label1.Text = "Congratulations "+uid+" Your Mobile No "+mo+" Recharge with "+amt+"Rs at "+dt+" Thank You From "+cuid;
                                        Label1.ForeColor = System.Drawing.Color.Green;

                                    }
                                    else
                                    {
                                        Label1.Text = "Failed..";
                                        Label1.ForeColor = System.Drawing.Color.Red;
                                    }

                                }
                                else
                                {
                                    Label1.Text = "Balance Not Updated Succesfully Please Try Again";
                                    Label1.ForeColor = System.Drawing.Color.Red;
                                }
                            }
                            else
                            {
                                Label1.Text = "Please Enter A Registred Telecom Company Name";
                                Label1.ForeColor = System.Drawing.Color.Red;
                            }
                        }
                    }
                    else
                    {
                        Label1.Text = "Telecom Company's Identity failed...Try Again or Contact Admin";
                        Label1.ForeColor = System.Drawing.Color.Red;
                    }

                }

            }
            else
            {
                Label1.Text = "User Identity Error Please Try Again Or Login";
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