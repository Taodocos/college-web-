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
    public partial class slip_g : System.Web.UI.Page
    {
        SIMS slip = new SIMS();
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

            }
        }
        private void SearchCollege()
        {
            radcollege.DataTextField = "College_Name";
            radcollege.DataValueField = "College_Code";
            radcollege.DataSource = slip.SearchallCollegeRad();
            radcollege.DataBind();
        }
        private void searchdepartment()
        {
            raddept.DataTextField = "Department_name";
            raddept.DataValueField = "Department_Code";
            raddept.DataSource = slip.searchalldepartmentbycollege(radcollege.SelectedValue);
            raddept.DataBind();
        }
        private void searchstudentID()
        {
            radStudID.DataTextField = "Stud_ID";
            radStudID.DataValueField = "Stud_ID";
            radStudID.DataSource = slip.searchstudentidbydept(raddept.SelectedValue);
            radStudID.DataBind();
        }

        protected void radcollege_SelectedIndexChanged(object sender, EventArgs e)
        {
            TBL_department[] dept = slip.searchalldepartmentbycollege(radcollege.SelectedValue);
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
            //  RadGrid1.Visible = false;
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
            TBL_FreshStudent[] studid = slip.searchstudentidbydept(raddept.SelectedValue);
            label.Text = "";
            if (studid.Count() > 0)
            {
                // radStudID.Text = studid[0].Stud_ID;
                searchstudentID();

            }
            else
            {
                label.Text = "no student in this department";
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

        protected void btngenerate_Click(object sender, EventArgs e)
        {
             int k = 0;
           
            TBL_FreshStudent[] st = slip.searchstudentbyid(radStudID.SelectedValue);
            int totalcredit = 0;
            TBL_Course[] co = slip.searchcoursebydys(raddept.SelectedValue, radyear.SelectedValue, radsemister.SelectedValue);
            TBL_studentGrade[] stugrade = slip.searchstudgrade(raddept.SelectedValue, radStudID.SelectedValue, radyear.SelectedValue, radsemister.SelectedValue);
            TBL_RegisterStudent[] checkreg = slip.searchstudforgradereport(radStudID.SelectedValue, radyear.SelectedValue, radsemister.SelectedValue);
           /* valids.addComponent(radcollege, ComponentValidator.NO_FORMAT, true);
            valids.addComponent(raddept, ComponentValidator.NO_FORMAT, true);
            valids.addComponent(radStudID, ComponentValidator.NO_FORMAT, true);
            if (valids.isAllComponenetValid())
            {*/
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
                if (radyear.SelectedValue == "I" && radsemister.SelectedValue == "I")
                {
                    if (st.Count() > 0 && co.Count() > 0)
                    {
                        Image2.ImageUrl = "../images/SLIP.PNG";
                        string strDate = DateTime.Now.ToString("MM/dd/yyyy");
                        date.Text = "Date:" + " " + strDate + " " + "G.C";
                        name.Text = "Name:" + " " + st[0].first_name + " " + st[0].middle_name + "      " + "ID.No.:" + "  " + st[0].Stud_ID + "   " +
                        "Dept:" + " " + raddept.Text;


                        ageandsex.Text = "Age:" + "   " + st[0].age + "   " + " Sex:" + " " + st[0].sex + "   "+"Nationality:" + " " + st[0].natinality + "Class Year:" + " " + radyear.SelectedValue + "  " + "Semister:" + " " + radsemister.Text + " " +
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
                            TBL_PrerequestCourse[] pre = slip.checkprerequestforgrade(raddept.SelectedValue, co[i].Course_code);
                            if (pre.Count() > 0)
                            {
                                for (int j = 0; j < pre.Count(); j++)
                                {
                                    TBL_studentGrade[] gr = slip.checkgradeprerequestforslip(radStudID.SelectedValue, raddept.SelectedValue, pre[j].Prerequest_Course);
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
                                            totalcredit = totalcredit + Convert.ToInt32(co[i].Credit_hour);
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
                                DataRow dr = dt.NewRow();
                                dr["S/N"] = k;
                                dr["Course Title"] = co[i].Course_name;
                                dr["Course Code"] = co[i].Course_code;
                                dr["Credit Hour"] = Convert.ToInt32(co[i].Credit_hour);
                                dr["Instructor"] = "staff";
                                totalcredit = totalcredit + Convert.ToInt32(co[i].Credit_hour);
                                dt.Rows.Add(dr);
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
                        Image2.Visible = false;
                        date.Visible = false;
                      
                        ageandsex.Visible = false;
                        region.Visible = false;
                        RadGrid1.Visible = false;
                        anames.Visible = false;
                        regi.Visible = false;
                        sign.Visible = false;
                        note.Visible = false;
                        no.Visible = false;
                    }
                }
                else if (radyear.SelectedValue == "I" && radsemister.SelectedValue == "II")
                {
                    if (checkreg.Count() > 0 && co.Count() > 0)
                    {
                        Image2.ImageUrl = "../images/SLIP.PNG";
                        string strDate = DateTime.Now.ToString("MM/dd/yyyy");
                        date.Text = "Date:" + " " + strDate + " " + "G.C";
                        name.Text = "Name:" + " " + checkreg[0].First_Name + " " + checkreg[0].Midle_Name + "      " + "ID.No.:" + "  " + checkreg[0].StudID + "   " +
                        "Dept:" + " " + raddept.Text;


                        ageandsex.Text = "Age:" + "   " + checkreg[0].Age + "   " + " Sex:" + " " + checkreg[0].Sex + "   "+"Nationality:" + " " + checkreg[0].Nationality+"        "+ "Class Year:" + " " + radyear.SelectedValue + "  " + "Semister:" + " " + radsemister.Text + " " +
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
                            TBL_PrerequestCourse[] pre = slip.checkprerequestforgrade(raddept.SelectedValue, co[i].Course_code);
                            if (pre.Count() > 0)
                            {
                                for (int j = 0; j < pre.Count(); j++)
                                {
                                   
                                    TBL_studentGrade[] gr = slip.checkgradeprerequestforslip(radStudID.SelectedValue, raddept.SelectedValue, pre[j].Prerequest_Course);
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
                                            totalcredit = totalcredit + Convert.ToInt32(co[i].Credit_hour);
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
                                DataRow dr = dt.NewRow();
                                dr["S/N"] = k;
                                dr["Course Title"] = co[i].Course_name;
                                dr["Course Code"] = co[i].Course_code;
                                dr["Credit Hour"] = Convert.ToInt32(co[i].Credit_hour);
                                dr["Instructor"] = "staff";
                                totalcredit = totalcredit + Convert.ToInt32(co[i].Credit_hour);
                                dt.Rows.Add(dr);
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
                        Image2.Visible = false;
                        date.Visible = false;
                      
                        ageandsex.Visible = false;
                        region.Visible = false;
                        RadGrid1.Visible = false;
                        anames.Visible = false;
                        regi.Visible = false;
                        sign.Visible = false;
                        note.Visible = false;
                        no.Visible = false;
                    }
                }

                else if (radyear.SelectedValue == "II" && radsemister.SelectedValue == "I")
                {
                    if (checkreg.Count() > 0 && co.Count() > 0)
                    {
                        Image2.ImageUrl = "../images/SLIP.PNG";
                        string strDate = DateTime.Now.ToString("MM/dd/yyyy");
                        date.Text = "Date:" + " " + strDate + " " + "G.C";
                        name.Text = "Name:" + " " + checkreg[0].First_Name + " " + checkreg[0].Midle_Name + "      " + "ID.No.:" + "  " + checkreg[0].StudID + "   " +
                        "Dept:" + " " + raddept.Text;


                        ageandsex.Text = "Age:" + "   " + checkreg[0].Age + "   " + " Sex:" + " " + checkreg[0].Sex +"   "+ "Nationality:" + " " + checkreg[0].Nationality + "        " + "Class Year:" + " " + radyear.SelectedValue + "  " + "Semister:" + " " + radsemister.Text + " " +
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
                            TBL_PrerequestCourse[] pre = slip.checkprerequestforgrade(raddept.SelectedValue, co[i].Course_code);
                            if (pre.Count() > 0)
                            {
                                for (int j = 0; j < pre.Count(); j++)
                                {
                                    TBL_studentGrade[] gr = slip.checkgradeprerequestforslip(radStudID.SelectedValue, raddept.SelectedValue, pre[j].Prerequest_Course);
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
                                            totalcredit = totalcredit + Convert.ToInt32(co[i].Credit_hour);
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
                                DataRow dr = dt.NewRow();
                                dr["S/N"] = k ;
                                dr["Course Title"] = co[i].Course_name;
                                dr["Course Code"] = co[i].Course_code;
                                dr["Credit Hour"] = Convert.ToInt32(co[i].Credit_hour);
                                dr["Instructor"] = "staff";
                                totalcredit = totalcredit + Convert.ToInt32(co[i].Credit_hour);
                                dt.Rows.Add(dr);
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
                        Image2.Visible = false;
                        date.Visible = false;
                       
                        ageandsex.Visible = false;
                        region.Visible = false;
                        RadGrid1.Visible = false;
                        anames.Visible = false;
                        regi.Visible = false;
                        sign.Visible = false;
                        note.Visible = false;
                        no.Visible = false;
                    }
                }

                else if (radyear.SelectedValue == "II" && radsemister.SelectedValue == "II")
                {
                    if (checkreg.Count() > 0 && co.Count() > 0)
                    {
                        Image2.ImageUrl = "../images/SLIP.PNG";
                        string strDate = DateTime.Now.ToString("MM/dd/yyyy");
                        date.Text = "Date:" + " " + strDate + " " + "G.C";
                        name.Text = "Name:" + " " + checkreg[0].First_Name + " " + checkreg[0].Midle_Name + "      " + "ID.No.:" + "  " + checkreg[0].StudID + "   " +
                        "Dept:" + " " + raddept.Text;


                        ageandsex.Text = "Age:" + "   " + checkreg[0].Age + "   " + " Sex:" + " " + checkreg[0].Sex +"   "+ "Nationality:" + " " + checkreg[0].Nationality + "        " + "Class Year:" + " " + radyear.SelectedValue + "  " + "Semister:" + " " + radsemister.Text + " " +
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
                            TBL_PrerequestCourse[] pre = slip.checkprerequestforgrade(raddept.SelectedValue, co[i].Course_code);
                            if (pre.Count() > 0)
                            {
                                for (int j = 0; j < pre.Count(); j++)
                                {
                                    TBL_studentGrade[] gr = slip.checkgradeprerequestforslip(radStudID.SelectedValue, raddept.SelectedValue, pre[j].Prerequest_Course);
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
                                            totalcredit = totalcredit + Convert.ToInt32(co[i].Credit_hour);
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
                                DataRow dr = dt.NewRow();
                                dr["S/N"] = k;
                                dr["Course Title"] = co[i].Course_name;
                                dr["Course Code"] = co[i].Course_code;
                                dr["Credit Hour"] = Convert.ToInt32(co[i].Credit_hour);
                                dr["Instructor"] = "staff";
                                totalcredit = totalcredit + Convert.ToInt32(co[i].Credit_hour);
                                dt.Rows.Add(dr);
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
                        Image2.Visible = false;
                        date.Visible = false;
                        
                        ageandsex.Visible = false;
                        region.Visible = false;
                        RadGrid1.Visible = false;
                        anames.Visible = false;
                        regi.Visible = false;
                        sign.Visible = false;
                        note.Visible = false;
                        no.Visible = false;
                    }
                }

                else if (radyear.SelectedValue == "III" && radsemister.SelectedValue == "I")
                {
                    if (checkreg.Count() > 0 && co.Count() > 0)
                    {
                        Image2.ImageUrl = "../images/SLIP.PNG";
                        string strDate = DateTime.Now.ToString("MM/dd/yyyy");
                        date.Text = "Date:" + " " + strDate + " " + "G.C";
                        name.Text = "Name:" + " " + checkreg[0].First_Name + " " + checkreg[0].Midle_Name + "      " + "ID.No.:" + "  " + checkreg[0].StudID + "   " +
                        "Dept:" + " " + raddept.Text;


                        ageandsex.Text = "Age:" + "   " + checkreg[0].Age + "   " + " Sex:" + " " + checkreg[0].Sex + "   "+"Nationality:" + " " + checkreg[0].Nationality + "        " + "Class Year:" + " " + radyear.SelectedValue + "  " + "Semister:" + " " + radsemister.Text + " " +
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

                            TBL_PrerequestCourse[] pre = slip.checkprerequestforgrade(raddept.SelectedValue, co[i].Course_code);
                            if (pre.Count() > 0)
                            {
                                for (int j = 0; j < pre.Count(); j++)
                                {
                                  
                                    TBL_studentGrade[] gr = slip.checkgradeprerequestforslip(radStudID.SelectedValue, raddept.SelectedValue, pre[j].Prerequest_Course);
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
                                            totalcredit = totalcredit + Convert.ToInt32(co[i].Credit_hour);
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
                                
                                DataRow dr = dt.NewRow();
                                dr["S/N"] = k;
                                dr["Course Title"] = co[i].Course_name;
                                dr["Course Code"] = co[i].Course_code;
                                dr["Credit Hour"] = Convert.ToInt32(co[i].Credit_hour);
                                dr["Instructor"] = "staff";
                                totalcredit = totalcredit + Convert.ToInt32(co[i].Credit_hour);
                                dt.Rows.Add(dr);
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
                        Image2.Visible = false;
                        date.Visible = false;
                        
                        ageandsex.Visible = false;
                        region.Visible = false;
                        RadGrid1.Visible = false;
                        anames.Visible = false;
                        regi.Visible = false;
                        sign.Visible = false;
                        note.Visible = false;
                        no.Visible = false;
                    }
                }
                else if (radyear.SelectedValue == "III" && radsemister.SelectedValue == "II")
                {
                    if (checkreg.Count() > 0 && co.Count() > 0)
                    {
                        Image2.ImageUrl = "../images/SLIP.PNG";
                        string strDate = DateTime.Now.ToString("MM/dd/yyyy");
                        date.Text = "Date:" + " " + strDate + " " + "G.C";
                        name.Text = "Name:" + " " + checkreg[0].First_Name + " " + checkreg[0].Midle_Name + "      " + "ID.No.:" + "  " + checkreg[0].StudID + "   " +
                        "Dept:" + " " + raddept.Text;


                        ageandsex.Text = "Age:" + "   " + checkreg[0].Age + "   " + " Sex:" + " " + checkreg[0].Sex + "Nationality:" + "   " + checkreg[0].Nationality + "        " + "Class Year:" + " " + radyear.SelectedValue + "  " + "Semister:" + " " + radsemister.Text + " " +
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
                            TBL_PrerequestCourse[] pre = slip.checkprerequestforgrade(raddept.SelectedValue, co[i].Course_code);
                            if (pre.Count() > 0)
                            {
                                for (int j = 0; j < pre.Count(); j++)
                                {
                                   
                                    TBL_studentGrade[] gr = slip.checkgradeprerequestforslip(radStudID.SelectedValue, raddept.SelectedValue, pre[j].Prerequest_Course);
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
                                            totalcredit = totalcredit + Convert.ToInt32(co[i].Credit_hour);
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
                                DataRow dr = dt.NewRow();
                                dr["S/N"] = k;
                                dr["Course Title"] = co[i].Course_name;
                                dr["Course Code"] = co[i].Course_code;
                                dr["Credit Hour"] = Convert.ToInt32(co[i].Credit_hour);
                                dr["Instructor"] = "staff";
                                totalcredit = totalcredit + Convert.ToInt32(co[i].Credit_hour);
                                dt.Rows.Add(dr);
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
                        Image2.ImageUrl = "../images/SLIP.PNG";
                        string strDate = DateTime.Now.ToString("MM/dd/yyyy");
                        date.Text = "Date:" + " " + strDate + " " + "G.C";
                        name.Text = "Name:" + " " + checkreg[0].First_Name + " " + checkreg[0].Midle_Name + "      " + "ID.No.:" + "  " + checkreg[0].StudID + "   " +
                        "Dept:" + " " + raddept.Text;


                        ageandsex.Text = "Age:" + "   " + checkreg[0].Age + "   " + " Sex:" + " " + checkreg[0].Sex + "    "+"Nationality:" + " " + checkreg[0].Nationality + "        " + "Class Year:" + " " + radyear.SelectedValue + "  " + "Semister:" + " " + radsemister.Text + " " +
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
                            TBL_PrerequestCourse[] pre = slip.checkprerequestforgrade(raddept.SelectedValue, co[i].Course_code);
                            if (pre.Count() > 0)
                            {
                                for (int j = 0; j < pre.Count(); j++)
                                {
                                    TBL_studentGrade[] gr = slip.checkgradeprerequestforslip(radStudID.SelectedValue, raddept.SelectedValue, pre[j].Prerequest_Course);
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
                                            totalcredit = totalcredit + Convert.ToInt32(co[i].Credit_hour);
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
                                DataRow dr = dt.NewRow();
                                dr["S/N"] = k;
                                dr["Course Title"] = co[i].Course_name;
                                dr["Course Code"] = co[i].Course_code;
                                dr["Credit Hour"] = Convert.ToInt32(co[i].Credit_hour);
                                dr["Instructor"] = "staff";
                                totalcredit = totalcredit + Convert.ToInt32(co[i].Credit_hour);
                                dt.Rows.Add(dr);
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
                        Image2.Visible = false;
                        date.Visible = false;
                      
                        ageandsex.Visible = false;
                        region.Visible = false;
                        RadGrid1.Visible = false;
                        anames.Visible = false;
                        regi.Visible = false;
                        sign.Visible = false;
                        note.Visible = false;
                        no.Visible = false;
                    }
                }
                else if (radyear.SelectedValue == "IV" && radsemister.SelectedValue == "II")
                {
                    if (checkreg.Count() > 0 && co.Count() > 0)
                    {
                        Image2.ImageUrl = "../images/SLIP.PNG";
                        string strDate = DateTime.Now.ToString("MM/dd/yyyy");
                        date.Text = "Date:" + " " + strDate + " " + "G.C";
                        name.Text = "Name:" + " " + checkreg[0].First_Name + " " + checkreg[0].Midle_Name + "      " + "ID.No.:" + "  " + checkreg[0].StudID + "   " +
                        "Dept:" + " " + raddept.Text;


                        ageandsex.Text = "Age:" + "   " + checkreg[0].Age + "   " + " Sex:" + " " + checkreg[0].Sex +"   "+ "Nationality:" + " " + checkreg[0].Nationality + "        " + "Class Year:" + " " + radyear.SelectedValue + "  " + "Semister:" + " " + radsemister.Text + " " +
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
                            TBL_PrerequestCourse[] pre = slip.checkprerequestforgrade(raddept.SelectedValue, co[i].Course_code);
                            if (pre.Count() > 0)
                            {
                                for (int j = 0; j < pre.Count(); j++)
                                {
                                    TBL_studentGrade[] gr = slip.checkgradeprerequestforslip(radStudID.SelectedValue, raddept.SelectedValue, pre[j].Prerequest_Course);
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
                                            totalcredit = totalcredit + Convert.ToInt32(co[i].Credit_hour);
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
                                DataRow dr = dt.NewRow();
                                dr["S/N"] = i;
                                dr["Course Title"] = co[i].Course_name;
                                dr["Course Code"] = co[i].Course_code;
                                dr["Credit Hour"] = Convert.ToInt32(co[i].Credit_hour);
                                dr["Instructor"] = "staff";
                                totalcredit = totalcredit + Convert.ToInt32(co[i].Credit_hour);
                                dt.Rows.Add(dr);
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
                        Image2.Visible = false;
                        date.Visible = false;
                        
                        ageandsex.Visible = false;
                        region.Visible = false;
                        RadGrid1.Visible = false;
                        anames.Visible = false;
                        regi.Visible = false;
                        sign.Visible = false;
                        note.Visible = false;
                        no.Visible = false;
                    }
                }
                else if (radyear.SelectedValue == "V" && radsemister.SelectedValue == "I")
                {
                    if (checkreg.Count() > 0 && co.Count() > 0)
                    {
                        Image2.ImageUrl = "../images/SLIP.PNG";
                        string strDate = DateTime.Now.ToString("MM/dd/yyyy");
                        date.Text = "Date:" + " " + strDate + " " + "G.C";
                        name.Text = "Name:" + " " + checkreg[0].First_Name + " " + checkreg[0].Midle_Name + "      " + "ID.No.:" + "  " + checkreg[0].StudID + "   " +
                        "Dept:" + " " + raddept.Text;


                        ageandsex.Text = "Age:" + "   " + checkreg[0].Age + "   " + " Sex:" + " " + checkreg[0].Sex +"   "+ "Nationality:" + " " + checkreg[0].Nationality + "        " + "Class Year:" + " " + radyear.SelectedValue + "  " + "Semister:" + " " + radsemister.Text + " " +
                           checkreg[0].Acadmic_Year + " " + "E.C" + "(A.Y)";

                        region.Text = "Region:" + "  " + checkreg[0].Region + "  " + "Zone:" + "  " + checkreg[0].Zone;
                        dt.Columns.Add("S/N");
                        dt.Columns.Add("Course Title");
                        dt.Columns.Add("Course Code");
                        dt.Columns.Add("Credit Hour");
                        dt.Columns.Add("Instructor");

                        for (int i = 0; i < co.Count(); i++)
                        {

                            TBL_PrerequestCourse[] pre = slip.checkprerequestforgrade(raddept.SelectedValue, co[i].Course_code);
                            if (pre.Count() > 0)
                            {
                                for (int j = 0; j < pre.Count(); j++)
                                {
                                    k++;
                                    TBL_studentGrade[] gr = slip.checkgradeprerequestforslip(radStudID.SelectedValue, raddept.SelectedValue, pre[j].Prerequest_Course);
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
                                            totalcredit = totalcredit + Convert.ToInt32(co[i].Credit_hour);
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
                                DataRow dr = dt.NewRow();
                                dr["S/N"] = k;
                                dr["Course Title"] = co[i].Course_name;
                                dr["Course Code"] = co[i].Course_code;
                                dr["Credit Hour"] = Convert.ToInt32(co[i].Credit_hour);
                                dr["Instructor"] = "staff";
                                totalcredit = totalcredit + Convert.ToInt32(co[i].Credit_hour);
                                dt.Rows.Add(dr);
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
                        Image2.Visible = false;
                        date.Visible = false;
                       
                        ageandsex.Visible = false;
                        region.Visible = false;
                        RadGrid1.Visible = false;
                        anames.Visible = false;
                        regi.Visible = false;
                        sign.Visible = false;
                        note.Visible = false;
                        no.Visible = false;
                    }
                }
                else if (radyear.SelectedValue == "V" && radsemister.SelectedValue == "II")
                {
                    if (checkreg.Count() > 0 && co.Count() > 0)
                    {
                        Image2.ImageUrl = "../images/SLIP.PNG";
                        string strDate = DateTime.Now.ToString("MM/dd/yyyy");
                        date.Text = "Date:" + " " + strDate + " " + "G.C";
                        name.Text = "Name:" + " " + checkreg[0].First_Name + " " + checkreg[0].Midle_Name + "      " + "ID.No.:" + "  " + checkreg[0].StudID + "   " +
                        "Dept:" + " " + raddept.Text;


                        ageandsex.Text = "Age:" + "   " + checkreg[0].Age + "   " + " Sex:" + "   " + checkreg[0].Sex +" "+ "Nationality:" + " " + checkreg[0].Nationality + "        " + "Class Year:" + " " + radyear.SelectedValue + "  " + "Semister:" + " " + radsemister.Text + " " +
                           checkreg[0].Acadmic_Year + " " + "E.C" + "(A.Y)";

                        region.Text = "Region:" + "  " + checkreg[0].Region + "  " + "Zone:" + "  " + checkreg[0].Zone;
                        dt.Columns.Add("S/N");
                        dt.Columns.Add("Course Title");
                        dt.Columns.Add("Course Code");
                        dt.Columns.Add("Credit Hour");
                        dt.Columns.Add("Instructor");

                        for (int i = 0; i < co.Count(); i++)
                        {

                            TBL_PrerequestCourse[] pre = slip.checkprerequestforgrade(raddept.SelectedValue, co[i].Course_code);
                            if (pre.Count() > 0)
                            {
                                for (int j = 0; j < pre.Count(); j++)
                                {
                                    k++;
                                    TBL_studentGrade[] gr = slip.checkgradeprerequestforslip(radStudID.SelectedValue, raddept.SelectedValue, pre[j].Prerequest_Course);
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
                                            totalcredit = totalcredit + Convert.ToInt32(co[i].Credit_hour);
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
                                DataRow dr = dt.NewRow();
                                dr["S/N"] = k;
                                dr["Course Title"] = co[i].Course_name;
                                dr["Course Code"] = co[i].Course_code;
                                dr["Credit Hour"] = Convert.ToInt32(co[i].Credit_hour);
                                dr["Instructor"] = "staff";
                                totalcredit = totalcredit + Convert.ToInt32(co[i].Credit_hour);
                                dt.Rows.Add(dr);
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
                        Image2.Visible = false;
                        date.Visible = false;
                       
                        ageandsex.Visible = false;
                        region.Visible = false;
                        RadGrid1.Visible = false;
                        anames.Visible = false;
                        regi.Visible = false;
                        sign.Visible = false;
                        note.Visible = false;
                        no.Visible = false;
                    }
                }
                else if (radyear.SelectedValue == "VI" && radsemister.SelectedValue == "I")
                {
                    if (checkreg.Count() > 0 && co.Count() > 0)
                    {
                        Image2.ImageUrl = "../images/SLIP.PNG";
                        string strDate = DateTime.Now.ToString("MM/dd/yyyy");
                        date.Text = "Date:" + " " + strDate + " " + "G.C";
                        name.Text = "Name:" + " " + checkreg[0].First_Name + " " + checkreg[0].Midle_Name + "      " + "ID.No.:" + "  " + checkreg[0].StudID + "   " +
                        "Dept:" + " " + raddept.Text;


                        ageandsex.Text = "Age:" + "   " + checkreg[0].Age + "   " + " Sex:" + " " + checkreg[0].Sex + "  "+"Nationality:" + " " + checkreg[0].Nationality + "        " + "Class Year:" + " " + radyear.SelectedValue + "  " + "Semister:" + " " + radsemister.Text + " " +
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
                            TBL_PrerequestCourse[] pre = slip.checkprerequestforgrade(raddept.SelectedValue, co[i].Course_code);
                            if (pre.Count() > 0)
                            {
                                for (int j = 0; j < pre.Count(); j++)
                                {
                                    TBL_studentGrade[] gr = slip.checkgradeprerequestforslip(radStudID.SelectedValue, raddept.SelectedValue, pre[j].Prerequest_Course);
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
                                            totalcredit = totalcredit + Convert.ToInt32(co[i].Credit_hour);
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
                                DataRow dr = dt.NewRow();
                                dr["S/N"] = k;
                                dr["Course Title"] = co[i].Course_name;
                                dr["Course Code"] = co[i].Course_code;
                                dr["Credit Hour"] = Convert.ToInt32(co[i].Credit_hour);
                                dr["Instructor"] = "staff";
                                totalcredit = totalcredit + Convert.ToInt32(co[i].Credit_hour);
                                dt.Rows.Add(dr);
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
                        Image2.Visible = false;
                        date.Visible = false;
                       
                        ageandsex.Visible = false;
                        region.Visible = false;
                        RadGrid1.Visible = false;
                        anames.Visible = false;
                        regi.Visible = false;
                        sign.Visible = false;
                        note.Visible = false;
                        no.Visible = false;
                    }
                }
                else if (radyear.SelectedValue == "VI" && radsemister.SelectedValue == "II")
                {
                    if (checkreg.Count() > 0 && co.Count() > 0)
                    {
                        Image2.ImageUrl = "../images/SLIP.PNG";
                        string strDate = DateTime.Now.ToString("MM/dd/yyyy");
                        date.Text = "Date:" + " " + strDate + " " + "G.C";
                        name.Text = "Name:" + " " + checkreg[0].First_Name + " " + checkreg[0].Midle_Name + "      " + "ID.No.:" + "  " + checkreg[0].StudID + "   " +
                        "Dept:" + " " + raddept.Text;


                        ageandsex.Text = "Age:" + "   " + checkreg[0].Age + "   " + " Sex:" + " " + checkreg[0].Sex +"  "+ "Nationality:" + " " + checkreg[0].Nationality + "        " + "Class Year:" + " " + radyear.SelectedValue + "  " + "Semister:" + " " + radsemister.Text + " " +
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
                            TBL_PrerequestCourse[] pre = slip.checkprerequestforgrade(raddept.SelectedValue, co[i].Course_code);
                            if (pre.Count() > 0)
                            {
                                for (int j = 0; j < pre.Count(); j++)
                                {
                                    TBL_studentGrade[] gr = slip.checkgradeprerequestforslip(radStudID.SelectedValue, raddept.SelectedValue, pre[j].Prerequest_Course);
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
                                            totalcredit = totalcredit + Convert.ToInt32(co[i].Credit_hour);
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
                                DataRow dr = dt.NewRow();
                                dr["S/N"] = k;
                                dr["Course Title"] = co[i].Course_name;
                                dr["Course Code"] = co[i].Course_code;
                                dr["Credit Hour"] = Convert.ToInt32(co[i].Credit_hour);
                                dr["Instructor"] = "staff";
                                totalcredit = totalcredit + Convert.ToInt32(co[i].Credit_hour);
                                dt.Rows.Add(dr);
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
                        Image2.Visible = false;
                        date.Visible = false;
                       
                        ageandsex.Visible = false;
                        region.Visible = false;
                        RadGrid1.Visible = false;
                        anames.Visible = false;
                        regi.Visible = false;
                        sign.Visible = false;
                        note.Visible = false;
                        no.Visible = false;
                    }
                }
                

                
            }

        

        protected void radyear_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
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

        protected void radsemister_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
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

        protected void radStudID_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
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
       

        }
    }
