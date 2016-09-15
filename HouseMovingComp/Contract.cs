using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseMovingComp
{
    /// <summary>
    /// Order contract detail
    /// </summary>
    class Contract
    {
        public String ID { get; private set; }
        public String From { get; set; }
        public String To { get; set; }
        public Decimal Fee { get; set; }

        public Contract()
        {
            this.ID = Guid.NewGuid().ToString();
        }
    }
}
