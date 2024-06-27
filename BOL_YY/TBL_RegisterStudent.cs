using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOL_YY
{
    public class TBL_RegisterStudent
    {
        DataClasses1DataContext register = new DataClasses1DataContext();
        public String registerstudent()
        {
            String student = Convert.ToString(register.RegisterStudent(_StudID, _First_Name,_Midle_Name, _Last_Name, _College_Code, _Department_Code, _Year, _Semister, _Age
                , _Sex, _Nationality, _Region, _Zone, _Acadmic_Year, _regdate,_Student_status));
            return student;
        }
        public TBL_RegisterStudent[] checkregsteredstudent()
        {
            var stud = from cc in register.TBL_RegisterStudents
                       where cc.StudID == _StudID && cc.First_Name == _First_Name && cc.Midle_Name == _Midle_Name && cc.Last_Name == _Last_Name
                       && cc.Department_Code == _Department_Code && cc.Year == _Year && cc.Semister == _Semister && cc.Sex == _Sex
                       select cc;
            return stud.ToArray<TBL_RegisterStudent>();
        
        }
        public TBL_RegisterStudent[] checkregisteredstudentforAddCourse()
        {
            var stud = from cc in register.TBL_RegisterStudents
                       where cc.StudID == _StudID  && cc.Year == _Year && cc.Semister == _Semister
                       select cc;
            return stud.ToArray<TBL_RegisterStudent>();
        }
        public TBL_RegisterStudent[] checkconsecutiveWarning()
        {
            var warning = from cc in register.TBL_RegisterStudents
                          where cc.StudID == _StudID && cc.Student_status == _Student_status
                          select cc;
            return warning.ToArray<TBL_RegisterStudent>();
        }
        public TBL_RegisterStudent[] SearchStudentForGradeReport()
        {
            var check = from cc in register.TBL_RegisterStudents
                        where cc.StudID == _StudID && cc.Year == _Year && cc.Semister == _Semister
                        select cc;
            return check.ToArray<TBL_RegisterStudent>();
        }
        public TBL_RegisterStudent[] searchstudentforViewSenior()
        {
            var view = from cc in register.TBL_RegisterStudents
                       where cc.Acadmic_Year == _Acadmic_Year && cc.Year == _Year && cc.Semister == _Semister
                       select cc;
            return view.ToArray<TBL_RegisterStudent>();
        }
        public TBL_RegisterStudent[] searchpassstudent()
        {
            var view = from cc in register.TBL_RegisterStudents
                       where cc.Acadmic_Year == _Acadmic_Year 
                       select cc;
            return view.ToArray<TBL_RegisterStudent>();
        }
        public TBL_RegisterStudent[] searchGCstudent()
        {
            var gc = from cc in register.TBL_RegisterStudents
                     where cc.Department_Code == _Department_Code && cc.Year == _Year && cc.Semister == _Semister
                     select cc;
            return gc.ToArray<TBL_RegisterStudent>();
        }
        public TBL_RegisterStudent[] searchGCIDNo()
        {
            var gc = from cc in register.TBL_RegisterStudents
                     where cc.StudID==_StudID && cc.Year == _Year && cc.Semister == _Semister
                     select cc;
            return gc.ToArray<TBL_RegisterStudent>();
        }
        public TBL_RegisterStudent[] searchstudentforplacment()
        {
            var dorm = from cc in register.TBL_RegisterStudents
                       where cc.Department_Code == _Department_Code && cc.Year == _Year&&cc.Semister==_Semister&& cc.Acadmic_Year == _Acadmic_Year && cc.Sex==_Sex
                       select cc;
            return dorm.ToArray<TBL_RegisterStudent>();
        }
    }
    }
