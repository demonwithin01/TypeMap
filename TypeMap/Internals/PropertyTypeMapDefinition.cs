using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TypeMapper
{
    /// <summary>
    /// Defines how a property should be mapped across.
    /// </summary>
    internal class PropertyTypeMapDefinition : PropertyMapDefinition
    {

        /* ----------------------------------------------------------------------------------------------------------------------------------------- */

        #region Class Members

        #endregion

        /* ----------------------------------------------------------------------------------------------------------------------------------------- */

        #region Constructor & Intialisation

        /// <summary>
        /// Holds the TypeMap definition for mapping to class properties.
        /// </summary>
        private TypeMapDefinition _typeMapDefinition;

        #endregion

        /* ----------------------------------------------------------------------------------------------------------------------------------------- */

        #region Public Methods

        /// <summary>
        /// Creates a property type map definition.
        /// </summary>
        /// <param name="typeMapDefinition"></param>
        /// <param name="sourceProperty">The property info for the source object.</param>
        /// <param name="destinationProperty">The property info for the destination object.</param>
        /// <param name="allowNullMapping">Whether or not to allow NULL values to be mapped.</param>
        public PropertyTypeMapDefinition( TypeMapDefinition typeMapDefinition, PropertyInfo sourceProperty, PropertyInfo destinationProperty, bool allowNullMapping )
            : base( sourceProperty, destinationProperty, allowNullMapping )
        {
            _typeMapDefinition = typeMapDefinition;
        }

        #endregion

        /* ----------------------------------------------------------------------------------------------------------------------------------------- */

        #region Internal Methods

        /// <summary>
        /// Performs a type map from one property value to another.
        /// </summary>
        /// <param name="source">The source object.</param>
        /// <param name="destination">The destination object.</param>
        internal override void Map( object source, object destination )
        {
            object sourceValue = base.SourceProperty.GetValue( source );

            if( sourceValue == null && base.AllowNullMapping == false ) return;

            if ( sourceValue == null )
            {
                base.DestinationProperty.SetValue( destination, null );
                return;
            }

            object destinationValue = base.DestinationProperty.GetValue( destination );

            if ( destinationValue == null )
            {
                destinationValue = Activator.CreateInstance( base.DestinationProperty.PropertyType );
                base.DestinationProperty.SetValue( destination, destinationValue );
            }

            _typeMapDefinition.PerformMap( sourceValue, destinationValue );
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
