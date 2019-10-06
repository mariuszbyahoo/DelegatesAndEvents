using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesAndEvents
{
    public delegate int BizRulesDelegate(int x, int y);

    class Program
    {

        static void Main(string[] args)
        {
            BizRulesDelegate addDel = (x, y) => x + y;
            BizRulesDelegate multiplyDel = (x, y) => x * y;

            var data = new ProcessData();
            data.Process(2, 9, multiplyDel);

            Action<int, int> myAction = (x, y) => Console.WriteLine(x + y);
            Action<int, int> myMultiplyAction = (x, y) => Console.WriteLine(x * y);
            data.ProcessAction(2, 3, myAction);
            data.ProcessAction(2, 3, myMultiplyAction);


            var worker = new Worker();

            worker.WorkPerformed += (s, e) =>
            {
                Console.WriteLine(e.Hours + " " + e.WorkType);
                return e.Hours;
            };

            // Anonymous method below:
            worker.WorkCompleted += (s, e) => Console.WriteLine("Worker is done.");

            worker.DoWork(8, WorkType.GenerateReports);

            Console.Read();
        }
    }
    public enum WorkType
    {
        GoToMeetings,
        Golf,
        GenerateReports
    }
}
