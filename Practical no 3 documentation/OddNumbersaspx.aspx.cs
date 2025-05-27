using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Practical_no_3_documentation
{
    public partial class OddNumbersaspx : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnFindOdd_Click(object sender, EventArgs e)
        {
            try
            {
                // Get input numbers from TextBox
                string input = txtNumbers.Text;

                // Convert input string to integer array
                int[] numbers = input.Split(',')
                                     .Select(n => Convert.ToInt32(n.Trim()))
                                     .ToArray();

                // Use LINQ to filter odd numbers
                var oddNumbers = numbers.Where(n => n % 2 != 0).ToArray();

                // Display result
                lblResult.Text = oddNumbers.Length > 0
                    ? "Odd Numbers: " + string.Join(", ", oddNumbers)
                    : "No odd numbers found.";
            }
            catch (Exception ex)
            {
                lblResult.Text = "Error: " + ex.Message;
            }
        }
    }
}