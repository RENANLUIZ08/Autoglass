using Autoglass.Domain.DTO;
using Autoglass.Domain.Entities;
using Autoglass.Domain.Repository.Interfaces;
using Autoglass.Serivce.Implementations;
using Autoglass.Serivce.Service.Interfaces;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;

namespace Autoglass.Serivce.Service.Implementations
{
    public class ProductService : ServiceBase, IProductService
    {
        private readonly IProductRepository _repository;

        public ProductService(
            IProductRepository repository,
            IMapper mapper) : base(mapper)
        {

        }
        
        public ProductDto Create(ProductDto dto)
        {
            var entity = _mapper.Map<Product>(dto);
            _repository.InsertDb(entity);

            if (_repository.Commit())
            {

            }
        }

        public ProductDto Update(ProductDto dto)
        {
            throw new System.NotImplementedException();
        }

        ProductDto IProductService.GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        List<ProductDto> IProductService.GetAll()
        {
            throw new System.NotImplementedException();
        }
        //marcelo - Authentication - fim
    }
}
