using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bread.AllInPay
{
    public class PayService
    {
        public string _RsaPrivateKey = "UAIEpAIBAAKCAQEAp3R+IS+H4ZF3MDwWTMuS/AZb1uQHbr5ncE/elDwMXTfIPi2J2snnCBoC023D/ICLWLjTLkMj4NNKjgS29tB452fO6Cg7Fdk/YFcWwFBM67HsGDY6EMED0CF3rFjdVBWD4t1ltnIwkGclhYwH5tyoHCCXKlVGNe1c3WpVGC+yHfMysGtIyrQMivxL/i+tl+9UUV8wiFclgondDHJiHfp67YHkg7Od5vgTtEbE/WAt7DgiTvBil28rrIdorv5ih/oIawBX53BAN6TftqS+unVTwFsgZrI+b7Jh6ChFYuH5lklCvj0xmtpmjHLBYh47zWm0zKrSe6LnRhhMyt/4V3/6LwIDAQABAoIBAEYgaW/RXWjQB+eJylb3zALCUPSxwxEUKPJmaFKQwSbKpQ+w93HKKvgAGJ3dcn2MgY6yvDG8CUrugWLvQ4YiMPfLx+D+dBwGwl1Aq3T3S/dKqBJNp0x74HJpiZoCDxJW/kfkKuPYd1EJ+TMvvOFoF/jLhzLBymjsEf9ht+gslT2n/L8r1Ed8z9LqxSgRbj7eLIkg73TpeiUhDWgPsVEjd4ZpAIQcOPvwxElND7r00DKPdidT1du41xfE7F5qeLtO7saC8fvxT5gCi8NHlRM9VFndvom17d87ZvsGKOPzkmdrVJDQb5XQk2SyFclduP5rz4AqdNOxelEuUByKbxFVtWECgYEA4mILaCfBD2D7ST3dM3rYaa81tomPT/PKtVrce4S22RVA+l641GrMUvakmz7dM/KHzEmWPu3xkaYW8HYWVYqvbc4FAulCsNhfkWSAMo9GL6dRnCWdoOu1enZFoceEkHKr+74JGuk6sSoMT45I5SZ7bon3F8TphBL6mAdejeqK+w8CgYEAvVzZp3SdFDvT/GCbP3HvFFDIqjJoy4Un9sr11gZw2cwfcErocrpMr7s1rtzOo+zKvYpSTDj1/WB225OTnu0S6uQ6eGy69grebMW6FErWkfX5UyiwcOZ4dum6t8Wm3K8++cbE1u7Prtfcz87UOtTL2NuNr9iCrmDin1zpPW55juECgYEAy4I+JOTP/mY9n+r4RoYhtGgozi69Ya+UxBGpcXSt91rO7gRm/bYAdnh5I4KQ0lkt0O06HtpCtp9rscFGdKHW8Mwq3yIYrOfmicqiIFGCU+aDS+7Y1Efw/eUC1duJhV1A1G9Suhl+hLN7G62aRD2i6o0mTvzau7tgAXlmfAej5usCgYBuHvD0UPyIJ8K/oe6mlrtSNSh80ZPfxy/WdXFBZb166xndU7KaBX1TNKujZQVGjw3X6/iwGu/yyYZVax0N7xBxSQg3wAN50hhHaTUtV9gwSbsUgTUacuzbOlE7TdYbwE3/M3iFBZwBMcdXkhAZpmZlVkivWlmkzvL7eiypbPWEAQKBgQDMKay+WFgIa+8uPFKLyAa4jDcCL0Aw6BNA5swVVwtZdSLHsL4Ug28lBRto1y3zYBpjfyIZ4VvXkl53Gew33LL1neBGz+xuqG9C14o8PddX0jOv2fqKnXsFaTfUpRdPF+RicyqcsX8H/gvPixVcCOH+SW+JtFqSQ/m+exX8fW3wJQ==";

        /// <summary>
        /// 生成交易单号
        /// </summary>
        /// <returns></returns>
        private string GenerateOutTradeNo()
        {
            var code = RandomHelper.GetRandom(1000, 9999);
            return $"M{DateTime.Now:yyyyMMddHHmmssfff}{code}";
        }

        public async Task<string> PrePay(H5PayInput input)
        {
            var paramDic = new Dictionary<string, string>
            {
                {"cusid", input.cusid},
                {"appid", input.appid},
                {"version", input.version},
                {"randomstr", DateTime.Now.ToFileTime().ToString()}
            };

            if (string.IsNullOrEmpty(input.reqsn))
            {
                input.reqsn = GenerateOutTradeNo();
            }

            paramDic.Add("trxamt", (input.trxamt * 100).ToString("F0"));
            paramDic.Add("reqsn", input.reqsn);
            paramDic.Add("charset", input.charset);
            paramDic.Add("returl", "https://www.baidu.com");
            paramDic.Add("notify_url", "异步通知地址");
            paramDic.Add("body", input.body);
            paramDic.Add("signtype", input.signtype);
            paramDic.Add("sign", Util.SignParam(paramDic, _RsaPrivateKey));
            var url = "https://syb.allinpay.com/apiweb/h5unionpay/unionorder?" + Util.BuildParamStr(paramDic, true);
            return await Task.FromResult(url);
        }
    }
}
