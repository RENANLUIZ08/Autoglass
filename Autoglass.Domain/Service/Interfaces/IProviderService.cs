using Autoglass.Domain.DTO;
using System.Collections.Generic;

namespace Autoglass.Serivce.Service.Interfaces
{
    public interface IProviderService
    {
        ProviderDto Create(ProviderDto dto);
        ProviderDto Update(ProviderDto dto);
        ProviderDto GetById(int id);
        List<ProviderDto> GetAll();
    }
}
