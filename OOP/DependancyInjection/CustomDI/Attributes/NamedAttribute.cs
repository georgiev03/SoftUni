using System;
using System.Collections.Generic;
using System.Text;

namespace CustomDI.Attributes
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = true)]
    public class NamedAttribute : Attribute
    {
        public NamedAttribute(string name)
        {
            Name = name;
        }

        public string Name { get; }

        
    }
}
