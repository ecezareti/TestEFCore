using System.Threading.Tasks;

namespace TestEFCore
{
    internal interface IRepositoryUnityOfWork<TRepository> where TRepository : class
    {
        TRepository Repository { get; }

        Task<int> Commit();
    }
}