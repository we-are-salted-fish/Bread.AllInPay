using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bread.AllInPay
{
    public class RandomHelper
    {
        private static readonly Random Rnd = new Random();

        //
        // 摘要:
        //     Returns a random number within a specified range.
        //
        // 参数:
        //   minValue:
        //     The inclusive lower bound of the random number returned.
        //
        //   maxValue:
        //     The exclusive upper bound of the random number returned. maxValue must be greater
        //     than or equal to minValue.
        //
        // 返回结果:
        //     A 32-bit signed integer greater than or equal to minValue and less than maxValue;
        //     that is, the range of return values includes minValue but not maxValue. If minValue
        //     equals maxValue, minValue is returned.
        public static int GetRandom(int minValue, int maxValue)
        {
            lock (Rnd)
            {
                return Rnd.Next(minValue, maxValue);
            }
        }

        //
        // 摘要:
        //     Returns a nonnegative random number less than the specified maximum.
        //
        // 参数:
        //   maxValue:
        //     The exclusive upper bound of the random number to be generated. maxValue must
        //     be greater than or equal to zero.
        //
        // 返回结果:
        //     A 32-bit signed integer greater than or equal to zero, and less than maxValue;
        //     that is, the range of return values ordinarily includes zero but not maxValue.
        //     However, if maxValue equals zero, maxValue is returned.
        public static int GetRandom(int maxValue)
        {
            lock (Rnd)
            {
                return Rnd.Next(maxValue);
            }
        }

        //
        // 摘要:
        //     Returns a nonnegative random number.
        //
        // 返回结果:
        //     A 32-bit signed integer greater than or equal to zero and less than System.Int32.MaxValue.
        public static int GetRandom()
        {
            lock (Rnd)
            {
                return Rnd.Next();
            }
        }
    }
}
