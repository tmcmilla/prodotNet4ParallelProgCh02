using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Listing_11
{
  class Program
  {
    static void Main(string[] args)
    {
      // create teh cancellation token sources
      CancellationTokenSource tokenSource1 = new CancellationTokenSource();
      CancellationTokenSource tokenSource2 = new CancellationTokenSource();
      CancellationTokenSource tokenSource3 = new CancellationTokenSource();

      // create a composite token source using multiple tokens
      CancellationTokenSource compositeSource =
        CancellationTokenSource.CreateLinkedTokenSource(tokenSource1.Token, tokenSource2.Token, tokenSource3.Token);

      // create a cancellable task using the composite token
      Task task = new Task(() =>
     {
       // wait until the token has been canceled
       compositeSource.Token.WaitHandle.WaitOne();
       // throw a cancellation exception
       throw new OperationCanceledException(compositeSource.Token);
     }, compositeSource.Token);

      // Start the task
      task.Start();

      // cancel one of the original tokens
      tokenSource2.Cancel();

      // wait for input before exiting
      Console.WriteLine("Main method complete. Press enter to finish.");
      Console.ReadLine();

    }
  }
}
