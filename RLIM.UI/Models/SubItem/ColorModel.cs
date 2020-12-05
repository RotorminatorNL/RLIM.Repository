using System.ComponentModel.DataAnnotations;

namespace RLIM.UI.Models
{
    public class ColorModel
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "You need to give it a Name.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "You need to give it a Hex.")]
        public string Hex { get; set; }

        public string Display { get; set; }
    }
}
