using System;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using TwoTierMVCReview.DAL.Repositories;

namespace MVC5AndUnity.App_Start
{
    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public class UnityConfig
    {
        #region Unity Container
        private static Lazy<IUnityContainer> container = new Lazy<IUnityContainer>(() =>
        {
            var container = new UnityContainer();
            RegisterTypes(container);
            return container;
        });

        /// <summary>
        /// Gets the configured Unity container.
        /// </summary>
        public static IUnityContainer GetConfiguredContainer()
        {
            return container.Value;
        }
        #endregion

        /// <summary>Registers the type mappings with the Unity container.</summary>
        /// <param name="container">The unity container to configure.</param>
        /// <remarks>There is no need to register concrete types such as controllers or API controllers (unless you want to 
        /// change the defaults), as Unity allows resolving a concrete type even if it was not previously registered.</remarks>
        public static void RegisterTypes(IUnityContainer container)
        {
            //Unity Configurations:

            // NOTE: To load from web.config uncomment the line below. Make sure to add a Microsoft.Practices.Unity.Configuration to the using statements.
            // container.LoadConfiguration();

            // Manually Register your types here
            // container.RegisterType<IProductRepository, ProductRepository>();
            //container.RegisterType<IWGProductRepository, WGProductRepository>();
            container.RegisterType<IWGProductRepository, InStockWGProductRepository>();

            //Register by Convention
            //direct the Unity container to scan a collection of assemblies
            //and then automatically register multiple mappings based on a set of
            //predefined rules.  By default it will register all interfaces to
            //a class instance that has the same name 
            //IProducts to Products
            //IFoo to Foo
            //container.RegisterTypes(AllClasses.FromLoadedAssemblies(),
            //    WithMappings.FromMatchingInterface,
            //    WithName.Default,
            //    WithLifetime.PerResolve);
        }
    }
}
