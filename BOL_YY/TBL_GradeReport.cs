using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOL_YY
{
    public class TBL_GradeReport
    {
        DataClasses1DataContext report = new DataClasses1DataContext();
       public String registergradereport()
       {
           String Greport = Convert.ToString(report.RegisterGradeReport(_StudentID, _Year, _Semister, _TotalCredit, _TotalPoint, _SGPA,_CGPA, _AcadmicStatus));
           return Greport;
       }
       public String updategradeReport()
       {
          String upgreport=Convert.ToString( report.updateGradeReport(_StudentID, _Year, _Semister, _TotalCredit, _TotalPoint, _SGPA,CGPA, _AcadmicStatus));
          return upgreport;
       }
       public TBL_GradeReport[] checkGradereport()
       {
           var chekgradereport = from cc in report.TBL_GradeReports
                                 where cc.StudentID == _StudentID && cc.Year == _Year && cc.Semister == _Semister
                                 select cc;
           return chekgradereport.ToArray<TBL_GradeReport>();
       }
    }
    }
