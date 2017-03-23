using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypeMapUnitTests.TestObjects
{
    public class TestClass2
    {
        public TestClass2()
        {
            this.MappedInt = 5;
            this.MappedBool = false;
            this.MappedChar = 'c';
            this.MappedString = "String";
            this.MappedDouble = 4.73d;
            this.MappedFloat = 1.14f;
            this.MappedDecimal = 2.53m;

            this.DifferentNameMapping = "I have been written over";
            this.NotMapped = "I have not been mapped";
            this.NotMappedDueToTypeDifference = "Already has value";
            this.NullNotMapped = "Null not mapped";
        }

        public int MappedInt { get; set; }

        public bool MappedBool { get; set; }

        public char MappedChar { get; set; }

        public string MappedString { get; set; }

        public double MappedDouble { get; set; }

        public float MappedFloat { get; set; }

        public decimal MappedDecimal { get; set; }

        public string DifferentNameMapping { get; set; }

        public string NotMapped { get; set; }

        public string NotMappedDueToTypeDifference { get; set; }

        public string NullNotMapped { get; set; }
    }
}
