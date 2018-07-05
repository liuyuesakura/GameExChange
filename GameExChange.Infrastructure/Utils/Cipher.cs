using System;
using System.Text;
using System.Threading;

namespace GameExChange.Infrastructure.Utils
{
    /// <summary>
    /// 编号生成
    /// </summary>
    public static  class Cipher
    {
        private static long _n1, _n2, _n3;
        private static readonly object _lock = new object();
        public static string Number;

        public static string CreateNumber()
        {
            DateTime now = DateTime.Now;
            TimeSpan span = now - DateTime.MinValue;
            long tempDay = span.Days;
            long seconds = span.Hours * 3600 + span.Seconds;
            StringBuilder sb = new StringBuilder();
            Monitor.Enter(_lock);
            if(tempDay != _n1)
            {
                _n1 = tempDay;
                _n2 = 0;
                _n3 = 1;
            }
            if(_n2 != seconds)
            {
                _n2 = seconds;
                _n3 = 1;
            }
            sb.Append(Convert.ToString(_n1, 16).PadLeft(5, '0') + Convert.ToString(_n2, 16).PadLeft(5, '0') + Convert.ToString(_n3++, 16).PadLeft(6, '0'));
            Monitor.Exit(_lock);
            return sb.ToString();
        }
    }
}
