using Demo.Feature_CSharp;

List<ICSharp> sharps = new List<ICSharp> { new CSharp11(), };

sharps.ForEach(c => c.ShowNewFeatures());

Console.ReadKey();

