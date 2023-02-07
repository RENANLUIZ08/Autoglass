using Autoglass.Domain.Entities;
using Autoglass.Domain.Repository.Interfaces;

namespace Autoglass.Domain.Repository.Interfaces
{
    public interface IProductRepository : IRepositoryBase<Product>
    {
        void DeleteDb(Product product);
    }
}
