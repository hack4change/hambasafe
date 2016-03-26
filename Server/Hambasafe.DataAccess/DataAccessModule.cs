using Hambasafe.DataAccess.Entities;
using Microsoft.Data.Entity;
using Ninject.Modules;

namespace Hambasafe.DataAccess
{
    public class DataAccessModule : NinjectModule
    {
        public override void Load()
        {
            Bind<DbContext>().To<HambasafeDataContext>();
            Bind(typeof(IRepository<>)).To(typeof(EfRepository<>));
        }
    }
}
