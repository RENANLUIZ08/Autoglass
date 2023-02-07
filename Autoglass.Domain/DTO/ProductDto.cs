using Autoglass.Domain.Entities;
using Autoglass.Domain.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autoglass.Domain.DTO
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public EtypeOfProduct State { get; set; }
        public DateTime Manufacturing { get; set; }
        public DateTime Expiration { get; set; }

        [ForeignKey("ProviderId")]
        public virtual Provider ProviderFk { get; set; }

        public int ProviderId { get; set; }
    }
}
