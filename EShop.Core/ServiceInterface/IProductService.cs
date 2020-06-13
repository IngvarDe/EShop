using EShop.Core.Domain;
using EShop.Core.Dtos;
using System;
using System.Threading.Tasks;

namespace EShop.Core.ServiceInterface
{
    public interface IProductService : IApplicationService
    {
        Task<Product> GetAsync(Guid id);
        Task<Product> Add(ProductDto dto);
        Task<Product> Update(ProductDto dto);
        Task<Product> Delete(Guid id);
        Task<ExistingFilePath> RemoveImage(ExistingFilePathDto dto);
    }
}
