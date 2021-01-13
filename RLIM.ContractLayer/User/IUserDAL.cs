using System.Collections.Generic;

namespace RLIM.ContractLayer
{
    public interface IUserDAL
    {
        bool AddToInventory(int userID, int subItemID);
        bool RemoveFromInventory(int userID, int subItemID);
    }
}
