// See https://aka.ms/new-console-template for more information
using Demo.CSharp7;
using Demo.Feature_CSharp10;
using Demo.Feature_CSharp8;
using Demo.Feature_CSharp9;
using Demo.Infrastructure;
using Demo.NewFeatures;
using System.Text;
class Program
{
    static async Task Main(string[] args)
    {
        /*In .net core project,  when we got encoding error:  'GB2312' is not a supported encoding name.
          To resovled it,  we need to do two steps:
            1.Install System.Text.Encoding.CodePages
            2.RegisterProvider programming
                Encoding.RegisterProvider(CodePagesEncodingProvider.Instance); 
        */
        
        Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
        Console.OutputEncoding = Encoding.GetEncoding("gb2312");

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
            };

        sharps.ForEach(c => c.ShowNewFeatures());

        Console.ReadLine();
    }
}