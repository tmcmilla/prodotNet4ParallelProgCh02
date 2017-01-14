using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Listing_03
{
  class Program
  {
    static void Main(string[] args)
    {
      // Use an Action delegate and named method
      Task task1 = new Task(new Action<object>(printMessage),
        "First task");

      // Use an anonymous delegate
      Task task2 = new Task(delegate (object obj)
      {
        printMessage(obj);

      }, "Second Task");

      // Use a lambda expression and a named method
      // note that parameters to a lambda don't need 
      // to be quoted if there is only on parameter
      Task task3 = new Task((obj) => printMessage(obj), "Third task");

      // use a lambda expression and an anonymous method
      Task task4 = new Task((obj) =>
      {
        printMessage(obj);
      }, "Fourth task");

      task1.Start();
      task2.Start();
      task3.Start();
      task4.Start();

      // wait for input before exiting
      Console.WriteLine("Main method complete. Press enter to finish.");
      Console.ReadLine();
    }

    static void printMessage(object message)
    {
      Console.WriteLine("Message: {0}", message);
    }
  }
}
