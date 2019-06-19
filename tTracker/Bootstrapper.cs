using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Reflection;
using BeijerElectronics.CommonSystemServices.IO;

namespace BeijerElectronics.PackageBuilder.Tool
{
    internal class Bootstrapper : IDisposable
    {
        private CompositionContainer m_Container { get; }

        public Bootstrapper()
        {
            m_Container = CreateContainer();
        }

        //public T GetExport<T>() where T : class
        //{
        //    //return m_Container.GetExportedValue<T>();
        //}

        private CompositionContainer CreateContainer()
        {
            var catalog = new AggregateCatalog();

            foreach (Assembly analyzedAssembly in AnalyzedAssemblies)
            {
                catalog.Catalogs.Add(new AssemblyCatalog(analyzedAssembly));
            }

            var container = new CompositionContainer(catalog);
            container.ComposeParts();

            return container;
        }

        private static IEnumerable<Assembly> AnalyzedAssemblies =>
            new[]
            {
                Assembly.GetExecutingAssembly(),           // Add Program assembly
            };

        public void Dispose()
        {
            m_Container.Dispose();
        }
    }
}
