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
    public partial class AcadmicCalander : System.Web.UI.Page
    {
        SIMS calander = new SIMS();
        //ComponentValidator valids = new ComponentValidator();
        DataTable dt = new DataTable();
        DataRow dr;
        protected void Page_Load(object sender, EventArgs e)
        {
            Calendar1.MinDate = DateTime.Now;
            Calendar2.MinDate = DateTime.Now;
            int ethipiayear;
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
            txtacadmiccyear.Text = Convert.ToString(ethipiayear);
        }

        protected void btnadd_Click(object sender, EventArgs e)
        {

          /*  valids.addComponent(txtacadmiccyear, ComponentValidator.INTEGER_NUMBER, true);
            valids.addComponent(radacadmicactivites, ComponentValidator.NO_FORMAT, true);
            valids.addComponent(radsemister, ComponentValidator.NO_FORMAT, true);
            valids.addComponent(radsemister, ComponentValidator.NO_FORMAT, true);
            valids.addComponent(radstartdate, ComponentValidator.GC_DATE, true);
            valids.addComponent(radlastdate, ComponentValidator.GC_DATE, true);
            if (valids.isAllComponenetValid())
            {
            */
                //generateCollegeCode();
                if (ViewState["CurrentData"] != null)
                {
                    DataTable dt = (DataTable)ViewState["CurrentData"];
                    int count = dt.Rows.Count;
                    BindGrid(count);
                }
                else
                {
                    BindGrid(1);

                }
                Gvrecords.Visible = true;
                label.Text = " ";
            }

        
        private void BindGrid(int rowcount)
        {





            dt.Columns.Add(new System.Data.DataColumn("Acadminc_Activities", typeof(String)));

            dt.Columns.Add(new System.Data.DataColumn("StartDate", typeof(String)));

            dt.Columns.Add(new System.Data.DataColumn("LastDate", typeof(String)));
            dt.Columns.Add(new System.Data.DataColumn("Semister", typeof(String)));
            dt.Columns.Add(new System.Data.DataColumn("AcadmicYear", typeof(String)));

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


                dr[0] = radacadmicactivites.SelectedValue;

                dr[1] = radstartdate.SelectedDate;
                dr[2] = radlastdate.SelectedDate;
                dr[3] = radsemister.SelectedValue;
                dr[4] = txtacadmiccyear.Text;

                dt.Rows.Add(dr);



            }

            else
            {


                dr = dt.NewRow();

                dr[0] = radacadmicactivites.SelectedValue;

                dr[1] = radstartdate.SelectedDate;
                dr[2] = radlastdate.SelectedDate;
                dr[3] = radsemister.SelectedValue;
                dr[4] = txtacadmiccyear.Text;


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
            if (radstartdate.SelectedDate > radlastdate.SelectedDate)
            {
                label.Text = "The last date must be after the start Date";
                da.Text = "*";
            }
            else
            {
                save();
                ViewState["CurrentData"] = null;
                Gvrecords.Visible = false;
            }
        }

        private void save()
        {
            try
            {
                if (Gvrecords.Rows.Count > 0)
                {

                    foreach (GridViewRow g1 in Gvrecords.Rows)
                    {
                        string activites = (g1.FindControl("lblaactivites") as Label).Text;
                        String startdate = (g1.FindControl("lblstartdate") as Label).Text;
                        String lastdate = (g1.FindControl("lbllastdate") as Label).Text;
                        int ayear = Convert.ToInt32((g1.FindControl("lblayear") as Label).Text);
                        string semister = (g1.FindControl("lblsemister") as Label).Text;
                        TBL_AcadmicCalander[] check = calander.checkacadmiccalander(activites, semister, ayear);

                        if (check.Count() == 0)
                        {
                            if (calander.acadmiccalander(activites, Convert.ToDateTime(startdate), Convert.ToDateTime(lastdate), ayear, semister))
                            {
                                label.Text = "Sucessfully registered";

                            }
                            else
                            {
                                label.Text = "Eror occured";
                            }
                        }

                        else
                        {
                            label.Text = " Allready registered";
                        }
                    }
                }
                else
                {
                    label.Text = "Please First Add all fields to data table";
                }
            }
            catch (Exception)
            {

            }
        }



        protected void btnupdate_Click(object sender, EventArgs e)
        {
            if (Calendar1.SelectedDate > Calendar2.SelectedDate)
            {
                label.Text = "The last date must be after the start Date";
                da.Text = "*";
            }
            else
            {
                update();
                ViewState["CurrentData"] = null;
                Gvrecords.Visible = false;
            }
        }

        private void update()
        {
            try
            {
                if (Gvrecords.Rows.Count > 0)
                {

                    foreach (GridViewRow g1 in Gvrecords.Rows)
                    {
                        string activites = (g1.FindControl("lblaactivites") as Label).Text;
                        String startdate = (g1.FindControl("lblstartdate") as Label).Text;
                        String lastdate = (g1.FindControl("lbllastdate") as Label).Text;
                        int ayear = Convert.ToInt32((g1.FindControl("lblayear") as Label).Text);
                        string semister = (g1.FindControl("lblsemister") as Label).Text;
                        TBL_AcadmicCalander[] check = calander.checkacadmiccalander(activites, semister, ayear);

                        if (check.Count() > 0)
                        {
                            if (calander.updateacadmiccalander(activites, Convert.ToDateTime(startdate), Convert.ToDateTime(lastdate), ayear, semister))
                            {
                                label.Text = "Sucessfully update";

                            }
                            else
                            {
                                label.Text = "Eror occured";
                            }
                        }

                        else
                        {
                            label.Text = " no updation";
                        }
                    }
                }
                else
                {
                    label.Text = "Please First Add all fields to data table";
                }
            }
            catch (Exception)
            {

            }
        }

        protected void radstartdate_SelectedDateChanged(object sender, Telerik.Web.UI.Calendar.SelectedDateChangedEventArgs e)
        {

        }

        protected void radlastdate_SelectedDateChanged(object sender, Telerik.Web.UI.Calendar.SelectedDateChangedEventArgs e)
        {


        }
               


               


        }
    }
