using Autoglass.Domain.DTO;
using Autoglass.Service.Repository.Interfaces;

namespace Autoglass.Service.Service.Interfaces
{
    public interface IProductService : IServiceBase<ProductDto>
    {
        void Delete(int id);
    }
}
