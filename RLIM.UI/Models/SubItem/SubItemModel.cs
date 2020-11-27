using System.ComponentModel.DataAnnotations;

namespace RLIM.UI.Models
{
    public class SubItemModel
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "You need to select the Main-Item.")]
        public int MainItemID { get; set; }

        [Required(ErrorMessage = "No Certificate? Please select 'None'.")]
        public CertificateModel Certificate { get; set; }

        [Required(ErrorMessage = "No Color? Please select 'Default'.")]
        public ColorModel Color { get; set; }
    }
}
