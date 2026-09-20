using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tourism.Application.Interfaces
{
    public interface IFileStorageService
    {
        Task<string> SaveFileAsync(IFormFile file, string subFolder, CancellationToken cancellationToken = default);
        Task<List<string>> SaveFilesAsync(List<IFormFile> files, string subFolder, CancellationToken cancellationToken = default);
        void DeleteFile(string relativePath);
    }
}
