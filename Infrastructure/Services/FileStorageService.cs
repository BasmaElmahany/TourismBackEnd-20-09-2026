using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tourism.Application.Interfaces;

namespace Tourism.Infrastructure.Services
{
    public class FileStorageService : IFileStorageService
    {
        private readonly IWebHostEnvironment _env;

        public FileStorageService(IWebHostEnvironment env)
        {
            _env = env;
        }

        public async Task<string> SaveFileAsync(IFormFile file, string subFolder, CancellationToken cancellationToken = default)
        {
            if (file == null || file.Length == 0)
                return string.Empty;

            // تحديد مسار المجلد داخل wwwroot/assets/images/subFolder
            var webRoot = _env.WebRootPath ?? Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
            var folderPath = Path.Combine(webRoot, "assets", "images", subFolder);

            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            // توليد اسم فريد للملف لمنع التكرار
            var fileName = $"{Guid.NewGuid()}_{Path.GetFileName(file.FileName)}";
            var fullPath = Path.Combine(folderPath, fileName);

            using (var stream = new FileStream(fullPath, FileMode.Create))
            {
                await file.CopyToAsync(stream, cancellationToken);
            }

            // إرجاع المسار النسبي المطلوب للفرونت إند
            return $"/assets/images/{subFolder}/{fileName}";
        }

        public async Task<List<string>> SaveFilesAsync(List<IFormFile> files, string subFolder, CancellationToken cancellationToken = default)
        {
            var paths = new List<string>();
            if (files == null || files.Count == 0) return paths;

            foreach (var file in files)
            {
                var path = await SaveFileAsync(file, subFolder, cancellationToken);
                if (!string.IsNullOrEmpty(path))
                    paths.Add(path);
            }

            return paths;
        }

        public void DeleteFile(string relativePath)
        {
            if (string.IsNullOrWhiteSpace(relativePath)) return;

            var webRoot = _env.WebRootPath ?? Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
            var fullPath = Path.Combine(webRoot, relativePath.TrimStart('/').Replace('/', Path.DirectorySeparatorChar));

            if (File.Exists(fullPath))
            {
                File.Delete(fullPath);
            }
        }
    }
}