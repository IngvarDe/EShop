using EShop.Core.Domain;
using EShop.Core.Dtos;
using EShop.Core.ServiceResult;

namespace EShop.Core.ServiceInterface
{
    public interface IProductService
    {
        ServiceResult<Product> Save(ProductDto dto);
        ServiceResult<Product> Edit(ProductDto dto);
        ServiceResults Delete(ProductDto dto);
        //ServiceResults ProductGrid();
    }
}
