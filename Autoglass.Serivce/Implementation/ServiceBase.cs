using AutoMapper;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Autoglass.Serivce.Implementations
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
