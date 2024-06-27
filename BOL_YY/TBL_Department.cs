using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOL_YY
{
    public partial class TBL_department
    {
        DataClasses1DataContext dept = new DataClasses1DataContext();
        public string addepartments()
        {
            String dep = Convert.ToString(dept.adddepartment(_College_Code, _Department_Code, _Department_name));
            return dep;
        }
        public TBL_department[] searchalldepartment()
        {
            var deptinfos = from cc in dept.TBL_departments
                            select cc;
            return deptinfos.ToArray<TBL_department>();

        }
        public TBL_department[] CheckdeptbyName()
        {
            var deptinfos = from cc in dept.TBL_departments
                            where cc.Department_name == _Department_name
                            select cc;
            return deptinfos.ToArray<TBL_department>();
        }
        public TBL_department[] SearchAlldepartmentByCollege()
        {
            var deptinfos = from cc in dept.TBL_departments
                            where cc.College_Code == _College_Code
                            select cc;
            return deptinfos.ToArray<TBL_department>();
        }
        public TBL_department[] SearchAlldepartmentbyName()
        {
            var deptinfos = from cc in dept.TBL_departments
                            where cc.Department_Code == _Department_Code
                            select cc;
            return deptinfos.ToArray<TBL_department>();
        }
        public void updatedepartment()
        {
            dept.updatedepartment(_Department_name, _Department_Code);
        }
    }
    }
