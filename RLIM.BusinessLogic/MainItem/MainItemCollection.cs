using RLIM.BusinessLogic.MessageToUI;
using RLIM.ContractLayer;
using RLIM.FactoryDAL;
using System.Collections.Generic;

namespace RLIM.BusinessLogic
{
    public class MainItemCollection
    {
        public IAdmin Create(string name, int categoryID, int platformID, int qualityID)
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

                if (id != 0)
                {
                    SubItemDTO subItemDTO = new SubItemDTO { MainItemID = id };

                    SubItemFactoryDAL.GetCollectionDAL().Create(subItemDTO);
                }
                else
                {
                    return new Error("Main-Item", "Create");
                }
            }
            else
            {
                return new AlreadyExisting("Main-Item");
            }

            return new Success("Main-Item", "Create");
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

        public IAdmin Delete(int id)
        {
            if(!SubItemFactoryDAL.GetCollectionDAL().DeleteAllWithMainItemID(id) || !MainItemFactoryDAL.GetCollectionDAL().Delete(id))
            {
                return new Error("Main-Item", "Delete");
            }

            return new Success("Main-Item", "Delete");
        }
    }
}
