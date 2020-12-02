using Microsoft.AspNetCore.Mvc;
using RLIM.BusinessLogic;
using RLIM.UI.Models;
using System.Collections.Generic;

namespace RLIM.UI.Controllers
{
    public class SubItemController : Controller
    {
        private string GetCertificate(int id)
        {
            Certificate certificate = new CertificateCollection().Get(id);

            return certificate.Name == "None" ? certificate.Name : $"{certificate.Name} ({certificate.Tier})";
        }

        private string GetColor(int id)
        {
            Color color = new ColorCollection().Get(id);

            return color.Name == "Default" ? color.Name : $"{color.Name} ({color.Hex})";
        }

        private List<SubItemModel> GetSubItems(int mainItemID)
        {
            List<SubItemModel> subItemModels = new List<SubItemModel>();

            MainItem mainItem = new MainItemCollection().Get(mainItemID);

            foreach (SubItem subItem in mainItem.GetSubItems())
            {
                subItemModels.Add(new SubItemModel
                {
                    ID = subItem.ID,
                    MainItem = mainItem.Name,
                    Certificate = GetCertificate(subItem.CertificateID),
                    Color = GetColor(subItem.ColorID)
                });
            }

            return subItemModels;
        }

        public IActionResult Index(int id)
        {
            return View(GetSubItems(id));
        }
    }
}
