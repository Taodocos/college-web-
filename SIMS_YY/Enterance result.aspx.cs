using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL_YY;
namespace SIMS_YY
{
    public partial class Enterance_result : System.Web.UI.Page
    {
        SIMS sims = new SIMS();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            //sims.Add_Enterance_result(TextBox4.Text,Decimal.Parse(TextBox1.Text),TextBox2.Text, DateTime.Parse(TextBox3.Text));
        }
    }
}