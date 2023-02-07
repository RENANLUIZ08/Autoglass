using Autoglass.Domain.Entities;
using Autoglass.Domain.Enum;
using Autoglass.Domain.Repository.Interfaces;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Autoglass.Repository.Implementations
{
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(MyDbContext contexto) : base(contexto)
        {

        }

        public void DeleteDb(Product product)
        {
            product.State = EtypeOfProduct.Inactive;
        }
    }
}
