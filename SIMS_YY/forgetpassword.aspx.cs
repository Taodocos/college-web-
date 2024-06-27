using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SIMS_YY
{
    public partial class change_password : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnsave_Click(object sender, EventArgs e)
        {
            if (TextBox3.Text.Trim() != TextBox2.Text.Trim())
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Retype two password fields does not match');", true);
            }
            else
            {
                string pass = Encrypt(TextBox2.Text);
                if (cngpassword.changePassword(TextBox1.Text, pass))
                {
                    HttpContext.Current.Response.Write("<script> alert('Change Successful');</script>");
                }
                else
                {
                    HttpContext.Current.Response.Write("<script> alert('Change not Successful');</script>");
                }
            }

           
        }
        public string Encrypt(String enc)
        {
            Byte[] Bytes = System.Text.Encoding.Unicode.GetBytes(enc);
            String encpass = Convert.ToBase64String(Bytes);
            return encpass;
        }

        
    }
}