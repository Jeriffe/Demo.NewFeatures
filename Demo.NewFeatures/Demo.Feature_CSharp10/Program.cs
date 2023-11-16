// See https://aka.ms/new-console-template for more information
using Demo.Feature_CSharp;

List<ICSharp> sharps = new List<ICSharp> { new CSharp10(), };

sharps.ForEach(c => c.ShowNewFeatures());

Console.ReadKey();

