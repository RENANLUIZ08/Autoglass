using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autoglass.Domain.DTO
{
    public class ProviderDto
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string CNPJ { get; set; }
    }
}
