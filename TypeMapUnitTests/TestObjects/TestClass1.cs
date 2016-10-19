using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypeMapUnitTests.TestObjects
{
    public class TestClass1
    {
        public TestClass1()
        {
            this.MappedInt = 10;
            this.MappedBool = true;
            this.MappedChar = 'j';
            this.MappedString = "Hello World!";
            this.MappedDouble = 6.95d;
            this.MappedFloat = 7.42f;
            this.MappedDecimal = 9.42m;
        }

        public int MappedInt { get; set; }

        public bool MappedBool { get; set; }

        public char MappedChar { get; set; }

        public string MappedString { get; set; }

        public double MappedDouble { get; set; }

        public float MappedFloat { get; set; }

        public decimal MappedDecimal { get; set; }
    }
}
