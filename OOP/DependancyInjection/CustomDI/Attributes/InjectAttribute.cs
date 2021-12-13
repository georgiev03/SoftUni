using System;
using System.Collections.Generic;
using System.Text;

namespace CustomDI
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Constructor, AllowMultiple = true)]
    public class InjectAttribute : Attribute
    {
    }
}
