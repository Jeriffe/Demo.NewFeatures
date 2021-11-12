using Demo.Feature_CSharp9;
using Demo.Infrastructure;

var sharps = new List<ICSharp> { new CSharp9(), };

sharps.ForEach(c => c.ShowNewFeatures());

Console.ReadKey();
