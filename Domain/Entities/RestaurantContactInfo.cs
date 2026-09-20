using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tourism.Domain.Entities.Common;

namespace Tourism.Domain.Entities
{
    public class RestaurantContactInfo
    {
        public LocalizedText Phone { get; set; } = new();
        public string? Email { get; set; }
    }
}
