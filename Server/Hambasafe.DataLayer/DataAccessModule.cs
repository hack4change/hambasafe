using Autofac;
using Hambasafe.DataLayer.Entities;
using Microsoft.Data.Entity;

namespace Hambasafe.DataLayer
{
    public class DataAccessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<HambasafeDataContext>().As<DbContext>();
            builder.RegisterGeneric(typeof(EfRepository<>)).As(typeof(IRepository<>));
        }
    }
}
