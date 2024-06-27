using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOL_YY
{
    public class TBL_AddCourse
    {
        DataClasses1DataContext add = new DataClasses1DataContext();
       public String addcourse()
       { 
       String course=Convert.ToString(add.Addcourse(_IDNo_,_first_Name,_Middle_Name,_Last_Name,_College_Code,_Dept_Code,_Year,_Semister,_Age,_Sex,_Nationality,_Region,_Zone,_Acadmic_Year,_Course_Code,_Course_name,_Credit_hour,_reg_date));
           return course;
       }
       public TBL_AddCourse[] checkaddcourse()
       {
           var check = from cc in add.TBL_AddCourses
                       where cc.IDNo_ == _IDNo_ && cc.Course_Code == _Course_Code&& cc.Year==_Year&& cc.Semister==_Semister
                       select cc;
           return check.ToArray<TBL_AddCourse>();
       }
       public TBL_AddCourse[] searchstudentaddedcourse()
       {
           var check = from cc in add.TBL_AddCourses
                       where cc.IDNo_ == _IDNo_ && cc.Year == _Year && cc.Semister == _Semister
                       select cc;
           return check.ToArray<TBL_AddCourse>();
       }
    }
    }
