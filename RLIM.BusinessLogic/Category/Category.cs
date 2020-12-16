using RLIM.BusinessLogic.MessageToUI;
using RLIM.ContractLayer;
using RLIM.FactoryDAL;

namespace RLIM.BusinessLogic
{
    public class Category
    {
        public int ID { get; private set; }
        public string Name { get; private set; }
        private readonly string previousName;

        public Category(CategoryDTO categoryDTO)
        {
            ID = categoryDTO.ID;
            Name = categoryDTO.Name;
            previousName = categoryDTO.Name;
        }

        public void SetName(string name)
        {
            Name = name;
        }

        public IAdmin Update()
        {
            CategoryDTO categoryDTO = new CategoryDTO
            {
                ID = ID,
                Name = Name
            };

            if (CategoryFactoryDAL.GetCollectionDAL().GetID(categoryDTO) == 0)
            {
                if (!CategoryFactoryDAL.GetDAL().Update(categoryDTO))
                {
                    return new Error("Category", "Update");
                }
            }
            else
            {
                Name = previousName;
                return new AlreadyExisting("Category");
            }

            return new Success("Category", "Update");
        }
    }
}
