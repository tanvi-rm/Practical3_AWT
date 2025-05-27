using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Practical_no_3_documentation
{
    public partial class ConnectedArchitecture : System.Web.UI.Page
    {
        static String conStr = ConfigurationManager.ConnectionStrings["customerConString"].ToString();

        SqlConnection conn = null;
        SqlCommand cmd = null;
        SqlDataReader dr = null;
        DataTable dt = null;

        public void showData()
        {
            try
            {
                cmd = new SqlCommand("SELECT * FROM customer_info", conn);
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                
                dt = new DataTable();
                dr = cmd.ExecuteReader();
                dt.Load(dr);

                custTable.DataSource = dt;
                custTable.DataBind();
                
            }
            catch(Exception e)
            {
                lbl1.Text = "Exception: " + e.Message;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            conn = new SqlConnection(conStr);
            showData();
        }

        protected void addb_Click(object sender, EventArgs e)
        {
            try
            {
                cmd = new SqlCommand("INSERT INTO customer_info(cid, cname, cadd) VALUES (@id, @name, @add)", conn);

                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                cmd.Parameters.AddWithValue("@id", cidt.Text);
                cmd.Parameters.AddWithValue("@name", cnamet.Text);
                cmd.Parameters.AddWithValue("@add", caddt.Text);

                int r = cmd.ExecuteNonQuery();

                if (r != 0)
                {
                    lbl1.Text = "Record inserted successfully!";
                }
                else
                {
                    lbl1.Text = "Record not inserted!";
                }
            }
            catch (Exception ex)
            {
                lbl1.Text = "Exception " + ex.Message;
            }
            finally
            {
                conn.Close();
                showData();

            }
        }

        protected void updateb_Click(object sender, EventArgs e)
        {
            try
            {
                cmd = new SqlCommand("UPDATE customer_info SET cname = @name, cadd = @add WHERE cid = @id", conn);
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                cmd.Parameters.AddWithValue("@id", cidt.Text);
                cmd.Parameters.AddWithValue("@name", cnamet.Text);
                cmd.Parameters.AddWithValue("@add", caddt.Text);

                int r = cmd.ExecuteNonQuery();

                if (r != 0)
                {
                    lbl1.Text = "Record updated successfully!";
                }
                else
                {
                    lbl1.Text = "Record not found!";
                }
            }
            catch (Exception ex)
            {
                lbl1.Text = "Exception: " + ex.Message;
            }
            finally
            {
                conn.Close();
                showData();
            }
        }

        protected void deleteb_Click(object sender, EventArgs e)
        {
            try
            {
                cmd = new SqlCommand("DELETE FROM customer_info WHERE cid = @id", conn);
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                cmd.Parameters.AddWithValue("@id", cidt.Text);

                int r = cmd.ExecuteNonQuery();

                if (r != 0)
                {
                    lbl1.Text = "Record deleted successfully!";
                }
                else
                {
                    lbl1.Text = "Record not deleted!";
                }
            }
            catch (Exception ex)
            {
                lbl1.Text = "Exception " + ex.Message;
            }
            finally
            {
                conn.Close();
                showData();

            }
        }

        protected void searchb_Click(object sender, EventArgs e)
        {
            try
            {
                cmd = new SqlCommand("SELECT cname, cadd FROM customer_info WHERE cid = @id", conn);
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                cmd.Parameters.AddWithValue("@id", cidt.Text);
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    cnamet.Text = dr["cname"].ToString();
                    caddt.Text = dr["cadd"].ToString();
                    lbl1.Text = "Record found!";
                }
                else
                {
                    lbl1.Text = "Record not found!";
                    cnamet.Text = "";
                    caddt.Text = "";
                }

                dr.Close();
            }
            catch (Exception ex)
            {
                lbl1.Text = "Exception: " + ex.Message;
            }
            finally
            {
                conn.Close();
            }
        }
    }
    }
