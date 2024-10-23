using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TripLogServer.Infrastructure.Services
{
    public class FileStorageService : IFileStorageService
    {
        private readonly string _baseDirectory = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images");

        public async Task<string> SaveFileAsync(IFormFile file, string folder, CancellationToken cancellationToken)
        {
            if (file == null || file.Length == 0)
                throw new ArgumentException("Invalid file.");

            var directoryPath = Path.Combine(_baseDirectory, folder);
            if (!Directory.Exists(directoryPath))
                Directory.CreateDirectory(directoryPath);

            var fileName = $"{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";
            var filePath = Path.Combine(directoryPath, fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream, cancellationToken);
            }

            return Path.Combine("images", folder, fileName).Replace("\\", "/");
        }
    }
}
