using EFCollections.BLL.DTO.Requests;
using EFCollections.BLL.DTO.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCollections.BLL.Interfaces
{
    public interface IIdentityService
    {
        Task<JwtResponse> SignInAsync(SignInRequest request);

        Task<JwtResponse> SignUpAsync(SignUpRequest request);
    }
}
