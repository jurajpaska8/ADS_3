using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace ADS_3
{
    class Kosaraj
    {
        private Dictionary<string, bool> used;
        private Dictionary<string, int> comp;
        private Dictionary<string, bool> assigment;
        private Stack<string> order;
        private List<string> vertices;
        private List<string> pureVertices;

        private ImplicationGraph g;
        private ImplicationGraph gt;

        public Kosaraj(List<string> vertices, ImplicationGraph g, ImplicationGraph gt, List<string> pureVertices)
        {
            // used vertices
            this.used = new Dictionary<string, bool>();
            vertices.ForEach(v => used.Add(v, false));
            // comp vertices
            this.comp = new Dictionary<string, int>();
            vertices.ForEach(v => comp.Add(v, -1));
            // assigment
            this.assigment = new Dictionary<string, bool>();
            pureVertices.ForEach(v => assigment.Add(v, false));

            //vertices
            this.vertices = vertices;
            this.pureVertices = pureVertices;
            // order in dfs 1
            this.order = new Stack<string>();
            // init graphs
            this.g = g;
            this.gt = gt;
        }

        private void dfs1(string v)
        {
            used.Remove(v);
            used.Add(v, true);
            foreach(string s in g.Vertices[v])
            {
                if(!used.GetValueOrDefault(s))
                {
                    dfs1(s);
                }
            }
            order.Push(v);
        }

        void dfs2(string v, int cl)
        {
            comp[v] = cl;
            foreach (string u in gt.Vertices[v])
            {
                if (comp[u] == -1)
                    dfs2(u, cl);
            }
        }

        public bool solve2SAT()
        {
            foreach(string v in vertices)
            {
                if(!used.GetValueOrDefault(v))
                {
                    dfs1(v);
                }
            }

            int j = 0;
            foreach (string v in vertices)
            {
                string popped = order.Pop();
                if (comp[popped] == -1)
                {
                    dfs2(popped, j++);
                }
            }

            foreach (string v in pureVertices)
            {
                if (comp[v] == comp[$"-{v}"])
                    return false;
                assigment[v] = comp[v] > comp[$"-{v}"];
            }

            return true;
        }

    }
}
