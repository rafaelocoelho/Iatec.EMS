using AutoMapper;
using Iatec.EMS.Core.Exceptions;
using Iatec.EMS.Domain.Entities;
using Iatec.EMS.Infra.Intefaces;
using Iatec.EMS.Services.DTOs;
using Iatec.EMS.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Iatec.EMS.Services
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _repository;

        public UserService(
            IMapper mapper,
            IUserRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<UserDTO> Create(UserDTO userDTO)
        {
            User userExists = await _repository.GetByEmail(userDTO.Email);

            if (userExists is not null)
                throw new DomainException("Já existe um usuário cadastrado com o e-mail informado.");

            User user = _mapper.Map<User>(userDTO);
            user.Validate();

            User userCreated = await _repository.Create(user);

            return _mapper.Map<UserDTO>(userCreated);
        }

        public async Task<UserDTO> Update(UserDTO userDTO)
        {
            User userExists = await _repository.Get(userDTO.Id);

            if (userExists is null)
                throw new DomainException("Não existe nunhum usuário com o id informado.");

            User user = _mapper.Map<User>(userDTO);
            user.Validate();

            User userUpdated = await _repository.Update(user);

            return _mapper.Map<UserDTO>(userUpdated);
        }

        public async Task Remove(long id)
        {
            User userExists = await _repository.Get(id);

            if (userExists is null)
                throw new DomainException("Não existe nunhum usuário com o id informado.");

            await _repository.Remove(id);
        }

        public async Task<UserDTO> Get(long id)
        {
            User user = await _repository.Get(id);

            return _mapper.Map<UserDTO>(user);
        }

        public async Task<List<UserDTO>> Get()
        {
            List<User> users = await _repository.Get();

            return _mapper.Map<List<UserDTO>>(users);
        }

        public async Task<UserDTO> GetByEmailAndPassword(string email, string password)
        {
            User user = await _repository.GetByEmailAndPassword(email, password);

            return _mapper.Map<UserDTO>(user);
        }
    }
}
