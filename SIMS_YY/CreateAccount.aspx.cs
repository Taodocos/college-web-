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
        SIMS account = new SIMS();
        int count = 0;
        String uid;

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                radcollege.Visible = false;
                raddept.Visible = false;
                //generatuserid();

            }
            try
            {
                if (Session["userName"] != null)
                {

                }
                else
                {
                    Response.Redirect("../Home.aspx");
                }
            }
            catch (Exception ex)
            {

            }

        }

        private void SearchCollege()
        {
            radcollege.DataTextField = "College_Name";
            radcollege.DataValueField = "College_Code";
            radcollege.DataSource = account.SearchallCollegeRad();
            radcollege.DataBind();
        }
        private String Encryptpassword(String pass)
        {
            byte[] bytes = System.Text.Encoding.Unicode.GetBytes(pass);
            String Encryptedpassword = Convert.ToBase64String(bytes);
            return Encryptedpassword;
        }
        private void searchdepartment()
        {
            raddept.DataTextField = "Department_name";
            raddept.DataValueField = "Department_Code";
            raddept.DataSource = account.searchalldepartmentbycollege(radcollege.SelectedValue);
            raddept.DataBind();
        }



        protected void radacounttype_SelectedIndexChanged(object sender, EventArgs e)
        {
            label.Text = " ";
            txtfname.Text = txtfname.Text ;
            txtmname.Text  = txtmname.Text ;
            txtlname.Text  = txtlname.Text ;
            txtusername.Text  = txtusername.Text ;
            if (radacounttype.SelectedValue == "Registrar" || radacounttype.SelectedValue == "Admin")
            {
                radcollege.Visible = false;
                raddept.Visible = false;
                txtfname.Visible = true;
                txtmname.Visible = true;
                txtlname.Visible = true;
                txtusername.Visible = true;
                txtpassword.Visible = true;
                txtconfirmpass.Visible = true;
                radsex.Visible = true;

            }
            else if (radacounttype.SelectedValue == "Student")
            {
                radcollege.Visible = false;
                raddept.Visible = false;
                txtfname.Visible = false;
                txtmname.Visible = false;
                txtlname.Visible = false;
                txtusername.Visible = false;
                txtpassword.Visible = false;
                txtconfirmpass.Visible = false;
                radsex.Visible = false;


            }
            else if (radacounttype.SelectedValue == "Instructor")
            {
                SearchCollege();
                radcollege.Visible = true;
                raddept.Visible = true;
                txtfname.Visible = true;
                txtmname.Visible = true;
                txtlname.Visible = true;
                txtusername.Visible = true;
                txtpassword.Visible = true;
                txtconfirmpass.Visible = true;
                radsex.Visible = true;

            }
        }
        protected void radcollege_SelectedIndexChanged(object sender, EventArgs e)
        {
            TBL_department[] dept = account.searchalldepartmentbycollege(radcollege.SelectedValue);
            label.Text = "";
            if (dept.Count() > 0)
            {
                // radcollege.Text = dept[0].College_Code;
                searchdepartment();

            }
            else
            {
                label.Text = "this college no department";
            }
        }

        void generatuserid()
        {
            count = 0;
            TBL_User[] userid = account.searchalluser();

            foreach (TBL_User ping in userid)
            {
                count++;
            }
            if (count != 0)
            {
                String lastcount = userid[count - 1].UserID;
                String sub = lastcount.Substring(4);
                int lastcode = Convert.ToInt32(sub);
                lastcode = lastcode + 1;
                String code = "user" + lastcode;
                String uid = code;
                for (int i = 0; i < count; i++)
                {
                    for (int j = 0; j < count; j++)
                    {
                        if (userid[j].UserID == uid)
                        {
                            String get = uid.Substring(4);
                            int getid = Convert.ToInt32(get);
                            getid = getid + 1;
                            uid = "user" + getid;

                        }
                    }
                }

            }
            else
            {
                String uid = "user" + count;
                //txtcollege_code.Enabled = false;
            }

        }
        void save()
        {
            generatuserid();
            if (radacounttype.SelectedValue == "Student")
            {
                TBL_FreshStudent[] stu = account.searchAllFreshStudent();

                for (int j = 0; j < stu.Count(); j++)
                {

                    String fname = stu[j].first_name;
                    String id = stu[j].Stud_ID;
                    String username = fname.Substring(0, 3) + id;
                    String pa = fname.Substring(0, 1);
                    String two = fname.Substring(1, 2);
                    String cap = pa.ToUpper();
                    String password = cap + two + "@" + id;
                    // String email=stu[j].first_name+stu[j].middle_name+"@"+"gmail.com";
                    TBL_User[] chek = account.checkaccount(username);
                    String pass = Encryptpassword(password);
                    if (chek.Count() <= 0)
                    {
                        account.createaccount(uid, stu[j].first_name, stu[j].middle_name, stu[j].last_name, radacounttype.SelectedValue, username, pass, stu[j].sex, stu[j].college, stu[0].department);
                        String studid = uid.Substring(4);
                        int studidno = Convert.ToInt32(studid);
                        studidno = studidno + 1;
                        uid = "user" + studidno;
                        label.Text = "All student account Created Successfully ";
                    }
                    else
                    {
                        label.Text = "All student account Allready Created ";
                    }



                }

            }
            else if (radacounttype.SelectedValue == "Instructor")
            {
/*
                valids.addComponent(txtpassword, ComponentValidator.PASSWORD, true);
                valids.addComponent(txtconfirmpass, ComponentValidator.PASSWORD, true);
                valids.addComponent(txtfname, ComponentValidator.PERSON_NAME, true);
                valids.addComponent(txtmname, ComponentValidator.PERSON_NAME, true);
                valids.addComponent(txtlname, ComponentValidator.PERSON_NAME, true);
                valids.addComponent(txtusername, ComponentValidator.NO_FORMAT, true);
                valids.addComponent(radsex, ComponentValidator.NO_FORMAT, true);
                valids.addComponent(radcollege, ComponentValidator.NO_FORMAT, true);
                valids.addComponent(raddept, ComponentValidator.NO_FORMAT, true);
                if (valids.isAllComponenetValid())
                {*/
                    TBL_User[] chek = account.checkaccount(txtusername.Text);
                    if (chek.Count() <= 0)
                    {
                        if (txtpassword.Text == txtconfirmpass.Text)
                        {
                            String pass = Encryptpassword(txtpassword.Text);
                            if (account.createaccount(uid, txtfname.Text, txtmname.Text, txtlname.Text, radacounttype.SelectedValue, txtusername.Text, pass, radsex.SelectedValue, radcollege.SelectedValue, raddept.SelectedValue))
                            {
                                label.Text = "Account Created successfully";
                            }
                            else
                            {
                                label.Text = "Error Occurred";
                            }
                        }
                        else
                        {
                            label.Text = "password dosen't match";
                        }
                    }
                    else
                    {
                        label.Text = "username all ready exist try again ";
                    }
                }
            
            else if (radacounttype.SelectedValue == "Registrar" || radacounttype.SelectedValue == "Admin")
            {

                /*valids.addComponent(txtpassword, ComponentValidator.PASSWORD, true);
                valids.addComponent(txtconfirmpass, ComponentValidator.PASSWORD, true);
                valids.addComponent(txtfname, ComponentValidator.PERSON_NAME, true);
                valids.addComponent(txtmname, ComponentValidator.PERSON_NAME, true);
                valids.addComponent(txtlname, ComponentValidator.PERSON_NAME, true);
                valids.addComponent(txtusername, ComponentValidator.NO_FORMAT, true);
                valids.addComponent(radsex, ComponentValidator.NO_FORMAT, true);
                //valids.addComponent(radcollege, ComponentValidator.NO_FORMAT, true);
                //valids.addComponent(raddept, ComponentValidator.NO_FORMAT, true);
                if (valids.isAllComponenetValid())
                {*/
                    TBL_User[] chek = account.checkaccount(txtusername.Text);
                    if (chek.Count() <= 0)
                    {
                        if (txtpassword.Text == txtconfirmpass.Text)
                        {
                            String pass = Encryptpassword(txtpassword.Text);
                            if (account.createaccount(uid, txtfname.Text, txtmname.Text, txtlname.Text, radacounttype.SelectedValue, txtusername.Text, pass, radsex.SelectedValue, "null", "null"))
                            {
                                label.Text = "Account Created successfully";
                            }
                            else
                            {
                                label.Text = "Error Occurred";
                            }
                        }
                        else
                        {
                            label.Text = "password dosen't match";
                        }
                    }
                    else
                    {
                        label.Text = "username all ready exist try again ";
                    }
              
            
        }}

 protected void btn_register_Click(object sender, EventArgs e)
        {
         save();
            generatuserid();
         
        }
 protected void btn_cancel_Click(object sender, EventArgs e)
        {
         label.Text = " ";
            txtfname.Text  = txtfname.Text ;
            txtmname.Text  = txtmname.Text ;
            txtlname.Text  = txtlname.Text ;
            txtusername.Text  = txtusername.Text ;
            txtpassword.Text =  txtpassword.Text ;
            txtconfirmpass.Text = txtconfirmpass.Text ;
        }
    }
}
    //}
        
    

    