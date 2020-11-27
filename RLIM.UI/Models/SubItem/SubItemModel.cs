using System.ComponentModel.DataAnnotations;

namespace RLIM.UI.Models
{
    public class SubItemModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "You need to select the Main-Item.")]
        public int MainItemId { get; set; }
        public MainItemModel mainItem { get; set; }

        [Required(ErrorMessage = "No Certificate? Please select 'None'.")]
        public int CertificateId { get; set; }
        public CertificateModel certificate { get; set; }

        [Required(ErrorMessage = "No Color? Please select 'Default'.")]
        public int ColorId { get; set; }
        public ColorModel color { get; set; }
    }
}
