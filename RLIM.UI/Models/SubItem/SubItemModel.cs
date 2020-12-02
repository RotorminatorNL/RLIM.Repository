using System.ComponentModel.DataAnnotations;

namespace RLIM.UI.Models
{
    public class SubItemModel
    {
        public int ID { get; set; }
        public string MainItem { get; set; }
        public string Certificate { get; set; }
        public string Color { get; set; }
    }
}
