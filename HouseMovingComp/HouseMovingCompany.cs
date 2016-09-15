using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HouseMovingComp
{
    class HouseMovingCompany
    {
        private static HouseMovingCompany _instance = null;
        //list of orders
        public List<Contract> Contracts { get; private set; }

        private HouseMovingCompany()
        {
            this.Contracts = new List<Contract>();
        }

        public static HouseMovingCompany Instance {
            get {
                if(_instance == null)
                {
                    _instance = new HouseMovingCompany();
                }

                return _instance;
            }
        }
        /// <summary>
        /// Go get to work!!! Move house
        /// </summary>
        public void MoveHouse()
        {
            if(this.Contracts ==null || this.Contracts.Count == 0)
            {
                return;
            }

            Contract contract = null;

            lock (this.Contracts)
            {
                contract = this.Contracts[0];
                this.Contracts.RemoveAt(0);
            }
            //contract = this.Contracts[0];
            //this.Contracts.RemoveAt(0);

            if (!String.IsNullOrEmpty(contract.From) && !String.IsNullOrEmpty(contract.To)){
                Console.WriteLine($"Move the House from {contract.From} to {contract.To} ");
               
            }
            Console.WriteLine("Working");
            Thread.Sleep(5000);

        }

    }
}
