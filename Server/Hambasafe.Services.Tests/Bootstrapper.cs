using Autofac;
using Hambasafe.DataLayer;
using Hambasafe.DataLayer.Entities;
using Hambasafe.Services;
using Microsoft.Data.Entity;

namespace Hambasafe.Logic.UnitTests
{
    public static class Bootstrapper
    {
        private static IContainer _container;
        private static readonly object SyncRoot = new object();

        public static IContainer Container
        {
            get
            {
                // Singleton https://msdn.microsoft.com/en-us/library/ff650316.aspx
                if (_container == null)
                {
                    lock (SyncRoot)
                    {
                        if (_container == null)
                        {
                            var db = new DbContextOptionsBuilder();
                            db.UseInMemoryDatabase();

                            var builder = new ContainerBuilder();
                            builder.RegisterModule<DataAccessModule>();
                            builder.Register(c => new HambasafeDataContext(db.Options)).As<HambasafeDataContext>().As<DbContext>();
                            builder.RegisterModule<ServicesModule>();
                            _container = builder.Build();
                            return _container;
                        }
                    }
                }
                return _container;
            }
        }
    }
}
