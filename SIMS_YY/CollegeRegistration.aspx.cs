using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL_YY;
using BOL_YY;
using System.Data;
namespace SIMS_YY
{
    public partial class and : System.Web.UI.Page
    {
        SIMS stud = new SIMS();
        DataTable dt = new DataTable();

        DataRow dr;
        int i = 0;
        int count = 0;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                generateCollegeCode();
                try
                {
                    if (Session["userName"] == null)
                    {
                        Response.Redirect("../Login.aspx");

                    }
                    else
                    {
                        //lbl.Text = " User:" + Session["userName"].ToString();
                    }
                }
                catch (Exception ex)
                {

                }
            }
        }

        protected void btnadd_Click(object sender, EventArgs e)
        {

        }

        protected void btn_register_Click(object sender, EventArgs e)
        {
            save();
            ViewState["CurrentData"] = null;
            Gvrecords.Visible = false;
            generateCollegeCode();
        }

        protected void btn_cancel_Click(object sender, EventArgs e)
        {

            txtCollege_name.Text = "";
        }
        void save()
        {

            //ComponentValidator valids = new ComponentValidator();
            //valids.addComponent(txtCollege_name, ComponentValidator.TEXT_A_TO_Z_ONLY, true);
            // valids.addComponent(txtcollege_code, ComponentValidator.NO_FORMAT, true);

            //if (valids.isAllComponenetValid())
            //{
            if (Gvrecords.Rows.Count > 0)
            {
                foreach (GridViewRow g1 in Gvrecords.Rows)
                {
                    string id = (g1.FindControl("lblId") as Label).Text;
                    string name = (g1.FindControl("lblName") as Label).Text;
                    TBL_college[] checks = stud.checkAllcollegebyName(name);
                    if (checks.Count() == 0)
                    {
                        if (stud.addcollege(id, name))
                        {
                            Label3.Text = "Sucessfully registered";
                            txtCollege_name.Text = "";
                            txtcollege_code.Text = "";
                            // generateCollegeCode();
                        }
                        else
                        {
                            Label3.Text = "Eror occured";
                        }
                    }


                    else
                    {
                        txtCollege_name.Text = " ";
                    }
                }
            }
            else
            {
                TBL_college[] check2 = stud.checkAllcollegebyName(txtCollege_name.Text);
                if (check2.Count() > 0)
                {
                    Label3.Text = "All Ready Registered";
                    txtCollege_name.Text = "";
                }
                else
                {
                    if (stud.addcollege(txtcollege_code.Text, txtCollege_name.Text))
                    {
                        Label3.Text = "Sucessfully registered";
                        txtCollege_name.Text = "";
                        txtcollege_code.Text = "";
                        // generateCollegeCode();
                    }
                    else
                    {
                        Label3.Text = "Eror occured";
                    }
                }
            }

        }


        void generateCollegeCode()
        {
            TBL_college[] generatecode = stud.SearchAllCollege();
            foreach (TBL_college ping in generatecode)
            {
                count++;
            }
            if (count != 0)
            {
                String lastcount = generatecode[count - 1].College_Code;
                String sub = lastcount.Substring(11);
                int lastcode = Convert.ToInt32(sub);
                lastcode = lastcode + 1;
                String code = "YU_College-" + lastcode;
                for (int j = 0; j < count; j++)
                {
                    for (int i = 0; i < count; i++)
                    {
                        if (generatecode[i].College_Code == code)
                        {
                            lastcode = lastcode + 1;
                            code = "YU_College-" + lastcode;

                        }
                    }

                }
                txtcollege_code.Text = "YU_College-" + lastcode;
                txtcollege_code.Enabled = false;

            }
            else
            {
                txtcollege_code.Text = "YU_College-" + count;
                txtcollege_code.Enabled = false;
            }

        }





        protected void TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

    }
}