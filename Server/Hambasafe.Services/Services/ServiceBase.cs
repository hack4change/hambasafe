using Hambasafe.DataLayer;

namespace Hambasafe.Services.Services
{
    public abstract class ServiceBase<T> where T : class
    {
        internal readonly IRepository<T> Repository;

        protected ServiceBase(IRepository<T> repository)
        {
            Repository = repository;
        }
    }
}
