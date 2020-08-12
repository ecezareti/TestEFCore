using System;
using System.Threading.Tasks;

namespace TestEFCore
{
    public class RepositoryUnitOfWork<TRepository> : IRepositoryUnityOfWork<TRepository> where TRepository : class
    {
        private readonly TestEFCoreContext context;

        public RepositoryUnitOfWork(TestEFCoreContext context, TRepository repository)
        {
            Repository = repository ?? throw new ArgumentNullException(nameof(repository));
            this.context = context;
        }

        public TRepository Repository { get; }

        public Task<int> Commit()
        {
            return context.SaveChangesAsync();
        }
    }
}
