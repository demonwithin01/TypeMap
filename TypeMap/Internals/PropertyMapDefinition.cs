using System;
using System.Linq.Expressions;
using System.Reflection;
using System.Reflection.Emit;

namespace TypeMapper
{
    /// <summary>
    /// Defines how a property should be mapped across.
    /// </summary>
    internal class PropertyMapDefinition
    {
        /// <summary>
        /// The get method for retrieving the value of the property from the source object.
        /// </summary>
        private MethodBase _sourceGetMethod;

        /// <summary>
        /// The set method for assigning the value of the property to the destination object.
        /// </summary>
        private MethodBase _destinationSetMethod;

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
            
            this._sourceGetMethod = this.SourceProperty.GetMethod;
            this._destinationSetMethod = this.DestinationProperty.SetMethod;
            
            this.AllowNullMapping = allowNullMapping;
        }

        /// <summary>
        /// Performs a normal map where the value on the source object is mapped directly over to the destination object.
        /// </summary>
        /// <param name="source">The source object.</param>
        /// <param name="destination">The destination object.</param>
        internal virtual void Map( object source, object destination )
        {
            var sourceValue = this._sourceGetMethod.Invoke( source, null );

            if ( sourceValue == null && this.AllowNullMapping == false ) return;

            this._destinationSetMethod.Invoke( destination, new object[] { sourceValue } );
        }

        /// <summary>
        /// Gets the source property information.
        /// </summary>
        internal PropertyInfo SourceProperty { get; private set; }

        /// <summary>
        /// Gets the destination property information.
        /// </summary>
        internal PropertyInfo DestinationProperty { get; private set; }

        /// <summary>
        /// Whether or not to allow NULL values to be mapped.
        /// </summary>
        internal bool AllowNullMapping { get; private set; }
    }
}
