using Iatec.EMS.Domain.Entities;
using Iatec.EMS.Infra.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Iatec.EMS.Infra.Intefaces
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<User> GetByName(string name);
        Task<User> GetByNameAndPassword(string name, string password);
    }
}
