using Iatec.EMS.Services.DTOs;

namespace Iatec.EMS.Token.Interfaces
{
    public interface ITokenProvider
    {
        string TokenGernerate(UserDTO user);
    }
}
