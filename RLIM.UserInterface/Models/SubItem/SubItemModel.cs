using System.ComponentModel.DataAnnotations;

namespace RLIM.UserInterface.Models
{
    public class SubItemModel
    {
        public int ID { get; set; }

        [Display(Name = "Main-Item")]
        public int MainItemID { get; set; }
        [Display(Name = "Main-Item")]
        public string MainItemDisplay { get; set; }

        [Display(Name = "Certificate")]
        public int CertificateID { get; set; }
        [Display(Name = "Certificate")]
        public string CertificateDisplay { get; set; }

        [Display(Name = "Color")]
        public int ColorID { get; set; }
        [Display(Name = "Color")]
        public string ColorDisplay { get; set; }

        public bool InCollection { get; set; } = false;
    }
}
