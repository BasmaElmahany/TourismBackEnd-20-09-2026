using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tourism.Domain.Entities
{
    public class ServiceOpeningHours
    {
        public Dictionary<string, string> En { get; set; } = new();
        public Dictionary<string, string> Ar { get; set; } = new();
    }
}
