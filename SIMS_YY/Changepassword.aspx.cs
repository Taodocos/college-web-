using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BOL_YY;
using BLL_YY;
namespace SIMS_YY
{
    public partial class Changepassword : System.Web.UI.Page
    {
        SIMS change = new SIMS();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["userName"] != null)
                {

                }
                else
                {
                    Response.Redirect("../Index.aspx");
                }
            }
            catch (Exception ex)
            {

            }
        }
        private String Encryptpassword(String pass)
        {
            byte[] bytes = System.Text.Encoding.Unicode.GetBytes(pass);
            String Encryptedpassword = Convert.ToBase64String(bytes);
            return Encryptedpassword;
        }

        void updatedPASS()
        {
            String newpass = Encryptpassword(txtnpassword.Text);
            String confpass = Encryptpassword(txtconfpass.Text);
            String username = Session["userName"].ToString();
            if (newpass == confpass)
            {
                if (change.updatedpassword(newpass, username))
                {
                    label.Text = "Password Changed succesfully";
                    //txtconfpass.Text = "";
                    //txtcpassword.Text = "";
                    //txtnpassword.Text = "";
                }
                else
                {
                    label.Text = "Error occured";
                }

            }
            else
            {
                label.Text = "password dosen't match";
            }
        }


        protected void btnchangepassword_Click(object sender, EventArgs e)
        {
            String username = Session["userName"].ToString();
            TBL_User[] chan = change.changepassword(username);
        }

        protected void btncancel_Click(object sender, EventArgs e)
        {

        }

    }
}