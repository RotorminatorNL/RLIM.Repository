using RLIM.FactoryDAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace RLIM.BusinessLogic 
{ 
    public class UserCollection
    {
        public User Get(int id = 1)
        {
            return new User(UserFactoryDAL.GetCollectionDAL().Get(id));
        }
    }
}
