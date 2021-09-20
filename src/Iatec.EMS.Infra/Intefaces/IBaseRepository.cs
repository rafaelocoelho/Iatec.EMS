using Iatec.EMS.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Iatec.EMS.Infra.Intefaces
{
    public interface IBaseRepository<T> where T : Base
    {
        Task<T> Create(T entity);
        Task<T> Update(T entity);
        Task Remove(long id);
        Task<T> Get(long id);
        Task<List<T>> Get();
    }
}
