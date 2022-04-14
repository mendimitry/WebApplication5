using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using MySql.Data.MySqlClient;
using System.Threading;

namespace WebApplication5
{
    public partial class search : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            

        }

        protected void ButSearch_Click(object sender, EventArgs e)
        {
            Label1.Text = "Действие выполнится в течение 2 секунд";
            //Thread.Sleep(2000);

            //string name = Request.Form.Get("name");
            //string eml = Request.Form.Get("email");
            DataTable dt2 = new DataTable();
            string mycon = "server =localhost; Uid=root; password = ; persistsecurityinfo = True; database =zavod; SslMode = none";
            //string mycon = "Server=localhost;Database=test1;Uid=root;Password= ;";
            MySqlConnection con = new MySqlConnection(mycon);
            MySqlCommand cmd = null;

            try
            {
                cmd = new MySqlCommand("select * from books where BooksName like '" + Txtsearch.Text + "%'",  con);
                //cmd = new MySqlCommand("select * from strachilkabook where BooksName like '" + Txtsearch.Text + "%'", con);
                //cmd = new MySqlCommand("select * from pashalkabook where BooksName like '" + Txtsearch.Text + "%'", con);

                con.Open();
                dt2.Load(cmd.ExecuteReader());
                cmd.ExecuteNonQuery();
                con.Close();

            }

            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "')</script>");
                con.Close();
                return;
            }
            //Response.Write("<script>alert('Data Saved Successfully')</script>");
            GridView1.DataSource = dt2;
            GridView1.DataBind();
        }


    }
}