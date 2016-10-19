using System;
using System.Collections.Generic;

namespace TypeMapper
{
    /// <summary>
    /// Provides mapping functionality to map property values from one object to another.
    /// </summary>
    public static class TypeMap
    {
        /// <summary>
        /// Holds all the current type map definitions.
        /// </summary>
        private static Dictionary<TypeMapDefinitionKey, TypeMapDefinition> _storedDefinitions = new Dictionary<TypeMapDefinitionKey, TypeMapDefinition>();

        /// <summary>
        /// Performs a property mapping of one object to the next.
        /// </summary>
        /// <typeparam name="S">The type to use for the source.</typeparam>
        /// <typeparam name="T">The type to use for the definition.</typeparam>
        /// <param name="source">The source object to map from.</param>
        /// <param name="destination">The destination object to map to.</param>
        public static void Map<S, T>( S source, T destination )
        {
            TypeMapDefinition definition;

            Type sourceType = typeof( S );
            Type destinationType = typeof( T );

            TypeMapDefinitionKey key = new TypeMapDefinitionKey( sourceType, destinationType );

            if ( _storedDefinitions.TryGetValue( key, out definition ) == false )
            {
                definition = CreateDefinition( key );
            }

            definition.PerformMap( source, destination );
        }

        /// <summary>
        /// Creates and caches a type map definition.
        /// </summary>
        /// <typeparam name="S">The type to use for the source.</typeparam>
        /// <typeparam name="T">The type to use for the definition.</typeparam>
        public static void CreateDefinition<S, T>()
        {
            Type sourceType = typeof( S );
            Type destinationType = typeof( T );

            TypeMapDefinitionKey key = new TypeMapDefinitionKey( sourceType, destinationType );

            if ( _storedDefinitions.ContainsKey( key ) == false )
            {
                CreateDefinition( key );
            }
        }

        /// <summary>
        /// Creates a bidirectional mapping definition.
        /// </summary>
        /// <typeparam name="S">The type to be mapped from and to.</typeparam>
        /// <typeparam name="T">The type to be mapped to and from.</typeparam>
        public static void CreateBidirectionalDefinition<S, T>()
        {
            CreateDefinition<S, T>();
            CreateDefinition<T, S>();
        }

        /// <summary>
        /// Creates and returns a type map definition.
        /// </summary>
        /// <param name="key">The type map definition key.</param>
        /// <returns>The generated type map definition.</returns>
        private static TypeMapDefinition CreateDefinition( TypeMapDefinitionKey key )
        {
            TypeMapDefinition definition = new TypeMapDefinition( key.SourceType, key.DestinationType );

            _storedDefinitions.Add( key, definition );

            return definition;
        }
    }
}
