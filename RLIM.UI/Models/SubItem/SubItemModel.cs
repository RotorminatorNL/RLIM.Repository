using System.ComponentModel.DataAnnotations;

namespace RLIM.UI.Models
{
    public class SubItemModel
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Without a Main-Item there cannot be a Sub-Item.")]
        public int MainItemID { get; set; }
        public string MainItemDisplay { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "You need to select a Certificate.")]
        public int CertificateID { get; set; }
        [Display(Name = "Certificate")]
        public string CertificateDisplay { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "You need to select a Color.")]
        public int ColorID { get; set; }
        [Display(Name = "Color")]
        public string ColorDisplay { get; set; }
    }
}
