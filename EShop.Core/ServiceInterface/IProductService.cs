using EShop.Core.Domain;
using EShop.Core.Dtos;
using EShop.Core.ServiceResult;
using System;
using System.Threading.Tasks;

namespace EShop.Core.ServiceInterface
{
    public interface IProductService
    {
        Task<Product> GetAsync(Guid id);
        //ServiceResult<Product> Save(ProductDto dto);
        Task<Product> Add(ProductDto dto);
        Task<Product> Update(ProductDto dto);
        ServiceResults Delete(ProductDto dto);
    }
}
