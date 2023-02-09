using Autoglass.Domain.DTO;
using Autoglass.Domain.Entities;
using Autoglass.Domain.Enum;
using Autoglass.Domain.Repository.Interfaces;
using Autoglass.Service.Implementations;
using Autoglass.Service.Service.Interfaces;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Autoglass.Service.Service.Implementations
{
    public class ProductService : ServiceBase, IProductService
    {
        private readonly IProductRepository _repository;

        public ProductService(
            IProductRepository repository,
            IMapper mapper) : base(mapper)
        {
            _repository = repository;
        }

        public ProductDto Create(ProductDto dto)
        {
            var entity = _mapper.Map<Product>(dto);
            var result = _repository.InsertDb(entity);

            if (!_repository.Commit())
            { throw new OperationCanceledException("Erro ao Cadastrar o produto."); }

            return _mapper.Map<ProductDto>(result);
        }

        public ProductDto Update(ProductDto dto)
        {
            var entity = _repository.GetAll((q) => q.Id == dto.Id)?.FirstOrDefault();
            if(entity == null) 
            { throw new NullReferenceException("Item não localizado para atualização."); }

            _mapper.Map(dto, entity);
            _repository.UpdateDb(entity);

            if (!_repository.Commit())
            { throw new OperationCanceledException("Erro ao Atualizar o produto."); }

            return dto;
        }

        public void Delete(int id)
        {
            var getProduct = _repository.GetAll((q) => q.Id == id)?.FirstOrDefault();
            if (getProduct == null)
            { throw new NullReferenceException("Produto não encontrado para exclusão."); }

            _repository.DeleteDb(getProduct);
            if (!_repository.Commit())
            { throw new OperationCanceledException("Erro ao Deletar o produto."); }
        }

        public ProductDto GetById(int id)
        {
            var getProduct = _repository.GetAll((q) => q.Id == id)?.FirstOrDefault();
            if(getProduct == null) 
            { throw new NullReferenceException("Produto não encontrado."); }

            return _mapper.Map<ProductDto>(getProduct);
        }

        public List<ProductDto> GetAll(bool all)
        {
            var getProducts = 
                !all?
                _repository.GetAll((q) => q.State == EtypeOfProduct.Active):
                _repository.GetAll();

            if (getProducts.Count == 0)
            { throw new NullReferenceException("Nenhum produto foi localizado."); }

            return _mapper.Map<List<ProductDto>>(getProducts);
        }
       
    }
}
