using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Bread.AllInPay
{
    public class Util
    {
        /// <summary>
        /// 将参数排序组装
        /// </summary>
        /// <param name="param"></param>
        /// <param name="isEncodeParam">是否编码参数</param>
        /// <returns></returns>
        public static string BuildParamStr(Dictionary<string, string> param, bool isEncodeParam = false)
        {
            if (param == null || param.Count == 0)
            {
                return "";
            }
            var ascDic = param.OrderBy(o => o.Key).ToDictionary(o => o.Key, p => p.Value);
            var sb = new StringBuilder();
            foreach (var item in ascDic)
            {
                if (!string.IsNullOrEmpty(item.Value))
                {
                    sb.Append(item.Key).Append("=").Append(isEncodeParam? WebUtility.UrlEncode(item.Value): item.Value).Append("&");
                }
            }
            return sb.ToString().Substring(0, sb.ToString().Length - 1);
        }

        public static string SignParam(Dictionary<string, string> param, string privateKey)
        {
            if (param == null || param.Count == 0)
            {
                return "";
            }
            param.Add("key", privateKey);
            var blankStr = BuildParamStr(param);
            return SHA1WithRSAUtil.Encrypt(privateKey, blankStr);
        }
    }
}
