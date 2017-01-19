using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Listing_17
{
  class Program
  {
    static void Main(string[] args)
    {
      // create the cancellation token source
      CancellationTokenSource tokenSource = new CancellationTokenSource();

      // create the cancellation token
      CancellationToken token = tokenSource.Token;

      // create the first task, which we will let run fully
      Task task1 = new Task(() =>
      {
        for (int i = 0; i < 5; i++)
        {
          // check for task cancellation
          token.ThrowIfCancellationRequested();
          // print out a message
          Console.WriteLine("Task 1 - Int value {0} ", i);
          // put the task to sleep for 1 second
          token.WaitHandle.WaitOne(1000);    
        }
        Console.WriteLine("Task 1 completed");
      }, token);

      Task task2 = new Task(() =>
      {
        Console.WriteLine("Task 2 completed");
      }, token);

      // start the tasks
       task1.Start();
        task2.Start();

      // wait for the tasks
      Console.WriteLine("Waiting for tasks to complete.");
      Task.WaitAll(task1, task2);
      Console.WriteLine("Tasks Completed.");

      // wait for input before exiting
      Console.WriteLine("Main method complete. Press enter to finish.");
      Console.ReadLine();
    }
  }
}
