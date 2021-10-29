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
            input.body = $"Wayne同学-订购个人学习计划-开车";

            var url = service.PrePay(input).Result;

            Assert.True(!string.IsNullOrEmpty(url));
        }
    }
}
