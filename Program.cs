using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace YoutubeSamples
{
    #region Reference
    // Youtube video https://www.youtube.com/watch?v=XEeeYTG3hUg
    // pluralsight full video http://bit.ly/ps-async
    #endregion

    class Program
    {
       static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Start");
                //Wait is bad approach, but here i am using to do continue with same thread
                CallFileRaderAsync().Wait();
                Console.WriteLine("End");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }
       
        private async static Task CallFileRaderAsync()
        {
            //reading file method using async
            await foreach(string line in ReadLineAsync())
            {
                Console.WriteLine(line);
            }
        }

        #region when async method not returning anything use Task
        /// <summary>
        /// Bad async apporach
        /// </summary>
        /// <returns></returns>
        private static async void GetNumberByBad()
        {
            await Task.Delay(2000);
        }

        /// <summary>
        /// Good async apporach
        /// </summary>
        /// <returns></returns>
        private static async Task GetNumberByGood()
        {
            await Task.Delay(2000);
        }
        #endregion

        #region Multiple async method calling approach

        #region BadApproach
        ///// <summary>
        ///// Bad approach
        ///// </summary>
        ///// <returns></returns>
        //private static async Task RunAsync()
        //{
        //    await RunInternalAsync();
        //}

        //private static async Task RunInternalAsync()
        //{
        //    await SomethingAsync();
        //}

        //private static async Task SomethingAsync()
        //{
        //    await SomethingInternalAsync()
        //}

        //private static async Task SomethingInternalAsync()
        //{
        //    await Task.Delay(2000);
        //    await Task.Delay(5000);
        //}
        #endregion

        #region GoodApproach
        /// <summary>
        /// Good approach 
        /// exceptional case for incase if your doing http call and database operations
        /// </summary>
        /// <returns></returns>
        private static async Task RunAsync()
        {
            await RunInternalAsync();
        }

        private static Task RunInternalAsync()
        {
            return SomethingAsync();
        }

        private static Task SomethingAsync()
        {
            return SomethingInternalAsync();
        }

        private static Task SomethingInternalAsync()
        {
            return Task.WhenAll(Task.Delay(2000), Task.Delay(5000));
        }
        #endregion

        #endregion

        #region IAsyncEnumerable to read large amount of data async way
        private static async IAsyncEnumerable<string> ReadLineAsync()
        {
            using (var stream = new StreamReader(@"C:\Users\DELL\Downloads\sample-text-file.txt"))
            {
                var line = string.Empty;

                while ((line = await stream.ReadLineAsync()) != null)
                {
                    await Task.Delay(400);
                    yield return line;
                }
            }
        }
        #endregion
    }
}
