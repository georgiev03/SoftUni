using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using CustomDI.Contracts;

namespace CustomDI.Modules
{
    public class Injector
    {
        private IModule module;

        public Injector(IModule module)
        {
            this.module = module;
        }

        private bool CheckForFieldInjection<TClass>()
        {
            return typeof(TClass)
                .GetFields((BindingFlags) 62)
                .Any(f => f.GetCustomAttributes(typeof(InjectAttribute), true).Any());
        }

        private bool CheckForCtorInjection<TClass>()
        {
            return typeof(TClass)
                .GetConstructors()
                .Any(c => c.GetCustomAttributes(typeof(InjectAttribute), true).Any());
        }

    }
}
