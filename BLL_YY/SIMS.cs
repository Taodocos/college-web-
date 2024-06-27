using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BOL_YY;
namespace BLL_YY
{
    public class SIMS
    {

        TBL_AcadmicCalander cal = new TBL_AcadmicCalander();
        TBL_college colleg = new TBL_college();
        TBL_department dept = new TBL_department();
        TBL_FreshStudent freshstud = new TBL_FreshStudent();
        //tbl_studentdetail upload = new tbl_studentdetail();
        TBL_Course course = new TBL_Course();
        TBL_GeneratedID id = new TBL_GeneratedID();
        TBL_studentGrade studgrade = new TBL_studentGrade();
        TBL_GradeReport gredreport = new TBL_GradeReport();
        TBL_RegisterStudent regstudent = new TBL_RegisterStudent();
        TBL_AcadmicDismissalStudent DismssalStudent = new TBL_AcadmicDismissalStudent();
        TBL_User user = new TBL_User();
        // TBL_WithdrawalStudent withdraw = new TBL_WithdrawalStudent();
        TBL_PrerequestCourse prereqcour = new TBL_PrerequestCourse();
        TBL_AddCourse add = new TBL_AddCourse();
        TBL_DropCourse drop = new TBL_DropCourse();
        // TBL_Building building = new TBL_Building();
        // StudentDorm studdorm = new StudentDorm();
        // Building Registration
        /*public bool registrationbuilding(String campus, String buildingname, int n, int s)
        {

            try
            {
                building.Campus = campus;
                building.BuildingName = buildingname;
                building.NumberofDorm = n;
                building.StudetINdorm = s;
                String reg = building.registerbuilding();
                return true;
            }
            catch (Exception ex)
            {
                return true;
            }
        }
        public bool assigndorm(String fullname, String idno, String sex, String campus, String dept, String buil, int dorm, String year, int acadmicyear)
        {
            try
            {
                studdorm.fullname = fullname;
                studdorm.idnumber = idno;
                studdorm.sex = sex;
                studdorm.campus = campus;
                studdorm.department = dept;
                studdorm.building = buil;
                studdorm.dorm = dorm;
                studdorm.years = year;
                studdorm.AcadmicYear = acadmicyear;
                String assigndo = studdorm.assigndorm();
                return true;
            }
            catch (Exception)
            {
                return true;
            }
        }
        public StudentDorm[] checkassigneddorm(String id,int ayear)
        {
            studdorm.idnumber = id;
            studdorm.AcadmicYear = ayear;
            return studdorm.checkassigndorm();
        }
        public StudentDorm[] checkmaxstudntdorm(String buil,int dorm,int year)
        {
            studdorm.building = buil;
            studdorm.dorm = dorm;
            studdorm.AcadmicYear = year;
            return studdorm.checkmaxstudntdorm();
        }
        public StudentDorm[] studentplacment(String id,int ayear)
        {
            studdorm.idnumber = id;
            studdorm.AcadmicYear = ayear;
            return studdorm.studentplacment();
        }
      /* public TBL_Building[] checkbuilding(String campus, String bname)
        {
            building.Campus = campus;
            building.BuildingName = bname;
            return building.checkbuilding();
        }
       public TBL_Building[] searchbuildingname(String campus)
       {
           building.Campus = campus;
           return building.searchbuildingname();
       }
     
        // acadmic Calander 
        public bool acadmiccalander(String aactiv, DateTime startdate, DateTime lastdate, int ayear, String semi)
        {
            try
            {
                cal.Acadminc_Activities = aactiv;
                cal.StartDateinG_C = startdate;
                cal.LastDateinG_C = lastdate;
                cal.AcadmicYear_E_C_ = ayear;
                cal.Semister = semi;
                String calander = cal.addcalander();
                return true;
            }
            catch (Exception)
            {
                return true;
            }
        }
        public bool updateacadmiccalander(String aactiv, DateTime startdate, DateTime lastdate, int ayear, String semi)
        {
            try
            {
                cal.Acadminc_Activities = aactiv;
                cal.StartDateinG_C = startdate;
                cal.LastDateinG_C = lastdate;
                cal.AcadmicYear_E_C_ = ayear;
                cal.Semister = semi;
                String calander = cal.updatecalander();
                return true;
            }
            catch (Exception)
            {
                return true;
            }
        }
        public TBL_AcadmicCalander[] checkacadmiccalander(String aactiv, String sem, int ayear)
        {
            cal.Acadminc_Activities = aactiv;
            cal.Semister = sem;
            cal.AcadmicYear_E_C_ = ayear;
            return cal.checkacadmiccalander();
        }
       /* public TBL_AcadmicCalander[] acadmiccalanderbyyear(int ayear)
        {

            cal.AcadmicYear_E_C_ = ayear;
            return cal.acadmicyearbyyear();
        }
        //add and drop course
        public bool addcourse(String studid, String fname, String mname, String lname, String coll, String dept, String year, String semi, int age, String sex,
            String nation, String region, String zone, int acyear, String ccode, String cname, int credit, DateTime regdate)
        {

            try
            {
                add.IDNo_ = studid;
                add.first_Name = fname;
                add.Middle_Name = mname;
                add.Last_Name = lname;
                add.College_Code = coll;
                add.Dept_Code = dept;
                add.Year = year;
                add.Semister = semi;
                add.Age = age;
                add.Sex = sex;
                add.Nationality = nation;
                add.Region = region;
                add.Zone = zone;
                add.Acadmic_Year = acyear;
                add.Course_Code = ccode;
                add.Course_name = cname;
                add.Credit_hour = credit;
                add.reg_date = regdate;
                String addcourse = add.addcourse();
                return true;
            }
            catch (Exception)
            {
                return true;
            }
        }*/
        public TBL_AddCourse[] checkaddedcourse(String idno, String coursecode, String year, String semister)
        {
            add.IDNo_ = idno;
            add.Course_Code = coursecode;
            add.Year = year;
            add.Semister = semister;
            return add.checkaddcourse();
        }
        public TBL_AddCourse[] searchstudentaddedcourse(String idno, String year, String semister)
        {
            add.IDNo_ = idno;
            add.Year = year;
            add.Semister = semister;
            return add.searchstudentaddedcourse();
        }

        /* public TBL_DropCourse[] checkdropcourse(String idno, String coursecode, String year, String semister)
         {
             drop.IDNo_ = idno;
             drop.Course_Code = coursecode;
             drop.Year = year;
             drop.Semister = semister;
             return drop.checkdropcourse();
         }
         public TBL_DropCourse[] searchstudentdropedcourse(String idno, String year, String semister)
         {
             drop.IDNo_ = idno;
             drop.Year = year;
             drop.Semister = semister;
             return drop.searchstudentdropedcourse();
         }

        public bool DropCourse(String studid, String fname, String mname, String lname, String coll, String dept, String year, String semi, int age, String sex,
     String nation, String region, String zone, int acyear, String ccode, String cname, int credit, DateTime regdate)
        {

            try
            {
                drop.IDNo_ = studid;
                drop.First_Name = fname;
                drop.Middle_Name = mname;
                drop.Last_Name = lname;
                drop.College_code = coll;
                drop.Dept_Code = dept;
                drop.Year = year;
                drop.Semister = semi;
                drop.Age = age;
                drop.Sex = sex;
                drop.Nationality = nation;
                drop.Region = region;
                drop.Zone = zone;
                drop.Acadmic_year = acyear;
                drop.Course_Code = ccode;
                drop.Course_Name = cname;
                drop.Credit_hour = credit;
                drop.Reg_Date = regdate;
                String dropcour = drop.dropcourse();
                return true;
            }*/
           
        
        // WithDrawal student information
        /* public bool withdrawalstudent(String studid, String fname, String mname, String lname, String coll, String dept, String sex, 
             String reson, int age, int wyear, DateTime date)
         {
             try
             {
                 withdraw.IDNo_ = studid;
                 withdraw.first_name = fname;
                 withdraw.middle_name = mname;
                 withdraw.last_name = lname;
                 withdraw.college = coll;
                 withdraw.department = dept;
                 withdraw.sex = sex;
                 withdraw.Reson = reson;
                 withdraw.age = age;
                 withdraw.Withdrawal_year = wyear;
                 withdraw.date = date;
                 String stud = withdraw.addwithdrawal();
                 return true;
             }
             catch (Exception ex)
             {
                 return true;
             }
         }
         public TBL_WithdrawalStudent[] searchwithdrawstud(String id, int wyear)
         {
             withdraw.IDNo_ = id;
             withdraw.Withdrawal_year = wyear;
             return withdraw.searchwithdrawalstudent();
         }*/

        //Acadmic Dismissal student Info
        public bool AcadmicDismissalStudent(String studid, String fname, String mname, String lname, String coll, String dept
            , String year, String semi, int age, String sex, String natio, String region, String zone, int Ayear, DateTime regdate, String studstatus)
        {
            try
            {
                DismssalStudent.StudID = studid;
                DismssalStudent.First_Name = fname;
                DismssalStudent.Midle_Name = mname;
                DismssalStudent.Last_Name = lname;
                DismssalStudent.College_Code = coll;
                DismssalStudent.Department_Code = dept;
                DismssalStudent.Year = year;
                DismssalStudent.Semister = semi;
                DismssalStudent.Age = age;
                DismssalStudent.Sex = sex;
                DismssalStudent.Nationality = natio;
                DismssalStudent.Region = region;
                DismssalStudent.Zone = zone;
                DismssalStudent.Acadmic_Year = Ayear;
                DismssalStudent.regdate = regdate;
                DismssalStudent.Student_status = studstatus;
                String student = DismssalStudent.acadmicdismssal();
                return true;

            }
            catch (Exception ex)
            {
                return true;
            }
        }
        public TBL_AcadmicDismissalStudent[] checkdismissalstud(String id, String fname, String mname, String lname, String dept, String year, String semi, String sex)
        {
            DismssalStudent.StudID = id;
            DismssalStudent.First_Name = fname;
            DismssalStudent.Midle_Name = mname;
            DismssalStudent.Last_Name = lname;
            DismssalStudent.Department_Code = dept;
            DismssalStudent.Year = year;
            DismssalStudent.Semister = semi;
            DismssalStudent.Sex = sex;
            return DismssalStudent.checkacadmicdismissalstud();

        }
        public TBL_AcadmicDismissalStudent[] searchdismissalstudent(int year)
        {
            DismssalStudent.Acadmic_Year = year;
            return DismssalStudent.searchdismissalstudent();
        }
        public TBL_AcadmicDismissalStudent[] searchforwithdrawal(String id, int acyear, String status)
        {
            DismssalStudent.StudID = id;
            DismssalStudent.Acadmic_Year = acyear;
            DismssalStudent.Student_status = status;
            return DismssalStudent.searchforwithdrawal();
        }
        //Senior Student Registration  Info
        public bool Registerseniorstudent(String studid, String fname, String mname, String lname, String coll, String dept
            , String year, String semi, int age, String sex, String natio, String region, String zone, int Ayear, DateTime regdate, String studstatus)
        {
            try
            {
                regstudent.StudID = studid;
                regstudent.First_Name = fname;
                regstudent.Midle_Name = mname;
                regstudent.Last_Name = lname;
                regstudent.College_Code = coll;
                regstudent.Department_Code = dept;
                regstudent.Year = year;
                regstudent.Semister = semi;
                regstudent.Age = age;
                regstudent.Sex = sex;
                regstudent.Nationality = natio;
                regstudent.Region = region;
                regstudent.Zone = zone;
                regstudent.Acadmic_Year = Ayear;
                regstudent.regdate = regdate;
                regstudent.Student_status = studstatus;
                String student = regstudent.registerstudent();
                return true;

            }
            catch (Exception ex)
            {
                return true;
            }
        }
        public TBL_RegisterStudent[] checkregisteredstudent(String id, String fname, String mname, String lname, String dept, String year, String semi, String sex)
        {
            regstudent.StudID = id;
            regstudent.First_Name = fname;
            regstudent.Midle_Name = mname;
            regstudent.Last_Name = lname;
            regstudent.Department_Code = dept;
            regstudent.Year = year;
            regstudent.Semister = semi;
            regstudent.Sex = sex;
            return regstudent.checkregsteredstudent();

        }
        public TBL_RegisterStudent[] checkregisteredstudentforAddCourse(String id, String year, String semister)
        {
            regstudent.StudID = id;
            regstudent.Year = year;
            regstudent.Semister = semister;
            return regstudent.checkregisteredstudentforAddCourse();
        }
        public TBL_RegisterStudent[] checkstudentWarning(String studid, String Status)
        {
            regstudent.StudID = studid;
            regstudent.Student_status = Status;
            return regstudent.checkconsecutiveWarning();
        }
        public TBL_RegisterStudent[] searchstudforgradereport(String studid, String year, String sem)
        {
            regstudent.StudID = studid;
            regstudent.Year = year;
            regstudent.Semister = sem;
            return regstudent.SearchStudentForGradeReport();
        }
        public TBL_RegisterStudent[] searchstudentforviewSenior(int ayer, String year, String semi)
        {
            regstudent.Acadmic_Year = ayer;
            regstudent.Year = year;
            regstudent.Semister = semi;
            return regstudent.searchstudentforViewSenior();
        }
        public TBL_RegisterStudent[] searchpassstudent(int year)
        {
            regstudent.Acadmic_Year = year;
            return regstudent.searchpassstudent();
        }
        public TBL_RegisterStudent[] SearchGCstudent(String dept, String year, String semi)
        {
            regstudent.Department_Code = dept;
            regstudent.Year = year;
            regstudent.Semister = semi;
            return regstudent.searchGCstudent();
        }
        public TBL_RegisterStudent[] searchGCIDNo(String id, String year, String semi)
        {
            regstudent.StudID = id;
            regstudent.Year = year;
            regstudent.Semister = semi;
            return regstudent.searchGCIDNo();
        }
        public TBL_RegisterStudent[] searchstudentforplacment(String dept, String year, String sem, int acadmicyear, String sex)
        {
            regstudent.Sex = sex;
            regstudent.Department_Code = dept;
            regstudent.Year = year;
            regstudent.Semister = sem;
            regstudent.Acadmic_Year = acadmicyear;
            return regstudent.searchstudentforplacment();
        }
        //College information managmen
        public bool addcollege(String c_code, String college_name)
        {
            colleg.College_Code = c_code;
            colleg.College_Name = college_name;

            String co = colleg.addcollege();

            return true;
        }
        public TBL_college[] SearchAllCollege()
        {
            return colleg.searchallcollege();
        }
        public TBL_college[] SearchallCollegeRad()
        {
            return colleg.SearchAllCollege();
        }
        public bool updatedColleges(String ccode, String cname)
        {
            try
            {
                colleg.College_Code = ccode;
                colleg.College_Name = cname;
                colleg.updateCollege();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
        public TBL_college[] findcollegebycode(String ccode)
        {
            colleg.College_Code = ccode;
            return colleg.findallcollegebycode();
        }
        public TBL_college[] checkAllcollegebyName(String name)
        {
            colleg.College_Name = name;
            return colleg.checkallcollegebyName();
        }
        //Department Information
        public bool addeddepartment(String c_code, String d_code, String d_name)
        {
            try
            {
                dept.College_Code = c_code;
                dept.Department_Code = d_code;
                dept.Department_name = d_name;
                String de = dept.addepartments();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public TBL_department[] SearchAllDepartment()
        {
            return dept.searchalldepartment();
        }
        public TBL_department[] checkDepartmentbyName(String dept_name)
        {
            dept.Department_name = dept_name;
            return dept.CheckdeptbyName();
        }
        public TBL_department[] searchalldepartmentbycollege(String collegecode)
        {
            dept.College_Code = collegecode;
            return dept.SearchAlldepartmentByCollege();
        }
        public TBL_department[] SearchalldepartmentbyName(String deptcode)
        {
            dept.Department_Code = deptcode;
            return dept.SearchAlldepartmentbyName();
        }

        public bool updatedepartment(String dname, String dcode)
        {
            try
            {
                dept.Department_Code = dcode;
                dept.Department_name = dname;
                dept.updatedepartment();
                return true;
            }
            catch (Exception ex)
            {
                return true;
            }

        }


        //Fresh Student Information
        public bool RegisterFreshStudent(String studid, String fname, String mname, String lname, String college,
           String dept, int age, String sex, String nation, String region, String zone,
           int Acadmic_year, String classYear, DateTime regdate)
        {
            try
            {
                freshstud.Stud_ID = studid;
                freshstud.first_name = fname;
                freshstud.middle_name = mname;
                freshstud.last_name = lname;
                freshstud.college = college;
                freshstud.department = dept;
                freshstud.age = age;
                freshstud.sex = sex;
                freshstud.natinality = nation;
                freshstud.region = region;
                freshstud.zone = zone;
                freshstud.Acadmic_year = Acadmic_year;
                freshstud.Class_year = classYear;
                freshstud.reg_date = regdate;
                String fresh = freshstud.addfreshstudent();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public TBL_FreshStudent[] searchstudentforplacment(String dept, String year, int acadmicyear, String sex)
        {
            freshstud.sex = sex;
            freshstud.department = dept;
            freshstud.Class_year = year;
            freshstud.Acadmic_year = acadmicyear;
            return freshstud.searchstudentforplacment();
        }
        public TBL_FreshStudent[] searchAllFreshStudent()
        {
            return freshstud.searchalFreshStudent();
        }
        public TBL_FreshStudent[] searchstudentidbydept(String dept)
        {
            freshstud.department = dept;
            return freshstud.SearchStudentIDbydept();
        }
        public TBL_FreshStudent[] searchstudentbyid(String id)
        {
            freshstud.Stud_ID = id;
            return freshstud.SearchStudentByID();
        }
        public TBL_FreshStudent[] checkfreshstudent(String id, String fname, String mname, String lname, String dept)
        {
            freshstud.Stud_ID = id;
            freshstud.first_name = fname;
            freshstud.middle_name = mname;
            freshstud.last_name = lname;
            freshstud.department = dept;
            return freshstud.CheckStudentForRegistration();
        }
        public TBL_FreshStudent[] searchstudidbydeptandAY(String deptcode, int ayear)
        {
            freshstud.department = deptcode;
            freshstud.Acadmic_year = ayear;
            return freshstud.searchstudentbydeptandAY();
        }
        public bool updatefreshstudent(String ccode, String dcode, String studid)
        {
            try
            {
                freshstud.college = ccode;
                freshstud.department = dcode;
                freshstud.Stud_ID = studid;
                freshstud.updatefrehstudent();
                return true;
            }
            catch (Exception ex)
            {
                return true;
            }

        }
        public TBL_FreshStudent[] serachstudentforviewFresh(int ayear, String year)
        {
            freshstud.Acadmic_year = ayear;
            freshstud.Class_year = year;
            return freshstud.searchstudentforView();
        }

        //Student Information Sent from Minster Of Education
        /*public tbl_studentdetail[] searchStudentFromMinsterOfEducation(String fname, String mname, String lname, int year)
        {
            upload.fname = fname;
            upload.mname = mname;
            upload.lname = lname;
            upload.year = year;
            return upload.SearchStudentUploadedminsterofeducation();
        }
        public tbl_studentdetail[] uploadliststudentfromME()
        {
            return upload.uploadlistfromME();
        }
        public bool deleteduplicatestudent(String regno)
        {
            try
            {
                upload.Reg_no = regno;
                upload.deleteduplicatestudent();
                return true;

            }
            catch (Exception)
            {
                return true;
            }
        }*/

        // Course information
        public TBL_Course[] searchallcourse()
        {
            return course.searchallcourse();
        }
        public bool courseregster(String college, String dept, String ccode, String cname, int credithour, String year, String semister)
        {
            try
            {
                course.College_code = college;
                course.Department_code = dept;
                course.Course_code = ccode;
                course.Course_name = cname;
                course.Credit_hour = credithour;
                course.Year = year;
                course.Semister = semister;
                String co = course.addcourse();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
        public TBL_Course[] checkcoursebyname(String coursename, String dept)
        {
            course.Course_name = coursename;
            course.Department_code = dept;
            return course.checkcoursebyname();
        }
        public TBL_Course[] searchcredithour(String dept, String year, String semi)
        {
            course.Department_code = dept;
            course.Year = year;
            course.Semister = semi;
            return course.searchCredithour();
        }
        public TBL_Course[] searchcoursebydys(String dept, String year, String semis)
        {
            course.Department_code = dept;
            course.Year = year;
            course.Semister = semis;
            return course.searchcoursebyDYS();
        }
        public TBL_Course[] searchcoursebydept(String dept)
        {
            course.Department_code = dept;
            return course.searchcoursebydept();
        }
        public TBL_Course[] searchcoursebyCCode(String ccode)
        {
            course.Course_code = ccode;
            return course.searchCoursebyCcode();
        }
        public bool updatecourse(String cname, int chour, String year, String semi, String ccode)
        {
            try
            {
                course.Course_name = cname;
                course.Credit_hour = chour;
                course.Year = year;
                course.Semister = semi;
                course.Course_code = ccode;
                course.updatecourse();
                return true;
            }
            catch (Exception ex)
            {
                return true;
            }

        }
        // prerequest Course information
      /*  public bool prerequestReg(String deptcode, String coursecode, String prerequest)
        {
            try
            {
                prereqcour.dept_code = deptcode;
                prereqcour.Course_Code = coursecode;
                prereqcour.Prerequest_Course = prerequest;
                String checkpre = prereqcour.prerequest();
                return true;
            }
            catch (Exception ex)
            {
                return true;
            }
        }
        public TBL_PrerequestCourse[] checkprerequest(String dept, String ccode, String precou)
        {
            prereqcour.dept_code = dept;
            prereqcour.Course_Code = ccode;
            prereqcour.Prerequest_Course = precou;
            return prereqcour.searchprerequest();
        }
        public TBL_PrerequestCourse[] checkprerequestforgrade(String deptcode, String ccode)
        {
            prereqcour.dept_code = deptcode;
            prereqcour.Course_Code = ccode;
            return prereqcour.checkfPrerequestforgrade();
        }
        //Generated id information
        public bool idregister(String studid, String dept, String img)
        {
            id.StudID = studid;
            id.department = dept;
            id.StudentImg = img;
            String generateid = id.registergeneratedid();
            return true;
        }*/
        // Student Grade information
        public TBL_studentGrade[] searchstudgrade(String dept, String studid, String year, String semi)
        {
            studgrade.Department = dept;
            studgrade.Year = year;
            studgrade.Semister = semi;
            studgrade.StudentID = studid;
            return studgrade.searchgradebyDYS();
        }
        public TBL_studentGrade[] searchallgrade()
        {
            return studgrade.searchallgrade();
        }
        public TBL_studentGrade[] searchstudgradebyIDNo(String studid)
        {
            studgrade.StudentID = studid;
            return studgrade.serachstudgradebyIDNo();
        }
        public TBL_studentGrade[] searchstudgradebyIDNOandgrede(String studid, String grade)
        {
            studgrade.StudentID = studid;
            studgrade.Grade = grade;
            return studgrade.searchstudgradebyidnoandGrade();
        }
        public bool updateteachername(String teachername, String studid, String deptcode, String ccode)
        {
            studgrade.Instrucor_UserName = teachername;
            studgrade.StudentID = studid;
            studgrade.Department = deptcode;
            studgrade.Course_Code = ccode;
            String updateins = studgrade.updateteachername();
            return true;
        }
        public bool deleteDuplicateGrade(String id, String dept, String ccode, String year, String semi)
        {
            studgrade.StudentID = id;
            studgrade.Department = dept;
            studgrade.Course_Code = ccode;
            studgrade.Year = year;
            studgrade.Semister = semi;
            String duplicategrade = studgrade.deleteDuplicateGrade();
            return true;
        }
        public bool deleteprerequestgrade(String id, String ccode)
        {
            studgrade.StudentID = id;
            studgrade.Course_Code = ccode;
            String del = studgrade.deleteprerequestgrade();
            return true;
        }
        public TBL_studentGrade[] viewgrade(String id, String year, String semi)
        {
            studgrade.StudentID = id;
            studgrade.Year = year;
            studgrade.Semister = semi;
            return studgrade.viewgradecheck();
        }
        public TBL_studentGrade[] checkgradeforprerequest(String deptcode, String ccode)
        {
            studgrade.Department = deptcode;
            studgrade.Course_Code = ccode;
            return studgrade.checkgradeforprerequest();
        }
        public TBL_studentGrade[] checkgradeprerequestforslip(String studid, String deptcode, String ccode)
        {
            studgrade.StudentID = studid;

            studgrade.Department = deptcode;
            studgrade.Course_Code = ccode;
            return studgrade.checkgradeprequestslip();
        }
        //Student Grade Report Information
        public bool regstergradereport(String studid, String year, String semi, int chour, float totalpoint, float sgpa, float cgpa, String acadmicstatus)
        {
            gredreport.StudentID = studid;
            gredreport.Year = year;
            gredreport.Semister = semi;
            gredreport.TotalCredit = chour;
            gredreport.TotalPoint = totalpoint;
            gredreport.SGPA = sgpa;
            gredreport.CGPA = cgpa;
            gredreport.AcadmicStatus = acadmicstatus;
            String gradereport = gredreport.registergradereport();
            return true;
        }
        public bool updategradereport(String studid, String year, String semi, int chour, float totalpoint, float sgpa, float cgpa, String acadmicstatus)
        {

            gredreport.StudentID = studid;
            gredreport.Year = year;
            gredreport.Semister = semi;
            gredreport.TotalCredit = chour;
            gredreport.TotalPoint = totalpoint;
            gredreport.SGPA = sgpa;
            gredreport.CGPA = cgpa;
            gredreport.AcadmicStatus = acadmicstatus;
            String updategrade = gredreport.updategradeReport();
            return true;
        }
        public TBL_GradeReport[] checkgradereport(String studid, String year, String semi)
        {
            gredreport.StudentID = studid;
            gredreport.Year = year;
            gredreport.Semister = semi;
            return gredreport.checkGradereport();
        }

        //User Account Information
        public bool createaccount(String userid, String fname, String mname, String lname, String atype, String username, String pass, String sex, String college, String dept)
        {
            try
            {
                user.UserID = userid;
                user.First_Name = fname;

                user.Middle_Name = mname;
                user.Last_Name = lname;
                user.Account_type = atype;

                // user.Email = email;
                user.UserName = username;
                user.password = pass;
                user.Sex = sex;
                user.College = college;
                user.Department = dept;
                String account = user.createAccount();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public TBL_User[] checkaccount(string username)
        {
            user.UserName = username;
            return user.checkAccount();
        }
        public TBL_User[] ResetPassword(string userid, string username)
        {
            user.UserID = userid;
            user.UserName = username;
            return user.resetpassword();
        }
        public TBL_User[] Checkuserlogin(String username, String password)
        {
            user.UserName = username;
            user.password = password;
            return user.userlogin();
        }
        public TBL_User[] searchalluser()
        {
            return user.searchalluser();
        }
        public TBL_User[] changepassword(String username)
        {
            user.UserName = username;
            return user.changepassword();
        }
        public bool updatedpassword(String pass, String uname)
        {
            try
            {
                user.password = pass;
                user.UserName = uname;
                user.updatepassword();
                return true;
            }
            catch (Exception ex)
            {
                return true;
            }

        }
    }
   
}