using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesAndEvents
{
    class Program
    {
        // Declaring the Delegate:
        public delegate void WorkPerformedHandler(int hours, WorkType workType);
        static void Main(string[] args)
        {
            // Creating the delegates, notice that they've got :
            WorkPerformedHandler del1 = new WorkPerformedHandler(WorkPerformed1);
            WorkPerformedHandler del2 = new WorkPerformedHandler(WorkPerformed2);
            WorkPerformedHandler del3 = new WorkPerformedHandler(WorkPerformed3);

            del1 += del2 + del3; // Concatinating of the delegates.

            del1(100, WorkType.Golf); // Invocation of delegates, they've passed same arguments.

        }

        // Method gets the delegate object as an argument and performs an action on it:
        static void DoWork(WorkPerformedHandler del)
        {
            del(5, WorkType.GoToMeetings);
        }

        // Several eventHandlers performs some work:
        static void WorkPerformed1(int hrs, WorkType wrkType)
        {
            Console.WriteLine("WorkPerformed1 called " + hrs.ToString());
        }

        static void WorkPerformed2(int hrs, WorkType workType)
        {
            Console.WriteLine("WorkPerformed2 called " + workType.ToString());
        }

        static void WorkPerformed3(int hrs, WorkType workType)
        {
            Console.WriteLine("WorkPerformed3 called " + workType.ToString() + 
                " I'll take you: " + hrs.ToString());
        }
    }

    public enum WorkType
    {
        GoToMeetings,
        Golf,
        GenerateReports
    }
}
