using Autoglass.Domain.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autoglass.Domain.Entities
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Description { get; set; }
        public EtypeOfProduct State { get; set; }
        public DateTime Manufacturing { get; set; }
        public DateTime Expiration { get; set; }

        [ForeignKey("ProviderId")]
        public virtual Provider ProviderFk { get; set; }
        public int ProviderId { get; set; }

    }
}
