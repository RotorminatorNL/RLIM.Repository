using RLIM.ContractLayer;
using RLIM.FactoryDAL;
using System.Collections.Generic;

namespace RLIM.BusinessLogic
{
    public class CertificateCollection
    {
        public MessageToUI Create(string name, int tier)
        {
            string outputStatus = "Success";
            string outputTitle = "Added Certificate!";
            string outputText = $"Certificate '{name} ({tier})' has been successfully added to the system.";

            CertificateDTO certificateDTO = new CertificateDTO
            {
                Name = name,
                Tier = tier
            };

            if (CertificateFactoryDAL.GetCollectionDAL().GetID(certificateDTO) == 0)
            {
                if (!CertificateFactoryDAL.GetCollectionDAL().Create(certificateDTO))
                {
                    outputStatus = "Error";
                    outputTitle = "Sorry!";
                    outputText = $"Certificate '{name} ({tier})' has not been added to the system.";
                }
            }
            else
            {
                outputStatus = "Error";
                outputTitle = "Whoops!";
                outputText = $"Certificate '{name} ({tier})' already exist in the system.";
            }

            return new MessageToUI(outputStatus, outputTitle, outputText);
        }

        public Certificate Get(int id)
        {
            return new Certificate(CertificateFactoryDAL.GetCollectionDAL().Get(id));
        }

        public List<Certificate> GetAll()
        {
            List<Certificate> certificates = new List<Certificate>();

            foreach (CertificateDTO certificateDTO in CertificateFactoryDAL.GetCollectionDAL().GetAll())
            {
                certificates.Add(new Certificate(certificateDTO));
            }

            return certificates;
        }

        public MessageToUI Delete(int id, string name, int tier)
        {
            string outputStatus = "Success";
            string outputTitle = "Removed Certificate!";
            string outputText = $"Certificate '{name} ({tier})' has been successfully removed from the system.";

            if (!CertificateFactoryDAL.GetCollectionDAL().Delete(id))
            {
                outputStatus = "Error";
                outputTitle = "Sorry!";
                outputText = $"Certificate '{name} ({tier})' has not been removed from the system.";
            }

            return new MessageToUI(outputStatus, outputTitle, outputText);
        }
    }
}
