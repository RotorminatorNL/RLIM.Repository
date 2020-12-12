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

        public MessageToUI Update(string previousName, string name)
        {
            Name = name;

            string outputStatus = "Success";
            string outputTitle = "Updated Category!";
            string outputText = $"The name of the choosen Category has been successfully changed in the system.";

            if (CategoryFactoryDAL.GetCollectionDAL().GetID(new CategoryDTO { Name = name }) != ID)
            {
                if (!CategoryFactoryDAL.GetDAL().Update(new CategoryDTO { ID = ID, Name = Name }))
                {
                    outputStatus = "Error";
                    outputTitle = "Sorry!";
                    outputText = $"The name of the choosen Category has not been changed in the system.";
                }
                else
                {
                    string outputPreviousData = $"Previous: '{previousName}'";
                    string outputNewData = $"Now: '{Name}'";

                    return new MessageToUI(outputStatus, outputTitle, outputText, outputPreviousData, outputNewData);
                }
            }
            else
            {
                outputStatus = "Error";
                outputTitle = "Whoops!";
                outputText = $"Category '{name}' already exist in the system.";
            }

            return new MessageToUI(outputStatus, outputTitle, outputText);
        }
    }
}
