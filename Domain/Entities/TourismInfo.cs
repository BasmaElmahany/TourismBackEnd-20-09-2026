using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tourism.Domain.Entities.Common;

namespace Tourism.Domain.Entities
{
    public class TourismInfo
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        public LocalizedText Title { get; set; } = new();
        public LocalizedText Climate { get; set; } = new();
        public LocalizedText BestTimeToVisit { get; set; } = new();
        public LocalizedText WhatToWear { get; set; } = new();
        public LocalizedText? Notes { get; set; }
        public string? LastUpdated { get; set; }
    }
}
