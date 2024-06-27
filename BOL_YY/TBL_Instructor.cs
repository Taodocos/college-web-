using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOL_YY
{
    public partial class TBL_Instructor
    {

        DataClasses1DataContext instructor = new DataClasses1DataContext();
        public String Add_Instructor()
        {
            String ins = Convert.ToString(instructor.Add_Instructor(_Instructor_Id, _FullName, _DateofBirth, _BirthPlace, _Gender, _Department, _Position, _Email, _Adress));
            return ins;
        }
    }
}