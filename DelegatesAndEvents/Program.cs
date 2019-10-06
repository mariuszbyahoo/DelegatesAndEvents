using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesAndEvents
{
    class Program
    {

        static void Main(string[] args)
        {

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
