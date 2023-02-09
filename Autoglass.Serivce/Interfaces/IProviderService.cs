using Autoglass.Domain.DTO;
using Autoglass.Service.Repository.Interfaces;
using System.Collections.Generic;

namespace Autoglass.Service.Service.Interfaces
{
    public interface IProviderService : IServiceBase<ProviderDto>
    {
        List<ProviderDto> GetAll();
    }
}
