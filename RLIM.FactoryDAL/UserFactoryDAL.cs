using RLIM.ContractLayer;
using RLIM.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace RLIM.FactoryDAL
{
    public static class UserFactoryDAL
    {
        public static IUserCollectionDAL GetCollectionDAL()
        {
            return new UserDAL();
        }

        public static IUserDAL GetDAL()
        {
            return new UserDAL();
        }
    }
}
