using Iatec.EMS.Domain.Entities;
using System.Threading.Tasks;

namespace Iatec.EMS.Infra.Intefaces
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<User> GetByEmail(string email);
        Task<User> GetByEmailAndPassword(string email, string password);
    }
}
