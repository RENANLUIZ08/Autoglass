using Autoglass.Domain.DTO;
using Autoglass.Service.Repository.Interfaces;
using System.Collections.Generic;

namespace Autoglass.Service.Service.Interfaces
{
    public interface IProductService : IServiceBase<ProductDto>
    {
        void Delete(int id);
        List<ProductDto> GetAll(bool all);
    }
}
