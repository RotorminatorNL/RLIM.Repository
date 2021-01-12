using System.Collections.Generic;

namespace RLIM.ContractLayer
{
    public class UserDTO
    {
        public int ID { get; set; } = 0;
        public List<int> SubItemIDs { get; set; } = new List<int>();
    }
}
