using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tourism.Domain.Entities.Common
{
    public class LocationInfo
    {
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        public LocalizedText? Address { get; set; }
    }
}
