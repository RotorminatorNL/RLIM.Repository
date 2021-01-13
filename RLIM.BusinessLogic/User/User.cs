using RLIM.ContractLayer;
using RLIM.FactoryDAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace RLIM.BusinessLogic
{
    public class User
    {
        public int ID { get; private set; } = 0;
        public int SubItemID { get; private set; } = 0;
        public List<int> SubItemsInventory { get; private set; } = new List<int>();

        public User(UserDTO userDTO)
        {
            ID = userDTO.ID;
            SubItemsInventory = userDTO.SubItemIDs;
        }

        public void SetSubItemID(int id)
        {
            SubItemID = id;
        }

        public bool AddSubItemToInventory()
        {
            if (SubItemID > 0)
            {
                return UserFactoryDAL.GetDAL().AddToInventory(ID, SubItemID);
            }

            return false;
        }

        public bool RemoveSubItemFromInventory()
        {
            if (SubItemID > 0)
            {
                return UserFactoryDAL.GetDAL().RemoveFromInventory(ID, SubItemID);
            }

            return false;
        }
    }
}
