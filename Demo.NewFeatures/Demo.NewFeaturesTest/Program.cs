// See https://aka.ms/new-console-template for more information
using Demo.Feature_CSharp;
using Demo.Feature_CSharp.Infrastructure;
using System.Text;
class Program
{
    static async Task Main(string[] args)
    {
        /*In .net core project,  when we got encoding error:  'GB2312' is not a supported encoding name.
          To resolved it,  we need to do two steps:
            1.Install System.Text.Encoding.CodePages
            2.RegisterProvider programming
                Encoding.RegisterProvider(CodePagesEncodingProvider.Instance); 
        */
        
        Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
        Console.OutputEncoding = Encoding.GetEncoding("gb2312");

        /*
            .NET	    8.x	    C# 12           VS2022      Nov 2023
            .NET	    7.x	    C# 11           VS2022      Nov 2022
            .NET	    6.x	    C# 10           VS2019      Nov 2021
            .NET	    5.x	    C# 9.0          VS2019      Nov 2020

            .NET Core	3.x	    C# 8.0          VS2019      Sep 2019
            .NET Core	2.x	    C# 7.3          VS2017      May 2018
            .NET Core	2.0	    C# 7.2          VS2017      Dec 2017
            .NET Core	2.0	    C# 7.1          VS2017      Aug 2017
            .NET Core	1.x	    C# 7.0          VS2017      Mar 2017

            .NET Framework 4.8	  C# 8.X        VS2019      Sep 2019
            .NET Framework 4.7.2  C# 7.2 & 7.3  VS2017      May 2018
            .NET Framework 4.7.1  C# 7.1        VS2017      Aug 2017
            .NET Framework 4.7	  C# 7.X        VS2017      2017 -2018

            .NET Framework 4.6	  C# 6.0        VS2015      Jul 2015
            .NET Framework 4.5	  C# 5.0        VS2012      Aug 2012
            .NET Framework 4.0    C# 4.0        VS2010      Apr 2010
            .NET Framework 3.5	  C# 3.0        VS2008      Nov 2007
            .NET Framework 2.0	  C# 2.0        VS2005      Nov 2005
            .NET Framework 1.1	  C# 1.2        VS2003      Apr 2003
            .NET Framework 1.0	  C# 1.0        vs2002      Jan 2002

            https://learn.microsoft.com/en-us/dotnet/standard/net-standard?tabs=net-standard-2-1#net-standard-versions
            .NET Standard 2.1	  C# 8.0 & 9.0
            .NET Standard 2.0	  C# 7.x
            .NET Standard 1.x	  C# 5.0 & 6.0
            .NET Standard 1.0	  C# 5.0
         */

        var sharps = new List<ICSharp>
            {
                new CSharp2(),
                new CSharp3(),
                new CSharp4(),
                new CSharp5(),
                new CSharp6(),
                new CSharp7(),
                new CSharp8(),
                new CSharp9(),
                new CSharp10(),
                new CSharp11(),
                new CSharp12(),
            };

        sharps.ForEach(c => c.ShowNewFeatures());

        Console.ReadLine();
    }
}