using Iatec.EMS.Api.ViewModels;
using System.Collections.Generic;

namespace Iatec.EMS.Api.Utilitis
{
    public static class Responses
    {
        public static ResultViewModel ApplicationErrorMessage()
        {
            return new ResultViewModel
            {
                Message = "Ocorreu algum erro interno na aplicação, por favor tente novamente",
                Success = false,
                Data = null
            };
        }

        public static ResultViewModel ApplicationErrorMessage(string message)
        {
            return new ResultViewModel
            {
                Message = message,
                Success = false,
                Data = null
            };
        }

        public static ResultViewModel DomainErroMessage(string message)
        {
            return new ResultViewModel
            {
                Message = message,
                Success = false,
                Data = null
            };
        }

        public static ResultViewModel DomainErroMessage(string message, IReadOnlyCollection<string> errors)
        {
            return new ResultViewModel
            {
                Message = message,
                Success = false,
                Data = errors
            };
        }

        public static ResultViewModel UnautorizedErrorMessage()
        {
            return new ResultViewModel
            {
                Message = "A combinação de login e senha está incoreta!",
                Success = false,
                Data = null
            };
        }
    }
}
