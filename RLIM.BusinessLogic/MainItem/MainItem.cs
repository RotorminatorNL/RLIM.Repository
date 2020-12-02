using RLIM.ContractLayer;
using RLIM.FactoryDAL;

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

        public void Update(string name, int categoryID, int platformID, int qualityID)
        {
            Name = name;
            CategoryID = categoryID;
            PlatformID = platformID;
            QualityID = qualityID;

            MainItemFactoryDAL.GetDAL().Update(new MainItemDTO 
            { 
                ID = ID,
                Name = Name,
                CategoryID = CategoryID,
                PlatformID = PlatformID,
                QualityID = QualityID
            });
        }
    }
}
