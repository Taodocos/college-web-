using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL_YY;
namespace SIMS_YY
{
    public partial class instuctor_addmi : System.Web.UI.Page
    {
        SIMS sims = new SIMS();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            sims.Add_Instructor(TextBox3.Text, txbf.Text, DateTime.Parse(tbod.Text), TextBox1.Text, TextBox2.Text, DropDownList1.Text, dd1.Text, TextBox5.Text, TextBox4.Text);
        }
    }
}