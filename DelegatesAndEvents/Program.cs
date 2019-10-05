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
            // Creating the delegates, notice that they've got :
            WorkPerformedHandler del1 = new WorkPerformedHandler(WorkPerformed1);
            WorkPerformedHandler del2 = new WorkPerformedHandler(WorkPerformed2);
            WorkPerformedHandler del3 = new WorkPerformedHandler(WorkPerformed3);

            del1 += del2 + del3; // Concatinating of the delegates.
            Console.WriteLine("Concatination completed");

            /* When we're returning some value through the combinated several delegates, 
             * then we will finally get the value from the last one, in this case: 3.
             * If we would call all three of them separately, then we would get 6 
             * (1 + 2 + 3) */
            int del2Hrs = del2(0, WorkType.Golf);
            int del3Hrs = del3(0, WorkType.Golf);
            int finalHours = del1(1, WorkType.Golf); // Invocation of concatinated three delegates, they've passed same arguments.
            Console.WriteLine("Invocation completed, printing the returned values: ");
            Console.WriteLine(del3Hrs);
            Console.WriteLine(del2Hrs);
            Console.WriteLine(finalHours);
        }

        // Method gets the delegate object as an argument and performs an action on it:
        static void DoWork(WorkPerformedHandler del)
        {
            del(5, WorkType.GoToMeetings);
        }

        // Several eventHandlers performs some work, they're returning somethind:
        static int WorkPerformed1(int hrs, WorkType wrkType)
        {
            Console.WriteLine("WorkPerformed1 called " + hrs.ToString());
            return hrs + 1;
        }

        static int WorkPerformed2(int hrs, WorkType workType)
        {
            Console.WriteLine("WorkPerformed2 called " + workType.ToString());
            return hrs + 2;
        }

        static int WorkPerformed3(int hrs, WorkType workType)
        {
            Console.WriteLine("WorkPerformed3 called " + workType.ToString() + 
                " It'll take you: " + hrs.ToString());
            return hrs + 3;
        }
    }

    public enum WorkType
    {
        GoToMeetings,
        Golf,
        GenerateReports
    }
}
