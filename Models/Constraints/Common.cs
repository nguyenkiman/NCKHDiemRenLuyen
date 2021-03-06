using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Constraints
{
    public class Common
    {
        public const int ACTIVATE = 1;
        public const int INACTIVATE = 0;

        public const int ACCOUNT_NOT_EXISTS = 0;
        public const int INVALID_PASSWORDS = 1;
        public const int LOGIN_SUCCESS = 2;
        public const int BLOCK = 3;

        public const string USER_SESSION = "USER_SESSION";
        public const string NAME_USER_SESSION = "MA_USER_SESSION";
        public const string LOP_USER_SESSION = "LOP_USER_SESSION";
        public const string IS_CAN_BO_SESSION = "IS_CAN_BO_SESSION";


        public const int PAGE_SIZE = 10;
       
    }
}
