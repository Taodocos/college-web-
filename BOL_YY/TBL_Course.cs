using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
namespace BOL_YY{

    public partial class TBL_Course
    {

        DataClasses1DataContext course = new DataClasses1DataContext();
        public String addcourse()
        {
            String cour = Convert.ToString(course.registercourse(_College_code, _Department_code, _Course_code, _Course_name, _Credit_hour, _Year, _Semister));
            return cour;
        }
        public TBL_Course[] searchallcourse()
        {
            var courseinfo = from cc in course.TBL_Courses
                             select cc;
            return courseinfo.ToArray<TBL_Course>();
        }
        public TBL_Course[] checkcoursebyname()
        {
            var courseinfos = from cc in course.TBL_Courses
                              where cc.Course_name == _Course_name && cc.Department_code == _Department_code
                              select cc;
            return courseinfos.ToArray<TBL_Course>();
        }
        public TBL_Course[] searchCredithour()
        {
            var credit = from cc in course.TBL_Courses
                         where cc.Department_code == _Department_code && cc.Year == _Year && cc.Semister == _Semister
                         select cc;
            return credit.ToArray<TBL_Course>();
        }
        public TBL_Course[] searchcoursebyDYS()
        {
            var grade = from cc in course.TBL_Courses
                        where cc.Department_code == _Department_code && cc.Year == _Year && cc.Semister == _Semister
                        select cc;
            return grade.ToArray<TBL_Course>();
        }
        public TBL_Course[] searchcoursebydept()
        {
            var view = from cc in course.TBL_Courses
                       where cc.Department_code == _Department_code
                       select cc;
            return view.ToArray<TBL_Course>();
        }
        public TBL_Course[] searchCoursebyCcode()
        {
            var sera = from cc in course.TBL_Courses
                       where cc.Course_code == _Course_code
                       select cc;
            return sera.ToArray<TBL_Course>();
        }
        public void updatecourse()
        {
            course.updatecourse(_Course_name, _Credit_hour, _Year, _Semister, _Course_code);
        }
    }
  
}