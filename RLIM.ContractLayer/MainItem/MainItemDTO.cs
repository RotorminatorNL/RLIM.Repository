using System;
using System.Collections.Generic;
using System.Text;

namespace RLIM.ContractLayer
{
    public class MainItemDTO
    {
        public int ID { get; set; } = 0;
        public string Name { get; set; } = "No Main-Item";
        public int CategoryID { get; set; } = 0;
        public int PlatformID { get; set; } = 0;
        public int QualityID { get; set; } = 0;
    }
}
