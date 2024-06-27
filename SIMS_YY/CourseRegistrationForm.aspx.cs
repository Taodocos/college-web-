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
    public partial class course : System.Web.UI.Page
    {
        SIMS cou = new SIMS();
        int count = 0;
        DataTable dt = new DataTable();
        int TotalCredithour = 0;
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
                        //  lbl.Text = " User:" + Session["userName"].ToString();
                    }
                }
                catch (Exception ex)
                {

                }
                SearchCollege();

            }
        }

        private void SearchCollege()
        {
            radcollege.DataTextField = "College_Name";
            radcollege.DataValueField = "College_Code";
            radcollege.DataSource = cou.SearchallCollegeRad();
            radcollege.DataBind();
        }
        private void searchdepartment()
        {
            raddept.DataTextField = "Department_name";
            raddept.DataValueField = "Department_Code";
            raddept.DataSource = cou.searchalldepartmentbycollege(radcollege.SelectedValue);
            raddept.DataBind();
        }
        private void generateCourseCode()
        {
            TBL_Course[] generatecoursecode = cou.searchallcourse();
            String deptname = raddept.Text;
            int index = deptname.LastIndexOf(' ');
            String first = deptname.Substring(0, 1);
            String second = deptname.Substring(index + 1, 3);
            foreach (TBL_Course ping in generatecoursecode)
            {
                count++;
            }
            if (count != 0)
            {
                String lastcount = generatecoursecode[count - 1].Course_code;
                String sub = lastcount.Substring(4);
                int lastcode = Convert.ToInt32(sub);
                lastcode = lastcode + 1;

                if (index <= 0)
                {
                    String code = deptname.Substring(0, 4) + lastcode;
                    for (int j = 0; j < count; j++)
                    {
                        if (generatecoursecode[j].Course_code == code)
                        {
                            lastcode = lastcode + 1;
                            code = first + second + lastcode;
                        }
                    }
                    txtcoursecode.Text = first + second + lastcode;
                }
                else
                {
                    String code = first + second + lastcode;
                    for (int j = 0; j < count; j++)
                    {
                        for (int i = 0; i < count; i++)
                        {
                            if (generatecoursecode[i].Course_code == code)
                            {
                                lastcode = lastcode + 1;
                                code = first + second + lastcode;
                            }
                        }
                    }
                    txtcoursecode.Text = first + second + lastcode;
                }
                txtcoursecode.Enabled = false;
            }
            else
            {
                if (index <= 0)
                {
                    txtcoursecode.Text = deptname.Substring(0, 4) + count;
                }
                else
                {
                    txtcoursecode.Text = first + second + count;
                }
                txtcoursecode.Enabled = false;
            }

        }

        protected void btnadd_Click(object sender, EventArgs e)
        {
            /* valids.addComponent(radcollege, ComponentValidator.NO_FORMAT, true);
            valids.addComponent(raddept, ComponentValidator.NO_FORMAT, true);
            valids.addComponent(radyear, ComponentValidator.NO_FORMAT, true);
            valids.addComponent(radsemister, ComponentValidator.NO_FORMAT, true);
            valids.addComponent(txtcoursename, ComponentValidator.TEXT_A_TO_Z_ONLY, true);
            valids.addComponent(txtcoursecode, ComponentValidator.NO_FORMAT, true);
            valids.addComponent(txtcredithour, ComponentValidator.INTEGER_NUMBER, true);
            if (valids.isAllComponenetValid())
           
               */
                //generateCollegeCode();
                if (ViewState["CurrentData"] != null)
                {
                    DataTable dt = (DataTable)ViewState["CurrentData"];
                    int count = dt.Rows.Count;
                    BindGrid(count);
                    String sub = txtcoursecode.Text;
                    String sube = sub.Substring(4);
                    int lastcode = Convert.ToInt32(sube);
                    lastcode = lastcode + 1;
                    String code = sub.Substring(0,4) + lastcode;
                    txtcoursecode.Text = code;
                }
                else
                {
                    BindGrid(1);
                    String sub = txtcoursecode.Text;
                    String sube = sub.Substring(4);
                    int lastcode = Convert.ToInt32(sube);
                    lastcode = lastcode + 1;
                    String code = sub.Substring(0, 4) + lastcode;
                    txtcoursecode.Text = code;
                }
                Gvrecords.Visible = true;
                label.Text = " ";
            }

        protected void btn_cancel_Click(object sender, EventArgs e)
        {
            txtcredithour.Text = " ";
            txtcoursename.Text = " ";
        }

        
        private void BindGrid(int rowcount)
        {



            dt.Columns.Add(new System.Data.DataColumn("College_code", typeof(String)));

            dt.Columns.Add(new System.Data.DataColumn("Department_code", typeof(String)));

            dt.Columns.Add(new System.Data.DataColumn("Course_code", typeof(String)));

            dt.Columns.Add(new System.Data.DataColumn("Course_name", typeof(String)));

            dt.Columns.Add(new System.Data.DataColumn("Credit_hour", typeof(String)));

            dt.Columns.Add(new System.Data.DataColumn("Year", typeof(String)));
            dt.Columns.Add(new System.Data.DataColumn("Semister", typeof(String)));

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


                dr = dt.NewRow();


                dr[0] = radcollege.SelectedValue;

                dr[1] = raddept.SelectedValue ;
                dr[2] = txtcoursecode.Text;
                dr[3] = txtcoursename.Text;
                dr[4] = txtcredithour.Text;
                dr[5] = radyear.SelectedValue;
                dr[6] = radsemister.SelectedValue;

                dt.Rows.Add(dr);



            }}

            else
            {


                dr = dt.NewRow();


                dr[0] = radcollege.SelectedValue;

                dr[1] = raddept.SelectedValue;
                dr[2] = txtcoursecode.Text;
                dr[3] = txtcoursename.Text;
                dr[4] = txtcredithour.Text;
                dr[5] = radyear.SelectedValue;
                dr[6] = radsemister.SelectedValue;



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

       

       
            protected void btn_register_Click(object sender, EventArgs e)
        {
            save();
            ViewState["CurrentData"] = null;
            Gvrecords.Visible = false;
            generateCourseCode();
            Gvrecords.Visible = false;
        }

        private void save()
        {
      
           /* valids.addComponent(radcollege, ComponentValidator.NO_FORMAT, true);
            valids.addComponent(raddept, ComponentValidator.NO_FORMAT, true);
            valids.addComponent(radyear, ComponentValidator.NO_FORMAT, true);
            valids.addComponent(radsemister, ComponentValidator.NO_FORMAT, true);
            valids.addComponent(txtcoursename, ComponentValidator.TEXT_A_TO_Z_ONLY, true);
            valids.addComponent(txtcoursecode, ComponentValidator.NO_FORMAT, true);
            valids.addComponent(txtcredithour, ComponentValidator.INTEGER_NUMBER, true);
            if (valids.isAllComponenetValid())
            {
}*/
                try 
                {
                    if (Gvrecords.Rows.Count >0)
                    {
                       
                        foreach (GridViewRow g1 in Gvrecords.Rows)
                        {
                            string college = (g1.FindControl("lblcollege") as Label).Text;
                            string dept = (g1.FindControl("lbldept") as Label).Text;
                            string ccode = (g1.FindControl("lblcoursecode") as Label).Text;
                            string cname = (g1.FindControl("lblcourseName") as Label).Text;
                            int credit = Convert.ToInt32((g1.FindControl("lblcredithour") as Label).Text);
                            string year = (g1.FindControl("lblyear") as Label).Text;
                            string semister = (g1.FindControl("lblsemister") as Label).Text;
                            TBL_Course[] check = cou.checkcoursebyname(cname, dept);
                            TBL_Course[] chour = cou.searchcredithour(dept, year, semister);
                            if (check.Count() == 0)
                            {
                                TotalCredithour = 0;
                                for (int i = 0; i < chour.Count(); i++)
                                {
                                    TotalCredithour = TotalCredithour + Convert.ToInt32(chour[i].Credit_hour);
                                }
                                int c = Convert.ToInt32(credit);
                                if ((TotalCredithour + c) > 23)
                                {
                                    label.Text = "Total Credithour in this department Greater than 23 so we havn't register please select next semister ";
                                }
                                else
                                {
                                    if (cou.courseregster(college, dept, ccode, cname, credit, year, semister))
                                    {
                                        label.Text = "Sucessfully registered";
                                        txtcredithour.Text = " ";
                                        txtcoursename.Text = " ";
                                        // generateCollegeCode();
                                    }
                                    else
                                    {
                                        label.Text = "Eror occured";
                                    }
                                }
                                TotalCredithour = 0;
                            }

                            else
                            {
                                label.Text = cname + " " + " Allready registered";
                            }
                        }
                    }
                    else
                    {
                        TBL_Course[] checks = cou.checkcoursebyname(txtcoursename.Text, raddept.SelectedValue);
                        TBL_Course[] chour = cou.searchcredithour(raddept.SelectedValue, radyear.SelectedValue, radsemister.SelectedValue);
                        for (int i = 0; i < chour.Count(); i++)
                        {
                            TotalCredithour = TotalCredithour + Convert.ToInt32(chour[i].Credit_hour);
                        }
                        int c = Convert.ToInt32(txtcredithour.Text);
                        if (TotalCredithour+c > 23)
                        {
                            label.Text ="Total Credithour in this department Greater than 23 so we havn't register please select next semister ";
                        }
                        else
                        {
                            if (checks.Count() > 0)
                            {
                                label.Text = txtcoursename.Text + " " + " Allready registered";
                                //SearchCollege();
                                // searchdepartment();
                                //txtcoursecode.Text = "";
                                txtcredithour.Text = " ";
                                txtcoursename.Text = " ";


                            }
                            else
                            {
                                if (cou.courseregster(radcollege.SelectedValue, raddept.SelectedValue, txtcoursecode.Text, txtcoursename.Text, Convert.ToInt32(txtcredithour.Text), radyear.SelectedValue, radsemister.SelectedValue))
                                {
                                    SearchCollege();
                                    //searchdepartment();
                                    //txtcoursecode.Text = "";
                                    txtcoursename.Text = " ";
                                    txtcredithour.Text = " ";
                                    // radyear.Text = radyear.EmptyMessage;
                                    // radsemister.Text = radsemister.EmptyMessage;
                                    label.Text = "Register Successfully";
                                    //generateCourseCode();

                                }
                                else
                                {
                                    label.Text = "Error Occured";
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    
                }

            }
        

        protected void radcollege_SelectedIndexChanged(object sender, EventArgs e)
        {
            TBL_department[] dept = cou.searchalldepartmentbycollege(radcollege.SelectedValue);
            label.Text = "";
            label.Text = " ";
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

        protected void raddept_SelectedIndexChanged(object sender, EventArgs e)
        {
            label.Text = " ";
            generateCourseCode();
        }
        }
    }

