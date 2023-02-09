using Autoglass.Domain.Enum;
using System;
using System.ComponentModel;

namespace Autoglass.Domain.DTO
{
    public class ProductDto
    {
        [DefaultValue(null)]
        public int? Id { get; set; }
        public string Description { get; set; }
        public EtypeOfProduct State { get; set; }
        public DateTime Manufacturing { get; set; }
        public DateTime Expiration { get; set; }
        public int ProviderId { get; set; }

        public ProductDto(int? id, string description, EtypeOfProduct state, DateTime manufacturing, DateTime expiration, int? providerId)
        {
            if(manufacturing >= expiration) 
            { throw new Exception("Não é possivel cadastrar um produto com data de fabricação igual ou superior a data de validade."); }

            if(state == EtypeOfProduct.Inactive)
            { throw new Exception("Não é permitido cadastrar um produto com o status inativo."); }

            if(providerId == 0)
            { throw new Exception("Deve ser informado fornecedor para o produto."); }

            Id = id;
            Description = description;
            State = state;
            Manufacturing = manufacturing;
            Expiration = expiration;
            ProviderId = providerId.Value;
        }
    }
}
