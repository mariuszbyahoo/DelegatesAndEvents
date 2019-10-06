using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesAndEvents
{
    public class ProcessData
    {
        public void ProcessFunc(int x, int y, Func<int, int, int> del)
        {
            var result = del(x, y);
            Console.WriteLine("Func<T1, T2, T3> processed: args: "+ 
                x + ", " + y + " = " + result);
        }

        public void ProcessAction(int x, int y, Action<int, int> action)
        {
            Console.WriteLine("Action<T1, T2> processed: args: "+
                x + ", " + y + " = ");
            action(x, y);
        }
    }
}
