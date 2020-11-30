using System;
using System.Collections.Generic;
using System.Text;

namespace RLIM.ContractLayer
{
    public class MainItemDTO
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int CategoryID { get; set; }
        public int PlatformID { get; set; }
        public int QualityID { get; set; }
    }
}
