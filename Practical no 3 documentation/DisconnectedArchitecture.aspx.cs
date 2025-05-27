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
    public partial class DisconnectedArchitecture : System.Web.UI.Page
    {
        static string conStr = ConfigurationManager.ConnectionStrings["customerConString"].ToString();

        SqlConnection conn = null;
        SqlCommand cmd = null;
        SqlDataAdapter da = null;
        SqlCommandBuilder builder = null;
        DataSet ds = null;

        public void clearTextBox()
        {
            eidt.Text = " ";
            enamet.Text = " ";
            edest.Text = " ";
            esalt.Text = " ";
        }
        public void showData()
        {
            try
            {
                cmd = new SqlCommand("SELECT * FROM emp_info", conn);
                da = new SqlDataAdapter();
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                ds = new DataSet();

                da.MissingSchemaAction = MissingSchemaAction.AddWithKey;

                cmd = new SqlCommand("Select * from emp_info", conn);
                cmd.CommandType = CommandType.Text;
                da.SelectCommand = cmd;

                da.Fill(ds, "empDS");
                empTable.DataSource = ds.Tables["empDS"];
                empTable.DataBind();

            }
            catch (Exception ex)
            {
                lbl1.Text = "Exception " + ex.Message;
            }
            finally
            {
                conn.Close();
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
                if (eidt.Text != "" && enamet.Text != "" && edest.Text != "" && esalt.Text != "")
                {
                    builder = new SqlCommandBuilder(da);

                    DataRow drNew = ds.Tables["empDS"].NewRow();

                    drNew[0] = eidt.Text;
                    drNew[1] = enamet.Text;
                    drNew[2] = edest.Text;
                    drNew[3] = esalt.Text;

                    ds.Tables["empDS"].Rows.Add(drNew);

                    builder.GetInsertCommand();

                    int r = da.Update(ds, "empDS");
                    if (r != 0)
                    {
                        lbl1.Text = "Record inserted successfully!!!";
                        showData();
                        clearTextBox();
                    }
                    else
                    {
                        lbl1.Text = "Record not inserted!!!";
                    }
                }
            }
            catch (Exception ex)
            {
                lbl1.Text = "Exception " + ex.Message;
            }
            finally
            {
                conn.Close();
            }
        }

        protected void updateb_Click(object sender, EventArgs e)
        {
            try
            {
                if (eidt.Text != "" && enamet.Text != "" && edest.Text != "" && esalt.Text != "")
                {
                    builder = new SqlCommandBuilder(da);
                    DataRow drUpdate = ds.Tables["empDS"].Rows.Find(Convert.ToInt32(eidt.Text));
                    if (drUpdate != null)
                    {
                        drUpdate["ename"] = enamet.Text;
                        drUpdate["designation"] = edest.Text;
                        drUpdate["salary"] = esalt.Text;
                        builder.GetUpdateCommand();

                        int r = da.Update(ds, "empDS");
                        if (r != 0)
                        {
                            lbl1.Text = "Record updated successfully!!!";
                            showData();  
                            clearTextBox(); 
                        }
                        else
                        {
                            lbl1.Text = "Record not updated!!!";
                        }
                    }
                    else
                    {
                        lbl1.Text = "Record not found!!!";
                    }
                }
            }
            catch (Exception ex)
            {
                lbl1.Text = "Exception " + ex.Message;
            }
            finally
            {
                conn.Close();
            }
        }

        protected void deleteb_Click(object sender, EventArgs e)
        {
            try
            {
                if (eidt.Text != "")
                {
                    builder = new SqlCommandBuilder(da);

                    DataRow drDelete = ds.Tables["empDS"].Rows.Find(Convert.ToInt32(eidt.Text));

                    drDelete.Delete();

                    builder.GetDeleteCommand();

                    int r = da.Update(ds, "empDS");

                    if (r != 0)
                    {
                        lbl1.Text = "Record deleted successfully!!!";
                        showData();
                        clearTextBox();
                    }
                    else
                    {
                        lbl1.Text = "Record not deleted!!!";
                    }
                }
            }
            catch (Exception ex)
            {
                lbl1.Text = "Exception " + ex.Message;
            }
            finally
            {
                conn.Close();
            }
        }

        protected void searchb_Click(object sender, EventArgs e)
        {
            try
            {
                if (eidt.Text != "")
                {
                    DataRow drSearch = ds.Tables["empDS"].Rows.Find(Convert.ToInt32(eidt.Text));
                    if (drSearch != null)
                    {
                        eidt.Text = drSearch["eid"].ToString();
                        enamet.Text = drSearch["ename"].ToString();
                        edest.Text = drSearch["designation"].ToString();
                        esalt.Text = drSearch["salary"].ToString();
                        lbl1.Text = "Record found!!!";
                    }
                    else
                    {
                        lbl1.Text = "Record not found!!!";
                    }
                }
            }
            catch (Exception ex)
            {
                lbl1.Text = "Exception " + ex.Message;
            }
        }
    }
}
   