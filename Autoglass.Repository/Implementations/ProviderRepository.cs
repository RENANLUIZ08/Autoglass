using Autoglass.Domain.Entities;
using Autoglass.Domain.Enum;
using Autoglass.Domain.Repository.Interfaces;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Autoglass.Repository.Implementations
{
    public class ProviderRepository : RepositoryBase<Provider>, IProviderRepository
    {
        public ProviderRepository(MyDbContext contexto) : base(contexto)
        {

        }
    }
}
