using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOL_YY
{
    public class TBL_AcadmicDismissalStudent
    
    {
        DataClasses1DataContext dismssal = new DataClasses1DataContext();
       public String acadmicdismssal()
       {
           String AcadmicDismssal = Convert.ToString(dismssal.AcadmicDismssalStudent(_StudID, _First_Name, _Midle_Name, _Last_Name, _College_Code, _Department_Code, _Year, _Semister, _Age
               , _Sex, _Nationality, _Region, _Zone, _Acadmic_Year, _regdate, _Student_status));
           return AcadmicDismssal;
       }
       public TBL_AcadmicDismissalStudent[] checkacadmicdismissalstud()
       {
           var stud = from cc in dismssal.TBL_AcadmicDismissalStudents
                      where cc.StudID == _StudID && cc.First_Name == _First_Name && cc.Midle_Name == _Midle_Name && cc.Last_Name == _Last_Name
                      && cc.Department_Code == _Department_Code && cc.Year == _Year && cc.Semister == _Semister && cc.Sex == _Sex
                      select cc;
           return stud.ToArray<TBL_AcadmicDismissalStudent>();

       }
       public TBL_AcadmicDismissalStudent[] searchdismissalstudent()
       {
           var fail = from cc in dismssal.TBL_AcadmicDismissalStudents
                      where cc.Acadmic_Year == _Acadmic_Year
                      select cc;
           return fail.ToArray<TBL_AcadmicDismissalStudent>();
       }
       public TBL_AcadmicDismissalStudent[] searchforwithdrawal()
       {
           var readmistion = from cc in dismssal.TBL_AcadmicDismissalStudents
                             where cc.StudID == _StudID && cc.Acadmic_Year == _Acadmic_Year && cc.Student_status == _Student_status
                             select cc;
           return readmistion.ToArray<TBL_AcadmicDismissalStudent>();
       }
    }
    }
