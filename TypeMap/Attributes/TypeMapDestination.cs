using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypeMapper
{
    [AttributeUsage( AttributeTargets.Property, AllowMultiple = false )]
    public class TypeMapDestinationAttribute : Attribute
    {

        /* ----------------------------------------------------------------------------------------------------------------------------------------- */

        #region Class Members

        #endregion

        /* ----------------------------------------------------------------------------------------------------------------------------------------- */

        #region Constructor & Intialisation

        /// <summary>
        /// Creates a new type map destination.
        /// </summary>
        public TypeMapDestinationAttribute()
        {
            SetDefaults();
        }

        /// <summary>
        /// Creates a new type map destination for the specified destination name.
        /// </summary>
        /// <param name="name">The name of the property on the destination class.</param>
        public TypeMapDestinationAttribute( string name )
            : this ( name, null )
        {

        }

        /// <summary>
        /// Creates a new type map destination for the container class type.
        /// </summary>
        /// <param name="type">The class type that contains the property. If the matching type is not found, this property will not be mapped.</param>
        public TypeMapDestinationAttribute( Type type )
            : this ( null, type )
        {

        }

        /// <summary>
        /// Creates a new type map destination for the specified destination name and container class type.
        /// </summary>
        /// <param name="name">The name of the property on the destination class.</param>
        /// <param name="type">The class type that contains the property. If the matching type is not found, this property will not be mapped.</param>
        public TypeMapDestinationAttribute( string name, Type type )
        {
            SetDefaults();

            this.Name = name;
            this.Type = type;
        }

        #endregion

        /* ----------------------------------------------------------------------------------------------------------------------------------------- */

        #region Public Methods

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
        /// Sets the default values.
        /// </summary>
        private void SetDefaults()
        {
            this.MapIfSourceIsNull = true;
        }

        #endregion

        /* ----------------------------------------------------------------------------------------------------------------------------------------- */

        #region Properties

        /// <summary>
        /// Whether or not to ignore this property when mapping to the destination.
        /// </summary>
        public bool Ignore { get; set; }

        /// <summary>
        /// Whether or not to map the value if the source has a null value. True by default.
        /// </summary>
        public bool MapIfSourceIsNull { get; set; }

        /// <summary>
        /// The name of the property to map to.
        /// </summary>
        public string Name { get; internal set; }

        /// <summary>
        /// The class type that the destination property must be defined against. If nothing is provided, all types are valid.
        /// </summary>
        public Type Type { get; private set; }
        
        #endregion

        /* ----------------------------------------------------------------------------------------------------------------------------------------- */

        #region Derived Properties

        #endregion

        /* ----------------------------------------------------------------------------------------------------------------------------------------- */

    }
}
