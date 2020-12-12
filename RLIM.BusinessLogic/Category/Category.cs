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
            string outputText = $"Category name has been successfully changed from '{previousName}' to '{Name}' in the system.";
            
            if (!CategoryFactoryDAL.GetDAL().Update(new CategoryDTO { ID = ID, Name = Name }))
            {
                outputStatus = "Error";
                outputTitle = "Sorry!";
                outputText = $"Category name has not been successfully changed from '{previousName}' to '{Name}' in the system.";
            }

            return new MessageToUI(outputStatus, outputTitle, outputText);
        }
    }
}
