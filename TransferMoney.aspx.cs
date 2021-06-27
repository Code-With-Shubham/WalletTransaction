using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using SohamMail;

public partial class TransferMoney : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
        
    }

    protected void transfer(object sender, EventArgs e)
    {
        SqlConnection scon;
        SqlCommand scmd;
        SqlDataAdapter sda;
        DataSet ds;

        try
        {
            string uid;
            int twid;
            DateTime dt;
            double amt;
            uid = Convert.ToString(Session["userid"]);
            twid = Convert.ToInt32(TextBox1.Text);
            amt = Convert.ToDouble(TextBox2.Text);
            dt = DateTime.Now;

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
                    
                    //update sender balance
                    scmd = new SqlCommand("update wallet set balance=balance-@a where walletid=@b;", scon);
                    scmd.Parameters.AddWithValue("a", amt);
                    scmd.Parameters.AddWithValue("b", wid);
                    scmd.ExecuteNonQuery();
                      

                       //code to access email of sender 
                        scmd = new SqlCommand("select email from wallet where walletid=@a;", scon);
                        scmd.Parameters.AddWithValue("a", wid);
                        sda = new SqlDataAdapter(scmd);
                        ds = new DataSet();
                        sda.Fill(ds, "ut");
                        int cnt5 = ds.Tables["ut"].Rows.Count;
                        if (cnt5> 0)
                        {
                        for (int j = 0; j < cnt5; j++)
                        {
                            string semail = Convert.ToString(ds.Tables["ut"].Rows[i]["email"]);
                            semail.Trim();
                            string msg = "<html><body>" +amt+ "Rs to "+twid+" send Successfully form your wallet id "+wid+"".Trim() + "</body></html>";
                            string sub = "Transfer Money Acknowlegement".Trim();
                            string frm = ""+uid+"".Trim();

                            SendMail sm = new SendMail();
                            if (sm.sendMail(semail, msg, sub, frm))
                            {
                                Label3.Text = "Acknowlegement Send On Mail";
                                Label3.ForeColor = System.Drawing.Color.Green;
                            }
                        }
                        }

                    //code to update reciver balance
                    scmd = new SqlCommand("update wallet set balance=balance+@a where walletid=@b;", scon);
                    scmd.Parameters.AddWithValue("a", amt);
                    scmd.Parameters.AddWithValue("b", twid);
                    int cnt1 = scmd.ExecuteNonQuery();
                    if (cnt1 > 0)
                    {
                        //code to find email of reciver
                        scmd = new SqlCommand("select email from wallet where walletid=@a;", scon);
                        scmd.Parameters.AddWithValue("a", twid);
                        sda = new SqlDataAdapter(scmd);
                        ds = new DataSet();
                        sda.Fill(ds, "ut");
                        int cnt6 = ds.Tables["ut"].Rows.Count;
                        if (cnt6 > 0)
                        {
                            for (int k = 0; k < cnt6; k++)
                            {
                                string semail = Convert.ToString(ds.Tables["ut"].Rows[i]["email"]);
                                semail.Trim();
                                string msg = "<html><body>" + amt + "Rs to recive from" + wid + "Success fully to your wallet id " + twid + "".Trim() + "</body></html>";
                                string sub = "Transfer Money Acknowlegement".Trim();
                                string frm = "" + uid + "".Trim();

                                SendMail sm = new SendMail();
                                if (sm.sendMail(semail, msg, sub, frm))
                                {
                                    Label3.Text = "Acknowlegement Send On Mail";
                                    Label3.ForeColor = System.Drawing.Color.Green;
                                }
                            }
                        }
                        //code to cashback
                        if (amt >= 1000)
                        {
                            double cashback = 50;
                            scmd = new SqlCommand("update wallet set balance=balance+@a where walletid=@b;", scon);
                            scmd.Parameters.AddWithValue("a", cashback);
                            scmd.Parameters.AddWithValue("b", wid);
                            int cb1 = scmd.ExecuteNonQuery();
                            {
                                Label2.Text = "Cogatulation " + uid + "You Win CashBack Rs" + cashback;
                                Label2.ForeColor = System.Drawing.Color.Orange;

                                scmd = new SqlCommand("insert into WalletTransaction values(@p1,@p2,@p3,@p4,@p5);", scon);
                                scmd.Parameters.AddWithValue("p1", uid);
                                scmd.Parameters.AddWithValue("p2", wid);
                                scmd.Parameters.AddWithValue("p3", "Cashback");
                                scmd.Parameters.AddWithValue("p4", cashback);
                                scmd.Parameters.AddWithValue("p5", dt);
                                scmd.ExecuteNonQuery();
                            }
                        }
                        //code to insert data in transaction table

                        scmd = new SqlCommand("insert into WalletTransaction values(@p1,@p2,@p3,@p4,@p5);", scon);
                        scmd.Parameters.AddWithValue("p1", uid);
                        scmd.Parameters.AddWithValue("p2", wid);
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
                        int cnt2 = scmd.ExecuteNonQuery();
                        if (cnt2 > 0)
                        {
                           
                            Label1.Text = "Transaction Successfull...";
                            Label1.ForeColor = System.Drawing.Color.Green;
                        }
                        else
                        {
                            Label1.Text = "Transaction Failed..";
                            Label1.ForeColor = System.Drawing.Color.Red;
                        }
                    }
                    else
                    {
                        Label1.Text = "Transaction Successfull But Transaction Not Interested..";
                    }
                }
            }
            else
            {
                Label1.Text = "WalletID Not Found..";
            }

        }
        catch(Exception ex)
        {
          Label1.Text = "Error : " + ex.Message;
        }
    }
}