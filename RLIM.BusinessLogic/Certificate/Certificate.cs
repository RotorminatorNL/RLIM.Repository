using System;
using System.Collections.Generic;
using System.Text;
using RLIM.FactoryDAL;
using RLIM.ContractLayer;

namespace RLIM.BusinessLogic
{
    public class Certificate
    {
        public int ID { get; private set; }
        public string Name { get; private set; }
        public int Tier { get; private set; }

        public Certificate(CertificateDTO certificateDTO)
        {
            ID = certificateDTO.ID;
            Name = certificateDTO.Name;
            Tier = certificateDTO.Tier;
        }

        public MessageToUI Update(string previousName, string name, int previousTier, int tier)
        {
            Name = name;
            Tier = tier;

            string outputStatus = "Success";
            string outputTitle = "Updated Certificate!";
            string outputText = "The name and/or tier of the choosen Certificate has been successfully changed in the system.";

            if (CertificateFactoryDAL.GetCollectionDAL().GetID(new CertificateDTO { Name = name, Tier = tier }) != ID)
            {
                if (!CertificateFactoryDAL.GetDAL().Update(new CertificateDTO { ID = ID, Name = Name, Tier = Tier }))
                {
                    outputStatus = "Error";
                    outputTitle = "Sorry!";
                    outputText = "The name and/or tier of the choosen Certificate has not been changed in the system.";
                }
                else
                {
                    string outputPreviousData = $"Previous: '{previousName} ({previousTier})'";
                    string outputNewData = $"Now: '{Name} ({Tier})'";

                    return new MessageToUI(outputStatus, outputTitle, outputText, outputPreviousData, outputNewData);
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
    }
}
