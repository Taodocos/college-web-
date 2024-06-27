using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOL_YY
{
    public partial class TBL_College
    {
        DataClasses1DataContext college = new DataClasses1DataContext();
        public string addcollege()
        {
            String coll = Convert.ToString(college.AddColleges(_College_Code, _College_Name));
            return coll;
        }
        public TBL_college[] searchallcollege()
        {
            var colleginfos = from cc in college.TBL_colleges
                              select cc;
            return colleginfos.ToArray<TBL_college>();

        }
        public TBL_college[] SearchAllCollege()
        {
            var colleginfos = from cc in college.TBL_colleges
                              select cc;
            return colleginfos.ToArray<TBL_college>();
        }
        public void updateCollege()
        {
            college.UpdateCollege(_College_Code, _College_Name);
        }
        public TBL_college[] findallcollegebycode()
        {
            var colleginfos = from cc in college.TBL_colleges
                              where cc.College_Code == _College_Code
                              select cc;
            return colleginfos.ToArray<TBL_college>();
        }
        public TBL_college[] checkallcollegebyName()
        {
            var colleginfos = from cc in college.TBL_colleges
                              where cc.College_Name == _College_Name
                              select cc;
            return colleginfos.ToArray<TBL_college>();
        }
    }
    }
}