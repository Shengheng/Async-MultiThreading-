using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AsyncReadWebsite
{
    class AsyncWay
    {
        public async Task<int> CountCharactersAsync(int id, string address)
        {
            var wc = new WebClient();
            Console.WriteLine("Start to execute id = {0} : {1} ms", id, Program.Watch.ElapsedMilliseconds);

            var result = await wc.DownloadStringTaskAsync(address);
            Console.WriteLine("End to execute id = {0} : {1} ms", id, Program.Watch.ElapsedMilliseconds);

            //Console.WriteLine("Start to execute id = {0} : {1} ms", id+10, Program.Watch.ElapsedMilliseconds);

            //var result1 = await wc.DownloadStringTaskAsync(address);
            //Console.WriteLine("End to execute id = {0} : {1} ms", id+10, Program.Watch.ElapsedMilliseconds);

            return result.Length;
        }
    }
}
