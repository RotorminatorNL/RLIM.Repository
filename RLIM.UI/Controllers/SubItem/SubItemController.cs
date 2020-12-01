using Microsoft.AspNetCore.Mvc;
using RLIM.BusinessLogic;
using RLIM.UI.Models;
using System.Collections.Generic;

namespace RLIM.UI.Controllers
{
    public class SubItemController : Controller
    {
        public IActionResult Index()
        {
            return View(GetSubItems());
        }

        private List<SubItemModel> GetSubItems()
        {
            List<SubItemModel> subItemModels = new List<SubItemModel>();

            foreach (SubItem subItem in new SubItemCollection().GetAll())
            {
                CertificateModel certificateModel = new CertificateModel
                {
                    ID = subItem.CertifcateDTO.ID,
                    Name = subItem.CertifcateDTO.Name,
                    Tier = subItem.CertifcateDTO.Tier
                };

                ColorModel colorModel = new ColorModel
                {
                    ID = subItem.ColorDTO.ID,
                    Name = subItem.ColorDTO.Name,
                    Hex = subItem.ColorDTO.Hex
                };

                subItemModels.Add(new SubItemModel
                {
                    ID = subItem.ID,
                    MainItemID = subItem.MainItemID,
                    Certificate = certificateModel,
                    Color = colorModel
                });
            }

            return subItemModels;
        }
    }
}
