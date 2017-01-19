using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Listing_23
{
  class Program
  {
    static void Main(string[] args)
    {
      // define the function
      Func<string> taskBody = new Func<string>(() =>
      {
        Console.WriteLine("Task body working...");
        return "Task Result";
      });

      // create the lazy variable
      Lazy<Task<string>> lazyData = new Lazy<Task<string>>(() =>
        Task<string>.Factory.StartNew(taskBody));

      Console.WriteLine("Calling lazy variable");
      Console.WriteLine("Result from task: {0}", lazyData.Value.Result);

      // do the same thing in a single statement
      Lazy<Task<string>> lazyData2 = new Lazy<Task<string>>(
        () => Task<string>.Factory.StartNew(() =>
        {
          Console.WriteLine("Task body working...");
          return "Task Result";
        }
        ));

      Console.WriteLine("Calling second lazy variable");
      Console.WriteLine("Result from task: {0}", lazyData2.Value.Result);

      // wait for input before exiting
      Console.WriteLine("Main method complete. Press enter to finish.");
      Console.ReadLine();

    }
  }
}
