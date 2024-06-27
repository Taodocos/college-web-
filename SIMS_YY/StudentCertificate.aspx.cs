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
    public partial class StudentCertificate : System.Web.UI.Page
    {
        SIMS sims = new SIMS();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                SearchCollege();
                label.Visible = true;

                
                hu.Visible = false;
                tempo.Visible = false;
                certify.Visible = false;
                cert.Visible = false;
                dept.Visible = false;
                regsig.Visible = false;
                reg.Visible = false;
                dean.Visible = false;
                deansign.Visible = false;
                // label.Visible = false;
            }
    
        }
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
        private void searchstudentIDthirdyear()
        {
            radStudID.DataTextField = "StudID";
            radStudID.DataValueField = "StudID";
            radStudID.DataSource = sims.SearchGCstudent(raddept.SelectedValue, "III", "II");
            radStudID.DataBind();
        }
        private void searchstudentIDFourthyear()
        {
            radStudID.DataTextField = "StudID";
            radStudID.DataValueField = "StudID";
            radStudID.DataSource = sims.SearchGCstudent(raddept.SelectedValue, "IV", "II");
            radStudID.DataBind();
        }
        private void searchstudentIDFivththyear()
        {
            radStudID.DataTextField = "StudID";
            radStudID.DataValueField = "StudID";
            radStudID.DataSource = sims.SearchGCstudent(raddept.SelectedValue, "V", "II");
            radStudID.DataBind();
        }
        private void searchstudentIDveternarythyear()
        {
            radStudID.DataTextField = "StudID";
            radStudID.DataValueField = "StudID";
            radStudID.DataSource = sims.SearchGCstudent(raddept.SelectedValue, "VI", "II");
            radStudID.DataBind();
        }
        protected void radcollege_SelectedIndexChanged(object sender, EventArgs e)
        {
            TBL_department[] depts = sims.searchalldepartmentbycollege(radcollege.SelectedValue);
            label.Text = "";
            if (depts.Count() > 0)
            {
                // radcollege.Text = dept[0].College_Code;
                searchdepartment();

            }
            else
            {
                raddept.Items.Clear();
                label.Text = "this college no department";
            }
            label.Visible = true;

           
           hu.Visible = false;
            tempo.Visible = false;
            certify.Visible = false;
            cert.Visible = false;
            dept.Visible = false;
            regsig.Visible = false;
            reg.Visible = false;
            dean.Visible = false;
            deansign.Visible = false;
          
        }

        protected void raddept_SelectedIndexChanged(object sender, EventArgs e)
        {
            label.Visible = true;

            Image1.Visible = false;
            Image2.Visible = false;
            Image3.Visible = false;
            hu.Visible = false;
            tempo.Visible = false;
            certify.Visible = false;
            cert.Visible = false;
            dept.Visible = false;
            regsig.Visible = false;
            reg.Visible = false;
            dean.Visible = false;
            deansign.Visible = false;
            //TBL_FreshStudent[] studid = StudID.searchstudentidbydept(raddept.SelectedValue);
            TBL_RegisterStudent[] stud = sims.SearchGCstudent(raddept.SelectedValue, "IV", "II");
            TBL_RegisterStudent[] third = sims.SearchGCstudent(raddept.SelectedValue, "III", "II");
            try
            {
                if (radcollege.SelectedValue == "YU_College-0")
                {
                    if (raddept.SelectedValue == "YU_Dept/3")
                    {
                        if (third.Count() > 0)
                        {
                            // radStudID.Text = studid[0].Stud_ID;

                            searchstudentIDthirdyear();

                        }
                        else
                        {
                            label.Text ="There is no GC student in"+" "+raddept.Text;
                        }
                    }
                    else
                    {
                        if (stud.Count() > 0)
                        {
                            // radStudID.Text = studid[0].Stud_ID;
                            searchstudentIDFourthyear();


                        }
                        else
                        {
                            label.Text ="There is no GC student in"+" "+raddept.Text;
                        }
                    }
                }
                else if (radcollege.SelectedValue == "YU_College-1" || radcollege.SelectedValue == "YU_College-2" || radcollege.SelectedValue == "YU_College-5" || radcollege.SelectedValue == "HU_College-6")
                {
                    if (third.Count() > 0)
                    {
                        // radStudID.Text = studid[0].Stud_ID;

                        searchstudentIDthirdyear();

                    }
                    else
                    {
                        label.Text ="There is no GC student in"+" "+raddept.Text;
                    }
                }
                else if (radcollege.SelectedValue == "YU_College-4" || radcollege.SelectedValue == "YU_College-8")
                {
                    TBL_RegisterStudent[] chek = certficate.SearchGCstudent(raddept.SelectedValue, "V", "II");
                    if (chek.Count() > 0)
                    {
                        searchstudentIDFivththyear();

                    }
                    else
                    {
                        //radStudID.Items.Clear();
                        label.Text ="There is no GC student in"+" "+raddept.Text;
                    }
                }
                else if (radcollege.SelectedValue == "YU_College-7")
                {
                    TBL_RegisterStudent[] chek = certficate.SearchGCstudent(raddept.SelectedValue, "VI", "II");
                    if (chek.Count() > 0)
                    {
                        searchstudentIDveternarythyear();

                    }
                    else
                    {
                        //radStudID.Items.Clear();
                        label.Text ="There is no GC student in"+" "+raddept.Text;
                    }
                }

            }
            catch (Exception ex)
            {
                label.Text = "Some Exception Occured";
            }

        }

        protected void btngenerate_Click(object sender, EventArgs e)
        {
            try
            {
                generatecertificate();
                label.Visible = true;

                Image1.Visible = true;
                Image2.Visible = true;
                Image3.Visible = true;
                hu.Visible = true;
                tempo.Visible = true;
                certify.Visible = true;
                cert.Visible = true;
                dept.Visible = true;
                regsig.Visible = true;
                reg.Visible = true;
                dean.Visible = true;
                deansign.Visible = true;
            }
            catch(Exception)
            {
                label.Text = "some Exception occurred check again";
            }
        }
        void generatecertificate()
        {
            int totalcredithour = 0;
            int totalcredit=0;
            float totalpoint = 0;

            TBL_RegisterStudent[] studidfourth = sims.searchstudforgradereport(radStudID.Text, "IV", "II");
            TBL_RegisterStudent[] studidfivth = sims.searchstudforgradereport(radStudID.Text, "V", "II");
            TBL_RegisterStudent[] studidveternary = sims.searchstudforgradereport(radStudID.Text, "VI", "II");
            TBL_RegisterStudent[] studidthird = sims.searchstudforgradereport(radStudID.Text, "III", "II");
            TBL_Course[] co = sims.searchcoursebydept(raddept.SelectedValue);
            TBL_studentGrade[] gre = sims.searchstudgradebyIDNo(radStudID.Text);
            TBL_studentGrade[] Fgrade = sims.searchstudgradebyIDNOandgrede(radStudID.Text, "F");
            
            valids.addComponent(radcollege, ComponentValidator.NO_FORMAT, true);
            valids.addComponent(raddept, ComponentValidator.NO_FORMAT, true);
            valids.addComponent(radStudID, ComponentValidator.NO_FORMAT, true);
            if (valids.isAllComponenetValid())
            {
                for (int i = 0; i < co.Count(); i++)
                {
                    totalcredithour = totalcredithour + Convert.ToInt32(co[i].Credit_hour);
                    //label.Text = Convert.ToString(gre.Count());
                }
                if (co.Count() == gre.Count())
                {
                    if (radcollege.SelectedValue == "YU_College-0")
                    {
                        if (raddept.SelectedValue == "YU_Dept/3")
                        {
                            TBL_studentGrade[] stugrade = sims.viewgrade(radStudID.SelectedValue, "III", "II");
                            TBL_Course[] cor = certficate.searchcoursebydys(raddept.SelectedValue, "III", "II");
                            if ((totalcredithour >= 102 && totalcredithour <= 114) && Fgrade.Count() == 0)
                            {
                                if (FileUpload1.HasFile)
                                {
                                    TBL_GradeReport[] checkcumulative = sims.checkgradereport(radStudID.SelectedValue, "III", "I");
                                    int credit = 0;
                                    for (int i = 0; i < cor.Count(); i++)
                                    {
                                        for (int j = 0; j < stugrade.Count(); j++)
                                        {
                                            if (cor[i].Course_code == stugrade[j].Course_Code)
                                            {

                                                if (stugrade[j].Grade == "A")
                                                {
                                                    credit = Convert.ToInt32(co[i].Credit_hour * 4);
                                                }
                                                else if (stugrade[j].Grade == "A-")
                                                {
                                                    credit = Convert.ToInt32(co[i].Credit_hour * 3.75);
                                                }
                                                else if (stugrade[j].Grade == "B+")
                                                {
                                                    credit = Convert.ToInt32(co[i].Credit_hour * 3.5);
                                                }
                                                else if (stugrade[j].Grade == "B")
                                                {
                                                    credit = Convert.ToInt32(co[i].Credit_hour * 3);
                                                }
                                                else if (stugrade[j].Grade == "B-")
                                                {
                                                    credit = Convert.ToInt32(co[i].Credit_hour * 2.75);
                                                }
                                                else if (stugrade[j].Grade == "C+")
                                                {
                                                    credit = Convert.ToInt32(co[i].Credit_hour * 2.5);
                                                }
                                                else if (stugrade[j].Grade == "C")
                                                {
                                                    credit = Convert.ToInt32(co[i].Credit_hour * 2);
                                                }
                                                else if (stugrade[j].Grade == "C-")
                                                {
                                                    credit = Convert.ToInt32(co[i].Credit_hour * 1.75);
                                                }
                                                else if (stugrade[j].Grade == "D")
                                                {
                                                    credit = Convert.ToInt32(co[i].Credit_hour * 1);
                                                }
                                                else
                                                {
                                                    credit = Convert.ToInt32(co[i].Credit_hour * 0);
                                                }
                                                totalcredit = totalcredit + Convert.ToInt32(co[i].Credit_hour);
                                                totalpoint = totalpoint + credit;

                                            }
                                        }
                                    }
                                    totalcredit = Convert.ToInt32(totalcredit + checkcumulative[0].TotalCredit);

                                    totalpoint = Convert.ToSingle(totalpoint + checkcumulative[0].TotalPoint);

                                    Double Cgpa = Convert.ToSingle((totalpoint + checkcumulative[0].TotalPoint) / (totalcredit + checkcumulative[0].TotalCredit));
                                    Double cgpa = Math.Round(Cgpa, 2);
                                    cgpad.Text = "CGPA:" + " " + cgpa;
                                    String Str = FileUpload1.FileName;
                                    FileUpload1.PostedFile.SaveAs(Server.MapPath(".") + "//uploads//" + Str);
                                    String path = "~//uploads//" + Str.ToString();


                                    hu.Text = "YEJU UNIVERSITY";
                                    Image2.ImageUrl = "uploads/" + Str.ToString();
                                    Image1.ImageUrl = "../images/logo.jpg";
                                    Image3.ImageUrl = "../images/tel.PNG";
                                    tempo.Text = "TEMPORARY CERTIFICATE OF COMPLETION ";
                                    certify.Text = "This is to certfiy that" + " " + studidthird[0].First_Name + " " + studidthird[0].Midle_Name + " " + studidthird[0].Last_Name; ;

                                    cert.Text = "Has successfully fulfilled the requirements of";
                                    dept.Text = "Bachelor of Science degree in" + " " + raddept.Text;
                                    reg.Text = "University Registrar";
                                    dean.Text = " Dean," + " " + radcollege.Text;
                                }
                                else
                                {
                                    label.ForeColor = Color.Red;
                                    label.Text = "please select the student photo";

                                }
                            }
                            else
                            {
                                label.Text = "IDNo.:" + radStudID.Text + " " + " Doesn't fulfill All requirements to graduate (get a degree)from a program.";
                            }
                        }
                        else
                        {
                            TBL_studentGrade[] stugrade = sims.viewgrade(radStudID.SelectedValue, "IV", "II");
                            TBL_Course[] cor = certficate.searchcoursebydys(raddept.SelectedValue, "IV", "II");
                            if ((totalcredithour >= 136 && totalcredithour <= 152) && Fgrade.Count() == 0)
                            {
                                if (FileUpload1.HasFile)
                                {
                                    TBL_GradeReport[] checkcumulative = sims.checkgradereport(radStudID.SelectedValue, "IV", "I");
                                    int credit = 0;
                                    for (int i = 0; i < cor.Count(); i++)
                                    {
                                        for (int j = 0; j < stugrade.Count(); j++)
                                        {
                                            if (cor[i].Course_code == stugrade[j].Course_Code)
                                            {
                                                
                                                if (stugrade[j].Grade == "A")
                                                {
                                                   credit = Convert.ToInt32(cor[i].Credit_hour * 4);
                                                }
                                                else if (stugrade[j].Grade == "A-")
                                                {
                                                     credit = Convert.ToInt32(cor[i].Credit_hour * 3.75);
                                                }
                                                else if (stugrade[j].Grade == "B+")
                                                {
                                                   credit = Convert.ToInt32(cor[i].Credit_hour * 3.5);
                                                }
                                                else if (stugrade[j].Grade == "B")
                                                {
                                                    credit = Convert.ToInt32(cor[i].Credit_hour * 3);
                                                }
                                                else if (stugrade[j].Grade == "B-")
                                                {
                                                    credit = Convert.ToInt32(cor[i].Credit_hour * 2.75);
                                                }
                                                else if (stugrade[j].Grade == "C+")
                                                {
                                                   credit = Convert.ToInt32(cor[i].Credit_hour * 2.5);
                                                }
                                                else if (stugrade[j].Grade == "C")
                                                {
                                                   credit = Convert.ToInt32 (cor[i].Credit_hour * 2);
                                                }
                                                else if (stugrade[j].Grade == "C-")
                                                {
                                                    credit = Convert.ToInt32(cor[i].Credit_hour * 1.75);
                                                }
                                                else if (stugrade[j].Grade == "D")
                                                {
                                                  credit = Convert.ToInt32(cor[i].Credit_hour * 1);
                                                }
                                                else
                                                {
                                                    credit = Convert.ToInt32 (cor[i].Credit_hour * 0);
                                                }
                                                totalcredit = totalcredit + Convert.ToInt32(cor[i].Credit_hour);
                                                totalpoint = totalpoint + credit;
                                                
                                            }
                                        }
                                    }
                                    totalcredit = Convert.ToInt32(totalcredit + checkcumulative[0].TotalCredit);

                                     totalpoint =Convert.ToSingle(totalpoint + checkcumulative[0].TotalPoint);

                                   Double Cgpa =Convert.ToSingle( (totalpoint + checkcumulative[0].TotalPoint) / (totalcredit + checkcumulative[0].TotalCredit));
                                   Double cgpa=Math.Round(Cgpa, 2)-0.02;
                                   cgpad.Text = "CGPA:" + " " + cgpa;
                                    String Str = FileUpload1.FileName;
                                    FileUpload1.PostedFile.SaveAs(Server.MapPath(".") + "//uploads//" + Str);
                                    String path = "~//uploads//" + Str.ToString();
                                  
                                    hu.Text = "YEJU UNIVERSITY";
                                    Image2.ImageUrl = "uploads/" + Str.ToString();
                                    Image1.ImageUrl = "../images/logo.jpg";
                                    Image3.ImageUrl = "../images/tel.PNG";
                                    tempo.Text = "TEMPORARY CERTIFICATE OF COMPLETION ";
                                    certify.Text = "This is to certfiy that" + " " + studidfourth[0].First_Name + " " + studidfourth[0].Midle_Name + " " + studidfourth[0].Last_Name; ;
                            
                                    cert.Text = "Has successfully fulfilled the requirements of";
                                    dept.Text = "Bachelor of Science degree in" + " " + raddept.Text;
                                    reg.Text = "University Registrar";
                                    dean.Text = " Dean," + " " + radcollege.Text;
                                }
                                else
                                {
                                    label.ForeColor = Color.Red;
                                    label.Text = "please select the student photo";

                                }
                            }
                            else
                            {
                                label.Text = "IDNo.:" + radStudID.Text + " " + " Doesn't fulfill All requirements to graduate (get a degree)from a program.";
                            }
                        }
                    }
                    else if (radcollege.SelectedValue == "YU_College-1" || radcollege.SelectedValue == "YU_College-2" || radcollege.SelectedValue == "YU_College-5" || radcollege.SelectedValue == "HU_College-6")
                    {
                        TBL_studentGrade[] stugrade = sims.viewgrade(radStudID.SelectedValue, "III", "II");
                        TBL_Course[] cor = sims.searchcoursebydys(raddept.SelectedValue, "III", "II");
                        if ((totalcredithour >= 102 && totalcredithour <= 114) && Fgrade.Count() == 0)
                        {

                            if (FileUpload1.HasFile)
                            {

                                TBL_GradeReport[] checkcumulative = sims.checkgradereport(radStudID.SelectedValue, "III", "I");
                                int credit = 0;
                                for (int i = 0; i < cor.Count(); i++)
                                {
                                    for (int j = 0; j < stugrade.Count(); j++)
                                    {
                                        if (cor[i].Course_code == stugrade[j].Course_Code)
                                        {

                                            if (stugrade[j].Grade == "A")
                                            {
                                                credit = Convert.ToInt32(co[i].Credit_hour * 4);
                                            }
                                            else if (stugrade[j].Grade == "A-")
                                            {
                                                credit = Convert.ToInt32(co[i].Credit_hour * 3.75);
                                            }
                                            else if (stugrade[j].Grade == "B+")
                                            {
                                                credit = Convert.ToInt32(co[i].Credit_hour * 3.5);
                                            }
                                            else if (stugrade[j].Grade == "B")
                                            {
                                                credit = Convert.ToInt32(co[i].Credit_hour * 3);
                                            }
                                            else if (stugrade[j].Grade == "B-")
                                            {
                                                credit = Convert.ToInt32(co[i].Credit_hour * 2.75);
                                            }
                                            else if (stugrade[j].Grade == "C+")
                                            {
                                                credit = Convert.ToInt32(co[i].Credit_hour * 2.5);
                                            }
                                            else if (stugrade[j].Grade == "C")
                                            {
                                                credit = Convert.ToInt32(co[i].Credit_hour * 2);
                                            }
                                            else if (stugrade[j].Grade == "C-")
                                            {
                                                credit = Convert.ToInt32(co[i].Credit_hour * 1.75);
                                            }
                                            else if (stugrade[j].Grade == "D")
                                            {
                                                credit = Convert.ToInt32(co[i].Credit_hour * 1);
                                            }
                                            else
                                            {
                                                credit = Convert.ToInt32(co[i].Credit_hour * 0);
                                            }
                                            totalcredit = totalcredit + Convert.ToInt32(co[i].Credit_hour);
                                            totalpoint = totalpoint + credit;

                                        }
                                    }
                                }
                                totalcredit = Convert.ToInt32(totalcredit + checkcumulative[0].TotalCredit);

                                totalpoint = Convert.ToSingle(totalpoint + checkcumulative[0].TotalPoint);

                                Double Cgpa = Convert.ToSingle((totalpoint + checkcumulative[0].TotalPoint) / (totalcredit + checkcumulative[0].TotalCredit));
                                Double cgpa = Math.Round(Cgpa, 2);
                                cgpad.Text = "CGPA:" + " " + cgpa;
                                String Str = FileUpload1.FileName;
                                FileUpload1.PostedFile.SaveAs(Server.MapPath(".") + "//uploads//" + Str);
                                String path = "~//uploads//" + Str.ToString();



                                hu.Text = "YEJU UNIVERSITY";
                                Image2.ImageUrl = "uploads/" + Str.ToString();
                                Image1.ImageUrl = "../images/logo.jpg";
                                Image3.ImageUrl = "../images/tel.PNG";
                                tempo.Text = "TEMPORARY CERTIFICATE OF COMPLETION ";
                                certify.Text = "This is to certfiy that" + " " + studidthird[0].First_Name + " " + studidthird[0].Midle_Name + " " + studidthird[0].Last_Name; ;

                                cert.Text = "Has successfully fulfilled the requirements of";
                                dept.Text = "Bachelor of Science degree in" + " " + raddept.Text;
                                reg.Text = "University Registrar";
                                dean.Text = " Dean," + " " + radcollege.Text;
                            }
                            else
                            {
                                label.ForeColor = Color.Red;
                                label.Text = "please select the student photo";

                            }
                        }
                        else
                        {
                            label.Text = "IDNo.:" + radStudID.Text + " " + " Doesn't fulfill All requirements to graduate (get a degree)from a program.";
                        }
                    }
                    else if (radcollege.SelectedValue == "YU_College-4" || radcollege.SelectedValue == "HU_College-8")
                    {
                        TBL_studentGrade[] stugrade = sims.viewgrade(radStudID.SelectedValue, "V", "II");
                        TBL_Course[] cor = sims.searchcoursebydys(raddept.SelectedValue, "V", "II");

                        if ((totalcredithour >= 170 && totalcredithour <= 190) && Fgrade.Count() == 0)
                        {

                            if (FileUpload1.HasFile)
                            {

                                TBL_GradeReport[] checkcumulative = simscheckgradereport(radStudID.SelectedValue, "V", "I");
                                int credit = 0;
                                for (int i = 0; i < cor.Count(); i++)
                                {
                                    for (int j = 0; j < stugrade.Count(); j++)
                                    {
                                        if (cor[i].Course_code == stugrade[j].Course_Code)
                                        {

                                            if (stugrade[j].Grade == "A")
                                            {
                                                credit = Convert.ToInt32(co[i].Credit_hour * 4);
                                            }
                                            else if (stugrade[j].Grade == "A-")
                                            {
                                                credit = Convert.ToInt32(co[i].Credit_hour * 3.75);
                                            }
                                            else if (stugrade[j].Grade == "B+")
                                            {
                                                credit = Convert.ToInt32(co[i].Credit_hour * 3.5);
                                            }
                                            else if (stugrade[j].Grade == "B")
                                            {
                                                credit = Convert.ToInt32(co[i].Credit_hour * 3);
                                            }
                                            else if (stugrade[j].Grade == "B-")
                                            {
                                                credit = Convert.ToInt32(co[i].Credit_hour * 2.75);
                                            }
                                            else if (stugrade[j].Grade == "C+")
                                            {
                                                credit = Convert.ToInt32(co[i].Credit_hour * 2.5);
                                            }
                                            else if (stugrade[j].Grade == "C")
                                            {
                                                credit = Convert.ToInt32(co[i].Credit_hour * 2);
                                            }
                                            else if (stugrade[j].Grade == "C-")
                                            {
                                                credit = Convert.ToInt32(co[i].Credit_hour * 1.75);
                                            }
                                            else if (stugrade[j].Grade == "D")
                                            {
                                                credit = Convert.ToInt32(co[i].Credit_hour * 1);
                                            }
                                            else
                                            {
                                                credit = Convert.ToInt32(co[i].Credit_hour * 0);
                                            }
                                            totalcredit = totalcredit + Convert.ToInt32(co[i].Credit_hour);
                                            totalpoint = totalpoint + credit;

                                        }
                                    }
                                }
                                totalcredit = Convert.ToInt32(totalcredit + checkcumulative[0].TotalCredit);

                                totalpoint = Convert.ToSingle(totalpoint + checkcumulative[0].TotalPoint);

                                Double Cgpa = Convert.ToSingle((totalpoint + checkcumulative[0].TotalPoint) / (totalcredit + checkcumulative[0].TotalCredit));
                                Double cgpa = Math.Round(Cgpa, 2);
                                cgpad.Text = "CGPA:" + " " + cgpa;
                                String Str = FileUpload1.FileName;
                                FileUpload1.PostedFile.SaveAs(Server.MapPath(".") + "//uploads//" + Str);
                                String path = "~//uploads//" + Str.ToString();



                                hu.Text = "YEJU UNIVERSITY";
                                Image2.ImageUrl = "uploads/" + Str.ToString();
                                Image1.ImageUrl = "../images/logo.jpg";
                                Image3.ImageUrl = "../images/tel.PNG";
                                tempo.Text = "TEMPORARY CERTIFICATE OF COMPLETION ";
                                certify.Text = "This is to certfiy that" + " " + studidfivth[0].First_Name + " " + studidfivth[0].Midle_Name + " " + studidfivth[0].Last_Name; ;

                                cert.Text = "Has successfully fulfilled the requirements of";
                                dept.Text = "Bachelor of Science degree in" + " " + raddept.Text;
                                reg.Text = "University Registrar";
                                dean.Text = " Dean," + " " + radcollege.Text;
                            }
                            else
                            {
                                label.ForeColor = Color.Red;
                                label.Text = "please select the student photo";

                            }
                        }
                        else
                        {
                            label.Text = "IDNo.:" + radStudID.Text + " " + " Doesn't fulfill All requirements to graduate (get a degree)from a program.";
                        }
                    }
                    else if (radcollege.SelectedValue == "YU_College-7")
                    {
                        TBL_studentGrade[] stugrade = sims.viewgrade(radStudID.SelectedValue, "VI", "II");
                        TBL_Course[] cor = sims.searchcoursebydys(raddept.SelectedValue, "VI", "II");
                        if ((totalcredithour >= 204 && totalcredithour <= 228) && Fgrade.Count() == 0)
                        {

                            if (FileUpload1.HasFile)
                            {
                                TBL_GradeReport[] checkcumulative = sims.checkgradereport(radStudID.SelectedValue, "VI", "I");
                                int credit = 0;
                                for (int i = 0; i < cor.Count(); i++)
                                {
                                    for (int j = 0; j < stugrade.Count(); j++)
                                    {
                                        if (cor[i].Course_code == stugrade[j].Course_Code)
                                        {

                                            if (stugrade[j].Grade == "A")
                                            {
                                                credit = Convert.ToInt32(co[i].Credit_hour * 4);
                                            }
                                            else if (stugrade[j].Grade == "A-")
                                            {
                                                credit = Convert.ToInt32(co[i].Credit_hour * 3.75);
                                            }
                                            else if (stugrade[j].Grade == "B+")
                                            {
                                                credit = Convert.ToInt32(co[i].Credit_hour * 3.5);
                                            }
                                            else if (stugrade[j].Grade == "B")
                                            {
                                                credit = Convert.ToInt32(co[i].Credit_hour * 3);
                                            }
                                            else if (stugrade[j].Grade == "B-")
                                            {
                                                credit = Convert.ToInt32(co[i].Credit_hour * 2.75);
                                            }
                                            else if (stugrade[j].Grade == "C+")
                                            {
                                                credit = Convert.ToInt32(co[i].Credit_hour * 2.5);
                                            }
                                            else if (stugrade[j].Grade == "C")
                                            {
                                                credit = Convert.ToInt32(co[i].Credit_hour * 2);
                                            }
                                            else if (stugrade[j].Grade == "C-")
                                            {
                                                credit = Convert.ToInt32(co[i].Credit_hour * 1.75);
                                            }
                                            else if (stugrade[j].Grade == "D")
                                            {
                                                credit = Convert.ToInt32(co[i].Credit_hour * 1);
                                            }
                                            else
                                            {
                                                credit = Convert.ToInt32(co[i].Credit_hour * 0);
                                            }
                                            totalcredit = totalcredit + Convert.ToInt32(co[i].Credit_hour);
                                            totalpoint = totalpoint + credit;

                                        }
                                    }
                                }
                                totalcredit = Convert.ToInt32(totalcredit + checkcumulative[0].TotalCredit);

                                totalpoint = Convert.ToSingle(totalpoint + checkcumulative[0].TotalPoint);

                                Double Cgpa = Convert.ToSingle((totalpoint + checkcumulative[0].TotalPoint) / (totalcredit + checkcumulative[0].TotalCredit));
                                Double cgpa = Math.Round(Cgpa, 2);
                                cgpad.Text = "CGPA:" + " " + cgpa;
                                String Str = FileUpload1.FileName;
                                FileUpload1.PostedFile.SaveAs(Server.MapPath(".") + "//uploads//" + Str);
                                String path = "~//uploads//" + Str.ToString();




                                hu.Text = "YEJU UNIVERSITY";
                                Image2.ImageUrl = "uploads/" + Str.ToString();
                                Image1.ImageUrl = "../images/logo.jpg";
                                Image3.ImageUrl = "../images/tel.PNG";
                                tempo.Text = "TEMPORARY CERTIFICATE OF COMPLETION ";
                                certify.Text = "This is to certfiy that" + " " + studidveternary[0].First_Name + " " + studidveternary[0].Midle_Name + " " + studidveternary[0].Last_Name; ;

                                cert.Text = "Has successfully fulfilled the requirements of";
                                dept.Text = "Bachelor of Science degree in" + " " + raddept.Text;
                                reg.Text = "University Registrar";
                                dean.Text = " Dean," + " " + radcollege.Text;
                            }
                            else
                            {
                                label.ForeColor = Color.Red;
                                label.Text = "please select the student photo";

                            }
                        }
                        else
                        {
                            label.Text = "IDNo.:" + radStudID.Text + " " + " Doesn't fulfill All requirements to graduate (get a degree)from a program.";
                        }
                    }


                }
                else
                {
                    label.Text = "There is no grade in some  course so There is no Certficiate";
                }
            }
        }
    }
}
