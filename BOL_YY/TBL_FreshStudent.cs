using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOL_YY
{
    public partial class TBL_FreshStudent
    {
        DataClasses1DataContext stud = new DataClasses1DataContext();
        public String addfreshstudent()
        {
            String freshstudent = Convert.ToString(stud.RegisterFreshStudent(_Stud_ID, _first_name, _middle_name,
                 _last_name, _college, _department, _age, _sex, _natinality, _region, _zone, _Acadmic_year,
                 _Class_year, _reg_date));
            return freshstudent;
        }
        public TBL_FreshStudent[] searchalFreshStudent()
        {
            var student = from cc in stud.TBL_FreshStudents
                          select cc;
            return student.ToArray<TBL_FreshStudent>();
        }
        public TBL_FreshStudent[] SearchStudentIDbydept()
        {
            var id = from cc in stud.TBL_FreshStudents
                     where cc.department == _department
                     select cc;
            return id.ToArray<TBL_FreshStudent>();
        }
        public TBL_FreshStudent[] SearchStudentByID()
        {
            var stu = from cc in stud.TBL_FreshStudents
                      where cc.Stud_ID == _Stud_ID
                      select cc;
            return stu.ToArray<TBL_FreshStudent>();
        }
        public TBL_FreshStudent[] CheckStudentForRegistration()
        {
            var stu = from cc in stud.TBL_FreshStudents
                      where cc.Stud_ID == _Stud_ID && cc.first_name == _first_name && cc.middle_name == _middle_name && cc.last_name == _last_name && cc.department == _department
                      select cc;
            return stu.ToArray<TBL_FreshStudent>();
        }
        public TBL_FreshStudent[] searchstudentbydeptandAY()
        {
            var info = from cc in stud.TBL_FreshStudents
                       where cc.department == _department && cc.Acadmic_year == _Acadmic_year
                       select cc;
            return info.ToArray<TBL_FreshStudent>();
        }
        public void updatefrehstudent()
        {
            stud.updateFreshStudent(_college, _department, _Stud_ID);
        }
        public TBL_FreshStudent[] searchstudentforView()
        {
            var view = from cc in stud.TBL_FreshStudents
                       where cc.Acadmic_year == _Acadmic_year && cc.Class_year == _Class_year
                       select cc;
            return view.ToArray<TBL_FreshStudent>();
        }
        public TBL_FreshStudent[] searchstudentforplacment()
        {
            var dorm = from cc in stud.TBL_FreshStudents
                       where cc.department == _department && cc.Class_year == _Class_year && cc.Acadmic_year == _Acadmic_year && cc.sex == _sex
                       select cc;
            return dorm.ToArray<TBL_FreshStudent>();
        }
    }
    }
