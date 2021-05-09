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
            formula.LoadFormula(@"C:\UserData\Z0045C9C\OneDrive - Siemens Healthineers\ing\2sem\ads\ADS_3\ADS_3\data2.txt");
            formula.LoadRepresentation(representation);
            var res = formula.IsSatisfied();

            // implication graph
            ImplicationGraph implicationGraph = new ImplicationGraph(formula.VerticesCount);
            implicationGraph.LoadGraphFromFormula(formula);

            // transpone graph
            ImplicationGraph transponsed = implicationGraph.TransponseGraph();

            //vertices 
            List<string> ver = new List<string>();
            List<string> verAll = new List<string>();

            for (int i = 1; i <= formula.VerticesCount; i++)
            {
                ver.Add($"{i}");
                verAll.Add($"{i}");
            }

            for (int i = 1; i <= formula.VerticesCount; i++)
            {
                verAll.Add($"-{i}");
            }

            // kosaraj
            Kosaraj kosaraj = new Kosaraj(verAll, implicationGraph, transponsed, ver);
            bool resKosaraj = kosaraj.solve2SAT();
        }
    }
}
