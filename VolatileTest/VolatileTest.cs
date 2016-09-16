using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace VolatileTest
{
  public class Worker
    {
        //volatile is used to indicate that this field will be accessed by multiple threads
        //latest value is present in this filed
        private volatile bool _shouldStop;

        public void DoWork()
        {
            while (!_shouldStop)
            {
                Console.WriteLine("Worker thread: working.......");
            }
            Console.WriteLine("Worker bee has died");
        }
        public void RequestStop()
        {
            _shouldStop = true;
        }
    }

    public class WorkerBee
    {
        static void Main()
        {
            Worker workerInstance = new Worker();
            Thread workerThread = new Thread(workerInstance.DoWork);

            workerThread.Start();
            Console.WriteLine("Main thread: starting work thread......");

            while (!workerThread.IsAlive);
            Thread.Sleep(1);

            workerInstance.RequestStop();

            workerThread.Join();
            Console.WriteLine("Main thread: worker thread has terminated");
        }
    }
}
