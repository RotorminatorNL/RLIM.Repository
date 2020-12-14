using RLIM.BusinessLogic.MessageToUI;
using RLIM.ContractLayer;
using RLIM.FactoryDAL;
using System.Collections.Generic;

namespace RLIM.BusinessLogic
{
    public class MainItem
    {
        public int ID { get; private set; }
        public string Name { get; private set; }
        public int CategoryID { get; private set; }
        public int PlatformID { get; private set; }
        public int QualityID { get; private set; }

        public MainItem(MainItemDTO mainItemDTO)
        {
            ID = mainItemDTO.ID;
            Name = mainItemDTO.Name;
            CategoryID = mainItemDTO.CategoryID;
            PlatformID = mainItemDTO.PlatformID;
            QualityID = mainItemDTO.QualityID;
        }

        public IAdmin Update(string name, int categoryID, int platformID, int qualityID)
        {
            MainItemDTO mainItemDTO = new MainItemDTO
            {
                ID = ID,
                Name = name,
                CategoryID = categoryID,
                PlatformID = platformID,
                QualityID = qualityID
            };

            if (MainItemFactoryDAL.GetCollectionDAL().GetID(mainItemDTO) == 0)
            {
                if (!MainItemFactoryDAL.GetDAL().Update(mainItemDTO))
                {
                    return new Error("Main-Item", "Update");
                }
            }
            else
            {
                return new AlreadyExisting("Main-Item");
            }

            return new Success("Main-Item","Update");
        }

        public List<SubItem> GetSubItems()
        {
            List<SubItem> subItems = new List<SubItem>();

            foreach (SubItemDTO subItemDTO in SubItemFactoryDAL.GetCollectionDAL().GetAllWithMainItemID(ID))
            {
                subItems.Add(new SubItem(subItemDTO));
            }

            return subItems;
        }
    }
}
