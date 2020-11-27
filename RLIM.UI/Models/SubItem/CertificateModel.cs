using System.ComponentModel.DataAnnotations;

namespace RLIM.UI.Models
{
    public class CertificateModel
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "You need to give it a Name.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "You need to give it a Tier.")]
        public int Tier { get; set; }
    }
}
