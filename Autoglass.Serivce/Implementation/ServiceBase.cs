using Autoglass.Service.Repository.Interfaces;
using AutoMapper;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Autoglass.Service.Implementations
{
    public abstract class ServiceBase
    {
        public readonly IMapper _mapper;

        protected ServiceBase(IMapper mapper)
        {
            _mapper = mapper;
        }

    }
}
