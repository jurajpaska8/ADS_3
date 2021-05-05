using System;
using System.Collections.Generic;
using System.Text;

namespace ADS_3
{
    class ImplicationGraph
    {
        private int verticesCount = 0;
        public Dictionary<string, SortedSet<string>> Vertices;

        public ImplicationGraph(int verticesCount)
        {
            this.verticesCount = verticesCount;
            Vertices = new Dictionary<string, SortedSet<string>>();
            for (int i = 1; i <= verticesCount; i++)
            {
                Vertices.Add("" + i, new SortedSet<string>());
                Vertices.Add("-" + i, new SortedSet<string>());
            }

        }

        public void LoadGraphFromFormula(Formula f)
        { 
            foreach(Clause c in f.Clauses)
            {
                string tmpFirst = c.First.StartsWith("-") ? c.First.Remove(0, 1) : $"-{c.First}";
                string tmpSecond = c.Second.StartsWith("-") ? c.Second.Remove(0, 1) : $"-{c.Second}";
                Vertices.GetValueOrDefault(tmpFirst).Add(c.Second);
                Vertices.GetValueOrDefault(tmpSecond).Add(c.First);
            }
        }

        public ImplicationGraph TransponseGraph()
        {
            ImplicationGraph implicationGraph = new ImplicationGraph(this.verticesCount);
            foreach(KeyValuePair<string, SortedSet<string>> kp in Vertices)
            {
                string v = kp.Key;
                foreach(string s in kp.Value)
                {
                    implicationGraph.Vertices.GetValueOrDefault(s).Add(v);
                }
            }

            return implicationGraph;
        }
    }
}
