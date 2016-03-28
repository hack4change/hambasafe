using System.Reflection;
using Ninject;
using Hambasafe.DataAccess;
using Hambasafe.Logic;

namespace Hambasafe.Logic
{

    public static class Bootstrapper
    {
        private static StandardKernel _kernel;
        private static object syncRoot = new object();
        
        public static IKernel Kernel
        {
            get
            {
                // Singleton https://msdn.microsoft.com/en-us/library/ff650316.aspx
                if (_kernel == null)
                {
                    lock (syncRoot)
                    {
                        if (_kernel == null)
                        {
                            _kernel = new StandardKernel();
                            try
                            {
                                RegisterServices(_kernel);
                                return _kernel;
                            }
                            catch
                            {
                                _kernel.Dispose();
                                throw;
                            }
                        }
                    }
                }
                return _kernel;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Load(Assembly.GetExecutingAssembly());
            kernel.Load(new DataAccessModule());
            kernel.Load(new LogicModule());





        }
    }
}
