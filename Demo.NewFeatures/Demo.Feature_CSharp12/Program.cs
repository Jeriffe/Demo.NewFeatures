using Demo.Feature_CSharp;
using System.Text;

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
                new CSharp12(),
            };


sharps.ForEach(c => c.ShowNewFeatures());

Console.ReadKey();

