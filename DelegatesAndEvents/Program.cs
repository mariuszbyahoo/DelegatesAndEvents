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
            var customers = new List<Customer>
            {
                new Customer { City = "Złotokłos", FirstName = "Grzesio", LastName = "Złotokłoski", ID = 4 },
                new Customer { City = "Piaseczno", FirstName = "Jan", LastName = "Kowalski", ID = 1},
                new Customer { City = "Złotokłos", FirstName = "Seba", LastName = "Jarząbek", ID = 2 },
                new Customer { City = "Warszawa", FirstName = "Brajan", LastName = "NULL", ID = 3 },

            };

            var zloCustomers = customers.Where(c => c.City == "Złotokłos").OrderBy(c => c.LastName);

            foreach (var customer in zloCustomers)
            {
                Console.WriteLine(customer.LastName) ;
            }

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
                Console.WriteLine("Worked: "+e.Hours + " hours, done : " + e.WorkType);
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
