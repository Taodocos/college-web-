using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
namespace BOL_YY
{

    public partial class TBL_UserAccount
    {
        DataClasses1DataContext user = new DataClasses1DataContext();
       public String Add_User()
        {
            String users = Convert.ToString(user.Add_User(_Username, _Password, _Confirmpassword, _Email, _Roll, _Status));
            return users;
        }
        public TBL_UserAccount[] cheackuserbyname()
        {
            var user_info = from cc in user.TBL_UserAccounts
                            where cc.Username == _Username
                            select cc;
            return user_info.ToArray<TBL_UserAccount>();
        }
        public TBL_UserAccount[] searchalluser()
        {
            var user_info = from cc in user.TBL_UserAccounts
                            select cc;
            return user_info.ToArray<TBL_UserAccount>();
        }
        
        public TBL_UserAccount[] userlogin()
        {
            var login = from f in user.TBL_UserAccounts
                        where f.Username == _Username && f.Password == _Password
                        select f;
            return login.ToArray<TBL_UserAccount>();
        }
    }
}
    
    

