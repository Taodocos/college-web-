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
    public partial class FreshStudentRegitration : System.Web.UI.Page
    {
         SIMS freshstudent = new SIMS();
         int count = 0;
        int countindex;
        int CIndex;
         protected void Page_Load(object sender, EventArgs e)
         {
             if (!Page.IsPostBack)
             {
                 SearchCollege();

             }
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
         }


         private void SearchCollege()
         {
             radcollege.DataTextField = "College_Name";
             radcollege.DataValueField = "College_Code";
             radcollege.DataSource = freshstudent.SearchallCollegeRad();
             radcollege.DataBind();
         }
         private void searchdepartment()
         {
             raddept.DataTextField = "Department_name";
             raddept.DataValueField = "Department_Code";
             raddept.DataSource = freshstudent.searchalldepartmentbycollege(radcollege.SelectedValue);
             raddept.DataBind();
         }

         private void GenerateStudentID()
         {
             TBL_FreshStudent[] generatetid = freshstudent.searchAllFreshStudent();
             string currentMonth = DateTime.Now.Month.ToString();
             string currentYear = DateTime.Now.Year.ToString();
             int month = Convert.ToInt32(currentMonth);
             int year = Convert.ToInt32(currentYear);
             if (month < 9)
             {
                 ethipiayear = year - 8;

             }
             else
             {
                 ethipiayear = year - 7;
             }
             string ethioyear = Convert.ToString(ethipiayear);
             String substringyear = ethioyear.Substring(2, 2);
             int ch = Convert.ToInt32(substringyear);

             foreach (TBL_FreshStudent ping in generatetid)
             {
                 count++;
                 // CIndex++;
                 countindex++;
                 String get = generatetid[count - 1].Stud_ID;
                 String chgeti = get.Substring(5);
                 int getie = Convert.ToInt32(chgeti);
                 if (getie == Convert.ToInt32(substringyear))
                 {
                     CIndex++;
                 }
                 // label.Text = Convert.ToString(CIndex);
             }
             if (count != 0 && CIndex > 0)
             {
                 String lastcount = generatetid[count - 1].Stud_ID;
                 //String First = Convert.ToString(lastcount.IndexOf("/") + 1);
                 //int fir = Convert.ToInt32(First);
                 if (CIndex <= 9)
                 {
                     String last = Convert.ToString(lastcount.LastIndexOf("/"));
                     int las = Convert.ToInt32(last);
                     int var = las - 3;
                     String sub = lastcount.Substring(3, var);
                     int lastid = Convert.ToInt32(sub);
                     lastid = CIndex;
                     String checkdept = "000" + lastid + "/" + substringyear;
                     for (int j = 0; j < count; j++)
                     {
                         for (int i = 0; i < count; i++)
                         {
                             if (generatetid[j].Stud_ID == checkdept)
                             {
                                 lastid = lastid + 1;
                                 checkdept = "000" + lastid + "/" + substringyear;
                             }
                             // txtidno.Text = "000" + lastid + "/" + substringyear;
                         }

                     }
                     txtidno.Text = "000" + lastid + "/" + substringyear;
                     txtidno.Enabled = false;
                 }
                 else if (CIndex >= 10 && CIndex <= 99)
                 {
                     String last = Convert.ToString(lastcount.LastIndexOf("/"));
                     int las = Convert.ToInt32(last);
                     int var = las - 2;
                     String sub = lastcount.Substring(2, var);
                     // int lastid = Convert.ToInt32(sub);
                     int lastid = CIndex;

                     String checkdept = "00" + lastid + "/" + substringyear;
                     for (int j = 0; j < count; j++)
                     {
                         for (int i = 0; i < count; i++)
                         {
                             if (generatetid[i].Stud_ID == checkdept)
                             {
                                 lastid = lastid + 1;
                                 checkdept = "00" + lastid + "/" + substringyear;

                             }
                         }
                         //txtidno.Text = "00" + lastid + "/" + substringyear;
                     }
                     txtidno.Text = "00" + lastid + "/" + substringyear;
                     //label.Text = Convert.ToString(CIndex);
                     txtidno.Enabled = false;
                 }
                 else if (CIndex >= 100 && CIndex <= 999)
                 {

                     String last = Convert.ToString(lastcount.LastIndexOf("/"));
                     int las = Convert.ToInt32(last);
                     int var = las - 1;
                     String sub = lastcount.Substring(1, var);
                     int lastid = Convert.ToInt32(sub);
                     lastid = CIndex;
                     String checkdept = "0" + lastid + "/" + substringyear;
                     for (int j = 0; j < count; j++)
                     {
                         for (int i = 0; i < count; i++)
                         {
                             if (generatetid[i].Stud_ID == checkdept)
                             {
                                 lastid = lastid + 1;
                                 checkdept = "0" + lastid + "/" + substringyear;

                             }
                         }
                         //txtidno.Text = "00" + lastid + "/" + substringyear;
                     }
                     txtidno.Text = "0" + lastid + "/" + substringyear;
                     txtidno.Enabled = false;
                 }
                 else
                 {

                     String last = Convert.ToString(lastcount.LastIndexOf("/"));
                     int las = Convert.ToInt32(last);
                     int var = las - 0;
                     String sub = lastcount.Substring(0, var);
                     int lastid = Convert.ToInt32(sub);
                     lastid = CIndex;
                     String checkdept = "" + lastid + "/" + substringyear;
                     for (int j = 0; j < count; j++)
                     {
                         for (int i = 0; i < count; i++)
                         {
                             if (generatetid[i].Stud_ID == checkdept)
                             {
                                 lastid = lastid + 1;
                                 checkdept = "" + lastid + "/" + substringyear;

                             }
                         }
                         //txtidno.Text = "00" + lastid + "/" + substringyear;
                     }
                     txtidno.Text = "" + lastid + "/" + substringyear;
                     txtidno.Enabled = false;
                 }

             }
             //second condition
             else if (count != 0 && CIndex <= 0)
             {
                 String lastcount = generatetid[count - 1].Stud_ID;
                 //String First = Convert.ToString(lastcount.IndexOf("/") + 1);
                 //int fir = Convert.ToInt32(First);
                 if (CIndex <= 9)
                 {
                     String last = Convert.ToString(lastcount.LastIndexOf("/"));
                     int las = Convert.ToInt32(last);
                     int var = las - 3;
                     String sub = lastcount.Substring(3, var);
                     int lastid = Convert.ToInt32(sub);
                     lastid = CIndex;
                     String checkdept = "000" + lastid + "/" + substringyear;
                     for (int j = 0; j < count; j++)
                     {
                         for (int i = 0; i < count; i++)
                         {
                             if (generatetid[j].Stud_ID == checkdept)
                             {
                                 lastid = lastid + 1;
                                 checkdept = "000" + lastid + "/" + substringyear;
                             }
                         }
                         // txtidno.Text = "000" + lastid + "/" + substringyear;
                     }
                     txtidno.Text = checkdept;
                     txtidno.Enabled = false;

                 }
             }
             //end
             //else
             //{
             //    txtidno.Text = "000" + count + "/" + substringyear;
             //    txtidno.Enabled = false;
             //    label.Text = Convert.ToString(CIndex);

             //}
         }
         protected void btn_register_Click(object sender, EventArgs e)
         {
             Save();
             ViewState["CurrentData"] = null;
             Gvrecords.Visible = false;
             GenerateStudentID();
             Gvrecords.Visible = false;

         }
         private void BindGrid(int rowcount)
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
             DateTime regdate = DateTime.Now;
             // DateTime acadmic = DateTime.Now;

             String CurentYear = "I";
             dt.Columns.Add(new System.Data.DataColumn("IDNo", typeof(String)));

             dt.Columns.Add(new System.Data.DataColumn("First_Name", typeof(String)));

             dt.Columns.Add(new System.Data.DataColumn("Middle_Name", typeof(String)));

             dt.Columns.Add(new System.Data.DataColumn("Last_Name", typeof(String)));

             dt.Columns.Add(new System.Data.DataColumn("College_code", typeof(String)));
             dt.Columns.Add(new System.Data.DataColumn("Dept_code", typeof(String)));
             dt.Columns.Add(new System.Data.DataColumn("Age", typeof(String)));

             dt.Columns.Add(new System.Data.DataColumn("Sex", typeof(String)));

             dt.Columns.Add(new System.Data.DataColumn("Nationality", typeof(String)));

             dt.Columns.Add(new System.Data.DataColumn("Region", typeof(String)));

             dt.Columns.Add(new System.Data.DataColumn("Zone", typeof(String)));


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


                 dr[0] = txtidno.Text;
                 dr[1] = txtfname.Text;
                 dr[2] = txtmname.Text;
                 dr[3] = txtlname.Text;
                 dr[4] = radcollege.SelectedValue;
                 dr[5] = raddept.SelectedValue;
                 dr[6] = Convert.ToInt32(txtage.Text);

                 dr[7] = radsex.SelectedValue;
                 dr[8] = radregion.SelectedValue;
                 dr[9] = txtzone.Text;
                 dr[10] = txtnatonal.Text;
                 dt.Rows.Add(dr);



             }

             else
             {


                 dr = dt.NewRow();

                 dr[0] = txtidno.Text;
                 dr[1] = txtfname.Text;
                 dr[2] = txtmname.Text;
                 dr[3] = txtlname.Text;
                 dr[4] = radcollege.SelectedValue;
                 dr[5] = raddept.SelectedValue;
                 dr[6] = Convert.ToInt32(txtage.Text);

                 dr[7] = radsex.SelectedValue;
                 dr[8] = radregion.SelectedValue;
                 dr[9] = txtzone.Text;
                 dr[10] = txtnatonal.Text;




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

         private void Save()
         {
             int ethipiayr;
             string currentMonth = DateTime.Now.Month.ToString();
             string currentYear = DateTime.Now.Year.ToString();
             DateTime regdate = DateTime.Now;
             DateTime acadmic = DateTime.Now;

             String CurentYear = "I";
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
             if (Gvrecords.Rows.Count > 0)
             {
                 foreach (GridViewRow g1 in Gvrecords.Rows)
                 {
                     string id = (g1.FindControl("lblid") as Label).Text;
                     string fname = (g1.FindControl("lblfname") as Label).Text;
                     string mname = (g1.FindControl("lblmname") as Label).Text;
                     string lname = (g1.FindControl("lbllname") as Label).Text;
                     string college = (g1.FindControl("lblcollege") as Label).Text;
                     string dept = (g1.FindControl("lbldept") as Label).Text;
                     int age = Convert.ToInt32((g1.FindControl("lblage") as Label).Text);
                     string sex = (g1.FindControl("lblsex") as Label).Text;
                     string nation = (g1.FindControl("lblnation") as Label).Text;
                     string region = (g1.FindControl("lblregion") as Label).Text;
                     string zone = (g1.FindControl("lblzone") as Label).Text;

                     tbl_studentdetail[] Checks = freshstudent.searchStudentFromMinsterOfEducation(fname, mname, lname, ethipiayr);
                     if (Checks.Count() > 0)
                     {
                         if (freshstudent.RegisterFreshStudent(id, fname, mname, lname, college, dept, age, sex, nation, region, zone, ethipiayr, CurentYear, regdate))
                         {
                             label.Text = "Sucessfully registered";

                             // generateCollegeCode();
                         }
                         else
                         {
                             label.Text = "Eror occured";
                         }
                     }


                     else
                     {
                         label.Text = fname + " " + " " + mname + " " + " Does not Assign For HU please contact Registrar Manager";
                     }
                 }
             }
             else
             {
                 tbl_studentdetail[] Checks = freshstudent.searchStudentFromMinsterOfEducation(txtfname.Text, txtmname.Text, txtlname.Text, ethipiayr);

                 /*valids.addComponent(txtfname, ComponentValidator.PERSON_NAME, true);
                 valids.addComponent(txtlname, ComponentValidator.PERSON_NAME, true);
                 valids.addComponent(txtmname, ComponentValidator.PERSON_NAME, true);
                 valids.addComponent(radcollege, ComponentValidator.NO_FORMAT, true);
                 valids.addComponent(raddept, ComponentValidator.NO_FORMAT, true);
                 valids.addComponent(txtage, ComponentValidator.INTEGER_NUMBER, true);
                 valids.addComponent(radsex, ComponentValidator.NO_FORMAT, true);
                 //valids.addComponent(radAcadmicYear, ComponentValidator.GC_DATE, true);
                 valids.addComponent(txtnatonal, ComponentValidator.TEXT_A_TO_Z_ONLY, true);
                 valids.addComponent(txtzone, ComponentValidator.FULL_NAME, true);
                 valids.addComponent(radregion, ComponentValidator.NO_FORMAT, true);
                 if (valids.isAllComponenetValid())
                 {
                    */ if (Checks.Count() > 0)
                     {

                         try
                         {
                             if (freshstudent.RegisterFreshStudent(txtidno.Text, txtfname.Text, txtmname.Text, txtlname.Text, radcollege.SelectedValue,
                                 raddept.SelectedValue, Convert.ToInt32(txtage.Text), radsex.SelectedValue, txtnatonal.Text,
                                 radregion.SelectedValue, txtzone.Text, ethipiayr, CurentYear, regdate))
                             {
                                 txtfname.Text = "";
                                 txtmname.Text = "";
                                 txtlname.Text = "";
                                 // SearchCollege();
                                 // searchdepartment();
                                 txtage.Text = "";
                                 radsex.Text = radsex.EmptyMessage;
                                 // raddept.Text = raddept.EmptyMessage;
                                 radsex.Text = radsex.EmptyMessage;
                                 radregion.Text = radregion.EmptyMessage;

                                 txtnatonal.Text = "";
                                 txtzone.Text = "";
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


                     else
                     {
                         label.Text = "This student is not assigned in HU please contact Registrar Manager";
                     }
                 }

             }
         }}

         protected void raddept_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
         {
             TBL_department[] dept = freshstudent.SearchalldepartmentbyName(raddept.SelectedValue);
             label.Text = "";
             if (dept.Count() > 0)
             {
                 raddept.Text = dept[0].Department_name;
             }
             else
             {

                 label.Text = "no Such Department in the selected College";
             }
         
}
         protected void radcollege_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
         {
             TBL_department[] dept = freshstudent.searchalldepartmentbycollege(radcollege.SelectedValue);
             label.Text = "";
             if (dept.Count() > 0)
             {
                 // radcollege.Text = dept[0].College_Code;
                 searchdepartment();
             }
             else
             {
                 raddept.Items.Clear();
                 label.Text = "this college no department";
             }
         }

         protected void txtfname_TextChanged(object sender, EventArgs e)
         {
             label.Text = "";
         }

         protected void btn_add_Click(object sender, EventArgs e)
         {

             valids.addComponent(txtfname, ComponentValidator.PERSON_NAME, true);
             valids.addComponent(txtlname, ComponentValidator.PERSON_NAME, true);
             valids.addComponent(txtmname, ComponentValidator.PERSON_NAME, true);
             valids.addComponent(radcollege, ComponentValidator.NO_FORMAT, true);
             valids.addComponent(raddept, ComponentValidator.NO_FORMAT, true);
             valids.addComponent(txtage, ComponentValidator.INTEGER_NUMBER, true);
             valids.addComponent(radsex, ComponentValidator.NO_FORMAT, true);
             //valids.addComponent(radAcadmicYear, ComponentValidator.GC_DATE, true);
             valids.addComponent(txtnatonal, ComponentValidator.TEXT_A_TO_Z_ONLY, true);
             valids.addComponent(txtzone, ComponentValidator.TEXT_A_TO_Z_ONLY, true);
             valids.addComponent(radregion, ComponentValidator.NO_FORMAT, true);
             if (valids.isAllComponenetValid())
             {

                 //generateCollegeCode();
                 if (ViewState["CurrentData"] != null)
                 {
                     DataTable dt = (DataTable)ViewState["CurrentData"];
                     int count = dt.Rows.Count;
                     BindGrid(count);
                     String sub = txtidno.Text;
                     String sube = sub.Substring(0, 4);
                     String slash = sub.Substring(4);
                     int lastcode = Convert.ToInt32(sube);
                     if (lastcode < 10)
                     {
                         lastcode = lastcode + 1;
                         String code = "000" + lastcode + slash;
                         txtidno.Text = code;
                     }
                     else if (lastcode >= 10 && lastcode <= 99)
                     {
                         lastcode = lastcode + 1;
                         String code = "00" + lastcode + slash;
                         txtidno.Text = code;
                     }
                     else if (lastcode >= 100 && lastcode <= 999)
                     {
                         lastcode = lastcode + 1;
                         String code = "0" + lastcode + slash;
                         txtidno.Text = code;
                     }
                     else
                     {
                         lastcode = lastcode + 1;
                         String code = lastcode + slash;
                         txtidno.Text = code;
                     }
                 }
                 else
                 {
                     BindGrid(1);
                     String sub = txtidno.Text;
                     String sube = sub.Substring(0, 4);
                     String slash = sub.Substring(4);
                     int lastcode = Convert.ToInt32(sube);
                     if (lastcode < 10)
                     {
                         lastcode = lastcode + 1;
                         String code = "000" + lastcode + slash;
                         txtidno.Text = code;
                     }
                     else if (lastcode >= 10 && lastcode <= 99)
                     {
                         lastcode = lastcode + 1;
                         String code = "00" + lastcode + slash;
                         txtidno.Text = code;
                     }
                     else if (lastcode >= 100 && lastcode <= 999)
                     {
                         lastcode = lastcode + 1;
                         String code = "0" + lastcode + slash;
                         txtidno.Text = code;
                     }
                     else
                     {
                         lastcode = lastcode + 1;
                         String code = lastcode + slash;
                         txtidno.Text = code;
                     }
                 }
                 Gvrecords.Visible = true;
                 Gvrecords.AllowPaging = true;
                 label.Text = " ";
             }
         }

         protected void Button1_Click(object sender, EventArgs e)
         {
             txtfname.Text = "";
             txtmname.Text = "";
             txtlname.Text = "";
             SearchCollege();
             searchdepartment();
             txtage.Text = "";
             radsex.Text = radsex.EmptyMessage;
             raddept.Text = raddept.EmptyMessage;
             radsex.Text = radsex.EmptyMessage;
             radregion.Text = radregion.EmptyMessage;

             txtnatonal.Text = "";
             txtzone.Text = "";
             label.Text = "";
         }
     }
        
    }

        
    
