using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace TypeMapper
{
    /// <summary>
    /// The definition for how an object is mapped to another object.
    /// </summary>
    public class TypeMapDefinition
    {

        /// <summary>
        /// Holds the property mapping definitions.
        /// </summary>
        private List<PropertyMapDefinition> _propertyMappings;

        /// <summary>
        /// Creates a new type map definition.
        /// </summary>
        /// <param name="sourceType">The source type to be mapped.</param>
        /// <param name="destinationType">The destination type to be mapped.</param>
        public TypeMapDefinition( Type sourceType, Type destinationType )
        {
            this.SourceType = sourceType;
            this.DestinationType = destinationType;

            this._propertyMappings = new List<PropertyMapDefinition>();

            List<PropertyInfo> sourceProperties = this.SourceType.GetProperties().ToList();
            List<PropertyInfo> destinationProperties = this.DestinationType.GetProperties().ToList();

            foreach ( var sourceProperty in sourceProperties )
            {
                if ( sourceProperty.GetMethod == null ) continue;

                TypeMapDestinationAttribute destinationAttribute = sourceProperty.GetCustomAttribute<TypeMapDestinationAttribute>();

                if ( destinationAttribute == null )
                {
                    destinationAttribute = new TypeMapDestinationAttribute( sourceProperty.Name );
                }

                if ( string.IsNullOrEmpty( destinationAttribute.Name ) )
                {
                    destinationAttribute.Name = sourceProperty.Name;
                }

                if ( destinationAttribute.Ignore ) continue;

                if ( destinationAttribute.Type != null && destinationAttribute.Type != destinationType ) continue;

                PropertyInfo destinationProperty = destinationProperties.FirstOrDefault( s => s.Name == destinationAttribute.Name );

                if ( destinationProperty == null ) continue;

                if ( destinationProperty.SetMethod == null ) continue;

                if( ( destinationProperty.PropertyType.IsClass || sourceProperty.PropertyType.IsClass ) && destinationProperty.PropertyType.GetConstructor( Type.EmptyTypes ) != null )
                {
                    this._propertyMappings.Add( new PropertyTypeMapDefinition( new TypeMapDefinition( sourceProperty.PropertyType, destinationProperty.PropertyType ), sourceProperty, destinationProperty, destinationAttribute.MapIfSourceIsNull ) );
                }
                else
                {
                    this._propertyMappings.Add( new PropertyMapDefinition( sourceProperty, destinationProperty, destinationAttribute.MapIfSourceIsNull ) );
                }
            }
        }

        /// <summary>
        /// Performs the actual mapping of all the properties.
        /// </summary>
        /// <param name="source">The source object.</param>
        /// <param name="destination">The destination object.</param>
        internal void PerformMap( object source, object destination )
        {
            foreach ( var mapping in this._propertyMappings )
            {
                mapping.Map( source, destination );
            }
        }
        
        /// <summary>
        /// Gets the source type.
        /// </summary>
        public Type SourceType { get; private set; }

        /// <summary>
        /// Gets the destination type.
        /// </summary>
        public Type DestinationType { get; private set; }
    }
}
