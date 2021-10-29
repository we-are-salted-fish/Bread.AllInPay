using System;
using System.Threading.Tasks;
using Xunit;

namespace Bread.AllInPay.Tests
{
    public class PayService_Tests
    {
        [Fact]
        public void PrePay()
        {
            var service = new PayService();
            var input = new H5PayInput();
            input.trxamt = 1;
            input.body = $"Wayneͬѧ-��������ѧϰ�ƻ�-����";

            var url = service.PrePay(input).Result;

            Assert.True(!string.IsNullOrEmpty(url));
        }
    }
}
