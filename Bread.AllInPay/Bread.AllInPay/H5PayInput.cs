using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bread.AllInPay
{
    public class H5PayInput
    {
        /// <summary>
        /// 商户号
        /// </summary>
        public string cusid { get; set; } = "";

        /// <summary>
        /// 应用ID
        /// </summary>
        public string appid { get; set; } = "";

        /// <summary>
        /// 付款金额(单位分)
        /// </summary>
        public decimal trxamt { get; set; } = 1;

        /// <summary>
        /// 商户唯一订单号订单号码支持数字、英文字母、_、-、*、+、#，其他字符不建议使用
        /// </summary>
        public string reqsn { get; set; }

        public string version { get; set; } = "12";

        public string charset { get; set; } = "UTF-8";
        public string returl { get; set; } = "";
        public string notify_url { get; set; } = "";
        public string body { get; set; } = "";
        public string randomstr { get; set; } = "";

        public string signtype { get; set; } = "RSA";

        public string sign { get; set; }
    }

}
