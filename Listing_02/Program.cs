using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Listing_02
{
  class Program
  {
    static void Main(string[] args)
    {
      // use an aAction delegate and a named method
      Task task1 = new Task(new Action(printMessage));
    }
    static void printMessage()
    {

    }
  }
}
