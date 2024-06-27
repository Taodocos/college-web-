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
    public partial class stud_regist : System.Web.UI.Page
    {
        SIMS sims= new SIMS();
        DataTable dt = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                SearchCollege();
                Image2.Visible = false;
                date.Visible = false;
                name.Visible = false;
                ageandsex.Visible = false;
                region.Visible = false;
                RadGrid1.Visible = false;
                anames.Visible = false;
                regi.Visible = false;
                sign.Visible = false;
                note.Visible = false;
                no.Visible = false;
              String id=  Session["userName"].ToString();
              String studid = id.Substring(3);
              txtstudid.Text = studid;
              txtstudid.Enabled = false;
            }
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

        protected void btn_register_Click(object sender, EventArgs e)
        {
            {
            Save();
        }}
        private void SearchCollege()
        {
            radcollege.DataTextField = "College_Name";
            radcollege.DataValueField = "College_Code";
            radcollege.DataSource = sims.SearchallCollegeRad();
            radcollege.DataBind();
        }
        private void searchdepartment()
        {
            raddept.DataTextField = "Department_name";
            raddept.DataValueField = "Department_Code";
            raddept.DataSource = sims.searchalldepartmentbycollege(radcollege.SelectedValue);
            raddept.DataBind();
        }

        protected void radcollege_SelectedIndexChanged(object sender, EventArgs e)
        {
            TBL_department[] dept = sims.searchalldepartmentbycollege(radcollege.SelectedValue);
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
            Image2.Visible = false;
            date.Visible = false;
            name.Visible = false;
            ageandsex.Visible = false;
            region.Visible = false;
            RadGrid1.Visible = false;
            anames.Visible = false;
            regi.Visible = false;
            sign.Visible = false;
            note.Visible = false;
            no.Visible = false;
        }

        protected void raddept_SelectedIndexChanged(object sender, EventArgs e)
        {
            Image2.Visible = false;
            date.Visible = false;
            name.Visible = false;
            ageandsex.Visible = false;
            region.Visible = false;
            RadGrid1.Visible = false;
            anames.Visible = false;
            regi.Visible = false;
            sign.Visible = false;
            note.Visible = false;
            no.Visible = false;
        }
        private void Save()
        {
            int ethipiayr;
            string currentMonth = DateTime.Now.Month.ToString();
            string currentYear = DateTime.Now.Year.ToString();
            int month = Convert.ToInt32(currentMonth);
            int year = Convert.ToInt32(currentYear);
            DateTime regdate = DateTime.Now;

            if (month < 9)
            {
                ethipiayr = year - 8;

            }
            else
            {
                ethipiayr = year - 7;
            }

           /* valids.addComponent(txtfname, ComponentValidator.PERSON_NAME, true);
            valids.addComponent(txtlname, ComponentValidator.PERSON_NAME, true);
            valids.addComponent(txtmname, ComponentValidator.PERSON_NAME, true);
            valids.addComponent(radcollege, ComponentValidator.NO_FORMAT, true);
            valids.addComponent(raddept, ComponentValidator.NO_FORMAT, true);
            valids.addComponent(txtage, ComponentValidator.INTEGER_NUMBER, true);
            valids.addComponent(radsex, ComponentValidator.NO_FORMAT, true);
            valids.addComponent(radsemister, ComponentValidator.NO_FORMAT, true);
            valids.addComponent(txtnational, ComponentValidator.TEXT_A_TO_Z_ONLY, true);
            valids.addComponent(txtzone, ComponentValidator.TEXT_A_TO_Z_ONLY, true);
            valids.addComponent(radyear, ComponentValidator.NO_FORMAT, true);
            valids.addComponent(radregion, ComponentValidator.NO_FORMAT, true);
            TBL_RegisterStudent[] checkregstud = studreg.checkregisteredstudent(txtstudid.Text, txtfname.Text, txtmname.Text, txtlname.Text, raddept.SelectedValue, radyear.SelectedValue, radsemister.SelectedValue, radsex.SelectedValue);
            TBL_AcadmicDismissalStudent[] checkdismissal = studreg.checkdismissalstud(txtstudid.Text, txtfname.Text, txtmname.Text, txtlname.Text, raddept.SelectedValue, radyear.SelectedValue, radsemister.SelectedValue, radsex.SelectedValue);
            if (valids.isAllComponenetValid())
            {*/
                //regstration first year second semister
                if (radyear.SelectedValue == "I" && radsemister.SelectedValue == "II")
                {
                    TBL_FreshStudent[] check = sims.checkfreshstudent(txtstudid.Text, txtfname.Text, txtmname.Text, txtlname.Text, raddept.SelectedValue);
                    
                    if (check.Count() > 0)
                    {
                        TBL_GradeReport[] gr = sims.checkgradereport(txtstudid.Text, "I", "I");
                        if (checkregstud.Count() <= 0 )
                        {

                            if (gr.Count() > 0)
                            {
                                if (gr[0].SGPA >= 1.75)
                                {
                                    try
                                    {
                                        if (sims.Registerseniorstudent(txtstudid.Text, txtfname.Text, txtmname.Text, txtlname.Text, radcollege.SelectedValue, raddept.SelectedValue, radyear.SelectedValue, radsemister.SelectedValue, Convert.ToInt32(txtage.Text), radsex.SelectedValue, txtnational.Text,
                                            radregion.SelectedValue, txtzone.Text, ethipiayr, regdate, "Pass"))
                                        {
                                            //slipreport();
                                            //txtfname.Text = "";
                                            //txtmname.Text = "";
                                            //txtlname.Text = "";
                                            //SearchCollege();
                                            //searchdepartment();
                                            //txtage.Text = "";
                                            //radsex.Text = radsex.EmptyMessage;
                                            //radsex.SelectedValue = radsex.EmptyMessage;
                                            //raddept.Text = raddept.EmptyMessage;
                                            //raddept.SelectedValue = raddept.EmptyMessage;
                                            //radsex.Text = radsex.EmptyMessage;
                                            //radsex.SelectedValue = radsex.EmptyMessage;
                                            //radregion.Text = radregion.EmptyMessage;
                                            //radregion.SelectedValue = radregion.EmptyMessage;
                                            //txtnational.Text = "";
                                            //txtzone.Text = "";
                                            label.Text = "Register Successfully";
                                           

                                        }
                                        else
                                        {
                                            label.Text = "Error Occured";
                                        }
                                    }
                                    catch (Exception ex)
                                    {

                                    }
                                }
                                else if (gr[0].SGPA < 1.75 && gr[0].SGPA >= 1.5)
                                {
                                    try
                                    {
                                        if (sims.Registerseniorstudent(txtstudid.Text, txtfname.Text, txtmname.Text, txtlname.Text, radcollege.SelectedValue, raddept.SelectedValue, radyear.SelectedValue, radsemister.SelectedValue, Convert.ToInt32(txtage.Text), radsex.SelectedValue, txtnational.Text,
                                          radregion.SelectedValue, txtzone.Text, ethipiayr, regdate, "Warning"))
                                        {
                                            //slipreport();
                                            //txtfname.Text = "";
                                            //txtmname.Text = "";
                                            //txtlname.Text = "";
                                            //SearchCollege();
                                            //searchdepartment();
                                            //txtage.Text = "";
                                            //radsex.Text = radsex.EmptyMessage;
                                            //raddept.Text = raddept.EmptyMessage;
                                            //radsex.Text = radsex.EmptyMessage;
                                            //radregion.Text = radregion.EmptyMessage;
                                            //txtnational.Text = "";
                                            //txtzone.Text = "";
                                            label.Text = "Register with Warning";
                                         
                                        }
                                        else
                                        {
                                            label.Text = "Error Occured";
                                        }
                                    }
                                    catch (Exception ex)
                                    {

                                    }
                                }
                                else if (gr[0].SGPA < 1.5)
                                {
                                    try
                                    {
                                        if (gr[0].SGPA >= 1.00)
                                        {
                                            if (checkdismissal.Count() <= 0)
                                            {
                                                if (sims.AcadmicDismissalStudent(txtstudid.Text, txtfname.Text, txtmname.Text, txtlname.Text, radcollege.SelectedValue, raddept.SelectedValue, radyear.SelectedValue, radsemister.SelectedValue, Convert.ToInt32(txtage.Text), radsex.SelectedValue, txtnational.Text,
                                                 radregion.SelectedValue, txtzone.Text, ethipiayr, regdate, "Readmission"))
                                                {
                                                    //txtfname.Text = "";
                                                    //txtmname.Text = "";
                                                    //txtlname.Text = "";
                                                  
                                                    //txtage.Text = "";
                                                    //radsex.Text = radsex.EmptyMessage;
                                                    //raddept.Text = raddept.EmptyMessage;
                                                    //radsex.Text = radsex.EmptyMessage;
                                                    //radregion.Text = radregion.EmptyMessage;
                                                    //txtnational.Text = "";
                                                    //txtzone.Text = "";
                                                    label.Text = "We haven't Registred Acadmiclly Dismissal so readmitted in next Semister ";

                                                }
                                                else
                                                {
                                                    label.Text = "Error Occurred";
                                                }
                                            }
                                            else
                                            {
                                                label.Text = " Acadmically Dismissal";
                                            }
                                        }
                                        else
                                        {
                                            if (checkdismissal.Count() <= 0)
                                            {
                                                if (sims.AcadmicDismissalStudent(txtstudid.Text, txtfname.Text, txtmname.Text, txtlname.Text, radcollege.SelectedValue, raddept.SelectedValue, radyear.SelectedValue, radsemister.SelectedValue, Convert.ToInt32(txtage.Text), radsex.SelectedValue, txtnational.Text,
                                                    radregion.SelectedValue, txtzone.Text, ethipiayr, regdate, "Dismissed For Good"))
                                                {
                                                    //txtfname.Text = "";
                                                    //txtmname.Text = "";
                                                    //txtlname.Text = "";
                                                    //SearchCollege();
                                                    //searchdepartment();
                                                    //txtage.Text = "";
                                                    //radsex.Text = radsex.EmptyMessage;
                                                    //raddept.Text = raddept.EmptyMessage;
                                                    //radsex.Text = radsex.EmptyMessage;
                                                    //radregion.Text = radregion.EmptyMessage;
                                                    //txtnational.Text = "";
                                                    //txtzone.Text = "";
                                                    label.Text = "We haven't Registered Acadmically Dismissed for Good ";

                                                }
                                                else
                                                {
                                                    label.Text = "Error Occurred";
                                                }
                                            }
                                            else
                                            { 
                                            label.Text="All ready Acadmically Dismissal";
                                            }
                                        }
                                    }
                                    catch (Exception ex)
                                    {

                                    }
                                }
                            }

                            else
                            {
                                label.Text = "doesn't registered first Generate GradeReport contact registrar manager ";
                            }
                        }
                            //end of chek regstered student
                        else
                        {
                            label.Text = "Already registered";
                        }
                    }
                        else
                        {
                            label.Text = "we haven't Registered first year First semister so contact registrar";
                        }
                    }

                    //Second year first Semister
                else if (radyear.SelectedValue == "II" && radsemister.SelectedValue == "I")
                {
                    TBL_RegisterStudent[] checkregstuIyearIIsemi= sims.checkregisteredstudent(txtstudid.Text, txtfname.Text, txtmname.Text, txtlname.Text, raddept.SelectedValue, "I", "II", radsex.SelectedValue);
                    TBL_RegisterStudent[] warning = sims.checkstudentWarning(txtstudid.Text, "Warning");
                    if (checkregstuIyearIIsemi.Count() > 0)
                    {
                        TBL_GradeReport[] gr = sims.checkgradereport(txtstudid.Text, "I", "II");
                        if (checkregstud.Count() <= 0)
                        {
                            if (gr.Count() > 0)
                            {
                                if (gr[0].SGPA >= 1.75 && gr[0].CGPA >= 1.75)
                                {
                                    try
                                    {
                                        if (sims.Registerseniorstudent(txtstudid.Text, txtfname.Text, txtmname.Text, txtlname.Text, radcollege.SelectedValue, raddept.SelectedValue, radyear.SelectedValue, radsemister.SelectedValue, Convert.ToInt32(txtage.Text), radsex.SelectedValue, txtnational.Text,
                                            radregion.SelectedValue, txtzone.Text, ethipiayr, regdate, "Pass"))
                                        {
                                            slipreport();
                                            //txtfname.Text = "";
                                            //txtmname.Text = "";
                                            //txtlname.Text = "";
                                            //SearchCollege();
                                            //searchdepartment();
                                            //txtage.Text = "";
                                            //radsex.Text = radsex.EmptyMessage;
                                            //raddept.Text = raddept.EmptyMessage;
                                            //radsex.Text = radsex.EmptyMessage;
                                            //radregion.Text = radregion.EmptyMessage;
                                            //txtnational.Text = "";
                                            //txtzone.Text = "";
                                            label.Text = "Register Successfully";
                                            // slipreport();
                                        }
                                        else
                                        {
                                            label.Text = "Error Occured";
                                        }
                                    }
                                    catch (Exception ex)
                                    {

                                    }
                                }
                                else if ((gr[0].SGPA < 1.75 && gr[0].SGPA >= 1.5) && (gr[0].CGPA > 1.75 && gr[0].CGPA < 2.00))
                                {
                                    try
                                    {
                                        if (sims.Registerseniorstudent(txtstudid.Text, txtfname.Text, txtmname.Text, txtlname.Text, radcollege.SelectedValue, raddept.SelectedValue, radyear.SelectedValue, radsemister.SelectedValue, Convert.ToInt32(txtage.Text), radsex.SelectedValue, txtnational.Text,
                                          radregion.SelectedValue, txtzone.Text, ethipiayr, regdate, "Warning"))
                                        {
                                            slipreport();
                                            //txtfname.Text = "";
                                            //txtmname.Text = "";
                                            //txtlname.Text = "";
                                            //SearchCollege();
                                            //searchdepartment();
                                            //txtage.Text = "";
                                            //radsex.Text = radsex.EmptyMessage;
                                            //raddept.Text = raddept.EmptyMessage;
                                            //radsex.Text = radsex.EmptyMessage;
                                            //radregion.Text = radregion.EmptyMessage;
                                            //txtnational.Text = "";
                                            //txtzone.Text = "";
                                            label.Text = "Register with Warning";
                                            //slipreport();
                                        }
                                        else
                                        {
                                            label.Text = "Error Occured";
                                        }
                                    }
                                    catch (Exception ex)
                                    {

                                    }
                                }

                                else if ((gr[0].SGPA < 1.75 && gr[0].CGPA < 1.75) || warning.Count() >= 2)
                                {
                                    try
                                    {
                                        if (gr[0].CGPA >= 1.5)
                                        {
                                            if (checkdismissal.Count() <= 0)
                                            {
                                                if (sims.AcadmicDismissalStudent(txtstudid.Text, txtfname.Text, txtmname.Text, txtlname.Text, radcollege.SelectedValue, raddept.SelectedValue, radyear.SelectedValue, radsemister.SelectedValue, Convert.ToInt32(txtage.Text), radsex.SelectedValue, txtnational.Text,
                                                 radregion.SelectedValue, txtzone.Text, ethipiayr, regdate, "Readmission"))
                                                {
                                                    //txtfname.Text = "";
                                                    //txtmname.Text = "";
                                                    //txtlname.Text = "";
                                                    //SearchCollege();
                                                    //searchdepartment();
                                                    //txtage.Text = "";
                                                    //radsex.Text = radsex.EmptyMessage;
                                                    //raddept.Text = raddept.EmptyMessage;
                                                    //radsex.Text = radsex.EmptyMessage;
                                                    //radregion.Text = radregion.EmptyMessage;
                                                    //txtnational.Text = "";
                                                    //txtzone.Text = "";
                                                    label.Text = "We haven't Registred Acadmiclly Dismissal so readmitted in next Semister  ";

                                                }
                                                else
                                                {
                                                    label.Text = "Error Occurred";
                                                }
                                            }
                                            else
                                            {
                                                label.Text = " Acadmically Dismissal";
                                            }
                                        }
                                        else
                                        {
                                            if (checkdismissal.Count() <= 0)
                                            {
                                                if (sims.AcadmicDismissalStudent(txtstudid.Text, txtfname.Text, txtmname.Text, txtlname.Text, radcollege.SelectedValue, raddept.SelectedValue, radyear.SelectedValue, radsemister.SelectedValue, Convert.ToInt32(txtage.Text), radsex.SelectedValue, txtnational.Text,
                                                    radregion.SelectedValue, txtzone.Text, ethipiayr, regdate, "Dismissed For Good"))
                                                {
                                                    //txtfname.Text = "";
                                                    //txtmname.Text = "";
                                                    //txtlname.Text = "";
                                                    //SearchCollege();
                                                    //searchdepartment();
                                                    //txtage.Text = "";
                                                    //radsex.Text = radsex.EmptyMessage;
                                                    //raddept.Text = raddept.EmptyMessage;
                                                    //radsex.Text = radsex.EmptyMessage;
                                                    //radregion.Text = radregion.EmptyMessage;
                                                    //txtnational.Text = "";
                                                    //txtzone.Text = "";
                                                    label.Text = "We haven't Registered Acadmically Dismissed for Good ";

                                                }
                                                else
                                                {
                                                    label.Text = "Error Occurred";
                                                }
                                            }
                                            else
                                            {
                                                label.Text = "Already Acadmically Dismissal";
                                            }
                                        }
                                    }
                                    catch (Exception ex)
                                    {

                                    }
                                }
                            }
                            else
                            {
                                label.Text = "doesn't registered first Generate GradeReport contact registrar manager ";
                            }
                        }
                        else
                        {
                            label.Text = "Already registered";
                        }

                    }
                    else
                    {
                        label.Text = "we haven't Registered first year Second semister so contact registrar";
                    }
                }
                //Second year second semister

                else if (radyear.SelectedValue == "II" && radsemister.SelectedValue == "II")
                {
                    TBL_RegisterStudent[] checkregstuIyearIIsemi = sims.checkregisteredstudent(txtstudid.Text, txtfname.Text, txtmname.Text, txtlname.Text, raddept.SelectedValue, "II", "I", radsex.SelectedValue);
                    TBL_RegisterStudent[] warning = sims.checkstudentWarning(txtstudid.Text, "Warning");
                    if (checkregstuIyearIIsemi.Count() > 0)
                    {
                        TBL_GradeReport[] gr = sims.checkgradereport(txtstudid.Text, "II", "I");
                        if (checkregstud.Count() <= 0)
                        {
                            if (gr.Count() > 0)
                            {
                                if (gr[0].SGPA >= 1.75 && gr[0].CGPA >= 2.00)
                                {
                                    try
                                    {
                                        if (sims.Registerseniorstudent(txtstudid.Text, txtfname.Text, txtmname.Text, txtlname.Text, radcollege.SelectedValue, raddept.SelectedValue, radyear.SelectedValue, radsemister.SelectedValue, Convert.ToInt32(txtage.Text), radsex.SelectedValue, txtnational.Text,
                                            radregion.SelectedValue, txtzone.Text, ethipiayr, regdate, "Pass"))
                                        {
                                            slipreport();
                                            //txtfname.Text = "";
                                            //txtmname.Text = "";
                                            //txtlname.Text = "";
                                            //SearchCollege();
                                            //searchdepartment();
                                            //txtage.Text = "";
                                            //radsex.Text = radsex.EmptyMessage;
                                            //raddept.Text = raddept.EmptyMessage;
                                            //radsex.Text = radsex.EmptyMessage;
                                            //radregion.Text = radregion.EmptyMessage;
                                            //txtnational.Text = "";
                                            //txtzone.Text = "";
                                            label.Text = "Register Successfully";
                                            //slipreport();
                                        }
                                        else
                                        {
                                            label.Text = "Error Occured";
                                        }
                                    }
                                    catch (Exception ex)
                                    {

                                    }
                                }
                                else if ((gr[0].SGPA < 1.75 && gr[0].SGPA >= 1.00) && (gr[0].CGPA >= 2.00))
                                {
                                    try
                                    {
                                        if (sims.Registerseniorstudent(txtstudid.Text, txtfname.Text, txtmname.Text, txtlname.Text, radcollege.SelectedValue, raddept.SelectedValue, radyear.SelectedValue, radsemister.SelectedValue, Convert.ToInt32(txtage.Text), radsex.SelectedValue, txtnational.Text,
                                          radregion.SelectedValue, txtzone.Text, ethipiayr, regdate, "Warning"))
                                        {
                                            slipreport();
                                            //txtfname.Text = "";
                                            //txtmname.Text = "";
                                            //txtlname.Text = "";
                                            //SearchCollege();
                                            //searchdepartment();
                                            //txtage.Text = "";
                                            //radsex.Text = radsex.EmptyMessage;
                                            //raddept.Text = raddept.EmptyMessage;
                                            //radsex.Text = radsex.EmptyMessage;
                                            //radregion.Text = radregion.EmptyMessage;
                                            //txtnational.Text = "";
                                            //txtzone.Text = "";
                                            label.Text = "Register with Warning";
                                            //slipreport();
                                        }
                                        else
                                        {
                                            label.Text = "Error Occured";
                                        }
                                    }
                                    catch (Exception ex)
                                    {

                                    }
                                }

                                else if (gr[0].SGPA < 1.75 && gr[0].CGPA < 2.00 || warning.Count() >= 2)
                                {
                                    try
                                    {
                                        if (gr[0].CGPA >= 1.75)
                                        {
                                            if (checkdismissal.Count() <= 0)
                                            {
                                                if (sims.AcadmicDismissalStudent(txtstudid.Text, txtfname.Text, txtmname.Text, txtlname.Text, radcollege.SelectedValue, raddept.SelectedValue, radyear.SelectedValue, radsemister.SelectedValue, Convert.ToInt32(txtage.Text), radsex.SelectedValue, txtnational.Text,
                                                 radregion.SelectedValue, txtzone.Text, ethipiayr, regdate, "Readmission"))
                                                {
                                                    //txtfname.Text = "";
                                                    //txtmname.Text = "";
                                                    //txtlname.Text = "";
                                                    //SearchCollege();
                                                    //searchdepartment();
                                                    //txtage.Text = "";
                                                    //radsex.Text = radsex.EmptyMessage;
                                                    //raddept.Text = raddept.EmptyMessage;
                                                    //radsex.Text = radsex.EmptyMessage;
                                                    //radregion.Text = radregion.EmptyMessage;
                                                    //txtnational.Text = "";
                                                    //txtzone.Text = "";
                                                    label.Text = "We haven't Registred Acadmiclly Dismissal so readmitted in next Semister ";

                                                }
                                                else
                                                {
                                                    label.Text = "Error Occurred";
                                                }
                                            }
                                            else
                                            {
                                                label.Text = " Acadmically Dismissal";
                                            }
                                        }
                                        else
                                        {
                                            if (checkdismissal.Count() <= 0)
                                            {
                                                if (sims.AcadmicDismissalStudent(txtstudid.Text, txtfname.Text, txtmname.Text, txtlname.Text, radcollege.SelectedValue, raddept.SelectedValue, radyear.SelectedValue, radsemister.SelectedValue, Convert.ToInt32(txtage.Text), radsex.SelectedValue, txtnational.Text,
                                                    radregion.SelectedValue, txtzone.Text, ethipiayr, regdate, "Dismissed For Good"))
                                                {
                                                    //txtfname.Text = "";
                                                    //txtmname.Text = "";
                                                    //txtlname.Text = "";
                                                    //SearchCollege();
                                                    //searchdepartment();
                                                    //txtage.Text = "";
                                                    //radsex.Text = radsex.EmptyMessage;
                                                    //raddept.Text = raddept.EmptyMessage;
                                                    //radsex.Text = radsex.EmptyMessage;
                                                    //radregion.Text = radregion.EmptyMessage;
                                                    //txtnational.Text = "";
                                                    //txtzone.Text = "";
                                                    label.Text = "We haven't Registered Acadmically Dismissed for Good ";

                                                }
                                                else
                                                {
                                                    label.Text = "Error Occurred";
                                                }
                                            }
                                            else
                                            {
                                                label.Text = "Already Acadmically Dismissal";
                                            }
                                        }
                                    }
                                    catch (Exception ex)
                                    {

                                    }
                                }
                            }
                            else
                            {
                                label.Text = "doesn't registered first Generate GradeReport contact registrar manager ";
                            }
                        }
                        else
                        {
                            label.Text = "All ready registered";
                        }

                    }
                    else
                    {
                        label.Text = "we haven't Registered second year first semister so contact registrar";
                    }
                }
                //third year first semister

                else if (radyear.SelectedValue == "III" && radsemister.SelectedValue == "I")
                {
                    TBL_RegisterStudent[] checkregstuIyearIIsemi = sims.checkregisteredstudent(txtstudid.Text, txtfname.Text, txtmname.Text, txtlname.Text, raddept.SelectedValue, "II", "II", radsex.SelectedValue);
                    TBL_RegisterStudent[] warning = sims.checkstudentWarning(txtstudid.Text, "Warning");
                    if (checkregstuIyearIIsemi.Count() > 0)
                    {
                        TBL_GradeReport[] gr =sims.checkgradereport(txtstudid.Text, "II", "II");
                        if (checkregstud.Count() <= 0)
                        {
                            if (gr.Count() > 0)
                            {
                                if (gr[0].SGPA >= 1.75 && gr[0].CGPA >= 2.00)
                                {
                                    try
                                    {
                                        if (sims.Registerseniorstudent(txtstudid.Text, txtfname.Text, txtmname.Text, txtlname.Text, radcollege.SelectedValue, raddept.SelectedValue, radyear.SelectedValue, radsemister.SelectedValue, Convert.ToInt32(txtage.Text), radsex.SelectedValue, txtnational.Text,
                                            radregion.SelectedValue, txtzone.Text, ethipiayr, regdate, "Pass"))
                                        {
                                            slipreport();
                                            //txtfname.Text = "";
                                            //txtmname.Text = "";
                                            //txtlname.Text = "";
                                            //SearchCollege();
                                            //searchdepartment();
                                            //txtage.Text = "";
                                            //radsex.Text = radsex.EmptyMessage;
                                            //raddept.Text = raddept.EmptyMessage;
                                            //radsex.Text = radsex.EmptyMessage;
                                            //radregion.Text = radregion.EmptyMessage;
                                            //txtnational.Text = "";
                                            //txtzone.Text = "";
                                            label.Text = "Register Successfully";
                                            //slipreport();
                                        }
                                        else
                                        {
                                            label.Text = "Error Occured";
                                        }
                                    }
                                    catch (Exception ex)
                                    {

                                    }
                                }
                                else if ((gr[0].SGPA < 1.75 && gr[0].SGPA >= 1.00) && (gr[0].CGPA >= 2.00))
                                {
                                    try
                                    {
                                        if (sims.Registerseniorstudent(txtstudid.Text, txtfname.Text, txtmname.Text, txtlname.Text, radcollege.SelectedValue, raddept.SelectedValue, radyear.SelectedValue, radsemister.SelectedValue, Convert.ToInt32(txtage.Text), radsex.SelectedValue, txtnational.Text,
                                          radregion.SelectedValue, txtzone.Text, ethipiayr, regdate, "Warning"))
                                        {
                                            slipreport();
                                            //txtfname.Text = "";
                                            //txtmname.Text = "";
                                            //txtlname.Text = "";
                                            //SearchCollege();
                                            //searchdepartment();
                                            //txtage.Text = "";
                                            //radsex.Text = radsex.EmptyMessage;
                                            //raddept.Text = raddept.EmptyMessage;
                                            //radsex.Text = radsex.EmptyMessage;
                                            //radregion.Text = radregion.EmptyMessage;
                                            //txtnational.Text = "";
                                            //txtzone.Text = "";
                                            label.Text = "Register with Warning";
                                            //slipreport();
                                        }
                                        else
                                        {
                                            label.Text = "Error Occured";
                                        }
                                    }
                                    catch (Exception ex)
                                    {

                                    }
                                }

                                else if (gr[0].SGPA < 1.75 && gr[0].CGPA < 2.00 || warning.Count() >= 2)
                                {
                                    try
                                    {
                                        if (gr[0].CGPA >= 1.75)
                                        {
                                            if (checkdismissal.Count() <= 0)
                                            {
                                                if (sims.AcadmicDismissalStudent(txtstudid.Text, txtfname.Text, txtmname.Text, txtlname.Text, radcollege.SelectedValue, raddept.SelectedValue, radyear.SelectedValue, radsemister.SelectedValue, Convert.ToInt32(txtage.Text), radsex.SelectedValue, txtnational.Text,
                                                 radregion.SelectedValue, txtzone.Text, ethipiayr, regdate, "Readmission"))
                                                {
                                                    //txtfname.Text = "";
                                                    //txtmname.Text = "";
                                                    //txtlname.Text = "";
                                                    //SearchCollege();
                                                    //searchdepartment();
                                                    //txtage.Text = "";
                                                    //radsex.Text = radsex.EmptyMessage;
                                                    //raddept.Text = raddept.EmptyMessage;
                                                    //radsex.Text = radsex.EmptyMessage;
                                                    //radregion.Text = radregion.EmptyMessage;
                                                    //txtnational.Text = "";
                                                    //txtzone.Text = "";
                                                    label.Text = "We haven't Registred Acadmiclly Dismissal so readmitted in next Semister  ";

                                                }
                                                else
                                                {
                                                    label.Text = "Error Occurred";
                                                }
                                            }
                                            else
                                            {
                                                label.Text = "Already Acadmically Dismissal";
                                            }
                                        }
                                        else
                                        {
                                            if (checkdismissal.Count() <= 0)
                                            {
                                                if (sims.AcadmicDismissalStudent(txtstudid.Text, txtfname.Text, txtmname.Text, txtlname.Text, radcollege.SelectedValue, raddept.SelectedValue, radyear.SelectedValue, radsemister.SelectedValue, Convert.ToInt32(txtage.Text), radsex.SelectedValue, txtnational.Text,
                                                    radregion.SelectedValue, txtzone.Text, ethipiayr, regdate, "Dismissed For Good"))
                                                {
                                                    //txtfname.Text = "";
                                                    //txtmname.Text = "";
                                                    //txtlname.Text = "";
                                                    //SearchCollege();
                                                    //searchdepartment();
                                                    //txtage.Text = "";
                                                    //radsex.Text = radsex.EmptyMessage;
                                                    //raddept.Text = raddept.EmptyMessage;
                                                    //radsex.Text = radsex.EmptyMessage;
                                                    //radregion.Text = radregion.EmptyMessage;
                                                    //txtnational.Text = "";
                                                    //txtzone.Text = "";
                                                    label.Text = "We haven't Registered Acadmically Dismissed for Good ";

                                                }
                                                else
                                                {
                                                    label.Text = "Error Occurred";
                                                }
                                            }
                                            else
                                            {
                                                label.Text = "Already Acadmically Dismissal";
                                            }
                                        }
                                    }
                                    catch (Exception ex)
                                    {

                                    }
                                }
                            }
                            else
                            {
                                label.Text = "doesn't registered first Generate GradeReport contact registrar manager ";
                            }
                        }
                        else
                        {
                            label.Text = "All ready registered";
                        }

                    }
                    else
                    {
                        label.Text = "we haven't Registered second year second semister so contact registrar";
                    }
                }
                //third year first semister End
                //third year second semister
                else if (radyear.SelectedValue == "III" && radsemister.SelectedValue == "II")
                {
                    TBL_RegisterStudent[] checkregstuIyearIIsemi = sims.checkregisteredstudent(txtstudid.Text, txtfname.Text, txtmname.Text, txtlname.Text, raddept.SelectedValue, "III", "I", radsex.SelectedValue);
                    TBL_RegisterStudent[] warning = sims.checkstudentWarning(txtstudid.Text, "Warning");
                    if (checkregstuIyearIIsemi.Count() > 0)
                    {
                        TBL_GradeReport[] gr = sims.checkgradereport(txtstudid.Text, "III", "I");
                        if (checkregstud.Count() <= 0)
                        {
                            if (gr.Count() > 0)
                            {
                                if (gr[0].SGPA >= 1.75 && gr[0].CGPA >= 2.00)
                                {
                                    try
                                    {
                                        if (sims.Registerseniorstudent(txtstudid.Text, txtfname.Text, txtmname.Text, txtlname.Text, radcollege.SelectedValue, raddept.SelectedValue, radyear.SelectedValue, radsemister.SelectedValue, Convert.ToInt32(txtage.Text), radsex.SelectedValue, txtnational.Text,
                                            radregion.SelectedValue, txtzone.Text, ethipiayr, regdate, "Pass"))
                                        {
                                            slipreport();
                                            //txtfname.Text = "";
                                            //txtmname.Text = "";
                                            //txtlname.Text = "";
                                            //SearchCollege();
                                            //searchdepartment();
                                            //txtage.Text = "";
                                            //radsex.Text = radsex.EmptyMessage;
                                            //raddept.Text = raddept.EmptyMessage;
                                            //radsex.Text = radsex.EmptyMessage;
                                            //radregion.Text = radregion.EmptyMessage;
                                            //txtnational.Text = "";
                                            //txtzone.Text = "";
                                            label.Text = "Register Successfully";
                                            // slipreport();
                                        }
                                        else
                                        {
                                            label.Text = "Error Occured";
                                        }
                                    }
                                    catch (Exception ex)
                                    {

                                    }
                                }
                                else if ((gr[0].SGPA < 1.75 && gr[0].SGPA >= 1.00) && (gr[0].CGPA >= 2.00))
                                {
                                    try
                                    {
                                        if (sims.Registerseniorstudent(txtstudid.Text, txtfname.Text, txtmname.Text, txtlname.Text, radcollege.SelectedValue, raddept.SelectedValue, radyear.SelectedValue, radsemister.SelectedValue, Convert.ToInt32(txtage.Text), radsex.SelectedValue, txtnational.Text,
                                          radregion.SelectedValue, txtzone.Text, ethipiayr, regdate, "Warning"))
                                        {
                                            slipreport();
                                            //txtfname.Text = "";
                                            //txtmname.Text = "";
                                            //txtlname.Text = "";
                                            //SearchCollege();
                                            //searchdepartment();
                                            //txtage.Text = "";
                                            //radsex.Text = radsex.EmptyMessage;
                                            //raddept.Text = raddept.EmptyMessage;
                                            //radsex.Text = radsex.EmptyMessage;
                                            //radregion.Text = radregion.EmptyMessage;
                                            //txtnational.Text = "";
                                            //txtzone.Text = "";
                                            label.Text = "Register with Warning";
                                            // slipreport();
                                        }
                                        else
                                        {
                                            label.Text = "Error Occured";
                                        }
                                    }
                                    catch (Exception ex)
                                    {

                                    }
                                }

                                else if (gr[0].SGPA < 1.75 && gr[0].CGPA < 2.00 || warning.Count() >= 2)
                                {
                                    try
                                    {
                                        if (gr[0].CGPA >= 1.85)
                                        {
                                            if (checkdismissal.Count() <= 0)
                                            {
                                                if (sims.AcadmicDismissalStudent(txtstudid.Text, txtfname.Text, txtmname.Text, txtlname.Text, radcollege.SelectedValue, raddept.SelectedValue, radyear.SelectedValue, radsemister.SelectedValue, Convert.ToInt32(txtage.Text), radsex.SelectedValue, txtnational.Text,
                                                 radregion.SelectedValue, txtzone.Text, ethipiayr, regdate, "Readmission"))
                                                {
                                                    //txtfname.Text = "";
                                                    //txtmname.Text = "";
                                                    //txtlname.Text = "";
                                                    //SearchCollege();
                                                    //searchdepartment();
                                                    //txtage.Text = "";
                                                    //radsex.Text = radsex.EmptyMessage;
                                                    //raddept.Text = raddept.EmptyMessage;
                                                    //radsex.Text = radsex.EmptyMessage;
                                                    //radregion.Text = radregion.EmptyMessage;
                                                    //txtnational.Text = "";
                                                    //txtzone.Text = "";
                                                    label.Text = "We haven't Registred Acadmiclly Dismissal so readmitted in next Semister Fill withdrawal form ";

                                                }
                                                else
                                                {
                                                    label.Text = "Error Occurred";
                                                }
                                            }
                                            else
                                            {
                                                label.Text = "Already Acadmically Dismissal";
                                            }
                                        }
                                        else
                                        {
                                            if (checkdismissal.Count() <= 0)
                                            {
                                                if (sims.AcadmicDismissalStudent(txtstudid.Text, txtfname.Text, txtmname.Text, txtlname.Text, radcollege.SelectedValue, raddept.SelectedValue, radyear.SelectedValue, radsemister.SelectedValue, Convert.ToInt32(txtage.Text), radsex.SelectedValue, txtnational.Text,
                                                    radregion.SelectedValue, txtzone.Text, ethipiayr, regdate, "Dismissed For Good"))
                                                {
                                                    //txtfname.Text = "";
                                                    //txtmname.Text = "";
                                                    //txtlname.Text = "";
                                                    //SearchCollege();
                                                    //searchdepartment();
                                                    //txtage.Text = "";
                                                    //radsex.Text = radsex.EmptyMessage;
                                                    //raddept.Text = raddept.EmptyMessage;
                                                    //radsex.Text = radsex.EmptyMessage;
                                                    //radregion.Text = radregion.EmptyMessage;
                                                    //txtnational.Text = "";
                                                    //txtzone.Text = "";
                                                    label.Text = "We haven't Registered Acadmically Dismissed for Good ";

                                                }
                                                else
                                                {
                                                    label.Text = "Error Occurred";
                                                }
                                            }
                                            else
                                            {
                                                label.Text = "Already Acadmically Dismissal";
                                            }
                                        }
                                    }
                                    catch (Exception ex)
                                    {

                                    }
                                }
                            }
                            else
                            {
                                label.Text = "doesn't registered first Generate GradeReport contact registrar manager ";
                            }
                        }
                        else
                        {
                            label.Text = "Already registered";
                        }

                    }
                    else
                    {
                        label.Text = "we haven't Registered third year first semister so contact registrar";
                    }
                }
                //third year second semister end
                //fourth year First semister
                else if (radyear.SelectedValue == "IV" && radsemister.SelectedValue == "I")
                {
                    TBL_RegisterStudent[] checkregstuIyearIIsemi = sims.checkregisteredstudent(txtstudid.Text, txtfname.Text, txtmname.Text, txtlname.Text, raddept.SelectedValue, "III", "II", radsex.SelectedValue);
                    TBL_RegisterStudent[] warning = sims.checkstudentWarning(txtstudid.Text, "Warning");
                    if (checkregstuIyearIIsemi.Count() > 0)
                    {
                        TBL_GradeReport[] gr = sims.checkgradereport(txtstudid.Text, "III", "II");
                        if (checkregstud.Count() <= 0)
                        {
                            if (gr.Count() > 0)
                            {
                                if (gr[0].SGPA >= 1.75 && gr[0].CGPA >= 2.00)
                                {
                                    try
                                    {
                                        if (sims.Registerseniorstudent(txtstudid.Text, txtfname.Text, txtmname.Text, txtlname.Text, radcollege.SelectedValue, raddept.SelectedValue, radyear.SelectedValue, radsemister.SelectedValue, Convert.ToInt32(txtage.Text), radsex.SelectedValue, txtnational.Text,
                                            radregion.SelectedValue, txtzone.Text, ethipiayr, regdate, "Pass"))
                                        {
                                            slipreport();
                                            //txtfname.Text = "";
                                            //txtmname.Text = "";
                                            //txtlname.Text = "";
                                            //SearchCollege();
                                            //searchdepartment();
                                            //txtage.Text = "";
                                            //radsex.Text = radsex.EmptyMessage;
                                            //raddept.Text = raddept.EmptyMessage;
                                            //radsex.Text = radsex.EmptyMessage;
                                            //radregion.Text = radregion.EmptyMessage;
                                            //txtnational.Text = "";
                                            //txtzone.Text = "";
                                            label.Text = "Register Successfully";
                                            // slipreport();
                                        }
                                        else
                                        {
                                            label.Text = "Error Occured";
                                        }
                                    }
                                    catch (Exception ex)
                                    {

                                    }
                                }
                                else if ((gr[0].SGPA < 1.75 && gr[0].SGPA >= 1.00) && (gr[0].CGPA >= 2.00))
                                {
                                    try
                                    {
                                        if (sims.Registerseniorstudent(txtstudid.Text, txtfname.Text, txtmname.Text, txtlname.Text, radcollege.SelectedValue, raddept.SelectedValue, radyear.SelectedValue, radsemister.SelectedValue, Convert.ToInt32(txtage.Text), radsex.SelectedValue, txtnational.Text,
                                          radregion.SelectedValue, txtzone.Text, ethipiayr, regdate, "Warning"))
                                        {
                                            slipreport();
                                            //txtfname.Text = "";
                                            //txtmname.Text = "";
                                            //txtlname.Text = "";
                                            //SearchCollege();
                                            //searchdepartment();
                                            //txtage.Text = "";
                                            //radsex.Text = radsex.EmptyMessage;
                                            //raddept.Text = raddept.EmptyMessage;
                                            //radsex.Text = radsex.EmptyMessage;
                                            //radregion.Text = radregion.EmptyMessage;
                                            //txtnational.Text = "";
                                            //txtzone.Text = "";
                                            label.Text = "Register with Warning";
                                            // slipreport();
                                        }
                                        else
                                        {
                                            label.Text = "Error Occured";
                                        }
                                    }
                                    catch (Exception ex)
                                    {

                                    }
                                }

                                else if (gr[0].SGPA < 1.75 && gr[0].CGPA < 2.00 || warning.Count() >= 2)
                                {
                                    try
                                    {
                                        if (gr[0].CGPA >= 1.85)
                                        {
                                            if (checkdismissal.Count() <= 0)
                                            {
                                                if (sims.AcadmicDismissalStudent(txtstudid.Text, txtfname.Text, txtmname.Text, txtlname.Text, radcollege.SelectedValue, raddept.SelectedValue, radyear.SelectedValue, radsemister.SelectedValue, Convert.ToInt32(txtage.Text), radsex.SelectedValue, txtnational.Text,
                                                 radregion.SelectedValue, txtzone.Text, ethipiayr, regdate, "Readmission"))
                                                {
                                                    //txtfname.Text = "";
                                                    //txtmname.Text = "";
                                                    //txtlname.Text = "";
                                                    //SearchCollege();
                                                    //searchdepartment();
                                                    //txtage.Text = "";
                                                    //radsex.Text = radsex.EmptyMessage;
                                                    //raddept.Text = raddept.EmptyMessage;
                                                    //radsex.Text = radsex.EmptyMessage;
                                                    //radregion.Text = radregion.EmptyMessage;
                                                    //txtnational.Text = "";
                                                    //txtzone.Text = "";
                                                    label.Text = "We haven't Registred Acadmiclly Dismissal so readmitted in next Semister ";

                                                }
                                                else
                                                {
                                                    label.Text = "Error Occurred";
                                                }
                                            }
                                            else
                                            {
                                                label.Text = "Already Acadmically Dismissal";
                                            }
                                        }
                                        else
                                        {
                                            if (checkdismissal.Count() <= 0)
                                            {
                                                if (sims.AcadmicDismissalStudent(txtstudid.Text, txtfname.Text, txtmname.Text, txtlname.Text, radcollege.SelectedValue, raddept.SelectedValue, radyear.SelectedValue, radsemister.SelectedValue, Convert.ToInt32(txtage.Text), radsex.SelectedValue, txtnational.Text,
                                                    radregion.SelectedValue, txtzone.Text, ethipiayr, regdate, "Dismissed For Good"))
                                                {
                                                    //txtfname.Text = "";
                                                    //txtmname.Text = "";
                                                    //txtlname.Text = "";
                                                    //SearchCollege();
                                                    //searchdepartment();
                                                    //txtage.Text = "";
                                                    //radsex.Text = radsex.EmptyMessage;
                                                    //raddept.Text = raddept.EmptyMessage;
                                                    //radsex.Text = radsex.EmptyMessage;
                                                    //radregion.Text = radregion.EmptyMessage;
                                                    //txtnational.Text = "";
                                                    //txtzone.Text = "";
                                                    label.Text = "We haven't Registered Acadmically Dismissed for Good ";

                                                }
                                                else
                                                {
                                                    label.Text = "Error Occurred";
                                                }
                                            }
                                            else
                                            {
                                                label.Text = "Already Acadmically Dismissal";
                                            }
                                        }
                                    }
                                    catch (Exception ex)
                                    {

                                    }
                                }
                            }
                            else
                            {
                                label.Text = "doesn't registered first Generate GradeReport contact registrar manager ";
                            }
                        }
                        else
                        {
                            label.Text = "Already registered";
                        }

                    }
                    else
                    {
                        label.Text = "we haven't Registered Third year First semister so contact registrar";
                    }
                }
                //fourth year first semister end
                //fourth year second semister
                else if (radyear.SelectedValue == "IV" && radsemister.SelectedValue == "II")
                {
                    TBL_RegisterStudent[] checkregstuIyearIIsemi = sims.checkregisteredstudent(txtstudid.Text, txtfname.Text, txtmname.Text, txtlname.Text, raddept.SelectedValue, "IV", "I", radsex.SelectedValue);
                    TBL_RegisterStudent[] warning = sims.checkstudentWarning(txtstudid.Text, "Warning");
                    if (checkregstuIyearIIsemi.Count() > 0)
                    {
                        TBL_GradeReport[] gr = sims.checkgradereport(txtstudid.Text, "IV", "I");
                        if (checkregstud.Count() <= 0)
                        {
                            if (gr.Count() > 0)
                            {
                                if (gr[0].SGPA >= 1.75 && gr[0].CGPA >= 2.00)
                                {
                                    try
                                    {
                                        if (sims.Registerseniorstudent(txtstudid.Text, txtfname.Text, txtmname.Text, txtlname.Text, radcollege.SelectedValue, raddept.SelectedValue, radyear.SelectedValue, radsemister.SelectedValue, Convert.ToInt32(txtage.Text), radsex.SelectedValue, txtnational.Text,
                                            radregion.SelectedValue, txtzone.Text, ethipiayr, regdate, "Pass"))
                                        {
                                            slipreport();
                                            //txtfname.Text = "";
                                            //txtmname.Text = "";
                                            //txtlname.Text = "";
                                            //SearchCollege();
                                            //searchdepartment();
                                            //txtage.Text = "";
                                            //radsex.Text = radsex.EmptyMessage;
                                            //raddept.Text = raddept.EmptyMessage;
                                            //radsex.Text = radsex.EmptyMessage;
                                            //radregion.Text = radregion.EmptyMessage;
                                            //txtnational.Text = "";
                                            //txtzone.Text = "";
                                            label.Text = "Register Successfully";
                                            //slipreport();
                                        }
                                        else
                                        {
                                            label.Text = "Error Occured";
                                        }
                                    }
                                    catch (Exception ex)
                                    {

                                    }
                                }
                                else if ((gr[0].SGPA < 1.75 && gr[0].SGPA >= 1.00) && (gr[0].CGPA >= 2.00))
                                {
                                    try
                                    {
                                        if (sims.Registerseniorstudent(txtstudid.Text, txtfname.Text, txtmname.Text, txtlname.Text, radcollege.SelectedValue, raddept.SelectedValue, radyear.SelectedValue, radsemister.SelectedValue, Convert.ToInt32(txtage.Text), radsex.SelectedValue, txtnational.Text,
                                          radregion.SelectedValue, txtzone.Text, ethipiayr, regdate, "Warning"))
                                        {
                                            slipreport();
                                            //txtfname.Text = "";
                                            //txtmname.Text = "";
                                            //txtlname.Text = "";
                                            //SearchCollege();
                                            //searchdepartment();
                                            //txtage.Text = "";
                                            //radsex.Text = radsex.EmptyMessage;
                                            //raddept.Text = raddept.EmptyMessage;
                                            //radsex.Text = radsex.EmptyMessage;
                                            //radregion.Text = radregion.EmptyMessage;
                                            //txtnational.Text = "";
                                            //txtzone.Text = "";
                                            label.Text = "Register with Warning";
                                            // slipreport();
                                        }
                                        else
                                        {
                                            label.Text = "Error Occured";
                                        }
                                    }
                                    catch (Exception ex)
                                    {

                                    }
                                }

                                else if (gr[0].SGPA < 1.75 && gr[0].CGPA < 2.00 || warning.Count() >= 2)
                                {
                                    try
                                    {
                                        if (gr[0].CGPA >= 1.92)
                                        {
                                            if (checkdismissal.Count() <= 0)
                                            {
                                                if (sims.AcadmicDismissalStudent(txtstudid.Text, txtfname.Text, txtmname.Text, txtlname.Text, radcollege.SelectedValue, raddept.SelectedValue, radyear.SelectedValue, radsemister.SelectedValue, Convert.ToInt32(txtage.Text), radsex.SelectedValue, txtnational.Text,
                                                 radregion.SelectedValue, txtzone.Text, ethipiayr, regdate, "Readmission"))
                                                {
                                                    //txtfname.Text = "";
                                                    //txtmname.Text = "";
                                                    //txtlname.Text = "";
                                                    //SearchCollege();
                                                    //searchdepartment();
                                                    //txtage.Text = "";
                                                    //radsex.Text = radsex.EmptyMessage;
                                                    //raddept.Text = raddept.EmptyMessage;
                                                    //radsex.Text = radsex.EmptyMessage;
                                                    //radregion.Text = radregion.EmptyMessage;
                                                    //txtnational.Text = "";
                                                    //txtzone.Text = "";
                                                    label.Text = "We haven't Registred Acadmiclly Dismissal so readmitted in next Semister Fill withdrawal form ";

                                                }
                                                else
                                                {
                                                    label.Text = "Error Occurred";
                                                }
                                            }
                                            else
                                            {
                                                label.Text = "Already Acadmically Dismissal";
                                            }
                                        }
                                        else
                                        {
                                            if (checkdismissal.Count() <= 0)
                                            {
                                                if (sims.AcadmicDismissalStudent(txtstudid.Text, txtfname.Text, txtmname.Text, txtlname.Text, radcollege.SelectedValue, raddept.SelectedValue, radyear.SelectedValue, radsemister.SelectedValue, Convert.ToInt32(txtage.Text), radsex.SelectedValue, txtnational.Text,
                                                    radregion.SelectedValue, txtzone.Text, ethipiayr, regdate, "Dismissed For Good"))
                                                {
                                                    //txtfname.Text = "";
                                                    //txtmname.Text = "";
                                                    //txtlname.Text = "";
                                                    //SearchCollege();
                                                    //searchdepartment();
                                                    //txtage.Text = "";
                                                    //radsex.Text = radsex.EmptyMessage;
                                                    //raddept.Text = raddept.EmptyMessage;
                                                    //radsex.Text = radsex.EmptyMessage;
                                                    //radregion.Text = radregion.EmptyMessage;
                                                    //txtnational.Text = "";
                                                    //txtzone.Text = "";
                                                    label.Text = "We haven't Registered Acadmically Dismissed for Good ";

                                                }
                                                else
                                                {
                                                    label.Text = "Error Occurred";
                                                }
                                            }
                                            else
                                            {
                                                label.Text = "Already Acadmically Dismissal";
                                            }
                                        }
                                    }
                                    catch (Exception ex)
                                    {

                                    }
                                }
                            }
                            else
                            {
                                label.Text = "doesn't registered first Generate GradeReport contact registrar manager ";
                            }
                        }
                        else
                        {
                            label.Text = "Already registered";
                        }

                    }
                    else
                    {
                        label.Text = "we haven't Registered fourth year first semister so contact registrar";
                    }
                }
                //fourth year second semister end
                //fifth year first semister
                else if (radyear.SelectedValue == "V" && radsemister.SelectedValue == "I")
                {
                    TBL_RegisterStudent[] checkregstuIyearIIsemi = sims.checkregisteredstudent(txtstudid.Text, txtfname.Text, txtmname.Text, txtlname.Text, raddept.SelectedValue, "IV", "II", radsex.SelectedValue);
                    TBL_RegisterStudent[] warning = sims.checkstudentWarning(txtstudid.Text, "Warning");
                    if (checkregstuIyearIIsemi.Count() > 0)
                    {
                        TBL_GradeReport[] gr = sims.checkgradereport(txtstudid.Text, "IV", "II");
                        if (checkregstud.Count() <= 0)
                        {
                            if (gr.Count() > 0)
                            {
                                if (gr[0].SGPA >= 1.75 && gr[0].CGPA >= 2.00)
                                {
                                    try
                                    {
                                        if (sims.Registerseniorstudent(txtstudid.Text, txtfname.Text, txtmname.Text, txtlname.Text, radcollege.SelectedValue, raddept.SelectedValue, radyear.SelectedValue, radsemister.SelectedValue, Convert.ToInt32(txtage.Text), radsex.SelectedValue, txtnational.Text,
                                            radregion.SelectedValue, txtzone.Text, ethipiayr, regdate, "Pass"))
                                        {
                                            slipreport();
                                            //txtfname.Text = "";
                                            //txtmname.Text = "";
                                            //txtlname.Text = "";
                                            //SearchCollege();
                                            //searchdepartment();
                                            //txtage.Text = "";
                                            //radsex.Text = radsex.EmptyMessage;
                                            //raddept.Text = raddept.EmptyMessage;
                                            //radsex.Text = radsex.EmptyMessage;
                                            //radregion.Text = radregion.EmptyMessage;
                                            //txtnational.Text = "";
                                            //txtzone.Text = "";
                                            label.Text = "Register Successfully";
                                            //slipreport();
                                        }
                                        else
                                        {
                                            label.Text = "Error Occured";
                                        }
                                    }
                                    catch (Exception ex)
                                    {

                                    }
                                }
                                else if ((gr[0].SGPA < 1.75 && gr[0].SGPA >= 1.00) && (gr[0].CGPA >= 2.00))
                                {
                                    try
                                    {
                                        if (sims.Registerseniorstudent(txtstudid.Text, txtfname.Text, txtmname.Text, txtlname.Text, radcollege.SelectedValue, raddept.SelectedValue, radyear.SelectedValue, radsemister.SelectedValue, Convert.ToInt32(txtage.Text), radsex.SelectedValue, txtnational.Text,
                                          radregion.SelectedValue, txtzone.Text, ethipiayr, regdate, "Warning"))
                                        {
                                            slipreport();
                                            //txtfname.Text = "";
                                            //txtmname.Text = "";
                                            //txtlname.Text = "";
                                            //SearchCollege();
                                            //searchdepartment();
                                            //txtage.Text = "";
                                            //radsex.Text = radsex.EmptyMessage;
                                            //raddept.Text = raddept.EmptyMessage;
                                            //radsex.Text = radsex.EmptyMessage;
                                            //radregion.Text = radregion.EmptyMessage;
                                            //txtnational.Text = "";
                                            //txtzone.Text = "";
                                            label.Text = "Register with Warning";
                                            // slipreport();
                                        }
                                        else
                                        {
                                            label.Text = "Error Occured";
                                        }
                                    }
                                    catch (Exception ex)
                                    {

                                    }
                                }

                                else if (gr[0].SGPA < 1.75 && gr[0].CGPA < 2.00 || warning.Count() >= 2)
                                {
                                    try
                                    {
                                        if (gr[0].CGPA >= 1.92)
                                        {
                                            if (checkdismissal.Count() <= 0)
                                            {
                                                if (sims.AcadmicDismissalStudent(txtstudid.Text, txtfname.Text, txtmname.Text, txtlname.Text, radcollege.SelectedValue, raddept.SelectedValue, radyear.SelectedValue, radsemister.SelectedValue, Convert.ToInt32(txtage.Text), radsex.SelectedValue, txtnational.Text,
                                                 radregion.SelectedValue, txtzone.Text, ethipiayr, regdate, "Readmission"))
                                                {
                                                    //txtfname.Text = "";
                                                    //txtmname.Text = "";
                                                    //txtlname.Text = "";
                                                    //SearchCollege();
                                                    //searchdepartment();
                                                    //txtage.Text = "";
                                                    //radsex.Text = radsex.EmptyMessage;
                                                    //raddept.Text = raddept.EmptyMessage;
                                                    //radsex.Text = radsex.EmptyMessage;
                                                    //radregion.Text = radregion.EmptyMessage;
                                                    //txtnational.Text = "";
                                                    //txtzone.Text = "";
                                                    label.Text = "We haven't Registred Acadmiclly Dismissal so readmitted in next Semister Fill withdrawal form ";

                                                }
                                                else
                                                {
                                                    label.Text = "Error Occurred";
                                                }
                                            }
                                            else
                                            {
                                                label.Text = "Already Acadmically Dismissal";
                                            }
                                        }
                                        else
                                        {
                                            if (checkdismissal.Count() <= 0)
                                            {
                                                if (sims.AcadmicDismissalStudent(txtstudid.Text, txtfname.Text, txtmname.Text, txtlname.Text, radcollege.SelectedValue, raddept.SelectedValue, radyear.SelectedValue, radsemister.SelectedValue, Convert.ToInt32(txtage.Text), radsex.SelectedValue, txtnational.Text,
                                                    radregion.SelectedValue, txtzone.Text, ethipiayr, regdate, "Dismissed For Good"))
                                                {
                                                    //txtfname.Text = "";
                                                    //txtmname.Text = "";
                                                    //txtlname.Text = "";
                                                    //SearchCollege();
                                                    //searchdepartment();
                                                    //txtage.Text = "";
                                                    //radsex.Text = radsex.EmptyMessage;
                                                    //raddept.Text = raddept.EmptyMessage;
                                                    //radsex.Text = radsex.EmptyMessage;
                                                    //radregion.Text = radregion.EmptyMessage;
                                                    //txtnational.Text = "";
                                                    //txtzone.Text = "";
                                                    label.Text = "We haven't Registered Acadmically Dismissed for Good ";

                                                }
                                                else
                                                {
                                                    label.Text = "Error Occurred";
                                                }
                                            }
                                            else
                                            {
                                                label.Text = "Already Acadmically Dismissal";
                                            }
                                        }
                                    }
                                    catch (Exception ex)
                                    {

                                    }
                                }
                            }
                            else
                            {
                                label.Text = "doesn't registered first Generate GradeReport contact registrar manager ";
                            }
                        }
                        else
                        {
                            label.Text = "Already registered";
                        }

                    }
                    else
                    {
                        label.Text = "we haven't Registered fourth year Second semister so contact registrar";
                    }
                }
                //fifth year first semister end
                //fifth year second Semister for medicine student
                else if (radyear.SelectedValue == "V" && radsemister.SelectedValue == "II")
                {
                    TBL_RegisterStudent[] checkregstuIyearIIsemi = sims.checkregisteredstudent(txtstudid.Text, txtfname.Text, txtmname.Text, txtlname.Text, raddept.SelectedValue, "V", "I", radsex.SelectedValue);
                    TBL_RegisterStudent[] warning = studreg.checkstudentWarning(txtstudid.Text, "Warning");
                    if (checkregstuIyearIIsemi.Count() > 0)
                    {
                        TBL_GradeReport[] gr = sims.checkgradereport(txtstudid.Text, "V", "I");
                        if (checkregstud.Count() <= 0)
                        {
                            if (gr.Count() > 0)
                            {
                                if (gr[0].SGPA >= 1.75 && gr[0].CGPA >= 2.00)
                                {
                                    try
                                    {
                                        if (sims.Registerseniorstudent(txtstudid.Text, txtfname.Text, txtmname.Text, txtlname.Text, radcollege.SelectedValue, raddept.SelectedValue, radyear.SelectedValue, radsemister.SelectedValue, Convert.ToInt32(txtage.Text), radsex.SelectedValue, txtnational.Text,
                                            radregion.SelectedValue, txtzone.Text, ethipiayr, regdate, "Pass"))
                                        {
                                            slipreport();
                                            //txtfname.Text = "";
                                            //txtmname.Text = "";
                                            //txtlname.Text = "";
                                            //SearchCollege();
                                            //searchdepartment();
                                            //txtage.Text = "";
                                            //radsex.Text = radsex.EmptyMessage;
                                            //raddept.Text = raddept.EmptyMessage;
                                            //radsex.Text = radsex.EmptyMessage;
                                            //radregion.Text = radregion.EmptyMessage;
                                            //txtnational.Text = "";
                                            //txtzone.Text = "";
                                            label.Text = "Register Successfully";
                                            //slipreport();
                                        }
                                        else
                                        {
                                            label.Text = "Error Occured";
                                        }
                                    }
                                    catch (Exception ex)
                                    {

                                    }
                                }
                                else if ((gr[0].SGPA < 1.75 && gr[0].SGPA >= 1.00) && (gr[0].CGPA >= 2.00))
                                {
                                    try
                                    {
                                        if (sims.Registerseniorstudent(txtstudid.Text, txtfname.Text, txtmname.Text, txtlname.Text, radcollege.SelectedValue, raddept.SelectedValue, radyear.SelectedValue, radsemister.SelectedValue, Convert.ToInt32(txtage.Text), radsex.SelectedValue, txtnational.Text,
                                          radregion.SelectedValue, txtzone.Text, ethipiayr, regdate, "Warning"))
                                        {
                                            slipreport();
                                            //txtfname.Text = "";
                                            //txtmname.Text = "";
                                            //txtlname.Text = "";
                                            //SearchCollege();
                                            //searchdepartment();
                                            //txtage.Text = "";
                                            //radsex.Text = radsex.EmptyMessage;
                                            //raddept.Text = raddept.EmptyMessage;
                                            //radsex.Text = radsex.EmptyMessage;
                                            //radregion.Text = radregion.EmptyMessage;
                                            //txtnational.Text = "";
                                            //txtzone.Text = "";
                                            label.Text = "Register with Warning";
                                            // slipreport();
                                        }
                                        else
                                        {
                                            label.Text = "Error Occured";
                                        }
                                    }
                                    catch (Exception ex)
                                    {

                                    }
                                }

                                else if (gr[0].SGPA < 1.75 && gr[0].CGPA < 2.00 || warning.Count() >= 2)
                                {
                                    try
                                    {
                                        if (gr[0].CGPA >= 1.92)
                                        {
                                            if (checkdismissal.Count() <= 0)
                                            {
                                                if (sims.AcadmicDismissalStudent(txtstudid.Text, txtfname.Text, txtmname.Text, txtlname.Text, radcollege.SelectedValue, raddept.SelectedValue, radyear.SelectedValue, radsemister.SelectedValue, Convert.ToInt32(txtage.Text), radsex.SelectedValue, txtnational.Text,
                                                 radregion.SelectedValue, txtzone.Text, ethipiayr, regdate, "Readmission"))
                                                {
                                                    //txtfname.Text = "";
                                                    //txtmname.Text = "";
                                                    //txtlname.Text = "";
                                                    //SearchCollege();
                                                    //searchdepartment();
                                                    //txtage.Text = "";
                                                    //radsex.Text = radsex.EmptyMessage;
                                                    //raddept.Text = raddept.EmptyMessage;
                                                    //radsex.Text = radsex.EmptyMessage;
                                                    //radregion.Text = radregion.EmptyMessage;
                                                    //txtnational.Text = "";
                                                    //txtzone.Text = "";
                                                    label.Text = "We haven't Registred Acadmiclly Dismissal so readmitted in next Semister  ";

                                                }
                                                else
                                                {
                                                    label.Text = "Error Occurred";
                                                }
                                            }
                                            else
                                            {
                                                label.Text = "Already Acadmically Dismissal";
                                            }
                                        }
                                        else
                                        {
                                            if (checkdismissal.Count() <= 0)
                                            {
                                                if (sims.AcadmicDismissalStudent(txtstudid.Text, txtfname.Text, txtmname.Text, txtlname.Text, radcollege.SelectedValue, raddept.SelectedValue, radyear.SelectedValue, radsemister.SelectedValue, Convert.ToInt32(txtage.Text), radsex.SelectedValue, txtnational.Text,
                                                    radregion.SelectedValue, txtzone.Text, ethipiayr, regdate, "Dismissed For Good"))
                                                {
                                                    //txtfname.Text = "";
                                                    //txtmname.Text = "";
                                                    //txtlname.Text = "";
                                                    //SearchCollege();
                                                    //searchdepartment();
                                                    //txtage.Text = "";
                                                    //radsex.Text = radsex.EmptyMessage;
                                                    //raddept.Text = raddept.EmptyMessage;
                                                    //radsex.Text = radsex.EmptyMessage;
                                                    //radregion.Text = radregion.EmptyMessage;
                                                    //txtnational.Text = "";
                                                    //txtzone.Text = "";
                                                    label.Text = "We haven't Registered Acadmically Dismissed for Good ";

                                                }
                                                else
                                                {
                                                    label.Text = "Error Occurred";
                                                }
                                            }
                                            else
                                            {
                                                label.Text = "Already Acadmically Dismissal";
                                            }
                                        }
                                    }
                                    catch (Exception ex)
                                    {

                                    }
                                }
                            }
                            else
                            {
                                label.Text = "doesn't registered first Generate GradeReport contact registrar manager ";
                            }
                        }
                        else
                        {
                            label.Text = "Already registered";
                        }

                    }
                    else
                    {
                        label.Text = "we haven't Registered fivth year first semister so contact registrar";
                    }
                }
                //fifth year second Semister end for medicine student
                //sixth year first semister for medicine student
                else if (radyear.SelectedValue == "VI" && radsemister.SelectedValue == "I")
                {
                    TBL_RegisterStudent[] checkregstuIyearIIsemi = sims.checkregisteredstudent(txtstudid.Text, txtfname.Text, txtmname.Text, txtlname.Text, raddept.SelectedValue, "V", "II", radsex.SelectedValue);
                    TBL_RegisterStudent[] warning = sims.checkstudentWarning(txtstudid.Text, "Warning");
                    if (checkregstuIyearIIsemi.Count() > 0)
                    {
                        TBL_GradeReport[] gr = sims.checkgradereport(txtstudid.Text, "V", "II");
                        if (checkregstud.Count() <= 0)
                        {
                            if (gr.Count() > 0)
                            {
                                if (gr[0].SGPA >= 1.75 && gr[0].CGPA >= 2.00)
                                {
                                    try
                                    {
                                        if (sims.Registerseniorstudent(txtstudid.Text, txtfname.Text, txtmname.Text, txtlname.Text, radcollege.SelectedValue, raddept.SelectedValue, radyear.SelectedValue, radsemister.SelectedValue, Convert.ToInt32(txtage.Text), radsex.SelectedValue, txtnational.Text,
                                            radregion.SelectedValue, txtzone.Text, ethipiayr, regdate, "Pass"))
                                        {
                                            slipreport();
                                            //txtfname.Text = "";
                                            //txtmname.Text = "";
                                            //txtlname.Text = "";
                                            //SearchCollege();
                                            //searchdepartment();
                                            //txtage.Text = "";
                                            //radsex.Text = radsex.EmptyMessage;
                                            //raddept.Text = raddept.EmptyMessage;
                                            //radsex.Text = radsex.EmptyMessage;
                                            //radregion.Text = radregion.EmptyMessage;
                                            //txtnational.Text = "";
                                            //txtzone.Text = "";
                                            label.Text = "Register Successfully";
                                            //slipreport();
                                        }
                                        else
                                        {
                                            label.Text = "Error Occured";
                                        }
                                    }
                                    catch (Exception ex)
                                    {

                                    }
                                }
                                else if ((gr[0].SGPA < 1.75 && gr[0].SGPA >= 1.00) && (gr[0].CGPA >= 2.00))
                                {
                                    try
                                    {
                                        if (sims.Registerseniorstudent(txtstudid.Text, txtfname.Text, txtmname.Text, txtlname.Text, radcollege.SelectedValue, raddept.SelectedValue, radyear.SelectedValue, radsemister.SelectedValue, Convert.ToInt32(txtage.Text), radsex.SelectedValue, txtnational.Text,
                                          radregion.SelectedValue, txtzone.Text, ethipiayr, regdate, "Warning"))
                                        {
                                            slipreport();
                                            //txtfname.Text = "";
                                            //txtmname.Text = "";
                                            //txtlname.Text = "";
                                            //SearchCollege();
                                            //searchdepartment();
                                            //txtage.Text = "";
                                            //radsex.Text = radsex.EmptyMessage;
                                            //raddept.Text = raddept.EmptyMessage;
                                            //radsex.Text = radsex.EmptyMessage;
                                            //radregion.Text = radregion.EmptyMessage;
                                            //txtnational.Text = "";
                                            //txtzone.Text = "";
                                            label.Text = "Register with Warning";
                                            //slipreport();
                                        }
                                        else
                                        {
                                            label.Text = "Error Occured";
                                        }
                                    }
                                    catch (Exception ex)
                                    {

                                    }
                                }

                                else if (gr[0].SGPA < 1.75 && gr[0].CGPA < 2.00 || warning.Count() >= 2)
                                {
                                    try
                                    {
                                        if (gr[0].CGPA >= 1.92)
                                        {
                                            if (checkdismissal.Count() <= 0)
                                            {
                                                if (sims.AcadmicDismissalStudent(txtstudid.Text, txtfname.Text, txtmname.Text, txtlname.Text, radcollege.SelectedValue, raddept.SelectedValue, radyear.SelectedValue, radsemister.SelectedValue, Convert.ToInt32(txtage.Text), radsex.SelectedValue, txtnational.Text,
                                                 radregion.SelectedValue, txtzone.Text, ethipiayr, regdate, "Readmission"))
                                                {
                                                    //txtfname.Text = "";
                                                    //txtmname.Text = "";
                                                    //txtlname.Text = "";
                                                    //SearchCollege();
                                                    //searchdepartment();
                                                    //txtage.Text = "";
                                                    //radsex.Text = radsex.EmptyMessage;
                                                    //raddept.Text = raddept.EmptyMessage;
                                                    //radsex.Text = radsex.EmptyMessage;
                                                    //radregion.Text = radregion.EmptyMessage;
                                                    //txtnational.Text = "";
                                                    //txtzone.Text = "";
                                                    label.Text = "We haven't Registred Acadmiclly Dismissal so readmitted in next Semister  ";

                                                }
                                                else
                                                {
                                                    label.Text = "Error Occurred";
                                                }
                                            }
                                            else
                                            {
                                                label.Text = "Already Acadmically Dismissal";
                                            }
                                        }
                                        else
                                        {
                                            if (checkdismissal.Count() <= 0)
                                            {
                                                if (sims.AcadmicDismissalStudent(txtstudid.Text, txtfname.Text, txtmname.Text, txtlname.Text, radcollege.SelectedValue, raddept.SelectedValue, radyear.SelectedValue, radsemister.SelectedValue, Convert.ToInt32(txtage.Text), radsex.SelectedValue, txtnational.Text,
                                                    radregion.SelectedValue, txtzone.Text, ethipiayr, regdate, "Dismissed For Good"))
                                                {
                                                    //txtfname.Text = "";
                                                    //txtmname.Text = "";
                                                    //txtlname.Text = "";
                                                    //SearchCollege();
                                                    //searchdepartment();
                                                    //txtage.Text = "";
                                                    //radsex.Text = radsex.EmptyMessage;
                                                    //raddept.Text = raddept.EmptyMessage;
                                                    //radsex.Text = radsex.EmptyMessage;
                                                    //radregion.Text = radregion.EmptyMessage;
                                                    //txtnational.Text = "";
                                                    //txtzone.Text = "";
                                                    label.Text = "We haven't Registered Acadmically Dismissed for Good ";

                                                }
                                                else
                                                {
                                                    label.Text = "Error Occurred";
                                                }
                                            }
                                            else
                                            {
                                                label.Text = "Already Acadmically Dismissal";
                                            }
                                        }
                                    }
                                    catch (Exception ex)
                                    {

                                    }
                                }
                            }
                            else
                            {
                                label.Text = "doesn't registered first Generate GradeReport contact registrar manager ";
                            }
                        }
                        else
                        {
                            label.Text = "Already registered";
                        }

                    }
                    else
                    {
                        label.Text = "we haven't Registered fivth year Second semister so contact registrar";
                    }
                }
                //sixth year first semister end medicne student
                }
            

        protected void radyear_SelectedIndexChanged(object sender, EventArgs e)
        {
            Image2.Visible = false;
            date.Visible = false;
            name.Visible = false;
            ageandsex.Visible = false;
            region.Visible = false;
            RadGrid1.Visible = false;
            anames.Visible = false;
            regi.Visible = false;
            sign.Visible = false;
            note.Visible = false;
            no.Visible = false;
        }

        protected void radsemister_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int ethipiayr;
                string currentMonth = DateTime.Now.Month.ToString();
                string currentYear = DateTime.Now.Year.ToString();
                int month = Convert.ToInt32(currentMonth);
                int year = Convert.ToInt32(currentYear);
                if (month < 9)
                {
                    ethipiayr = year - 8;

                }
                else
                {
                    ethipiayr = year - 7;
                }
                TBL_AcadmicCalander[] calander = sims.checkacadmiccalander("Registration for all 2nd year and above students", radsemister.SelectedValue, ethipiayr);
                DateTime current = DateTime.Now;
                if (calander.Count() > 0)
                {
                DateTime start = Convert.ToDateTime(calander[0].StartDateinG_C);
                DateTime last = Convert.ToDateTime(calander[0].LastDateinG_C);
              
                    if (current >= start && current <= last)
                    {
                        txtfname.Enabled = true;
                        txtmname.Enabled = true;
                        txtlname.Enabled = true;
                        radyear.Enabled = true;
                        txtage.Enabled = true;
                        radsex.Enabled = true;
                        raddept.Enabled = true;
                        radsex.Enabled = true;
                        radregion.Enabled = true;
                        radcollege.Enabled = true;
                        txtnational.Enabled = true;
                        txtzone.Enabled = true;
                        btn_cancel.Enabled = true;
                        btn_register.Enabled = true;

                    }
                    else
                    {
                        txtfname.Enabled = false;
                        txtmname.Enabled = false;
                        txtlname.Enabled = false;
                        radyear.Enabled = false;
                        txtage.Enabled = false;
                        radsex.Enabled = false;
                        raddept.Enabled = false;
                        radcollege.Enabled = false;
                        radsex.Enabled = false;
                        radregion.Enabled = false;
                        txtnational.Enabled = false;
                        txtzone.Enabled = false;
                        btn_cancel.Enabled = false;
                        btn_register.Enabled = false;
                        label.Text = "Student Reg page is Disactive b/c Acadmic Reg Date";
                    }
                }
                else
                {
                    txtfname.Enabled = false;
                    txtmname.Enabled = false;
                    txtlname.Enabled = false;
                    radyear.Enabled = false;
                    txtage.Enabled = false;
                    radsex.Enabled = false;
                    raddept.Enabled = false;
                    radcollege.Enabled = false;
                    radsex.Enabled = false;
                    radregion.Enabled = false;
                    txtnational.Enabled = false;
                    txtzone.Enabled = false;
                    btn_cancel.Enabled = false;
                    btn_register.Enabled = false;
                    label.Text = "Student Reg page is Disactive b/c Acadmic Reg Date";
                }
                Image2.Visible = false;
                date.Visible = false;
                name.Visible = false;
                ageandsex.Visible = false;
                region.Visible = false;
                RadGrid1.Visible = false;
                anames.Visible = false;
                regi.Visible = false;
                sign.Visible = false;
                note.Visible = false;
                no.Visible = false;
                no.Visible = false;
            }
            catch (Exception ex)
            { 
            
            }
        }
        private void slipreport()
        {
            int k = 0;
            Image2.Visible = true;
            date.Visible = true;
            name.Visible = true;
            ageandsex.Visible = true;
            region.Visible = true;
            RadGrid1.Visible = true;
            anames.Visible = true;
            regi.Visible = true;
            sign.Visible = true;
            note.Visible = true;
            no.Visible = true;
            TBL_FreshStudent[] st = sims.searchstudentbyid(txtstudid.Text);
            int totalcredit = 0;
            TBL_Course[] co = sims.searchcoursebydys(raddept.SelectedValue, radyear.SelectedValue, radsemister.SelectedValue);
            TBL_studentGrade[] stugrade = sims.searchstudgrade(raddept.SelectedValue,txtstudid.Text, radyear.SelectedValue, radsemister.SelectedValue);
            TBL_RegisterStudent[] checkreg = sims.searchstudforgradereport(txtstudid.Text, radyear.SelectedValue, radsemister.SelectedValue);
            //valids.addComponent(radcollege, ComponentValidator.NO_FORMAT, true);
            //valids.addComponent(raddept, ComponentValidator.NO_FORMAT, true);
            //valids.addComponent(txtstudid, ComponentValidator.NO_FORMAT, true);
           // if (valids.isAllComponenetValid())
           // {
                if (radyear.SelectedValue == "I" && radsemister.SelectedValue == "I")
                {
                    if (st.Count() > 0 && co.Count() > 0)
                    {
                        Image2.ImageUrl = "../images/";
                        string strDate = DateTime.Now.ToString("MM/dd/yyyy");
                        date.Text = "Date:" + " " + strDate + " " + "G.C";
                        name.Text = "Name:" + " " + st[0].first_name + " " + st[0].middle_name + "      " + "ID.No.:" + "  " + st[0].Stud_ID + "   " +
                        "Dept:" + " " + raddept.Text;


                        ageandsex.Text = "Age:" + "   " + st[0].age + "   " + " Sex:" + " " + st[0].sex + "Nationality:" + " " + st[0].natinality + "Class Year:" + " " + radyear.SelectedValue + "  " + "Semister:" + " " + radsemister.Text + " " +
                            st[0].Acadmic_year + " " + "E.C" + "(A.Y)";

                        region.Text = "Region:" + "  " + st[0].region + "  " + "Zone:" + "  " + st[0].zone;
                        dt.Columns.Add("S/N");
                        dt.Columns.Add("Course Title");
                        dt.Columns.Add("Course Code");
                        dt.Columns.Add("Credit Hour");
                        dt.Columns.Add("Instructor");

                        for (int i = 0; i < co.Count(); i++)
                        {
                            k++;
                            TBL_PrerequestCourse[] pre = sims.checkprerequestforgrade(raddept.SelectedValue, co[i].Course_code);
                            if (pre.Count() > 0)
                            {
                                for (int j = 0; j < pre.Count(); j++)
                                {
                                    TBL_studentGrade[] gr = sims.checkgradeprerequestforslip(txtstudid.Text, raddept.SelectedValue, pre[j].Prerequest_Course);
                                    if (gr.Count() > 0)
                                    {
                                        if (gr[j].Grade != "F")
                                        {
                                            DataRow dr = dt.NewRow();
                                            dr["S/N"] = k;
                                            dr["Course Title"] = co[i].Course_name;
                                            dr["Course Code"] = co[i].Course_code;
                                            dr["Credit Hour"] = Convert.ToInt32(co[i].Credit_hour);
                                            dr["Instructor"] = "staff";
                                            dt.Rows.Add(dr);
                                        }
                                        else
                                        {
                                            k = k - 1;
                                        }
                                    }
                                    else
                                    {

                                    }
                                }
                            }
                            else
                            {
                                DataRow drc = dt.NewRow();
                                drc["S/N"] = k;
                                drc["Course Title"] = co[i].Course_name;
                                drc["Course Code"] = co[i].Course_code;
                                drc["Credit Hour"] = Convert.ToInt32(co[i].Credit_hour);
                                drc["Instructor"] = "staff";
                                dt.Rows.Add(drc);
                            }


                        }

                        RadGrid1.DataSource = dt;
                        RadGrid1.DataBind();
                        anames.Text = "Advisors Name" + ".........................";
                        regi.Text = "Registrar" + ".......................";
                        sign.Text = "Signature" + " " + "...........................";
                        note.Text = "Notice:." + "1. This registration slip should not be signed by advisors without checking credit hours.";
                        no.Text = "       " + "2. proper references to catalogue are made regarding maximum and minimum credit hours load.";
                    }
                    else
                    {
                        name.Text = "No Slip Report First register in the current semister";
                        RadGrid1.Visible = false;
                    }
                }
                else if (radyear.SelectedValue == "I" && radsemister.SelectedValue == "II")
                {
                    if (checkreg.Count() > 0 && co.Count() > 0)
                    {
                        Image2.ImageUrl = "../images/";
                        string strDate = DateTime.Now.ToString("MM/dd/yyyy");
                        date.Text = "Date:" + " " + strDate + " " + "G.C";
                        name.Text = "Name:" + " " + checkreg[0].First_Name + " " + checkreg[0].Midle_Name + "      " + "ID.No.:" + "  " + checkreg[0].StudID + "   " +
                        "Dept:" + " " + raddept.Text;


                        ageandsex.Text = "Age:" + "   " + checkreg[0].Age + "   " + " Sex:" + " " + checkreg[0].Sex + "Nationality:" + " " + checkreg[0].Nationality + "        " + "Class Year:" + " " + radyear.SelectedValue + "  " + "Semister:" + " " + radsemister.Text + " " +
                           checkreg[0].Acadmic_Year + " " + "E.C" + "(A.Y)";

                        region.Text = "Region:" + "  " + checkreg[0].Region + "  " + "Zone:" + "  " + checkreg[0].Zone;
                        dt.Columns.Add("S/N");
                        dt.Columns.Add("Course Title");
                        dt.Columns.Add("Course Code");
                        dt.Columns.Add("Credit Hour");
                        dt.Columns.Add("Instructor");

                        for (int i = 0; i < co.Count(); i++)
                        {
                            k++;
                            TBL_PrerequestCourse[] pre = sims.checkprerequestforgrade(raddept.SelectedValue,co[i].Course_code);
                            if (pre.Count() > 0)
                            {
                                for (int j = 0; j < pre.Count(); j++)
                                {
                                    TBL_studentGrade[] gr = sims.checkgradeprerequestforslip(txtstudid.Text, raddept.SelectedValue, pre[j].Prerequest_Course);
                                    if (gr.Count() > 0)
                                    {
                                        if (gr[j].Grade != "F")
                                        {
                                            DataRow dr = dt.NewRow();
                                            dr["S/N"] = k;
                                            dr["Course Title"] = co[i].Course_name;
                                            dr["Course Code"] = co[i].Course_code;
                                            dr["Credit Hour"] = Convert.ToInt32(co[i].Credit_hour);
                                            dr["Instructor"] = "staff";
                                            dt.Rows.Add(dr);
                                        }
                                        else
                                        {
                                            k = k - 1;
                                        }
                                    }
                                    else
                                    { 
                                    
                                    }
                                }
                            }
                            else
                            {
                                DataRow drc = dt.NewRow();
                                drc["S/N"] = k ;
                                drc["Course Title"] = co[i].Course_name;
                                drc["Course Code"] = co[i].Course_code;
                                drc["Credit Hour"] = Convert.ToInt32(co[i].Credit_hour);
                                drc["Instructor"] = "staff";
                                dt.Rows.Add(drc);
                            }
                          
                        }

                        RadGrid1.DataSource = dt;
                        RadGrid1.DataBind();
                        anames.Text = "Advisors Name" + ".........................";
                        regi.Text = "Registrar" + ".......................";
                        sign.Text = "Signature" + " " + "...........................";
                        note.Text = "Notice:." + "1. This registration slip should not be signed by advisors without checking credit hours.";
                        no.Text = "       " + "2. proper references to catalogue are made regarding maximum and minimum credit hours load.";
                    }
                    else
                    {
                        name.Text = "No Slip Report First register in the current semister";
                        RadGrid1.Visible = false;
                    }
                }

                else if (radyear.SelectedValue == "II" && radsemister.SelectedValue == "I")
                {
                    if (checkreg.Count() > 0 && co.Count() > 0)
                    {
                        Image2.ImageUrl = "../images/";
                        string strDate = DateTime.Now.ToString("MM/dd/yyyy");
                        date.Text = "Date:" + " " + strDate + " " + "G.C";
                        name.Text = "Name:" + " " + checkreg[0].First_Name + " " + checkreg[0].Midle_Name + "      " + "ID.No.:" + "  " + checkreg[0].StudID + "   " +
                        "Dept:" + " " + raddept.Text;


                        ageandsex.Text = "Age:" + "   " + checkreg[0].Age + "   " + " Sex:" + " " + checkreg[0].Sex + "Nationality:" + " " + checkreg[0].Nationality + "        " + "Class Year:" + " " + radyear.SelectedValue + "  " + "Semister:" + " " + radsemister.Text + " " +
                           checkreg[0].Acadmic_Year + " " + "E.C" + "(A.Y)";

                        region.Text = "Region:" + "  " + checkreg[0].Region + "  " + "Zone:" + "  " + checkreg[0].Zone;
                        dt.Columns.Add("S/N");
                        dt.Columns.Add("Course Title");
                        dt.Columns.Add("Course Code");
                        dt.Columns.Add("Credit Hour");
                        dt.Columns.Add("Instructor");

                        for (int i = 0; i < co.Count(); i++)
                        {
                            k++;
                            TBL_PrerequestCourse[] pre = sims.checkprerequestforgrade(raddept.SelectedValue, co[i].Course_code);
                            if (pre.Count() > 0)
                            {
                                for (int j = 0; j < pre.Count(); j++)
                                {
                                    TBL_studentGrade[] gr = sims.checkgradeprerequestforslip(txtstudid.Text, raddept.SelectedValue, pre[j].Prerequest_Course);
                                    if (gr.Count() > 0)
                                    {
                                        if (gr[j].Grade != "F")
                                        {
                                            DataRow dr = dt.NewRow();
                                            dr["S/N"] = k;
                                            dr["Course Title"] = co[i].Course_name;
                                            dr["Course Code"] = co[i].Course_code;
                                            dr["Credit Hour"] = Convert.ToInt32(co[i].Credit_hour);
                                            dr["Instructor"] = "staff";
                                            dt.Rows.Add(dr);
                                        }
                                        else
                                        {
                                            k = k - 1;
                                        }
                                    }
                                    else
                                    {

                                    }
                                }
                            }
                            else
                            {
                                DataRow drc = dt.NewRow();
                                drc["S/N"] = k;
                                drc["Course Title"] = co[i].Course_name;
                                drc["Course Code"] = co[i].Course_code;
                                drc["Credit Hour"] = Convert.ToInt32(co[i].Credit_hour);
                                drc["Instructor"] = "staff";
                                dt.Rows.Add(drc);
                            }


                        }

                        RadGrid1.DataSource = dt;
                        RadGrid1.DataBind();
                        anames.Text = "Advisors Name" + ".........................";
                        regi.Text = "Registrar" + ".......................";
                        sign.Text = "Signature" + " " + "...........................";
                        note.Text = "Notice:." + "1. This registration slip should not be signed by advisors without checking credit hours.";
                        no.Text = "       " + "2. proper references to catalogue are made regarding maximum and minimum credit hours load.";
                    }
                    else
                    {
                        name.Text = "No Slip Report First register in the current semister";
                        RadGrid1.Visible = false;
                    }
                }

                else if (radyear.SelectedValue == "II" && radsemister.SelectedValue == "II")
                {
                    if (checkreg.Count() > 0 && co.Count() > 0)
                    {
                        Image2.ImageUrl = "../images/";
                        string strDate = DateTime.Now.ToString("MM/dd/yyyy");
                        date.Text = "Date:" + " " + strDate + " " + "G.C";
                        name.Text = "Name:" + " " + checkreg[0].First_Name + " " + checkreg[0].Midle_Name + "      " + "ID.No.:" + "  " + checkreg[0].StudID + "   " +
                        "Dept:" + " " + raddept.Text;


                        ageandsex.Text = "Age:" + "   " + checkreg[0].Age + "   " + " Sex:" + " " + checkreg[0].Sex + "Nationality:" + " " + checkreg[0].Nationality + "        " + "Class Year:" + " " + radyear.SelectedValue + "  " + "Semister:" + " " + radsemister.Text + " " +
                           checkreg[0].Acadmic_Year + " " + "E.C" + "(A.Y)";

                        region.Text = "Region:" + "  " + checkreg[0].Region + "  " + "Zone:" + "  " + checkreg[0].Zone;
                        dt.Columns.Add("S/N");
                        dt.Columns.Add("Course Title");
                        dt.Columns.Add("Course Code");
                        dt.Columns.Add("Credit Hour");
                        dt.Columns.Add("Instructor");

                        for (int i = 0; i < co.Count(); i++)
                        {
                            k++;
                            TBL_PrerequestCourse[] pre = sims.checkprerequestforgrade(raddept.SelectedValue, co[i].Course_code);
                            if (pre.Count() > 0)
                            {
                                for (int j = 0; j < pre.Count(); j++)
                                {
                                    TBL_studentGrade[] gr = sims.checkgradeprerequestforslip(txtstudid.Text, raddept.SelectedValue, pre[j].Prerequest_Course);
                                    if (gr.Count() > 0)
                                    {
                                        if (gr[j].Grade != "F")
                                        {
                                            DataRow dr = dt.NewRow();
                                            dr["S/N"] = k;
                                            dr["Course Title"] = co[i].Course_name;
                                            dr["Course Code"] = co[i].Course_code;
                                            dr["Credit Hour"] = Convert.ToInt32(co[i].Credit_hour);
                                            dr["Instructor"] = "staff";
                                            dt.Rows.Add(dr);
                                        }
                                        else
                                        {

                                        }
                                    }
                                    else
                                    {

                                    }
                                }
                            }
                            else
                            {
                                DataRow drc = dt.NewRow();
                                drc["S/N"] = k;
                                drc["Course Title"] = co[i].Course_name;
                                drc["Course Code"] = co[i].Course_code;
                                drc["Credit Hour"] = Convert.ToInt32(co[i].Credit_hour);
                                drc["Instructor"] = "staff";
                                dt.Rows.Add(drc);
                            }


                        }

                        RadGrid1.DataSource = dt;
                        RadGrid1.DataBind();
                        anames.Text = "Advisors Name" + ".........................";
                        regi.Text = "Registrar" + ".......................";
                        sign.Text = "Signature" + " " + "...........................";
                        note.Text = "Notice:." + "1. This registration slip should not be signed by advisors without checking credit hours.";
                        no.Text = "       " + "2. proper references to catalogue are made regarding maximum and minimum credit hours load.";
                    }
                    else
                    {
                        name.Text = "No Slip Report First register in the current semister";
                        RadGrid1.Visible = false;
                    }
                }

                else if (radyear.SelectedValue == "III" && radsemister.SelectedValue == "I")
                {
                    if (checkreg.Count() > 0 && co.Count() > 0)
                    {
                        Image2.ImageUrl = "../images/";
                        string strDate = DateTime.Now.ToString("MM/dd/yyyy");
                        date.Text = "Date:" + " " + strDate + " " + "G.C";
                        name.Text = "Name:" + " " + checkreg[0].First_Name + " " + checkreg[0].Midle_Name + "      " + "ID.No.:" + "  " + checkreg[0].StudID + "   " +
                        "Dept:" + " " + raddept.Text;


                        ageandsex.Text = "Age:" + "   " + checkreg[0].Age + "   " + " Sex:" + " " + checkreg[0].Sex + "Nationality:" + " " + checkreg[0].Nationality + "        " + "Class Year:" + " " + radyear.SelectedValue + "  " + "Semister:" + " " + radsemister.Text + " " +
                           checkreg[0].Acadmic_Year + " " + "E.C" + "(A.Y)";

                        region.Text = "Region:" + "  " + checkreg[0].Region + "  " + "Zone:" + "  " + checkreg[0].Zone;
                        dt.Columns.Add("S/N");
                        dt.Columns.Add("Course Title");
                        dt.Columns.Add("Course Code");
                        dt.Columns.Add("Credit Hour");
                        dt.Columns.Add("Instructor");

                        for (int i = 0; i < co.Count(); i++)
                        {
                            k++;
                            TBL_PrerequestCourse[] pre = sims.checkprerequestforgrade(raddept.SelectedValue, co[i].Course_code);
                            if (pre.Count() > 0)
                            {
                                for (int j = 0; j < pre.Count(); j++)
                                {
                                    TBL_studentGrade[] gr = sims.checkgradeprerequestforslip(txtstudid.Text, raddept.SelectedValue, pre[j].Prerequest_Course);
                                    if (gr.Count() > 0)
                                    {
                                        if (gr[j].Grade != "F")
                                        {
                                            DataRow dr = dt.NewRow();
                                            dr["S/N"] = k;
                                            dr["Course Title"] = co[i].Course_name;
                                            dr["Course Code"] = co[i].Course_code;
                                            dr["Credit Hour"] = Convert.ToInt32(co[i].Credit_hour);
                                            dr["Instructor"] = "staff";
                                            dt.Rows.Add(dr);
                                        }
                                        else
                                        {
                                            k = k - 1;
                                        }
                                    }
                                    else
                                    {

                                    }
                                }
                            }
                            else
                            {
                                DataRow drc = dt.NewRow();
                                drc["S/N"] = k;
                                drc["Course Title"] = co[i].Course_name;
                                drc["Course Code"] = co[i].Course_code;
                                drc["Credit Hour"] = Convert.ToInt32(co[i].Credit_hour);
                                drc["Instructor"] = "staff";
                                dt.Rows.Add(drc);
                            }


                        }

                        RadGrid1.DataSource = dt;
                        RadGrid1.DataBind();
                        anames.Text = "Advisors Name" + ".........................";
                        regi.Text = "Registrar" + ".......................";
                        sign.Text = "Signature" + " " + "...........................";
                        note.Text = "Notice:." + "1. This registration slip should not be signed by advisors without checking credit hours.";
                        no.Text = "       " + "2. proper references to catalogue are made regarding maximum and minimum credit hours load.";
                    }
                    else
                    {
                        name.Text = "No Slip Report First register in the current semister";
                        RadGrid1.Visible = false;
                    }
                }
                else if (radyear.SelectedValue == "III" && radsemister.SelectedValue == "II")
                {
                    if (checkreg.Count() > 0 && co.Count() > 0)
                    {
                        Image2.ImageUrl = "../images/";
                        string strDate = DateTime.Now.ToString("MM/dd/yyyy");
                        date.Text = "Date:" + " " + strDate + " " + "G.C";
                        name.Text = "Name:" + " " + checkreg[0].First_Name + " " + checkreg[0].Midle_Name + "      " + "ID.No.:" + "  " + checkreg[0].StudID + "   " +
                        "Dept:" + " " + raddept.Text;


                        ageandsex.Text = "Age:" + "   " + checkreg[0].Age + "   " + " Sex:" + " " + checkreg[0].Sex + "Nationality:" + " " + checkreg[0].Nationality + "        " + "Class Year:" + " " + radyear.SelectedValue + "  " + "Semister:" + " " + radsemister.Text + " " +
                           checkreg[0].Acadmic_Year + " " + "E.C" + "(A.Y)";

                        region.Text = "Region:" + "  " + checkreg[0].Region + "  " + "Zone:" + "  " + checkreg[0].Zone;
                        dt.Columns.Add("S/N");
                        dt.Columns.Add("Course Title");
                        dt.Columns.Add("Course Code");
                        dt.Columns.Add("Credit Hour");
                        dt.Columns.Add("Instructor");

                        for (int i = 0; i < co.Count(); i++)
                        {
                            k++;
                            TBL_PrerequestCourse[] pre = sims.checkprerequestforgrade(raddept.SelectedValue, co[i].Course_code);
                            if (pre.Count() > 0)
                            {
                                for (int j = 0; j < pre.Count(); j++)
                                {
                                    TBL_studentGrade[] gr =sims.checkgradeprerequestforslip(txtstudid.Text, raddept.SelectedValue, pre[j].Prerequest_Course);
                                    if (gr.Count() > 0)
                                    {
                                        if (gr[j].Grade != "F")
                                        {
                                            DataRow dr = dt.NewRow();
                                            dr["S/N"] = k;
                                            dr["Course Title"] = co[i].Course_name;
                                            dr["Course Code"] = co[i].Course_code;
                                            dr["Credit Hour"] = Convert.ToInt32(co[i].Credit_hour);
                                            dr["Instructor"] = "staff";
                                            dt.Rows.Add(dr);
                                        }
                                        else
                                        {
                                            k = k - 1;
                                        }
                                    }
                                    else
                                    {

                                    }
                                }
                            }
                            else
                            {
                                DataRow drc = dt.NewRow();
                                drc["S/N"] = k;
                                drc["Course Title"] = co[i].Course_name;
                                drc["Course Code"] = co[i].Course_code;
                                drc["Credit Hour"] = Convert.ToInt32(co[i].Credit_hour);
                                drc["Instructor"] = "staff";
                                dt.Rows.Add(drc);
                            }


                        }

                        RadGrid1.DataSource = dt;
                        RadGrid1.DataBind();
                        anames.Text = "Advisors Name" + ".........................";
                        regi.Text = "Registrar" + ".......................";
                        sign.Text = "Signature" + " " + "...........................";
                        note.Text = "Notice:." + "1. This registration slip should not be signed by advisors without checking credit hours.";
                        no.Text = "       " + "2. proper references to catalogue are made regarding maximum and minimum credit hours load.";
                    }
                    else
                    {
                        name.Text = "No Slip Report First register in the current semister";
                        RadGrid1.Visible = false;
                    }
                }
                else if (radyear.SelectedValue == "IV" && radsemister.SelectedValue == "I")
                {
                    if (checkreg.Count() > 0 && co.Count() > 0)
                    {
                        Image2.ImageUrl = "../images/";
                        string strDate = DateTime.Now.ToString("MM/dd/yyyy");
                        date.Text = "Date:" + " " + strDate + " " + "G.C";
                        name.Text = "Name:" + " " + checkreg[0].First_Name + " " + checkreg[0].Midle_Name + "      " + "ID.No.:" + "  " + checkreg[0].StudID + "   " +
                        "Dept:" + " " + raddept.Text;


                        ageandsex.Text = "Age:" + "   " + checkreg[0].Age + "   " + " Sex:" + " " + checkreg[0].Sex + "Nationality:" + " " + checkreg[0].Nationality + "        " + "Class Year:" + " " + radyear.SelectedValue + "  " + "Semister:" + " " + radsemister.Text + " " +
                           checkreg[0].Acadmic_Year + " " + "E.C" + "(A.Y)";

                        region.Text = "Region:" + "  " + checkreg[0].Region + "  " + "Zone:" + "  " + checkreg[0].Zone;
                        dt.Columns.Add("S/N");
                        dt.Columns.Add("Course Title");
                        dt.Columns.Add("Course Code");
                        dt.Columns.Add("Credit Hour");
                        dt.Columns.Add("Instructor");

                        for (int i = 0; i < co.Count(); i++)
                        {
                            k++;
                            TBL_PrerequestCourse[] pre = sims.checkprerequestforgrade(raddept.SelectedValue, co[i].Course_code);
                            if (pre.Count() > 0)
                            {
                                for (int j = 0; j < pre.Count(); j++)
                                {
                                    TBL_studentGrade[] gr = sims.checkgradeprerequestforslip(txtstudid.Text, raddept.SelectedValue, pre[j].Prerequest_Course);
                                    if (gr.Count() > 0)
                                    {
                                        if (gr[j].Grade != "F")
                                        {
                                            DataRow dr = dt.NewRow();
                                            dr["S/N"] = k;
                                            dr["Course Title"] = co[i].Course_name;
                                            dr["Course Code"] = co[i].Course_code;
                                            dr["Credit Hour"] = Convert.ToInt32(co[i].Credit_hour);
                                            dr["Instructor"] = "staff";
                                            dt.Rows.Add(dr);
                                        }
                                        else
                                        {
                                            k = k - 1;
                                        }
                                    }
                                    else
                                    {

                                    }
                                }
                            }
                            else
                            {
                                DataRow drc = dt.NewRow();
                                drc["S/N"] = k;
                                drc["Course Title"] = co[i].Course_name;
                                drc["Course Code"] = co[i].Course_code;
                                drc["Credit Hour"] = Convert.ToInt32(co[i].Credit_hour);
                                drc["Instructor"] = "staff";
                                dt.Rows.Add(drc);
                            }

                        }

                        RadGrid1.DataSource = dt;
                        RadGrid1.DataBind();
                        anames.Text = "Advisors Name" + ".........................";
                        regi.Text = "Registrar" + ".......................";
                        sign.Text = "Signature" + " " + "...........................";
                        note.Text = "Notice:." + "1. This registration slip should not be signed by advisors without checking credit hours.";
                        no.Text = "       " + "2. proper references to catalogue are made regarding maximum and minimum credit hours load.";
                    }
                    else
                    {
                        name.Text = "No Slip Report First register in the current semister";
                        RadGrid1.Visible = false;
                    }
                }
                else if (radyear.SelectedValue == "IV" && radsemister.SelectedValue == "II")
                {
                    if (checkreg.Count() > 0 && co.Count() > 0)
                    {
                        Image2.ImageUrl = "../images/";
                        string strDate = DateTime.Now.ToString("MM/dd/yyyy");
                        date.Text = "Date:" + " " + strDate + " " + "G.C";
                        name.Text = "Name:" + " " + checkreg[0].First_Name + " " + checkreg[0].Midle_Name + "      " + "ID.No.:" + "  " + checkreg[0].StudID + "   " +
                        "Dept:" + " " + raddept.Text;


                        ageandsex.Text = "Age:" + "   " + checkreg[0].Age + "   " + " Sex:" + " " + checkreg[0].Sex + "Nationality:" + " " + checkreg[0].Nationality + "        " + "Class Year:" + " " + radyear.SelectedValue + "  " + "Semister:" + " " + radsemister.Text + " " +
                           checkreg[0].Acadmic_Year + " " + "E.C" + "(A.Y)";

                        region.Text = "Region:" + "  " + checkreg[0].Region + "  " + "Zone:" + "  " + checkreg[0].Zone;
                        dt.Columns.Add("S/N");
                        dt.Columns.Add("Course Title");
                        dt.Columns.Add("Course Code");
                        dt.Columns.Add("Credit Hour");
                        dt.Columns.Add("Instructor");

                        for (int i = 0; i < co.Count(); i++)
                        {
                            k++;
                            TBL_PrerequestCourse[] pre =sims.checkprerequestforgrade(raddept.SelectedValue, co[i].Course_code);
                            if (pre.Count() > 0)
                            {
                                for (int j = 0; j < pre.Count(); j++)
                                {
                                    TBL_studentGrade[] gr = sims.checkgradeprerequestforslip(txtstudid.Text, raddept.SelectedValue, pre[j].Prerequest_Course);
                                    if (gr.Count() > 0)
                                    {
                                        if (gr[j].Grade != "F")
                                        {
                                            DataRow dr = dt.NewRow();
                                            dr["S/N"] = k;
                                            dr["Course Title"] = co[i].Course_name;
                                            dr["Course Code"] = co[i].Course_code;
                                            dr["Credit Hour"] = Convert.ToInt32(co[i].Credit_hour);
                                            dr["Instructor"] = "staff";
                                            dt.Rows.Add(dr);
                                        }
                                        else
                                        {
                                            k = k - 1;
                                        }
                                    }
                                    else
                                    {

                                    }
                                }
                            }
                            else
                            {
                                DataRow drc = dt.NewRow();
                                drc["S/N"] = k;
                                drc["Course Title"] = co[i].Course_name;
                                drc["Course Code"] = co[i].Course_code;
                                drc["Credit Hour"] = Convert.ToInt32(co[i].Credit_hour);
                                drc["Instructor"] = "staff";
                                dt.Rows.Add(drc);
                            }

                        }

                        RadGrid1.DataSource = dt;
                        RadGrid1.DataBind();
                        anames.Text = "Advisors Name" + ".........................";
                        regi.Text = "Registrar" + ".......................";
                        sign.Text = "Signature" + " " + "...........................";
                        note.Text = "Notice:." + "1. This registration slip should not be signed by advisors without checking credit hours.";
                        no.Text = "       " + "2. proper references to catalogue are made regarding maximum and minimum credit hours load.";
                    }
                    else
                    {
                        name.Text = "No Slip Report First register in the current semister";
                        RadGrid1.Visible = false;
                    }
                }
                else if (radyear.SelectedValue == "V" && radsemister.SelectedValue == "I")
                {
                    if (checkreg.Count() > 0 && co.Count() > 0)
                    {
                        Image2.ImageUrl = "../images/";
                        string strDate = DateTime.Now.ToString("MM/dd/yyyy");
                        date.Text = "Date:" + " " + strDate + " " + "G.C";
                        name.Text = "Name:" + " " + checkreg[0].First_Name + " " + checkreg[0].Midle_Name + "      " + "ID.No.:" + "  " + checkreg[0].StudID + "   " +
                        "Dept:" + " " + raddept.Text;


                        ageandsex.Text = "Age:" + "   " + checkreg[0].Age + "   " + " Sex:" + " " + checkreg[0].Sex + "Nationality:" + " " + checkreg[0].Nationality + "        " + "Class Year:" + " " + radyear.SelectedValue + "  " + "Semister:" + " " + radsemister.Text + " " +
                           checkreg[0].Acadmic_Year + " " + "E.C" + "(A.Y)";

                        region.Text = "Region:" + "  " + checkreg[0].Region + "  " + "Zone:" + "  " + checkreg[0].Zone;
                        dt.Columns.Add("S/N");
                        dt.Columns.Add("Course Title");
                        dt.Columns.Add("Course Code");
                        dt.Columns.Add("Credit Hour");
                        dt.Columns.Add("Instructor");

                        for (int i = 0; i < co.Count(); i++)
                        {
                            k++;
                            TBL_PrerequestCourse[] pre = sims.checkprerequestforgrade(raddept.SelectedValue, co[i].Course_code);
                            if (pre.Count() > 0)
                            {
                                for (int j = 0; j < pre.Count(); j++)
                                {
                                    TBL_studentGrade[] gr = sims.checkgradeprerequestforslip(txtstudid.Text, raddept.SelectedValue, pre[j].Prerequest_Course);
                                    if (gr.Count() > 0)
                                    {
                                        if (gr[j].Grade != "F")
                                        {
                                            DataRow dr = dt.NewRow();
                                            dr["S/N"] = k;
                                            dr["Course Title"] = co[i].Course_name;
                                            dr["Course Code"] = co[i].Course_code;
                                            dr["Credit Hour"] = Convert.ToInt32(co[i].Credit_hour);
                                            dr["Instructor"] = "staff";
                                            dt.Rows.Add(dr);
                                        }
                                        else
                                        {
                                            k = k - 1;
                                        }
                                    }
                                    else
                                    {

                                    }
                                }
                            }
                            else
                            {
                                DataRow drc = dt.NewRow();
                                drc["S/N"] = k;
                                drc["Course Title"] = co[i].Course_name;
                                drc["Course Code"] = co[i].Course_code;
                                drc["Credit Hour"] = Convert.ToInt32(co[i].Credit_hour);
                                drc["Instructor"] = "staff";
                                dt.Rows.Add(drc);
                            }

                        }

                        RadGrid1.DataSource = dt;
                        RadGrid1.DataBind();
                        anames.Text = "Advisors Name" + ".........................";
                        regi.Text = "Registrar" + ".......................";
                        sign.Text = "Signature" + " " + "...........................";
                        note.Text = "Notice:." + "1. This registration slip should not be signed by advisors without checking credit hours.";
                        no.Text = "       " + "2. proper references to catalogue are made regarding maximum and minimum credit hours load.";
                    }
                    else
                    {
                        name.Text = "No Slip Report First register in the current semister";
                        RadGrid1.Visible = false;
                    }
                }
                else if (radyear.SelectedValue == "V" && radsemister.SelectedValue == "II")
                {
                    if (checkreg.Count() > 0 && co.Count() > 0)
                    {
                        Image2.ImageUrl = "../";
                        string strDate = DateTime.Now.ToString("MM/dd/yyyy");
                        date.Text = "Date:" + " " + strDate + " " + "G.C";
                        name.Text = "Name:" + " " + checkreg[0].First_Name + " " + checkreg[0].Midle_Name + "      " + "ID.No.:" + "  " + checkreg[0].StudID + "   " +
                        "Dept:" + " " + raddept.Text;


                        ageandsex.Text = "Age:" + "   " + checkreg[0].Age + "   " + " Sex:" + " " + checkreg[0].Sex + "Nationality:" + " " + checkreg[0].Nationality + "        " + "Class Year:" + " " + radyear.SelectedValue + "  " + "Semister:" + " " + radsemister.Text + " " +
                           checkreg[0].Acadmic_Year + " " + "E.C" + "(A.Y)";

                        region.Text = "Region:" + "  " + checkreg[0].Region + "  " + "Zone:" + "  " + checkreg[0].Zone;
                        dt.Columns.Add("S/N");
                        dt.Columns.Add("Course Title");
                        dt.Columns.Add("Course Code");
                        dt.Columns.Add("Credit Hour");
                        dt.Columns.Add("Instructor");

                        for (int i = 0; i < co.Count(); i++)
                        {
                            k++;
                            TBL_PrerequestCourse[] pre = sims.checkprerequestforgrade(raddept.SelectedValue, co[i].Course_code);
                            if (pre.Count() > 0)
                            {
                                for (int j = 0; j < pre.Count(); j++)
                                {
                                    TBL_studentGrade[] gr = sims.checkgradeprerequestforslip(txtstudid.Text, raddept.SelectedValue, pre[j].Prerequest_Course);
                                    if (gr.Count() > 0)
                                    {
                                        if (gr[j].Grade != "F")
                                        {
                                            DataRow dr = dt.NewRow();
                                            dr["S/N"] = k;
                                            dr["Course Title"] = co[i].Course_name;
                                            dr["Course Code"] = co[i].Course_code;
                                            dr["Credit Hour"] = Convert.ToInt32(co[i].Credit_hour);
                                            dr["Instructor"] = "staff";
                                            dt.Rows.Add(dr);
                                        }
                                        else
                                        {
                                            k = k - 1;
                                        }
                                    }
                                    else
                                    {

                                    }
                                }
                            }
                            else
                            {
                                DataRow drc = dt.NewRow();
                                drc["S/N"] = k;
                                drc["Course Title"] = co[i].Course_name;
                                drc["Course Code"] = co[i].Course_code;
                                drc["Credit Hour"] = Convert.ToInt32(co[i].Credit_hour);
                                drc["Instructor"] = "staff";
                                dt.Rows.Add(drc);
                            }


                        }

                        RadGrid1.DataSource = dt;
                        RadGrid1.DataBind();
                        anames.Text = "Advisors Name" + ".........................";
                        regi.Text = "Registrar" + ".......................";
                        sign.Text = "Signature" + " " + "...........................";
                        note.Text = "Notice:." + "1. This registration slip should not be signed by advisors without checking credit hours.";
                        no.Text = "       " + "2. proper references to catalogue are made regarding maximum and minimum credit hours load.";
                    }
                    else
                    {
                        name.Text = "No Slip Report First register in the current semister";
                        RadGrid1.Visible = false;
                    }
                }
                else if (radyear.SelectedValue == "VI" && radsemister.SelectedValue == "I")
                {
                    if (checkreg.Count() > 0 && co.Count() > 0)
                    {
                        Image2.ImageUrl = "../images/";
                        string strDate = DateTime.Now.ToString("MM/dd/yyyy");
                        date.Text = "Date:" + " " + strDate + " " + "G.C";
                        name.Text = "Name:" + " " + checkreg[0].First_Name + " " + checkreg[0].Midle_Name + "      " + "ID.No.:" + "  " + checkreg[0].StudID + "   " +
                        "Dept:" + " " + raddept.Text;


                        ageandsex.Text = "Age:" + "   " + checkreg[0].Age + "   " + " Sex:" + " " + checkreg[0].Sex + "Nationality:" + " " + checkreg[0].Nationality + "        " + "Class Year:" + " " + radyear.SelectedValue + "  " + "Semister:" + " " + radsemister.Text + " " +
                           checkreg[0].Acadmic_Year + " " + "E.C" + "(A.Y)";

                        region.Text = "Region:" + "  " + checkreg[0].Region + "  " + "Zone:" + "  " + checkreg[0].Zone;
                        dt.Columns.Add("S/N");
                        dt.Columns.Add("Course Title");
                        dt.Columns.Add("Course Code");
                        dt.Columns.Add("Credit Hour");
                        dt.Columns.Add("Instructor");

                        for (int i = 0; i < co.Count(); i++)
                        {
                            k++;
                            TBL_PrerequestCourse[] pre = sims.checkprerequestforgrade(raddept.SelectedValue, co[i].Course_code);
                            if (pre.Count() > 0)
                            {
                                for (int j = 0; j < pre.Count(); j++)
                                {
                                    TBL_studentGrade[] gr = sims.checkgradeprerequestforslip(txtstudid.Text, raddept.SelectedValue, pre[j].Prerequest_Course);
                                    if (gr.Count() > 0)
                                    {
                                        if (gr[j].Grade != "F")
                                        {
                                            DataRow dr = dt.NewRow();
                                            dr["S/N"] = k;
                                            dr["Course Title"] = co[i].Course_name;
                                            dr["Course Code"] = co[i].Course_code;
                                            dr["Credit Hour"] = Convert.ToInt32(co[i].Credit_hour);
                                            dr["Instructor"] = "staff";
                                            dt.Rows.Add(dr);
                                        }
                                        else
                                        {
                                            k = k - 1;
                                        }
                                    }
                                    else
                                    {

                                    }
                                }
                            }
                            else
                            {
                                DataRow drc = dt.NewRow();
                                drc["S/N"] = k;
                                drc["Course Title"] = co[i].Course_name;
                                drc["Course Code"] = co[i].Course_code;
                                drc["Credit Hour"] = Convert.ToInt32(co[i].Credit_hour);
                                drc["Instructor"] = "staff";
                                dt.Rows.Add(drc);
                            }

                        }

                        RadGrid1.DataSource = dt;
                        RadGrid1.DataBind();
                        anames.Text = "Advisors Name" + ".........................";
                        regi.Text = "Registrar" + ".......................";
                        sign.Text = "Signature" + " " + "...........................";
                        note.Text = "Notice:." + "1. This registration slip should not be signed by advisors without checking credit hours.";
                        no.Text = "       " + "2. proper references to catalogue are made regarding maximum and minimum credit hours load.";
                    }
                    else
                    {
                        name.Text = "No Slip Report First register in the current semister";
                        RadGrid1.Visible = false;
                    }
                }
                else if (radyear.SelectedValue == "VI" && radsemister.SelectedValue == "II")
                {
                    if (checkreg.Count() > 0 && co.Count() > 0)
                    {
                        Image2.ImageUrl = "../images/";
                        string strDate = DateTime.Now.ToString("MM/dd/yyyy");
                        date.Text = "Date:" + " " + strDate + " " + "G.C";
                        name.Text = "Name:" + " " + checkreg[0].First_Name + " " + checkreg[0].Midle_Name + "      " + "ID.No.:" + "  " + checkreg[0].StudID + "   " +
                        "Dept:" + " " + raddept.Text;


                        ageandsex.Text = "Age:" + "   " + checkreg[0].Age + "   " + " Sex:" + " " + checkreg[0].Sex + "Nationality:" + " " + checkreg[0].Nationality + "        " + "Class Year:" + " " + radyear.SelectedValue + "  " + "Semister:" + " " + radsemister.Text + " " +
                           checkreg[0].Acadmic_Year + " " + "E.C" + "(A.Y)";

                        region.Text = "Region:" + "  " + checkreg[0].Region + "  " + "Zone:" + "  " + checkreg[0].Zone;
                        dt.Columns.Add("S/N");
                        dt.Columns.Add("Course Title");
                        dt.Columns.Add("Course Code");
                        dt.Columns.Add("Credit Hour");
                        dt.Columns.Add("Instructor");

                        for (int i = 0; i < co.Count(); i++)
                        {
                            k++;
                            TBL_PrerequestCourse[] pre = sims.checkprerequestforgrade(raddept.SelectedValue, co[i].Course_code);
                            if (pre.Count() > 0)
                            {
                                for (int j = 0; j < pre.Count(); j++)
                                {
                                    TBL_studentGrade[] gr = sims.checkgradeprerequestforslip(txtstudid.Text, raddept.SelectedValue, pre[j].Prerequest_Course);
                                    if (gr.Count() > 0)
                                    {
                                        if (gr[j].Grade != "F")
                                        {
                                            DataRow dr = dt.NewRow();
                                            dr["S/N"] = k;
                                            dr["Course Title"] = co[i].Course_name;
                                            dr["Course Code"] = co[i].Course_code;
                                            dr["Credit Hour"] = Convert.ToInt32(co[i].Credit_hour);
                                            dr["Instructor"] = "staff";
                                            dt.Rows.Add(dr);
                                        }
                                        else
                                        {
                                            k = k - 1;
                                        }
                                    }
                                    else
                                    {

                                    }
                                }
                            }
                            else
                            {
                                DataRow drc = dt.NewRow();
                                drc["S/N"] = k;
                                drc["Course Title"] = co[i].Course_name;
                                drc["Course Code"] = co[i].Course_code;
                                drc["Credit Hour"] = Convert.ToInt32(co[i].Credit_hour);
                                drc["Instructor"] = "staff";
                                dt.Rows.Add(drc);
                            }


                        }

                        RadGrid1.DataSource = dt;
                        RadGrid1.DataBind();
                        anames.Text = "Advisors Name" + ".........................";
                        regi.Text = "Registrar" + ".......................";
                        sign.Text = "Signature" + " " + "...........................";
                        note.Text = "Notice:." + "1. This registration slip should not be signed by advisors without checking credit hours.";
                        no.Text = "       " + "2. proper references to catalogue are made regarding maximum and minimum credit hours load.";
                    }
                    else
                    {
                        name.Text = "No Slip Report First register in the current semister";
                        RadGrid1.Visible = false;
                    }
                }



            }
        }
        }

