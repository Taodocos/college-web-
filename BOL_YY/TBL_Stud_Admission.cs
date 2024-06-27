using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOL_YY
{
    public partial class TBL_Stud_Admission
    {
           DataClasses1DataContext student = new DataClasses1DataContext();
        public String Add_Student()
        {
            String stud = Convert.ToString(student.Add_Student(_Year, _Classification,_College,_Department,_Stud_Id,_Full_Name,_Gender,
                _Nationality,_Place_Of_Birth,_Date_Of_Birth,_Martial_Status,_Region,_Zone,_Woreda,_Town,_Phone_No,_Mother_Full_Name,
                _Mother_Phone_No,_Contact_Full_Name,_contact_Phone_no,_Enterance_Result));
            return stud;
        }
        public TBL_Stud_Admission[] checkstudbyid()
        {
            var stud_info = from cc in student.TBL_Stud_Admissions
                            where cc.Stud_Id == _Stud_Id
                            select cc;
            return stud_info.ToArray< TBL_Stud_Admission>();
        }
        public TBL_Stud_Admission[] searchallstud()
        {
            var stud_info = from cc in student.TBL_Stud_Admissions
                            select cc;
            return stud_info.ToArray< TBL_Stud_Admission>();
        }
    }
    }
