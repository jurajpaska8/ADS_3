using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace ADS_3
{
    class Formula
    {
        public List<Clause> Clauses;
        public Formula()
        {
            Clauses = new List<Clause>();
        }

        public void LoadFormula(string path)
        {
            string[] lines = System.IO.File.ReadAllLines(path);

            for(int i = 1; i < lines.Length; i++)
            {
                string[] numbers = lines[i].Split(" ");
                Clauses.Add(new Clause(numbers[0], numbers[1]));
            }
        }

        public void LoadRepresentation(Dictionary<string, bool> valuePairs)
        { 
            foreach(KeyValuePair<string, bool> kp in valuePairs)
            {
                foreach (Clause c in Clauses)
                {
                    // 1 - if first literal equals key from dictionary 
                    if (c.First.Equals(kp.Key))
                    {
                        c.FirstBool = kp.Value;
                    }
                    // 2 - if first literal equals !key from dictionary
                    else if (c.First.Equals($"-{kp.Key}"))
                    {
                        c.FirstBool = !kp.Value;
                    }
                    // 1 --||-- 'second'
                    if (c.Second.Equals(kp.Key))
                    {
                        c.SecondBool = kp.Value;
                    }
                    // 2 - -||- 'second'
                    else if (c.Second.Equals($"-{kp.Key}"))
                    {
                        c.SecondBool = !kp.Value;
                    }
                }
            }

            foreach (Clause c in Clauses)
            {
                if (c.First.Equals("0"))
                {
                    c.First = c.Second;
                    c.FirstBool = c.SecondBool;
                }
                if (c.Second.Equals("0"))
                {
                    c.Second = c.First;
                    c.SecondBool = c.FirstBool;
                }
            }
        }

        public bool IsSatisfied()
        {
            var res = Clauses.Where(c => !c.IsFullfilled());
            if (res.Count() > 0) return false;
            {
                return true;
            }
        }
    }
}
