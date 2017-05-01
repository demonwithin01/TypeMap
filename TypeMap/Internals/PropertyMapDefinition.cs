using System;
using System.Linq.Expressions;
using System.Reflection;

namespace TypeMapper
{
    /// <summary>
    /// Defines how a property should be mapped across.
    /// </summary>
    internal class PropertyMapDefinition
    {
        /// <summary>
        /// The delegate that holds the definition for retrieving the value the property.
        /// </summary>
        private Delegate _sourceGet;

        /// <summary>
        /// The delegate that holds the definition for setting the value of the property.
        /// </summary>
        private Delegate _destinationSet;

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

            var sParameter = Expression.Parameter( sourceProperty.DeclaringType );
            var sProperty = Expression.Property( sParameter, sourceProperty );
            var sConversion = Expression.Convert( sProperty, sourceProperty.PropertyType );
            var sLambda = Expression.Lambda( sConversion, sParameter );
            this._sourceGet = sLambda.Compile();

            var dParameter = Expression.Parameter( destinationProperty.DeclaringType );
            var dSetParameter = Expression.Parameter( destinationProperty.PropertyType );
            var dProperty = Expression.Property( dParameter, destinationProperty );
            var dConversion = Expression.Convert( dProperty, destinationProperty.PropertyType );
            var dAssign = Expression.Assign( dProperty, dSetParameter );
            
            var dLambda = Expression.Lambda( dAssign, dParameter, dSetParameter );
            this._destinationSet = dLambda.Compile();

            this.AllowNullMapping = allowNullMapping;
        }

        /// <summary>
        /// Performs a normal map where the value on the source object is mapped directly over to the destination object.
        /// </summary>
        /// <param name="source">The source object.</param>
        /// <param name="destination">The destination object.</param>
        internal virtual void Map( object source, object destination )
        {
            var value2 = this._sourceGet.DynamicInvoke( source );

            if( value2 == null && this.AllowNullMapping == false ) return;

            this._destinationSet.DynamicInvoke( destination, value2 );

            //var value = this.SourceProperty.GetValue( source );

            //if ( value == null && this.AllowNullMapping == false ) return;

            //this.DestinationProperty.SetValue( destination, value );
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
