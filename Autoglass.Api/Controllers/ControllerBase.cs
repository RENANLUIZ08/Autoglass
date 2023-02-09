using Autoglass.Domain.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Autoglass.Api.Controllers
{
    public abstract class ControllerBase<TEntity> : Controller where TEntity : class
    {        
        public abstract IActionResult Get(int id);
        public abstract IActionResult Create([FromBody]TEntity entity);
        public abstract IActionResult Update([FromBody] TEntity entity);
    }
}
