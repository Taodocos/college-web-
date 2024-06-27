using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL_YY;
using BOL_YY;
namespace SIMS_YY
{
    public partial class create_account : System.Web.UI.Page
    {
        SIMS sims = new SIMS();
        int count = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            TextBox1.Enabled = true;
            TextBox2.Enabled = true;
            TextBox3.Enabled = true;
            TextBox4.Enabled = true;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int s = 0;
            if (TextBox2.Text.Trim() != TextBox3.Text.Trim())
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Retype two password fields does not match');", true);
                // Response.Redirect("~/Actors/Applicant/NewApplicantAccount.aspx");
            }
            else
            {
                if (DropDownList2.SelectedValue == "Active")
                {
                    s = 1;
                }
                else if (DropDownList2.SelectedValue == "Deactive")
                {
                    s = 0;
                }
                String password = Encrypt(TextBox2.Text);
                String cpassword = Encrypt(TextBox3.Text);
                //   SearchUsernameById
                sims.Add_User(DropDownList1.SelectedValue, TextBox1.Text, password, cpassword, TextBox4.Text, s);

                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Account Created');", true);
                Response.Redirect("create%20account.aspx");
            }


        }


        void save()
        {
            int s = 0;

            if (DropDownList2.SelectedValue == "Active")
            {
                s = 1;
            }
            else if (DropDownList2.SelectedValue == "Deactive")
            {
                s = 0;
            }
            if (DropDownList1.SelectedValue == "Student")
            {
                TBL_Stud_Admission[] stud = sims.searchallstud();
                for (int j = 0; j < stud.Count(); j++)
                {

                    TextBox1.Enabled = false;
                    TextBox2.Enabled = false;
                    TextBox3.Enabled = false;
                    TextBox4.Enabled = false;
                    String fname = stud[j].Full_Name;
                    String id = stud[j].Stud_Id;
                    String pa = fname.Substring(0, 1);
                    String pm = fname.Substring(1, 2);
                    String cpa = pa.ToUpper();
                    String dpassword = cpa + pm + "@" + id;
                    String uname = fname.Substring(0, 3) + id;

                    TextBox1.Text = uname;
                    TextBox2.Text = dpassword;
                    TextBox3.Text = dpassword;
                    sims.Add_User(uname, dpassword, dpassword, TextBox4.Text, DropDownList1.SelectedValue, s);
                }

            }
        }
        public string Encrypt(String enc)
        {
            Byte[] Bytes = System.Text.Encoding.Unicode.GetBytes(enc);
            String encpass = Convert.ToBase64String(Bytes);
            return encpass;
        }


        /*TBL_UserAccount[] check = sims.checkuserbyname(TextBox1.Text);
            if (check.Count() == 0)
            {

                if (sims.Add_User(TextBox1.Text, TextBox3.Text, TextBox4.Text, TextBox2.Text, DropDownList1.SelectedItem, DropDownList2.SelectedItem ))
                {
                    if (DropDownList2.SelectedValue == "Activate")
                    {
                        DropDownList2 = 1;
                    }
                    else if (DropDownList2.SelectedValue == "Deactivate")
                    {
                        DropDownList2 = 0;
                    }
                    lbltxt.Text = "succesful registered";
                }
                else
                {
                    lbltxt.Text = "error occur";
                }

            }
            else
            {
                lbltxt.Text = TextBox2.Text + " " + "already registered";
            }*/










        //protected void TextBox1_TextChanged(object sender, EventArgs e)
        //{


    }
}
    //}
        //}
    

    