﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TypeMapper;
using TypeMapUnitTests.TestObjects;

namespace TypeMapUnitTests
{
    [TestClass]
    public class UnitTests
    {
        [TestMethod]
        public void NormalMap()
        {
            TestClass1 source = new TestClass1();
            TestClass2 destination = new TestClass2();

            TypeMap.Map( source, destination );

            Assert.AreEqual( 10, destination.MappedInt );
            Assert.AreEqual( true, destination.MappedBool );
            Assert.AreEqual( 'j', destination.MappedChar );
            Assert.AreEqual( "Hello World!", destination.MappedString );
            Assert.AreEqual( 6.95d, destination.MappedDouble );
            Assert.AreEqual( 7.42f, destination.MappedFloat );
            Assert.AreEqual( 9.42m, destination.MappedDecimal );

            Assert.AreEqual( "Mapped to a different name", destination.DifferentNameMapping );
            Assert.AreEqual( "I have not been mapped", destination.NotMapped );
            Assert.AreEqual( "Already has value", destination.NotMappedDueToTypeDifference );
            Assert.AreEqual( "Null not mapped", destination.NullNotMapped );

            Assert.IsNotNull( destination.TestClass );
            Assert.AreEqual( "I have a value", destination.TestClass.TestString );
        }
    }
}
