using Autoglass.Domain.Entities;
using Autoglass.Service.Repository.Interfaces;

namespace Autoglass.Domain.Repository.Interfaces
{
    public interface IProductRepository : IRepositoryBase<Product>
    {
        void DeleteDb(Product product);
    }
}
