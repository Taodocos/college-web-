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
    public partial class CollegeModfication : System.Web.UI.Page
    {
        SIMS college = new SIMS();
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
                    // lbl.Text = " User:" + Session["userName"].ToString();
                    }
                }
                catch (Exception ex)
                {

                }
                searchcollegeRad();
               

            }
        }
         private void searchcollegeRad()
        {
            Radcollegecode.DataTextField = "College_Code";
            Radcollegecode.DataValueField = "College_Code";
            Radcollegecode.DataSource = college.SearchallCollegeRad();
            Radcollegecode.DataBind();
        }

         protected void btn_update_Click(object sender, EventArgs e)
         {
             //{
             /*valids.addComponent(Radcollegecode, ComponentValidator.NO_FORMAT, true);
             valids.addComponent(txtCollege_name, ComponentValidator.FULL_NAME, true);
             if (valids.isAllComponenetValid())
             {
                 updateCollege();
             }
         }*/
         }
        private void updateCollege()
        {
            if(college.updatedColleges(Convert.ToString(Radcollegecode.SelectedValue),txtCollege_name.Text))
            {
            Label3.Text="College successfully Updated";
            Radcollegecode.SelectedValue = "Select to Update Another College";
            txtCollege_name.Text = "";
            }
            else
            {
            Label3.Text="Error occured";
            }
            Radcollegecode.SelectedValue="Select to Update Another College";
            txtCollege_name.Text = "";
            }

        protected void btn_delete_Click(object sender, EventArgs e)
        {
             txtCollege_name.Text = "";
        }
        
        }

        }
    