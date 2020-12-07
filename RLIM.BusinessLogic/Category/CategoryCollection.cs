using RLIM.ContractLayer;
using RLIM.FactoryDAL;
using System.Collections.Generic;

namespace RLIM.BusinessLogic
{
    public class CategoryCollection
    {
        public void Create(string name)
        {
            CategoryDTO categoryDTO = new CategoryDTO
            {
                Name = name
            };

            if (CategoryFactoryDAL.GetCollectionDAL().GetID(categoryDTO) == 0)
            {
                CategoryFactoryDAL.GetCollectionDAL().Create(categoryDTO);
            }
        }

        public Category Get(int id)
        {
            return new Category(CategoryFactoryDAL.GetCollectionDAL().Get(id));
        }

        public List<Category> GetAll()
        {
            List<Category> categories = new List<Category>();

            foreach (CategoryDTO categoryDTO in CategoryFactoryDAL.GetCollectionDAL().GetAll())
            {
                categories.Add(new Category(categoryDTO));
            }

            return categories;
        }

        public void Delete(int id)
        {
            CategoryFactoryDAL.GetCollectionDAL().Delete(id);
        }
    }

}
