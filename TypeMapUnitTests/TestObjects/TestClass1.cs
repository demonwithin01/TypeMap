using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TypeMapper;

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

            this.MappedToDifferentName = "Mapped to a different name";
            this.NotMapped = "Not mapped";
            this.NotMappedDueToTypeDifference = "Not mapped due to type difference";
            this.NullNotMapped = null;

            this.TestClass = new TestClass3();
            this.TestClass.TestString = "I have a value";
        }

        public int MappedInt { get; set; }

        public bool MappedBool { get; set; }

        public char MappedChar { get; set; }

        public string MappedString { get; set; }

        public double MappedDouble { get; set; }

        public float MappedFloat { get; set; }

        public decimal MappedDecimal { get; set; }

        [TypeMapDestination( "DifferentNameMapping" )]
        public string MappedToDifferentName { get; set; }

        [TypeMapDestination( Ignore = true )]
        public string NotMapped { get; set; }

        [TypeMapDestination( typeof( TestClass1 ) )]
        public string NotMappedDueToTypeDifference { get; set; }

        [TypeMapDestination( MapIfSourceIsNull = false )]
        public string NullNotMapped { get; set; }

        public TestClass3 TestClass { get; set; }
    }
}
