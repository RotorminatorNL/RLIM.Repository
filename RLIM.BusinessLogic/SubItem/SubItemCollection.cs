using RLIM.ContractLayer;
using RLIM.FactoryDAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace RLIM.BusinessLogic
{
    public class SubItemCollection
    {
        private readonly ISubItemCollectionDAL CollectionDAL = SubItemFactoryDAL.GetCollectionDAL();

        public List<SubItem> GetAll()
        {
            List<SubItem> subItems = new List<SubItem>();

            foreach (SubItemDTO subItemDTO in CollectionDAL.GetAll())
            {
                subItems.Add(new SubItem(subItemDTO));
            }

            return subItems;
        }
    }
}
