using RLIM.ContractLayer;
using RLIM.FactoryDAL;
using System.Collections.Generic;

namespace RLIM.BusinessLogic
{
    public class CategoryCollection
    {
        public MessageToUI Create(string name)
        {
            string outputStatus = "Success";
            string outputTitle = "Added Category!";
            string outputText = $"Category '{name}' has been successfully added to the system.";
            object outputData = null;

            CategoryDTO categoryDTO = new CategoryDTO
            {
                Name = name
            };

            if (CategoryFactoryDAL.GetCollectionDAL().GetID(categoryDTO) == 0)
            {
                if (!CategoryFactoryDAL.GetCollectionDAL().Create(categoryDTO))
                {
                    outputStatus = "Error";
                    outputTitle = "Sorry!";
                    outputText = $"Category '{name}' has not been added to the system.";
                    outputData = new Category(categoryDTO);
                }
            }
            else
            {
                outputStatus = "Error";
                outputTitle = "Whoops!";
                outputText = $"Category '{name}' already exist in our system.";
                outputData = new Category(categoryDTO);
            }

            return new MessageToUI(outputStatus, outputTitle, outputText, outputData);
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

        public MessageToUI Delete(int id, string name)
        {
            string outputStatus = "Success";
            string outputTitle = "Removed Category!";
            string outputText = $"Category '{name}' has been successfully removed from the system.";

            if (!CategoryFactoryDAL.GetCollectionDAL().Delete(id))
            {
                outputStatus = "Error";
                outputTitle = "Sorry!";
                outputText = $"Category '{name}' has not been successfully removed from the system.";
            }

            return new MessageToUI(outputStatus, outputTitle, outputText);
        }
    }

}
