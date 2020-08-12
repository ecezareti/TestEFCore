using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace TestEFCore
{
    public interface IClientRepository
    {
        Task<Client> FindById(int id);
    }

    public sealed class ClientRepository : IClientRepository
    {
        private readonly TestEFCoreContext _context;

        public ClientRepository(TestEFCoreContext context) =>
            _context = context;

        public async Task<Client> FindById(int id)
        {
            return await _context.Set<Client>().FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
