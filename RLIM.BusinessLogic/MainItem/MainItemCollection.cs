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

            MainItemFactoryDAL.GetCollectionDAL().Create(mainItemDTO);
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
            foreach (SubItem subItem in Get(id).GetSubItems())
            {
                SubItemFactoryDAL.GetCollectionDAL().Delete(subItem.ID);
            }

            MainItemFactoryDAL.GetCollectionDAL().Delete(id);
        }
    }
}
