using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tourism.Domain.Entities
{
    public class SouvenirCategory
    {
        [Key]
        public string Key { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string NameAr { get; set; } = string.Empty;
        public string Icon { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string DescriptionAr { get; set; } = string.Empty;
    }
}
