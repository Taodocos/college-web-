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
    public partial class UplodStudentGrade : System.Web.UI.Page
    {
        SIMS sims = new SIMS();

        protected void Page_Load(object sender, EventArgs e)
        {
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
        protected void btnUpload_Click(object sender, EventArgs e)
        {
            try
            {
                //valids.addComponent(radsemister, ComponentValidator.NO_FORMAT, true);
                //if (valids.isAllComponenetValid())
                //{
                    if (FileUpload2.HasFile)
                    {
                        Label1.Text = " ";
                        string path = string.Concat((Server.MapPath("~/Instructor/Excel/" + FileUpload2.FileName)));
                        FileUpload2.PostedFile.SaveAs(path);
                        TBL_studentGrade[] gre = sims.searchallgrade();
                        TBL_FreshStudent[] fresh = sims.searchAllFreshStudent();
                        TBL_Course[] cou = sims.searchallcourse();
                        TBL_department[] dep = sims.SearchAllDepartment();
                        OleDbConnection OleDbcon = new OleDbConnection("Provider=Microsoft.Ace.OLEDB.12.0;Data Source=" + path + ";Extended Properties=Excel 12.0; ");
                        OleDbCommand cmd = new OleDbCommand("select * from [Sheet1$]", OleDbcon);
                        OleDbDataAdapter objAdapter1 = new OleDbDataAdapter(cmd);
                        OleDbcon.Open();
                        //DbDataAdapter dr = cmd.ExecuteReader();
                        DataTable dt = new DataTable();
                        objAdapter1.Fill(dt);
                        for (int j = 0; j < gre.Count(); j++)
                        {
                            for (int i = 0; i < dt.Rows.Count; i++)
                            {
                                if (gre[j].StudentID == dt.Rows[i][0].ToString() && gre[j].Department == dt.Rows[i][1].ToString() && gre[j].Course_Code == dt.Rows[i][2].ToString() && gre[j].Year == dt.Rows[i][4].ToString() && gre[j].Semister == dt.Rows[i][5].ToString())
                                {
                                    sims.deleteDuplicateGrade(gre[j].StudentID, gre[j].Department, gre[j].Course_Code, gre[j].Year, gre[j].Semister);
                                }
                            }
                        }

                        string con_str = @"Data Source=PC\SQLEXPRESS;Initial Catalog=HUSIMS;Integrated Security=True";
                        SqlBulkCopy bulkinsert = new SqlBulkCopy(con_str);
                        bulkinsert.DestinationTableName = "TBL_studentGrade";
                        bulkinsert.WriteToServer(cmd.ExecuteReader());
                        OleDbcon.Close();
                        for (int k = 0; k < dt.Rows.Count; k++)
                        {
                            sims.updateteachername(Session["userName"].ToString(), dt.Rows[k][0].ToString(), dt.Rows[k][1].ToString(), dt.Rows[k][2].ToString());
                        }
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            TBL_PrerequestCourse[] pre = sims.checkprerequestforgrade(dt.Rows[i][1].ToString(), dt.Rows[i][2].ToString());
                            if (pre.Count() > 0)
                            {
                                for (int j = 0; j < pre.Count(); j++)
                                {
                                    TBL_studentGrade[] gr = sims.checkgradeprerequestforslip(dt.Rows[i][0].ToString(), pre[j].dept_code, pre[j].Prerequest_Course);
                                    if (gr.Count() > 0)
                                    {
                                        if (gr[j].Grade == "F")
                                        {
                                            sims.deleteprerequestgrade(gr[j].StudentID, dt.Rows[i][2].ToString());
                                            Label2.Text = "some student havn't grade because of prerequest Course";
                                        }
                                    }
                                }
                            }
                            else
                            {

                            }
                        }
                        Array.ForEach(Directory.GetFiles((Server.MapPath("~/Instructor/Excel/"))), File.Delete);
                        Label1.ForeColor = Color.Green;
                        Label1.Text = "sucessfully inserted";

                    }
                    else
                    {
                        Label1.ForeColor = Color.Red;
                        Label1.Text = "please select the file";

                    }
                }
            }
            catch (Exception)
            {
                Label1.ForeColor = Color.Red;
                Label1.Text = "some exception occured please check again";
            }



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
                TBL_AcadmicCalander[] calander = sims.checkacadmiccalander(" submit grades of Graduate students", radsemister.SelectedValue, ethipiayr);
                DateTime current = DateTime.Now;
                if (calander.Count() > 0)
                {
                    DateTime start = Convert.ToDateTime(calander[0].StartDateinG_C);
                    DateTime last = Convert.ToDateTime(calander[0].LastDateinG_C);

                    if (current >= start && current <= last)
                    {
                        FileUpload2.Enabled = true;
                        btnUpload.Enabled = true;

                    }
                    else
                    {
                        FileUpload2.Enabled = false;
                        btnUpload.Enabled = false;
                        Label2.Text = "Grade Upload page is Disactive b/c Acadmic Grade submition date";
                    }
                }
                else
                {
                    FileUpload2.Enabled = false;
                    btnUpload.Enabled = false;
                    Label2.Text = "Grade Upload page is Disactive b/c Acadmic Grade submition date";
                }
            }
            catch (Exception ex)
            {
                Label2.Text = "Some Exception Occured.please refresh the page";
            }
        }
        }
    }
