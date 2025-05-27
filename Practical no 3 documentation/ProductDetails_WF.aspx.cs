using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Practical_no_3_documentation
{
    public partial class ProductDetails_WF : System.Web.UI.Page
    {
        LinqDBEntities db = new LinqDBEntities();

        public void clearTextBox()
        {
            pid.Text = " ";
            pname.Text = " ";
            pprice.Text = " ";
        }

        public void showData()
        {
            try
            {
                var data = db.ProductDetails.ToList();
                if (data.Count == 0)
                {
                    lblMessage.Text = "No data available.";
                }
                table1.DataSource = data;
                table1.DataBind();
            }
            catch (Exception ex)
            {
                lblMessage.Text = "Exception in showData(): " + ex.Message;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            showData();
        }

        protected void add_Click(object sender, EventArgs e)
        {
            try
            {
                ProductDetail pd = new ProductDetail
                {
                    Id = Convert.ToInt32(pid.Text),
                    Name = pname.Text,
                    Price = pprice.Text  
                };

                db.ProductDetails.Add(pd);
                db.SaveChanges();

                lblMessage.Text = "Record added successfully!";
                showData();  // Refresh GridView
                clearTextBox();
            }
            catch (Exception ex)
            {
                lblMessage.Text = "Error: " + ex.Message;
            }
        }


        protected void delete_Click(object sender, EventArgs e)
        {
            try
            {
                int productId = int.Parse(pid.Text); // Convert before using in LINQ
                ProductDetail objDel = db.ProductDetails.SingleOrDefault(p => p.Id == productId);
                if (objDel != null)
                {
                    db.ProductDetails.Remove(objDel);
                    db.SaveChanges();

                    lblMessage.Text = "Record deleted successfully!";
                    showData();
                    clearTextBox();

                }
                else
                {
                    lblMessage.Text = "Record not found!!";
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = "Exception caught!" + ex.Message;
            }
        }

        protected void update_Click(object sender, EventArgs e)
        {
            try
            {
                int productId = Convert.ToInt32(pid.Text);
                ProductDetail objUpdate = db.ProductDetails.SingleOrDefault(p => p.Id == productId);

                if (objUpdate != null)
                {
                    objUpdate.Name = pname.Text;
                    objUpdate.Price = pprice.Text;

                    db.SaveChanges();
                    lblMessage.Text = "Record updated successfully!";
                }
                else
                {
                    lblMessage.Text = "Record not found!";
                }
                showData();
                clearTextBox();
            }
            catch (Exception ex)
            {
                lblMessage.Text = "Error: " + ex.Message;
            }
        }


        protected void search_Click(object sender, EventArgs e)
        {
            try
            {
                int productId = Convert.ToInt32(pid.Text);
                ProductDetail objSearch = db.ProductDetails.SingleOrDefault(p => p.Id == productId);

                if (objSearch != null)
                {
                    pname.Text = objSearch.Name;
                    pprice.Text = objSearch.Price.ToString();
                    lblMessage.Text = "Record found!";
                }
                else
                {
                    lblMessage.Text = "Record not found!";
                    clearTextBox();
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = "Error: " + ex.Message;
            }
        }
    }
}