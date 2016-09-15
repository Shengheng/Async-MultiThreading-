using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AsyncReadWebsite
{
    public class NonAsyncWay
    {
        /// <summary>
        /// 统计字符个数
        /// </summary>
        /// <param name="id"></param>
        /// <param name="address"></param>
        /// <returns></returns>
        public int CountCharacters(int id, string address)
        {
            var wc = new WebClient();
            Console.WriteLine($"开始调用 id = {id}：{Program.Watch.ElapsedMilliseconds} ms");

            var result = wc.DownloadString(address);
            Console.WriteLine($"调用完成 id = {id}：{Program.Watch.ElapsedMilliseconds} ms");

            return result.Length;
        }


    }
}
