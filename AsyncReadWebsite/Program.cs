using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AsyncReadWebsite
{
    //Process provides the resources that needed for executing a program. 
    //Thread is the entity within process that can be scheduled for execution
    class Program
    {
        //创建计时器
        public static readonly Stopwatch Watch = new Stopwatch();

        private static void Main(string[] args)
        {
            //启动计时器
            Watch.Start();

            const string url1 = "https://github.com/";
            const string url2 = "https://github.com/Shengheng";

            //两次调用 CountCharacters 方法（下载某网站内容，并统计字符的个数）

            //NonAsyncWay nAsy = new NonAsync();
            //var result1 = nAsy.CountCharacters(1, url1);
            //var result2 = nAsy.CountCharacters(2, url2);

            //CountCharacters in Asynchronous way. Executed in the same thread. 

            AsyncWay asy = new AsyncWay();
            var result1 = asy.CountCharactersAsync(1, url1);
            var result2 = asy.CountCharactersAsync(2, url2);

            //三次调用 ExtraOperation 方法（主要是通过拼接字符串达到耗时操作）
            for (var i = 0; i < 3; i++)
            {
               ExtraOperation(i + 1);
            }

            //控制台输出
            Console.WriteLine($"{url1} 的字符个数：{result1.Result},{result1.Id}");
            Console.WriteLine($"{url2} 的字符个数：{result2.Result}");

            Console.Read();
        }
        /// <summary>
        /// 额外操作
        /// </summary>
        /// <param name="id"></param>
        private static void ExtraOperation(int id)
        {
            //这里是通过拼接字符串进行一些相对耗时的操作
            var s = "";

            for (var i = 0; i < 6000; i++)
            {
                s += i;
            }

            Console.WriteLine($"id = {id} 的 ExtraOperation 方法完成：{Program.Watch.ElapsedMilliseconds} ms");
        }


    }
}
