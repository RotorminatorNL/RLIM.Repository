using System.ComponentModel.DataAnnotations;

namespace RLIM.UserInterface.Models
{
    public class CertificateModel
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "You need to give it a Name.")]
        public string Name { get; set; }

        public string PreviousName { get; set; }

        [Required(ErrorMessage = "You need to give it a Tier.")]
        public int Tier { get; set; }

        public int PreviousTier { get; set; }

        public string Display { get; set; }
    }
}
