using System.Collections.Generic;
using System.Linq;

namespace MonopolyKata
{
    public class PropertyBroker
    {
        private PropertyBroker() { }

        public PropertyBroker(IDictionary<LocationIndex, Property> properties, IDictionary<LocationIndex, OwnedProperty> ownedProperties)
        {
            Properties = properties;
            OwnedProperties = ownedProperties;
        }

        public IDictionary<LocationIndex, Property> Properties { get; }
        public IDictionary<LocationIndex, OwnedProperty> OwnedProperties { get; }

        public PropertyBroker With(IDictionary<LocationIndex, Property> properties = null, IDictionary<LocationIndex, OwnedProperty> ownedProperties = null)
        {
            return new PropertyBroker(properties ?? Properties, ownedProperties ?? OwnedProperties);
        }
    }

    public static class PropertyBrokerServices
    {
        public static PropertyBroker Create()
        {
            var properties = BoardServices.GetLocationDictionary()
                .Values
                .Where(l => l.Type.Equals(LocationType.Property))
                .Select(l => l.Index)
                .Select(i => PropertyServices.BuildProperty(i))
                .ToDictionary(p => p.LocationIndex);

            return new PropertyBroker(properties, new Dictionary<LocationIndex, OwnedProperty>());
        }

        public static bool PropertyIsOwned(this PropertyBroker broker, LocationIndex index)
        {
            return broker.OwnedProperties.ContainsKey(index);
        }
    }
}
