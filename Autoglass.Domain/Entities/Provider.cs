using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autoglass.Domain.Entities
{
    public class Provider
    {
        [Key]
        public int Id { get; set; }
        public string Description { get; set; }
        public string CNPJ { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
