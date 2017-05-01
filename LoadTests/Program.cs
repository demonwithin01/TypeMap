using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TypeMapper;

namespace LoadTests
{
    class Program
    {
        private const int LoopMax = 10000;

        static void Main( string[] args )
        {
            PerformAutoMapperTimeTest();
            PerformTypeMapTimeTest();
            PerformCopyTimeTest();

            //PerformAutoMapperLoadTest1();
            PerformAutoMapperLoadTest2();
            PerformTypeMapLoadTest();
            PerformCopyLoadTest();

            Console.ReadKey();
        }

        private static void PerformAutoMapperLoadTest1()
        {
            Stopwatch stopwatch = Stopwatch.StartNew();

            for( int i = 0 ; i < LoopMax ; i++ )
            {
                TestClass1 source = new TestClass1();
                TestClass2 destination = new TestClass2();

                AutoMapper.Mapper.Initialize( new AutoMapper.Configuration.MapperConfigurationExpression() { CreateMissingTypeMaps = true } );
                AutoMapper.Mapper.Map( source, destination );
            }

            Console.WriteLine( "Auto Mapping Load Current: " + stopwatch.Elapsed.ToString() );
        }

        private static void PerformAutoMapperLoadTest2()
        {
            Stopwatch stopwatch = Stopwatch.StartNew();

            AutoMapper.Mapper.Initialize( new AutoMapper.Configuration.MapperConfigurationExpression() {  CreateMissingTypeMaps = true } );

            for( int i = 0 ; i < LoopMax ; i++ )
            {
                TestClass1 source = new TestClass1();
                TestClass2 destination = new TestClass2();
                
                AutoMapper.Mapper.Map( source, destination );
            }
            
            Console.WriteLine( "Auto Mapping Load Correct: " + stopwatch.Elapsed.ToString() );
        }

        private static void PerformTypeMapLoadTest()
        {
            Stopwatch stopwatch = Stopwatch.StartNew();

            for ( int i = 0 ; i < LoopMax ; i++ )
            {
                TestClass1 source = new TestClass1();
                TestClass2 destination = new TestClass2();

                TypeMap.Map( source, destination );
            }

            Console.WriteLine( "Type Mapping Load: " + stopwatch.Elapsed.ToString() );
        }

        private static void PerformCopyLoadTest()
        {
            Stopwatch stopwatch = Stopwatch.StartNew();

            for( int i = 0 ; i < LoopMax ; i++ )
            {
                TestClass1 source = new TestClass1();
                TestClass2 destination = new TestClass2();

                destination.MappedInt = source.MappedInt;
                destination.MappedBool = source.MappedBool;
                destination.MappedChar = source.MappedChar;
                destination.MappedString = source.MappedString;
                destination.MappedDouble = source.MappedDouble;
                destination.MappedFloat = source.MappedFloat;
                destination.MappedDecimal = source.MappedDecimal;
            }

            Console.WriteLine( "Regular Mapping Load: " + stopwatch.Elapsed.ToString() );
        }

        private static void PerformAutoMapperTimeTest()
        {
            Stopwatch stopwatch = Stopwatch.StartNew();

            TestClass1 source = new TestClass1();
            TestClass2 destination = new TestClass2();

            AutoMapper.Mapper.Initialize( new AutoMapper.Configuration.MapperConfigurationExpression() { CreateMissingTypeMaps = true } );
            AutoMapper.Mapper.Map( source, destination );

            TypeMap.Map( source, destination );

            Console.WriteLine( "Auto Mapping: " + stopwatch.Elapsed.ToString() );
        }

        private static void PerformTypeMapTimeTest()
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            
            TestClass1 source = new TestClass1();
            TestClass2 destination = new TestClass2();

            TypeMap.Map( source, destination );

            Console.WriteLine( "Type Mapping: " + stopwatch.Elapsed.ToString() );
        }

        private static void PerformCopyTimeTest()
        {
            Stopwatch stopwatch = Stopwatch.StartNew();

            TestClass1 source = new TestClass1();
            TestClass2 destination = new TestClass2();

            destination.MappedInt = source.MappedInt;
            destination.MappedBool = source.MappedBool;
            destination.MappedChar = source.MappedChar;
            destination.MappedString = source.MappedString;
            destination.MappedDouble = source.MappedDouble;
            destination.MappedFloat = source.MappedFloat;
            destination.MappedDecimal = source.MappedDecimal;
            
            Console.WriteLine( "Regular Mapping: " + stopwatch.Elapsed.ToString() );
        }
    }
}
