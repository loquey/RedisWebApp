using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xunit;

namespace RedisMvcApp.Model.Test
{
    public class QuantityTest
    {
        public QuantityTest()
        {
            _Quantity = new();
        }

        [Fact]
        public void NewQuantityCreated_ShouldBeOutOfStock()
        {
            Assert.True(_Quantity.OutOfStock);
        }

        [Fact]
        public void ItemOutOfStock()
        {
            _Quantity = _Quantity + 4;
            _Quantity = _Quantity - 4;

            Assert.True(_Quantity.OutOfStock);
        }

        [Fact]
        public void QuantityDecreasedLessThanZero_ShouldThrowException()
        {
            _Quantity = _Quantity + 4;

            Assert.Throws<InvalidOperationException>(() => _Quantity - 6);
        }

        [Fact]
        public void ItemLowOnStock()
        {
            _Quantity = _Quantity + 4;
            _Quantity = _Quantity - 3;

            Assert.True(_Quantity.LowOnStock(2));
        }

        [Fact]
        public void IncreaseQuantity()
        {
            _Quantity = _Quantity + 4;

            Assert.Equal(4, _Quantity);
        }

        [Fact]
        public void DecreaseQuantity()
        {
            _Quantity = _Quantity + 4;
            _Quantity = _Quantity - 3;

            Assert.Equal(1, _Quantity);
        }

        [Fact]
        public void GetQuantityValue()
        {
            _Quantity = _Quantity + 4;

            Assert.Equal(4, _Quantity);
        }


        [Fact]
        public void IfItemInStock_ShouldPass()
        {
            _Quantity = _Quantity + 4;

            Assert.True(_Quantity.InStock);
        }

        private Quantity _Quantity;
    }
}
