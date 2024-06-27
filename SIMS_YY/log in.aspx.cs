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
   public partial class log_in : System.Web.UI.Page
    {
         SIMS log = new SIMS();
        int count = 0;
        int status;
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        private string decryptedpasswored(string encryptedpass)
        {
            byte[] bytes = Convert.FromBase64String(encryptedpass);
            String Decryptedpassword = System.Text.Encoding.Unicode.GetString(bytes);
            return Decryptedpassword;
        }
        private String Encryptpassword(String pass)
        {
            byte[] bytes = System.Text.Encoding.Unicode.GetBytes(pass);
            String Encryptedpassword = Convert.ToBase64String(bytes);
            return Encryptedpassword;
        }

        protected void login_Click(object sender, EventArgs e)
        {
           String decryptedpass = Encryptpassword(pass.Text);
            TBL_User[] che = log.Checkuserlogin(username.Text, decryptedpass);
           // valids.addComponent(username, ComponentValidator.NO_FORMAT, true);
            //valids.addComponent(pass, ComponentValidator.PASSWORD, true);
           // if (valids.isAllComponenetValid())
           // {
                if (che.Count() > 0)
                {
                    if (che[0].Account_type == "Admin")
                    {
                        //string userName = getUserInfo(txtusername.Text);// on header
                        Session["userName"] = username.Text;
                        Session["fname"] = che[0].First_Name + " " + che[0].Middle_Name;
                        Response.Redirect("~/Admin/CreateAccount.aspx");

                    }
                    else if (che[0].Account_type == "Registrar")
                    {
                        //string userName = getUserInfo(txtusername.Text);// on header
                        Session["userName"] = username.Text;
                        Session["fname"] = che[0].First_Name + " " + che[0].Middle_Name;
                        Response.Redirect("~/Registrar/home.aspx");

                    }
                    else if (che[0].Account_type == "Instructor")
                    {
                        //string userName = getUserInfo(txtusername.Text);// on header
                        Session["userName"] = username.Text;
                        Session["fname"] = che[0].First_Name + " " + che[0].Middle_Name;
                        Response.Redirect("~/Instructor/Home.aspx");

                    }

                    else if (che[0].Account_type == "Student")
                    {
                        //string userName = getUserInfo(txtusername.Text);// on header
                        Session["userName"] = username.Text;
                        Session["fname"] = che[0].First_Name + " " + che[0].Middle_Name;
                        Response.Redirect("~/Student/Home.aspx");

                    }
                    /*else if (che[0].Account_type == "Dormitory Manager")
                    {
                        //string userName = getUserInfo(txtusername.Text);// on header
                        Session["userName"] = username.Text;
                        Session["fname"] = che[0].First_Name + " " + che[0].Middle_Name;
                        Response.Redirect("~/Dormitory/BuildingRegistration.aspx");

                    }*/

                }
                else
                {
                    lbl2.Text = "wrong password";
                }
            }
        }

        }
           

        
    
