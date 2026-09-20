using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tourism.Application.Features.Authentication.DTOs
{
    public class AuthResponse
    {
        public string Token { get; set; } = "";

        public string Email { get; set; } = "";

        public string FullName { get; set; } = "";
    }
}
