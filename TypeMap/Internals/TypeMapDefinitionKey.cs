using System;

namespace TypeMapper
{
    /// <summary>
    /// The key used for storing the type map definition.
    /// </summary>
    internal struct TypeMapDefinitionKey
    {
        /// <summary>
        /// Creates a new type definition key.
        /// </summary>
        /// <param name="sourceType">The source type to map from.</param>
        /// <param name="destinationType">The destination type to map to.</param>
        internal TypeMapDefinitionKey( Type sourceType, Type destinationType )
        {
            this.SourceType = sourceType;
            this.DestinationType = destinationType;
        }

        /// <summary>
        /// Gets the source type.
        /// </summary>
        internal Type SourceType { get; private set; }

        /// <summary>
        /// Gets the destination type.
        /// </summary>
        internal Type DestinationType { get; private set; }
    }
}
