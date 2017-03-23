using System;
using System.Reflection;

namespace TypeMapper
{
    /// <summary>
    /// Defines how a property should be mapped across.
    /// </summary>
    internal class PropertyMapDefinition
    {
        /// <summary>
        /// Whether or not to allow NULL values to be mapped.
        /// </summary>
        private bool _allowNullMapping;

        /// <summary>
        /// Creates a property map definition.
        /// </summary>
        /// <param name="sourceProperty">The property info for the source object.</param>
        /// <param name="destinationProperty">The property info for the destination object.</param>
        /// <param name="allowNullMapping">Whether or not to allow NULL values to be mapped.</param>
        internal PropertyMapDefinition( PropertyInfo sourceProperty, PropertyInfo destinationProperty, bool allowNullMapping )
        {
            this.SourceProperty = sourceProperty;
            this.DestinationProperty = destinationProperty;

            this._allowNullMapping = allowNullMapping;
        }

        /// <summary>
        /// Performs a normal map where the value on the source object is mapped directly over to the destination object.
        /// </summary>
        /// <param name="source">The source object.</param>
        /// <param name="destination">The destination object.</param>
        internal virtual void Map( object source, object destination )
        {
            var value = this.SourceProperty.GetValue( source );

            if ( value == null && this._allowNullMapping == false ) return;

            this.DestinationProperty.SetValue( destination, value );
        }

        /// <summary>
        /// Gets the source property information.
        /// </summary>
        internal PropertyInfo SourceProperty { get; private set; }

        /// <summary>
        /// Gets the destination property information.
        /// </summary>
        internal PropertyInfo DestinationProperty { get; private set; }
    }
}
