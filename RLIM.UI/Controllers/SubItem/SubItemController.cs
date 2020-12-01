using Microsoft.AspNetCore.Mvc;
using RLIM.BusinessLogic;
using RLIM.UI.Models;
using System.Collections.Generic;

namespace RLIM.UI.Controllers
{
    public class SubItemController : Controller
    {
        private CertificateModel GetCertificate(int id)
        {
            Certificate certificate = new CertificateCollection().Get(id);

            return new CertificateModel
            {
                ID = certificate.ID,
                Name = certificate.Name,
                Tier = certificate.Tier
            };
        }

        private ColorModel GetColor(int id)
        {
            Color color = new ColorCollection().Get(id);

            return new ColorModel
            {
                ID = color.ID,
                Name = color.Name,
                Hex = color.Hex
            };
        }

        private List<SubItemModel> GetSubItems()
        {
            List<SubItemModel> subItemModels = new List<SubItemModel>();

            foreach (SubItem subItem in new SubItemCollection().GetAll())
            {
                subItemModels.Add(new SubItemModel
                {
                    ID = subItem.ID,
                    MainItemID = subItem.MainItemID,
                    Certificate = GetCertificate(subItem.CertificateID),
                    Color = GetColor(subItem.ColorID)
                });
            }

            return subItemModels;
        }

        public IActionResult Index()
        {
            return View(GetSubItems());
        }
    }
}
