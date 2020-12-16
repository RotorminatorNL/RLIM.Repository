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
        private readonly string previousName;
        public int CategoryID { get; private set; }
        private readonly int previousCategoryID;
        public int PlatformID { get; private set; }
        private readonly int previousPlatformID;
        public int QualityID { get; private set; }
        private readonly int previousQualityID;

        public MainItem(MainItemDTO mainItemDTO)
        {
            ID = mainItemDTO.ID;

            Name = mainItemDTO.Name;
            previousName = mainItemDTO.Name;

            CategoryID = mainItemDTO.CategoryID;
            previousCategoryID = mainItemDTO.CategoryID;

            PlatformID = mainItemDTO.PlatformID;
            previousPlatformID = mainItemDTO.PlatformID;

            QualityID = mainItemDTO.QualityID;
            previousQualityID = mainItemDTO.QualityID;
        }

        public void SetName(string name)
        {
            Name = name;
        }

        public void SetCategoryID(int id)
        {
            CategoryID = id;
        }

        public void SetPlatformID(int id)
        {
            PlatformID = id;
        }

        public void SetQualityID(int id)
        {
            QualityID = id;
        }

        public IAdmin Update()
        {
            MainItemDTO mainItemDTO = new MainItemDTO
            {
                ID = ID,
                Name = Name,
                CategoryID = CategoryID,
                PlatformID = PlatformID,
                QualityID = QualityID
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
                Name = previousName;
                CategoryID = previousCategoryID;
                PlatformID = previousPlatformID;
                QualityID = previousQualityID;

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
