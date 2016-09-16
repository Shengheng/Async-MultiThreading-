using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Await_Task_Run
{
    class Program
    {
        static void Main(string[] args)
        {
            var t = Do.GetGuidAsync();
            t.Wait();

            Console.Read();
        }
    }

    class Do
    {
        /// <summary>
        /// Get Guid
        /// </summary>
        /// <returns></returns>
        private static Guid GetGuid()
        {
            return Guid.NewGuid();
        }
        public static async Task GetGuidAsync()
        {
            var myFunc = new Func<Guid>(GetGuid);

            var t1 = await Task.Run(myFunc);

            var t2 = await Task.Run(() => GetGuid());

            var t3 = await Task.Run(new Func<Guid>(GetGuid));

            var t4 = await Task.Run(() => Guid.NewGuid());

            Console.WriteLine($"t1: {t1}");
            Console.WriteLine($"t2: {t2}");
            Console.WriteLine($"t3: {t3}");
            Console.WriteLine($"t4: {t4}");
        }
    }
}
