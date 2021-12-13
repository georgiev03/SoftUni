using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CustomDI.Attributes;
using CustomDI.Contracts;

namespace CustomDI.Modules
{
    public abstract class AbstractModule : IModule
    {
        private readonly IDictionary<Type, Dictionary<string, Type>> implementations;

        private readonly IDictionary<Type, object> instances;

        public AbstractModule()
        {
            implementations = new Dictionary<Type, Dictionary<string, Type>>();
            instances = new Dictionary<Type, object>();
        }

        public abstract void Configure();

        protected void CreateMapping<TInter, TImlp>()
        {
            Type implType = typeof(TImlp);
            Type interfaceType = typeof(TInter);

            if (!implementations.ContainsKey(interfaceType))
            {
                implementations[interfaceType] = new Dictionary<string, Type>();
            }

            implementations[interfaceType].Add(implType.Name, implType);
        }
        public Type GetMapping(Type currentInterface, object attribute)
        {
            Type result = null;
            var currentInmlementation = implementations[currentInterface];

            if (currentInmlementation == null || currentInmlementation.Count == 0)
            {
                throw new ArgumentException($"No implementation found for type {currentInterface.Name}");
            }

            if (attribute is InjectAttribute)
            {
                result = currentInmlementation.Values.FirstOrDefault();
            }
            else if (attribute is NamedAttribute named)
            {
                result = currentInmlementation[named.Name];
            }

            return result;
        }

        public object GetInstance(Type type)
        {
            instances.TryGetValue(type, out object value);

            return value;
        }

        public void SetInstance(Type implementation, object instance)
        {
            if (!instances.ContainsKey(implementation))
            {
                instances.Add(implementation, instance);
            }
        }
    }
}
