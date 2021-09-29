using Iatec.EMS.Services.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Iatec.EMS.Services.Interfaces
{
    public interface IUserService
    {
        Task<UserDTO> Create(UserDTO userDTO);
        Task<UserDTO> Update(UserDTO userDTO);
        Task Remove(long id);
        Task<UserDTO> Get(long id);
        Task<List<UserDTO>> Get();
        Task<UserDTO> GetByEmailAndPassword(string email, string password);
        string HashValue(string value);
    }
}
