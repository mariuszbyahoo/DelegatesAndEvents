using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesAndEvents
{
    // Declaring the Delegate:
    public delegate int WorkPerformedHandler(int hours, WorkType workType);
    public class Worker
    {
        //Below defining a custom EventHandler
        public event WorkPerformedHandler WorkPerformed;
        //Below defining a DotNet's default EventHandler
        public event EventHandler WorkCompleted;

        public void DoWord(int hours, WorkType workType)
        {

        }
    }
}
