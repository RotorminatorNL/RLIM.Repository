using RLIM.ContractLayer;
using RLIM.FactoryDAL;
using System.Collections.Generic;

namespace RLIM.BusinessLogic
{
    public class MainItemCollection
    {
        public void Create(string name, int categoryID, int platformID, int qualityID)
        {
            MainItemDTO mainItemDTO = new MainItemDTO
            {
                Name = name,
                CategoryID = categoryID,
                PlatformID = platformID,
                QualityID = qualityID
            };

            if (MainItemFactoryDAL.GetCollectionDAL().GetID(mainItemDTO) == 0)
            {
                int id = MainItemFactoryDAL.GetCollectionDAL().Create(mainItemDTO);

                SubItemDTO subItemDTO = new SubItemDTO { MainItemID = id };

                SubItemFactoryDAL.GetCollectionDAL().Create(subItemDTO);
            }
        }

        public MainItem Get(int id)
        {
            return new MainItem(MainItemFactoryDAL.GetCollectionDAL().Get(id));
        }

        public List<MainItem> GetAll()
        {
            List<MainItem> mainItems = new List<MainItem>();

            foreach (MainItemDTO mainItemDTO in MainItemFactoryDAL.GetCollectionDAL().GetAll())
            {
                mainItems.Add(new MainItem(mainItemDTO));
            }

            return mainItems;
        }

        public void Delete(int id)
        {
            SubItemFactoryDAL.GetCollectionDAL().DeleteAllWithMainItemID(id);
            MainItemFactoryDAL.GetCollectionDAL().Delete(id);
        }
    }
}
