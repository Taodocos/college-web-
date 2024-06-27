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
    public partial class StudentID : System.Web.UI.Page
    {
        SIMS sims = new SIMS();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                SearchCollege();
                label.Visible = false;

                
                pbox.Visible = false;
                dire.Visible = false;
                name.Visible = false;
                dept.Visible = false;
                id.Visible = false;
                under.Visible = false;
                valid.Visible = false;
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
        private void searchstudentID()
        {
            radStudID.DataTextField = "Stud_ID";
            radStudID.DataValueField = "Stud_ID";
            radStudID.DataSource = sims.searchstudentidbydept(raddept.SelectedValue);
            radStudID.DataBind();
        }

        protected void radcollege_SelectedIndexChanged(object sender,EventArgs e)
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
                //raddept.Items.Clear();
                label.Text = "this college no department";
            }
            label.Visible = true;

            Image1.Visible = false;
            Image2.Visible = false;
        
            pbox.Visible = false;
            dire.Visible = false;
            name.Visible = false;
            dept.Visible = false;
            id.Visible = false;
            under.Visible = false;
            valid.Visible = false;
        }

        protected void raddept_SelectedIndexChanged(object sender, EventArgs e)
        {
            TBL_FreshStudent[] studid = sims.searchstudentidbydept(raddept.SelectedValue);
           
            label.Text = "";
            if (studid.Count() > 0)
            {
                // radStudID.Text = studid[0].Stud_ID;
                searchstudentID();

            }
            else
            {
                radStudID.Items.Clear();
                label.Text = "no student in"+" "+raddept.Text;
                Image1.Visible = false;
                Image2.Visible = false;

                pbox.Visible = false;
                dire.Visible = false;
                name.Visible = false;
                dept.Visible = false;
                id.Visible = false;
                under.Visible = false;
                valid.Visible = false;
            }
            label.Visible = true;

            Image1.Visible = false;
            Image2.Visible = false;
          
            pbox.Visible = false;
            dire.Visible = false;
            name.Visible = false;
            dept.Visible = false;
            id.Visible = false;
            under.Visible = false;
            valid.Visible = false;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            
            label.Visible = true;
            label.Text = " ";
            Image1.Visible = true;
            Image2.Visible = true;
            pbox.Visible = true;
            dire.Visible = true;
            name.Visible = true;
            dept.Visible = true;
            id.Visible = true;
            under.Visible = true;
            valid.Visible = true;

            Image1.ImageUrl = " ";
            Image2.ImageUrl = " ";
            pbox.Text = " ";
            dire.Text = " ";
            name.Text = " ";
            dept.Text = " ";
            id.Text = " ";
            under.Text = " ";
            valid.Text = " ";
           
            TBL_FreshStudent[] st = sims.searchstudentbyid(radStudID.SelectedValue);
           /* valids.addComponent(radcollege, ComponentValidator.NO_FORMAT, true);
            valids.addComponent(raddept, ComponentValidator.NO_FORMAT, true);
            valids.addComponent(radStudID, ComponentValidator.NO_FORMAT, true);
            if (valids.isAllComponenetValid())
            {*/
                if(st.Count()>0)
                {
                    if (FileUpload1.HasFile)
                    {
                        String Str = FileUpload1.FileName;
                        FileUpload1.PostedFile.SaveAs(Server.MapPath(".") + "//uploads//" + Str);
                        String path = "~//uploads//" + Str.ToString();
                        if (sims.idregister(radStudID.SelectedValue, raddept.SelectedValue, path))
                        {
                          //  label.Text = "successfully regstered";
                            
                           

                            Image1.ImageUrl = "uploads/" + Str.ToString();
                            Image2.ImageUrl = "../images/ID.PNG";
                         
                            pbox.Text = "P.o.Box 138,woldia,Ethiopia";
                            dire.Text = "Tel. +251-25-5530313";
                            name.Text = "Name:"+" "+st[0].first_name + " " + st[0].middle_name + " " + st[0].last_name;
                            dept.Text = "Department:" + raddept.Text;
                            id.Text = "ID No:" + " " + radStudID.SelectedValue;
                            under.Text = "Undergraduate";
                            if (radcollege.SelectedValue == "YU_College-0")
                            {
                                if (raddept.SelectedValue == "YU_Dept/3")
                                {
                                    valid.Text = "Valid:" + " " + st[0].Acadmic_year + "-" + (Convert.ToInt32(st[0].Acadmic_year) + 4) + " " + "E.C";
                                }
                                else
                                {

                                    valid.Text = "Valid:" + " " + st[0].Acadmic_year + "-" + (Convert.ToInt32(st[0].Acadmic_year) + 3) + " " + "E.C";
                                }
                                }
                            else if (radcollege.SelectedValue == "YU_College-1" || radcollege.SelectedValue == "YU_College-2" || radcollege.SelectedValue == "YU_College-3" || radcollege.SelectedValue == "YU_College-5" || radcollege.SelectedValue == "YU_College-6")
                            {
                                valid.Text = "Valid:" + " " + st[0].Acadmic_year + "-" + (Convert.ToInt32(st[0].Acadmic_year) + 3) +" "+ "E.C";
                            }
                            else if (radcollege.SelectedValue == "YU_College-4" || radcollege.SelectedValue == "YU_College-8")
                            {
                                valid.Text = "Valid:" + " " + st[0].Acadmic_year + "-" + (Convert.ToInt32(st[0].Acadmic_year) + 5) +" "+ "E.C";
                            }
                            else if (radcollege.SelectedValue == "YU_College-7")
                            {
                                valid.Text = "Valid:" + " " + st[0].Acadmic_year + "-" + (Convert.ToInt32(st[0].Acadmic_year) + 6) + " " + "E.C";
                            }
                          
                        }

                        else
                        {
                            label.Text = "Error occured";
                        }
                    }
                    else
                    {
                        
                    label.Text="Please select student photo";
                    Image1.Visible = false;
                    Image2.Visible = false;

                    pbox.Visible = false;
                    dire.Visible = false;
                    name.Visible = false;
                    dept.Visible = false;
                    id.Visible = false;
                    under.Visible = false;
                    valid.Visible = false;
                    }
                
                }
                else
                {
                    label.Text = "no student in this department";
                    Image1.Visible = false;
                    Image2.Visible = false;

                    pbox.Visible = false;
                    dire.Visible = false;
                    name.Visible = false;
                    dept.Visible = false;
                    id.Visible = false;
                    under.Visible = false;
                    valid.Visible = false;
                }
               
            }
        }
    }
}
        