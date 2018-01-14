using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TypeMapper;

namespace LoadTests
{
    public class PerformanceTest
    {

        /* ----------------------------------------------------------------------------------------------------------------------------------------- */

        #region Class Members

        /// <summary>
        /// The number of loops for the load testing.
        /// </summary>
        private const int LoopMax = 10000;

        #endregion

        /* ----------------------------------------------------------------------------------------------------------------------------------------- */

        #region Constructor & Intialisation

        #endregion

        /* ----------------------------------------------------------------------------------------------------------------------------------------- */

        #region Public Methods

        /// <summary>
        /// Executes the performance comparison.
        /// </summary>
        public void Run()
        {
            TimeSpan[] singleMapTimes = new TimeSpan[ 3 ];
            TimeSpan[] loadedMapTimes = new TimeSpan[ 3 ];

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine( "Single Mapping" );
            Console.ForegroundColor = ConsoleColor.White;

            singleMapTimes[ 0 ] = PerformAutoMapperTimeTest();
            singleMapTimes[ 1 ] = PerformTypeMapTimeTest();
            singleMapTimes[ 2 ] = PerformCopyTimeTest();

            WriteResults( singleMapTimes );

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine( "Load Mapping" );
            Console.ForegroundColor = ConsoleColor.White;

            loadedMapTimes[ 0 ] = PerformAutoMapperLoadTest();
            loadedMapTimes[ 1 ] = PerformTypeMapLoadTest();
            loadedMapTimes[ 2 ] = PerformCopyLoadTest();

            WriteResults( loadedMapTimes );

            Console.WriteLine();

            Console.ReadKey();
        }

        #endregion

        /* ----------------------------------------------------------------------------------------------------------------------------------------- */

        #region Protected Methods

        #endregion

        /* ----------------------------------------------------------------------------------------------------------------------------------------- */

        #region Static Methods

        #endregion

        /* ----------------------------------------------------------------------------------------------------------------------------------------- */

        #region Private Methods

        /// <summary>
        /// Writes the results of the 3 tests out to the console.
        /// </summary>
        private void WriteResults( TimeSpan[] times )
        {
            WriteResult( "AutoMap: ", times, 0 );
            WriteResult( "TypeMap: ", times, 1 );
            WriteResult( "Normal:  ", times, 2 );
        }

        /// <summary>
        /// Writes a single result out to the console.
        /// </summary>
        private void WriteResult( string text, TimeSpan[] times, int testingIndex )
        {
            Console.Write( text );
            Console.ForegroundColor = PositionColor( times, testingIndex );
            Console.WriteLine( times[ testingIndex ].ToString() );
            Console.ForegroundColor = ConsoleColor.White;
        }

        /// <summary>
        /// Gets the colour to use for the time that occurred.
        /// </summary>
        private ConsoleColor PositionColor( TimeSpan[] times, int testingIndex )
        {
            if ( times[ testingIndex ] < times[ ( testingIndex + 1 ) % 3 ] && times[ testingIndex ] < times[ ( testingIndex + 2 ) % 3 ] )
            {
                return ConsoleColor.Green;
            }

            if ( times[ testingIndex ] > times[ ( testingIndex + 1 ) % 3 ] && times[ testingIndex ] > times[ ( testingIndex + 2 ) % 3 ] )
            {
                return ConsoleColor.Red;
            }

            return ConsoleColor.Yellow;
        }

        /// <summary>
        /// Performs the Auto Mapper load test.
        /// </summary>
        private TimeSpan PerformAutoMapperLoadTest()
        {
            Stopwatch stopwatch = Stopwatch.StartNew();

            AutoMapper.Mapper.Initialize( new AutoMapper.Configuration.MapperConfigurationExpression() { CreateMissingTypeMaps = true } );

            for ( int i = 0 ; i < LoopMax ; i++ )
            {
                TestClass1 source = new TestClass1();
                TestClass2 destination = new TestClass2();

                AutoMapper.Mapper.Map( source, destination );
            }

            return stopwatch.Elapsed;
        }

        /// <summary>
        /// Performs the Type Map load test.
        /// </summary>
        private TimeSpan PerformTypeMapLoadTest()
        {
            Stopwatch stopwatch = Stopwatch.StartNew();

            for ( int i = 0 ; i < LoopMax ; i++ )
            {
                TestClass1 source = new TestClass1();
                TestClass2 destination = new TestClass2();

                TypeMap.Map( source, destination );
            }

            return stopwatch.Elapsed;
        }

        /// <summary>
        /// Performs the normal copy load test.
        /// </summary>
        private TimeSpan PerformCopyLoadTest()
        {
            Stopwatch stopwatch = Stopwatch.StartNew();

            for ( int i = 0 ; i < LoopMax ; i++ )
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

            return stopwatch.Elapsed;
        }

        /// <summary>
        /// Performs the AutoMapper single use test.
        /// </summary>
        private TimeSpan PerformAutoMapperTimeTest()
        {
            Stopwatch stopwatch = Stopwatch.StartNew();

            TestClass1 source = new TestClass1();
            TestClass2 destination = new TestClass2();

            AutoMapper.Mapper.Initialize( new AutoMapper.Configuration.MapperConfigurationExpression() { CreateMissingTypeMaps = true } );
            AutoMapper.Mapper.Map( source, destination );

            TypeMap.Map( source, destination );

            return stopwatch.Elapsed;
        }

        /// <summary>
        /// Performs the TypeMap single use test.
        /// </summary>
        private TimeSpan PerformTypeMapTimeTest()
        {
            Stopwatch stopwatch = Stopwatch.StartNew();

            TestClass1 source = new TestClass1();
            TestClass2 destination = new TestClass2();

            TypeMap.Map( source, destination );

            return stopwatch.Elapsed;
        }

        /// <summary>
        /// Performs the regular copy use test.
        /// </summary>
        private TimeSpan PerformCopyTimeTest()
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

            return stopwatch.Elapsed;
        }

        #endregion

        /* ----------------------------------------------------------------------------------------------------------------------------------------- */

        #region Properties

        #endregion

        /* ----------------------------------------------------------------------------------------------------------------------------------------- */

        #region Derived Properties

        #endregion

        /* ----------------------------------------------------------------------------------------------------------------------------------------- */

    }
}
