using PropertyPro.Infrastructure.Responses;
using PropertyPro.Service.Dto.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyPro.Service.Abstract
{
    public interface IAuthService
    {
        public Task<ResponseModel<AuthModel>> RegisterAsync(RegisterDto model);
        public Task<ResponseModel<AuthModel>> LoginAsync(LoginDto model);
    }
}
