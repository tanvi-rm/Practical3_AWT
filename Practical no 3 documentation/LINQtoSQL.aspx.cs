using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Practical_no_3_documentation
{
    public partial class LINQtoSQL : System.Web.UI.Page
    {
        public void clearTextBox()
        {
            eidt.Text = " ";
            enamet.Text = " ";
            edest.Text = " ";
            esalt.Text = " ";
        }
        DataClasses1DataContext dc = new DataClasses1DataContext();
        public void showData()
        {
            try
            {
                var q = from a in dc.GetTable<emp_info>() select a;

                empTable.DataSource = q;
                empTable.DataBind();
            }
            catch (Exception ex)
            {
                lbl1.Text = "Exception caught!" + ex.Message;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            showData();
        }

        protected void addb_Click(object sender, EventArgs e)
        {
            try
            {
                emp_info objAdd = new emp_info();

                objAdd.eid = Convert.ToByte(eidt.Text);
                objAdd.ename = Convert.ToString(enamet.Text);
                objAdd.designation = Convert.ToString(edest.Text);
                objAdd.salary = Convert.ToString(esalt.Text);

                dc.emp_infos.InsertOnSubmit(objAdd);

                dc.SubmitChanges();

                lbl1.Text = "Record inserted successfully!!!";
                clearTextBox();
            }
            catch (Exception ex)
            {
                lbl1.Text = "Exception caught!" + ex.Message;
            }
            showData();
        }

        protected void deleteb_Click(object sender, EventArgs e)
        {
            try
            {
                emp_info objDel = dc.emp_infos.Single(emp_info => emp_info.eid == Convert.ToInt16(eidt.Text));
                if (objDel != null)
                {
                    dc.emp_infos.DeleteOnSubmit(objDel);

                    dc.SubmitChanges();
                    lbl1.Text = "Record deleted successfully!";
                }
                else
                {
                    lbl1.Text = "Record not found!!";
                }
                clearTextBox();
            }
            catch (Exception ex)
            {
                lbl1.Text = "Exception caught!" + ex.Message;
            }
            showData();
        }

        protected void updateb_Click(object sender, EventArgs e)
        {
            try
            {
                emp_info objUpdate = dc.emp_infos.Single(emp_info => emp_info.eid == Convert.ToInt16(eidt.Text));

                if (objUpdate != null)
                {
                    objUpdate.ename = Convert.ToString(enamet.Text);
                    objUpdate.designation = Convert.ToString(edest.Text);
                    objUpdate.salary = Convert.ToString(esalt.Text);

                    dc.SubmitChanges();

                    lbl1.Text = "Record updated successfully!";
                }
                else
                {
                    lbl1.Text = "Record not found!!";
                }
                clearTextBox();
            }
            catch (Exception ex)
            {
                lbl1.Text = "Exception caught!" + ex.Message;
            }
            showData();
        }

        protected void searchb_Click(object sender, EventArgs e)
        {
            try
            {
                emp_info objSearch = dc.emp_infos.Single(emp_info => emp_info.eid == Convert.ToInt16(eidt.Text));

                if (objSearch != null)
                {
                    eidt.Text = Convert.ToString(objSearch.eid);
                    enamet.Text = objSearch.ename;
                    edest.Text = objSearch.designation;
                    esalt.Text = objSearch.salary;

                    lbl1.Text = "Record found!!";
                }
                else
                {
                    lbl1.Text = "Record not found!!!";
                }
            }
            catch (Exception ex)
            {
                lbl1.Text = "Exception caught! " + ex.Message;
            }
            showData();
        }
    }
}