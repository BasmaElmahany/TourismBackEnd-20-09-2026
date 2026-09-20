using DTourism.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tourism.Application.Interfaces
{
    public interface IJwtTokenGenerator
    {
        Task<string> GenerateToken(ApplicationUser user);

    }
}
