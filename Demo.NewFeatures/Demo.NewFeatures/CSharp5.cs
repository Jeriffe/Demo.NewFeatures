using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Demo.Infrastructure;

namespace Demo.NewFeatures
{
    public class CSharp5 : ICSharp
    {
        public CSharp5()
        {

        }
        public void ShowNewFeatures()
        {
            AsyncFeature();

            CallerInformation();
        }

        private void CallerInformation()
        {
            /*
             * message: Something happened
             * member name: CallerInformation
             * source file path: D:\Jeriffe\Examples\C#\Demo.NewFeatures\Demo.NewFeatures\Demo.NewFeatures\CSharp5.cs
             * source line number: 31
             */
            TraceMessage("Something happened");
        }

        private async void AsyncFeature()
        {
            var user = await GetUserAsync(1);
        }

        private void TraceMessage(string message,
        [CallerMemberName] string memberName = "",
        [CallerFilePath] string sourceFilePath = "",
        [CallerLineNumber] int sourceLineNumber = 0)
        {
            System.Diagnostics.Trace.WriteLine("message: " + message);
            System.Diagnostics.Trace.WriteLine("member name: " + memberName);
            System.Diagnostics.Trace.WriteLine("source file path: " + sourceFilePath);
            System.Diagnostics.Trace.WriteLine("source line number: " + sourceLineNumber);
        }

        public async Task<User> GetUserAsync(int userId)
        {
            // Code omitted:

            return null;
        }
    }

    public class User
    {
    }
}
