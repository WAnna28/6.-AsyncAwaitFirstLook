using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncAwaitFirstLook
{
    // Since the release of .NET 4.5, the C# programming language has been updated with two new keywords
    // that further simplify the process of authoring asynchronous code. When you use the new async and await keywords,
    // the compiler will generate a good deal of threading code on your behalf,
    // using numerous members of the System.Threading and System.Threading.Tasks namespaces.
    //
    // The async keyword of C# is used to qualify that a method, lambda expression, or anonymous method
    // should be called in an asynchronous manner automatically.
    // Simply by marking a method with the async modifier, the .NET Core Runtime will create a new thread of execution
    // to handle the task at hand.
    //
    // Furthermore, when you are calling an async method, the await keyword will automatically
    // pause the current thread from any further activity until the task is complete,
    // leaving the calling thread free to continue.
    class Program
    {
        // The ability to decorate the Main() method with async is new as of C# 7.1.
        // New in C# 9.0, top-level statements are implicitly async.
        static async Task Main()
        {
            Console.WriteLine(" Fun With Async ===>");
            Console.WriteLine(DoWork());

            string message = await DoWorkAsync();
            //Console.WriteLine(message);

            Console.WriteLine("Completed");

            Console.ReadLine();
        }

        static string DoWork()
        {
            Thread.Sleep(5000);
            return "Done with work!";
        }

        static async Task<string> DoWorkAsync()
        {
            return await Task.Run(() =>
            {
                Thread.Sleep(5000);
                return "Done with work!";
            });
        }
    }
}
