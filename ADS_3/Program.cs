using System;
using System.Collections.Generic;

namespace ADS_3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var representation = new Dictionary<string, bool>()
            {
                ["1"] = true,
                ["2"] = false
            };
            Formula formula = new Formula();
            formula.LoadFormula(@"C:\UserData\Z0045C9C\OneDrive - Siemens Healthineers\ing\2sem\ads\ADS_3\ADS_3\data.txt");
            formula.LoadRepresentation(representation);
            var res = formula.IsSatisfied();

            // implication graph
            ImplicationGraph implicationGraph = new ImplicationGraph(2);
            implicationGraph.LoadGraphFromFormula(formula);

            // transpone graph
            ImplicationGraph transponsed = implicationGraph.TransponseGraph();

            // kosaraj
            Kosaraj kosaraj = new Kosaraj(new List<string>() { "1", "2", "-1", "-2" }, implicationGraph, transponsed, new List<string>() { "1", "2"});
            bool resKosaraj = kosaraj.solve2SAT();
        }
    }
}
