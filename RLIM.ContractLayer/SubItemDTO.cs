using System;
using System.Collections.Generic;
using System.Text;

namespace RLIM.ContractLayer
{
    public class SubItemDTO
    {
        public int Id { get; set; }

        public int MainItemId { get; set; }
        public MainItemDTO MainItem { get; set; }

        public int CertificateId { get; set; }
        public CertificateDTO Certificate { get; set; }

        public int ColorId { get; set; }
        public ColorDTO Color { get; set; }
    }
}
