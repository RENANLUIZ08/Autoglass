using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Autoglass.Service.Repository.Interfaces
{
    public interface IServiceBase<TDto> where TDto : class
    {
        TDto Create(TDto dto);
        TDto Update(TDto dto);
        TDto GetById(int id);
        List<TDto> GetAll();
    }
}
