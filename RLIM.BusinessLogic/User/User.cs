using RLIM.ContractLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace RLIM.BusinessLogic
{
    public class User
    {
        public int ID { get; private set; } = 0;
        public List<int> SubItemsInventory { get; private set; } = new List<int>();

        public User(UserDTO userDTO)
        {
            ID = userDTO.ID;
            SubItemsInventory = userDTO.SubItemIDs;
        }
    }
}
