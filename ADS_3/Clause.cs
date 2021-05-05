using System;
using System.Collections.Generic;
using System.Text;

namespace ADS_3
{
    class Clause
    {
        public string First { get; set; }
        public string Second { get; set; }
        public bool FirstBool { get; set; } = false;
        public bool SecondBool { get; set; } = false;

        public Clause(string first, string second, bool firstBool, bool secondBool)
        {
            this.First = first;
            this.Second = second;
            this.FirstBool = firstBool;
            this.SecondBool = secondBool;
        }

        public Clause(string first, string second)
        {
            this.First = first;
            this.Second = second;
        }

        public bool IsFullfilled()
        {
            return FirstBool || SecondBool;
        }
    }
}
