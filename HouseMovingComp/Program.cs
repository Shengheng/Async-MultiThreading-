using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HouseMovingComp
{
    class Program
    {
        static void Main(string[] args)
        {
            HouseMovingCompany workBee = HouseMovingCompany.Instance;
            workBee.Contracts.Add(new Contract { From = "DongGuan", To = "DongYing", Fee = 1000 });
            workBee.Contracts.Add(new Contract { From = "XiangShan", To = "The Forbidden City", Fee = 10000 });
            workBee.Contracts.Add(new Contract { From = "XiDan", To = "WangFujing", Fee = 1000 });

            Thread thread = null;

            while(workBee.Contracts.Count > 0)
            {
                thread = new Thread(new ThreadStart(workBee.MoveHouse));
                thread.Start();
            }
        }
    }
}
