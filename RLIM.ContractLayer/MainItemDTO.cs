using System;
using System.Collections.Generic;
using System.Text;

namespace RLIM.ContractLayer
{
    public class MainItemDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public int PlatformId { get; set; }
        public int QualityId { get; set; }
    }
}
