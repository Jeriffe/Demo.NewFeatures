using Demo.Feature_CSharp;
using Demo.Feature_CSharp.Infrastructure;

var sharps = new List<ICSharp> { new CSharp9(), };

sharps.ForEach(c => c.ShowNewFeatures());

Console.ReadKey();
