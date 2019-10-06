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
            var data = new ProcessData();

            Func<int, int, int> funcAddDel = (x, y) => x + y;
            Func<int, int, int> funcMultiplyDel = (x, y) => x * y;
            data.ProcessFunc(3, 6, funcMultiplyDel);

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
