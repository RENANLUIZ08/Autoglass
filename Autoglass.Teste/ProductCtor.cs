using Autoglass.Domain.DTO;
using Autoglass.Domain.Enum;
using System;
using Xunit;

namespace Autoglass.Teste
{
    public class ProductCtor
    {
        [Fact]
        public void ThrowsExceptionGivenProductWithoutProvider()
        {
            //arranje
            int idProvider = 0;

            //assert
            Assert.Throws<Exception>(
                () => 
                    new ProductDto(
                        0,
                        "produto exemplo",
                        EtypeOfProduct.Active,
                        DateTime.Now,
                        DateTime.Now.AddMonths(1),
                        idProvider)
                );
        }

        [Fact]
        public void ThrowsExceptionGivenProductWithExpirationDateLessThanOrEqualToManufacture()
        {
            //arranje
            DateTime manufacture;
            DateTime expired;

            manufacture = expired = DateTime.Now;

            //assert
            Assert.Throws<Exception>(
                () =>
                    new ProductDto(
                        null,
                        "produto exemplo",
                        EtypeOfProduct.Active,
                        manufacture,
                        expired,
                        1)
                );
        }

        [Fact]
        public void ThrowsExceptionGivenProductWithInactiveStatus()
        {
            //arranje
            EtypeOfProduct state = EtypeOfProduct.Inactive;

            //assert
            Assert.Throws<Exception>(
                () =>
                    new ProductDto(
                        null,
                        "produto exemplo",
                        state,
                        DateTime.Now,
                        DateTime.Now.AddMonths(1),
                        1)
                );
        }
    }
}
