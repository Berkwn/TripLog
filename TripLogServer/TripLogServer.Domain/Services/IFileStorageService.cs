using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TripLogServer.Infrastructure.Services
{
    public interface IFileStorageService
    {
        Task<string> SaveFileAsync(IFormFile file, string folder, CancellationToken cancellationToken);

        Task<bool> DeleteFileAsync(string relativePath, CancellationToken cancellationToken);
    }
}
