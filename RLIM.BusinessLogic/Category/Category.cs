using RLIM.ContractLayer;
using RLIM.FactoryDAL;

namespace RLIM.BusinessLogic
{
    public class Category
    {
        public int ID { get; private set; }
        public string Name { get; private set; }

        public Category(CategoryDTO categoryDTO)
        {
            ID = categoryDTO.ID;
            Name = categoryDTO.Name;
        }

        public void Update(string name)
        {
            Name = name;

            CategoryFactoryDAL.GetDAL().Update(new CategoryDTO
            {
                ID = ID,
                Name = Name
            });
        }
    }
}
