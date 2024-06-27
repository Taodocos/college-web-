using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL_YY;
using BOL_YY;
using System.Data;
//using EBA_Validater;
namespace SIMS_YY
{
    public partial class DepartmentRegistration : System.Web.UI.Page
    {

        SIMS depa = new  SIMS();
        int count = 0;
        DataTable dt = new DataTable();
       // ComponentValidator valids = new ComponentValidator();
        DataRow dr;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
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
                searchcollegeRad();
                generateDepartmentCode();

            }
        }

        private void generateDepartmentCode()
        {
            TBL_department[] generatecode = depa.SearchAllDepartment();
            foreach (TBL_department ping in generatecode)
            {
                count++;
            }
            if (count != 0)
            {
                String lastcount = generatecode[count - 1].Department_Code;
                String sub = lastcount.Substring(8);
                int lastcode = Convert.ToInt32(sub);
                lastcode = lastcode + 1;
                String code = "YU_Dept/" + lastcode;
                for (int j = 0; j < count; j++)
                {
                    for (int i = 0; i < count; i++)
                    {
                        if (generatecode[i].Department_Code == code)
                        {
                            lastcode = lastcode + 1;
                            code = "YU_Dept/" + lastcode;

                        }
                    }
                }
                txtdept_code.Text = "YU_Dept/" + lastcode;
                txtdept_code.Enabled = false;
            }
            else
            {
                txtdept_code.Text = "YU_Dept/" + count;
                txtdept_code.Enabled = false;
            }

        }

        private void searchcollegeRad()
        {
            radcollege.DataTextField = "College_Name";
            radcollege.DataValueField = "College_Code";
            radcollege.DataSource = depa.SearchallCollegeRad();
            radcollege.DataBind();
        }

        protected void btn_register_Click(object sender, EventArgs e)
        {
            save();
            ViewState["CurrentData"] = null;
            Gvrecords.Visible = false;
            generateDepartmentCode();
            Gvrecords.Visible = false;
        }

        private void save()
        {
           /* ComponentValidator valids = new ComponentValidator();
            valids.addComponent(txtdept_name, ComponentValidator.TEXT_A_TO_Z_ONLY, true);
          valids.addComponent(radcollege, ComponentValidator.NO_FORMAT, true);
            if (valids.isAllComponenetValid())
            {*/
                if (Gvrecords.Rows.Count > 0)
                {
                    foreach (GridViewRow g1 in Gvrecords.Rows)
                    {
                        string college = (g1.FindControl("lblcollege") as Label).Text;
                        string deptcode = (g1.FindControl("lbldept") as Label).Text;
                        string deptname = (g1.FindControl("lbldeptname") as Label).Text;
                        TBL_department[] checks = depa.checkDepartmentbyName(deptname);
                        if (checks.Count() == 0)
                        {
                            if (depa.addeddepartment(college, deptcode,deptname))
                            {
                                Label3.Text = " Sucessfully registered";
                               
                                 generateCollegeCode();
                            }
                            else
                            {
                                Label3.Text = "Eror occured";
                            }
                        }


                        else
                        {
                            Label3.Text =deptname+ "  " + " Allready registered";
                        }
                    }
                }
    
                else
                {
                  TBL_department[] checks = depa.checkDepartmentbyName(txtdept_name.Text);
                    if (checks.Count() > 0)
                    {
                        Label3.Text = txtdept_name.Text + " " + " Allready registered";
                    }
                    else
                    {

                        if (depa.addeddepartment(radcollege.SelectedValue, txtdept_code.Text, txtdept_name.Text))
                        {
                            Label3.Text = " Sucessfully registered";
                            txtdept_name.Text = "";



                        }
                        else
                        {
                            Label3.Text = "Eror occured";
                        }
                    }
                }
            }
        

        protected void btn_cancel_Click(object sender, EventArgs e)
        {
            txtdept_name.Text = " ";
           
        }

        protected void btnadd_Click(object sender, EventArgs e)
        {
           /* valids.addComponent(txtdept_name, ComponentValidator.TEXT_A_TO_Z_ONLY, true);
            valids.addComponent(radcollege, ComponentValidator.NO_FORMAT, true);
            if (valids.isAllComponenetValid())
            {*/
                //generateCollegeCode();
                if (ViewState["CurrentData"] != null)
                {
                    DataTable dt = (DataTable)ViewState["CurrentData"];
                    int count = dt.Rows.Count;
                    BindGrid(count);
                    String sub = txtdept_code.Text;
                    String sube = sub.Substring(8);
                    int lastcode = Convert.ToInt32(sube);
                    lastcode = lastcode + 1;
                    String code = "YU_Dept/" + lastcode;
                     txtdept_code.Text= code;
                }
                else
                {
                    BindGrid(1);
                    String sub = txtdept_code.Text;
                    String sube = sub.Substring(8);
                    int lastcode = Convert.ToInt32(sube);
                    lastcode = lastcode + 1;
                    String code = "YU_Dept/" + lastcode;
                    txtdept_code.Text = code;
                }

}
            Gvrecords.Visible = true;
            Label3.Text = " ";
        
        private void BindGrid(int rowcount)
        {



            dt.Columns.Add(new System.Data.DataColumn("College_Code", typeof(String)));

            dt.Columns.Add(new System.Data.DataColumn("Department_Code", typeof(String)));


            dt.Columns.Add(new System.Data.DataColumn("Department_name", typeof(String)));


            if (ViewState["CurrentData"] != null)
            {

                for (int i = 0; i < rowcount + 1; i++)
                {

                    dt = (DataTable)ViewState["CurrentData"];

                    if (dt.Rows.Count > 0)
                    {

                        dr = dt.NewRow();

                        dr[0] = dt.Rows[0][0].ToString();



                    }

                }


                dr = dt.NewRow();


                dr[0] = radcollege.SelectedValue;

                dr[1] = txtdept_code.Text;
                dr[2] = txtdept_name.Text;

                dt.Rows.Add(dr);



            }

            else
            {


                dr = dt.NewRow();


                dr[0] = radcollege.SelectedValue;

                dr[1] = txtdept_code.Text;
                dr[2] = txtdept_name.Text;


                dt.Rows.Add(dr);



            }



            // If ViewState has a data then use the value as the DataSource

            if (ViewState["CurrentData"] != null)
            {

                Gvrecords.DataSource = (DataTable)ViewState["CurrentData"];

                Gvrecords.DataBind();

            }

            else
            {

                // Bind GridView with the initial data assocaited in the DataTable

                Gvrecords.DataSource = dt;

                Gvrecords.DataBind();



            }

            // Store the DataTable in ViewState to retain the values

            ViewState["CurrentData"] = dt;



        }
    }}