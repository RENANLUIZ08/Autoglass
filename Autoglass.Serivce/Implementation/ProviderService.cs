using Autoglass.Domain.DTO;
using Autoglass.Domain.Entities;
using Autoglass.Domain.Repository.Interfaces;
using Autoglass.Service.Implementations;
using Autoglass.Service.Service.Interfaces;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Autoglass.Service.Service.Implementations
{
    public class ProviderService : ServiceBase, IProviderService
    {
        private readonly IProviderRepository _repository;

        public ProviderService(
            IProviderRepository repository,
            IMapper mapper) : base(mapper)
        {
            _repository = repository;
        }
        
        public ProviderDto Create(ProviderDto dto)
        {
            dto.Id = null;
            var entity = _mapper.Map<Provider>(dto);
            var result = _repository.InsertDb(entity);

            if (!_repository.Commit())
            { throw new OperationCanceledException("Erro ao Salvar o Cadastro do fornecedor."); }

            return _mapper.Map<ProviderDto>(result);
        }

        public ProviderDto Update(ProviderDto dto)
        {
            var entity = _repository.GetAll((q) => q.Id == dto.Id)?.FirstOrDefault();
            if (entity == null)
            { throw new NullReferenceException("Item não localizado para atualização."); }

            _mapper.Map(dto, entity);
            _repository.UpdateDb(entity);

            if (!_repository.Commit())
            { throw new OperationCanceledException("Erro ao Atualizar o fornecedor."); }

            return dto;
        }

        public ProviderDto GetById(int id)
        {
            var getProvider = _repository.GetAll((q) => q.Id == id)?.FirstOrDefault();
            if(getProvider == null) 
            { throw new NullReferenceException("fornecedor não encontrado."); }

            return _mapper.Map<ProviderDto>(getProvider);
        }

        public List<ProviderDto> GetAll()
        {
            var getProviders = _repository.GetAll();
            if (getProviders.Count == 0)
            { throw new NullReferenceException("Nenhum fornecedor foi localizado."); }

            return _mapper.Map<List<ProviderDto>>(getProviders);
        }
    }
}
