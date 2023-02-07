using Autoglass.Domain.DTO;
using System.Collections.Generic;

namespace Autoglass.Serivce.Service.Interfaces
{
    public interface IProductService
    {
        ProductDto Create(ProductDto dto);
        ProductDto Update(ProductDto dto);
        ProductDto GetById(int id);
        List<ProductDto> GetAll();
        void Delete(int id);
    }
}
