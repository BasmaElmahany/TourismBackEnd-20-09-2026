using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tourism.Application.Features.DTOs
{
    public class TourismEventFormRequest
    {
        [FromForm(Name = "eventDataJson")]
        public string EventDataJson { get; set; } = string.Empty;

        [FromForm(Name = "image")]
        public IFormFile? Image { get; set; }
    }
}
