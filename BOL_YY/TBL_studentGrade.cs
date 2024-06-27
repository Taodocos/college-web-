using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOL_YY
{
    public partial class TBL_studentGrade
    {
        DataClasses1DataContext grade = new DataClasses1DataContext();
        public TBL_studentGrade[] searchgradebyDYS()
        {
        var gr=from cc in grade.TBL_studentGrades
               where cc.Department==_Department && cc.StudentID==_StudentID && cc.Year==_Year && cc.Semister==_Semister
               select cc;
        return gr.ToArray<TBL_studentGrade>();
        }
        public TBL_studentGrade[] searchallgrade()
        {
            var gr = from cc in grade.TBL_studentGrades
                     select cc;
            return gr.ToArray<TBL_studentGrade>();
        }
        public TBL_studentGrade[] serachstudgradebyIDNo()
        {
            var gr = from cc in grade.TBL_studentGrades
                     where cc.StudentID==_StudentID
                     select cc;
            return gr.ToArray<TBL_studentGrade>();
        }
        public TBL_studentGrade[] searchstudgradebyidnoandGrade()
        {
            var gr = from cc in grade.TBL_studentGrades
                     where cc.StudentID == _StudentID && cc.Grade == _Grade
                     select cc;
            return gr.ToArray<TBL_studentGrade>();
        }
        public String  deleteDuplicateGrade()
        {
            String duplicate = Convert.ToString(grade.DeleteDuplicateGrade(_StudentID, _Department, _Course_Code, _Year, _Semister));
            return duplicate;
        }
        public String deleteprerequestgrade()
        {
            String gr = Convert.ToString(grade.deleteprerequestgrade(_StudentID, _Course_Code));
            return gr;
        }
        public String updateteachername()
        {
            String teacher = Convert.ToString(grade.updateTeacherUsername(_Instrucor_UserName, _StudentID, _Department, _Course_Code));
            return teacher;
        }
        public TBL_studentGrade[] viewgradecheck()
        {
            var view = from cc in grade.TBL_studentGrades
                       where cc.StudentID == _StudentID && cc.Year == _Year && cc.Semister == _Semister
                       select cc;
            return view.ToArray<TBL_studentGrade>();
        }
        public TBL_studentGrade[] checkgradeforprerequest()
        {
            var pre = from cc in grade.TBL_studentGrades
                      where cc.Department == _Department && cc.Course_Code == _Course_Code
                      select cc;
            return pre.ToArray<TBL_studentGrade>();
        }
        public TBL_studentGrade[] checkgradeprequestslip()
        {
            var pre = from cc in grade.TBL_studentGrades
                      where cc.StudentID==_StudentID&& cc.Department == _Department && cc.Course_Code == _Course_Code
                      select cc;
            return pre.ToArray<TBL_studentGrade>();
        }
    }
      
   
    }
