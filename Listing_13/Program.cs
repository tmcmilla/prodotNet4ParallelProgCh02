using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Listing_13
{
  class Program
  {
    static void Main(string[] args)
    {
      // create the cancellation token source
      CancellationTokenSource tokenSource = new CancellationTokenSource();

      // create the cancellation token
      CancellationToken token = tokenSource.Token;

      Task task1 = new Task(() =>
      {
        for (int i = 0; i < int.MaxValue; i++)
        {
          // put the task to sleep for 10 seconds
          bool cancelled = token.WaitHandle.WaitOne(10000);
          // print out a message
          Console.WriteLine("Task 1 - Int value {0}.  Cancelled? {1}", i, cancelled);
          // check to see if we have been canceled
          if (cancelled)
          {
            throw new OperationCanceledException(token);
          }
        }
      }, token);

      // start task
      task1.Start();

      // wait for input before exiting
      Console.WriteLine("Press enter to cancel token.");
      Console.ReadLine();

      // cancel the token
      tokenSource.Cancel();

      // wait for input before exiting
      Console.WriteLine("Main method complete. Press enter to finish.");
      Console.ReadLine();
    }
  }
}
