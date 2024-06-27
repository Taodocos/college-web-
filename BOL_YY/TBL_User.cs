using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
namespace BOL_YY
{

    public partial class TBL_UserAccount
    {
        DataClasses1DataContext acc = new DataClasses1DataContext();
        public String createAccount()
        {
            String account = Convert.ToString(acc.createAccount(_UserID, _First_Name, _Middle_Name, _Last_Name, _Account_type, _UserName, _password, _Sex, _College, _Department));
            return account;
        }
        public TBL_User[] checkAccount()
        {
            var chek = from cc in acc.TBL_Users
                       where cc.UserName == _UserName
                       select cc;
            return chek.ToArray<TBL_User>();
        }
        public TBL_User[] resetpassword()
        {
            var chek = from cc in acc.TBL_Users
                       where cc.UserID == _UserID && cc.UserName == _UserName
                       select cc;
            return chek.ToArray<TBL_User>();
        }
        public TBL_User[] userlogin()
        {
            var login = from cc in acc.TBL_Users
                        where cc.UserName == _UserName && cc.password == _password
                        select cc;
            return login.ToArray<TBL_User>();
        }
        public TBL_User[] searchalluser()
        {
            var search = from cc in acc.TBL_Users
                         select cc;
            return search.ToArray<TBL_User>();
        }
        public TBL_User[] changepassword()
        {
            var userinfos = from ccc in acc.TBL_Users
                            where ccc.UserName == _UserName
                            select ccc;
            return userinfos.ToArray<TBL_User>();
        }
        public void updatepassword()
        {
            acc.updatepassword(_password, _UserName);
        }
    }
}
    
    

