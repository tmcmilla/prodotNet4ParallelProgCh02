using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Listing_01
{
  class Program
  {
    static void Main(string[] args)
    {
      Task.Factory.StartNew(() =>
     {
       Console.WriteLine("Hello World");
     });
      // wait for input before exiting
      Console.WriteLine("'Main method complete. Press enter to Finish");
      Console.ReadLine();
    }
  }
}
